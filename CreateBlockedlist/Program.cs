using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateBlockedlist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Standard keys dict path:");
            string path = Console.ReadLine();
            string fileString = File.ReadAllText(path);
            string[] keys = fileString.Split('\n');
            List<string> blockedlist = new List<string>();
            foreach (string k in keys)
            {
                Console.WriteLine(k);
                if (Console.ReadKey().Key == ConsoleKey.N)
                {
                    Console.WriteLine("Removed from blockedlist");
                }
                else
                {
                    blockedlist.Add(k);
                    Console.WriteLine("Added to blockedlist");
                }
            }
            Console.WriteLine("Enter destination path");
        }
    }
}
