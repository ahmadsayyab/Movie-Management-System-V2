using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Management_System
{
    internal class SearchTitle
    {

        //Follwoing is the code which is been used in FindMovie, RateMovie and DeleteMovie classes.
        public static string SearchATitle()
        {
            Console.WriteLine("Enter the movie title to find if it exist:");
            string title = Console.ReadLine();

            while (string.IsNullOrEmpty(title) || !MovieList.moviesData.Contains(title))
            {
                if (string.IsNullOrEmpty(title))
                {
                    Console.WriteLine("You missed out entering Movie Title, Please enter it!: ");
                    title = Console.ReadLine();
                }

                else if (!MovieList.moviesData.Contains(title))
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
