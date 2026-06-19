using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Sentry
{
	[TypeConverter(typeof(SubstringOrRegexPatternTypeConverter))]
	public class SubstringOrRegexPattern
	{
		private readonly Regex? _regex;

		private readonly string? _substring;

		private readonly StringComparison _stringComparison;

		internal Regex? Regex => _regex;

		public SubstringOrRegexPattern(string substringOrRegexPattern, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
		{
			_substring = substringOrRegexPattern;
			_stringComparison = comparison;
			_regex = TryParseRegex(substringOrRegexPattern, comparison);
		}

		public SubstringOrRegexPattern(Regex regex)
		{
			_regex = regex;
		}

		public static implicit operator SubstringOrRegexPattern(string substringOrRegexPattern)
		{
			return new SubstringOrRegexPattern(substringOrRegexPattern);
		}

		public static implicit operator SubstringOrRegexPattern(Regex regex)
		{
			return new SubstringOrRegexPattern(regex);
		}

		public override string ToString()
		{
			return _substring ?? _regex?.ToString() ?? "";
		}

		public override bool Equals(object? obj)
		{
			if (obj is SubstringOrRegexPattern substringOrRegexPattern)
			{
				return substringOrRegexPattern.ToString() == ToString();
			}
			return false;
		}

		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		internal bool IsMatch(string str)
		{
			if (!(_substring == ".*") && (_substring == null || !PolyfillExtensions.Contains(str, _substring, _stringComparison)))
			{
				return _regex?.IsMatch(str) ?? false;
			}
			return true;
		}

		private static Regex? TryParseRegex(string pattern, StringComparison comparison)
		{
			try
			{
				RegexOptions regexOptions = RegexOptions.Compiled;
				if ((uint)(comparison - 2) <= 3u)
				{
					regexOptions |= RegexOptions.CultureInvariant;
				}
				bool flag;
				switch (comparison)
				{
				case StringComparison.CurrentCultureIgnoreCase:
				case StringComparison.InvariantCultureIgnoreCase:
				case StringComparison.OrdinalIgnoreCase:
					flag = true;
					break;
				default:
					flag = false;
					break;
				}
				if (flag)
				{
					regexOptions |= RegexOptions.IgnoreCase;
				}
				return new Regex(pattern, regexOptions);
			}
			catch
			{
				return null;
			}
		}
	}
}
