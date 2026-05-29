using System.Collections.Generic;

namespace Pathfinding.Util
{
	public static class ArrayPool<T>
	{
		private const int MaximumExactArrayLength = 256;

		private static readonly Stack<T[]>[] pool;

		private static readonly Stack<T[]>[] exactPool;

		public static T[] Claim(int minimumLength)
		{
			return null;
		}

		public static T[] ClaimWithExactLength(int length)
		{
			return null;
		}

		public static void Release(ref T[] array, bool allowNonPowerOfTwo = false)
		{
		}
	}
}
