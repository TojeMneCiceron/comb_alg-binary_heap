using System;
using System.IO;

namespace binary_heap
{
    class Program
    {
        public static void GenerateHeap(int size, int n, int max)
        {
            StreamWriter writer = new StreamWriter(@"C:\Users\Пользователь\source\repos\binary_heap\binary_heap\output.txt");

            Heap<char> heap = new Heap<char>(size);

            Random rand = new Random();

            char c = 'a';

            writer.WriteLine("\n---------------------Creating heap---------------------\n");

            for (int i = 0; i < n; i++)
            {
                if (!heap.Insert(rand.Next(1, max), c))
                {
                    writer.WriteLine("\nКуча переполнена\n");
                    break;
                }

                writer.WriteLine($"\n{heap}\n");

                c++;
            }

            for (int i = 0; i < 2; i++)
            {
                writer.WriteLine("\n---------------------Finding min---------------------\n");

                HeapNode<char> heapNode = heap.Min();

                if (heapNode is null)
                {
                    writer.WriteLine("The heap is empty");
                    break;
                }
                writer.WriteLine($"\nMin: {heapNode}\n");

                writer.WriteLine("\n---------------------Deleting min---------------------\n");

                heapNode = heap.DeleteMin();

                writer.WriteLine($"\nDeleted node: {heapNode}\n");

                writer.WriteLine($"\n{heap}\n");
            }

            writer.Close();
        }

        public static void Insert(ref Heap<string> heap)
        {
            Console.WriteLine("\n---------------------Inserting node---------------------\n");

            Console.WriteLine("Enter key");
            int key = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter value");
            string value = Console.ReadLine();

            if (!heap.Insert(key, value))
            {
                Console.WriteLine("\nКуча переполнена\n");
                return;
            }

            Console.WriteLine($"\n{heap}\n");
        }

        public static void FindMin(Heap<string> heap)
        {
            Console.WriteLine("\n---------------------Finding min---------------------\n");

            HeapNode<string> heapNode = heap.Min();

            if (heapNode is null)
            {
                Console.WriteLine("The heap is empty");
                return;
            }

            Console.WriteLine($"\nMin: {heapNode}\n");
        }

        public static void DeleteMin(ref Heap<string> heap)
        {
            Console.WriteLine("\n---------------------Deleting min---------------------\n");

            HeapNode<string> heapNode = heap.DeleteMin();

            if (heapNode is null)
            {
                Console.WriteLine("The heap is empty");
                return;
            }

            Console.WriteLine($"\nDeleted node: {heapNode}\n");

            Console.WriteLine($"\n{heap}\n");
        }

        public static void CreateHeap(int size)
        {
            Heap<string> heap = new Heap<string>(size);

            while (true)
            {
                string ans = "";
                Console.WriteLine("\nChoose operation:\n1 - Insert\n2 - Find min\n3 - Delete min\n");
                ans = Console.ReadLine();

                if (ans == "1")
                {
                    Insert(ref heap);
                }
                else
                if (ans == "2")
                {
                    FindMin(heap);
                }
                else
                if (ans == "3")
                {
                    DeleteMin(ref heap);
                }
                else
                {
                    continue;
                }

                Console.WriteLine("\nContinue? y/n");
                ans = Console.ReadLine();
                if (ans == "n")
                    break;
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                string ans = "";
                Console.WriteLine("Choose way of creation:\n1 - Console\n2 - Generate\n");
                ans = Console.ReadLine();

                if (ans == "1")
                {
                    Console.WriteLine("Enter heap size");
                    int size = Convert.ToInt32(Console.ReadLine());

                    CreateHeap(size);
                    break;
                }
                else
                if (ans == "2")
                {
                    Console.WriteLine("Enter heap size");
                    int size = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter nodes count");
                    int n = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter max key value");
                    int max = Convert.ToInt32(Console.ReadLine());

                    GenerateHeap(size, n, max);
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
