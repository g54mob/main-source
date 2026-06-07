using System;
using UnityEngine;

namespace Dreamteck
{
	public static class ArrayUtility
	{
		public static void Add<T>(ref T[] array, T item)
		{
			T[] array2 = new T[array.Length + 1];
			array.CopyTo(array2, 0);
			array2[^1] = item;
			array = array2;
		}

		public static bool Contains<T>(T[] array, T item)
		{
			for (int i = 0; i < array.Length; i++)
			{
				try
				{
					if (array[i].Equals(item))
					{
						return true;
					}
				}
				catch
				{
				}
			}
			return false;
		}

		public static int IndexOf<T>(T[] array, T value)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].Equals(value))
				{
					return i;
				}
			}
			return 0;
		}

		public static void Insert<T>(ref T[] array, int index, T item)
		{
			T[] array2 = new T[array.Length + 1];
			for (int i = 0; i < array2.Length; i++)
			{
				if (i < index)
				{
					array2[i] = array[i];
				}
				else if (i > index)
				{
					array2[i] = array[i - 1];
				}
				else
				{
					array2[i] = item;
				}
			}
			array = array2;
		}

		public static void RemoveAt<T>(ref T[] array, int index)
		{
			if (array.Length == 0)
			{
				return;
			}
			T[] array2 = new T[array.Length - 1];
			for (int i = 0; i < array.Length; i++)
			{
				if (i < index)
				{
					array2[i] = array[i];
				}
				else if (i > index)
				{
					array2[i - 1] = array[i];
				}
			}
			array = array2;
		}

		public static void ForEach<T>(this T[] source, Action<T> onLoop)
		{
			foreach (T obj in source)
			{
				onLoop(obj);
			}
		}

		public static void SetLength<T>(ref T[] source, int newCount)
		{
			T[] array = new T[newCount];
			for (int i = 0; i < Mathf.Min(newCount, source.Length); i++)
			{
				array[i] = source[i];
			}
			source = array;
		}

		public static void ShiftLeft<T>(this T[] source, int startIndex = 0, bool loop = true)
		{
			T val = source[startIndex];
			for (int i = startIndex; i < source.Length - 1; i++)
			{
				source[i] = source[i + 1];
			}
			source[^1] = (loop ? val : default(T));
		}

		public static void ShiftRight<T>(this T[] source, int startIndex = 0, bool loop = true)
		{
			T val = source[^1];
			for (int i = startIndex + 1; i < source.Length; i++)
			{
				source[i] = source[i - 1];
			}
			source[startIndex] = (loop ? val : default(T));
		}

		public static TArray[] QuickSort<TArray, T>(this TArray[] array, Func<TArray, T> getProperty, int leftIndex, int rightIndex) where T : IComparable
		{
			int i = leftIndex;
			int num = rightIndex;
			T val = getProperty(array[leftIndex]);
			while (i <= num)
			{
				for (; getProperty(array[i]).CompareTo(val) == -1; i++)
				{
				}
				while (getProperty(array[num]).CompareTo(val) == 1)
				{
					num--;
				}
				if (i <= num)
				{
					TArray val2 = array[i];
					array[i] = array[num];
					array[num] = val2;
					i++;
					num--;
				}
			}
			if (leftIndex < num)
			{
				array.QuickSort(getProperty, leftIndex, num);
			}
			if (i < rightIndex)
			{
				array.QuickSort(getProperty, i, rightIndex);
			}
			return array;
		}
	}
}
