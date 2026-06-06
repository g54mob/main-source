using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class AllAsync<T> : TaskObserverBase<T, bool>
	{
		public AllAsync(Func<T, bool> predicate, CancellationToken cancellationToken)
		{
			_003Cpredicate_003EP = predicate;
			base._002Ector(cancellationToken);
		}

		protected override void OnNextCore(T value)
		{
			if (!_003Cpredicate_003EP(value))
			{
				TrySetResult(result: false);
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
				TrySetResult(result: true);
			}
		}
	}
}
