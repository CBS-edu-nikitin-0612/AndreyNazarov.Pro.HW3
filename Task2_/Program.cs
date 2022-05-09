using System;
using System.IO;
using System.Reflection;

namespace Task2_
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\test.txt";
            FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            StreamWriter stream = new(file, System.Text.Encoding.UTF8);
            stream.WriteLine("Hello World!!!");
            stream.Close();

            FileStream fileStream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader streamReader = new(fileStream);

            Console.WriteLine(streamReader.ReadToEnd());
            streamReader.Close();
        }
    }
}
