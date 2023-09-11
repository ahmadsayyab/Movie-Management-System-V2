using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Management_System
{
    internal class RateMovie
    {
        public static void UpdateMovieRating()
        {

            bool confirm = true;

            while (confirm)
            {

                if (MovieList.moviesData.Count != 0)
                {

                    //Code for getting title is been written in SearchTitle class
                    string title = SearchTitle.SearchATitle();

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
                    for (int i = 0; i < MovieList.moviesData.Count; i += 3)
                    {
                        string movieTitle = MovieList.moviesData[i];

                        if (movieTitle.Equals(title))
                        {
                            indexToUpdate = i;
                            break;
                        }
                    }

                    

                    if (indexToUpdate != -1)
                    {

                        MovieList.moviesData[indexToUpdate + 1] = new_avg_rating.ToString();

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

            //MovieList.ShowAllMoviesData();

           



        }
    }
}
