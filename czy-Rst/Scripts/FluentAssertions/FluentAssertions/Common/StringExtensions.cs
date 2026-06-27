using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;
using FluentAssertions.Formatting;

namespace FluentAssertions.Common
{
	internal static class StringExtensions
	{
		public static int IndexOfFirstMismatch(this string value, string expected, IEqualityComparer<string> comparer)
		{
			int num = 0;
			while (num < value.Length)
			{
				if (num < expected.Length)
				{
					int num2 = num;
					string x = value.Substring(num2, num + 1 - num2);
					num2 = num;
					if (comparer.Equals(x, expected.Substring(num2, num + 1 - num2)))
					{
						num++;
						continue;
					}
				}
				return num;
			}
			return -1;
		}

		public static string IndexedSegmentAt(this string value, int index)
		{
			int length = Math.Min(value.Length - index, 3);
			string arg = Formatter.ToString(value.Substring(index, length));
			return $"{arg} (index {index})".EscapePlaceholders();
		}

		public static string WithoutSpecificCollectionIndices(this string indexedPath)
		{
			return Regex.Replace(indexedPath, "\\[[0-9]+\\]", "[]");
		}

		public static bool ContainsSpecificCollectionIndex(this string indexedPath)
		{
			return Regex.IsMatch(indexedPath, "\\[[0-9]+\\]");
		}

		public static string EscapePlaceholders(this string value)
		{
			return SystemExtensions.Replace(SystemExtensions.Replace(value, "{", "{{", StringComparison.Ordinal), "}", "}}", StringComparison.Ordinal);
		}

		public static string Combine(this string @this, string other, string separator = ".")
		{
			if (@this.IsNullOrEmpty())
			{
				if (other.IsNullOrEmpty())
				{
					return string.Empty;
				}
				return other;
			}
			if (other == null || SystemExtensions.StartsWith(other, '['))
			{
				separator = string.Empty;
			}
			return @this + separator + other;
		}

		public static string Capitalize(this string @this)
		{
			if (@this.Length == 0)
			{
				return @this;
			}
			char[] array = @this.ToCharArray();
			array[0] = char.ToUpperInvariant(array[0]);
			return new string(array);
		}

		public static string IndentLines(this string @this)
		{
			return string.Join(Environment.NewLine, from x in @this.Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
				select "\t" + x);
		}

		public static string RemoveNewLines(this string @this)
		{
			return SystemExtensions.Replace(SystemExtensions.Replace(@this, "\n", string.Empty, StringComparison.Ordinal), "\r", string.Empty, StringComparison.Ordinal);
		}

		public static string RemoveNewlineStyle(this string @this)
		{
			return SystemExtensions.Replace(@this, "\r\n", "\n", StringComparison.Ordinal).Replace('\r', '\n');
		}

		public static string RemoveTrailingWhitespaceFromLines(this string input)
		{
			return Regex.Replace(input, "[ \\t]+(?=\\r?\\n)", string.Empty);
		}

		public static int CountSubstring(this string str, string substring, IEqualityComparer<string> comparer)
		{
			string text = str ?? string.Empty;
			string text2 = substring ?? string.Empty;
			int num = 0;
			int num2 = text.Length - text2.Length;
			for (int i = 0; i <= num2; i++)
			{
				int num3 = i;
				if (comparer.Equals(text.Substring(num3, i + text2.Length - num3), text2))
				{
					num++;
				}
			}
			return num;
		}

		public static bool IsLongOrMultiline(this string value)
		{
			if (value.Length <= 8)
			{
				return SystemExtensions.Contains(value, Environment.NewLine, StringComparison.Ordinal);
			}
			return true;
		}

		public static bool IsNullOrEmpty([NotNullWhen(false)] this string value)
		{
			return string.IsNullOrEmpty(value);
		}
	}
}
