using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace FileUtils
{
    

    public class DirectoryWatcher : IDirectoryWatcher
    {

        private string _path;
        public TimeSpan Interval { get; set; }
        public bool IsFileNameSensitive { get; set; }
        public List<string> listOfMyNewFiles=new List<string>();

        public DirectoryWatcher(string path, TimeSpan interval)
        {
            this.Interval = interval;
            this._path = path;
        }

        public void Start()
        {
            string[] oldFiles = Directory.GetFiles(this._path);

            while (true)
            {
                Thread.Sleep(this.Interval);
                string[] currentFiles = Directory.GetFiles(this._path);

                
                foreach (string currentFile in currentFiles)
                {
                    if (!oldFiles.Contains(currentFile))
                    {
                        listOfMyNewFiles.Add(currentFile);
                    }
                }
                oldFiles = currentFiles;
            }
            
        }
        public static void PickTheChangesOverTheDirectory(string[] oldFiles, string[] currentFiles, out List<string> removed,out List<string> newest)
        {   
            newest = new List<string>();
            removed = new List<string>();
            foreach (string item in currentFiles)
            {
                if (!oldFiles.Contains(item))
                {
                    newest.Add(item);
                }
            }
            foreach (string file in oldFiles)
            {
                if (!currentFiles.Contains(file))
                {
                    removed.Add(file);
                }
            }
        }

    }

}
