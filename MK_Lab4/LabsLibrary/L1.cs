using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsLibrary
{
    public static class L1
    {
        public static string Run(string pathInpFile = "INPUT.TXT")
        {
            List<string> inputData = File.ReadLines(pathInpFile).ToList();
            int numberOfDays = Convert.ToInt32(inputData?[0].Trim() ?? "0");
            List<int> prices = inputData?[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(pr => Convert.ToInt32(pr)).ToList() ?? new List<int>();
            return GetMaxEarnings(prices).ToString();
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
