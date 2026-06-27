using System.Text;

namespace FluentAssertions.CallerIdentification
{
	internal class MultiLineCommentParsingStrategy : IParsingStrategy
	{
		private bool isCommentContext;

		private char? commentContextPreviousChar;

		public ParsingState Parse(char symbol, StringBuilder statement)
		{
			if (isCommentContext)
			{
				if (symbol == '/')
				{
					char? c = commentContextPreviousChar;
					if (c.HasValue && c == '*')
					{
						isCommentContext = false;
						commentContextPreviousChar = null;
						goto IL_0051;
					}
				}
				commentContextPreviousChar = symbol;
				goto IL_0051;
			}
			if (symbol == '*' && statement != null)
			{
				int length = statement.Length;
				if (length >= 1 && statement[length - 1] == '/')
				{
					statement.Remove(statement.Length - 1, 1);
					isCommentContext = true;
					return ParsingState.GoToNextSymbol;
				}
			}
			return ParsingState.InProgress;
			IL_0051:
			return ParsingState.GoToNextSymbol;
		}

		public bool IsWaitingForContextEnd()
		{
			return isCommentContext;
		}

		public void NotifyEndOfLineReached()
		{
		}
	}
}
