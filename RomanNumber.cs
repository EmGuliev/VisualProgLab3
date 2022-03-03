using System;

namespace VisualProgLab3
{
    public class RomanNumber : ICloneable, IComparable
    {
        private string Roman_number;
        public RomanNumber(ushort n)
        {
            if ((n <= 0) || (n > 3999)) 
                throw new RomanNumberException("В конструктор подается надепустимое значение!");
            Roman_number = convert_to_roman(n);                       
        }
        private static string convert_to_roman(int n)
        {
            int[] arabic = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] roman = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int i = 0;
            string new_Roman_number = "";
            while (n > 0)
            {
                if (n >= arabic[i])
                {
                    n -= arabic[i];
                    new_Roman_number += roman[i];
                }
                else
                    i++;
            }
            return new_Roman_number;
        }

        private static int convert_to_arabic(string n)
        {
            int[] arabic = { 1000, 500, 100, 50, 10, 5, 1 };
            string[] roman = { "M", "D", "C", "L", "X", "V", "I" };
            int new_Arab_num = 0;
            int temp_prev = 0;
            int j;

            for (int i = n.Length - 1; i >= 0; i--)
            {
                for (j = 0; j < roman.Length; j++)
                    if (n[i] == roman[j][0])
                        break;
                if (temp_prev > arabic[j])
                    new_Arab_num -= arabic[j];
                else 
                    new_Arab_num += arabic[j];
                temp_prev = arabic[j];
            }

            return new_Arab_num;
        }

        //Сложение
        public static RomanNumber operator +(RomanNumber? n1, RomanNumber? n2)
        {
            return new RomanNumber((ushort)(convert_to_arabic(n1.Roman_number) + convert_to_arabic(n2.Roman_number)));
        }

        //Вычитание
        public static RomanNumber operator -(RomanNumber? n1, RomanNumber? n2)
        {
            int n_1 = convert_to_arabic(n1.Roman_number);
            int n_2 = convert_to_arabic(n2.Roman_number);
            if (n_1 <= n_2)
            {
                throw new RomanNumberException("Ошибка при вычитании!");
            }
            return new RomanNumber((ushort)(n_1 - n_2));
        }

        //Умножение
        public static RomanNumber operator *(RomanNumber? n1, RomanNumber? n2)
        {
            int n_1 = convert_to_arabic(n1.Roman_number);
            int n_2 = convert_to_arabic(n2.Roman_number);
            return new RomanNumber((ushort)(n_1 * n_2));
        }

        //Целочисленное деление
        public static RomanNumber operator /(RomanNumber? n1, RomanNumber? n2)
        {
            int n_1 = convert_to_arabic(n1.Roman_number);
            int n_2 = convert_to_arabic(n2.Roman_number);
            if ((n_1 % n_2 != 0))
            {
                throw new RomanNumberException("Ошибка при делении!");
            }
            return new RomanNumber((ushort)(n_1 / n_2));
        }

        //Возвращает строковое представление римского числа
        public override string ToString()
        {
            return Roman_number;
        }
        //Реализация интерфейса IClonable
        public object Clone()
        {
            int tmp = convert_to_arabic(Roman_number);
            return new RomanNumber((ushort)tmp);
            //throw new NotImplementedException();
        }
        //Реализация интерфейса IComparable
        public int CompareTo(object? obj)
        {
            if (obj is null)
                throw new RomanNumberException("Ошибка в CompareTo!");
            int num_obj = convert_to_arabic(obj.ToString());
            int Roman_number_to_Arabic = convert_to_arabic(Roman_number);
            return Roman_number_to_Arabic - num_obj;
        }

    }
}
