
namespace ObvTrojanClient
{
    public class Subdomain
    {
        public int ID { get; set; }
        public string IP { get; set; }
        public string Name { get; set; }
        public bool UseCurrentIP { get; set; }

        public Subdomain(int id, string ip, string name)
        {
            ID = id;
            IP = ip;
            Name = name;
            UseCurrentIP = false;
        }
    }
}
