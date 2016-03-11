using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kea.WebApi
{
    class Program
    {
        static string address = "http://localhost:82";
        static void Main(string[] args)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Siam.WebApi");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(Assembly.GetExecutingAssembly().GetName().Version.ToString());

            Console.ForegroundColor = ConsoleColor.Gray;
            Init().Wait();

            Console.ReadLine();
        }

        static async Task Init()
        {
            var S = new Server(address);
            Console.WriteLine("Staring server at: " + address);
            await S.OpenAsync();
            Console.WriteLine("ready");
            Console.WriteLine("press a key to exit");

        }
    }
}
