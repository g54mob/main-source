using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Nimbatus.Scripts.Common.Helpers
{
	public static class ListHelper
	{
		public static IEnumerable<T[]> Chunk<T>(this IEnumerable<T> items, int size)
		{
			T[] array = (items as T[]) ?? items.ToArray();
			for (int i = 0; i < array.Length; i += size)
			{
				T[] array2 = new T[Math.Min(size, array.Length - i)];
				Array.Copy(array, i, array2, 0, array2.Length);
				yield return array2;
			}
		}

		public static int RandomInt(this Random random)
		{
			return random.Next(int.MinValue, int.MaxValue);
		}
	}
}
