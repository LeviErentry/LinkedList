using System;

namespace LinkedList
{
    public class Node
    {
        public Node next;
        public int data;
    }
    public class LinkedList
    {
        private Node head = null;

        public void PrintLinkedList()
        {
            Node next_node = head;
            while (next_node != null)
            {
                Console.WriteLine(next_node.data);
                next_node = next_node.next;
            }
        }

        public void AddToFirst(int add_data)
        {
            Node new_node = new Node
            {
                data = add_data,
                next = head
            };
            head = new_node;
        }
        public void AddToLast(int add_data)
        {
            if (head == null)
            {
                head = new Node
                {
                    data = add_data,
                    next = null
                };
            }
            else
            {
                Node next_node = head;
                while (next_node.next != null)
                    next_node = next_node.next;
                next_node.next = new Node
                {
                    data = add_data,
                    next = null
                };
            }
        }
        public void AddByIndex(int add_data, int index)
        {
            if (index < 2 || head == null)
                AddToFirst(add_data);
            else
            {
                Node prev_node = head, next_node = head;
                for (int i = 1; i < index && next_node != null; i++)
                {
                    prev_node = next_node;
                    next_node = next_node.next;
                }
                Node new_node = new Node
                {
                    data = add_data,
                    next = next_node
                };
                prev_node.next = new_node;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LinkedList my_list = new();
            int data_to_add;
            Console.WriteLine("To add to the head of the list type af\r\n" +
                              "To add to the end of the list type al\r\n" +
                              "To add in the middle of the list type ai\r\n" +
                              "to end the program type exit");
            string func = Console.ReadLine();
            while (func != "exit")
            {
                Console.WriteLine("Type the data to enter");
                if (func == "af")
                {
                    data_to_add = int.Parse(Console.ReadLine());
                    my_list.AddToFirst(data_to_add);
                }
                else if(func == "al")
                {
                    data_to_add = int.Parse(Console.ReadLine());
                    my_list.AddToLast(data_to_add);
                }
                else if(func == "ai")
                {
                    data_to_add = int.Parse(Console.ReadLine());
                    Console.WriteLine("Type the place to add the data");
                    int index = int.Parse(Console.ReadLine());
                    my_list.AddByIndex(data_to_add, index);
                }
                else
                    Console.WriteLine("Wrong input");
                my_list.PrintLinkedList();
                Console.WriteLine("To add to the head of the list type af\r\n" +
                                  "To add to the end of the list type al\r\n" +
                                  "To add in the middle of the list type ai\r\n" +
                                  "to end the program type exit");
                func = Console.ReadLine();
            }
        }
    }
}

