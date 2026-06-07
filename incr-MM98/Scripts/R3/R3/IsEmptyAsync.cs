using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class IsEmptyAsync<T> : TaskObserverBase<T, bool>
	{
		public IsEmptyAsync(CancellationToken cancellationToken)
			: base(cancellationToken)
		{
		}

		protected override void OnNextCore(T value)
		{
			TrySetResult(result: false);
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
