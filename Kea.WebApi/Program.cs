using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tonic.Console;

namespace Kea.WebApi
{
    class Program
    {
        static string address = "http://localhost:82";
        static void Main(string[] args)
        {
            Clear();

            Console.ForegroundColor = ConsoleColor.Magenta;
      
            //Make a first time database connection here


            Tonic.Console.ConsoleHelper H = new Tonic.Console.ConsoleHelper();
            H.Instance = new ConsoleBoot();
            H.LoadMethod(typeof(ConsoleBoot).GetMethod(nameof(ConsoleBoot.Restart)));
            H.LoadMethod(typeof(ConsoleBoot).GetMethod(nameof(ConsoleBoot.Solve)));
            H.LoadAssemblyTypes(typeof(Program));

            Execute(H, "restart, await").Wait();
            Loop(H).Wait();
        }

        static async Task Loop(Tonic.Console.ConsoleHelper H)
        {
            while (!H.Exit)
            {
                await Execute(H);
            }
        }

        static void Clear()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Siam.WebApi");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(Assembly.GetExecutingAssembly().GetName().Version.ToString());

            Console.WriteLine("kea software");
            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static async Task Execute(ConsoleHelper H)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Tonic.Console> ");
            Console.ForegroundColor = ConsoleColor.White;
            var Line = Console.ReadLine();
            if (Line == "clear")
            {
                Clear();
            }
            else
            {
                var Ret = await H.Execute(Line);

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(Ret);
            }
        }

        private static async Task Execute(ConsoleHelper H, string Command)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Tonic.Console> ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Command);
            var Ret = await H.Execute(Command);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(Ret);
        }

    }
}
