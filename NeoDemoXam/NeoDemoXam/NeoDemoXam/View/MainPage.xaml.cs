using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NeoDemoXam.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked_One(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FillDetailsTypeMusic());
        }

        private void Button_Clicked_Two(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FillDetailsTypeDance());
        }

        private void Button_Clicked_Three(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FillDetailsTypeDrama());
        }
    }
}