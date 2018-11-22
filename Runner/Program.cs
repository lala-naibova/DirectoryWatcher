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
            List<string> newFiles;
            List<string> deleted;

            DirectoryWatcher.PickTheChangesOverTheDirectory(old, newLetters, out deleted, out newFiles);
            foreach (string item in deleted)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}