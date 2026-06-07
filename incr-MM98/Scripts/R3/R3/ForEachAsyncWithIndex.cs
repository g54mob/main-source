using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class ForEachAsyncWithIndex<T> : TaskObserverBase<T, Unit>
	{
		private int index;

		public ForEachAsyncWithIndex(Action<T, int> action, CancellationToken cancellationToken)
		{
			_003Caction_003EP = action;
			base._002Ector(cancellationToken);
		}

		protected override void OnNextCore(T value)
		{
			_003Caction_003EP(value, index++);
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
				TrySetResult(default(Unit));
			}
		}
	}
}
