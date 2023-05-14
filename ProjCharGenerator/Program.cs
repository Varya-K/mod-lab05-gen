using System;
using System.Collections.Generic;
using System.IO;

namespace Laba_5
{
    class Program
    {
        static void Main(string[] args)
        {
            CharPairGenerator g1 = new CharPairGenerator();
            string text1 = g1.getText(1000);
            StreamWriter sr1 = new StreamWriter("Text_from_pairs_of_chars.txt");
            sr1.Write(text1);
            sr1.Close();

            WordGenerator g2 = new WordGenerator();
            string text2 = g2.getText(1000);
            StreamWriter sr2 = new StreamWriter("Text_from_words.txt");
            sr2.Write(text2);
            sr2.Close();

            WordPairGenerator g3 = new WordPairGenerator();
            string text3 = g3.getText(1000);
            StreamWriter sr3 = new StreamWriter("Text_from_pairs_of_words.txt");
            sr3.Write(text3);
            sr3.Close();


        }
    }
}
