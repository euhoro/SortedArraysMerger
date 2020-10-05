using System;
using System.Collections.Generic;

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

        private static int[] MergeSortedArrays(int[,] sortedArrays)
        {
            if (sortedArrays == null || sortedArrays.Length == 0)
            {
                return new int[0];
            }

            int[] mergedArray = new int[sortedArrays.Length];
            int lastInsertedIndex = 0;
            int K = sortedArrays.GetLength(0);
            int N = sortedArrays.Length / K;
            SortedList<int, Tuple<int, int>> sortedValuesWithLocation = FillSortedArray(sortedArrays);
            while (sortedValuesWithLocation.Count > 0)
            {
                KeyValuePair<int, Tuple<int, int>> minimumWithLocation = getMinimumWithLocation(sortedValuesWithLocation);
                mergedArray[lastInsertedIndex] = minimumWithLocation.Key;
                lastInsertedIndex++;
                sortedValuesWithLocation.Remove(minimumWithLocation.Key);
                if (minimumWithLocation.Value.Item2 < N - 1)
                {
                    sortedValuesWithLocation.Add(sortedArrays[minimumWithLocation.Value.Item1, minimumWithLocation.Value.Item2 + 1],
                        new Tuple<int, int>(minimumWithLocation.Value.Item1, minimumWithLocation.Value.Item2 + 1));
                }
            }
            return mergedArray;
        }

        private static KeyValuePair<int, Tuple<int, int>> getMinimumWithLocation(SortedList<int, Tuple<int, int>> sortedValuesToIndex)
        {
            var en = sortedValuesToIndex.GetEnumerator();
            en.MoveNext();
            var minimumWithLocation = en.Current;
            return minimumWithLocation;
        }

        private static SortedList<int, Tuple<int, int>> FillSortedArray(int[,] sortedArrays)
        {
            var sortedValuesToIndex = new SortedList<int, Tuple<int, int>>();
            for (int i = 0; i < sortedArrays.GetLength(0); i++)
            {
                sortedValuesToIndex.Add(sortedArrays[i, 0], new Tuple<int, int>(i, 0));
            }
            return sortedValuesToIndex;
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
    }
}
