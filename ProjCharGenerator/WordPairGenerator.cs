using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Laba_5
{
    public class WordPairGenerator
    {
        private string[] data;
        private int size;
        private int[] weights;
        private int[] np;
        private int sum = 0;
        private Random random = new Random();
        public WordPairGenerator()
        {

            //Заполнение массива весов из файла и формирование массива верхних границ для каждого символа
            StreamReader file = new StreamReader("Pairs_of_words_and_weights.txt");
            List<string> pairs = new List<string>();
            List<int> w = new List<int>();
            string s;
            while ((s = file.ReadLine()) != null)
            {
                string[] s1 = s.Split(" / ");
                pairs.Add(s1[0]);
                w.Add(Int32.Parse(s1[1]));
            }
            file.Close();

            data = pairs.ToArray();
            weights = w.ToArray();
            size = data.Length;
            np = new int[size];
            int sum1 = 0;

            for (int i = 0; i < size; i++)
            {
                sum1 += weights[i];
                np[i] += sum1;
            }

            sum = np[size - 1];
        }

        public string[] getData { get { return data; } }
        public int[] getWeights { get { return weights; } }
        public int getSum { get { return sum; } }
        public string getWordPair()
        {
            int m = random.Next(0, sum);
            int i = 0;
            for (i = 0; i < size; i++)
            {
                if (m < np[i]) break;
            }
            return data[i];
        }
        public string getText(int count)
        {
            string text = "";
            for (int i = 0; i < count; i++)
            {
                text += getWordPair() + " ";
            }
            text = text.Trim();
            return text;

        }

        public SortedDictionary<string, int> getStatistics(string text)
        {
            SortedDictionary<string, int> stat = new SortedDictionary<string, int>();
            string[] words = text.Split(" ");
            for (int i = 0; i < words.Length / 2; i++)
            {
                string pair = words[i*2]+" "+words[i*2+1];
                if (stat.ContainsKey(pair))
                    stat[pair]++;
                else
                    stat.Add(pair, 1);
            }
            return stat;
        }
    }
}
