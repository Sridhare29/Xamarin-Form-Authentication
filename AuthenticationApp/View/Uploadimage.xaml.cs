using AuthenticationApp.ViewModel;
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
    public partial class Uploadimage : ContentPage
    {
        public ProfileViewModel ViewModel { get; set; }

        public Uploadimage()
        {
            InitializeComponent();
            ViewModel = new ProfileViewModel();
            BindingContext = ViewModel;
        }
    }
}