using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions.Execution;

namespace FluentAssertions.Primitives
{
	[DebuggerNonUserCode]
	public class GuidAssertions : GuidAssertions<GuidAssertions>
	{
		public GuidAssertions(Guid? value, AssertionChain assertionChain)
			: base(value, assertionChain)
		{
		}
	}
	[DebuggerNonUserCode]
	public class GuidAssertions<TAssertions> where TAssertions : GuidAssertions<TAssertions>
	{
		private readonly AssertionChain assertionChain;

		public Guid? Subject { get; }

		public GuidAssertions(Guid? value, AssertionChain assertionChain)
		{
			this.assertionChain = assertionChain;
			Subject = value;
		}

		public AndConstraint<TAssertions> BeEmpty([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(Subject == Guid.Empty).BecauseOf(because, becauseArgs).FailWith("Expected {context:Guid} to be empty{reason}, but found {0}.", Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeEmpty([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			AssertionChain obj = assertionChain;
			Guid? subject = Subject;
			int condition;
			if (subject.HasValue)
			{
				Guid valueOrDefault = subject.GetValueOrDefault();
				condition = ((valueOrDefault != Guid.Empty) ? 1 : 0);
			}
			else
			{
				condition = 0;
			}
			obj.ForCondition((byte)condition != 0).BecauseOf(because, becauseArgs).FailWith("Did not expect {context:Guid} to be empty{reason}.");
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> Be(string expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			if (!Guid.TryParse(expected, out var result))
			{
				throw new ArgumentException("Unable to parse \"" + expected + "\" as a valid GUID", "expected");
			}
			return Be(result, because, becauseArgs);
		}

		public AndConstraint<TAssertions> Be(Guid expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(Subject == expected).BecauseOf(because, becauseArgs).FailWith("Expected {context:Guid} to be {0}{reason}, but found {1}.", expected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBe(string unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			if (!Guid.TryParse(unexpected, out var result))
			{
				throw new ArgumentException("Unable to parse \"" + unexpected + "\" as a valid GUID", "unexpected");
			}
			return NotBe(result, because, becauseArgs);
		}

		public AndConstraint<TAssertions> NotBe(Guid unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(Subject != unexpected).BecauseOf(because, becauseArgs).FailWith("Did not expect {context:Guid} to be {0}{reason}.", Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public override bool Equals(object obj)
		{
			throw new NotSupportedException("Equals is not part of Fluent Assertions. Did you mean Be() or BeOneOf() instead?");
		}
	}
}
