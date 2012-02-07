using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Xml;

namespace ObvTrojanClient
{
    public class ObvTrojanController
    {
        public string ClientKey { get { return _clientKey; } }

        public bool IsAutoUpdating
        {
            get
            {
                return _isAutoUpdating;
            }
        }

        public bool IsLoggedIn
        {
            get
            {
                return _isLoggedIn;
            }
        }

        public string CurrentIP { get { return _model.GetDetectedIPAddress(); } }


        private string _clientKey;
        private bool _isAutoUpdating;
        private volatile bool _isLoggedIn;
        private long _period = 10 * 6 * 1000;
        private object _threadLock = new object();
        private string _currentIP;

        private ObvTrojanModel _model;
        private ObvTrojanView _view;
        private Timer _timer;



        public ObvTrojanController(ObvTrojanView view)
        {
            _view = view;
            _model = new ObvTrojanModel(this, _view);
        }

        public void BeginAutoupdate()
        {
            if (!IsLoggedIn)
                throw new ApplicationException("You must be logged in to do that.");

            int? subdomainID = _view.SubdomainID;
            bool useCurrentIP = _view.UseCurrentIP;
            string ip = useCurrentIP ? null : _view.IPAddress;

            if (validate(subdomainID, ip))
            {
                _isAutoUpdating = true;
                

                _timer = new Timer(new TimerCallback(delegate
                {
                    string newip;
                    try
                    {
                        newip = _model.Update(_clientKey, subdomainID.Value, ip);
                        _view.DisplaySuccessMessage(String.Format("Heartbeat sent at {0}.", DateTime.Now));
                        if (useCurrentIP)
                            _view.SetIP(subdomainID.Value, newip);
                    }
                    catch
                    {
                        //The subdomain probably got deleted 
                        EndAutoupdate();
                        RefreshDomainList();
                        Thread.Sleep(100); //previous two lines give msgs so make sure the next one occurs last.  HACK
                        _view.DisplayErrorMessage("Unknown error.");
                    }

                }), null, 0, _period);

                _view.RefreshUI();
            }
        }

        public void EndAutoupdate()
        {
            if (_timer != null)
            {
                _timer.Dispose();
                _timer = null;
            }
            _isAutoUpdating = false;
            _view.RefreshUI();
            _view.DisplaySuccessMessage("Heartbeat disabled.");
        }

        public void Login()
        {
            string username = _view.UserName;
            string password = _view.Password;

            new Thread(delegate()
            {
                lockTryAndReportErrors(delegate
                {
                    if (_model.TryLogin(username, password, out _clientKey))
                    {
                        _view.SetLoggedIn();
                        _isLoggedIn = true;
                        refreshDomainList();
                    }
                    else
                    {
                        _view.DisplayErrorMessage("Invalid username or password.");
                        _view.ShowTab("myDomainsTabPage");
                        _isLoggedIn = false;
                    }
                });

                _view.RefreshUI();

            }).Start();
        }

        public void Login(string clientKey)
        {
            _isLoggedIn = true;
            _clientKey = clientKey;
        }

        public void Logout()
        {
            _isLoggedIn = false;
            EndAutoupdate();
            _view.DisplaySuccessMessage("Logged out.");
            _view.RefreshUI();
        }

        public void UpdateSubdomain()
        {
            //TODO: TEST
            if (!IsLoggedIn)
                throw new ApplicationException("Must be logged in to do that.");

            int? subdomainID = _view.SubdomainID;
            string ip = _view.UseCurrentIP ? null : _view.IPAddress;
            bool useCurrentIP = _view.UseCurrentIP;

            if (validate(subdomainID, ip))
            {
                new Thread((ThreadStart)delegate
                {
                    lockTryAndReportErrors(delegate
                    {
                        try
                        {
                            string newip = _model.Update(_clientKey, subdomainID.Value, ip);
                            _view.DisplaySuccessMessage("Updated");
                            _view.SetIP(subdomainID.Value, newip);
                        }
                        catch
                        {
                            //The subdomain probably got deleted 
                            _view.DisplayErrorMessage("Unknown error.");
                        }
                    });
                }).Start();
            }
        }

        public void RefreshDomainList()
        {
            RefreshDomainList(null);
        }

        public void RefreshDomainList(Action callback)
        {
            if (!IsLoggedIn)
                throw new ApplicationException("Must be logged in to do that.");

            new Thread((ThreadStart)delegate
            {
                lockTryAndReportErrors(delegate
                {
                    refreshDomainList();
                    _view.DisplaySuccessMessage("Subdomain list refreshsed.");

                    if (callback != null)
                        callback();
                });
            }).Start();
        }

        private void refreshDomainList()
        {
            IList<Subdomain> subdomains = _model.GetSubdomainList(_clientKey);
            _view.SetSubdomainList(subdomains);
        }

        private void lockTryAndReportErrors(Action action)
        {
            lock (_threadLock)
            {
                try
                {
                    action();
                }
                catch (WebException e)
                {
                    _view.DisplayErrorMessage(String.Format("Network error. {0}", e.Message));
                }
                catch (XmlException)
                {
                    _view.DisplayErrorMessage("Unexpected error.");
                }
            }
        }

        //todo: better name
        private bool validate(int? subdomainID, string ip)
        {
            IPAdressValidator ipv = new IPAdressValidator();

            if (!(ip == null || ipv.Validate(ip)))
            {
                _view.DisplayErrorMessage("IP address is invalid.");
                return false;
            }

            if (!subdomainID.HasValue)
            {
                _view.DisplayErrorMessage("Must choose a subdomain.");
                return false;
            }

            return true;
        }
    }
}
