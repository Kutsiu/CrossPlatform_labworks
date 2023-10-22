using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace LabsLibrary
{
    internal static class L1
    {
        public static void Exec(string path)
        {
            var inputPath = Path.Combine(path, "input.txt");
            var outputPath = Path.Combine(path, "output.txt");
            FileInfo outputFileInfo = new FileInfo(outputPath);
            List<string> inputData = File.ReadLines(inputPath).ToList();
            int numberOfDays = Convert.ToInt32(inputData?[0].Trim() ?? "0");
            List<int> prices = inputData?[1].Split(' ').Select(pr => Convert.ToInt32(pr)).ToList() ?? new List<int>();
            using (StreamWriter streamWriter = outputFileInfo.CreateText())
            {
                if (numberOfDays <= 0 || numberOfDays > 100)
                {
                    streamWriter.WriteLine("Out of range exception!");
                }
                else
                {
                    streamWriter.WriteLine(GetMaxEarnings(prices));
                }
            }
        }

        private static int GetMaxEarnings(List<int> pricesPerDayList)
        {
            int maxEarnings = 0;
            int hairLength = 1;
            for (int i = 0; i < pricesPerDayList.Count; i++, hairLength++)
            {
                if (!isBiggerOrEqualPriceLater(i, pricesPerDayList))
                {
                    maxEarnings += hairLength * pricesPerDayList[i];
                    hairLength = 0;
                }
            }
            return maxEarnings;
        }

        private static bool isBiggerOrEqualPriceLater(int currentDay, List<int> pricesPerDayList)
        {
            for (int i = currentDay + 1; i < pricesPerDayList.Count; i++)
            {
                if (pricesPerDayList[currentDay] <= pricesPerDayList[i])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
