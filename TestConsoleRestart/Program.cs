using System;

namespace TestRestart
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press R to restart the program...");
            string restar = Console.ReadLine();
            if (restar.ToUpper() == "R")
            {
                Restart();
            }
        }

        static void Restart()
        {
            //netcoreapp3.1
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            path = path.Replace(".dll", ".exe");
            System.Diagnostics.Process.Start(path);
            Environment.Exit(0);  // insure current process exit normally
        }
    }
}
