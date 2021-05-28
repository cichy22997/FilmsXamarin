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
    public partial class NewFilmView : ContentPage
    {
        NewFilmViewModel NewFilmVM = new NewFilmViewModel();
        public NewFilmView()
        {
            InitializeComponent();
            BindingContext = NewFilmVM;
        }
    }
}
