using System;

namespace Jundroo.Common.Extensions
{
	public static class ArrayExtensions
	{
		public static T[] Fill<T>(this T[] array) where T : new()
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new T();
			}
			return array;
		}

		public static T[] Fill<T>(this T[] array, T value, int startIndex = 0)
		{
			Array.Fill(array, value, startIndex, array.Length);
			return array;
		}

		public static T[] Fill<T>(this T[] array, Func<T> value, int startIndex = 0)
		{
			for (int i = startIndex; i < array.Length; i++)
			{
				array[i] = value();
			}
			return array;
		}

		public static T[] Fill<T>(this T[] array, Func<int, T> value, int startIndex = 0)
		{
			for (int i = startIndex; i < array.Length; i++)
			{
				array[i] = value(i);
			}
			return array;
		}
	}
}
