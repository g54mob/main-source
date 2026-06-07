using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace NJsonSchema
{
	public class ConversionUtilities
	{
		private static readonly char[] _whiteSpaceChars = new char[4] { '\n', '\r', '\t', ' ' };

		private static readonly char[] _lineBreakTrimChars = new char[3] { '\n', '\t', ' ' };

		public static string ConvertToLowerCamelCase(string input, bool firstCharacterMustBeAlpha)
		{
			if (string.IsNullOrEmpty(input))
			{
				return string.Empty;
			}
			input = ConvertDashesToCamelCase((input[0].ToString().ToLowerInvariant() + ((input.Length > 1) ? input.Substring(1) : "")).Replace(" ", "_").Replace("/", "_"));
			if (string.IsNullOrEmpty(input))
			{
				return string.Empty;
			}
			if (firstCharacterMustBeAlpha && char.IsNumber(input[0]))
			{
				return "_" + input;
			}
			return input;
		}

		public static string ConvertToUpperCamelCase(string input, bool firstCharacterMustBeAlpha)
		{
			if (string.IsNullOrEmpty(input))
			{
				return string.Empty;
			}
			input = ConvertDashesToCamelCase(Capitalize(input).Replace(" ", "_").Replace("/", "_"));
			if (firstCharacterMustBeAlpha && char.IsNumber(input[0]))
			{
				return "_" + input;
			}
			return input;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static string Capitalize(string input)
		{
			if (char.IsUpper(input[0]))
			{
				return input;
			}
			if (input.Length == 1)
			{
				return char.ToUpperInvariant(input[0]).ToString();
			}
			return char.ToUpperInvariant(input[0]) + input.Substring(1);
		}

		public static string ConvertToStringLiteral(string input)
		{
			StringBuilder stringBuilder = new StringBuilder(input.Length);
			foreach (char c in input)
			{
				switch (c)
				{
				case '\'':
					stringBuilder.Append("\\'");
					continue;
				case '"':
					stringBuilder.Append("\\\"");
					continue;
				case '\\':
					stringBuilder.Append("\\\\");
					continue;
				case '\0':
					stringBuilder.Append("\\0");
					continue;
				case '\a':
					stringBuilder.Append("\\a");
					continue;
				case '\b':
					stringBuilder.Append("\\b");
					continue;
				case '\f':
					stringBuilder.Append("\\f");
					continue;
				case '\n':
					stringBuilder.Append("\\n");
					continue;
				case '\r':
					stringBuilder.Append("\\r");
					continue;
				case '\t':
					stringBuilder.Append("\\t");
					continue;
				case '\v':
					stringBuilder.Append("\\v");
					continue;
				}
				if (c >= ' ' && c <= '~')
				{
					stringBuilder.Append(c);
					continue;
				}
				stringBuilder.Append("\\u");
				int num = c;
				stringBuilder.Append(num.ToString("x4"));
			}
			return stringBuilder.ToString();
		}

		public static string ConvertToCamelCase(string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return string.Empty;
			}
			return ConvertDashesToCamelCase(input.Replace(" ", "_").Replace("/", "_"));
		}

		public static string TrimWhiteSpaces(string text)
		{
			return text?.Trim(_whiteSpaceChars);
		}

		public static string RemoveLineBreaks(string text)
		{
			return text?.Replace("\r", "").Replace("\n", " \n").Replace("\n ", "\n")
				.Replace("  \n", " \n")
				.Replace("\n", "")
				.Trim(_lineBreakTrimChars);
		}

		public static string Singularize(string word)
		{
			if (word == "people")
			{
				return "Person";
			}
			if (!word.EndsWith("s"))
			{
				return word;
			}
			return word.Substring(0, word.Length - 1);
		}

		public static string Tab(string input, int tabCount)
		{
			if (input == null)
			{
				return "";
			}
			StringWriter stringWriter = new StringWriter(new StringBuilder(input.Length), CultureInfo.CurrentCulture);
			Tab(input, tabCount, stringWriter);
			return stringWriter.ToString();
		}

		public static void Tab(string input, int tabCount, TextWriter writer)
		{
			string tabString = CreateTabString(tabCount);
			AddPrefixToBeginningOfNonEmptyLines(input, tabString, writer);
		}

		private static void AddPrefixToBeginningOfNonEmptyLines(string input, string tabString, TextWriter writer)
		{
			if (tabString.Length == 0)
			{
				return;
			}
			for (int i = 0; i < input.Length; i++)
			{
				char c = input[i];
				writer.Write(c);
				if (c != '\n')
				{
					continue;
				}
				bool flag = false;
				for (int j = i + 1; j < input.Length; j++)
				{
					char c2 = input[j];
					if (c2 == '\n')
					{
						break;
					}
					if (!char.IsWhiteSpace(c2))
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					writer.Write(tabString);
				}
			}
		}

		public static string ConvertCSharpDocs(string input, int tabCount)
		{
			input = input?.Replace("\r", string.Empty).Replace("\n", "\n" + string.Join("", Enumerable.Repeat("    ", tabCount)) + "/// ") ?? string.Empty;
			string input2 = new XText(input).ToString();
			return Regex.Replace(input2, "^( *)/// ", (Match m) => m.Groups[1]?.ToString() + "/// <br/>", RegexOptions.Multiline);
		}

		private static string CreateTabString(int tabCount)
		{
			return tabCount switch
			{
				0 => "", 
				1 => "    ", 
				2 => "        ", 
				_ => new string(' ', 4 * tabCount), 
			};
		}

		private static string ConvertDashesToCamelCase(string input)
		{
			if (input.IndexOf('-') == -1)
			{
				return input;
			}
			StringBuilder stringBuilder = new StringBuilder(input.Length - 1);
			bool flag = false;
			foreach (char c in input)
			{
				if (c == '-')
				{
					flag = true;
				}
				else if (flag)
				{
					stringBuilder.Append(char.ToUpperInvariant(c));
					flag = false;
				}
				else
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}
	}
}
