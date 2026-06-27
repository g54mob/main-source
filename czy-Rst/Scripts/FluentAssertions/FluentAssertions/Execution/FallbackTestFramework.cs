using System.Diagnostics.CodeAnalysis;

namespace FluentAssertions.Execution
{
	internal class FallbackTestFramework : ITestFramework
	{
		public bool IsAvailable => true;

		[DoesNotReturn]
		public void Throw(string message)
		{
			throw new AssertionFailedException(message);
		}
	}
}
