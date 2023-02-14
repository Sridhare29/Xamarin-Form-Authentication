using AuthenticationApp.View;
using AuthenticationApp.ViewModel;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AuthenticationApp
{
    public partial class App : Application
    {
        private static AuthViewModel db;
        public static AuthViewModel MyDatabase
        {
            get
            {
                if(db == null)
                {
                    db = new AuthViewModel(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "gfhgfhgh.db3"));
                }
                return db;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
