using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabsLibrary
{
    public static class L2
    {
        public static string Run(string pathInpFile = "INPUT.TXT")
        {
            var number = Convert.ToInt32(File.ReadLines(pathInpFile).First().Trim());
            return GetCountOfWaysToShowNumber(number).ToString();
        }

        /// <summary>
        /// Отримати кількість способів представлення числа, яке передали у функцію
        /// </summary>
        private static int GetCountOfWaysToShowNumber(int number)
        {
            int result = 0;
            int currPower = 0;
            while (Math.Pow(2, currPower) <= number)
            {
                result += getCountOfWaysToShowNumberWithPower(number, currPower);
                currPower++;
            }
            return result;
        }

        /// <summary>
        /// Кількість способів представлення числа number, у кожному представленні як мінімум одне значення 2**mainPower
        /// </summary>
        private static int getCountOfWaysToShowNumberWithPower(int number, int mainPower)
        {
            if (number == 0)
            {
                return 0;
            }
            if (mainPower == 0)
            {
                return 1;
            }
            int count = 0;
            int numOfMainPowerNums = 1;
            while (true)
            {
                int nextNumber = number - (numOfMainPowerNums * Convert.ToInt32(Math.Pow(2, mainPower)));
                if (nextNumber < 0)
                {
                    break;
                }
                if (nextNumber == 0)
                {
                    count++;
                    break;
                }
                else
                {
                    for (int i = mainPower - 1; i >= 0; i--)
                    {
                        count += getCountOfWaysToShowNumberWithPower(nextNumber, i);
                    }
                    numOfMainPowerNums++;
                }
            }
            return count;
        }
    }
}
