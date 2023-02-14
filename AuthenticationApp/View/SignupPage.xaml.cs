using AuthenticationApp.Valid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media.Abstractions;
using Plugin.Media;

namespace AuthenticationApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {




            if (string.IsNullOrWhiteSpace(uname.Text) || string.IsNullOrWhiteSpace(password.Text))
            {
                await DisplayAlert("Invalid", "Blank Value is Invalid", "OK");
            }
            else if (!Regex.IsMatch(email.Text, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
           @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$"))
            {
                DisplayAlert("Invalid Email", "", "Ok");
            }

            else
            {
                AddUser();

            }
        }

        private async void AddUser()
        {
            await App.MyDatabase.CreateUser(new Model.User
            {

                UserName = uname.Text,
                FirstName = fname.Text,
                LastName = lname.Text,
                Email = email.Text,
                PhoneNumber = pno.Text,
                Password = password.Text,
                ConfirmPassword = cpassword.Text
            });

            if (!string.Equals(password.Text, cpassword.Text))
            {
                /// warningLabel.Text = "Enter Same Password";
                password.Text = string.Empty;
                cpassword.Text = string.Empty;
                //   warningLabel.TextColor = Color.IndianRed;
                //   warningLabel.IsVisible = true;
                await DisplayAlert("Invalid", "password are not same", "OK");

            }
            else if(!Regex.IsMatch(password.Text, @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$"))
                {
                DisplayAlert("Invalid Passsword", "", "ok");

            }
            else
            {
                DisplayAlert("Successfully! Sigup", "", "OK");

                await Navigation.PushAsync(new LoginPage());

            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

  
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Not Supported", "Your device does currently support this funcitionality", "ok");
                return;
            }
            var mediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Small

            };
            var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);
            if (selectedImage == null)
            {
                await DisplayAlert("Error", "", "ok");
                return;
            }
            selectedImage.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());
        }

       
    }
}