using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace LabsLibrary
{
    public static class LabWorks
    {
        public static void Execute(string labName)
        {
            var path = Environment.GetEnvironmentVariable("LAB_PATH");
            if (path == null)
            {
                Console.WriteLine("Path is incorrect!");
                return;
            }
            switch (labName.ToLower())
            {
                case "lab1":
                    L1.Exec(path);
                    break;
                case "lab2":
                    L2.Exec(path);
                    break;
                case "lab3":
                    L3.Exec(path);
                    break;
                default:
                    Console.WriteLine("Unknown lab!");
                    break;
            }
        }
    }
}
