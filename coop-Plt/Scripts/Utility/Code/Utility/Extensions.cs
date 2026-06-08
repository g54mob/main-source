using System;
using System.Linq;

namespace Code.Utility
{
	public static class Extensions
	{
		public static string SafeSubstring(this string input, int out_len)
		{
			if (input == null)
			{
				return "";
			}
			int length = input.Length;
			return input.Substring(0, Math.Min(length, out_len));
		}

		public static bool AreTheseTheSame<T>(this T[] a, T[] b)
		{
			if (a == null || b == null)
			{
				if (a == null)
				{
					return b == null;
				}
				return false;
			}
			return a.SequenceEqual(b);
		}
	}
}
