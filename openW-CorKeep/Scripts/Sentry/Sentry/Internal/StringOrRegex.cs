using System.Text.RegularExpressions;

namespace Sentry.Internal
{
	internal class StringOrRegex
	{
		internal readonly Regex? _regex;

		internal readonly string? _prefix;

		public StringOrRegex(string stringOrRegex)
		{
			_prefix = stringOrRegex;
		}

		public StringOrRegex(Regex regex)
		{
			_regex = regex;
		}

		public static implicit operator StringOrRegex(string stringOrRegex)
		{
			return new StringOrRegex(stringOrRegex);
		}

		public static implicit operator StringOrRegex(Regex regex)
		{
			return new StringOrRegex(regex);
		}

		public override string ToString()
		{
			return _prefix ?? _regex?.ToString() ?? "";
		}

		public override bool Equals(object? obj)
		{
			if (obj is StringOrRegex stringOrRegex)
			{
				return stringOrRegex.ToString() == ToString();
			}
			return false;
		}

		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}
	}
}
