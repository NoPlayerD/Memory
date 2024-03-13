using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class ERROR
    {
        public void exit(string message)
        {
            Console.WriteLine($"Error: {message}");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
