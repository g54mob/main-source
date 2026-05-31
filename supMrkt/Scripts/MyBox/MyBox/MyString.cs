using UnityEngine;

namespace MyBox
{
	public static class MyString
	{
		public static bool IsNullOrEmpty(this string str)
		{
			return false;
		}

		public static bool NotNullOrEmpty(this string str)
		{
			return false;
		}

		public static string RemoveStart(this string str, string remove)
		{
			return null;
		}

		public static string RemoveEnd(this string str, string remove)
		{
			return null;
		}

		public static string ToCamelCase(this string message)
		{
			return null;
		}

		public static string SplitCamelCase(this string camelCaseString)
		{
			return null;
		}

		public static T AsEnum<T>(this string source, bool ignoreCase = true)
		{
			return default(T);
		}

		public static string ToRoman(this int i)
		{
			return null;
		}

		public static string SurroundedWith(this string message, string surround)
		{
			return null;
		}

		public static string SurroundedWith(this string message, string start, string end)
		{
			return null;
		}

		public static string Colored(this string message, Colors color)
		{
			return null;
		}

		public static string Colored(this string message, Color color)
		{
			return null;
		}

		public static string Colored(this string message, string colorCode)
		{
			return null;
		}

		public static string Sized(this string message, int size)
		{
			return null;
		}

		public static string Underlined(this string message)
		{
			return null;
		}

		public static string Bold(this string message)
		{
			return null;
		}

		public static string Italics(this string message)
		{
			return null;
		}
	}
}
