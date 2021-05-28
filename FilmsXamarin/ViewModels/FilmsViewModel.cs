using FilmsXamarin.Models;
using FilmsXamarin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace FilmsXamarin.ViewModels
{
    class FilmsViewModel: INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private ObservableCollection<Film> filmsCollection;
        public ObservableCollection<Film> FilmsCollection
        {
            get { return filmsCollection; }
            set
            {
                filmsCollection = value;
                OnPropertyChanged();
            }
        }

        public Command OnAddClick { get; }

        public FilmsViewModel()
        {
            OnAddClick = new Command(ToAddFilmPage);
        }

        private async void ToAddFilmPage()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new NewFilmView());
        }

        public void RefreshFilmsList()
        {
            FilmsCollection.Clear();

        }
    }
}
