using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AminoSoupLottery
{
    class Program
    {
        static private List<int> quota;

        static void Main(string[] args)
        {
            quota = new List<int>();
            List<string> winResult = new List<string>();
            List<string> closeResult = new List<string>();

            addquota(ref quota, 750, 3);
            addquota(ref quota, 559, 1);
            addquota(ref quota, 390, 2);
            addquota(ref quota, 299, 1);
            addquota(ref quota, 269, 1);
            addquota(ref quota, 260, 1);
            addquota(ref quota, 130, 2);
            addquota(ref quota, 91, 1);
            addquota(ref quota, 26, 3);


            generateResults(ref quota, ref winResult, ref closeResult);

            writeResults(ref winResult, '$', "WIN RESULTS");
            writeResults(ref closeResult, '*', "CLOSE RESULTS");

            Console.ReadKey();
        }

        private static void writeResults(ref List<string> winResult, char symbol, string text)
        {
            Console.WriteLine("\n\n" + ("".PadLeft(5, symbol) + text).PadRight(50, symbol));
            foreach (var r in winResult)
            {
                Console.WriteLine(r);
            }
            Console.WriteLine("".PadLeft(50, symbol) + "\n\n");
        }

        private static void generateResults(ref List<int> quota, ref List<string> winResult, ref List<string> closeResult)
        {
            int n = quota.Count();
            string result;
            int sum;

            //function was used from: http://www.geeksforgeeks.org/finding-all-subsets-of-a-given-set-in-java/
            for (int i = 0; i < (1 << n); i++)
            {
                result = string.Empty;
                sum = 0;
                result += "{ ";

                for (int j = 0; j < n; j++)
                {
                    if ((i & (1 << j)) > 0)
                    {
                        sum += quota[j];
                        if (sum > 1000) { goto BreakThisSubset; }
                        result += ("\"" + quota[j] + "\" ");
                    }
                }
                result += "}";

                if ((sum % 100) == 0)
                {
                    result = result.Insert(0, sum + " :");
                    winResult.Add(result);
                }
                else if ((sum % 100) < 5)
                {
                    result = result.Insert(0, sum + " :");
                    closeResult.Add(result);
                }

                BreakThisSubset:;
            }
        }

        static public void addquota(ref List<int> quota, int x_quota, int x_howManyTimes)
        {
            int i = 0;

            for (i = 0; i < x_howManyTimes; i++)
            {
                quota.Add(x_quota);
            }
        }

    }
}
