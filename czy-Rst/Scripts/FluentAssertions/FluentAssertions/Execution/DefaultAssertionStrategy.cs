using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FluentAssertions.Execution
{
	[ExcludeFromCodeCoverage]
	internal class DefaultAssertionStrategy : IAssertionStrategy
	{
		public IEnumerable<string> FailureMessages => Array.Empty<string>();

		public void HandleFailure(string message)
		{
			AssertionEngine.TestFramework.Throw(message);
		}

		public IEnumerable<string> DiscardFailures()
		{
			return Array.Empty<string>();
		}

		public void ThrowIfAny(IDictionary<string, object> context)
		{
		}
	}
}
