using System;
using System.Runtime.Serialization.Formatters;

namespace FinalProgect_Mod5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var anketa = Anketa();
            OutputAnketa(anketa);

            Console.ReadKey();
        }

        static (string name, string surname, int age, bool HavePet, int amountPet, string[] namePets, int amountColor, string[] Colors) Anketa()
        {
            (string name, string surname, int age, bool HavePet, int amountPet, string[] namePets, int amountColor, string[] Colors) anketa;

            Console.WriteLine("Введите ваше имя:");
            anketa.name = Console.ReadLine();

            Console.WriteLine("Введите вашу фамилию:");
            anketa.surname = Console.ReadLine();

            string age;
            int int_age;
            do
            {
                Console.WriteLine("Введите ваш возраст:");
                age = Console.ReadLine();

            } while (CheckNum(age, out int_age));
            anketa.age = int_age;

            Console.WriteLine("У вас есть питомец? (Да/Нет)");
            anketa.HavePet = Console.ReadLine() == "Да" ? true : false;

            anketa.amountPet = 0;
            anketa.namePets = null;

            if (anketa.HavePet)
            {
                string str_amountPet;
                int amountPet;
                do
                {
                    Console.WriteLine("Сколько у вас питомцев?");
                    str_amountPet = Console.ReadLine();

                } while (CheckNum(str_amountPet, out amountPet));

                anketa.amountPet = amountPet;

                Console.WriteLine("Введите клички ваших питомцев:");
                anketa.namePets = ReturnArray(anketa.amountPet);
            }

            string str_amountColors;
            int amountColors;
            do
            {
                Console.WriteLine("Введите количество любимых цветов:");
                str_amountColors = Console.ReadLine();
            } while(CheckNum(str_amountColors,out amountColors));
            anketa.amountColor = amountColors;
            anketa.Colors = null;

            if (anketa.amountColor > 0)
            {
                Console.WriteLine("Введите ваши любимые цвета:");
                anketa.Colors = ReturnArray(anketa.amountColor);
            }

            return anketa;
        }
        
        static string[] ReturnArray(int amount)
        {
            string[] arr = new string[amount];
            for (int i = 0; i < amount; i++)
            {
                Console.Write((i + 1).ToString() + ". ");
                arr[i] = Console.ReadLine();
            }

            return arr;
        }

        static bool CheckNum(string str_number, out int number)
        {
            if (int.TryParse(str_number, out int int_number))
            {
                if (int_number > 0)
                {
                    number = int_number;
                    return false;
                }
            }
            {
                number = 0;
                return true;
            }
        }

        static void OutputAnketa((string name, string surname, int age, bool HavePet, int amountPet, string[] namePets, int amountColor, string[] Colors) anketa)
        {
            Console.WriteLine("Ваше имя и фамилия: {0} {1}", anketa.name, anketa.surname);
            Console.WriteLine("Вам {0} лет", anketa.age);
            if (anketa.HavePet)
            {
                Console.WriteLine("У вас есть {0} питомца:", anketa.amountPet);
                for (int i = 0; i < anketa.namePets.Length; i++)
                {
                    Console.WriteLine((i + 1).ToString() + ". " + anketa.namePets[i]);
                }
            }
            else
            {
                Console.WriteLine("У вас нет домашних животных");
            }
            Console.WriteLine("Ваши любимые цвета:");
            for (int i = 0; i < anketa.Colors.Length; i++)
            {
                Console.WriteLine((i + 1).ToString() + ". " + anketa.Colors[i]);
            }
        }
    }
}
