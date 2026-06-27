using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace FluentAssertions.Primitives
{
	[DebuggerNonUserCode]
	public class SimpleTimeSpanAssertions : SimpleTimeSpanAssertions<SimpleTimeSpanAssertions>
	{
		public SimpleTimeSpanAssertions(TimeSpan? value, AssertionChain assertionChain)
			: base(value, assertionChain)
		{
		}
	}
	[DebuggerNonUserCode]
	public class SimpleTimeSpanAssertions<TAssertions> where TAssertions : SimpleTimeSpanAssertions<TAssertions>
	{
		private readonly AssertionChain assertionChain;

		public TimeSpan? Subject { get; }

		public SimpleTimeSpanAssertions(TimeSpan? value, AssertionChain assertionChain)
		{
			this.assertionChain = assertionChain;
			Subject = value;
		}

		public AndConstraint<TAssertions> BePositive([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(Subject > TimeSpan.Zero).FailWith("Expected {context:time} to be positive{reason}, but found {0}.", Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeNegative([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(Subject < TimeSpan.Zero).FailWith("Expected {context:time} to be negative{reason}, but found {0}.", Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> Be(TimeSpan expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			AssertionChain obj = assertionChain.BecauseOf(because, becauseArgs);
			TimeSpan? subject = Subject;
			obj.ForCondition(expected == subject).FailWith("Expected {0}{reason}, but found {1}.", expected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBe(TimeSpan unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			AssertionChain obj = assertionChain;
			TimeSpan? subject = Subject;
			obj.ForCondition(unexpected != subject).BecauseOf(because, becauseArgs).FailWith("Did not expect {0}{reason}.", unexpected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeLessThan(TimeSpan expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(Subject < expected).FailWith("Expected {context:time} to be less than {0}{reason}, but found {1}.", expected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeLessThanOrEqualTo(TimeSpan expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(Subject <= expected).FailWith("Expected {context:time} to be less than or equal to {0}{reason}, but found {1}.", expected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeGreaterThan(TimeSpan expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(Subject > expected).FailWith("Expected {context:time} to be greater than {0}{reason}, but found {1}.", expected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeGreaterThanOrEqualTo(TimeSpan expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(Subject >= expected).FailWith("Expected {context:time} to be greater than or equal to {0}{reason}, but found {1}.", expected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeCloseTo(TimeSpan nearbyTime, TimeSpan precision, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNegative(precision, "precision");
			TimeSpan value = nearbyTime - precision;
			TimeSpan timeSpan = nearbyTime + precision;
			assertionChain.ForCondition(Subject >= value && Subject.Value <= timeSpan).BecauseOf(because, becauseArgs).FailWith("Expected {context:time} to be within {0} from {1}{reason}, but found {2}.", precision, nearbyTime, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeCloseTo(TimeSpan distantTime, TimeSpan precision, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNegative(precision, "precision");
			TimeSpan value = distantTime - precision;
			TimeSpan value2 = distantTime + precision;
			assertionChain.ForCondition(Subject < value || Subject > value2).BecauseOf(because, becauseArgs).FailWith("Expected {context:time} to not be within {0} from {1}{reason}, but found {2}.", precision, distantTime, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public override bool Equals(object obj)
		{
			throw new NotSupportedException("Equals is not part of Fluent Assertions. Did you mean Be() instead?");
		}
	}
}
