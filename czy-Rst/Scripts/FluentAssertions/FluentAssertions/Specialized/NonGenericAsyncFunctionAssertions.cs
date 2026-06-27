using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace FluentAssertions.Specialized
{
	public class NonGenericAsyncFunctionAssertions : AsyncFunctionAssertions<Task, NonGenericAsyncFunctionAssertions>
	{
		private readonly AssertionChain assertionChain;

		public NonGenericAsyncFunctionAssertions(Func<Task> subject, IExtractExceptions extractor, AssertionChain assertionChain)
			: this(subject, extractor, assertionChain, new Clock())
		{
			this.assertionChain = assertionChain;
		}

		public NonGenericAsyncFunctionAssertions(Func<Task> subject, IExtractExceptions extractor, AssertionChain assertionChain, IClock clock)
			: base(subject, extractor, assertionChain, clock)
		{
			this.assertionChain = assertionChain;
		}

		public async Task<AndConstraint<NonGenericAsyncFunctionAssertions>> CompleteWithinAsync(TimeSpan timeSpan, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Expected {context:task} to complete within {0}{reason}, but found <null>.", timeSpan);
			if (assertionChain.Succeeded)
			{
				var (target, timeSpan2) = InvokeWithTimer(timeSpan);
				assertionChain.ForCondition(timeSpan2 >= TimeSpan.Zero).BecauseOf(because, becauseArgs).FailWith("Expected {context:task} to complete within {0}{reason}.", timeSpan);
				if (assertionChain.Succeeded)
				{
					bool condition = await CompletesWithinTimeoutAsync(target, timeSpan2, (Task _) => Task.CompletedTask);
					assertionChain.ForCondition(condition).BecauseOf(because, becauseArgs).FailWith("Expected {context:task} to complete within {0}{reason}.", timeSpan);
				}
			}
			return new AndConstraint<NonGenericAsyncFunctionAssertions>(this);
		}

		public async Task<AndConstraint<NonGenericAsyncFunctionAssertions>> NotThrowAsync([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Expected {context} not to throw{reason}, but found <null>.");
			if (assertionChain.Succeeded)
			{
				try
				{
					await base.Subject();
				}
				catch (Exception exception)
				{
					return NotThrowInternal(exception, because, becauseArgs);
				}
			}
			return new AndConstraint<NonGenericAsyncFunctionAssertions>(this);
		}

		public Task<AndConstraint<NonGenericAsyncFunctionAssertions>> NotThrowAfterAsync(TimeSpan waitTime, TimeSpan pollInterval, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNegative(waitTime, "waitTime");
			Guard.ThrowIfArgumentIsNegative(pollInterval, "pollInterval");
			assertionChain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Expected {context} not to throw any exceptions after {0}{reason}, but found <null>.", waitTime);
			if (assertionChain.Succeeded)
			{
				return AssertionTaskAsync();
			}
			return Task.FromResult(new AndConstraint<NonGenericAsyncFunctionAssertions>(this));
			async Task<AndConstraint<NonGenericAsyncFunctionAssertions>> AssertionTaskAsync()
			{
				TimeSpan? timeSpan = null;
				Exception exception = null;
				ITimer timer = base.Clock.StartTimer();
				while (!timeSpan.HasValue || timeSpan < waitTime)
				{
					exception = await AsyncFunctionAssertions<Task, NonGenericAsyncFunctionAssertions>.InvokeWithInterceptionAsync(base.Subject);
					if (exception == null)
					{
						return new AndConstraint<NonGenericAsyncFunctionAssertions>(this);
					}
					await base.Clock.DelayAsync(pollInterval, CancellationToken.None);
					timeSpan = timer.Elapsed;
				}
				assertionChain.BecauseOf(because, becauseArgs).FailWith("Did not expect any exceptions after {0}{reason}, but found {1}.", waitTime, exception);
				return new AndConstraint<NonGenericAsyncFunctionAssertions>(this);
			}
		}
	}
}
