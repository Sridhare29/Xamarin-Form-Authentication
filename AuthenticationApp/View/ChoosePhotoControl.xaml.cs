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
    public partial class ChoosePhotoControl : ContentPage
    {
        private ImageSource _profileImage;

        public ImageSource ProfileImage { get; set; }

        public ChoosePhotoControl(ImageSource profileImage)
        {
            InitializeComponent();
            ProfileImage = _profileImage;
            BindingContext = this;
        }
    }
}