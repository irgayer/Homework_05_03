using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_05_03
{
    public class SumToNumbers
    {
        public const string PATH_TO_FILE = ""; //НА ВСЯКИЙ СЛУЧАЙ
        public const string INPUT_FILE_NAME = "AB.txt";
        public const string OUTPUT_FILE_NAME = "C.txt";
        public void Run()
        {

            if (File.Exists(PATH_TO_FILE + INPUT_FILE_NAME))
            {
                List<int> numbers = new List<int>();
                string[] words;
                using (StreamReader stream = new StreamReader(PATH_TO_FILE + INPUT_FILE_NAME))
                {
                    string text = stream.ReadLine();
                    words = text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                }

                bool isInt = false;
                foreach (string item in words)
                {
                    int number;
                    isInt = int.TryParse(item, out number);
                    if (isInt)
                    {
                        numbers.Add(number);
                    }
                }
                int result = numbers[0] + numbers[1];
                Console.WriteLine($"result = {result}");

                using(FileStream stream = new FileStream(PATH_TO_FILE + OUTPUT_FILE_NAME, FileMode.Create))
                {
                    string data = result.ToString();

                    byte[] bytes = System.Text.Encoding.Unicode.GetBytes(data);
                    stream.Write(bytes, 0, bytes.Length);
                }
            }
        }
    }
}
