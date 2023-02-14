using AuthenticationApp.Model;
using AuthenticationApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AuthenticationApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {

            base.OnAppearing();

            myCollectionView.ItemsSource = await App.MyDatabase.ReadUser();





        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new LoginPage());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.ListView());

        }
    }
}
