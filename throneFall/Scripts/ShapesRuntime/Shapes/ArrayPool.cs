using System.Collections.Generic;

namespace Shapes
{
	internal static class ArrayPool<T>
	{
		private static readonly Stack<T[]> pool = new Stack<T[]>();

		public static T[] Alloc(int maxCount)
		{
			if (pool.Count != 0)
			{
				return pool.Pop();
			}
			return new T[maxCount];
		}

		public static void Free(T[] obj)
		{
			pool.Push(obj);
		}
	}
}
