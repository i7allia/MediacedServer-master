using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediacedServer.Prefs
{

    
    public class Database
    {
        public string connectionString;
        
        public Database()
        {
            connectionString = "Data Source=192.168.56.1\\NODE2;Initial Catalog=Mediaced;Persist Security Info=False;User ID=sa;Password=Pa$$w0rd";
        }
    }
}
