namespace RLD
{
	public static class StringEx
	{
		public static string RemoveTrailingSlashes(this string str)
		{
			string text = str;
			while (text.LastChar() == '\\' || text.LastChar() == '/')
			{
				text = text.Substring(0, text.LastCharIndex());
			}
			return text;
		}

		public static char LastChar(this string str)
		{
			return str[str.LastCharIndex()];
		}

		public static int LastCharIndex(this string str)
		{
			return str.Length - 1;
		}

		public static bool ContainsOnlyWhiteSpace(this string str)
		{
			for (int i = 0; i < str.Length; i++)
			{
				if (!char.IsWhiteSpace(str[i]))
				{
					return false;
				}
			}
			return true;
		}

		public static bool IsSingleDigit(this string str)
		{
			if (str.Length == 1)
			{
				return char.IsDigit(str[0]);
			}
			return false;
		}

		public static bool IsSingleLetter(this string str)
		{
			if (str.Length == 1)
			{
				return char.IsLetter(str[0]);
			}
			return false;
		}

		public static bool IsSingleChar(this string str, char character)
		{
			if (str.Length == 1)
			{
				return str[0] == character;
			}
			return false;
		}
	}
}
