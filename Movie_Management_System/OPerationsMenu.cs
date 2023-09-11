using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Management_System
{
    internal class OPerationsMenu
    {
        public static void Menu()
        {

            Console.WriteLine("===== Movie Management System =====");
            Console.WriteLine("\nWhich operation do you want to perform?\nChoose by id from the following menu. ");
            bool loopBreaker = true;

            while (loopBreaker)
            {

                Console.WriteLine("\n\n1. Add Movie\n2. Delete Movie\n3. Rate Movie\n4. Find Movie\n" +
                    "5. Show All Movies\n6. Exit \n\nEnter your choice (1-6):");

                string option = Console.ReadLine();
                int choose_option;
                while (string.IsNullOrEmpty(option) || !int.TryParse(option, out choose_option))
                {
                    if (string.IsNullOrEmpty(option))
                    {
                        Console.WriteLine("Please select one of the choices to proceed with the program!: ");
                        option = Console.ReadLine();
                    }
                    else if (!int.TryParse(option, out choose_option))
                    {
                        Console.WriteLine("Your input should be a digit between 1 - 6");
                        option = Console.ReadLine();
                    }

                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                }


                switch (choose_option)
                {
                    case 1:
                        AddMovie.AddMovieData();
                        break;
                    case 2:
                       DeleteMovie.DeleteSpecificMovie();
                        break;
                    case 3:
                       RateMovie.UpdateMovieRating();
                        break;
                    case 4:
                       FindMovie.FindAMovie();
                        break;
                    case 5:
                       MovieList.ShowAllMoviesData();
                        break;
                    case 6:
                        loopBreaker = false;
                        break;
                    default:
                        Console.WriteLine("\n===Wrong option===");
                        Console.WriteLine("Choose option only from the menu");
                        break;
                }
            }



        }
    }
}
