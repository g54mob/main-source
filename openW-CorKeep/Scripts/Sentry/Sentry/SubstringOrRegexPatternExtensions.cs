using System.Collections.Generic;
using System.Linq;
using Sentry.Internal;

namespace Sentry
{
	internal static class SubstringOrRegexPatternExtensions
	{
		public static bool ContainsMatch(this IEnumerable<SubstringOrRegexPattern> targets, string str)
		{
			return targets.Any((SubstringOrRegexPattern t) => t.IsMatch(str));
		}

		public static IList<T> WithConfigBinding<T>(this IList<T> value) where T : SubstringOrRegexPattern
		{
			int count = value.Count;
			if (count <= 1)
			{
				if (count == 1 && value[0].ToString() == ".*")
				{
					return new AutoClearingList<T>(value, clearOnNextAdd: true);
				}
				return value;
			}
			List<T> list = value.ToList();
			list.RemoveAll((T t) => t.ToString() == ".*");
			return list;
		}
	}
}
