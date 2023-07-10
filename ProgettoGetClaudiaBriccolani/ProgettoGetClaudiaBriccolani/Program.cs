using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Data.SqlClient;
using System.Text.Json;

namespace ProgettoGetClaudiaBriccolani
{
    public class Program
    {

        public string apiUrl = "https://jsonplaceholder.typicode.com/posts";
       


        public static void Main(string[] args)
        {
            PostSaverClass postSaverClass = new PostSaverClass();
            Console.WriteLine("Scrivi 'start' per iniziare a salvare i post sul database:");
            string input = Console.ReadLine();

            if (input.Trim().ToLower() == "start")
            {
                
                postSaverClass.PostSaver().GetAwaiter().GetResult();
            }
            else
            {
                Console.WriteLine("Comando non corretto. Il programma si chiuderà.");
            }

            Console.ReadLine();
        }
        
    }

}
