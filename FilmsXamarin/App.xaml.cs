using FilmsXamarin.Views;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("Acme-Regular.ttf", Alias = "MainFont")]

namespace FilmsXamarin
{
    public partial class App : Application
    {
        private static ISettings AppSettings => CrossSettings.Current;
        public static bool FirstLaunch
        {
            get => AppSettings.GetValueOrDefault(nameof(FirstLaunch), true);
            set => AppSettings.AddOrUpdateValue(nameof(FirstLaunch), value);
        }
        public App()
        {
            InitializeComponent();
            Sharpnado.Shades.Initializer.Initialize(loggerEnable: false);

            MainPage = new NavigationPage(new FilmsPage());
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
