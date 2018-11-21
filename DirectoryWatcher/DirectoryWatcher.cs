﻿using System;
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

        public static List<string> FindTheNewestFiles(string[] oldFiles, string[] currentFiles)
        {
            List<string> addedFiles =new List<string>();
           // List<string> removedFiles =new List<string>();
            
            bool found = false;
            
            for (int currIndex = 0; currIndex < currentFiles.Length; currIndex++)
            {
                for (int oldIndex = 0; oldIndex < oldFiles.Length; oldIndex++)
                {
                    
                    if (currentFiles[currIndex]==oldFiles[oldIndex])
                    {
                        found = true;
                        break;
                    }
                }
                
                if (!found)
                {
                    addedFiles.Add(currentFiles[currIndex]);
                }
                //reset
                found = false;
            }
            return addedFiles;
        }
    }

}
