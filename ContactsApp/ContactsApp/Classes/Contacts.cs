using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Classes
{
    public class Contacts
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public  string name{ get; set; }
        public string email { get; set; }
        public string phone { get; set; }

        public override string ToString()
        {
            return $"{name}-{email}-{phone}";
        }
    }
}
