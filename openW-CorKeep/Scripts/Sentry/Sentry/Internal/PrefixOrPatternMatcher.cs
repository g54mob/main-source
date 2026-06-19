using System;

namespace Sentry.Internal
{
	internal class PrefixOrPatternMatcher : IStringOrRegexMatcher
	{
		public PrefixOrPatternMatcher(StringComparison comparison = StringComparison.OrdinalIgnoreCase)
		{
			_003Ccomparison_003EP = comparison;
			base._002Ector();
		}

		public bool IsMatch(StringOrRegex stringOrRegex, string value)
		{
			if (stringOrRegex._prefix == null || !value.StartsWith(stringOrRegex._prefix, _003Ccomparison_003EP))
			{
				if (stringOrRegex == null)
				{
					return false;
				}
				return stringOrRegex._regex?.IsMatch(value) == true;
			}
			return true;
		}
	}
}
