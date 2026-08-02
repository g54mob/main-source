namespace MoonSharp.Interpreter.Tree
{
	internal class Lexer
	{
		private Token m_Current;

		private string m_Code;

		private int m_PrevLineTo;

		private int m_PrevColTo;

		private int m_Cursor;

		private int m_Line;

		private int m_Col;

		private int m_SourceId;

		private bool m_AutoSkipComments;

		public Token Current => null;

		public Lexer(int sourceID, string scriptContent, bool autoSkipComments)
		{
		}

		private Token FetchNewToken()
		{
			return null;
		}

		public void Next()
		{
		}

		public Token PeekNext()
		{
			return null;
		}

		private void CursorNext()
		{
		}

		private char CursorChar()
		{
			return '\0';
		}

		private char CursorCharNext()
		{
			return '\0';
		}

		private bool CursorMatches(string pattern)
		{
			return false;
		}

		private bool CursorNotEof()
		{
			return false;
		}

		private bool IsWhiteSpace(char c)
		{
			return false;
		}

		private void SkipWhiteSpace()
		{
		}

		private Token ReadToken()
		{
			return null;
		}

		private string ReadLongString(int fromLine, int fromCol, string startpattern, string subtypeforerrors)
		{
			return null;
		}

		private Token ReadNumberToken(int fromLine, int fromCol, bool leadingDot)
		{
			return null;
		}

		private Token CreateSingleCharToken(TokenType tokenType, int fromLine, int fromCol)
		{
			return null;
		}

		private Token ReadHashBang(int fromLine, int fromCol)
		{
			return null;
		}

		private Token ReadComment(int fromLine, int fromCol)
		{
			return null;
		}

		private Token ReadSimpleStringToken(int fromLine, int fromCol)
		{
			return null;
		}

		private Token PotentiallyDoubleCharOperator(char expectedSecondChar, TokenType singleCharToken, TokenType doubleCharToken, int fromLine, int fromCol)
		{
			return null;
		}

		private Token CreateNameToken(string name, int fromLine, int fromCol)
		{
			return null;
		}

		private Token CreateToken(TokenType tokenType, int fromLine, int fromCol, string text = null)
		{
			return null;
		}

		private string ReadNameToken()
		{
			return null;
		}
	}
}
