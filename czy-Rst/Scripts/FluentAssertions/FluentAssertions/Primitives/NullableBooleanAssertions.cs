using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions.Execution;

namespace FluentAssertions.Primitives
{
	[DebuggerNonUserCode]
	public class NullableBooleanAssertions : NullableBooleanAssertions<NullableBooleanAssertions>
	{
		public NullableBooleanAssertions(bool? value, AssertionChain assertionChain)
			: base(value, assertionChain)
		{
		}
	}
	[DebuggerNonUserCode]
	public class NullableBooleanAssertions<TAssertions> : BooleanAssertions<TAssertions> where TAssertions : NullableBooleanAssertions<TAssertions>
	{
		private readonly AssertionChain assertionChain;

		public NullableBooleanAssertions(bool? value, AssertionChain assertionChain)
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

		public AndConstraint<TAssertions> Be(bool? expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject == expected).BecauseOf(because, becauseArgs).FailWith("Expected {0}{reason}, but found {1}.", expected, base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBe(bool? unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject != unexpected).BecauseOf(because, becauseArgs).FailWith("Expected {context:nullable boolean} not to be {0}{reason}, but found {1}.", unexpected, base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeFalse([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(!((!base.Subject) ?? false)).BecauseOf(because, becauseArgs).FailWith("Expected {context:nullable boolean} not to be {0}{reason}, but found {1}.", false, base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeTrue([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(!(base.Subject ?? false)).BecauseOf(because, becauseArgs).FailWith("Expected {context:nullable boolean} not to be {0}{reason}, but found {1}.", true, base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}
	}
}
