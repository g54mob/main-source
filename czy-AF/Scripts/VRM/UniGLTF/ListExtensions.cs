using System;
using System.Collections.Generic;
using System.Linq;

namespace UniGLTF
{
	public static class ListExtensions
	{
		public static void Assign<T>(this List<T> dst, T[] src, Func<T, T> pred)
		{
			dst.Capacity = src.Length;
			dst.AddRange(src.Select(pred));
		}
	}
}
