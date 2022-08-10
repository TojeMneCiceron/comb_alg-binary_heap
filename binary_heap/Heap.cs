using System;
using System.Collections.Generic;
using System.Text;

namespace binary_heap
{
    class HeapNode<T>
    {
        int key;
        T value;

        public HeapNode(int key, T value)
        {
            this.Key = key;
            this.Value = value;
        }

        public int Key { get => key; set => key = value; }
        public T Value { get => value; set => this.value = value; }

        public override string ToString()
        {
            return $"{key}({value})";
        }
    }
    class Heap<T>
    {
        int size, n;
        HeapNode<T>[] nodes;

        public Heap(int size)
        {
            this.size = size;
            n = 0;
            nodes = new HeapNode<T>[size + 1];
        }
        public static void Swap(ref HeapNode<T> a, ref HeapNode<T> b)
        {
            HeapNode<T> temp = a;
            a = b;
            b = temp;
        }
        public HeapNode<T> Min()
        {
            return nodes[1];
        }
        public bool Insert(int new_key, T new_value)
        {
            if (n >= size)
                return false;

            n++;
            nodes[n] = new HeapNode<T>(new_key, new_value);

            for (int i = n; i > 1 && nodes[i].Key > nodes[i / 2].Key; i /= 2)
                Swap(ref nodes[i], ref nodes[i / 2]);

            return true;
        }
        public HeapNode<T> DeleteMin()
        {
            if (n == 0)
                return null;

            HeapNode<T> min = nodes[1];

            nodes[1] = nodes[n];
            n--;

            Heapify(1);

            return min;
        }
        void Heapify(int i)
        {
            for (; ; )
            {
                int left = 2 * i;
                int right = 2 * i + 1;

                int min = i;

                if (left <= n && nodes[left].Key < nodes[right].Key && nodes[left].Key < nodes[i].Key)
                { 
                    min = left; 
                }

                if (right <= n && nodes[right].Key < nodes[left].Key && nodes[left].Key < nodes[i].Key)
                { 
                    min = right;
                }

                if (min == i)
                    break;

                Swap(ref nodes[i], ref nodes[min]);
                i = min;
            }
        }
        public override string ToString()
        {
            if (n == 0)
                return "";

            string res = $"{nodes[1].Key}({nodes[1].Value})\n";

            int a = 4;

            for (int i = 2; i <= n; i++)
            {
                res += $"{nodes[i].Key}({nodes[i].Value}) ";

                if (i + 1 == a)
                {
                    res += "\n";
                    a *= 2;
                }
            }

            return res;
        }
    }
}