using System.Collections.Generic;

namespace LabsLibrary
{
    public class L1Manager
    {
        private readonly List<int> _pricesPerDayList;

        public L1Manager(List<int> pricesPerDayList)
        {
            _pricesPerDayList = new List<int>(pricesPerDayList);
        }

        public string Run()
        {
            return GetMaxEarnings(_pricesPerDayList).ToString();
        }

        private int GetMaxEarnings(List<int> pricesPerDayList)
        {
            int maxEarnings = 0;
            int hairLength = 1;
            for (int i = 0; i < pricesPerDayList.Count; i++, hairLength++)
            {
                if (!IsBiggerOrEqualPriceLater(i, pricesPerDayList))
                {
                    maxEarnings += hairLength * pricesPerDayList[i];
                    hairLength = 0;
                }
            }
            return maxEarnings;
        }

        private bool IsBiggerOrEqualPriceLater(int currentDay, List<int> pricesPerDayList)
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
