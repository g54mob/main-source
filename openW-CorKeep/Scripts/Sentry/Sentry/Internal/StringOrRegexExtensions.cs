using System.Collections.Generic;

namespace Sentry.Internal
{
	internal static class StringOrRegexExtensions
	{
		public static bool MatchesAny(this string parameter, List<StringOrRegex>? patterns, IStringOrRegexMatcher matcher)
		{
			if (patterns == null)
			{
				return false;
			}
			foreach (StringOrRegex pattern in patterns)
			{
				if (matcher.IsMatch(pattern, parameter))
				{
					return true;
				}
			}
			return false;
		}
	}
}
