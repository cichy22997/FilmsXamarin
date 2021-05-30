using FilmsXamarin.Models;
using FilmsXamarin.Services;
using FilmsXamarin.Views;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

namespace FilmsXamarin.ViewModels
{
    class FilmsViewModel : INotifyPropertyChanged
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

        public AsyncCommand OnAddClick { get; }
        public AsyncCommand<Film> OnDetailsClick { get; }
        public AsyncCommand<Film> SwipeToEdit { get; }
        public AsyncCommand<Film> SwipeToDelete { get; }

        public FilmsViewModel()
        {
            OnAddClick = new AsyncCommand(ToAddFilmPage);
            OnDetailsClick = new AsyncCommand<Film>(ShowDetails);
            SwipeToEdit = new AsyncCommand<Film>(EditFilm);
            SwipeToDelete = new AsyncCommand<Film>(RemoveFilm);
        }

        private async Task ToAddFilmPage()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new NewFilmView());
        }

        private async Task ShowDetails(Film film)
        {
            await Application.Current.MainPage.DisplayAlert(film.Title, $"Year of production: {film.Year}", "Ok");
        }

        private async Task EditFilm(Film film)
        {
            int year = default(int);
            string editedTitle = await Application.Current.MainPage.DisplayPromptAsync("Title", "What's the title?", maxLength: 200, accept: "Submit", cancel: "Skip");
            string editedYear = await Application.Current.MainPage.DisplayPromptAsync("Year", "Insert year between 1900 and 2100", maxLength: 4, keyboard: Keyboard.Numeric, accept: "Submit", cancel: "Skip");
            var canBeParsed = Int32.TryParse(editedYear, out year);

            if (String.IsNullOrEmpty(editedTitle))
                editedTitle = film.Title;
            if (String.IsNullOrEmpty(editedYear))
                year = film.Year;
            else if (year < 1900 || year > 2100)
            {
                year = film.Year;
                await Application.Current.MainPage.DisplayAlert("Invalid year value!", "Year should be between 1900 and 2100", "Ok");
            }

            await FilmService.EditFilm(film, editedTitle, year);
            await RefreshFilmsList();
        }

        private async Task RemoveFilm(Film film)
        {
            var answer = await Application.Current.MainPage.DisplayAlert("Delete", $"Do you want to delete \"{film.Title}\"?", "Yes", "No");
            if (answer)
            {
                await FilmService.RemoveFilm(film.Id);
                await RefreshFilmsList();
            }
        }
        public async Task RefreshFilmsList()
        {
            var tempList = await FilmService.GetFilmsCollection();
            ObservableCollection<Film> tempObservable = new ObservableCollection<Film>();
            foreach (var item in tempList)
                tempObservable.Add(item);
            FilmsCollection = tempObservable;
        }
    }
}
