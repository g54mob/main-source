namespace MoonSharp.Interpreter.Tree
{
	internal static class LexerUtils
	{
		public static double ParseNumber(Token T)
		{
			return 0.0;
		}

		public static double ParseHexInteger(Token T)
		{
			return 0.0;
		}

		public static string ReadHexProgressive(string s, ref double d, out int digits)
		{
			digits = default(int);
			return null;
		}

		public static double ParseHexFloat(Token T)
		{
			return 0.0;
		}

		public static int HexDigit2Value(char c)
		{
			return 0;
		}

		public static bool CharIsDigit(char c)
		{
			return false;
		}

		public static bool CharIsHexDigit(char c)
		{
			return false;
		}

		public static string AdjustLuaLongString(string str)
		{
			return null;
		}

		public static string UnescapeLuaString(Token token, string str)
		{
			return null;
		}

		private static string ConvertUtf32ToChar(int i)
		{
			return null;
		}
	}
}
