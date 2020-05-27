using System;

namespace Rus_OOP_6._1
{
    interface IUniversity
    {
        void Swap(ref University x, ref University y);
        int Partition(University[] array, int minIndex, int maxIndex);
        University[] QuickSort1(University[] array, int minIndex, int maxIndex);
        University[] QuickSort(University[] array);



    }

    public class University:IUniversity
    {


        public string LastName;
        public DateTime data;
        public string city;

        public University(string LastName, DateTime data, string city)
        {
            this.LastName = LastName;
            this.data = data;
            this.city = city;
        }
        public void Swap(ref University x, ref University y)
        {
            var t = x;
            x = y;
            y = t;
        }


        public int Partition(University[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i].data < array[maxIndex].data)
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }
        public University[] QuickSort1(University[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort1(array, minIndex, pivotIndex - 1);
            QuickSort1(array, pivotIndex + 1, maxIndex);

            return array;
        }

        public University[] QuickSort(University[] array)
        {

            return QuickSort1(array, 0, array.Length - 1);
        }

    }
    class Program
    {
      
        static void Main(string[] args)
        {

            Console.Write("Введіть кількість Студентів: ");
            int n = int.Parse(Console.ReadLine());
            University[] b = new University[n];
            DateTime[] d = new DateTime[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Студент №" + (i + 1));

                Console.Write("прізвище: ");
                string LastName = Console.ReadLine();
                Console.Write("дата народження: ");
                string demotime = Console.ReadLine();
                DateTime data = Convert.ToDateTime(demotime);

                Console.Write(" Місце народження: ");
                string city = Console.ReadLine();


                b[i] = new University(LastName, data, city);
                d[i] = b[i].data;

            }



            University[] b1 = new University[n];
            Console.WriteLine("Прізвище\t\tДата народження\t\tМісце народження");
            b[0] = QuickSort(b);





        }
    }
}

