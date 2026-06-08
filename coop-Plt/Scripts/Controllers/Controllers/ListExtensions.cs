using System.Collections.Generic;

namespace Controllers
{
	public static class ListExtensions
	{
		public static List<T> CopyTo<T>(this List<T> source, List<T> dest, bool reverse = false)
		{
			dest.Clear();
			for (int i = 0; i < source.Count; i++)
			{
				T item = source[reverse ? (source.Count - 1 - i) : i];
				dest.Add(item);
			}
			return dest;
		}
	}
}
