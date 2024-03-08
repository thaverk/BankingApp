using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Models
{
    public class Bank
    {

        [PrimaryKey,AutoIncrement] 
        public int BankId { get; set; }
        
        public string BankName { get; set; }
        public int BankBranchCode { get; set;}
        
        [OneToMany(CascadeOperations =CascadeOperation.All)]
        public List<Client>clients { get; set; } 
    
        public Bank() 
        {
        clients= new List<Client>();
        
        }
    }
        



}
