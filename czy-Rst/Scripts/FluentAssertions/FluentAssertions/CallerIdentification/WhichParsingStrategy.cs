using System.Text;

namespace FluentAssertions.CallerIdentification
{
	internal class WhichParsingStrategy : IParsingStrategy
	{
		private const string ExpectedPhrase = ".Which.";

		public ParsingState Parse(char symbol, StringBuilder statement)
		{
			if (IsLongEnough(statement) && EndsWithExpectedPhrase(statement))
			{
				statement.Clear();
			}
			return ParsingState.InProgress;
		}

		private static bool IsLongEnough(StringBuilder statement)
		{
			return statement.Length >= ".Which.".Length;
		}

		private static bool EndsWithExpectedPhrase(StringBuilder statement)
		{
			int num = statement.Length - 1;
			int num2 = ".Which.".Length - 1;
			for (int i = 0; i < ".Which.".Length; i++)
			{
				if (statement[num - i] != ".Which."[num2 - i])
				{
					return false;
				}
			}
			return true;
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
