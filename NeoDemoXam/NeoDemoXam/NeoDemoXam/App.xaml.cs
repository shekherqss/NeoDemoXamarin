using NeoDemoXam.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NeoDemoXam
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new FillDetailsTypeOne();
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
