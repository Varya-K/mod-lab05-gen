using Microsoft.VisualStudio.TestTools.UnitTesting;
using Laba_5;
using System.Collections.Generic;
using System.Linq;


namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        

        public void TestCorrectReadingBigram()
        {
            CharPairGenerator g = new CharPairGenerator();
            string syms = "абвгдежзийклмнопрстуфхцчшщыьэюя";
            int[,] bigram = g.getWeightMatrix;
            Assert.AreEqual(bigram[syms.IndexOf('ч'), syms.IndexOf('т')], 7);
            Assert.AreEqual(bigram[syms.IndexOf('у'), syms.IndexOf('й')], 0);
            Assert.AreEqual(bigram[syms.IndexOf('о'), syms.IndexOf('в')], 84);
            Assert.AreEqual(bigram[syms.IndexOf('и'), syms.IndexOf('я')], 17);
            Assert.AreEqual(bigram[syms.IndexOf('ы'), syms.IndexOf('х')], 16);
        }

        [TestMethod]
        public void TestExsitCharPair()
        {
            CharPairGenerator g = new CharPairGenerator();
            string syms = "абвгдежзийклмнопрстуфхцчшщыьэюя";
            int[,] bigram = g.getWeightMatrix;
            for (int i = 0; i < 10000; i++)
            {
                string pair = g.getPair();
                Assert.IsTrue(bigram[syms.IndexOf(pair[0]), syms.IndexOf(pair[1])] != 0);
                //if (bigram[syms.IndexOf(g.getPair()[0]), syms.IndexOf(g.getPair()[1])] == 0)
                    //Correct = false;
            }
            //Assert.IsTrue(Correct);
        }

        [TestMethod]

        public void TestStatisticCharPair()
        {
            CharPairGenerator g = new CharPairGenerator();
            double eps = 0.005;
            int count = 10000;
            string syms = "абвгдежзийклмнопрстуфхцчшщыьэюя";
            int[,] bigram = g.getWeightMatrix;
            int sum = g.getSum;
            string text = g.getText(count);
            SortedDictionary<string, int> stat = g.getStatistics(text);
            foreach (KeyValuePair<string, int> pair in stat)
            {
                Assert.IsTrue(System.Math.Abs((double)pair.Value / count - (double)bigram[syms.IndexOf(pair.Key[0]), syms.IndexOf(pair.Key[1])] / sum) < eps);
            }
        }

        [TestMethod]

        public void TestCorrectReadingWordList()
        {
            WordGenerator g = new WordGenerator();
            string[] data = g.getData;
            int[] weights = g.getWeights;
            Assert.AreEqual(weights[System.Array.IndexOf(data, "время")], 768250);
            Assert.AreEqual(weights[System.Array.IndexOf(data, "он")], 4947719);
            Assert.AreEqual(weights[System.Array.IndexOf(data, "там")], 389633);
            Assert.AreEqual(System.Array.IndexOf(data, "туда"), -1);
        }

        [TestMethod]
        public void TestExsitWord()
        {
            WordGenerator g = new WordGenerator();
            string[] data = g.getData;
            for (int i = 0; i < 10000; i++)
            {
                Assert.IsTrue(data.Contains(g.getWord()));
            }
        }

        [TestMethod]
        public void TestStatisticWord()
        {
            WordGenerator g = new WordGenerator();
            double eps = 0.01;
            int count = 10000;
            string[] data = g.getData;
            int[] weights = g.getWeights;
            int sum = g.getSum;
            string text = g.getText(count);
            SortedDictionary<string, int> stat = g.getStatistics(text);
            foreach (KeyValuePair<string, int> pair in stat)
            {
                Assert.IsTrue(System.Math.Abs((double)pair.Value / count - (double)weights[System.Array.IndexOf(data,pair.Key)] / sum) < eps);
            }
        }

        [TestMethod]
        public void TestCorrectReadingWordPairList()
        {
            WordPairGenerator g = new WordPairGenerator();
            string[] data = g.getData;
            int[] weights = g.getWeights;
            Assert.AreEqual(weights[System.Array.IndexOf(data, "об этом")], 45100);
            Assert.AreEqual(weights[System.Array.IndexOf(data, "что у")], 35149);
            Assert.AreEqual(weights[System.Array.IndexOf(data, "таким образом")], 30278);
            Assert.AreEqual(System.Array.IndexOf(data, "тем не"), -1);
        }

        [TestMethod]
        public void TestExsitWordPair()
        {
            WordPairGenerator g = new WordPairGenerator();
            string[] data = g.getData;
            for (int i = 0; i < 10000; i++)
            {
                Assert.IsTrue(data.Contains(g.getWordPair()));
            }
        }

        [TestMethod]
        public void TestStatisticWordPair()
        {
            WordPairGenerator g = new WordPairGenerator();
            double eps = 0.01;
            int count = 10000;
            string[] data = g.getData;
            int[] weights = g.getWeights;
            int sum = g.getSum;
            string text = g.getText(count);
            SortedDictionary<string, int> stat = g.getStatistics(text);
            foreach (KeyValuePair<string, int> pair in stat)
            {
                Assert.IsTrue(System.Math.Abs((double)pair.Value / count - (double)weights[System.Array.IndexOf(data, pair.Key)] / sum) < eps);
            }
        }
    }
}

