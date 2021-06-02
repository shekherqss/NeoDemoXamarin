﻿using NeoDemoXam.Bootstrap;
using NeoDemoXam.UI.Utils;
using NeoDemoXam.View;
using NeoDemoXam.ViewModel;
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
            AppContainer.RegisterDependencies();
            MainPage = new NavigationPage(new MainPage());
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
