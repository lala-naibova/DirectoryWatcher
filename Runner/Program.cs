using System;
using System.Collections.Generic;
using FileUtils;
namespace Runner
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] old = {"a","b","c","d","e" };
            string[] newLetters = {"z","d","j","m" };

            List<string> list = DirectoryWatcher.FindTheNewestFiles(old, newLetters);
            foreach (string item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}