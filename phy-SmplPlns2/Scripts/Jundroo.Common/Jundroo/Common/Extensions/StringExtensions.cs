using System;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Jundroo.Common.Extensions
{
	public static class StringExtensions
	{
		private static char[] _vectorParseTrimChars = new char[3] { ' ', '(', ')' };

		public static int CharacterCount(this ReadOnlySpan<char> value, char character)
		{
			int num = 0;
			ReadOnlySpan<char> readOnlySpan = value;
			for (int i = 0; i < readOnlySpan.Length; i++)
			{
				if (readOnlySpan[i] == character)
				{
					num++;
				}
			}
			return num;
		}

		public static int ParseInt(this string value, int defaultValue)
		{
			if (!int.TryParse(value, out var result))
			{
				return defaultValue;
			}
			return result;
		}

		public static int ParseInt(this string value)
		{
			if (!int.TryParse(value, out var result))
			{
				throw new ArgumentException("An integer value could not be parsed from string: " + (value ?? string.Empty));
			}
			return result;
		}

		public static Quaternion ParseQuaternion(this string value)
		{
			string[] array = value.Trim(_vectorParseTrimChars).Split(',');
			float x = DataIO.ParseFloat(array[0]);
			float y = DataIO.ParseFloat(array[1]);
			float z = DataIO.ParseFloat(array[2]);
			float w = DataIO.ParseFloat(array[3]);
			return new Quaternion(x, y, z, w);
		}

		public static Vector2 ParseVector2(this string value)
		{
			string[] array = value.Trim(_vectorParseTrimChars).Split(',');
			float x = DataIO.ParseFloat(array[0]);
			float y = DataIO.ParseFloat(array[1]);
			return new Vector2(x, y);
		}

		public static Vector3 ParseVector3(this string value)
		{
			string[] array = value.Trim(_vectorParseTrimChars).Split(',');
			float x = DataIO.ParseFloat(array[0]);
			float y = DataIO.ParseFloat(array[1]);
			float z = DataIO.ParseFloat(array[2]);
			return new Vector3(x, y, z);
		}

		public static string Replace(this string value, string oldValue)
		{
			return value.Replace(oldValue, string.Empty);
		}

		public static StringUtility.StringSplitEnumerator SpanSplit(this string value, char split, bool removeEmptyEntries = true)
		{
			return new StringUtility.StringSplitEnumerator(value.AsSpan(), split, removeEmptyEntries);
		}

		public static StringUtility.StringSplitEnumerator SpanSplit(this ReadOnlySpan<char> value, char split, bool removeEmptyEntries = true)
		{
			return new StringUtility.StringSplitEnumerator(value, split, removeEmptyEntries);
		}

		public static StringUtility.StringSplitEnumerator<T> SpanSplit<T>(this string value, char split, bool removeEmptyEntries, StringUtility.SpanSplitEntryValueDelegate<T> valueFunction)
		{
			return new StringUtility.StringSplitEnumerator<T>(value.AsSpan(), split, removeEmptyEntries, valueFunction);
		}

		public static StringUtility.StringSplitEnumerator<T> SpanSplit<T>(this ReadOnlySpan<char> value, char split, bool removeEmptyEntries, StringUtility.SpanSplitEntryValueDelegate<T> valueFunction)
		{
			return new StringUtility.StringSplitEnumerator<T>(value, split, removeEmptyEntries, valueFunction);
		}

		public static StringUtility.StringSplitEnumerator<double?> SpanSplitAsDoubles(this string value, char split, bool removeEmptyEntries = true)
		{
			return new StringUtility.StringSplitEnumerator<double?>(value.AsSpan(), split, removeEmptyEntries, StringUtility._spanSplitValueToDouble);
		}

		public static StringUtility.StringSplitEnumerator<double?> SpanSplitAsDoubles(this ReadOnlySpan<char> value, char split, bool removeEmptyEntries = true)
		{
			return new StringUtility.StringSplitEnumerator<double?>(value, split, removeEmptyEntries, StringUtility._spanSplitValueToDouble);
		}

		public static StringUtility.StringSplitEnumerator<float?> SpanSplitAsFloats(this string value, char split, bool removeEmptyEntries = true)
		{
			return new StringUtility.StringSplitEnumerator<float?>(value.AsSpan(), split, removeEmptyEntries, StringUtility._spanSplitValueToFloat);
		}

		public static StringUtility.StringSplitEnumerator<float?> SpanSplitAsFloats(this ReadOnlySpan<char> value, char split, bool removeEmptyEntries = true)
		{
			return new StringUtility.StringSplitEnumerator<float?>(value, split, removeEmptyEntries, StringUtility._spanSplitValueToFloat);
		}

		public static StringUtility.StringSplitEnumerator<int?> SpanSplitAsIntegers(this string value, char split, bool removeEmptyEntries = true)
		{
			return new StringUtility.StringSplitEnumerator<int?>(value.AsSpan(), split, removeEmptyEntries, StringUtility._spanSplitValueToInteger);
		}

		public static StringUtility.StringSplitEnumerator<int?> SpanSplitAsIntegers(this ReadOnlySpan<char> value, char split, bool removeEmptyEntries = true)
		{
			return new StringUtility.StringSplitEnumerator<int?>(value, split, removeEmptyEntries, StringUtility._spanSplitValueToInteger);
		}

		public static string TrimEnd(this string value, string trimString)
		{
			if (value.EndsWith(trimString))
			{
				value = value.Substring(0, value.Length - trimString.Length);
			}
			return value;
		}
	}
}
