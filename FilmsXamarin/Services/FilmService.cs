using FilmsXamarin.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FilmsXamarin.Services
{
    public static class FilmService
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            if (db != null)
                return;
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "FilmsData.db");
            db = new SQLiteAsyncConnection(dbPath);
            await db.CreateTableAsync<Film>();
        }

        public static async Task AddFilm(string title, int year)
        {
            await Init();
            var id = await db.InsertAsync(new Film { Title = title, Year = year });

        }

        public static async Task<IEnumerable<Film>> GetFilmsCollection()
        {
            await Init();
            var filmsCollection = await db.Table<Film>().ToListAsync();
            return filmsCollection;
        }

        public static async Task RemoveFilm(int id)
        {
            await Init();
            await db.DeleteAsync<Film>(id);
        }

        public static async Task EditFilm(Film film, string newTitle, int newYear)
        {
            await Init();
            film.Title = newTitle;
            film.Year = newYear;
            var result = await db.UpdateAsync(film);
        }

        public static async Task UpdateFilm(int id, string title, int year)
        {
            await Init();
        }
    }
}
