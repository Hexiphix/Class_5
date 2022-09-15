/*
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_5.Services
{
    internal class UserInput : IUserInput
    {
        private readonly ILogger<IUserInput> _logger;
        private readonly IFileService _fileService;
        public UserInput(ILogger<IUserInput> logger)
        {
            _logger = logger;
        }

        public void Menu()
        {
            throw new NotImplementedException();
        }

        public void PopulateChoices()
        {
            // Add Movie
            // ask user to input movie title
            Console.WriteLine("Enter the movie title");
            // input title
            string movieTitle = Console.ReadLine();
            // check for duplicate title
            List<string> LowerCaseMovieTitles = MovieTitles.ConvertAll(t => t.ToLower());
            if (LowerCaseMovieTitles.Contains(movieTitle.ToLower()))
            {
                Console.WriteLine("That movie has already been entered");
                _logger.LogInformation("Duplicate movie title {Title}", movieTitle);
            }
            else
            {
                // generate movie id - use max value in MovieIds + 1
                UInt64 movieId = MovieIds.Max() + 1;
                // input genres
                List<string> genres = new List<string>();
                string genre;
                do
                {
                    // ask user to enter genre
                    Console.WriteLine("Enter genre (or done to quit)");
                    // input genre
                    genre = Console.ReadLine();
                    // if user enters "done"
                    // or does not enter a genre do not add it to list
                    if (genre != "done" && genre.Length > 0)
                    {
                        genres.Add(genre);
                    }
                } while (genre != "done");
                // specify if no genres are entered
                if (genres.Count == 0)
                {
                    genres.Add("(no genres listed)");
                }
                // use "|" as delimeter for genres
                string genresString = string.Join("|", genres);
                // if there is a comma(,) in the title, wrap it in quotes
                movieTitle = movieTitle.IndexOf(',') != -1 ? $"\"{movieTitle}\"" : movieTitle;
                // display movie id, title, genres
                Console.WriteLine($"{movieId},{movieTitle},{genresString}");
            }
        }
    }
}
*/