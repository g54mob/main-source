using System.Diagnostics.CodeAnalysis;

namespace FluentAssertions.Execution
{
	public interface ITestFramework
	{
		bool IsAvailable { get; }

		[DoesNotReturn]
		void Throw(string message);
	}
}
