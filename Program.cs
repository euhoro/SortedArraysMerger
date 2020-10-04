using System;

namespace SortedArraysMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            var sortedArrays = new int[,]
                { {1, 3, 5, 7},
                {2, 4, 6, 8},
                {0, 9, 10, 11}};
            Print(MergeSortedArrays(sortedArrays));

            sortedArrays = new int[,] {
                { 1, 5, 6, 8},
                { 2, 4, 10, 12},
                { 3, 7, 9, 11},
                { 13, 14, 15, 16} };
            Print(MergeSortedArrays(sortedArrays));
        }

        private static void Print(int[] sortedArray)
        {
            for (int i = 0; i < sortedArray.Length - 1; i++)
            {
                Console.Write(sortedArray[i] + ",");
            }
            Console.Write(sortedArray[sortedArray.Length - 1]);
            Console.Write("\n\r");
        }

        private static int[] MergeSortedArrays(int[,] sortedArrays)
        {
            if (sortedArrays == null || sortedArrays.Length == 0)
            {
                return new int[0];
            }

            int[] mergedArray = new int[sortedArrays.Length];
            int lastInsertedIndex = 0;
            int[] arrayIndexes = new int[sortedArrays.GetLength(0)];
            while (lastInsertedIndex < sortedArrays.Length)
            {
                int arrayIndexToInsertNext = GetMinimumLocationInArrays(sortedArrays, arrayIndexes);
                mergedArray[lastInsertedIndex] = sortedArrays[arrayIndexToInsertNext, arrayIndexes[arrayIndexToInsertNext]];
                arrayIndexes[arrayIndexToInsertNext] += 1;
                lastInsertedIndex++;
            }
            return mergedArray;
        }

        private static int GetMinimumLocationInArrays(int[,] sortedArrays, int[] arrayIndexes)
        {
            int N = sortedArrays.Length / sortedArrays.GetLength(0);
            int min = Int32.MaxValue;
            int minLocationIndex = 0;
            for (int i = 0; i < arrayIndexes.Length; i++)
            {
                if (arrayIndexes[i] == N)
                {
                    continue;
                }
                if (sortedArrays[i, arrayIndexes[i]] < min)
                {
                    min = sortedArrays[i, arrayIndexes[i]];
                    minLocationIndex = i;
                }
            }
            return minLocationIndex;
        }
    }
}
