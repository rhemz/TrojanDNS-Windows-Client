using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;


namespace ObvTrojanClient
{
    public class ObvTrojanModel
    {
        private ObvTrojanController _controller;

        private static Uri _baseUrl = new Uri(@"https://trojandns.com/rest/subdomains/");
        private static Uri _keyUrl = new Uri(@"https://trojandns.com/rest/account/key/");
        private static Uri _ipUrl = new Uri(@"https://trojandns.com/ip");

        public ObvTrojanModel(ObvTrojanController controller, ObvTrojanView view)
        {
            _controller = controller;
        }

        public string GetDetectedIPAddress()
        {
            string data;
            using (WebClient client = new WebClient())
            {
                client.Proxy = null;
                data = client.DownloadString(_ipUrl);
            }

            return data;
        }

        public IList<Subdomain> GetSubdomainList(string clientKey)
        {
            IList<Subdomain> subdomains = new List<Subdomain>();

            string url = _baseUrl.ToString() + @"?key=" + clientKey;
            XmlDocument doc = new XmlDocument();
            string data;

            using (WebClient client = new WebClient())
            {
                client.Proxy = null;
                data = client.DownloadString(url);
            }

            doc.Load(new StringReader(data));
            XmlNodeList nodes = doc.SelectNodes("//item");

            if (nodes != null)
            {
                foreach (XmlNode node in nodes)
                {
                    string domainName = node.SelectSingleNode("descendant::domain_name").InnerText;
                    string subdomainName = node.SelectSingleNode("descendant::subdomain_name").InnerText;
                    int subdomain_id = Int32.Parse(node.SelectSingleNode("descendant::subdomain_id").InnerText);
                    string ip = node.SelectSingleNode("descendant::bound_ip").InnerText;
                    Subdomain subdomain = new Subdomain(subdomain_id, ip, subdomainName + "." + domainName);
                    subdomains.Add(subdomain);
                }
            }

            return subdomains;
        }

        public bool TryLogin(string username, string password, out string clientKey)
        {
            string response;

            using (WebClient wc = new WebClient())
            {
                wc.Proxy = null;
                NameValueCollection nvc = new NameValueCollection();
                nvc.Add("username", username);
                nvc.Add("password", password);

                byte[] byteResponse = wc.UploadValues(_keyUrl, nvc);
                UTF8Encoding utf8 = new UTF8Encoding();
                response = utf8.GetString(byteResponse);
            }

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(response);

            if (getXmlSucces(xml))
            {
                clientKey = xml.SelectSingleNode("//key").InnerText.Trim();
                return true;
            }
            else
            {
                clientKey = "";
                return false;
            }
        }

        public string Update(string clientKey, int subdomainID, string ip)
        {
            string url = _baseUrl.ToString() + subdomainID.ToString() + @"?key=" + clientKey;
            byte[] data = { };

            if (!String.IsNullOrEmpty(ip))
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                data = utf8.GetBytes("ip=" + ip);
            }

            Console.WriteLine(url);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Proxy = null;
            request.Method = "PUT";
            request.ContentLength = data.Length;
            request.ContentType = "application/x-www-form-urlencoded";
            Stream postData = request.GetRequestStream();
            postData.Write(data, 0, data.Length);

            XmlDocument doc = new XmlDocument();

            using (WebResponse response = request.GetResponse())
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                doc.Load(stream);
            }

            return getIPAddress(doc);
        }

        private static bool getXmlSucces(XmlDocument xml)
        {
            return xml.SelectSingleNode("//success").InnerText == "true";
        }

        private static string getXmlErrorMessage(XmlDocument xml)
        {
            return xml.SelectSingleNode("//message").InnerText;
        }

        private static string getIPAddress(XmlDocument xml)
        {
            return xml.SelectSingleNode("//ip").InnerText;
        }
    }
}

