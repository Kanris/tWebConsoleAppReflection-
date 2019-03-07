using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace tWebConsoleAppReflection
{
    class Program
    {
        private const string url = "http://localhost:9000";

        private static void Main(string[] args)
        {
            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Server started at:" + url);
                Console.ReadLine();
            }
        }
    }
}
