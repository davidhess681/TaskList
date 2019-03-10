﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TaskList
{
    class IO
    {
        static string path = @"c:/temp/TaskList.txt";
        public static void ReadFile()
        {
            Directory.CreateDirectory(@"c:\temp");

            if (File.Exists(path))
            {
                StreamReader sr = new StreamReader(path);
                string line = sr.ReadLine();
                while (line != null)
                {
                    try
                    {
                        string[] split = line.Split(';');
                        string name = split[0];
                        string desc = split[1];
                        DateTime duedate = DateTime.Parse(split[2]);
                        bool comp = bool.Parse(split[3]);

                        Task task = new Task(name, desc, duedate, comp);
                    }
                    catch
                    {

                    }
                }
            }
        }
        public static void UpdateFile()
        {
            try
            {
                StreamWriter sw = new StreamWriter(path, false);

                foreach (Task t in Menu.TaskList)
                {
                    sw.WriteLine(t.PrintToFile());
                }
                sw.Close();
            }
            catch
            {
                Console.WriteLine("Something went wrong writing to file!");
                Console.ReadKey();
            }
        }
    }
}
