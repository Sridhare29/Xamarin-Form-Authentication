using AuthenticationApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AuthenticationApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usr.Text) || string.IsNullOrWhiteSpace(passtxt.Text))
            {
                await DisplayAlert("Invalid", "Blank Value is Invalid", "OK");
            }

            else
                AddUser();
        }

        async void AddUser()
        {
            await App.MyDatabase.CreateUser(new Model.User
            {
                UserName = usr.Text,
                Password = passtxt.Text
            });
            if (!Regex.IsMatch(passtxt.Text, @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$"))
            {
                DisplayAlert("Invalid Passsword", "", "ok");

            }
            else
            { 
                await Navigation.PushAsync(new MainPage());
            DisplayAlert("Successfully! login", "", "OK");
        }

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignupPage());

        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await DisplayAlert("Success", "A password reset link has been sent to your email and Please updated your password ", "OK");

            Device.OpenUri(new Uri("https://mail.google.com/"));

        }

        private void GenerateRandomPassword()
        {

            // return "@newpassword2";

        }
    }
    }


    
