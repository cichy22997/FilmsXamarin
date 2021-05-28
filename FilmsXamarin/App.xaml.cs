using FilmsXamarin.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("ScriptMTBold.ttf", Alias = "MainFont")]

namespace FilmsXamarin
{
    public partial class App : Application
    {
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
