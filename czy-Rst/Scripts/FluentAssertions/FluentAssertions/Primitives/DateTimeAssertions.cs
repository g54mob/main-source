using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace FluentAssertions.Primitives
{
	[DebuggerNonUserCode]
	public class DateTimeAssertions : DateTimeAssertions<DateTimeAssertions>
	{
		public DateTimeAssertions(DateTime? value, AssertionChain assertionChain)
			: base(value, assertionChain)
		{
		}
	}
	[DebuggerNonUserCode]
	public class DateTimeAssertions<TAssertions> where TAssertions : DateTimeAssertions<TAssertions>
	{
		private readonly AssertionChain assertionChain;

		public DateTime? Subject { get; }

		public DateTimeAssertions(DateTime? value, AssertionChain assertionChain)
		{
			this.assertionChain = assertionChain;
			Subject = value;
		}

		public AndConstraint<TAssertions> Be(DateTime expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(Subject == expected).BecauseOf(because, becauseArgs).FailWith("Expected {context:date and time} to be {0}{reason}, but found {1}.", expected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> Be(DateTime? expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(Subject == expected).BecauseOf(because, becauseArgs).FailWith("Expected {context:date and time} to be {0}{reason}, but found {1}.", expected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBe(DateTime unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(Subject != unexpected).BecauseOf(because, becauseArgs).FailWith("Expected {context:date and time} not to be {0}{reason}, but it is.", unexpected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBe(DateTime? unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(Subject != unexpected).BecauseOf(because, becauseArgs).FailWith("Expected {context:date and time} not to be {0}{reason}, but it is.", unexpected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeCloseTo(DateTime nearbyTime, TimeSpan precision, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNegative(precision, "precision");
			long ticks = (nearbyTime - DateTime.MinValue).Ticks;
			DateTime minimumValue = nearbyTime.AddTicks(-Math.Min(precision.Ticks, ticks));
			long ticks2 = (DateTime.MaxValue - nearbyTime).Ticks;
			DateTime maximumValue = nearbyTime.AddTicks(Math.Min(precision.Ticks, ticks2));
			TimeSpan? difference = (Subject - nearbyTime)?.Duration();
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected {context:the date and time} to be within {0} from {1}{reason}", precision, nearbyTime, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith(", but found <null>.").Then.ForCondition(Subject >= minimumValue && Subject <= maximumValue).FailWith(", but {0} was off by {1}.", Subject, difference);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeCloseTo(DateTime distantTime, TimeSpan precision, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNegative(precision, "precision");
			long ticks = (distantTime - DateTime.MinValue).Ticks;
			DateTime value = distantTime.AddTicks(-Math.Min(precision.Ticks, ticks));
			long ticks2 = (DateTime.MaxValue - distantTime).Ticks;
			DateTime value2 = distantTime.AddTicks(Math.Min(precision.Ticks, ticks2));
			assertionChain.ForCondition(Subject < value || Subject > value2).BecauseOf(because, becauseArgs).FailWith("Did not expect {context:the date and time} to be within {0} from {1}{reason}, but it was {2}.", precision, distantTime, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeBefore(DateTime expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(Subject < expected).BecauseOf(because, becauseArgs).FailWith("Expected {context:the date and time} to be before {0}{reason}, but found {1}.", expected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeBefore(DateTime unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return BeOnOrAfter(unexpected, because, becauseArgs);
		}

		public AndConstraint<TAssertions> BeOnOrBefore(DateTime expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(Subject <= expected).BecauseOf(because, becauseArgs).FailWith("Expected {context:the date and time} to be on or before {0}{reason}, but found {1}.", expected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeOnOrBefore(DateTime unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return BeAfter(unexpected, because, becauseArgs);
		}

		public AndConstraint<TAssertions> BeAfter(DateTime expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(Subject > expected).BecauseOf(because, becauseArgs).FailWith("Expected {context:the date and time} to be after {0}{reason}, but found {1}.", expected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeAfter(DateTime unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return BeOnOrBefore(unexpected, because, becauseArgs);
		}

		public AndConstraint<TAssertions> BeOnOrAfter(DateTime expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(Subject >= expected).BecauseOf(because, becauseArgs).FailWith("Expected {context:the date and time} to be on or after {0}{reason}, but found {1}.", expected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeOnOrAfter(DateTime unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return BeBefore(unexpected, because, becauseArgs);
		}

		public AndConstraint<TAssertions> HaveYear(int expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected the year part of {context:the date} to be {0}{reason}", expected, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith(", but found <null>.").Then.ForCondition(Subject.Value.Year == expected).FailWith(", but found {0}.", Subject.Value.Year);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotHaveYear(int unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(Subject.HasValue).FailWith("Did not expect the year part of {context:the date} to be {0}{reason}, but found a <null> DateTime.", unexpected)
				.Then.ForCondition(Subject.Value.Year != unexpected).FailWith("Did not expect the year part of {context:the date} to be {0}{reason}, but it was.", unexpected, Subject.Value.Year);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> HaveMonth(int expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected the month part of {context:the date} to be {0}{reason}", expected, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith(", but found a <null> DateTime.").Then.ForCondition(Subject.Value.Month == expected).FailWith(", but found {0}.", Subject.Value.Month);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotHaveMonth(int unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Did not expect the month part of {context:the date} to be {0}{reason}", unexpected, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith(", but found a <null> DateTime.").Then.ForCondition(Subject.Value.Month != unexpected).FailWith(", but it was.");
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> HaveDay(int expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected the day part of {context:the date} to be {0}{reason}", expected, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith(", but found a <null> DateTime.").Then.ForCondition(Subject.Value.Day == expected).FailWith(", but found {0}.", Subject.Value.Day);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotHaveDay(int unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Did not expect the day part of {context:the date} to be {0}{reason}", unexpected, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith(", but found a <null> DateTime.").Then.ForCondition(Subject.Value.Day != unexpected).FailWith(", but it was.");
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> HaveHour(int expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected the hour part of {context:the time} to be {0}{reason}", expected, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith(", but found a <null> DateTime.").Then.ForCondition(Subject.Value.Hour == expected).FailWith(", but found {0}.", Subject.Value.Hour);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotHaveHour(int unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Did not expect the hour part of {context:the time} to be {0}{reason}", unexpected, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith(", but found a <null> DateTime.", unexpected).Then.ForCondition(Subject.Value.Hour != unexpected).FailWith(", but it was.", unexpected, Subject.Value.Hour);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> HaveMinute(int expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected the minute part of {context:the time} to be {0}{reason}", expected, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith(", but found a <null> DateTime.").Then.ForCondition(Subject.Value.Minute == expected).FailWith(", but found {0}.", Subject.Value.Minute);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotHaveMinute(int unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Did not expect the minute part of {context:the time} to be {0}{reason}", unexpected, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith(", but found a <null> DateTime.", unexpected).Then.ForCondition(Subject.Value.Minute != unexpected).FailWith(", but it was.", unexpected, Subject.Value.Minute);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> HaveSecond(int expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected the seconds part of {context:the time} to be {0}{reason}", expected, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith(", but found a <null> DateTime.").Then.ForCondition(Subject.Value.Second == expected).FailWith(", but found {0}.", Subject.Value.Second);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotHaveSecond(int unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Did not expect the seconds part of {context:the time} to be {0}{reason}", unexpected, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith(", but found a <null> DateTime.").Then.ForCondition(Subject.Value.Second != unexpected).FailWith(", but it was.");
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public DateTimeRangeAssertions<TAssertions> BeMoreThan(TimeSpan timeSpan)
		{
			return new DateTimeRangeAssertions<TAssertions>((TAssertions)this, assertionChain, Subject, TimeSpanCondition.MoreThan, timeSpan);
		}

		public DateTimeRangeAssertions<TAssertions> BeAtLeast(TimeSpan timeSpan)
		{
			return new DateTimeRangeAssertions<TAssertions>((TAssertions)this, assertionChain, Subject, TimeSpanCondition.AtLeast, timeSpan);
		}

		public DateTimeRangeAssertions<TAssertions> BeExactly(TimeSpan timeSpan)
		{
			return new DateTimeRangeAssertions<TAssertions>((TAssertions)this, assertionChain, Subject, TimeSpanCondition.Exactly, timeSpan);
		}

		public DateTimeRangeAssertions<TAssertions> BeWithin(TimeSpan timeSpan)
		{
			return new DateTimeRangeAssertions<TAssertions>((TAssertions)this, assertionChain, Subject, TimeSpanCondition.Within, timeSpan);
		}

		public DateTimeRangeAssertions<TAssertions> BeLessThan(TimeSpan timeSpan)
		{
			return new DateTimeRangeAssertions<TAssertions>((TAssertions)this, assertionChain, Subject, TimeSpanCondition.LessThan, timeSpan);
		}

		public AndConstraint<TAssertions> BeSameDateAs(DateTime expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			DateTime expectedDate = expected.Date;
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected the date part of {context:the date and time} to be {0}{reason}", expectedDate, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith(", but found a <null> DateTime.", expectedDate).Then.ForCondition(Subject.Value.Date == expectedDate).FailWith(", but found {1}.", expectedDate, Subject.Value);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeSameDateAs(DateTime unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			DateTime unexpectedDate = unexpected.Date;
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Did not expect the date part of {context:the date and time} to be {0}{reason}", unexpectedDate, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith(", but found a <null> DateTime.").Then.ForCondition(Subject.Value.Date != unexpectedDate).FailWith(", but it was.");
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeOneOf(params DateTime?[] validValues)
		{
			return BeOneOf(validValues, string.Empty);
		}

		public AndConstraint<TAssertions> BeOneOf(params DateTime[] validValues)
		{
			return BeOneOf(validValues.Cast<DateTime?>(), "");
		}

		public AndConstraint<TAssertions> BeOneOf(IEnumerable<DateTime> validValues, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return BeOneOf(validValues.Cast<DateTime?>(), because, becauseArgs);
		}

		public AndConstraint<TAssertions> BeOneOf(IEnumerable<DateTime?> validValues, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(validValues.Contains(Subject)).BecauseOf(because, becauseArgs).FailWith("Expected {context:date and time} to be one of {0}{reason}, but found {1}.", validValues, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeIn(DateTimeKind expectedKind, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected {context:the date and time} to be in " + expectedKind.ToString() + "{reason}", delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith(", but found a <null> DateTime.").Then.ForCondition(Subject.Value.Kind == expectedKind).FailWith(", but found " + Subject.Value.Kind.ToString() + ".");
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeIn(DateTimeKind unexpectedKind, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Did not expect {context:the date and time} to be in " + unexpectedKind.ToString() + "{reason}", delegate(AssertionChain chain)
			{
				chain.Given(() => Subject).ForCondition((DateTime? subject) => subject.HasValue).FailWith(", but found a <null> DateTime.")
					.Then.ForCondition((DateTime? subject) => subject.GetValueOrDefault().Kind != unexpectedKind).FailWith(", but it was.");
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public override bool Equals(object obj)
		{
			throw new NotSupportedException("Equals is not part of Fluent Assertions. Did you mean Be() instead?");
		}
	}
}
