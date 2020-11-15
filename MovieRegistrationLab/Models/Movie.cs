using System;
using System.Collections.Generic;
using System.Linq;
using LiteDB;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MovieRegistrationLab.Models
{
    public class Movie
    {
        [StringLength(50, ErrorMessage = "Maximum of 50 characters allowed!")]
        public string Title { get; set; }

        public string Genre { get; set; }

        public int Year { get; set; }

        public string Actors { get; set; }

        public string Directors { get; set; }

        public Movie() { }
        public Movie(string title, string genre, int year, string actors, string directors)
        {
            Title = title;
            Genre = genre;
            Year = year;
            Actors = actors;
            Directors = directors;
        }

        public void AddToDB(Movie newMovie)
        {

            using (var db = new LiteDatabase(@"./MoviesDB.db"))
            {
                // Get a collection (or create, if doesn't exist)
                var col = db.GetCollection<Movie>("movies");

                // Create movie instance
                var movie = new Movie
                {
                    Title = newMovie.Title,
                    Genre = newMovie.Genre,
                    Year = newMovie.Year,
                    Actors = newMovie.Actors,
                    Directors = newMovie.Directors
                };

                // Insert new customer document (Id will be auto-incremented)
                col.Insert(movie);
            }
        }

        public List<Movie> GetMovieList()
        {
            using (var db = new LiteDatabase(@"./MoviesDB.db"))
            {
                List<Movie> movieList = new List<Movie>();
                // Get a collection (or create, if doesn't exist)
                var col = db.GetCollection<Movie>("movies");

                // Get every row in MovieDB and add it to a list to be returned
                foreach (var movie in col.FindAll())
                {
                    movieList.Add(movie);
                }

                return movieList;
            }
        }
    }
}
