using System.Text;

namespace FluentAssertions.CallerIdentification
{
	internal class AddNonEmptySymbolParsingStrategy : IParsingStrategy
	{
		private enum Mode
		{
			RemoveAllWhitespace = 0,
			RemoveSuperfluousWhitespace = 1
		}

		private Mode mode;

		private char? precedingSymbol;

		public ParsingState Parse(char symbol, StringBuilder statement)
		{
			if (!char.IsWhiteSpace(symbol))
			{
				statement.Append(symbol);
				mode = Mode.RemoveSuperfluousWhitespace;
			}
			else if (mode == Mode.RemoveSuperfluousWhitespace)
			{
				char? c = precedingSymbol;
				if (c.HasValue)
				{
					char valueOrDefault = c.GetValueOrDefault();
					if (!char.IsWhiteSpace(valueOrDefault))
					{
						statement.Append(symbol);
					}
				}
			}
			precedingSymbol = symbol;
			return ParsingState.GoToNextSymbol;
		}

		public bool IsWaitingForContextEnd()
		{
			return false;
		}

		public void NotifyEndOfLineReached()
		{
			mode = Mode.RemoveAllWhitespace;
		}
	}
}
