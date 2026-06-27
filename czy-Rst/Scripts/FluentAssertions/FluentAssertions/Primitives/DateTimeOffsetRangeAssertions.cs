using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions.Execution;

namespace FluentAssertions.Primitives
{
	[DebuggerNonUserCode]
	public class DateTimeOffsetRangeAssertions<TAssertions> where TAssertions : DateTimeOffsetAssertions<TAssertions>
	{
		private readonly TAssertions parentAssertions;

		private readonly AssertionChain assertionChain;

		private readonly TimeSpanPredicate predicate;

		private readonly Dictionary<TimeSpanCondition, TimeSpanPredicate> predicates = new Dictionary<TimeSpanCondition, TimeSpanPredicate>
		{
			[TimeSpanCondition.MoreThan] = new TimeSpanPredicate((TimeSpan ts1, TimeSpan ts2) => ts1 > ts2, "more than"),
			[TimeSpanCondition.AtLeast] = new TimeSpanPredicate((TimeSpan ts1, TimeSpan ts2) => ts1 >= ts2, "at least"),
			[TimeSpanCondition.Exactly] = new TimeSpanPredicate((TimeSpan ts1, TimeSpan ts2) => ts1 == ts2, "exactly"),
			[TimeSpanCondition.Within] = new TimeSpanPredicate((TimeSpan ts1, TimeSpan ts2) => ts1 <= ts2, "within"),
			[TimeSpanCondition.LessThan] = new TimeSpanPredicate((TimeSpan ts1, TimeSpan ts2) => ts1 < ts2, "less than")
		};

		private readonly DateTimeOffset? subject;

		private readonly TimeSpan timeSpan;

		protected internal DateTimeOffsetRangeAssertions(TAssertions parentAssertions, AssertionChain assertionChain, DateTimeOffset? subject, TimeSpanCondition condition, TimeSpan timeSpan)
		{
			this.parentAssertions = parentAssertions;
			this.assertionChain = assertionChain;
			this.subject = subject;
			this.timeSpan = timeSpan;
			predicate = predicates[condition];
		}

		public AndConstraint<TAssertions> Before(DateTimeOffset target, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(subject.HasValue).BecauseOf(because, becauseArgs).FailWith("Expected {context:the date and time} to be " + predicate.DisplayText + " {0} before {1}{reason}, but found a <null> DateTime.", timeSpan, target);
			if (assertionChain.Succeeded)
			{
				TimeSpan actual = target - subject.Value;
				assertionChain.ForCondition(predicate.IsMatchedBy(actual, timeSpan)).BecauseOf(because, becauseArgs).FailWith("Expected {context:the date and time} {0} to be " + predicate.DisplayText + " {1} before {2}{reason}, but it is " + PositionRelativeToTarget(subject.Value, target) + " by {3}.", subject, timeSpan, target, actual.Duration());
			}
			return new AndConstraint<TAssertions>(parentAssertions);
		}

		public AndConstraint<TAssertions> After(DateTimeOffset target, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(subject.HasValue).BecauseOf(because, becauseArgs).FailWith("Expected {context:the date and time} to be " + predicate.DisplayText + " {0} after {1}{reason}, but found a <null> DateTime.", timeSpan, target);
			if (assertionChain.Succeeded)
			{
				TimeSpan actual = subject.Value - target;
				assertionChain.ForCondition(predicate.IsMatchedBy(actual, timeSpan)).BecauseOf(because, becauseArgs).FailWith("Expected {context:the date and time} {0} to be " + predicate.DisplayText + " {1} after {2}{reason}, but it is " + PositionRelativeToTarget(subject.Value, target) + " by {3}.", subject, timeSpan, target, actual.Duration());
			}
			return new AndConstraint<TAssertions>(parentAssertions);
		}

		private static string PositionRelativeToTarget(DateTimeOffset actual, DateTimeOffset target)
		{
			if (!(actual - target >= TimeSpan.Zero))
			{
				return "behind";
			}
			return "ahead";
		}

		public override bool Equals(object obj)
		{
			throw new NotSupportedException("Equals is not part of Fluent Assertions. Did you mean Before() or After() instead?");
		}
	}
}
