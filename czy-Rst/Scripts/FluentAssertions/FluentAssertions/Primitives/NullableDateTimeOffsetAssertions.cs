using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions.Execution;

namespace FluentAssertions.Primitives
{
	[DebuggerNonUserCode]
	public class NullableDateTimeOffsetAssertions : NullableDateTimeOffsetAssertions<NullableDateTimeOffsetAssertions>
	{
		public NullableDateTimeOffsetAssertions(DateTimeOffset? expected, AssertionChain assertionChain)
			: base(expected, assertionChain)
		{
		}
	}
	[DebuggerNonUserCode]
	public class NullableDateTimeOffsetAssertions<TAssertions> : DateTimeOffsetAssertions<TAssertions> where TAssertions : NullableDateTimeOffsetAssertions<TAssertions>
	{
		private readonly AssertionChain assertionChain;

		public NullableDateTimeOffsetAssertions(DateTimeOffset? expected, AssertionChain assertionChain)
			: base(expected, assertionChain)
		{
			this.assertionChain = assertionChain;
		}

		public AndConstraint<TAssertions> HaveValue([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject.HasValue).BecauseOf(because, becauseArgs).FailWith("Expected {context:variable} to have a value{reason}, but found {0}", base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeNull([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return HaveValue(because, becauseArgs);
		}

		public AndConstraint<TAssertions> NotHaveValue([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(!base.Subject.HasValue).BecauseOf(because, becauseArgs).FailWith("Did not expect {context:variable} to have a value{reason}, but found {0}", base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeNull([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return NotHaveValue(because, becauseArgs);
		}
	}
}
