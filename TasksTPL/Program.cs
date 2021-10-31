using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksTPL
{
    class Program
    {
        #region Статические методы
        //Метод определения суммы массива
        static void SumArray (int [] array)
        {
            int Sum = array.Sum();
            Console.WriteLine("Сумма - {0}", Sum);
        }
        // Метод определения максимального значения массива
        static void MaxArray (Task task, object n)
        {
            int[] array = (int[])n;
            int max = array.Max();
            Console.WriteLine("Наибольшее число - {0}", max);
        }

        #endregion
        static void Main(string[] args)
        {
            //Длина массива
            Console.WriteLine("Введите длину массива:");
            int lengthArray = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите нижний диапазон рандомных чисел:");
            int minRandom = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите верхний диапазон рандомных чисел:");
            int maxRandom = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[lengthArray];
            Random random = new Random();
            for (int i = 0; i < lengthArray; i++)
            {
                array[i] = random.Next(minRandom, maxRandom);
            }
            object arrayObject = (object)array;

            Task taskSum = new Task(() => SumArray(array));

            Action<Task, object> actionMax = new Action<Task, object>(MaxArray);
            Task taskMax = taskSum.ContinueWith(actionMax, arrayObject);

            taskSum.Start();
            
            Console.ReadKey();
        }
    }

}
