using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Data.SqlClient;
using System.Text.Json;

namespace ProgettoGetClaudiaBriccolani
{
    public class PostModel
    {
        public int userid { get; set; } 
        public int id { get; set; } 
        public string title { get; set; }   
        public string body { get; set; }    

    }
}
