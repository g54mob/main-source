using System.Collections.Generic;

namespace Pathfinding.Util
{
	public static class StackPool<T>
	{
		private static readonly List<Stack<T>> pool;

		static StackPool()
		{
		}

		public static Stack<T> Claim()
		{
			return null;
		}

		public static void Warmup(int count)
		{
		}

		public static void Release(Stack<T> stack)
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
