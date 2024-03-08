using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Models
{
    public class ClientType
    {
        [PrimaryKey, AutoIncrement]
        public int ClientTypeID { get; set; }

        public string ClientTypeDescription { get; set; }
        public int MyProperty {  get; set; }

    }
}
