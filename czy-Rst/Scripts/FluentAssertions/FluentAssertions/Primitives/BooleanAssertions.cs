using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions.Execution;

namespace FluentAssertions.Primitives
{
	[DebuggerNonUserCode]
	public class BooleanAssertions : BooleanAssertions<BooleanAssertions>
	{
		public BooleanAssertions(bool? value, AssertionChain assertionChain)
			: base(value, assertionChain)
		{
		}
	}
	[DebuggerNonUserCode]
	public class BooleanAssertions<TAssertions> where TAssertions : BooleanAssertions<TAssertions>
	{
		private readonly AssertionChain assertionChain;

		public bool? Subject { get; }

		public BooleanAssertions(bool? value, AssertionChain assertionChain)
		{
			this.assertionChain = assertionChain;
			Subject = value;
		}

		public AndConstraint<TAssertions> BeFalse([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(Subject == false).BecauseOf(because, becauseArgs).FailWith("Expected {context:boolean} to be {0}{reason}, but found {1}.", false, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeTrue([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(Subject == true).BecauseOf(because, becauseArgs).FailWith("Expected {context:boolean} to be {0}{reason}, but found {1}.", true, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> Be(bool expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(Subject == expected).BecauseOf(because, becauseArgs).FailWith("Expected {context:boolean} to be {0}{reason}, but found {1}.", expected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBe(bool unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(Subject != unexpected).BecauseOf(because, becauseArgs).FailWith("Expected {context:boolean} not to be {0}{reason}, but found {1}.", unexpected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> Imply(bool consequent, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			bool? antecedent = Subject;
			assertionChain.ForCondition(antecedent.HasValue).BecauseOf(because, becauseArgs).WithExpectation("Expected {context:antecedent} ({0}) to imply consequent ({1}){reason}, ", antecedent, consequent, delegate(AssertionChain chain)
			{
				chain.FailWith("but found null.").Then.ForCondition(!antecedent.Value || consequent).FailWith("but it did not.");
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public override bool Equals(object obj)
		{
			throw new NotSupportedException("Equals is not part of Fluent Assertions. Did you mean Be() instead?");
		}
	}
}
