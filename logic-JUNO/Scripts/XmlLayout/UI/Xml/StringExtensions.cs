using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace UI.Xml
{
	public static class StringExtensions
	{
		public static string StripChars(this string s, params char[] chars)
		{
			if (string.IsNullOrEmpty(s) || chars.Length == 0)
			{
				return s;
			}
			return string.Join(string.Empty, s.Split(chars));
		}

		public static string SplitByCapitals(this string s)
		{
			if (string.IsNullOrEmpty(s))
			{
				s = string.Empty;
			}
			return new Regex("\r\n                (?<=[A-Z])(?=[A-Z][a-z]) |\r\n                 (?<=[^A-Z])(?=[A-Z]) |\r\n                 (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace).Replace(s, " ");
		}

		public static string ToTitleCase(this string s)
		{
			return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());
		}

		public static bool EndsWithAny(this string name, string[] endings)
		{
			return endings.Any((string x) => name.EndsWith(x));
		}

		public static string DecodeEncodedNonAsciiCharacters(string value)
		{
			if (value == null)
			{
				return null;
			}
			return Regex.Replace(value, "\\\\u(?<Value>[a-zA-Z0-9]{4})", (Match m) => ((char)int.Parse(m.Groups["Value"].Value, NumberStyles.HexNumber)).ToString());
		}
	}
}
