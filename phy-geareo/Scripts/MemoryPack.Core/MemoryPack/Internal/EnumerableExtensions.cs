using System.Collections.Generic;

namespace MemoryPack.Internal
{
	internal static class EnumerableExtensions
	{
		public static bool TryGetNonEnumeratedCountEx<T>(this IEnumerable<T> value, out int count) where T : notnull
		{
			count = default(int);
			return false;
		}
	}
}
