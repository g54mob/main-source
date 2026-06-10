using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NSEipix
{
	public static class StringExtension
	{
		public static string ToUnderscoreCase(this string str)
		{
			return Regex.Replace(str, "(?<=[a-z0-9])[A-Z]", (Match m) => "_" + m.Value).ToLowerInvariant();
		}

		public static string ToCamelCase(this string str)
		{
			return (from s in str.Split(new string[1] { "_" }, StringSplitOptions.RemoveEmptyEntries)
				select char.ToUpperInvariant(s[0]) + s.Substring(1, s.Length - 1)).Aggregate(string.Empty, (string s1, string s2) => s1 + s2);
		}

		public static string CapitalizeFirst(this string str)
		{
			if (str.Length == 0)
			{
				return string.Empty;
			}
			if (str.Length == 1)
			{
				return $"{char.ToUpper(str[0])}";
			}
			return $"{char.ToUpper(str[0])}{str.Substring(1)}";
		}

		public static string[] SplitAtFirstUppercase(this string str)
		{
			str = str.CapitalizeFirst();
			string text = string.Empty;
			string empty = string.Empty;
			string text2 = str;
			for (int i = 0; i < text2.Length; i++)
			{
				char c = text2[i];
				if (char.IsUpper(c))
				{
					if (text != string.Empty)
					{
						empty = str.Substring(text.Length).ToLower().CapitalizeFirst();
						return new string[2] { text, empty };
					}
					text = c.ToString();
				}
				else
				{
					text += c;
				}
			}
			return new string[2] { text, empty };
		}

		public static bool TryParseEnumNameOrInt<T>(this string stringValue, out T parsedEnumValue) where T : Enum
		{
			if (Enum.TryParse(typeof(T), stringValue, out var result))
			{
				parsedEnumValue = (T)result;
				return true;
			}
			if (int.TryParse(stringValue, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result2))
			{
				parsedEnumValue = (T)(object)result2;
				return true;
			}
			parsedEnumValue = default(T);
			return false;
		}

		public static string AddSpacesToCamelCase(string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return input;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(input[0]);
			for (int i = 1; i < input.Length; i++)
			{
				if (char.IsUpper(input[i]) && !char.IsWhiteSpace(input[i - 1]))
				{
					stringBuilder.Append(' ');
				}
				stringBuilder.Append(input[i]);
			}
			return stringBuilder.ToString();
		}

		public static string RemoveNewLines(this string str)
		{
			if (string.IsNullOrEmpty(str))
			{
				return str;
			}
			return Regex.Replace(Regex.Replace(str, "<indent=.*?>", ""), "</?indent.*?>", "").Replace("\n\n", " ").Replace("\r\n", " ")
				.Replace("\n\r", " ")
				.Replace("\n", " ")
				.Replace("\r", " ")
				.Replace("  ", " ")
				.Trim();
		}

		public static string TruncateAtLenght(this string str, int maxLength)
		{
			if (string.IsNullOrEmpty(str) || str.Length <= maxLength)
			{
				return str;
			}
			string text = str.Substring(0, maxLength);
			int num = text.LastIndexOf(' ');
			if (num > 0)
			{
				text = text.Substring(0, num);
			}
			return text + "...";
		}

		public static int GetHashCodeDeterministic(this string str)
		{
			int num = -2128831035;
			foreach (char c in str)
			{
				num ^= c;
				num *= 16777619;
			}
			return num;
		}
	}
}
