using System.Collections;
using System.Collections.Generic;

namespace Libs
{
	public static class LinqUtility
	{
		public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
		{
		}

		public static void AddRange(this IList list, IEnumerable items)
		{
		}
	}
}
