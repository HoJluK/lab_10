using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_10
{
    class Program
    {
        public class Graph
        {
            private int V = 0;
            private int[,] graph = null;
            public Graph(int[,] matrix, int vernum)
            {
                graph = matrix;
                V = vernum;
            }

            public Stack<int> DFS(int startPos, int endPos)
            {
                Stack<int> st = new Stack<int>();

                int[] vPath = new int[V];
                int[] checkedv = new int[V];

                st.Push(startPos);
                checkedv[startPos] = 1;

                while (st.Count > 0)
                {
                    int i = st.Pop();

                    for (int j = V - 1; j >= 0; j--)
                    {
                        if (graph[i, j] == 1 && checkedv[j] == 0)
                        {
                            checkedv[j] = 1;
                            st.Push(j);
                            vPath[j] = i;

                            if (j == endPos)
                                return backChain(vPath, startPos, endPos);
                        }
                    }
                }
                return null;
            }
            public Stack<int> BFS(int startPos, int endPos)
            {
                Queue<int> q = new Queue<int>();

                int[] vPath = new int[V];
                int[] checkedv = new int[V];

                q.Enqueue(startPos);
                checkedv[startPos] = 1;

                while (q.Count > 0)
                {
                    int i = q.Dequeue();

                    for (int j = 0; j < V; j++)
                    {
                        if (graph[i, j] == 1 && checkedv[j] == 0)
                        {
                            checkedv[j] = 1;
                            q.Enqueue(j);
                            vPath[j] = i;

                            if (j == endPos)
                                return backChain(vPath, startPos, endPos);
                        }
                    }
                }
                return null;
            }
            public Stack<int> backChain(int[] p, int startPos, int endPos)
            {
                int pos = endPos;

                Stack<int> pathStack = new Stack<int>();
                pathStack.Push(pos);

                while (pos != startPos)
                {
                    pos = p[pos];
                    pathStack.Push(pos);
                }

                return pathStack;
            }
        }
        static void ShowPath(Stack<int> stack)
        {
                int cnt = 0;
                foreach (int i in stack)
                {
                    Console.Write((cnt == 0) ? Convert.ToString(i + 1) : " -> " + (i + 1));
                    cnt++;
               }
                 
            Console.WriteLine();
        }
        static void DictionaryAdd(Stack<int> BFS, int[,] distances, ref Dictionary<string, int> dist, int city)
        {
            int prevNum = -1;
            int sum = 0;
                foreach (var i in BFS)
                {
                    if (prevNum == -1)
                        prevNum = i;
                    else
                    {
                        sum += distances[prevNum, i];
                        prevNum = i;
                        dist["From " + city + " to " + (i + 1)] = sum;
                    }
                }
            }
    static int len = 100000;
        static Random rnd = new Random();
        static void mergeSort(int[] array, int left, int right)
        {
            if (right <= left)
                return;
            int mid = (left + right) / 2;

            mergeSort(array, left, mid);
            mergeSort(array, mid + 1, right);
            merge(array, left, mid, right);
        }
        static void merge(int[] array, int left, int mid, int right)
        {
            int[] tmp = new int[right - left + 1];

            int i = left, j = mid + 1, k = 0;

            for (k = 0; k < tmp.Length; k++)
            {
                if (i > mid)
                    tmp[k] = array[j++];
                else if (j > right)
                    tmp[k] = array[i++];
                else
                    tmp[k] = (array[i] > array[j]) ? array[i++] : array[j++];
            }

            k = 0;
            i = left;
            while (k < tmp.Length && i <= right)
                array[i++] = tmp[k++];
        }
        static void sort(int[] array)
        {
            int n = array.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(array, n, i);

            for (int i = n - 1; i >= 0; i--)
            {
                int tmp = array[0];
                array[0] = array[i];
                array[i] = tmp;

                heapify(array, i, 0);
            }
        }
        static void heapify(int[] array, int n, int i)
        {
            int largest = i;
            int l = 2 * i + 1; 
            int r = 2 * i + 2; 

            if (l < n && array[l] > array[largest])
                largest = l;

            if (r < n && array[r] > array[largest])
                largest = r;

            if (largest != i)
            {
                int swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;

                heapify(array, n, largest);
            }
        }
        static void Swap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
        }

        static int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        static int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        static int[] QuickSort(int[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }
        static int[] SortArray(int[] inputArray)
        {
            int[] countArray = new int[inputArray.Max() + 1];
            for (int i = 0; i < inputArray.Length; i++)
            {
                countArray[inputArray[i]]++;
            }
            int[] sortedArray = new int[inputArray.Length];
            int sortedArrayIndex = 0;
            for (int i = countArray.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < countArray[i]; j++)
                {
                    sortedArray[sortedArrayIndex++] = i;
                }
            }
            return sortedArray;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер задания");
            int tmp = Convert.ToInt32(Console.ReadLine());
            save:
            switch (tmp)
            {
                case 1:
                    ex1();
                    goto save;
                case 2:
                    ex2();
                    goto save;
                case 3:
                    ex3();
                    goto save;
                case 4:
                    ex4();
                    goto save;
            }
        }
        static void ex1()
        {
            Console.WriteLine("Введите вариант сортировки");
            int tmp = Convert.ToInt32(Console.ReadLine());
            save1:
            switch (tmp)
            {
                case 1:
                    merg();
                    goto save1;
                case 2:
                    pyr();
                    goto save1;
                case 3:
                    qsort();
                    goto save1;
            }
        }
        static void merg()
        {
            int[] array = new int[len];
            int left = 0;
            int right = array.Length - 1;
            for (int i = 0; i < len; i++)
            {
                array[i] = rnd.Next(-999, 999);
               
            }
            mergeSort(array, left, right);
            array.Reverse();
            Console.ReadKey();
        }
        static void pyr()
        {
            int[] array = new int[len];
            int n = array.Length;
            for (int i = 0; i < len; i++)
            {
                array[i] = rnd.Next(-999, 999);
            }
            sort(array);
            array.Reverse();
            Console.ReadKey();
        }
        static void qsort()
        {
            
            int[] array = new int[len];
            int minIndex = 0;
            int maxIndex = array.Length -1;
            for (int i = 0; i < len; i++)
            {
                array[i] = rnd.Next(-999, 999);
            }
            QuickSort(array , minIndex , maxIndex);
            array.Reverse();
            foreach (int i in array)
                Console.WriteLine(i);
            Console.ReadKey();
        }
        static void ex2()
        {
            int[] values = { 1, 2, 5, 10, 20, 50, 100 };
            int n = 100;
            int[] array = new int[n];
            Console.WriteLine("Начальынй");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = values[rnd.Next(0, values.Length)];
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("\n Sorted");
            int[] array2 = SortArray(array);
            foreach (int i in array2)
                Console.Write(i + " ");
            Console.ReadKey();
        }
        static void ex3()
        {
            Console.WriteLine("Enter x");

            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter y");

            int y = Convert.ToInt32(Console.ReadLine());
            int[,] graph = {    { 0, 1, 1, 0, 0, 0, 0, 0 },
                                { 1, 0, 0, 0, 0, 1, 1, 0 },
                                { 1, 0, 0, 1, 0, 1, 0, 1 },
                                { 0, 0, 1, 0, 1, 0, 0, 0 },
                                { 0, 0, 0, 1, 0, 1, 0, 0 },
                                { 0, 1, 1, 0, 1, 0, 0, 0 },
                                { 0, 1, 0, 0, 0, 0, 0, 1 },
                                { 0, 0, 1, 0, 0, 0, 1, 0 }    };

            Graph G = new Graph(graph , 8);

            Stack<int> dfs = G.DFS(x-1, y-1 );
            Stack<int> bfs = G.BFS(x-1 , y-1);
            Console.WriteLine("DFS");
            ShowPath(dfs);
            Console.WriteLine();
            Console.WriteLine("BFS");
            ShowPath(bfs);
            Console.ReadKey();
        }
        static void ShowPath1(Stack<int> stack)
        {

            int cnt = 0;
            foreach (int i in stack)
            {
                Console.Write((cnt == 0) ? Convert.ToString(i + 1) : " -> " + (i + 1));
                cnt++;
            }


        }
        static void ex4()
        {
            int[,] distances = new int[10, 10];
            for (int i = 0; i < distances.GetLength(0); i++)
                for (int j = 0; j < distances.GetLength(1); j++)
                    distances[i, j] = -1;
            for (int i = 0; i < distances.GetLength(0); i++)
                distances[i, rnd.Next(0, i)] = rnd.Next(40, 120);
            for (int i = 0; i < distances.GetLength(0); i++)
                for (int j = 0; j < distances.GetLength(1); j++)
                    if (j > i)
                        distances[i, j] = distances[j, i];
            for (int i = 0; i < distances.GetLength(0); i++)
            {
                for (int j = 0; j < distances.GetLength(1); j++)
                    Console.Write("{0, -3} ", distances[i, j]);
                Console.WriteLine("\n");
            }
            Console.WriteLine();
            int city = 0, limit = 200;
            while (city < 1 || city > distances.GetLength(0))
            {
                Console.Write("Enter the number of city (from 1 to " + distances.GetLength(0) + "): ");
                city = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();
            Graph1 G = new Graph1(distances, distances.GetLength(0));
            Dictionary<string, int> dist = new Dictionary<string, int>();
            Console.WriteLine("\nPaths:\n");
            for (int j = 0; j < distances.GetLength(0); j++)
                if (!dist.ContainsKey("From " + city + " to " + j + 1) && city != j + 1)
                {
                    var stackBFS = G.BFS1(city - 1, j);
                    ShowPath1(stackBFS);
                    Console.WriteLine();
                    DictionaryAdd(stackBFS, distances, ref dist, city);
                }
            Console.WriteLine("\nDistances:\n");
            foreach (var item in dist)
                if (item.Value <= limit)
                    Console.WriteLine(item.Key + " : " + item.Value + "\n");

        }
        public class Graph1
        {
            private int vertices = 0;

            private int[,] graph = null;

            public Graph1(int[,] adjacencyMatrix, int vertNum)
            {
                graph = adjacencyMatrix;
                vertices = vertNum;
            }
            public Stack<int> backChain1(int[] p, int startPos, int endPos)
            {
                int pos = endPos;

                Stack<int> pathStack = new Stack<int>();
                pathStack.Push(pos);

                while (pos != startPos)
                {
                    pos = p[pos];
                    pathStack.Push(pos);
                }

                return pathStack;
            }
            public Stack<int> BFS1(int startPos, int endPos)
            {
                Queue<int> q = new Queue<int>();

                int[] path = new int[vertices];
                int[] checkedVertices = new int[vertices];

                q.Enqueue(startPos);
                checkedVertices[startPos] = 1;

                while (q.Count > 0)
                {
                    int i = q.Dequeue();
                    for (int j = 0; j < vertices; j++)
                        if (graph[i, j] > -1 && checkedVertices[j] == 0)
                        {
                            checkedVertices[j] = 1;
                            q.Enqueue(j);
                            path[j] = i;

                            if (j == endPos)
                                return backChain1(path, startPos, endPos);
                        }
                }
                return null;
            }
            static void DictionaryAdd(Stack<int> stackBFS, int[,] distances, ref Dictionary<string, int> dist, int city)
            {
                int prevNum = -1, sum = 0;
                
                    foreach (var i in stackBFS)
                    {
                        if (prevNum == -1)
                            prevNum = i;
                        else
                        {
                            sum += distances[prevNum, i];
                            prevNum = i;
                            dist["From " + city + " to " + (i + 1)] = sum;
                        }
                    }
               
            }
           
        }
    }
}
