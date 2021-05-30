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
            await FilmsVM.RefreshFilmsList();
        }

    }
}
