using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class LongCountAsync<T> : TaskObserverBase<T, long>
	{
		private long count;

		public LongCountAsync(CancellationToken cancellationToken)
			: base(cancellationToken)
		{
		}

		protected override void OnNextCore(T _)
		{
			checked
			{
				count++;
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
