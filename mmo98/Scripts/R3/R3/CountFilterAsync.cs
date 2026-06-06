using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class CountFilterAsync<T> : TaskObserverBase<T, int>
	{
		private int count;

		public CountFilterAsync(Func<T, bool> predicate, CancellationToken cancellationToken)
		{
			_003Cpredicate_003EP = predicate;
			base._002Ector(cancellationToken);
		}

		protected override void OnNextCore(T value)
		{
			checked
			{
				if (_003Cpredicate_003EP(value))
				{
					count++;
				}
			}
		}

		protected override void OnErrorResumeCore(Exception error)
		{
			TrySetException(error);
		}

		protected override void OnCompletedCore(Result result)
		{
			if (result.IsFailure)
			{
				TrySetException(result.Exception);
			}
			else
			{
				TrySetResult(count);
			}
		}
	}
}
