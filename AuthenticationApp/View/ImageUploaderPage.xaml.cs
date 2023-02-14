using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AuthenticationApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageUploaderPage : ContentPage
    {
        public ImageUploaderPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Not Supported", "Your device does currently support this funcitionality","ok");
                return;
    }
            var mediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Small

            };
            var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);
            if(selectedImage == null)
            {
                await DisplayAlert("Error", "", "ok");
                return;
            }
            selectedImage.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());
        }

    }
}