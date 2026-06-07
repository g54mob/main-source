using System;
using System.Threading;

namespace ZLinq.Internal
{
	internal static class RandomShared
	{
		private static ThreadLocal<Random> Shared;

		public static void Shuffle<T>(Span<T> span)
		{
		}

		public static void PartialShuffle<T>(Span<T> span, int count)
		{
		}

		private static void Shuffle<T>(this Random random, Span<T> values) where T : notnull
		{
		}

		private static void PartialShuffle<T>(this Random random, Span<T> values, int count) where T : notnull
		{
		}
	}
}
