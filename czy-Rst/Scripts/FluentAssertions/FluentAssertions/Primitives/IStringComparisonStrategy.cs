using FluentAssertions.Execution;

namespace FluentAssertions.Primitives
{
	internal interface IStringComparisonStrategy
	{
		string ExpectationDescription { get; }

		void ValidateAgainstMismatch(AssertionChain assertionChain, string subject, string expected);
	}
}
