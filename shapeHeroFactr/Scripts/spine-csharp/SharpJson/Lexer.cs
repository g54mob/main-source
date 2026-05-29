namespace SharpJson
{
	internal class Lexer
	{
		public enum Token
		{
			None = 0,
			Null = 1,
			True = 2,
			False = 3,
			Colon = 4,
			Comma = 5,
			String = 6,
			Number = 7,
			CurlyOpen = 8,
			CurlyClose = 9,
			SquaredOpen = 10,
			SquaredClose = 11
		}

		private char[] json;

		private int index;

		private bool success;

		private char[] stringBuffer;

		public bool hasError => false;

		public int lineNumber { get; private set; }

		public bool parseNumbersAsFloat { get; set; }

		public Lexer(string text)
		{
		}

		public void Reset()
		{
		}

		public string ParseString()
		{
			return null;
		}

		private string GetNumberString()
		{
			return null;
		}

		public float ParseFloatNumber()
		{
			return 0f;
		}

		public double ParseDoubleNumber()
		{
			return 0.0;
		}

		private int GetLastIndexOfNumber(int index)
		{
			return 0;
		}

		private void SkipWhiteSpaces()
		{
		}

		public Token LookAhead()
		{
			return default(Token);
		}

		public Token NextToken()
		{
			return default(Token);
		}

		private static Token NextToken(char[] json, ref int index)
		{
			return default(Token);
		}
	}
}
