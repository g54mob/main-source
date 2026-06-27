using System.Diagnostics.CodeAnalysis;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace FluentAssertions.Primitives
{
	internal class StringValidatorSupportingNull
	{
		private readonly IStringComparisonStrategy comparisonStrategy;

		private AssertionChain assertionChain;

		public StringValidatorSupportingNull(AssertionChain assertionChain, IStringComparisonStrategy comparisonStrategy, [StringSyntax("CompositeFormat")] string because, object[] becauseArgs)
		{
			this.comparisonStrategy = comparisonStrategy;
			this.assertionChain = assertionChain.BecauseOf(because, becauseArgs);
		}

		public void Validate(string subject, string expected)
		{
			if ((expected != null && expected.IsLongOrMultiline()) || (subject != null && subject.IsLongOrMultiline()))
			{
				assertionChain = assertionChain.UsingLineBreaks;
			}
			comparisonStrategy.ValidateAgainstMismatch(assertionChain, subject, expected);
		}
	}
}
