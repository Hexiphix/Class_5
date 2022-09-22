using System;

namespace Class_5.Services;

/// <summary>
///     You would need to inject your interfaces here to execute the methods in Invoke()
///     See the commented out code as an example
/// </summary>
public class MainService : IMainService
{
    private readonly IFileService _fileService;
    public MainService(IFileService fileService)
    {
        _fileService = fileService;
    }

    public void Invoke()
    {
        string choice;
        do
        {
            Console.WriteLine("1) Add Movie");
            Console.WriteLine("2) Display All Movies");
            Console.WriteLine("X) Quit");
            choice = Console.ReadLine();

            // Logic would need to exist to validate inputs and data prior to writing to the file
            // You would need to decide where this logic would reside.
            // Is it part of the FileService or some other service?
            if (choice == "1")
            {
                // Gets the movie title
                Console.WriteLine("\nAn ID will be assigned to the movie automatically");
                Console.WriteLine("What is the title of the movie being added? ");
                string addedTitle = Console.ReadLine();

                try 
                {
                    // Ensures that the movie title isn't already in the database
                    _fileService.Read();
                    if (_fileService.CheckTitles(addedTitle))
                    { Console.WriteLine($"A movie titled {addedTitle} already exists!"); }
                    else
                    {
                        // Confirms the movie and allows input of genres
                        Console.WriteLine($"No movie named {addedTitle} found, preparing to add to database.");
                        Console.WriteLine("Add a genre, or list of genres split by pipes (Ex: Action|Horror)\n");
                        string addGenres = Console.ReadLine().Replace(" ", "").Replace(",", "|");

                        // Ensures the Genres weren't left blank
                        if (addGenres == "")
                        { Console.WriteLine("Movies must have at least one genre, try again."); }
                        else
                        { _fileService.Write((int)_fileService.GetNextInt(), addedTitle, addGenres); } 
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("\n\nWriting to database seems to have failed for some reason!");
                    Console.WriteLine("Be careful what you input!\n\n");
                    choice = "1";
                }
            }
            else if (choice == "2")
            {
                _fileService.Read();
                _fileService.Display();
            }
        }
        while (choice != "X");
    }
}
