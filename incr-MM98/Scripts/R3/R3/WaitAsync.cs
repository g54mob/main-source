using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class WaitAsync<T> : TaskObserverBase<T, Unit>
	{
		public WaitAsync(CancellationToken cancellationToken)
			: base(cancellationToken)
		{
		}

		protected override void OnNextCore(T value)
		{
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
				TrySetResult(Unit.Default);
			}
		}
	}
}
