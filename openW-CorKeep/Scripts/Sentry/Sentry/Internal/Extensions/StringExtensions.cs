using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Sentry.Internal.Extensions
{
	internal static class StringExtensions
	{
		public static string ToSnakeCase(this string str)
		{
			return Regex.Replace(str, "(\\p{Ll})(\\p{Lu})", "$1_$2").ToLowerInvariant();
		}

		public static string? NullIfWhitespace(this string? str)
		{
			if (!string.IsNullOrWhiteSpace(str))
			{
				return str;
			}
			return null;
		}

		public static long ParseHexAsLong(this string str)
		{
			long result;
			if (str.StartsWith("0x"))
			{
				if (long.TryParse(str.Substring(2, str.Length - 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out result))
				{
					return result;
				}
			}
			if (long.TryParse(str, NumberStyles.Number, CultureInfo.InvariantCulture, out result))
			{
				return result;
			}
			throw new FormatException("ParseHexAsLong() cannot parse '" + str + "'");
		}
	}
}
