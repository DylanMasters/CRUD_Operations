using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using MySql.Data.MySqlClient;

namespace CRUD_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            string jsonText = File.ReadAllText("appsettings.development.json");
#else
            string jsonText = File.ReadAllText("appsettings.release.json");
#endif
            var connString = JObject.Parse(jsonText)["ConnectionStrings"]["DefaultConnection"].ToString();
          
        }
    }
}
