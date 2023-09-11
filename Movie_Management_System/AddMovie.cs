using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Management_System
{
    internal class AddMovie
    {
        public static void AddMovieData()
        {

            
            

            bool confirm = true;

            while (confirm)
            {

                Console.WriteLine("Enter the movie title:");
                string title = Console.ReadLine();

                while (string.IsNullOrEmpty(title))
                {
                    Console.WriteLine("You missed out entering Movie Title, Please enter it!: ");
                    title = Console.ReadLine();
                }
                Console.WriteLine("Enter Author Name of the movie: ");
                string author = Console.ReadLine();
                
                while (string.IsNullOrEmpty(author) || int.TryParse(author, out int movie_author))
                {
                    if (string.IsNullOrEmpty(author))
                    {
                        Console.WriteLine("You missed out entering Author Name, Please enter it!: ");
                        author = Console.ReadLine();
                    }
                    else if (int.TryParse(author, out movie_author))
                    {
                        Console.WriteLine("Name cannot be an integer");
                        author = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }
                }
                int count = 0;
                double sum = 0;
                bool choose = true;
                while (choose)
                {
                    Console.WriteLine("Enter the movie rating (out of 10):");
                    string rating = Console.ReadLine();

                    while (string.IsNullOrEmpty(rating) || !int.TryParse(rating, out int movie_rating) || movie_rating > 10)
                    {
                        if (string.IsNullOrEmpty(rating))
                        {
                            Console.WriteLine("You missed out entering Movie Rating, Please enter it!: ");
                            rating = Console.ReadLine();
                        }
                        else if (!int.TryParse(rating, out movie_rating))
                        {
                            Console.WriteLine("Your input should be a digit in range: 1 - 10");
                            rating = Console.ReadLine();
                        }
                        else if (movie_rating > 10)
                        {
                            Console.WriteLine("Keep your rating under 10:");
                            rating = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Invalid input");
                        }
                    }

                    count++;
                    sum += double.Parse(rating);
                    Console.WriteLine("Do you want to add another rating?, type yes");
                    string decide = Console.ReadLine().ToLower();

                    if (decide == "yes")
                    {
                        choose = true;

                    }
                    else
                    {
                        choose = false;
                    }

                }

                
                double avg_rating = sum / count;
                Console.WriteLine($"The average rating of the movie {title} after {count} times of rating is: {avg_rating}");





                
               MovieList.moviesData.Add(title);
               MovieList.moviesData.Add(avg_rating.ToString());
               MovieList.moviesData.Add(author);
                
                



                Console.WriteLine("####################################################");
                Console.WriteLine($"Movie Title: {title}, Movie Author: {author} & Rating: {avg_rating} has been added Successfully!!!");
                Console.WriteLine("#####################################################");
                Console.WriteLine("\nDo you want to add another Movie Data? type yes, OR any other Char to stop entering");
                string choice = Console.ReadLine().ToLower();


                if (choice == "yes")
                {
                    confirm = true;
                }
                else
                {
                    confirm = false;
                }


            }

            //call a mthod declared in a MovieList class to show all movies, 
            //MovieList.ShowAllMoviesData();
            


        }

    }
}
