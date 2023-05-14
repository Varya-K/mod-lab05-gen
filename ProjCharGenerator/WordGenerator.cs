using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Laba_5
{
    public class WordGenerator
    {
        private string[] data;
        private int size;
        private int[] weights;
        private int[] np;
        private int sum=0;
        private Random random = new Random();
        public WordGenerator()
        {

            //Заполнение массива весов из файла и формирование массива верхних границ для каждого символа
            StreamReader file = new StreamReader("Words_and_Weights.txt");
            List<string> words = new List<string>();
            List<int> w = new List<int>();
            string s;
            while ((s = file.ReadLine()) != null)
            {
                string[] s1 = s.Split(" / ");
                words.Add(s1[0]);
                w.Add(Int32.Parse(s1[1]));
            }
            file.Close();

            data = words.ToArray();
            weights = w.ToArray();
            size = data.Length;
            np = new int[size];
            int sum1 = 0;
            
            for(int i = 0; i < size; i++)
            {
                sum1 += weights[i];
                np[i] += sum1;
            }
            sum = np[size - 1];
        }

        public string[] getData { get { return data; } }
        public int[] getWeights { get { return weights; } }
        public int getSum { get { return sum; } }
        public string getWord()
        {
            int m = random.Next(0, sum);
            int i=0;
            for (i = 0; i < size; i++)
            {
                if (m < np[i]) break;
            }
            return data[i];
        }
        public string getText(int count)
        {
            string text="";
            for (int i = 0; i < count; i++)
            {
                text += getWord()+" ";
            }
            text = text.Trim();
            return text;

        }

        public SortedDictionary<string, int> getStatistics(string text)
        {
            SortedDictionary<string, int> stat = new SortedDictionary<string, int>();
            string[] words = text.Split(" ");
            foreach (string word in words) 
            {
                if (stat.ContainsKey(word))
                    stat[word]++;
                else
                    stat.Add(word, 1);
            }
            return stat;
        }
    }
}
