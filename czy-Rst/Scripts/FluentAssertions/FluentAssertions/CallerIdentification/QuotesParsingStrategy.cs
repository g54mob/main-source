using System.Text;

namespace FluentAssertions.CallerIdentification
{
	internal class QuotesParsingStrategy : IParsingStrategy
	{
		private char isQuoteEscapeSymbol = '\\';

		private bool isQuoteContext;

		private char? previousChar;

		public ParsingState Parse(char symbol, StringBuilder statement)
		{
			if (symbol == '"')
			{
				if (isQuoteContext)
				{
					if (previousChar != isQuoteEscapeSymbol)
					{
						isQuoteContext = false;
						isQuoteEscapeSymbol = '\\';
						previousChar = null;
						statement.Append(symbol);
						return ParsingState.GoToNextSymbol;
					}
				}
				else
				{
					isQuoteContext = true;
					if (IsVerbatim(statement))
					{
						isQuoteEscapeSymbol = '"';
					}
				}
			}
			if (isQuoteContext)
			{
				statement.Append(symbol);
			}
			previousChar = symbol;
			if (!isQuoteContext)
			{
				return ParsingState.InProgress;
			}
			return ParsingState.GoToNextSymbol;
		}

		public bool IsWaitingForContextEnd()
		{
			return isQuoteContext;
		}

		public void NotifyEndOfLineReached()
		{
		}

		private bool IsVerbatim(StringBuilder statement)
		{
			char? c = previousChar;
			if (c.HasValue && c == '@' && statement != null)
			{
				int length = statement.Length;
				if (length >= 2 && statement[length - 2] == '$' && statement[length - 1] == '@')
				{
					return true;
				}
			}
			c = previousChar;
			if (c.HasValue && c == '$')
			{
				if (statement != null)
				{
					int length = statement.Length;
					if (length >= 2 && statement[length - 2] == '@')
					{
						return statement[length - 1] == '$';
					}
				}
				return false;
			}
			return false;
		}
	}
}
