using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace FluentAssertions.Specialized
{
	public class GenericAsyncFunctionAssertions<TResult> : AsyncFunctionAssertions<Task<TResult>, GenericAsyncFunctionAssertions<TResult>>
	{
		private readonly AssertionChain assertionChain;

		public GenericAsyncFunctionAssertions(Func<Task<TResult>> subject, IExtractExceptions extractor, AssertionChain assertionChain)
			: this(subject, extractor, assertionChain, (IClock)new Clock())
		{
			this.assertionChain = assertionChain;
		}

		public GenericAsyncFunctionAssertions(Func<Task<TResult>> subject, IExtractExceptions extractor, AssertionChain assertionChain, IClock clock)
			: base(subject, extractor, assertionChain, clock)
		{
			this.assertionChain = assertionChain;
		}

		public async Task<AndWhichConstraint<GenericAsyncFunctionAssertions<TResult>, TResult>> CompleteWithinAsync(TimeSpan timeSpan, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Expected {context} to complete within {0}{reason}, but found <null>.", timeSpan);
			if (assertionChain.Succeeded)
			{
				var (task, timeSpan2) = InvokeWithTimer(timeSpan);
				assertionChain.ForCondition(timeSpan2 >= TimeSpan.Zero).BecauseOf(because, becauseArgs).FailWith("Expected {context:task} to complete within {0}{reason}.", timeSpan);
				if (assertionChain.Succeeded)
				{
					bool condition = await CompletesWithinTimeoutAsync(task, timeSpan2, (Task _) => Task.CompletedTask);
					assertionChain.ForCondition(condition).BecauseOf(because, becauseArgs).FailWith("Expected {context:task} to complete within {0}{reason}.", timeSpan);
				}
				TResult subject = (assertionChain.Succeeded ? task.Result : default(TResult));
				return new AndWhichConstraint<GenericAsyncFunctionAssertions<TResult>, TResult>(this, subject, assertionChain, ".Result");
			}
			return new AndWhichConstraint<GenericAsyncFunctionAssertions<TResult>, TResult>(this, default(TResult));
		}

		public async Task<AndWhichConstraint<GenericAsyncFunctionAssertions<TResult>, TResult>> NotThrowAsync([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Expected {context} not to throw{reason}, but found <null>.");
			if (assertionChain.Succeeded)
			{
				try
				{
					return new AndWhichConstraint<GenericAsyncFunctionAssertions<TResult>, TResult>(this, await base.Subject(), assertionChain, ".Result");
				}
				catch (Exception exception)
				{
					NotThrowInternal(exception, because, becauseArgs);
				}
			}
			return new AndWhichConstraint<GenericAsyncFunctionAssertions<TResult>, TResult>(this, default(TResult));
		}

		public Task<AndWhichConstraint<GenericAsyncFunctionAssertions<TResult>, TResult>> NotThrowAfterAsync(TimeSpan waitTime, TimeSpan pollInterval, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNegative(waitTime, "waitTime");
			Guard.ThrowIfArgumentIsNegative(pollInterval, "pollInterval");
			assertionChain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Expected {context} not to throw any exceptions after {0}{reason}, but found <null>.", waitTime);
			if (assertionChain.Succeeded)
			{
				return AssertionTaskAsync();
			}
			return Task.FromResult(new AndWhichConstraint<GenericAsyncFunctionAssertions<TResult>, TResult>(this, default(TResult)));
			async Task<AndWhichConstraint<GenericAsyncFunctionAssertions<TResult>, TResult>> AssertionTaskAsync()
			{
				TimeSpan? invocationEndTime = null;
				Exception exception = null;
				ITimer timer = base.Clock.StartTimer();
				while (!invocationEndTime.HasValue || invocationEndTime < waitTime)
				{
					try
					{
						TResult subject = await base.Subject();
						return new AndWhichConstraint<GenericAsyncFunctionAssertions<TResult>, TResult>(this, subject, assertionChain, ".Result");
					}
					catch (Exception ex)
					{
						exception = ex;
						await base.Clock.DelayAsync(pollInterval, CancellationToken.None);
						invocationEndTime = timer.Elapsed;
					}
				}
				assertionChain.BecauseOf(because, becauseArgs).FailWith("Did not expect any exceptions after {0}{reason}, but found {1}.", waitTime, exception);
				return new AndWhichConstraint<GenericAsyncFunctionAssertions<TResult>, TResult>(this, default(TResult));
			}
		}
	}
}
