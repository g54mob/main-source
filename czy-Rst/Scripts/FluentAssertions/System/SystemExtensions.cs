namespace System
{
	internal static class SystemExtensions
	{
		public static int IndexOf(this string str, char c, StringComparison _)
		{
			return str.IndexOf(c);
		}

		public static string Replace(this string str, string oldValue, string newValue, StringComparison _)
		{
			return str.Replace(oldValue, newValue);
		}

		public static bool Contains(this string str, string value, StringComparison comparison)
		{
			return str.IndexOf(value, comparison) != -1;
		}

		public static bool Contains(this string str, char value, StringComparison comparison)
		{
			return IndexOf(str, value, comparison) != -1;
		}

		public static bool StartsWith(this string str, char value)
		{
			if (str.Length != 0)
			{
				return str[0] == value;
			}
			return false;
		}

		public static string[] Split(this string str, char separator, StringSplitOptions options = StringSplitOptions.None)
		{
			return str.Split(new char[1] { separator }, options);
		}

		public static string[] Split(this string str, string separator, StringSplitOptions options = StringSplitOptions.None)
		{
			return str.Split(new string[1] { separator }, options);
		}
	}
}
