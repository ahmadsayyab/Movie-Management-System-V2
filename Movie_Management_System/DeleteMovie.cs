using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Management_System
{
    internal class DeleteMovie
    {
        public static void DeleteSpecificMovie()
        {

            bool confirm = true;

            while (confirm)
            {

                if (MovieList.moviesData.Count != 0)
                {
                    //Code for getting title is been written in SearchTitle class
                    string title = SearchTitle.SearchATitle();

                    
                    Console.WriteLine("#######################################################");
                    Console.WriteLine($"Movie_Name: {title} has been deleted Successfully!!!");
                    Console.WriteLine("#####################################################\n");

                    int indexToRemove = -1;

                    // Find the index of the movie title in the List
                    for (int i = 0; i < MovieList.moviesData.Count; i += 3)
                    {
                        string movieTitle = (string)MovieList.moviesData[i];

                        if (movieTitle.Equals(title))
                        {
                            indexToRemove = i;
                            break;
                        }
                    }

                    if (indexToRemove != -1)
                    {

                        MovieList.moviesData.RemoveRange(indexToRemove, 3);

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
                //Console.WriteLine("====After deletion=====");
                //MovieList.ShowAllMoviesData();



            }

        }
    }
}
