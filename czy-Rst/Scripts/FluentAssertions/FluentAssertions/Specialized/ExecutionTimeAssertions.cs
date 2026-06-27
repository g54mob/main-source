using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace FluentAssertions.Specialized
{
	public class ExecutionTimeAssertions
	{
		private readonly ExecutionTime execution;

		private readonly AssertionChain assertionChain;

		public ExecutionTimeAssertions(ExecutionTime executionTime, AssertionChain assertionChain)
		{
			execution = executionTime ?? throw new ArgumentNullException("executionTime");
			this.assertionChain = assertionChain;
		}

		private (bool isRunning, TimeSpan elapsed) PollUntil(Func<TimeSpan, bool> condition, bool expectedResult, TimeSpan rate)
		{
			TimeSpan elapsedTime = execution.ElapsedTime;
			bool flag = execution.IsRunning;
			while (flag && condition(elapsedTime) != expectedResult)
			{
				flag = !execution.Task.Wait(rate);
				elapsedTime = execution.ElapsedTime;
			}
			if (execution.Exception != null)
			{
				throw execution.Exception;
			}
			return (isRunning: flag, elapsed: elapsedTime);
		}

		public AndConstraint<ExecutionTimeAssertions> BeLessThanOrEqualTo(TimeSpan maxDuration, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			var (flag, timeSpan) = PollUntil((TimeSpan duration) => duration <= maxDuration, expectedResult: false, maxDuration);
			assertionChain.ForCondition(timeSpan <= maxDuration).BecauseOf(because, becauseArgs).FailWith("Execution of " + execution.ActionDescription.EscapePlaceholders() + " should be less than or equal to {0}{reason}, but it required " + (flag ? "more than " : "exactly ") + "{1}.", maxDuration, timeSpan);
			return new AndConstraint<ExecutionTimeAssertions>(this);
		}

		public AndConstraint<ExecutionTimeAssertions> BeLessThan(TimeSpan maxDuration, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			var (flag, timeSpan) = PollUntil((TimeSpan duration) => duration < maxDuration, expectedResult: false, maxDuration);
			assertionChain.ForCondition(timeSpan < maxDuration).BecauseOf(because, becauseArgs).FailWith("Execution of " + execution.ActionDescription.EscapePlaceholders() + " should be less than {0}{reason}, but it required " + (flag ? "more than " : "exactly ") + "{1}.", maxDuration, timeSpan);
			return new AndConstraint<ExecutionTimeAssertions>(this);
		}

		public AndConstraint<ExecutionTimeAssertions> BeGreaterThanOrEqualTo(TimeSpan minDuration, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			var (flag, timeSpan) = PollUntil((TimeSpan duration) => duration >= minDuration, expectedResult: true, minDuration);
			assertionChain.ForCondition(timeSpan >= minDuration).BecauseOf(because, becauseArgs).FailWith("Execution of " + execution.ActionDescription.EscapePlaceholders() + " should be greater than or equal to {0}{reason}, but it required " + (flag ? "more than " : "exactly ") + "{1}.", minDuration, timeSpan);
			return new AndConstraint<ExecutionTimeAssertions>(this);
		}

		public AndConstraint<ExecutionTimeAssertions> BeGreaterThan(TimeSpan minDuration, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			var (flag, timeSpan) = PollUntil((TimeSpan duration) => duration > minDuration, expectedResult: true, minDuration);
			assertionChain.ForCondition(timeSpan > minDuration).BecauseOf(because, becauseArgs).FailWith("Execution of " + execution.ActionDescription.EscapePlaceholders() + " should be greater than {0}{reason}, but it required " + (flag ? "more than " : "exactly ") + "{1}.", minDuration, timeSpan);
			return new AndConstraint<ExecutionTimeAssertions>(this);
		}

		public AndConstraint<ExecutionTimeAssertions> BeCloseTo(TimeSpan expectedDuration, TimeSpan precision, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNegative(precision, "precision");
			TimeSpan timeSpan = expectedDuration - precision;
			TimeSpan maximumValue = expectedDuration + precision;
			var (flag, timeSpan2) = PollUntil((TimeSpan duration) => duration <= maximumValue, expectedResult: false, maximumValue);
			assertionChain.ForCondition(timeSpan2 >= timeSpan && timeSpan2 <= maximumValue).BecauseOf(because, becauseArgs).FailWith("Execution of " + execution.ActionDescription.EscapePlaceholders() + " should be within {0} from {1}{reason}, but it required " + (flag ? "more than " : "exactly ") + "{2}.", precision, expectedDuration, timeSpan2);
			return new AndConstraint<ExecutionTimeAssertions>(this);
		}

		public override bool Equals(object obj)
		{
			throw new NotSupportedException("Equals is not part of Fluent Assertions. Did you mean BeLessThanOrEqualTo() or BeGreaterThanOrEqualTo() instead?");
		}
	}
}
