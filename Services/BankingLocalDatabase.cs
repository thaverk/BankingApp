using BankingApp.Models;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Services
{
    public class BankingLocalDatabase
    {
        //class for database connection
        private SQLiteConnection _dbConnection;


        public string GetDatabasePath()
        {
            //Creates DataBase
            string filename = "bankingdata.db";

            //Gets File Path for database to be stored
            string pathToDb = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            return pathToDb + filename; //Path.Combine(pathToDb, filename); //Both code does the exact same thing
        }

        public BankingLocalDatabase()
        {
            //Initiates connection to database path
            _dbConnection = new SQLiteConnection(GetDatabasePath());

            //Creates Table ClientType Table
            _dbConnection.CreateTable<ClientType>();
            _dbConnection.CreateTable<BankAccountType>();
            _dbConnection.CreateTable<TransactionType>();
            _dbConnection.CreateTable<Bank>();
            _dbConnection.CreateTable<Client>();
            _dbConnection.CreateTable<BankAccount>();  
            _dbConnection.CreateTable<Transaction>();
            SeedDataBase();

        }

        public void SeedDataBase()//the inital state of our database is being set up here 
        {
            if (_dbConnection.Table<ClientType>().Count() == 0)//So that the table doesn't continue adding rows, will only populate on initalization 
            {
                ClientType clientType = new ClientType() //Creating a instance of a class
                { ClientTypeDescription = "Private" };
                _dbConnection.Insert(clientType); //Saving the clientType to the database

                clientType = new ClientType()
                { ClientTypeDescription = "MVP" };
                _dbConnection.Insert(clientType);

                clientType = new ClientType()
                { ClientTypeDescription = "Standard" };
                _dbConnection.Insert(clientType);



            }
            if (_dbConnection.Table<BankAccountType>().Count() == 0)
            {
                BankAccountType bankAccountType = new BankAccountType()
                {
                    BankDescription = "Savings"

                };
                _dbConnection.Insert(bankAccountType);

                bankAccountType = new BankAccountType()
                {
                    BankDescription = "Cheque"

                };

                _dbConnection.Insert(bankAccountType);
                bankAccountType = new BankAccountType()
                { BankDescription = "Debit"

                };
            }
            if (_dbConnection.Table<TransactionType>().Count() == 0)
            {

                TransactionType transactionType = new TransactionType()
                {
                    TransactionTypeDescription = "Drawings"


                };
                _dbConnection.Insert(transactionType);
                transactionType = new TransactionType()
                {
                    TransactionTypeDescription = "Payment"
                };

                _dbConnection.Insert(transactionType);
                transactionType = new TransactionType()
                {
                    TransactionTypeDescription = "Withdrawal"

                };
                _dbConnection.Insert(transactionType);




            }



            Client client = new Client()
            {
                ClientName = "Keanan",
                ClientSurname = "Thaver",
                ClientID_number = 0,

            };


            Bank bank = new Bank()
            {
                BankName = "Capitec Bank",
                BankBranchCode = 1524,

            };
            _dbConnection.Insert(client);
            _dbConnection.Insert(bank);
            bank.clients.Add(client);
            _dbConnection.UpdateWithChildren(bank);

            BankAccount bankAccount = new BankAccount()
            {
                BankAccountNumber = "0001",
                BankAccountTypeID =1,
                
            };
            _dbConnection.Insert(bankAccount);
           client.BankAccounts.Add(bankAccount);
            _dbConnection.UpdateWithChildren(client);

            Transaction transaction = new Transaction() 
            { 
            TransactionAmount=1000,
            TransactionDate = DateTime.Now,
            TransactionDescription="Deposited Money: Lunch"
            };

            try
            {
                transaction = new Transaction()
                {
                    TransactionAmount = 10,
                    TransactionDate = DateTime.Now,
                    TransactionDescription = "Withdraw Money: Lunch"
                };
            } catch (InvalidOperationException ex) 
            { 
            
            
            }

        }

        public List<ClientType> GetAllClientTypes()
        {
            var clientTypes = _dbConnection.Table<ClientType>().ToList();
            return clientTypes;


        }
        public List<BankAccountType> GetAllBankAccountTypes()
        {
            var bankaccounttypes = _dbConnection.Table<BankAccountType>().ToList();
            return bankaccounttypes;


        }
        public List<TransactionType> GetAllTransactionTypes()
        {
            var transactionType = _dbConnection.Table<TransactionType>().ToList();
            return transactionType;


        }
        
        public List<Client> GetAllClients() 
        
        { 
        return _dbConnection.Table<Client>().ToList();
        
        
        }

        public Client GetClient(string saID)
        {
            return _dbConnection.Table<Client>().Where(x=> x.ClientID_number==saID).FirstOrDefault();
        }




    }

   

}  
