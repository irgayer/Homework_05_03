using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_05_03
{
    public class FiboContunier
    {
        public const string PATH_TO_FILE = ""; //НА ВСЯКИЙ СЛУЧАЙ
        public const string INPUT_FILE_NAME = "fibanazzi.txt";
        public const string OUTPUT_FILE_NAME = "fibanazzi2.txt";
        public void Run()
        {
            if (File.Exists(PATH_TO_FILE + INPUT_FILE_NAME))
            {
                string[] words;
                List<int> numbers = new List<int>();

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
                if (IsFib(numbers))
                {
                    numbers = ContinueFib(numbers);

                    foreach (int item in numbers)
                    {
                        Console.WriteLine($"{item} ");
                    }
                    using (FileStream stream = new FileStream(PATH_TO_FILE + OUTPUT_FILE_NAME, FileMode.Create))
                    {
                        string data = string.Join<int>(" ", numbers);

                        byte[] bytes = System.Text.Encoding.Unicode.GetBytes(data);

                        stream.Write(bytes, 0, bytes.Length);
                    }
                }
                else
                {
                    Console.WriteLine("В файле не последовательность Фибоначчи!");
                }
            }
            else
            {
                Console.WriteLine("Файла не существует!");
            }
        }
        public static bool IsFib(List<int> numbers)
        {
            bool result = false;
            for (int i = 0; i < numbers.Count - 2; i++)
            {
                if (numbers[i] + numbers[i + 1] == numbers[i + 2])
                    result = true;
                else
                    return false;
            }
            return result;
        }
        public List<int> ContinueFib(List<int> numbers)
        {
            int size = numbers.Count;
            for (int i = size - 1; i < (size * 2) - 1; i++)
            {
                numbers.Add(numbers[i - 1] + numbers[i]);
            }
            return numbers;
        }
    }
}
