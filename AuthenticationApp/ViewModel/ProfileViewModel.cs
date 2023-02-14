using AuthenticationApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AuthenticationApp.ViewModel
{
    public class ProfileViewModel : INotifyPropertyChanged
    {
        private ImageSource _profileImage;
        public ImageSource ProfileImage
        {
            get { return _profileImage; }
            set
            {
                _profileImage = value;
                OnPropertyChanged("ProfileImage");
            }
        }

        public ICommand PickCommand { get; set; }

        public ProfileViewModel()
        {
            PickCommand = new Command(PickPhoto);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void PickPhoto()
        {
            try
            {
                var file = await FilePicker.PickAsync();
                if (file == null)
                    return;
                ProfileImage = ImageSource.FromFile(file.FullPath);
                await Application.Current.MainPage.Navigation.PushAsync(new ChoosePhotoControl(ProfileImage));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }

}
