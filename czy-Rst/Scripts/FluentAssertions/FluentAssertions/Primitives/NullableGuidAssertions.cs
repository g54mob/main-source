using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions.Execution;

namespace FluentAssertions.Primitives
{
	[DebuggerNonUserCode]
	public class NullableGuidAssertions : NullableGuidAssertions<NullableGuidAssertions>
	{
		public NullableGuidAssertions(Guid? value, AssertionChain assertionChain)
			: base(value, assertionChain)
		{
		}
	}
	[DebuggerNonUserCode]
	public class NullableGuidAssertions<TAssertions> : GuidAssertions<TAssertions> where TAssertions : NullableGuidAssertions<TAssertions>
	{
		private readonly AssertionChain assertionChain;

		public NullableGuidAssertions(Guid? value, AssertionChain assertionChain)
			: base(value, assertionChain)
		{
			this.assertionChain = assertionChain;
		}

		public AndConstraint<TAssertions> HaveValue([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject.HasValue).BecauseOf(because, becauseArgs).FailWith("Expected a value{reason}.");
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeNull([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return HaveValue(because, becauseArgs);
		}

		public AndConstraint<TAssertions> NotHaveValue([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(!base.Subject.HasValue).BecauseOf(because, becauseArgs).FailWith("Did not expect a value{reason}, but found {0}.", base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeNull([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return NotHaveValue(because, becauseArgs);
		}

		public AndConstraint<TAssertions> Be(Guid? expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject == expected).BecauseOf(because, becauseArgs).FailWith("Expected {context:Guid} to be {0}{reason}, but found {1}.", expected, base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}
	}
}
