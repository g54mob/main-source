using System.Collections.Generic;
using System.Linq;

namespace Helpers.Extensions
{
	public static class HashSetExtensions
	{
		public static HashSet<TValue> Clone<TValue>(this HashSet<TValue> source)
		{
			return source.ToHashSet();
		}
	}
}
