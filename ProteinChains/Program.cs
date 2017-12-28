using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProteinChains
{
    class Program
    {
        static void Main(string[] args)
        {
            var proteinChainList = new List<string>();

            try
            {
                var lines = File.ReadAllLines("lancuchy_bialkowe.txt");

                foreach (var line in lines)
                    proteinChainList.Add(line);
            }
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine("Nie znaleziono pliku");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            for (int i = 0; i < proteinChainList.Count; i += 2)
                Console.WriteLine(check(proteinChainList[i], proteinChainList[i + 1]));

            Console.ReadKey();
        }

        public static bool check(String s1, String s2)
        {

            char[] tmpX = s1.ToCharArray();
            char[] tmpY = s2.ToCharArray();
            BubleSort(tmpX);
            BubleSort(tmpY);

            int count = 0;

            if (tmpX.Length == tmpY.Length)
            {
                for (int i = 0; i < tmpX.Length; i++)
                {
                    if (tmpX[i] == tmpY[i]) count++;
                    else return false;
                }
                return true;
            }
            return false;
        }


        public static void BubleSort(char[] array)
        {
            int n = array.Length;
            do
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        char tmp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = tmp;
                    }
                }
                n--;
            }
            while (n > 1);
        }
    }
}
