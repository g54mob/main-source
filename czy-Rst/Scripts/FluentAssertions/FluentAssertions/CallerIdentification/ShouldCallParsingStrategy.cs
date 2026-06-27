using System.Text;

namespace FluentAssertions.CallerIdentification
{
	internal class ShouldCallParsingStrategy : IParsingStrategy
	{
		private const string ExpectedPhrase = ".Should";

		public ParsingState Parse(char symbol, StringBuilder statement)
		{
			if (IsLongEnough(statement) && EndsWithExpectedPhrase(statement) && EndsWithInvocation(statement))
			{
				statement.Remove(statement.Length - (".Should".Length + 1), ".Should".Length + 1);
				return ParsingState.CandidateFound;
			}
			return ParsingState.InProgress;
		}

		private static bool IsLongEnough(StringBuilder statement)
		{
			return statement.Length >= ".Should".Length + 1;
		}

		private static bool EndsWithExpectedPhrase(StringBuilder statement)
		{
			int num = statement.Length - 2;
			int num2 = ".Should".Length - 1;
			for (int i = 0; i < ".Should".Length; i++)
			{
				if (statement[num - i] != ".Should"[num2 - i])
				{
					return false;
				}
			}
			return true;
		}

		private static bool EndsWithInvocation(StringBuilder statement)
		{
			char c = statement[statement.Length - 1];
			if (c == '(' || c == '.')
			{
				return true;
			}
			return false;
		}

		public bool IsWaitingForContextEnd()
		{
			return false;
		}

		public void NotifyEndOfLineReached()
		{
		}
	}
}
