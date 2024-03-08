using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Models
{
    public class BankAccount
    {
        [PrimaryKey, AutoIncrement]
        public int BankAccountID { get; set; }
        public decimal Balance { get; set; } 
        public string BankAccountNumber { get; set; }
        [ForeignKey(typeof(BankAccountType))]
        public int BankAccountTypeID { get; set; }
        [OneToOne]
        public BankAccountType BankAccountType { get; set; }
        [ForeignKey(typeof(Client))]
       public int ClientID { get; set; }

        [ManyToOne]
        public Client Client { get; set; }
      
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Transaction> Transactions { get; set; }

        public BankAccount() 
        {
        Transactions=new List<Transaction>();
        }
    
        public void DepositMoney(Transaction transaction) 
        {
        Balance=transaction.TransactionAmount+Balance;
            Transactions.Add(transaction);
        
        
        }
        
        public void WithdrawMoney(Transaction transaction) 
        {
            
            if (transaction.TransactionAmount <= Balance) 
            {
                Balance -= transaction.TransactionAmount;
                Transactions.Add(transaction);
            }
            else
            {
                throw new InvalidOperationException("Insufficient Funds");
            }
        }
    
    }
}
