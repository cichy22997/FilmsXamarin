using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace FilmsXamarin.ViewModels
{
    class NewFilmViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Command OnCheckClick { get; }

        public NewFilmViewModel()
        {
            OnCheckClick = new Command(AddNewFilm);
        }

        private async void AddNewFilm()
        {

            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
