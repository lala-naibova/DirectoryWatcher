﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUtils
{
    interface IDirectoryWatcher
    {
        void Start(Action<int, int> countHandler);
    } 
}
