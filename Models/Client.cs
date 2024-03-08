using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Models
{
    public class Client
    {
        [PrimaryKey,AutoIncrement]
        public int ClientID { get; set; }

        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string ClientID_number { get; set; }
        public DateTime CLient_DateOfBirth { get; set; }
        public string ClientEmail { get; set; }
        public string ClientContactnumber { get; set; }
        public string ClientAddress { get; set;}

        [ForeignKey(typeof(ClientType))]
        public int ClientTypeID { get; set; }

       [OneToOne] //[ForeignKey(typeof(Client))]
        public ClientType ClientType { get; set; }

        [ForeignKey(typeof(Bank))]
        public int BankID { get; set; }

        [ManyToOne] //Code not needed
        public Bank Bank { get; set;}
       
        [OneToMany(CascadeOperations = CascadeOperation.All)]
      public  List<BankAccount> BankAccounts { get; set; }
         
        public Client() 
        { BankAccounts = new List<BankAccount>(); }
    }
}
