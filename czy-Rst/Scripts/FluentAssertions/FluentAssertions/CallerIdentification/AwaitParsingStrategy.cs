using System.Text;

namespace FluentAssertions.CallerIdentification
{
	internal class AwaitParsingStrategy : IParsingStrategy
	{
		private const string KeywordToSkip = "await ";

		public ParsingState Parse(char symbol, StringBuilder statement)
		{
			if (IsLongEnoughToContainOurKeyword(statement) && EndsWithOurKeyword(statement))
			{
				statement.Remove(statement.Length - "await ".Length, "await ".Length);
			}
			return ParsingState.InProgress;
		}

		private static bool EndsWithOurKeyword(StringBuilder statement)
		{
			int num = statement.Length - 1;
			int num2 = "await ".Length - 1;
			for (int i = 0; i < "await ".Length; i++)
			{
				if (statement[num - i] != "await "[num2 - i])
				{
					return false;
				}
			}
			return true;
		}

		private static bool IsLongEnoughToContainOurKeyword(StringBuilder statement)
		{
			return statement.Length >= "await ".Length;
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
