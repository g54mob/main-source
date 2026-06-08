using System.Collections.Generic;
using System.Linq;

namespace Bindito.Core.Internal
{
	public static class EnumerableExtensions
	{
		public static IEnumerable<T> AsReadOnlyEnumerable<T>(this IEnumerable<T> source)
		{
			return source.Select((T x) => x);
		}
	}
}
