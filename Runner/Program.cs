using FileUtils;
using System;
using System.Collections.Generic;


namespace Runner
{
    public class Program
    {
        static void Main(string[] args)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            DirectoryWatcher dw = new DirectoryWatcher(@"D:\smart-cart",TimeSpan.FromSeconds(4));
            DirectoryWatcher dw2 = new DirectoryWatcher(desktopPath,TimeSpan.FromSeconds(5));

            dw.WhenNewFilesAppear += WriteToConsole;
            dw2.WhenNewFilesAppear += WriteToConsole;

            dw.Start();
            dw2.Start();

            Console.ReadKey();
        }

        private static void WriteToConsole(object sebebkar, NewFilesInfoEventArgs ea)
        { 
            Console.WriteLine(string.Join("/n", ea.fileNames));  ;
        }
    }
}