using System;
using System.Collections.Generic;
using System.Globalization;

namespace MathNet.Numerics
{
	internal static class GlobalizationHelper
	{
		internal static CultureInfo GetCultureInfo(this IFormatProvider formatProvider)
		{
			if (formatProvider == null)
			{
				return CultureInfo.CurrentCulture;
			}
			return (formatProvider as CultureInfo) ?? (formatProvider.GetFormat(typeof(CultureInfo)) as CultureInfo) ?? CultureInfo.CurrentCulture;
		}

		internal static NumberFormatInfo GetNumberFormatInfo(this IFormatProvider formatProvider)
		{
			return NumberFormatInfo.GetInstance(formatProvider);
		}

		internal static TextInfo GetTextInfo(this IFormatProvider formatProvider)
		{
			if (formatProvider == null)
			{
				return CultureInfo.CurrentCulture.TextInfo;
			}
			return (formatProvider.GetFormat(typeof(TextInfo)) as TextInfo) ?? formatProvider.GetCultureInfo().TextInfo;
		}

		internal static void Tokenize(LinkedListNode<string> node, string[] keywords, int skip)
		{
			for (int i = skip; i < keywords.Length; i++)
			{
				string text = keywords[i];
				int num;
				while ((num = node.Value.IndexOf(text, StringComparison.Ordinal)) >= 0)
				{
					if (num != 0)
					{
						string value = node.Value.Substring(0, num).Trim();
						Tokenize(node.List.AddBefore(node, value), keywords, i + 1);
						node.Value = node.Value.Substring(num);
					}
					if (text.Length == node.Value.Length)
					{
						return;
					}
					string value2 = node.Value.Substring(text.Length).Trim();
					node.List.AddBefore(node, text);
					node.Value = value2;
				}
			}
		}

		internal static double ParseDouble(ref LinkedListNode<string> token, CultureInfo culture)
		{
			if (token.Value.EndsWith("e", ignoreCase: true, culture))
			{
				if (token.Next == null || token.Next.Next == null)
				{
					throw new FormatException();
				}
				token.Value = token.Value + token.Next.Value + token.Next.Next.Value;
				LinkedList<string> list = token.List;
				list.Remove(token.Next.Next);
				list.Remove(token.Next);
			}
			if (!double.TryParse(token.Value, NumberStyles.Any, culture, out var result))
			{
				throw new FormatException();
			}
			token = token.Next;
			return result;
		}

		internal static float ParseSingle(ref LinkedListNode<string> token, CultureInfo culture)
		{
			if (token.Value.EndsWith("e", ignoreCase: true, culture))
			{
				if (token.Next == null || token.Next.Next == null)
				{
					throw new FormatException();
				}
				token.Value = token.Value + token.Next.Value + token.Next.Next.Value;
				LinkedList<string> list = token.List;
				list.Remove(token.Next.Next);
				list.Remove(token.Next);
			}
			if (!float.TryParse(token.Value, NumberStyles.Any, culture, out var result))
			{
				throw new FormatException();
			}
			token = token.Next;
			return result;
		}
	}
}
