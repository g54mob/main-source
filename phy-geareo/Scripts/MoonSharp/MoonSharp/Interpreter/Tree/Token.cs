using MoonSharp.Interpreter.Debugging;

namespace MoonSharp.Interpreter.Tree
{
	internal class Token
	{
		public readonly int SourceId;

		public readonly int FromCol;

		public readonly int ToCol;

		public readonly int FromLine;

		public readonly int ToLine;

		public readonly int PrevCol;

		public readonly int PrevLine;

		public readonly TokenType Type;

		public string Text { get; set; }

		public Token(TokenType type, int sourceId, int fromLine, int fromCol, int toLine, int toCol, int prevLine, int prevCol)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public static TokenType? GetReservedTokenType(string reservedWord)
		{
			return null;
		}

		public double GetNumberValue()
		{
			return 0.0;
		}

		public bool IsEndOfBlock()
		{
			return false;
		}

		public bool IsUnaryOperator()
		{
			return false;
		}

		public bool IsBinaryOperator()
		{
			return false;
		}

		internal SourceRef GetSourceRef(bool isStepStop = true)
		{
			return null;
		}

		internal SourceRef GetSourceRef(Token to, bool isStepStop = true)
		{
			return null;
		}

		internal SourceRef GetSourceRefUpTo(Token to, bool isStepStop = true)
		{
			return null;
		}
	}
}
