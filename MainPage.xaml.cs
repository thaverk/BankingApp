using BankingApp.Services;

namespace BankingApp
{
    public partial class MainPage : ContentPage
    {
        
         
        //creates member class to connect database to main page
        private BankingLocalDatabase _database;

        public MainPage()
        {
            InitializeComponent();
           
            //connects database to main page
            _database=new BankingLocalDatabase();
        }

        private void CounterBtn_Clicked(object sender, EventArgs e)
        {
           List<> clients= _database.GetAllClients();
        }
    }

}
