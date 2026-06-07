using System;
using System.Collections.Generic;
using CLanguage.Syntax;

namespace CLanguage.Parser
{
	public class CodeLexer
	{
		private int _token;

		private object? _value;

		private int _lastR;

		private char[] _chbuf;

		private int _chbuflen;

		private Location location;

		private Location endLocation;

		private int line;

		private int column;

		private static readonly Dictionary<string, int> _kwTokens;

		public static readonly HashSet<int> KeywordTokens;

		public static readonly HashSet<int> OperatorTokens;

		private int nextPosition;

		public Report Report { get; }

		public Document Document { get; }

		public Token CurrentToken => default(Token);

		public Func<string, bool> IsTypedef { get; set; }

		public CodeLexer(Document document, Report? report = null)
		{
		}

		public CodeLexer(string name, string code, Report? report = null)
		{
		}

		private bool Eof()
		{
			return false;
		}

		private int Read()
		{
			return 0;
		}

		private int Peek()
		{
			return 0;
		}

		public void SkipWhiteSpace()
		{
		}

		public bool Advance()
		{
			return false;
		}

		private static bool IsHex(char c)
		{
			return false;
		}
	}
}
