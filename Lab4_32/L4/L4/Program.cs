using LabsLibrary;

namespace L4
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Write a command.");
                return;
            }
            string command = args[0].ToLower();
            switch (command)
            {
                case "version":
                    Console.WriteLine($"Author: Mykyta Kutsenko\nVersion: 0.1");
                    break;
                case "run":
                    LabsLibrary.LabWorks.Execute(args[1]);
                    break;
                case "set-path":
                    Environment.SetEnvironmentVariable("LAB_PATH", args[2]);
                    break;
                default:
                    break;
            }
        }
    }
}