using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TaskApp
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива случайных чисел:");
            int n = Convert.ToInt32(Console.ReadLine());
            Func<object, int[]> func1 = new Func<object, int[]>(CreateArray);
            Task<int[]> task1 = new Task<int[]>(func1, n);


            Action<Task<int[]>> act1 = new Action<Task<int[]>>(PrintArr);
            Task task2 = task1.ContinueWith(act1);

            Func<Task<int[]>, int> func2 = new Func<Task<int[]>, int>(ArraySumm);
            Task<int> task3 = task1.ContinueWith<int>(func2);

            Func<Task<int[]>, int> func3 = new Func<Task<int[]>, int>(ArrayMax);
            Task<int> task4 = task1.ContinueWith<int>(func3);
            task1.Start();
            task2.Wait();
            Console.WriteLine($"Summ = { task3.Result}");
            Console.WriteLine($"Max = { task4.Result}");
            Console.ReadKey();

        }


        static int ArraySumm(Task<int[]> task)
        {
            int[] arr = task.Result;
            int summ = 0;
            foreach(int a in arr) {
                summ += a;
            }
            return summ;
        }
        static int ArrayMax(Task<int[]> task)
        {
            int[] arr = task.Result;
            int max = arr[0];
            foreach(int a in arr) {
                if(max < a) {
                    max = a;
                }
            }
            return max;
        }
        static int[] CreateArray(object a)
        {
            int n = (int)a;
            Random random = new Random();
            int[] array = new int[n];
            for(int i = 0; i < n; i++) {
                array[i] = random.Next(0, 1000);
            }
            return array;
        }
        static void PrintArr(Task<int[]> task)
        {
            int[] array = task.Result;
            foreach(int a in array) {
                Console.Write($"{a} ");
            }
            Console.WriteLine();

        }

    }
}
