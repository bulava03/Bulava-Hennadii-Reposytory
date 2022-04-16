using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class ArraySearch
    {
        public static void LinearSearchArray(int[] array, int elem)
        {
            bool found = false;
            int i = 0;
            while (!found && i < array.Length)
            {
                if (array[i] == elem)
                {
                    Console.WriteLine("iндекс знайденого елемента: " + i);
                    found = true;
                }
                else
                {
                    i++;
                }
            }
            if (!found)
            {
                Console.WriteLine("Нiчого не знайдено");
            }
        }
        public static void BarrierSearchArray(int[] array, int elem)
        {
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = elem;
            int i = 0;
            while (array[i] != elem)
            {
                i++;
            }
            if (i == array.Length - 1)
            {
                Console.WriteLine("Нiчого не знайдено");
            }
            else
            {
                Console.WriteLine($"Знайдений iндекс елемента: {i}");
            }
            Array.Resize(ref array, array.Length - 1);
        }
        public static void BinarySearchArray(int[] array, int elem)
        {
            int left = 0;
            int right = array.Length - 1;
            int index = -1;
            while (left <= right)
            {
                index = (left + right) / 2;
                if (array[index] > elem)
                {
                    right = index - 1;
                }
                else if (array[index] < elem)
                {
                    left = index + 1;
                }
                else if (array[index] == elem)
                {
                    Console.WriteLine($"iндекс знайденого елемента: {index}");
                    return;
                }
            }
            Console.WriteLine("Нiчого не знайдено");
        }
        public static void BinarySearchGoldArray(int[] array, int elem)
        {
            int left = 0;
            int right = array.Length - 1;
            int index = -1;
            while (left <= right)
            {
                double lambda = (1 + Math.Sqrt(5)) / 2;
                double numerator = left + lambda * right;
                double denumerator = 1 + lambda;
                index = Convert.ToInt32(numerator / denumerator);
                if (array[index] > elem)
                {
                    right = index - 1;
                }
                else if (array[index] < elem)
                {
                    left = index + 1;
                }
                else if (array[index] == elem)
                {
                    Console.WriteLine($"iндекс знайденого елемента: {index}");
                    return;
                }
            }
            Console.WriteLine("Нiчого не знайдено");
        }
    }
}
