using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Laba_5
{
    public class CharPairGenerator
    {
        private string syms = "абвгдежзийклмнопрстуфхцчшщыьэюя";
        private char[] data;
        private int size;
        private int[,] weights;
        private int[,] np;
        private int sum = 0;
        private Random random = new Random();
        public CharPairGenerator()
        {
            size = syms.Length;
            data = syms.ToCharArray();

            //Заполнение массива весов из файла и формирование массива верхних границ для каждого символа
            StreamReader file = new StreamReader("CharPairWeights.txt");

            weights = new int[size, size];
            np = new int[size, size];
            int sum1 = 0;
            for (int i = 0; i < size; i++)
            {
                string[] s = file.ReadLine().Split(" ");
                for (int j = 0; j < size; j++)
                {
                    weights[i, j] = Int32.Parse(s[j]);
                    sum1 += weights[i, j];
                    np[i, j] = sum1 ;
                }
            }
            file.Close();

            sum = np[size - 1, size - 1];
        }

        public int[,] getWeightMatrix { get { return weights; } }
        public int getSum { get { return sum; } }
        public string getPair()
        {
            int m = random.Next(0, sum);
            int i,j=0;
            bool flag = false;
            for (i = 0; i < size; i++)
            {
                for (j = 0; j < size; j++)
                {
                    if (m < np[i, j]) 
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag) break;
            }
            return  (data[i].ToString()+data[j].ToString());
        }
        public string getText(int count)
        {
            string pairs="";
            for(int i = 0; i < count; i++)
            {
                pairs += getPair();
            }
            return pairs;

        }

        public SortedDictionary<string, int> getStatistics (string text)
        {
            SortedDictionary<string, int> stat = new SortedDictionary<string, int>();
            for (int i = 0; i < text.Length / 2; i++)
            {
                string pair = text.Substring(i*2, 2);
                if (stat.ContainsKey(pair))
                    stat[pair]++;
                else
                    stat.Add(pair, 1);
            }
            return stat;
        }
    }
}
