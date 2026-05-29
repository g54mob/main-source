using System.Collections.Generic;

namespace Pathfinding.Util
{
	public static class ObjectPoolSimple<T> where T : class, new()
	{
		private static List<T> pool;

		private static readonly HashSet<T> inPool;

		public static T Claim()
		{
			return null;
		}

		public static void Release(ref T obj)
		{
		}

		public static void Clear()
		{
		}

		public static int GetSize()
		{
			return 0;
		}
	}
}
