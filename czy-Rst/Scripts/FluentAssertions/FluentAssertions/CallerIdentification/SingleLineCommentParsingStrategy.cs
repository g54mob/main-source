using System.Text;

namespace FluentAssertions.CallerIdentification
{
	internal class SingleLineCommentParsingStrategy : IParsingStrategy
	{
		private bool isCommentContext;

		public ParsingState Parse(char symbol, StringBuilder statement)
		{
			if (isCommentContext)
			{
				return ParsingState.GoToNextSymbol;
			}
			if (symbol == '/' && statement != null)
			{
				int length = statement.Length;
				if (length >= 1 && statement[length - 1] == '/')
				{
					isCommentContext = true;
					statement.Remove(statement.Length - 1, 1);
					return ParsingState.GoToNextSymbol;
				}
			}
			return ParsingState.InProgress;
		}

		public bool IsWaitingForContextEnd()
		{
			return isCommentContext;
		}

		public void NotifyEndOfLineReached()
		{
			if (isCommentContext)
			{
				isCommentContext = false;
			}
		}
	}
}
