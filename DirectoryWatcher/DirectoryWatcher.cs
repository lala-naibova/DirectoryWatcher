using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace DirectoryWatcher
{

    public class DirectoryWatcher : IDirectoryWatcher
    {

        private string _path;
        public TimeSpan Interval { get; set; }
        public bool IsFileNameSensitive { get; set; }

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
                        Console.WriteLine($"new file {currentFile}");
                    }
                }
                oldFiles = currentFiles;
            }
            
        }
    }

}
