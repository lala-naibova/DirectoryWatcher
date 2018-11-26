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

        public event Action<List<string>> NewFilesNames;

        public event Action<List<string>> RemovedFilesNames;

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

            List<string> newFiles;
            List<string> removedFiles;

            while (true)
            {
                Thread.Sleep(this.Interval);
                string[] currentFiles = Directory.GetFiles(this._path);
                
                bool hasDiff=PickTheChangesOverTheDirectory(oldFiles, currentFiles, out removedFiles, out newFiles);
                if (hasDiff)
                {
                    if (NewFilesNames !=null && newFiles.Count != 0)
                    {
                        NewFilesNames(newFiles);
                    }
                    if (RemovedFilesNames!=null && removedFiles.Count!=0)
                    {
                        RemovedFilesNames(removedFiles);
                    }
                                
                }

                oldFiles = currentFiles;
            }
            
        }
        public static bool PickTheChangesOverTheDirectory(string[] oldFiles, string[] currentFiles, out List<string> removed,out List<string> newest)
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

            return newest.Count != 0 || removed.Count != 0;

        }

    }

}
