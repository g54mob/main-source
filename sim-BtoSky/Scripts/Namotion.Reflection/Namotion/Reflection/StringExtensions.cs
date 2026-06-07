namespace Namotion.Reflection
{
	internal static class StringExtensions
	{
		public static string FirstToken(this string s, char splitChar)
		{
			int num = s.IndexOf(splitChar);
			if (num == -1)
			{
				return s;
			}
			return s.Substring(0, num);
		}

		public static string LastToken(this string s, char splitChar)
		{
			int num = s.LastIndexOf(splitChar);
			if (num == -1)
			{
				return s;
			}
			return s.Substring(num + 1);
		}
	}
}
