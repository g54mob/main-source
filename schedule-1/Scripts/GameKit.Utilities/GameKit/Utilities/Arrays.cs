using System;
using System.Collections.Generic;

namespace GameKit.Utilities
{
	public static class Arrays
	{
		private static Random _random;

		public static bool AddUnique<T>(this List<T> list, T value)
		{
			return false;
		}

		public static bool FastReferenceRemove<T>(this List<T> list, object value)
		{
			return false;
		}

		public static void FastIndexRemove<T>(this List<T> list, int index)
		{
		}

		public static void Shuffle<T>(this T[] array)
		{
		}

		public static void Shuffle<T>(this List<T> lst)
		{
		}
	}
}
