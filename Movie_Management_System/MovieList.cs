using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Management_System
{
    internal class MovieList
    {
        
         public static List<string> moviesData = new List<string>();

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


    }
}
