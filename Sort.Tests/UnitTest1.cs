using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sort;

namespace Sort.Tests
{
    [TestClass]
    public class SortTests
    {
        [TestMethod]
        public void MergeSort_executes_successfully_on_big_array()
        {
            int[] result = CreateBigArray();

            Algorithm.MergeSort(result);

            Assert.IsTrue(ArrayIsSorted(result));
        }

        [TestMethod]
        public void MergeSort_executes_successfully()
        {
            int[] arrayToSort1 = { 33, 1, -8, 143, 44, 20, -16 };
            int[] sortedArray1 = { -16, -8, 1, 20, 33, 44, 143 };

            int[] arrayToSort2 = { 12, 1, -55, 12, 0, 0, -6 };
            int[] sortedArray2 = { -55, -6, 0, 0, 1, 12, 12 };

            Algorithm.MergeSort(arrayToSort1);
            Algorithm.MergeSort(arrayToSort2);

            CollectionAssert.AreEqual(arrayToSort1, sortedArray1);
            CollectionAssert.AreEqual(arrayToSort2, sortedArray2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullReferenceArray_throws_exception_in_MergeSort()
        {
            Algorithm.MergeSort(null);
        }

        [TestMethod]
        public void QuickSort_executes_successfully_on_big_array()
        {
            int[] result = CreateBigArray();

            Algorithm.QuickSort(result);

            Assert.IsTrue(ArrayIsSorted(result));
        }

        [TestMethod]
        public void QuickSort_executes_successfully()
        {
            int[] arrayToSort1 = { 5, 102, -84, 34, -234, 24, -2334, 334, 1, 6, 0 };
            int[] sortedArray1 = { -2334, -234, -84, 0, 1, 5, 6, 24, 34, 102, 334 };

            int[] arrayToSort2 = { 12, 1, -55, 12, 0, 0, -6 };
            int[] sortedArray2 = { -55, -6, 0, 0, 1, 12, 12 };

            Algorithm.MergeSort(arrayToSort1);
            Algorithm.MergeSort(arrayToSort2);

            CollectionAssert.AreEqual(arrayToSort1, sortedArray1);
            CollectionAssert.AreEqual(arrayToSort2, sortedArray2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullReferenceArray_throws_exception_in_QuickSort()
        {
            Algorithm.QuickSort(null);
        }

        #region Private Methods
        private static int[] CreateBigArray()
        {
            int[] bigArray = new int[20000000];
            var random = new Random();

            for (int i = 0; i < bigArray.Length; i++)
            {
                bigArray[i] = random.Next(int.MinValue, int.MaxValue);
            }

            return bigArray;
        }

        private static bool ArrayIsSorted(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] > array[i])
                {
                    return false;
                }
            }

            return true;
        }
        #endregion
    }
}