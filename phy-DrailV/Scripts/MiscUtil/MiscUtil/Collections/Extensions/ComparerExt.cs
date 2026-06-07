using System;
using System.Collections.Generic;

namespace MiscUtil.Collections.Extensions
{
	public static class ComparerExt
	{
		public static IComparer<T> Reverse<T>(this IComparer<T> original)
		{
			if (original is ReverseComparer<T> reverseComparer)
			{
				return reverseComparer.OriginalComparer;
			}
			return new ReverseComparer<T>(original);
		}

		public static IComparer<T> ThenBy<T>(this IComparer<T> firstComparer, IComparer<T> secondComparer)
		{
			return new LinkedComparer<T>(firstComparer, secondComparer);
		}

		public static IComparer<T> ThenBy<T, TKey>(this IComparer<T> firstComparer, Func<T, TKey> projection)
		{
			return new LinkedComparer<T>(firstComparer, new ProjectionComparer<T, TKey>(projection));
		}
	}
}
