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
	public class DateTimeOffsetAssertions : DateTimeOffsetAssertions<DateTimeOffsetAssertions>
	{
		public DateTimeOffsetAssertions(DateTimeOffset? value, AssertionChain assertionChain)
			: base(value, assertionChain)
		{
		}
	}
	[DebuggerNonUserCode]
	public class DateTimeOffsetAssertions<TAssertions> where TAssertions : DateTimeOffsetAssertions<TAssertions>
	{
		private readonly AssertionChain assertionChain;

		public DateTimeOffset? Subject { get; }

		public DateTimeOffsetAssertions(DateTimeOffset? value, AssertionChain assertionChain)
		{
			this.assertionChain = assertionChain;
			Subject = value;
		}

		public AndConstraint<TAssertions> Be(DateTimeOffset expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected {context:the date and time} to represent the same point in time as {0}{reason}, ", expected, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith("but found a <null> DateTimeOffset.").Then.ForCondition(Subject == expected).FailWith("but {0} does not.", Subject);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> Be(DateTimeOffset? expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			if (!expected.HasValue)
			{
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(!Subject.HasValue).FailWith("Expected {context:the date and time} to be <null>{reason}, but it was {0}.", Subject);
			}
			else
			{
				assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected {context:the date and time} to represent the same point in time as {0}{reason}, ", expected, delegate(AssertionChain chain)
				{
					chain.ForCondition(Subject.HasValue).FailWith("but found a <null> DateTimeOffset.").Then.ForCondition(Subject == expected).FailWith("but {0} does not.", Subject);
				});
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBe(DateTimeOffset unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(Subject != unexpected).BecauseOf(because, becauseArgs).FailWith("Did not expect {context:the date and time} to represent the same point in time as {0}{reason}, but it did.", unexpected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBe(DateTimeOffset? unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(Subject != unexpected).BecauseOf(because, becauseArgs).FailWith("Did not expect {context:the date and time} to represent the same point in time as {0}{reason}, but it did.", unexpected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeExactly(DateTimeOffset expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected {context:the date and time} to be exactly {0}{reason}, ", expected, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith("but found a <null> DateTimeOffset.").Then.ForCondition(Subject.Value.EqualsExact(expected)).FailWith("but it was {0}.", Subject);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeExactly(DateTimeOffset? expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			if (!expected.HasValue)
			{
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(!Subject.HasValue).FailWith("Expected {context:the date and time} to be <null>{reason}, but it was {0}.", Subject);
			}
			else
			{
				assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected {context:the date and time} to be exactly {0}{reason}, ", expected, delegate(AssertionChain chain)
				{
					chain.ForCondition(Subject.HasValue).FailWith("but found a <null> DateTimeOffset.").Then.ForCondition(Subject.Value.EqualsExact(expected.Value)).FailWith("but it was {0}.", Subject);
				});
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeExactly(DateTimeOffset unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			AssertionChain obj = assertionChain;
			DateTimeOffset? subject = Subject;
			obj.ForCondition(!subject.HasValue || !subject.GetValueOrDefault().EqualsExact(unexpected)).BecauseOf(because, becauseArgs).FailWith("Did not expect {context:the date and time} to be exactly {0}{reason}, but it was.", unexpected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeExactly(DateTimeOffset? unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition((Subject.HasValue || unexpected.HasValue) && (!Subject.HasValue || !unexpected.HasValue || !Subject.Value.EqualsExact(unexpected.Value))).BecauseOf(because, becauseArgs).FailWith("Did not expect {context:the date and time} to be exactly {0}{reason}, but it was.", unexpected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeCloseTo(DateTimeOffset nearbyTime, TimeSpan precision, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNegative(precision, "precision");
			long ticks = (nearbyTime - DateTimeOffset.MinValue).Ticks;
			DateTimeOffset minimumValue = nearbyTime.AddTicks(-Math.Min(precision.Ticks, ticks));
			long ticks2 = (DateTimeOffset.MaxValue - nearbyTime).Ticks;
			DateTimeOffset maximumValue = nearbyTime.AddTicks(Math.Min(precision.Ticks, ticks2));
			TimeSpan? difference = (Subject - nearbyTime)?.Duration();
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected {context:the date and time} to be within {0} from {1}{reason}", precision, nearbyTime, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith(", but found <null>.").Then.ForCondition(Subject >= minimumValue && Subject <= maximumValue).FailWith(", but {0} was off by {1}.", Subject, difference);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeCloseTo(DateTimeOffset distantTime, TimeSpan precision, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNegative(precision, "precision");
			long ticks = (distantTime - DateTimeOffset.MinValue).Ticks;
			DateTimeOffset value = distantTime.AddTicks(-Math.Min(precision.Ticks, ticks));
			long ticks2 = (DateTimeOffset.MaxValue - distantTime).Ticks;
			DateTimeOffset value2 = distantTime.AddTicks(Math.Min(precision.Ticks, ticks2));
			assertionChain.ForCondition(Subject < value || Subject > value2).BecauseOf(because, becauseArgs).FailWith("Did not expect {context:the date and time} to be within {0} from {1}{reason}, but it was {2}.", precision, distantTime, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeBefore(DateTimeOffset expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(Subject < expected).BecauseOf(because, becauseArgs).FailWith("Expected {context:the date and time} to be before {0}{reason}, but it was {1}.", expected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeBefore(DateTimeOffset unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return BeOnOrAfter(unexpected, because, becauseArgs);
		}

		public AndConstraint<TAssertions> BeOnOrBefore(DateTimeOffset expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(Subject <= expected).BecauseOf(because, becauseArgs).FailWith("Expected {context:the date and time} to be on or before {0}{reason}, but it was {1}.", expected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeOnOrBefore(DateTimeOffset unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return BeAfter(unexpected, because, becauseArgs);
		}

		public AndConstraint<TAssertions> BeAfter(DateTimeOffset expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(Subject > expected).BecauseOf(because, becauseArgs).FailWith("Expected {context:the date and time} to be after {0}{reason}, but it was {1}.", expected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeAfter(DateTimeOffset unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return BeOnOrBefore(unexpected, because, becauseArgs);
		}

		public AndConstraint<TAssertions> BeOnOrAfter(DateTimeOffset expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(Subject >= expected).BecauseOf(because, becauseArgs).FailWith("Expected {context:the date and time} to be on or after {0}{reason}, but it was {1}.", expected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeOnOrAfter(DateTimeOffset unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return BeBefore(unexpected, because, becauseArgs);
		}

		public AndConstraint<TAssertions> HaveYear(int expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected the year part of {context:the date} to be {0}{reason}, ", expected, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith("but found a <null> DateTimeOffset.").Then.ForCondition(Subject.Value.Year == expected).FailWith("but it was {0}.", Subject.Value.Year);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotHaveYear(int unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Did not expect the year part of {context:the date} to be {0}{reason}, ", unexpected, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith("but found a <null> DateTimeOffset.").Then.ForCondition(Subject.Value.Year != unexpected).FailWith("but it was.");
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> HaveMonth(int expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected the month part of {context:the date} to be {0}{reason}, ", expected, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith("but found a <null> DateTimeOffset.").Then.ForCondition(Subject.Value.Month == expected).FailWith("but it was {0}.", Subject.Value.Month);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotHaveMonth(int unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Did not expect the month part of {context:the date} to be {0}{reason}, ", unexpected, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith("but found a <null> DateTimeOffset.").Then.ForCondition(Subject.Value.Month != unexpected).FailWith("but it was.");
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> HaveDay(int expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected the day part of {context:the date} to be {0}{reason}, ", expected, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith("but found a <null> DateTimeOffset.").Then.ForCondition(Subject.Value.Day == expected).FailWith("but it was {0}.", Subject.Value.Day);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotHaveDay(int unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Did not expect the day part of {context:the date} to be {0}{reason}, ", unexpected, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith("but found a <null> DateTimeOffset.").Then.ForCondition(Subject.Value.Day != unexpected).FailWith("but it was.");
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> HaveHour(int expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected the hour part of {context:the time} to be {0}{reason}, ", expected, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith("but found a <null> DateTimeOffset.").Then.ForCondition(Subject.Value.Hour == expected).FailWith("but it was {0}.", Subject.Value.Hour);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotHaveHour(int unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Did not expect the hour part of {context:the time} to be {0}{reason}, ", unexpected, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith("but found a <null> DateTimeOffset.").Then.ForCondition(Subject.Value.Hour != unexpected).FailWith("but it was.");
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> HaveMinute(int expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected the minute part of {context:the time} to be {0}{reason}, ", expected, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith("but found a <null> DateTimeOffset.").Then.ForCondition(Subject.Value.Minute == expected).FailWith("but it was {0}.", Subject.Value.Minute);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotHaveMinute(int unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Did not expect the minute part of {context:the time} to be {0}{reason}, ", unexpected, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith("but found a <null> DateTimeOffset.").Then.ForCondition(Subject.Value.Minute != unexpected).FailWith("but it was.");
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> HaveSecond(int expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected the seconds part of {context:the time} to be {0}{reason}, ", expected, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith("but found a <null> DateTimeOffset.").Then.ForCondition(Subject.Value.Second == expected).FailWith("but it was {0}.", Subject.Value.Second);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotHaveSecond(int unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Did not expect the seconds part of {context:the time} to be {0}{reason}, ", unexpected, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith("but found a <null> DateTimeOffset.").Then.ForCondition(Subject.Value.Second != unexpected).FailWith("but it was.");
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> HaveOffset(TimeSpan expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected the offset of {context:the date} to be {0}{reason}, ", expected, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith("but found a <null> DateTimeOffset.").Then.ForCondition(Subject.Value.Offset == expected).FailWith("but it was {0}.", Subject.Value.Offset);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotHaveOffset(TimeSpan unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Did not expect the offset of {context:the date} to be {0}{reason}, ", unexpected, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith("but found a <null> DateTimeOffset.").Then.ForCondition(Subject.Value.Offset != unexpected).FailWith("but it was.");
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public DateTimeOffsetRangeAssertions<TAssertions> BeMoreThan(TimeSpan timeSpan)
		{
			return new DateTimeOffsetRangeAssertions<TAssertions>((TAssertions)this, assertionChain, Subject, TimeSpanCondition.MoreThan, timeSpan);
		}

		public DateTimeOffsetRangeAssertions<TAssertions> BeAtLeast(TimeSpan timeSpan)
		{
			return new DateTimeOffsetRangeAssertions<TAssertions>((TAssertions)this, assertionChain, Subject, TimeSpanCondition.AtLeast, timeSpan);
		}

		public DateTimeOffsetRangeAssertions<TAssertions> BeExactly(TimeSpan timeSpan)
		{
			return new DateTimeOffsetRangeAssertions<TAssertions>((TAssertions)this, assertionChain, Subject, TimeSpanCondition.Exactly, timeSpan);
		}

		public DateTimeOffsetRangeAssertions<TAssertions> BeWithin(TimeSpan timeSpan)
		{
			return new DateTimeOffsetRangeAssertions<TAssertions>((TAssertions)this, assertionChain, Subject, TimeSpanCondition.Within, timeSpan);
		}

		public DateTimeOffsetRangeAssertions<TAssertions> BeLessThan(TimeSpan timeSpan)
		{
			return new DateTimeOffsetRangeAssertions<TAssertions>((TAssertions)this, assertionChain, Subject, TimeSpanCondition.LessThan, timeSpan);
		}

		public AndConstraint<TAssertions> BeSameDateAs(DateTimeOffset expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			DateTime expectedDate = expected.Date;
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected the date part of {context:the date and time} to be {0}{reason}, ", expectedDate, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith("but found a <null> DateTimeOffset.", expectedDate).Then.ForCondition(Subject.Value.Date == expectedDate).FailWith("but it was {0}.", Subject.Value.Date);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeSameDateAs(DateTimeOffset unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			DateTime unexpectedDate = unexpected.Date;
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Did not expect the date part of {context:the date and time} to be {0}{reason}, ", unexpectedDate, delegate(AssertionChain chain)
			{
				chain.ForCondition(Subject.HasValue).FailWith("but found a <null> DateTimeOffset.").Then.ForCondition(Subject.Value.Date != unexpectedDate).FailWith("but it was.");
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeOneOf(params DateTimeOffset?[] validValues)
		{
			return BeOneOf(validValues, string.Empty);
		}

		public AndConstraint<TAssertions> BeOneOf(params DateTimeOffset[] validValues)
		{
			return BeOneOf(validValues.Cast<DateTimeOffset?>(), "");
		}

		public AndConstraint<TAssertions> BeOneOf(IEnumerable<DateTimeOffset> validValues, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return BeOneOf(validValues.Cast<DateTimeOffset?>(), because, becauseArgs);
		}

		public AndConstraint<TAssertions> BeOneOf(IEnumerable<DateTimeOffset?> validValues, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(validValues.Contains(Subject)).BecauseOf(because, becauseArgs).FailWith("Expected {context:the date and time} to be one of {0}{reason}, but it was {1}.", validValues, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public override bool Equals(object obj)
		{
			throw new NotSupportedException("Equals is not part of Fluent Assertions. Did you mean Be() instead?");
		}
	}
}
