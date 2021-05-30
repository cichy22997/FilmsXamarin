using FilmsXamarin.Models;
using FilmsXamarin.Services;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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

        private string titleEntry;
        public string TitleEntry
        {
            get
            { return titleEntry; }
            set
            {
                titleEntry = value;
                OnPropertyChanged();
            }
        }


        // String, not int; Value is binded to placeholder
        private string yearEntry;
        public string YearEntry
        {
            get
            { return yearEntry; }
            set
            {
                yearEntry = value;
                OnPropertyChanged();
            }
        }

        public AsyncCommand OnCheckClick { get; }

        public NewFilmViewModel()
        {
            OnCheckClick = new AsyncCommand(AddNewFilm);
        }

        private async Task AddNewFilm()
        {
            int year = default(int);
            var canBeParsed = Int32.TryParse(YearEntry, out year);
            if (!String.IsNullOrEmpty(TitleEntry))
            {
                if(!canBeParsed)
                    await Application.Current.MainPage.DisplayAlert("Invalid year value!", "Year should be number", "Ok");
                if (canBeParsed && year >= 1900 && year <= 2100)
                {
                    await FilmService.AddFilm(TitleEntry, year);
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Invalid year value!", "Year should be between 1900 and 2100", "Ok");
            }
            else
                await Application.Current.MainPage.DisplayAlert("Invalid title value!", "Film must have a title", "Ok");
        }
    }
}
