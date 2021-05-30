using SQLite;

namespace FilmsXamarin.Models
{
    public class Film
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("year")]
        public int Year { get; set; }
    }
}
