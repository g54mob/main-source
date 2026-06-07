using System.Collections.Generic;

namespace ZLinq.Internal
{
	internal static class EnumerableExtensions
	{
		internal static bool TryGetNonEnumeratedCount<T>(this IEnumerable<T> source, out int count) where T : notnull
		{
			count = default(int);
			return false;
		}
	}
}
