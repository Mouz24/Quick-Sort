using System;
using System.Collections.Generic;

#pragma warning disable SA1611
#pragma warning disable S1854
#pragma warning disable S1066

namespace QuickSort
{
    public static class Sorter
    {
        /// <summary>
        /// Sorts an <paramref name="array"/> with quick sort algorithm.
        /// </summary>
        public static void QuickSort(this int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0)
            {
                array = Array.Empty<int>();
            }
            else
            {
                var stack = new Stack<int>();

                int pivot;
                int pivotIndex = 0;
                int leftIndex = 0;
                int rightIndex = array.Length - 1;

                stack.Push(pivotIndex);
                stack.Push(rightIndex);

                int leftIndexOfSubSet, rightIndexOfSubset;

                while (stack.Count > 0)
                {
                    rightIndexOfSubset = stack.Pop();
                    leftIndexOfSubSet = stack.Pop();

                    leftIndex = leftIndexOfSubSet + 1;
                    pivotIndex = leftIndexOfSubSet;
                    rightIndex = rightIndexOfSubset;

                    pivot = array[pivotIndex];

                    if (leftIndex > rightIndex)
                    {
                        continue;
                    }

                    while (leftIndex < rightIndex)
                    {
                        while ((leftIndex <= rightIndex) && (array[leftIndex] <= pivot))
                        {
                            leftIndex++;
                        }

                        while ((leftIndex <= rightIndex) && (array[rightIndex] >= pivot))
                        {
                            rightIndex--;
                        }

                        if (rightIndex >= leftIndex)
                        {
                            SwapElement(array, leftIndex, rightIndex);
                        }
                    }

                    if (pivotIndex <= rightIndex)
                    {
                        if (array[pivotIndex] > array[rightIndex])
                        {
                            SwapElement(array, pivotIndex, rightIndex);
                        }
                    }

                    if (leftIndexOfSubSet < rightIndex)
                    {
                        stack.Push(leftIndexOfSubSet);
                        stack.Push(rightIndex - 1);
                    }

                    if (rightIndexOfSubset > rightIndex)
                    {
                        stack.Push(rightIndex + 1);
                        stack.Push(rightIndexOfSubset);
                    }
                }
            }
        }

        public static void SwapElement(int[] arr, int left, int right)
        {
            if (arr is null)
            {
                throw new ArgumentNullException(nameof(arr));
            }

            int temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
        }

        /// <summary>
        /// Sorts an <paramref name="array"/> with recursive quick sort algorithm.
        /// </summary>
        public static void RecursiveQuickSort(this int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0)
            {
                array = Array.Empty<int>();
            }
            else
            {
                SortArray(array, 0, array.Length - 1);
            }
        }

        public static int[] SortArray(int[] array, int leftIndex, int rightIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex];
            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }

                while (array[j] > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
            {
                SortArray(array, leftIndex, j);
            }

            if (i < rightIndex)
            {
                SortArray(array, i, rightIndex);
            }

            return array;
        }
    }
}
