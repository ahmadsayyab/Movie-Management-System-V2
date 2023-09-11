using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Management_System
{
    internal class FindMovie
    {
        public static void FindAMovie()
        {

            bool confirm = true;

            while (confirm)
            {

                if (MovieList.moviesData.Count != 0)
                {
                    //Code for getting title is been written in SearchTitle class
                    string title = SearchTitle.SearchATitle();
                  
                    if (MovieList.moviesData.Contains(title))
                    {
                        Console.WriteLine("##########################");
                        Console.WriteLine("Movie found Successfully!!!");
                        Console.WriteLine("##########################");

                        int indexToShow = -1;
                        for (int i = 0; i < MovieList.moviesData.Count; i += 3)
                        {
                            string movieTitle = (string)MovieList.moviesData[i];

                            if (movieTitle.Equals(title))
                            {
                                indexToShow = i;
                                break;
                            }
                        }

                        if (indexToShow != -1)
                        {


                            Console.Write($"Movie Name: {MovieList.moviesData[indexToShow]}\t");
                            Console.Write($"Movie Rating: {MovieList.moviesData[indexToShow + 1]}\t");
                            Console.Write($"Movie Author: {MovieList.moviesData[indexToShow + 2]}\t\n");

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
    }
}
