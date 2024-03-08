using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Models
{
    public class BankAccountType
    {
        [PrimaryKey, AutoIncrement]
        public int BankAccountTypeId { get; set; }
        public string BankDescription { get; set; }

   
    
    
    }
}
