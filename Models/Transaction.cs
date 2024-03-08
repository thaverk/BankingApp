
using SQLite;
using System;
using System.Collections.Generic;
using SQLiteNetExtensions.Attributes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Models
{
    public class Transaction
    {
        [PrimaryKey,AutoIncrement]
        public int TransactionID { get; set; }
        public decimal TransactionAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionDescription { get; set; }
        [ForeignKey(typeof(TransactionType))]
        public int TransactionTypeID { get; set; }
        [OneToOne]
    public TransactionType TransactionType { get; set; }
        [ForeignKey(typeof(BankAccount))]
        public int BankAccountID { get;set; }
        [ManyToOne]
        public BankAccount BankAccount { get; set; }
    }
}
