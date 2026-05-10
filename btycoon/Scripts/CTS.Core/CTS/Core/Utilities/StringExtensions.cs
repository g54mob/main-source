using System;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

namespace CTS.Core.Utilities
{
	public static class StringExtensions
	{
		public static string WrapInColor(this string message, Color color)
		{
			return "<color=#" + ColorUtility.ToHtmlStringRGB(color) + ">" + message + "</color>";
		}

		public static string ToCamelCase(this string p_string)
		{
			string[] array = p_string.Split(new string[3] { "_", " ", "/" }, StringSplitOptions.RemoveEmptyEntries);
			string text = array[0].ToLower();
			string[] value = (from word in array.Skip(1)
				select char.ToUpper(word[0]) + word.Substring(1, word.Length - 1)).ToArray();
			return text + string.Join(string.Empty, value);
		}

		public static string ToPascalCase(this string p_string)
		{
			string[] source = p_string.Split(new string[3] { "_", " ", "/" }, StringSplitOptions.RemoveEmptyEntries);
			source = source.Select((string word) => char.ToUpper(word[0]) + word.Substring(1, word.Length - 1).ToLower()).ToArray();
			return string.Concat(string.Join(string.Empty, source));
		}

		public static string ToBackingField(this string value)
		{
			return "<" + value + ">k__BackingField";
		}

		public static string Repeat(this string p_string, int p_count)
		{
			return string.Concat(Enumerable.Repeat(p_string, p_count));
		}

		public static string ConcatRepeated(this string p_string, string p_message, int p_count)
		{
			return p_string + p_message.Repeat(p_count);
		}

		public static string GetSubstringAfterLast(this string text, char character)
		{
			int num = text.LastIndexOf(character);
			if (num != -1)
			{
				return text.Substring(num + 1, text.Length - num - 1);
			}
			return text;
		}

		public static string GetSubstringBeforeLast(this string text, char character)
		{
			int num = text.LastIndexOf(character);
			if (num != -1)
			{
				return text.Substring(0, num);
			}
			return text;
		}

		public static string GetSubstringBefore(this string text, char character)
		{
			int num = text.IndexOf(character);
			if (num != -1)
			{
				return text.Substring(0, num);
			}
			return text;
		}

		public static string GetSubstringAfter(this string text, char character)
		{
			int num = text.IndexOf(character);
			if (num != -1)
			{
				return text.Substring(num + 1, text.Length - num - 1);
			}
			return text;
		}

		public static int CountChars(this string text, char character)
		{
			int num = 0;
			int length = text.Length;
			for (int i = 0; i < length; i++)
			{
				if (text[i] == character)
				{
					num++;
				}
			}
			return num;
		}

		public static string StripGenericSuffix(this string typeName)
		{
			int num = typeName.IndexOf('`');
			if (num != -1)
			{
				return typeName.Substring(0, num);
			}
			return typeName;
		}

		public static string AddSpacesBeforeCapitals(this string text)
		{
			return Regex.Replace(text, "((?<=\\p{Ll})\\p{Lu})|((?!\\A)\\p{Lu}(?>\\p{Ll}))", " $0");
		}
	}
}
