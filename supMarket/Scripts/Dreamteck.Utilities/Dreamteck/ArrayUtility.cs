using System;

namespace Dreamteck
{
	public static class ArrayUtility
	{
		public static void Add<T>(ref T[] array, T item)
		{
		}

		public static bool Contains<T>(T[] array, T item)
		{
			return false;
		}

		public static int IndexOf<T>(T[] array, T value)
		{
			return 0;
		}

		public static void Insert<T>(ref T[] array, int index, T item)
		{
		}

		public static void RemoveAt<T>(ref T[] array, int index)
		{
		}

		public static void ForEach<T>(this T[] source, Action<T> onLoop)
		{
		}

		public static void SetLength<T>(ref T[] source, int newCount)
		{
		}

		public static void ShiftLeft<T>(this T[] source, int startIndex = 0, bool loop = true)
		{
		}

		public static void ShiftRight<T>(this T[] source, int startIndex = 0, bool loop = true)
		{
		}

		public static TArray[] QuickSort<TArray, T>(this TArray[] array, Func<TArray, T> getProperty, int leftIndex, int rightIndex)
		{
			return null;
		}
	}
}
