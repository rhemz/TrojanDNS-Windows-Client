using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace ObvTrojanClient
{
    public partial class ObvTrojanView : Form
    {
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool SetForegroundWindow(IntPtr hwnd);

        ObvTrojanController _controller;
        NotifyIcon _notifyIcon;

        IList<Subdomain> _subdomains;

        public static string appName = "TrojanDNS_Client";
        public static string appUrl = @"https://trojandns.com";

        public int? SubdomainID
        {
            get { return (int?)domainComboBox.SelectedValue; }
            set { domainComboBox.SelectedItem = value; }
        }

        public string IPAddress
        {
            get { return ipTextBox.Text; }
            set { ipTextBox.Text = value; }
        }

        public string Password
        {
            get { return passwordTextbox.Text; }
            set { passwordTextbox.Text = value; }
        }

        public bool UseCurrentIP
        {
            get { return useCurrentIPCheckBox.Checked; }
            set { useCurrentIPCheckBox.Checked = value; }
        }

        public string UserName
        {
            get { return usernameTextbox.Text; }
            set { usernameTextbox.Text = value; }
        }

        public ObvTrojanView()
        {
            InitializeComponent();

            _controller = new ObvTrojanController(this);
            setFormIcon();
            createNotifyIcon();
        }

        public void DisplayErrorMessage(string msg)
        {
            BeginInvoke((Action)delegate
            {
                statusTextBox.Clear();
                statusTextBox.SelectionColor = Color.Red;
                statusTextBox.SelectedText = String.Format(" {0}{1}", msg, Environment.NewLine);
            });
        }

        public void DisplaySuccessMessage(string msg)
        {
            BeginInvoke((Action)delegate
            {
                statusTextBox.Clear();
                statusTextBox.SelectionColor = Color.Green;
                statusTextBox.SelectedText = String.Format(" {0}{1}", msg, Environment.NewLine);
            });
        }

        public void RefreshUI()
        {
            BeginInvoke((Action)delegate
            {
                setFormState();
            });
        }

        public void SetIP(int subdomainID, string ip)
        {
            BeginInvoke((Action)delegate
            {
                ipTextBox.Text = ip;

                Subdomain subdomain = getSubdomain(subdomainID);
                if (subdomain != null)
                {
                    subdomain.IP = ip;
                    subdomain.UseCurrentIP = useCurrentIPCheckBox.Checked;
                }
            });
        }

        public void SetLoggedIn()
        {
            BeginInvoke((Action)delegate
            {
                DisplaySuccessMessage("Logged in successfully.");
                tabControl.SelectTab(myDomainsTabPage);
            });
        }

        public void ShowTab(string page)
        {
            BeginInvoke((Action) delegate
            {
                tabControl.SelectTab(page);
            });

        }

        public void SetSubdomainList(IList<Subdomain> subdomains)
        {
            BeginInvoke((Action)delegate
            {
                setSubdomainList(subdomains);
            });
        }

        private void setSubdomainList(IList<Subdomain> subdomains)
        {
            _subdomains = subdomains;
            domainComboBox.DisplayMember = "Name";
            domainComboBox.ValueMember = "ID";
            domainComboBox.DataSource = new BindingSource(subdomains, null);

        }

        private void createNotifyIcon()
        {
            _notifyIcon = new NotifyIcon();
            _notifyIcon.Text = "Trojan DNS";
            _notifyIcon.Icon = new Icon(GetType(), "icon.ico");
            _notifyIcon.Visible = true;
            //this.ShowInTaskbar = false;


            _notifyIcon.DoubleClick += delegate(object sender, EventArgs e)
            {
                this.ShowInTaskbar = true;
                Show();
                this.WindowState = FormWindowState.Normal;
                BringToFront();
                SetForegroundWindow(this.Handle);
            };
        }

        private void setFormIcon()
        {
            this.Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }

        private void toggleLogin()
        {
            if (_controller.IsLoggedIn)
                _controller.Logout();
            else
                _controller.Login();
        }

        private Subdomain getSubdomain(int subdomainID)
        {
            foreach (Subdomain subdomain in _subdomains)
                if (subdomain.ID == subdomainID)
                    return subdomain;
            return null;
        }

        private void setFormState()
        {
            bool loggedIn = _controller.IsLoggedIn;
            bool auto = _controller.IsAutoUpdating;
            bool useCurrentIP = useCurrentIPCheckBox.Checked;

            toggleHeartbeatButton.Text = auto ? "Disable Autoupdate." : "Enable Autoupdate.";
            toggleHeartbeatButton.Enabled = loggedIn;
            updateButton.Enabled = loggedIn && !auto;
            useCurrentIPCheckBox.Enabled = loggedIn && !auto;
            domainComboBox.Enabled = loggedIn && !auto;
            usernameTextbox.Enabled = !loggedIn;
            passwordTextbox.Enabled = !loggedIn;
            refreshButton.Enabled = loggedIn && !auto;
            loginButton.Text = loggedIn ? "Logout" : "Login";
            //loginButton.Enabled = !loggedIn;
            ipTextBox.Enabled = loggedIn && !auto && !useCurrentIP;

            if (!loggedIn)
                domainComboBox.DataSource = null;
        }

        private void loadSettings()
        {
            WindowState = (FormWindowState)Properties.Settings.Default["WindowState"];

            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                     ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            string appName = "TrojanDNS_Client";

            string autoStart = (string)rk.GetValue(appName);
            startAutomaticallyCheckBox.Checked = (autoStart != null);

            if ((bool)Properties.Settings.Default["LoggedIn"])
            {
                usernameTextbox.Text = (string)Properties.Settings.Default["UserName"];
                string clientKey = (string)Properties.Settings.Default["Key"];
                _controller.Login(clientKey);

                if ((bool)Properties.Settings.Default["HasSubdomainID"])
                {
                    _controller.RefreshDomainList(delegate()
                    {
                        BeginInvoke((Action)delegate()
                        {
                            try
                            {
                                domainComboBox.SelectedValue = (int)Properties.Settings.Default["SubdomainID"];

                                if ((bool)Properties.Settings.Default["IsAutoUpdating"])
                                {
                                    _controller.BeginAutoupdate();
                                }
                            }
                            catch (Exception)
                            {
                                DisplayErrorMessage("Subdomain no longer exists.");
                            }
                        });
                    });
                }
            }
            else
            {
                tabControl.SelectTab(settingsTabPage);
            }
        }

        void saveSettings()
        {
            Properties.Settings.Default["UserName"] = usernameTextbox.Text;
            Properties.Settings.Default["Key"] = _controller.ClientKey;
            Properties.Settings.Default["WindowState"] = (int)WindowState;

            if (domainComboBox.Items.Count > 0)
            {
                Properties.Settings.Default["SubdomainID"] = (int)domainComboBox.SelectedValue;
                Properties.Settings.Default["HasSubdomainID"] = true;
            }
            else
            {
                Properties.Settings.Default["SubdomainID"] = 0;
                Properties.Settings.Default["HasSubdomainID"] = false;
            }

            Properties.Settings.Default["UseCurrentIP"] = useCurrentIPCheckBox.Checked;
            Properties.Settings.Default["IsAutoUpdating"] = _controller.IsAutoUpdating;
            Properties.Settings.Default["LoggedIn"] = _controller.IsLoggedIn;

            Properties.Settings.Default.Save();
        }

        private void updateButtonClick(object sender, EventArgs e)
        {
            _controller.UpdateSubdomain();
        }

        private void useCurrentIPCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (useCurrentIPCheckBox.Checked)
            {
                ipTextBox.Text = _controller.CurrentIP;
            }

            setFormState();
        }

        private void refreshButtonClick(object sender, EventArgs e)
        {
            _controller.RefreshDomainList();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toggleHeartbeatButton_Click(object sender, EventArgs e)
        {
            if (_controller.IsAutoUpdating)
            {
                _controller.EndAutoupdate();
            }
            else
            {
                _controller.BeginAutoupdate();
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            toggleLogin();
        }

        private void startAutomaticallyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            string appName = "TrojanDNS_Client";

            if (startAutomaticallyCheckBox.Checked)
                rk.SetValue(appName, Application.ExecutablePath.ToString());
            else
                rk.DeleteValue(appName, false);
        }

        private void passwordOrUsernameTextboxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //loginButton.Enabled = false;
                toggleLogin();
            }
        }

        private void domainComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Subdomain subdomain = null;

            try
            {
                subdomain = getSubdomain((int)domainComboBox.SelectedValue);
            }
            catch { }

            if (subdomain != null)
            {
                ipTextBox.Text = subdomain.IP;
                useCurrentIPCheckBox.Checked = subdomain.UseCurrentIP;
            }

        }

        private void trojanLogo_DoubleClick(object sender, EventArgs e)
        {
            Process.Start(appUrl);
        }

        private void ObvTrojanView_Load(object sender, EventArgs e)
        {
            loadSettings();
            setFormState();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            if (disposing)
            {
                _notifyIcon.Dispose();
            }

            base.Dispose(disposing);
        }

        private void ObvTrojanView_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveSettings();
        }

        private void ObvTrojanView_Resize(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                this.ShowInTaskbar = false;
                Hide();
            }
        }

    }
}
