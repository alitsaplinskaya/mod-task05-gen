using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace generator
{
    class CharGenerator
    {
        private string syms = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя";
        private char[] data;
        private int size;
        private Random random = new Random();
        public CharGenerator()
        {
            size = syms.Length;
            data = syms.ToCharArray();
        }
        public char getSym()
        {
            return data[random.Next(0, size)];
        }
    }
    class CharGenerators 
    {
        private string syms = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя"; 
        private char[] data;
        private int size;
        private Random random = new Random();
        public int[,] array;
        public int[,] array1;
        public int sum = 0;
        public CharGenerators(int[,] arr) 
        {
            array = arr;
            int sum2 = 0;
           size = syms.Length;
           data = syms.ToCharArray();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    sum += array[i, j];
                }
            }
            array1 = new int[size, size];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    sum2 += arr[i, j];
                    array1[i, j] = sum2;
                }
            }
        }

       

        public string getSym() 
        {
            int i = 0;
            int j = 0;
            int a = random.Next(0, sum);
            for(i = 0; i < size; i++)
            {
                int ch = 0;
                for( j = 0; j < size; j++)
                {
                    if (a < array1[i, j])
                    {
                        ch = 1;
                        break;

                    }
                }
                if (ch == 1)
                {
                    break;
                }
            }
            return data[i].ToString() + data[j].ToString();
        }
        public string Output(int cl)
        {
            string output = "";
            for (int i = 0; i < cl; i++)
            {
                output += getSym();
                if (i != cl - 1)
                    output += ' ';
            }

            return output;
        }
    }
    class StringGenerator
    {
        private string[] data;
        private int size;
        private Random random = new Random();
        int[] array1;
        int sum = 0;
        public StringGenerator(string[] arr)
        {
            data = arr;
            size = 100;
            array1 = new int[size];
            for (int i = 0; i < size; i++)
            {
                sum += 1;
                array1[i] = sum;

            }
        }
        public string getSym1()
        {
            int i = 0;
            return data[random.Next(0, size)];
            int a = random.Next(0, sum);
            for (i = 0; i < size; i++)
            {
                if (a < array1[i]) break;
            }
            return data[i];
        }
        public string Output(int cl)
        {
            string output = "";
            for (int i = 0; i < cl; i++)
            {
                output += getSym1();
                if (i != cl - 1)
                    output += ' ';
            }

            return output;
        }
    }
    class StringGenerator1
    {
        private string[] data;
        private int size;
        private Random random = new Random();
        int[] array1;
        int sum = 0;
        public StringGenerator1(string[] arr)
        {
            data = arr;
            size = 100;
            array1 = new int[size];
            for (int i = 0; i < size; i++)
            {
                sum += i;
                array1[i] = sum;
            }
        }
        public string getSym2()
        {
            int a = random.Next(0, sum);
            int i = 0;
            for (i = 0; i < size; i++)
            {
                if (a < array1[i]) break;
            }
            return data[i];
        }
        public string Output(int cl)
        {
            string output = "";
            for (int i = 0; i < cl; i++)
            {
                output += getSym2();
                if (i != cl - 1)
                    output += ' ';
            }

            return output;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CharGenerator gen = new CharGenerator();
            SortedDictionary<char, int> stat = new SortedDictionary<char, int>();
            for(int i = 0; i < 1000; i++) 
            {
               char ch = gen.getSym(); 
               if (stat.ContainsKey(ch))
                  stat[ch]++;
               else
                  stat.Add(ch, 1); Console.Write(ch);
            }
            Console.Write('\n');
            foreach (KeyValuePair<char, int> entry in stat) 
            {
                 Console.WriteLine("{0} - {1}",entry.Key,entry.Value/1000.0); 
            }

            string[] temp = File.ReadAllLines("test.txt");
            int[,] test = new int[temp.Length, temp[0].Split(' ').Length];
            for (int i = 0; i < temp.Length; i++)
            {
                string[] temp1 = temp[i].Split(' ');
                for (int j = 0; j < temp1.Length; j++)
                    test[i, j] = Convert.ToInt32(temp1[j]);
            }
            CharGenerators CharGenerator = new CharGenerators(test);
            string one = CharGenerator.Output(1000);
            File.WriteAllText("CharGenerator.txt", one);
            string[] word = File.ReadAllLines("Word.txt");
            StringGenerator StringGenerator = new StringGenerator(word);
            string two = StringGenerator.Output(1000);
            File.WriteAllText("StringGenerator.txt", two);
            string[] doubleword = File.ReadAllLines("Doubleword.txt");
            StringGenerator1 StringGenerator1 = new StringGenerator1(doubleword);
            string three = StringGenerator1.Output(1000);
            File.WriteAllText("StringGenerator1.txt", three);
        }
    }
}

