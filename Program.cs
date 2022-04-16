using System;
using System.Diagnostics;
namespace Lab1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            bool active = true;
            while(active)
            {
                Console.WriteLine("Введiть кiлькiсть елементiв");
                Console.Write("Кiлькiсть елементiв: ");
                int NumOfElems;
                InputNumOfElems(out NumOfElems);
                int[] array = new int[NumOfElems];
                LinkedList list = new LinkedList();
                Input(ref array, ref list, NumOfElems);
                Console.WriteLine();
                Output(ref array, ref list);
                bool eleminput = false;
                int elem = 0;
                while(!eleminput)
                {
                    try
                    {
                        Console.WriteLine("Введiть шуканий елемент");
                        Console.Write("Шуканий елемент: ");
                        elem = Convert.ToInt32(Console.ReadLine());
                        eleminput = true;
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine("Елемент введено некоректно");
                    }
                }
                short choose = 0;
                while (choose == 0)
                {
                    choose = ChooseAlgorithm();
                    if (choose == 0)
                    {
                        Console.WriteLine("Варiант обрано неправильно");
                    }
                    else
                    {
                        DoAlgorithm(choose, array, list, elem);
                    }
                    if (choose != 0)
                    {
                        if (ChooseOption("Обрати iнший алгоритм?") == 1)
                        {
                            choose = 0;
                        }
                    }    
                }
                if (ChooseOption("Виконати програму ще раз?") == 2)
                {
                    active = false;
                }
            }
            
        }
        public static short ChooseAlgorithm()
        {
            short choose;
            Console.WriteLine("Оберiть алгоритм");
            Console.WriteLine("1 - Пошук перебором");
            Console.WriteLine("2 - Пошук з бар'єром");
            Console.WriteLine("3 - Пошук перебором та пошук з бар'єром");
            Console.WriteLine("4 - Бiнарний пошук");
            Console.WriteLine("5 - Бiнарний пошук (з правилом золотого перерiзу)");
            try
            {
                choose = Convert.ToInt16(Console.ReadLine());
            }
            catch (FormatException)
            {
                choose = 0;
            }
            if (choose < 1 || choose > 5)
            {
                choose = 0;
            }
            return choose;
        }
        public static void DoAlgorithm(short choose, int[] array, LinkedList list, int elem)
        {
            Stopwatch sWatch = new Stopwatch();
            if (choose == 1)
            {
                sWatch.Start();
                ArraySearch.LinearSearchArray(array, elem);
                sWatch.Stop();
                Console.WriteLine("Час виконання лiнiйного пошуку в масивi: " + sWatch.ElapsedMilliseconds.ToString());
                sWatch.Reset();
                sWatch.Start();
                list.LinearSearchList(list, elem);
                sWatch.Stop();
                Console.WriteLine("Час виконання лiнiйного пошуку в лiнiйному зв'язному списку: " + sWatch.ElapsedMilliseconds.ToString());
                sWatch.Reset();
            }
            else if (choose == 2)
            {
                sWatch.Start();
                ArraySearch.BarrierSearchArray(array, elem);
                sWatch.Stop();
                Console.WriteLine("Час виконання пошуку з бар'єром в масивi: " + sWatch.ElapsedMilliseconds.ToString());
                sWatch.Reset();
                sWatch.Start();
                list.BarrierSearchList(list, elem);
                sWatch.Stop();
                Console.WriteLine("Час виконання пошуку з бар'єром в лiнiйному зв'язному списку: " + sWatch.ElapsedMilliseconds.ToString());
                sWatch.Reset();
            }
            else if (choose == 3)
            {
                sWatch.Start();
                ArraySearch.LinearSearchArray(array, elem);
                sWatch.Stop();
                Console.WriteLine("Час виконання лiнiйного пошуку в масивi: : " + sWatch.ElapsedMilliseconds.ToString());
                sWatch.Reset();
                sWatch.Start();
                list.LinearSearchList(list, elem);
                sWatch.Stop();
                Console.WriteLine("Час виконання лiнiйного пошуку в лiнiйному зв'язному списку: " + sWatch.ElapsedMilliseconds.ToString());
                sWatch.Reset();
                sWatch.Start();
                ArraySearch.BarrierSearchArray(array, elem);
                sWatch.Stop();
                Console.WriteLine("Час виконання пошуку з бар'єром в масивi: " + sWatch.ElapsedMilliseconds.ToString());
                sWatch.Reset();
                sWatch.Start();
                list.BarrierSearchList(list, elem);
                sWatch.Stop();
                Console.WriteLine("Час виконання пошуку з бар'єром в лiнiйному зв'язному списку: " + sWatch.ElapsedMilliseconds.ToString());
                sWatch.Reset();
            }
            else if (choose == 4)
            {
                sWatch.Start();
                ArraySearch.BinarySearchArray(array, elem);
                sWatch.Stop();
                Console.WriteLine("Час виконання бiнарного пошуку в масивi: " + sWatch.ElapsedMilliseconds.ToString());
                sWatch.Reset();
                sWatch.Start();
                LinkedList.BinarySearchList(list, elem);
                sWatch.Stop();
                Console.WriteLine("Час виконання бiнарного пошуку в лiнiйному зв'язному списку: " + sWatch.ElapsedMilliseconds.ToString());
                sWatch.Reset();
            }
            else if (choose == 5)
            {
                sWatch.Start();
                ArraySearch.BinarySearchGoldArray(array, elem);
                sWatch.Stop();
                Console.WriteLine("Час виконання бiнарного пошуку (iз золотим перерiзом) в масивi: " + sWatch.ElapsedMilliseconds.ToString());
                sWatch.Reset();
                sWatch.Start();
                LinkedList.BinarySearchGoldList(list, elem);
                sWatch.Stop();
                Console.WriteLine("Час виконання бiнарного пошуку (iз золотим перерiзом) в лiнiйному зв'язному списку: " + sWatch.ElapsedMilliseconds.ToString());
                sWatch.Reset();
            }
        }
        public static short ChooseOption(string str)
        {
            short choose = 0;
            while (choose == 0)
            {
                Console.WriteLine(str);
                Console.WriteLine("1 - Так");
                Console.WriteLine("2 - Нi");
                try
                {
                    choose = Convert.ToInt16(Console.ReadLine());
                }
                catch (FormatException)
                {
                    choose = 0;
                }
                if (choose != 1 && choose != 2)
                {
                    choose = 0;
                }
                if (choose == 0)
                {
                    Console.WriteLine("Варiант обрано неправильно");
                }
            }
            return choose;
        }
        public static void Output(ref int[] array, ref LinkedList list)
        {
            Console.Write("Масив: ");
            foreach (int elem in array)
            {
                Console.Write(elem + "   ");
            }
            Console.WriteLine();
            Console.Write("Лiнiйний зв'язаний список: ");
            list.PrintList();
        }
        public static void Input(ref int[] array, ref LinkedList list, int NumOfElems)
        {
            Console.WriteLine("Введiть елементи");
            for (int i = 0; i < NumOfElems; i++)
            {
                Console.Write(i + 1 + "-й елемент: ");
                int elem = -1;
                while (elem < 0)
                {
                    try
                    {
                        elem = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        elem = -1;
                        Console.WriteLine("Елемент введено некоректно");
                    }
                }
                array[i] = elem;
                list.AddBack(elem);
            }
        }
        public static void InputNumOfElems(out int num)
        {
            num = 0;
            while (num < 1)
            {
                try
                {
                    num = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    num = 0;
                }
            }
        }
    }
}