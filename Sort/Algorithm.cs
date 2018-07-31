using System;

namespace Sort
{
    public static class Algorithm
    {
        /// <summary>
        /// Executes merge sort of an array of the integer numbers
        /// </summary>
        /// <param name="initialArray"> Array to sort </param>
        /// <exception cref="ArgumentNullException"> Throws if array is null </exception>
        public static void MergeSort(int[] initialArray)
        {
            ValidateArray(initialArray);

            if (initialArray.Length <= 1)
            {
                return;
            }
            else
            {
                int middle = initialArray.Length / 2;

                int[] firstArray = new int[middle];
                int[] secondArray = new int[initialArray.Length - middle];

                Array.Copy(initialArray, 0, firstArray, 0, middle);
                Array.Copy(
                    initialArray,
                    middle,
                    secondArray,
                    0,
                    initialArray.Length - middle);

                MergeSort(firstArray);
                MergeSort(secondArray);

                MergeSort(initialArray, firstArray, secondArray);
            }
        }

        /// <summary>
        /// Executes quick sort of an array of the integer numbers
        /// </summary>
        /// <param name="initialArray"> Array to sort </param>
        /// <exception cref="ArgumentNullException"> Throws if array is null </exception>
        public static void QuickSort(int[] initialArray)
        {
            ValidateArray(initialArray);

            QuickSort(initialArray, 0, initialArray.Length - 1);
        }

        #region Private Methods
        /// <summary>
        /// Merges two parts of initial array
        /// </summary>
        /// <param name="initialArray"> Initial array </param>
        /// <param name="firstArray"> Left side of the initial array </param>
        /// <param name="secondArray"> Right side of the initial array </param>
        private static void MergeSort(
            int[] initialArray,
            int[] firstArray,
            int[] secondArray)
        {
            int j = 0;
            int k = 0;

            for (int i = 0; i < initialArray.Length; i++)
            {
                if (j >= firstArray.Length)
                {
                    initialArray[i] = secondArray[k++];
                }
                else if (k >= secondArray.Length)
                {
                    initialArray[i] = firstArray[j++];
                }
                else if (firstArray[j] <= secondArray[k])
                {
                    initialArray[i] = firstArray[j++];
                }
                else
                {
                    initialArray[i] = secondArray[k++];
                }
            }
        }

        /// <summary>
        /// Shifts left and right sides of array relative to the pivot element
        /// </summary>
        /// <param name="initialArray"> Initial array </param>
        /// <param name="left"> Index of the left element </param>
        /// <param name="right"> Index of the right element </param>
        private static void QuickSort(int[] initialArray, int left, int right)
        {
            int i = left;
            int j = right;
            int pivot = initialArray[(left + right) >> 1];

            while (i <= j)
            {
                while (initialArray[i] < pivot)
                {
                    i++;
                }

                while (initialArray[j] > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    Swap(ref initialArray[i], ref initialArray[j]);
                    i++;
                    j--;
                }
            }
            
            if (left < j)
            {
                QuickSort(initialArray, left, j);
            }

            if (i < right)
            {
                QuickSort(initialArray, i, right);
            }
        }

        /// <summary>
        /// Swaps two integer numbers
        /// </summary>
        /// <param name="firstNumber"> First integer number to swap </param>
        /// <param name="secondNumber"> Second integer number to swap </param>
        private static void Swap(ref int firstNumber, ref int secondNumber)
        {
            int temp = firstNumber;
            firstNumber = secondNumber;
            secondNumber = temp;
        }

        /// <summary>
        /// Checks wheather an array is null
        /// </summary>
        /// <param name="array"> Array to check </param>
        /// <exception cref="ArgumentNullException"> Throws if array is null </exception>
        private static void ValidateArray(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
        }
    }
    #endregion
}