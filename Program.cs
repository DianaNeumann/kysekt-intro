using System;
using System.Text.Json;

namespace sekta
{

    
    class Program
    {
        static void Main(string[] args)
        {

            
            /*Console.WriteLine("Press ESC to stop");
            while (!(Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                string? commandTemp = Console.ReadLine();
                Core.Execute(commandTemp);
            }*/

            Console.WriteLine("Type \"exit\" to stop");
            while (true)
            {
                string? commandTemp = Console.ReadLine();   
                Core.Execute(commandTemp);
            }
        }
    }
}
