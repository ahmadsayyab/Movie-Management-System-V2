using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Management_System
{
    internal class MovieService
    {

        //List to store the movies data 
        public static List<string> moviesData = new List<string>();
        public static void AddMovie()
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
                            Console.WriteLine("Rate movie out of 10 ,cannot exceed!!:");
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






                 moviesData.Add(title);
                 moviesData.Add(avg_rating.ToString());
                 moviesData.Add(author);





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
             ShowAllMoviesData();



        }


        public static void DeleteMovie()
        {

            bool confirm = true;

            while (confirm)
            {

                if (moviesData.Count != 0)
                {
                    //Code for getting title is written in SearchTitle class
                    string title = SearchATitle();


                    Console.WriteLine("#######################################################");
                    Console.WriteLine($"Movie_Name: {title} has been deleted Successfully!!!");
                    Console.WriteLine("#####################################################\n");

                    int indexToRemove = -1;

                    // Find the index of the movie title in the List
                    for (int i = 0; i < moviesData.Count; i += 3)
                    {
                        string movieTitle = (string)moviesData[i];

                        if (movieTitle.Equals(title))
                        {
                            indexToRemove = i;
                            break;
                        }
                    }

                    if (indexToRemove != -1)
                    {

                        moviesData.RemoveRange(indexToRemove, 3);

                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }


                    Console.WriteLine("Do you want to delete another Movie? " +
                        "type yes, OR any other Char to stop entering");
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
                else
                {
                    Console.WriteLine("#########################");
                    Console.WriteLine("The collection is empty!!!");
                    Console.WriteLine("#########################");
                    break;
                }


                //Console.WriteLine("\n===Movies List===");
                Console.WriteLine("====After deletion=====");
                ShowAllMoviesData();



            }

        }


        public static void UpdateMovieRating()
        {

            bool confirm = true;

            while (confirm)
            {

                if (moviesData.Count != 0)
                {

                    //Code for getting title is written in SearchTitle class
                    string title = SearchATitle();

                    int count = 0;
                    double sum = 0;
                    bool choose = true;
                    while (choose)
                    {
                        Console.WriteLine("Enter the new movie rating (out of 10):");
                        string rating = Console.ReadLine();
                        int movie_rating;
                        while (string.IsNullOrEmpty(rating) || !int.TryParse(rating, out movie_rating) || movie_rating > 10)
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


                    double new_avg_rating = sum / count;

                    int indexToUpdate = -1;
                    for (int i = 0; i < moviesData.Count; i += 3)
                    {
                        string movieTitle = moviesData[i];

                        if (movieTitle.Equals(title))
                        {
                            indexToUpdate = i;
                            break;
                        }
                    }



                    if (indexToUpdate != -1)
                    {

                        moviesData[indexToUpdate + 1] = new_avg_rating.ToString();

                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }




                    Console.WriteLine("###############################################");
                    Console.WriteLine("Movie Rating has been updated Successfully!!!");
                    Console.WriteLine("###############################################");

                    Console.WriteLine($"\nNew Average Rating for the Movie {title} after {count} times rating is: {new_avg_rating}\n");

                    Console.WriteLine("Do you want to update rating for another Movie? type yes, " +
                        "OR any other Char to stop entering");
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

                else
                {
                    Console.WriteLine("#########################");
                    Console.WriteLine("The collection is empty");
                    Console.WriteLine("#########################");
                    break;
                }

            }

             





            }


        public static void FindMovie()
        {

            bool confirm = true;

            while (confirm)
            {

                if (moviesData.Count != 0)
                {
                    //Code for getting title is written in SearchTitle class
                    string title = SearchATitle();

                    if (moviesData.Contains(title))
                    {
                        Console.WriteLine("##########################");
                        Console.WriteLine("Movie found Successfully!!!");
                        Console.WriteLine("##########################");

                        int indexToShow = -1;
                        for (int i = 0; i < moviesData.Count; i += 3)
                        {
                            string movieTitle = (string)moviesData[i];

                            if (movieTitle.Equals(title))
                            {
                                indexToShow = i;
                                break;
                            }
                        }

                        if (indexToShow != -1)
                        {


                            Console.Write($"Movie Name:   {moviesData[indexToShow]}\t");
                            Console.Write($"Movie Rating: {moviesData[indexToShow + 1]}\t");
                            Console.Write($"Movie Author: {moviesData[indexToShow + 2]}\t\n");

                        }
                        else
                        {
                            Console.WriteLine("Something went wrong");
                        }

                    }

                    else
                    {
                        Console.WriteLine("Something went wrog");
                    }


                    Console.WriteLine("Do you want to search for another Movie? " +
                        "type yes, OR any other Char to stop entering");
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

                else
                {
                    Console.WriteLine("#########################");
                    Console.WriteLine("The collection is empty!!!");
                    Console.WriteLine("#########################");
                    break;
                }

                //MovieList.ShowAllMoviesData();

            }
        }




        public static void ShowAllMoviesData()
        {


            if (moviesData.Count != 0)
            {
                Console.WriteLine("\n===Movies List===");

                int itemsPerGroup = 3;
                int itemCount = 0;
                Console.Write("Movie Name: \tRating: \tAuthor:\n");
                foreach (var item in moviesData)
                {

                    Console.Write(item + "  \t\t");
                    itemCount++;

                    if (itemCount % itemsPerGroup == 0)
                    {

                        Console.WriteLine();
                    }

                }


            }
            else
            {
                Console.WriteLine("#########################");
                Console.WriteLine("The Collection is empty!!!");
                Console.WriteLine("#########################");

            }

        }


        //Following code is used multiple times
        public static string SearchATitle()
        {
            Console.WriteLine("Enter the movie title to find if it exist:");
            string title = Console.ReadLine();

            while (string.IsNullOrEmpty(title) || !moviesData.Contains(title))
            {
                if (string.IsNullOrEmpty(title))
                {
                    Console.WriteLine("You missed out entering Movie Title, Please enter it!: ");
                    title = Console.ReadLine();
                }

                else if (!moviesData.Contains(title))
                {
                    Console.WriteLine("The title you provided does not exist in the collection" +
                        "enter the correct title!!!");
                    title = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Something went wrong!!!");
                }
            }
            return title;
        }
    }
}
