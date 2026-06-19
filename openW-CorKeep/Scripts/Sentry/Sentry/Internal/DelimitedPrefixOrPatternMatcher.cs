using System;
using System.Text.RegularExpressions;

namespace Sentry.Internal
{
	internal class DelimitedPrefixOrPatternMatcher : IStringOrRegexMatcher
	{
		public DelimitedPrefixOrPatternMatcher(char delimiter = '.', StringComparison comparison = StringComparison.OrdinalIgnoreCase)
		{
			_003Cdelimiter_003EP = delimiter;
			_003Ccomparison_003EP = comparison;
			base._002Ector();
		}

		public bool IsMatch(StringOrRegex stringOrRegex, string value)
		{
			if (stringOrRegex._prefix != null)
			{
				if (stringOrRegex._prefix != null && value.StartsWith(stringOrRegex._prefix, _003Ccomparison_003EP) && value.Length > stringOrRegex._prefix.Length)
				{
					return value[stringOrRegex._prefix.Length] == _003Cdelimiter_003EP;
				}
				return false;
			}
			if (stringOrRegex._regex != null)
			{
				foreach (Match item in stringOrRegex._regex.Matches(value))
				{
					if (value.Length > item.Value.Length && value[item.Value.Length] == _003Cdelimiter_003EP)
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
