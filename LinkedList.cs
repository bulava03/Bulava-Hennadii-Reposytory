using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class LinkedList
    {
        private int count = 0;
        private Node head = null;
        private Node tail = null;
        public class Node
        {
            public int Data;
            public Node Next;
            public Node(int data, Node next)
            {
                Data = data;
                Next = next;
            }
        }
        public void AddBack(int data)
        {
            if (head == null)
            {
                head = new Node(data, null);
                tail = head;
            }
            else
            {
                tail.Next = new Node(data, null);
                tail = tail.Next;
            }
            count++;
        }
        public void PrintList()
        {
            Node n = head;
            while (n != null)
            {
                Console.Write(n.Data + "   ");
                n = n.Next;
            }
            Console.WriteLine();
        }
        public void LinearSearchList(LinkedList list, int elem)
        {
            bool IsFound = false;
            int i = 0;
            Node n = head;
            while (n != null && !IsFound)
            {
                if (n.Data == elem)
                {
                    Console.WriteLine("iндекс знайденого елемента: " + i + "   ");
                    IsFound = true;
                }
                n = n.Next;
                i++;
            }
            if (!IsFound)
            {
                Console.WriteLine("Нiчого не знайдено");
            }
        }
        public void BarrierSearchList(LinkedList list, int elem)
        {
            list.AddBack(elem);
            Node n = head;
            int i = 0;
            while (n.Data != elem)
            {
                n = n.Next;
                i++;
            }
            if (i == count - 1)
            {
                Console.WriteLine("Нiчого не знайдено");
            }
            else
            {
                Console.WriteLine($"Знайдений iндекс елемента: {i}");
            }
            count--;
            n = head;
            for (i = 0; i < count - 1; i++)
            {
                n = n.Next;
            }
            n.Next = null;
        }
        public static Node MiddleElem(Node start, Node last, out int i)
        {
            i = 0;
            if (start == null)
            {
                return null;
            }
            Node slow = start;
            Node fast = start.Next;
            i++;
            while (fast != last)
            {
                fast = fast.Next;
                if (fast != last)
                {
                    slow = slow.Next;
                    fast = fast.Next;
                    i++;
                }
            }
            return slow;
        }
        public static Node MiddleElemGold(Node start, Node last, out int i)
        {
            i = 0;
            if (start == null)
            {
                return null;
            }
            Node slow = start;
            Node fast = start.Next;
            double counter = 0;
            while (fast != last)
            {
                fast = fast.Next;
                counter++;
            }
            i = Convert.ToInt32(counter);
            counter *= ((1 + Math.Sqrt(5)) / 2);
            for (int j = 0; j < counter; j++)
            {
                slow = slow.Next;
            }
            return slow;
        }
        public static Node BinarySearchList(LinkedList list, int elem)
        {
            Node start = list.head;
            Node last = null;
            int index = -1;
            int i;
            do
            {
                Node mid = MiddleElem(start, last, out i);
                if (mid == null)
                {
                    Console.WriteLine("Нiчого не знайдено");
                    return null;
                }
                else if (mid.Data == elem)
                {
                    index += i;
                    Console.WriteLine("iндекс знайденого елемента: " + index);
                    return mid;
                }
                else if (mid.Data < elem)
                {
                    start = mid.Next;
                    index += i;
                }
                else
                {
                    last = mid;
                }
            } while (last == null || last != start);
            Console.WriteLine("Нiчого не знайдено");
            return null;
        }
        public static Node BinarySearchGoldList(LinkedList list, int elem)
        {
            Node start = list.head;
            Node last = null;
            int index = -1;
            int i;
            do
            {
                Node mid = MiddleElem(start, last, out i);
                if (mid == null)
                {
                    Console.WriteLine("Нічого не знайдено");
                    return null;
                }
                else if (mid.Data == elem)
                {
                    index += i;
                    Console.WriteLine("iндекс знайденого елемента: " + index);
                    return mid;
                }
                else if (mid.Data < elem)
                {
                    start = mid.Next;
                    index += i;
                }
                else
                {
                    last = mid;
                }
            } while (last == null || last != start);
            Console.WriteLine("Нiчого не знайдено");
            return null;
        }
    }
}
