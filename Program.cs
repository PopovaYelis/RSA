using System;
using static System.Console;

namespace RSA
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string alph = "абвгдежзийклмнопрстуфхцчшщьыэюя "; //объявление строковой переменной, хранящей русский алфавит
                Write("Введите p: ");
                int p = Convert.ToInt32(ReadLine()); //конвертация вводимого в консоль в целочисленный тип
                Write("Введите g: ");
                int g = Convert.ToInt32(ReadLine());

                int r = p * g; //вычисление значения переменной r
                int q_r = (p - 1) * (g - 1); //вычисление значения переменной q_r

                int c = 1;
                while (q_r % c == 0)
                {
                    c++;
                }
                int d = 1;
                while ((c * d) % q_r != 1)
                {
                    d++;
                }
                int[] openKey = { c, r }; //массив, хранящий открытый ключ
                int[] closeKey = { d, r }; //массив, хранящий закрытый ключ
                WriteLine($"Открытый: ({openKey[0]}; {openKey[1]})\nЗакрытый: ({closeKey[0]}; {closeKey[1]})"); //вывод значений ключа в консоль

                Write("Выберите действие. 1 - расшифровать. 2 - зашифровать. Введите: ");
                int n = Convert.ToInt32(ReadLine()); //переменная хранит выбор пользователя

                if (n == 2)
                {
                    Write("Введите фразу: ");
                    string word = ReadLine();
                    word = word.Replace(" ", "");
                    string res = "";
                    for (int i = 0; i < word.Length; i++)
                    {
                        int code = alph.IndexOf(word[i]) + 1;
                        int w = Convert.ToInt32(Math.Pow(code, openKey[0]) % openKey[1]);
                        res += w;
                        res += " ";
                    }
                    WriteLine("Зашифрованная фраза: " + res); //вывод зашифрованной фразы
                }
                else
                {
                    Write("Введите зашифрованную фразу. Цифры через пробел: ");
                    string word = ReadLine();
                    string[] numbers = word.Split(" ");
                    string res = "";
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        int w = Convert.ToInt32(Math.Pow(Convert.ToInt64(numbers[i]), closeKey[0]) % closeKey[1]);
                        res += alph[w - 1];
                    }
                    WriteLine(res); //вывод расшифрованной фразы

                }
            }
        }
    }
}