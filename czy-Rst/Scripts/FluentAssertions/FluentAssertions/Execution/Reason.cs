using System.Diagnostics.CodeAnalysis;

namespace FluentAssertions.Execution
{
	public class Reason
	{
		public string FormattedMessage { get; set; }

		public object[] Arguments { get; set; }

		public Reason([StringSyntax("CompositeFormat")] string formattedMessage, object[] arguments)
		{
			FormattedMessage = formattedMessage;
			Arguments = arguments;
		}
	}
}
