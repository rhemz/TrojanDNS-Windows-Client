using System.Net;

namespace ObvTrojanClient
{
    class IPAdressValidator
    {
        public bool Validate(string ipaddress)
        {
            IPAddress ip = new IPAddress(0);
            return IPAddress.TryParse(ipaddress, out ip);
        }
    }
}
