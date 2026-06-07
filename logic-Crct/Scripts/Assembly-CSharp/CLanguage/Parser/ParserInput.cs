using System.Collections.Generic;
using CLanguage.Parser.yyParser;
using CLanguage.Syntax;

namespace CLanguage.Parser
{
	public class ParserInput : yyInput
	{
		public readonly Token[] Tokens;

		private int index;

		private readonly HashSet<string> typedefs;

		private int[] retTypes;

		public Token CurrentToken => default(Token);

		public ParserInput(Token[] tokens)
		{
		}

		public bool advance()
		{
			return false;
		}

		public int token()
		{
			return 0;
		}

		public object value()
		{
			return null;
		}

		private bool IsReturnType(Token tok)
		{
			return false;
		}

		public void AddTypedef(string declaredIdentifier)
		{
		}
	}
}
