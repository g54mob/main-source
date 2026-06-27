using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentAssertions.CallerIdentification
{
	internal class StatementParser
	{
		private readonly StringBuilder statement;

		private readonly List<IParsingStrategy> parsingStrategies;

		private readonly List<string> candidates = new List<string>();

		private ParsingState state;

		public string[] Identifiers => candidates.ToArray();

		internal StatementParser()
		{
			statement = new StringBuilder();
			parsingStrategies = new List<IParsingStrategy>(8)
			{
				new QuotesParsingStrategy(),
				new MultiLineCommentParsingStrategy(),
				new SingleLineCommentParsingStrategy(),
				new SemicolonParsingStrategy(),
				new ShouldCallParsingStrategy(),
				new WhichParsingStrategy(),
				new AwaitParsingStrategy(),
				new AddNonEmptySymbolParsingStrategy()
			};
		}

		public void Append(string symbols)
		{
			using CharEnumerator charEnumerator = symbols.GetEnumerator();
			while (charEnumerator.MoveNext() && state != ParsingState.Completed)
			{
				IEnumerable<IParsingStrategy> enumerable = parsingStrategies;
				if (parsingStrategies.Exists((IParsingStrategy s) => s.IsWaitingForContextEnd()))
				{
					enumerable = parsingStrategies.SkipWhile((IParsingStrategy parsingStrategy) => !parsingStrategy.IsWaitingForContextEnd());
				}
				state = ParsingState.InProgress;
				foreach (IParsingStrategy item in enumerable)
				{
					state = item.Parse(charEnumerator.Current, statement);
					if (state == ParsingState.CandidateFound)
					{
						candidates.Add(statement.ToString());
					}
					if (state != ParsingState.InProgress)
					{
						break;
					}
				}
			}
			if (!IsDone())
			{
				parsingStrategies.ForEach(delegate(IParsingStrategy strategy)
				{
					strategy.NotifyEndOfLineReached();
				});
			}
		}

		public bool IsDone()
		{
			return state == ParsingState.Completed;
		}
	}
}
