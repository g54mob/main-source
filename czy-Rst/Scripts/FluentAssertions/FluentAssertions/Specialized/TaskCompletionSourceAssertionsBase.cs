using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions.Common;

namespace FluentAssertions.Specialized
{
	public class TaskCompletionSourceAssertionsBase
	{
		private protected IClock Clock { get; }

		protected TaskCompletionSourceAssertionsBase(IClock clock)
		{
			Clock = clock ?? throw new ArgumentNullException("clock");
		}

		public override bool Equals(object obj)
		{
			throw new NotSupportedException("Equals is not part of Fluent Assertions. Did you mean CompleteWithinAsync() instead?");
		}

		private protected async Task<bool> CompletesWithinTimeoutAsync(Task target, TimeSpan remainingTime)
		{
			using CancellationTokenSource timeoutCancellationTokenSource = new CancellationTokenSource();
			if (await Task.WhenAny(target, Clock.DelayAsync(remainingTime, timeoutCancellationTokenSource.Token)) != target)
			{
				return false;
			}
			timeoutCancellationTokenSource.Cancel();
			return true;
		}
	}
}
