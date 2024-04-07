using System;

namespace CommonAlgorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = GenerateArray();
            while (true)
            {
                
                Console.WriteLine("1. Print Array");
                Console.WriteLine("2. Linear Search");
                Console.WriteLine("3. Binary Search");
                Console.WriteLine("4. Bubble Sort");
                Console.WriteLine("5. Insertion Sort");
                Console.WriteLine("6. Quick Sort");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        PrintArray(array);
                        break;
                    case "2":
                        Console.Write("INPUT: ");
                        int data1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(LinearSearch(array, data1));
                        break;
                    case "3":
                        Console.Write("INPUT: ");
                        int data2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(BinarySearch(array, data2));
                        break;
                    case "4":
                        BubbleSort(array);
                        break;
                    case "5":
                        InsertionSort(array);
                        break;
                    case "6":
                        QuickSort(array, 0, array.Length - 1);
                        break;
                    default:
                        PrintArray(array);
                        break;
                }
            }
        }
        public static int[] GenerateArray() // generates array of random numbers between 1 and 20
        {
            Random random = new Random();
            int[] array = new int[20];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 20);
            }
            return array;
        }
        public static void PrintArray(int[] array) // prints array seperated by ,
        {
            Console.Write(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                Console.Write(", " + array[i]);
            }
            Console.WriteLine();
        }
        public static int LinearSearch(int[] array, int data) 
        {
            for (int i = 0; i < array.Length; i++) // loops through each element in order
            {
                if (array[i] == data)
                { return i; }
            }
            return -1;
        }
        public static int BinarySearch(int[] array, int data) 
        {
            int lPointer = 0;
            int rPointer = array.Length - 1;
            while (lPointer < rPointer) // loops until pointers overlap
            {
                int i = (lPointer + rPointer) / 2;
                if (array[i] < data) // eliminates half array from search
                { rPointer = i; }
                else if (array[i] > data)
                { lPointer = i; }
                else { return i; }
            }
            return -1;
        }
        public static void BubbleSort(int[] array) 
        {
            bool unsorted = true;
            int i = 0;
            int temp;
            while(unsorted)// loop until sorted
            {
                unsorted = false; // bool flag for if any sorts occur
                for (int j = 0; j < array.Length - i - 1; j++) {
                    if (array[j] > array[j + 1]) // swap item if larger
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        unsorted = true;
                    }
                }
                i++;
            }
        }
        public static void InsertionSort(int[] array) 
        {
            int temp;
            for (int i = 0; i < array.Length - 1; i++) // iterate through unsorted array
            {
                for (int j = i + 1; j > 0; j--) // iterate backwards through sorted array
                {
                    if (array[j - 1] > array[j]) // swap if item is smaller
                    {
                        temp = array[j - 1]; // swap items at j-1 and j
                        array[j - 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
        public static void QuickSort(int[] array, int lPointer, int rPointer) // Couldn't get working - can explain the algorithm though
        {
            if (lPointer < rPointer) {
                int temp;
                while (lPointer != rPointer)
                {
                    if (array[lPointer] > array[rPointer])
                    {
                        temp = array[rPointer];
                        array[rPointer] = array[lPointer];
                        array[lPointer] = temp;
                        lPointer++;
                    }
                    else { rPointer--; }
                }
                QuickSort(array, 0, rPointer);
                QuickSort(array, lPointer, array.Length - 1);
            }
        }

    }
}
