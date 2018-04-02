using System;
using System.Linq;

namespace Puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("************ Random Array ************");
            int[] myArray = RandomArray();
            int sum = 0;
            for(int i = 0; i < myArray.Length; i++){
                sum += myArray[i];
                Console.WriteLine("#" + (i + 1) + " - " + myArray[i]);
            }
            Console.WriteLine("Min: "+myArray.Min());
            Console.WriteLine("Max: "+myArray.Max());
            Console.WriteLine("Sum: "+myArray.Sum());
            Console.WriteLine("**************************************" + Environment.NewLine);

            Console.WriteLine("************ Coin Flip ************");
            Console.WriteLine("You tossed: " + TossCoin());
            Console.WriteLine("**************************************" + Environment.NewLine);

            Console.WriteLine("************ Coin Flip Multiple ************");
            Console.WriteLine("Ratio for {0} tosses: {1}", 5, TossCoinMulti(5));
            Console.WriteLine("Ratio for {0} tosses: {1}", 10, TossCoinMulti(10));
            Console.WriteLine("Ratio for {0} tosses: {1}", 20, TossCoinMulti(20));
            Console.WriteLine("Ratio for {0} tosses: {1}", 1000, TossCoinMulti(1000));
            Console.WriteLine("**************************************" + Environment.NewLine);


            Console.WriteLine("************ Names ************");
            string[] myNames = Names();
            Console.WriteLine("Names: [{0}]", string.Join(", ", myNames));
            Console.WriteLine("**************************************" + Environment.NewLine);

        }

        private static string[] Names()
        {
            string[] tempNames = {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};

            Random rand=new Random();
            tempNames = tempNames.OrderBy(x => rand.Next()).ToArray();

            int len = tempNames.Length - 1;
            for(int i = len; i > 0; i--){
                if(tempNames[i].Length < 5) tempNames = tempNames.Where((source, index) => index != i).ToArray();
            }

            return tempNames;
        }

        private static double TossCoinMulti(int num)
        {
            double ratio = 0;
            double numHeads = 0;
            double numTails = 0;

            for(int i = 0; i < num; i++){
                if(TossCoin() == "Heads") numHeads++;
                else numTails++;
            }

            ratio = numHeads / num;

            return ratio;
        }

        private static string TossCoin()
        {
            string tempString;
            Random rand = new Random();

            tempString=(rand.Next(0, 2) == 1)?"Heads":"Tails";

            return tempString;
        }

        private static int[] RandomArray()
        {
            int[] tempArray = new int[10];
            Random rand = new Random();

            for(int i = 0; i < tempArray.Length; i++){
                tempArray[i] = rand.Next(5, 25);
            }

            return tempArray;
        }
    }
}
