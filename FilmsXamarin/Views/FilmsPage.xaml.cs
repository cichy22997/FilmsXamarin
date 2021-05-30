using FilmsXamarin.Models;
using FilmsXamarin.Services;
using FilmsXamarin.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FilmsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilmsPage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }
        FilmsViewModel FilmsVM = new FilmsViewModel();

        public FilmsPage()
        {
            InitializeComponent();
            BindingContext = FilmsVM;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await LaunchFirstTime();
            await FilmsVM.RefreshFilmsList();
        }

        private async Task LaunchFirstTime()
        {
            if (App.FirstLaunch)
            {
                await Application.Current.MainPage.DisplayAlert("Basic tutorial", "Create your film list", "Ok");
                await Application.Current.MainPage.DisplayAlert("Add", "Add film by pressing \"+\" icon", "Ok");
                await Application.Current.MainPage.DisplayAlert("Details", "Click on the loupe to show details", "Ok");
                await Application.Current.MainPage.DisplayAlert("Remove", "Swipe film RIGHT to delete", "Ok");
                await Application.Current.MainPage.DisplayAlert("Edit", "Swipe film LEFT to edit", "Ok");
                App.FirstLaunch = false;
            }
        }
    }
}
