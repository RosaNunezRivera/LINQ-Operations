using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class MovieBusinessLogic
    {
        List<Movies> MovieCollection = new List<Movies>()
        {
            new Movies() { MovieId = 1, MovieName = "Titanic", CountryOfOrigin="US", MovieLength=180, ReleaseYear = 2000},
            new Movies() { MovieId = 2, MovieName = "Jumanji", CountryOfOrigin="US", MovieLength=150, ReleaseYear = 1995},
            new Movies() { MovieId = 3, MovieName = "Life of PI", CountryOfOrigin="India", MovieLength=130, ReleaseYear = 2010},
            new Movies() { MovieId = 4, MovieName = "The pursuit of Happiness", CountryOfOrigin="UK", MovieLength=160, ReleaseYear = 2005},
            new Movies() { MovieId = 5, MovieName = "Lord of the Rings", CountryOfOrigin="New Zealand", MovieLength=145, ReleaseYear = 2008},
            new Movies() { MovieId = 6, MovieName = "Fast and Furious", CountryOfOrigin="UK", MovieLength=90, ReleaseYear = 2004}
        };

        List<MovieAward> MovieAwardCollection = new List<MovieAward>()
        {
            new MovieAward { MovieId = 1, AwardId = 1, AwardName = "Oscar" },
            new MovieAward { MovieId = 1, AwardId = 2, AwardName = "IIFA" },
            new MovieAward { MovieId = 2, AwardId = 3, AwardName = "Oscar" },
            new MovieAward { MovieId = 2, AwardId = 4, AwardName = "IIFA" },
            new MovieAward { MovieId = 3, AwardId = 5, AwardName = "Oscar" },
            new MovieAward { MovieId = 7, AwardId = 5, AwardName = "Oscar" },
        };

        public void LINQMethodsOpeations()
        {
            // requirement 1 - print movies which are length of more than 150 minutes and released after 2000
            var moviesReq1 = MovieCollection.Where(x => x.MovieLength > 150 && x.ReleaseYear > 2000);
            // chain of methods
            //var moviesReq2 = MovieCollection.Where(x => x.MovieLength > 150).Where(x => x.ReleaseYear > 2000);

            Console.WriteLine("print movies which are length of more than 150 minutes and released after 2000 \n");

            foreach(var item in moviesReq1)
            {
                Console.WriteLine(item.MovieName + " " + item.CountryOfOrigin);
            }

            Console.WriteLine("print all the movies in the order of they were released.\n");
            // requirement 2 - print all the movies in the order of they were released. (ascending order)

            var moviesReq2 = MovieCollection.OrderBy(x => x.ReleaseYear);


            foreach (var item in moviesReq2)
            {
                Console.WriteLine(item.MovieName + " " + item.ReleaseYear);
            }

            // requirement 3 - print the movies group by country of origin
            Console.WriteLine("print the movies group by country of origin.\n");

            var moviesReq3 = MovieCollection
                            .GroupBy(x => x.CountryOfOrigin)
                            .Select(s => new { Name = s.Key, movies = s.OrderBy(x => x.MovieName) })
                            .OrderBy(y => y.Name);

            foreach (var item in moviesReq3)
            {
                //Console.WriteLine(item.Key);
                foreach(var value in item.movies)
                {
                    Console.WriteLine("in the group of " + item.Name  + " the movies are : " + value.MovieName);
                }
            }

            Console.WriteLine("print the selection of movies originated in US.\n");

            // requirement 4 - select using anonymous objects
            var moviesReq4 = MovieCollection.Where(x => x.CountryOfOrigin == "US")
                                            .Select(s => new { NameofMovie = s.MovieName, ReleasedIn = s.ReleaseYear });
            foreach (var item in moviesReq4)
            {
                Console.WriteLine("The movies which are released in US are" + item.NameofMovie + " and the release year was " + item.ReleasedIn);
            }

            // All and Any

            // all - check if all the elements satisfies the given condition
            // any - check if any of the element satisfies the given condition

            // requirement 5 - if the length of all the movies is above 100 minutes in time.
            Console.WriteLine("if the length of all the movies is above 100 minutes in time.\n");

            var moviesReq5 = MovieCollection.All(x => x.MovieLength > 100);
            var moviesReq6 = MovieCollection.Any(x => x.MovieLength < 100);

            Console.WriteLine(moviesReq5);
            Console.WriteLine(moviesReq6);


            Console.WriteLine("select first element/movie out of the collection which was released after year 2000.\n");
            // First(), FirstOrDefault()
            // select first element/movie out of the collection which was released after year 2000.
            Console.WriteLine(MovieCollection.FirstOrDefault(x => x.ReleaseYear > 2010));
            var FirstorDefault =  MovieCollection.FirstOrDefault(x => x.ReleaseYear > 2010) == null ? "null" : "success" ;
            Console.Write(FirstorDefault);
            // Console.WriteLine(MovieCollection.First(x => x.ReleaseYear > 2010));


            // Requirement 6 - Join Movie and MovieAwards based on MovieId to get which movie won which award..
            Console.WriteLine();
            Console.WriteLine("Join Movie and MovieAwards based on MovieId to get which movie won which award.\n");
            Console.WriteLine();
            var joinMovieAndAwards = MovieCollection.Join(MovieAwardCollection,
                                                            Movies => Movies.MovieId,
                                                            MovieAward => MovieAward.MovieId,
                                                            (Movies, MovieAward) => new
                                                            {
                                                                movieName = Movies.MovieName,
                                                                country = Movies.CountryOfOrigin,
                                                                releaseYear = Movies.ReleaseYear,
                                                                awardName = MovieAward.AwardName
                                                            });

            foreach(var item in joinMovieAndAwards)
            {
                Console.WriteLine(item.movieName + " " + item.country + " " + item.releaseYear + " " + item.awardName);
            }

        }

    }
}
