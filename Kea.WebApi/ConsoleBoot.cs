using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kea.WebApi
{
    /// <summary>
    /// Expose a console interface
    /// </summary>
    public class ConsoleBoot
    {
        public Server Server { get; set; }
        public string Address { get; set; } = "http://localhost:8080";

        public ConsoleBoot()
        {
        }

        public object Solve(Type Type)
        {
            var C = Server.GetContainer();
            return C.GetService(Type);
        }

        public async Task Restart()
        {
            if (Server != null)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Stopping server...");
                await Server.server.CloseAsync();
                Server.Dispose();
                Server = null;
            }
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("Starting server...");

            Console.WriteLine("Address: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Address);

            Server = new Server(Address);
            await Server.server.OpenAsync();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("ready.");
        }
    }
}
