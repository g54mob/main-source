using System.Collections.Generic;

namespace Pathfinding.Util
{
	public static class ListPool<T>
	{
		private static readonly List<List<T>> pool;

		private static readonly List<List<T>> largePool;

		private static readonly HashSet<List<T>> inPool;

		private const int MaxCapacitySearchLength = 8;

		private const int LargeThreshold = 5000;

		private const int MaxLargePoolSize = 8;

		public static List<T> Claim()
		{
			return null;
		}

		private static int FindCandidate(List<List<T>> pool, int capacity)
		{
			return 0;
		}

		public static List<T> Claim(int capacity)
		{
			return null;
		}

		public static void Warmup(int count, int size)
		{
		}

		public static void Release(ref List<T> list)
		{
		}

		public static void Release(List<T> list)
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
