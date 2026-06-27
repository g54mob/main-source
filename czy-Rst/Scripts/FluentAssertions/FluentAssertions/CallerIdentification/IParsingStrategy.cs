using System.Text;

namespace FluentAssertions.CallerIdentification
{
	internal interface IParsingStrategy
	{
		ParsingState Parse(char symbol, StringBuilder statement);

		bool IsWaitingForContextEnd();

		void NotifyEndOfLineReached();
	}
}
