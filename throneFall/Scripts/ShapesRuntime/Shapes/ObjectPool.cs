using System.Collections.Generic;

namespace Shapes
{
	internal static class ObjectPool<T> where T : new()
	{
		private static readonly Stack<T> pool = new Stack<T>();

		public static T Alloc()
		{
			if (pool.Count != 0)
			{
				return pool.Pop();
			}
			return new T();
		}

		public static void Free(T obj)
		{
			pool.Push(obj);
		}
	}
}
