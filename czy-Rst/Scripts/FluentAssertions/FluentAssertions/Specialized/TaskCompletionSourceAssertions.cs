using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace FluentAssertions.Specialized
{
	public class TaskCompletionSourceAssertions<T> : TaskCompletionSourceAssertionsBase
	{
		private readonly AssertionChain assertionChain;

		private readonly TaskCompletionSource<T> subject;

		public TaskCompletionSourceAssertions(TaskCompletionSource<T> tcs, AssertionChain assertionChain)
			: this(tcs, assertionChain, (IClock)new Clock())
		{
			this.assertionChain = assertionChain;
		}

		public TaskCompletionSourceAssertions(TaskCompletionSource<T> tcs, AssertionChain assertionChain, IClock clock)
			: base(clock)
		{
			subject = tcs;
			this.assertionChain = assertionChain;
		}

		public async Task<AndWhichConstraint<TaskCompletionSourceAssertions<T>, T>> CompleteWithinAsync(TimeSpan timeSpan, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(subject != null).BecauseOf(because, becauseArgs).FailWith("Expected {context} to complete within {0}{reason}, but found <null>.", timeSpan);
			if (assertionChain.Succeeded)
			{
				bool condition = await CompletesWithinTimeoutAsync(subject.Task, timeSpan);
				assertionChain.ForCondition(condition).BecauseOf(because, becauseArgs).FailWith("Expected {context:task} to complete within {0}{reason}.", timeSpan);
				T val = (subject.Task.IsCompleted ? subject.Task.Result : default(T));
				return new AndWhichConstraint<TaskCompletionSourceAssertions<T>, T>(this, val, assertionChain, ".Result");
			}
			return new AndWhichConstraint<TaskCompletionSourceAssertions<T>, T>(this, default(T));
		}

		public async Task<AndConstraint<TaskCompletionSourceAssertions<T>>> NotCompleteWithinAsync(TimeSpan timeSpan, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(subject != null).BecauseOf(because, becauseArgs).FailWith("Did not expect {context} to complete within {0}{reason}, but found <null>.", timeSpan);
			if (assertionChain.Succeeded)
			{
				bool flag = await CompletesWithinTimeoutAsync(subject.Task, timeSpan);
				assertionChain.ForCondition(!flag).BecauseOf(because, becauseArgs).FailWith("Did not expect {context:task} to complete within {0}{reason}.", timeSpan);
			}
			return new AndConstraint<TaskCompletionSourceAssertions<T>>(this);
		}
	}
}
