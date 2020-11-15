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

        public void PopulateMovieDB() 
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie("Star Wars: Episode V - The Empire Strikes Back", "Action", 1980, "Mark Hamill, Harrison Ford, Carrie Fisher", "Irvin Kershner"),
                new Movie("The Matrix", "Action", 1999, "Keanu Reeves, Laurence Fishburne", "Lana Wachowski, Lilly Wachowski"),
                new Movie("Alien", "Horror", 1979, "Sigourney Weaver, John Hunt, Harry Dean Stanton", "Ridley Scott, James Cameron"),
                new Movie("Independence Day", "Action", 1996, "Will Smith, Jeff Goldblum, Bill Pullman", "Roland Emmerich"),
                new Movie("The Evil Dead", "Horror", 1981, "Bruce Campbell, Ted Raimi, Ellen Sandweiss", "Sam Raimi"),
                new Movie("Halloween", "Horror", 1978, "Jamie Lee Curtis, Donald Pleasence, Nick Castle", "John Carpenter"),
            };

            foreach (Movie movie in movies)
            {
                AddToDB(movie);
            }
        }
    }
}
