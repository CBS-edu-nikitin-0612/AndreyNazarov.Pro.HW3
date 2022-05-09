using System;
using System.IO;
using System.Collections.Generic;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            string path  = @"C:\";
            string baseName = "folder_";
            List<DirectoryInfo> directories = new List<DirectoryInfo>();
            for (int i = 0; i < 100; i++)
            {
                directories.Add(new DirectoryInfo(path + baseName + i));
                directories[i].Create();
            }

            foreach (var item in directories)
            {
                item.Delete();
            }
        }
    }
}
