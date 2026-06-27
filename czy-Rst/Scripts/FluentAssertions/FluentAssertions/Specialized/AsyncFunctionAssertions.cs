using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace FluentAssertions.Specialized
{
	[DebuggerNonUserCode]
	public class AsyncFunctionAssertions<TTask, TAssertions> : DelegateAssertionsBase<Func<TTask>, TAssertions> where TTask : Task where TAssertions : AsyncFunctionAssertions<TTask, TAssertions>
	{
		private readonly AssertionChain assertionChain;

		protected override string Identifier => "async function";

		protected AsyncFunctionAssertions(Func<TTask> subject, IExtractExceptions extractor, AssertionChain assertionChain, IClock clock)
			: base(subject, extractor, assertionChain, clock)
		{
			this.assertionChain = assertionChain;
		}

		public async Task<AndConstraint<TAssertions>> NotCompleteWithinAsync(TimeSpan timeSpan, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Did not expect {context:task} to complete within {0}{reason}, but found <null>.", timeSpan);
			if (assertionChain.Succeeded)
			{
				Task target;
				TimeSpan timeSpan2;
				(target, timeSpan2) = InvokeWithTimer(timeSpan);
				if (timeSpan2 >= TimeSpan.Zero)
				{
					bool flag = await CompletesWithinTimeoutAsync(target, timeSpan2, (Task _) => Task.CompletedTask);
					assertionChain.ForCondition(!flag).BecauseOf(because, becauseArgs).FailWith("Did not expect {context:task} to complete within {0}{reason}.", timeSpan);
				}
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public async Task<ExceptionAssertions<TException>> ThrowExactlyAsync<TException>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TException : Exception
		{
			Type expectedType = typeof(TException);
			assertionChain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Expected {context} to throw exactly {0}{reason}, but found <null>.", expectedType);
			if (assertionChain.Succeeded)
			{
				Exception ex = await InvokeWithInterceptionAsync(base.Subject);
				assertionChain.ForCondition(ex != null).BecauseOf(because, becauseArgs).FailWith("Expected {0}{reason}, but no exception was thrown.", expectedType);
				if (assertionChain.Succeeded)
				{
					AssertionExtensions.Should(ex).BeOfType(expectedType, because, becauseArgs);
				}
				return new ExceptionAssertions<TException>(new _003C_003Ez__ReadOnlySingleElementList<TException>(ex as TException), assertionChain);
			}
			return new ExceptionAssertions<TException>(Array.Empty<TException>(), assertionChain);
		}

		public async Task<ExceptionAssertions<TException>> ThrowAsync<TException>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TException : Exception
		{
			assertionChain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Expected {context} to throw {0}{reason}, but found <null>.", typeof(TException));
			if (assertionChain.Succeeded)
			{
				return ThrowInternal<TException>(await InvokeWithInterceptionAsync(base.Subject), because, becauseArgs);
			}
			return new ExceptionAssertions<TException>(Array.Empty<TException>(), assertionChain);
		}

		public async Task<ExceptionAssertions<TException>> ThrowWithinAsync<TException>(TimeSpan timeSpan, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TException : Exception
		{
			assertionChain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Expected {context} to throw {0} within {1}{reason}, but found <null>.", typeof(TException), timeSpan);
			if (assertionChain.Succeeded)
			{
				return AssertThrows<TException>(await InvokeWithInterceptionAsync(timeSpan), timeSpan, because, becauseArgs);
			}
			return new ExceptionAssertions<TException>(Array.Empty<TException>(), assertionChain);
		}

		private ExceptionAssertions<TException> AssertThrows<TException>(Exception exception, TimeSpan timeSpan, [StringSyntax("CompositeFormat")] string because, object[] becauseArgs) where TException : Exception
		{
			TException[] expectedExceptions = base.Extractor.OfType<TException>(exception).ToArray();
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected a <{0}> to be thrown within {1}{reason}, ", typeof(TException), timeSpan, delegate(AssertionChain chain)
			{
				chain.ForCondition(exception != null).FailWith("but no exception was thrown.").Then.ForCondition(expectedExceptions.Length != 0).FailWith("but found <{0}>:" + Environment.NewLine + "{1}.", exception?.GetType(), exception);
			});
			return new ExceptionAssertions<TException>(expectedExceptions, assertionChain);
		}

		private async Task<Exception> InvokeWithInterceptionAsync(TimeSpan timeout)
		{
			try
			{
				using (CallerIdentifier.OnlyOneFluentAssertionScopeOnCallStack() ? CallerIdentifier.OverrideStackSearchUsingCurrentScope() : null)
				{
					var (val, timeSpan) = InvokeWithTimer(timeout);
					if (timeSpan < TimeSpan.Zero)
					{
						return null;
					}
					if (val.IsFaulted)
					{
						return val.Exception.GetBaseException();
					}
					await CompletesWithinTimeoutAsync(val, timeSpan, (Task cancelledTask) => cancelledTask);
				}
				return null;
			}
			catch (Exception result)
			{
				return result;
			}
		}

		public async Task<AndConstraint<TAssertions>> NotThrowAsync<TException>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TException : Exception
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
					return NotThrowInternal<TException>(exception, because, becauseArgs);
				}
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		private protected (TTask result, TimeSpan remainingTime) InvokeWithTimer(TimeSpan timeSpan)
		{
			ITimer timer = base.Clock.StartTimer();
			TTask item = base.Subject();
			TimeSpan item2 = timeSpan - timer.Elapsed;
			return (result: item, remainingTime: item2);
		}

		private protected async Task<bool> CompletesWithinTimeoutAsync(Task target, TimeSpan remainingTime, Func<Task, Task> onTaskCanceled)
		{
			using CancellationTokenSource delayCancellationTokenSource = new CancellationTokenSource();
			Task task = base.Clock.DelayAsync(remainingTime, delayCancellationTokenSource.Token);
			Task completedTask = await Task.WhenAny(target, task);
			if (completedTask.IsFaulted)
			{
				await completedTask;
			}
			if (completedTask != target)
			{
				return false;
			}
			if (target.IsCanceled)
			{
				await onTaskCanceled(target);
			}
			delayCancellationTokenSource.Cancel();
			return true;
		}

		private protected static async Task<Exception> InvokeWithInterceptionAsync(Func<Task> action)
		{
			try
			{
				using (CallerIdentifier.OnlyOneFluentAssertionScopeOnCallStack() ? CallerIdentifier.OverrideStackSearchUsingCurrentScope() : null)
				{
					await action();
				}
				return null;
			}
			catch (Exception result)
			{
				return result;
			}
		}
	}
}
