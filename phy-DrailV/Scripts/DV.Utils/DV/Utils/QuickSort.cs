using System;
using System.Runtime.CompilerServices;

namespace DV.Utils
{
	public static class QuickSort
	{
		public static void Sort<T>(T[] arr, Comparison<T> compare)
		{
			if (arr != null && arr.Length > 1)
			{
				DoSort(arr, 0, arr.Length - 1, compare);
			}
		}

		public static void Sort<T>(T[] arr, int index, int length, Comparison<T> compare)
		{
			if (arr == null)
			{
				throw new ArgumentNullException("arr");
			}
			if (index < 0 || length < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (arr.Length - index < length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (arr.Length > 1)
			{
				DoSort(arr, index, index + length - 1, compare);
			}
		}

		private static void DoSort<T>(T[] arr, int low, int high, Comparison<T> compare)
		{
			if (compare == null)
			{
				throw new ArgumentNullException("compare");
			}
			while (low < high)
			{
				int num = Partition(arr, low, high, compare);
				if (num - low < high - num)
				{
					DoSort(arr, low, num - 1, compare);
					low = num + 1;
				}
				else
				{
					DoSort(arr, num + 1, high, compare);
					high = num - 1;
				}
			}
		}

		private static int Partition<T>(T[] arr, int low, int high, Comparison<T> compare)
		{
			T y = arr[high];
			int num = low - 1;
			for (int i = low; i < high; i++)
			{
				if (compare(arr[i], y) < 0)
				{
					num++;
					Swap(arr, num, i);
				}
			}
			Swap(arr, num + 1, high);
			return num + 1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void Swap<T>(T[] arr, int i, int j)
		{
			T val = arr[j];
			T val2 = arr[i];
			arr[i] = val;
			arr[j] = val2;
		}
	}
}
