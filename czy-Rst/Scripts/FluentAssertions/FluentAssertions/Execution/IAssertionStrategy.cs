using System.Collections.Generic;

namespace FluentAssertions.Execution
{
	public interface IAssertionStrategy
	{
		IEnumerable<string> FailureMessages { get; }

		void HandleFailure(string message);

		IEnumerable<string> DiscardFailures();

		void ThrowIfAny(IDictionary<string, object> context);
	}
}
