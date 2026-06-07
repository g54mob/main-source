using System;
using System.Collections.Generic;

namespace MG_BlocksEngine2.Utils
{
	public static class BE2_ArrayUtils
	{
		public static void Resize<T>(ref T[] array, int size)
		{
			T[] array2 = array;
			array = new T[size];
			for (int i = 0; i < array2.Length; i++)
			{
				if (size > i)
				{
					array[i] = array2[i];
				}
			}
		}

		public static void Add<T>(ref T[] array, T value)
		{
			int num = array.Length;
			Resize(ref array, num + 1);
			array[num] = value;
		}

		public static T[] AddReturn<T>(T[] array, T value)
		{
			int num = array.Length;
			T[] array2 = array;
			Resize(ref array2, num + 1);
			array2[num] = value;
			return array2;
		}

		public static void Remove<T>(ref T[] array, T value)
		{
			List<T> list = new List<T>();
			list.AddRange(array);
			list.Remove(value);
			array = list.ToArray();
		}

		public static T[] FindAll<T>(ref T[] array, Predicate<T> match)
		{
			return Array.FindAll(array, match);
		}

		public static T Find<T>(ref T[] array, Predicate<T> match)
		{
			return Array.Find(array, match);
		}
	}
}
