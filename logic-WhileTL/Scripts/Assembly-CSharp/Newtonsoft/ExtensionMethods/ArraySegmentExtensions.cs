using System;
using System.Collections.Generic;
using System.Linq;

namespace Newtonsoft.ExtensionMethods
{
	public static class ArraySegmentExtensions
	{
		public static ArraySegment<T> GetSegment<T>(this T[] array, int from, int count)
		{
			return new ArraySegment<T>(array, from, count);
		}

		public static ArraySegment<T> GetSegment<T>(this T[] array, int from)
		{
			return array.GetSegment(from, array.Length - from);
		}

		public static ArraySegment<T> GetSegment<T>(this T[] array)
		{
			return new ArraySegment<T>(array);
		}

		public static IEnumerable<T> AsEnumerable<T>(this ArraySegment<T> arraySegment)
		{
			return arraySegment.Array.Skip(arraySegment.Offset).Take(arraySegment.Count);
		}

		public static T[] ToArray<T>(this ArraySegment<T> arraySegment)
		{
			T[] array = new T[arraySegment.Count];
			Array.Copy(arraySegment.Array, arraySegment.Offset, array, 0, arraySegment.Count);
			return array;
		}

		public static void SetSegment<T>(this ArraySegment<T> arraySegment, T[] array)
		{
			for (int i = arraySegment.Offset; i - arraySegment.Offset < arraySegment.Count; i++)
			{
				arraySegment.Array[i] = array[i];
			}
		}
	}
}
