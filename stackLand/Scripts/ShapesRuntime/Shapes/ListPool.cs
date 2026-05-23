using System.Collections.Generic;

namespace Shapes
{
	internal static class ListPool<T> where T : new()
	{
		private static readonly Stack<List<T>> pool = new Stack<List<T>>();

		public static List<T> Alloc()
		{
			if (pool.Count != 0)
			{
				return pool.Pop();
			}
			return new List<T>();
		}

		public static void Free(List<T> list)
		{
			list.Clear();
			pool.Push(list);
		}
	}
}
