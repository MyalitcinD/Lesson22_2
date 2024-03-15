using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива случайных чисел:");
            int n = Convert.ToInt32(Console.ReadLine());


            Task task = new Task();




            Console.ReadKey();

        }

        static int ArraySumm(int[] arr)
        {
            int summ = 0;
            foreach(int a in arr) {
                summ += a;
            }
            return summ;
        }
        static int ArrayMax(int[] arr)
        {
            int max = arr[0];
            foreach(int a in arr) {
                if(max<a) {
                    max = a;
                }
            }
            return max;
        }
        static int[] CreateArray(int n)
        {
            Random random = new Random();
            int[] array = new int[n];
            for(int i = 0; i < n; i++) {
                array[i] = random.Next(-10000, 10000);
            }
            return array;
        }
        static void PrintArr(int[] array)
        {
            foreach(int a in array) {
                Console.Write($"{a} ");
            }
            Console.WriteLine();

        }
        
    }
}
