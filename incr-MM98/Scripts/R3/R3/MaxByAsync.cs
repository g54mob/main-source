using System;
using System.Collections.Generic;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class MaxByAsync<T, TKey> : TaskObserverBase<T, T>
	{
		private T? latestValue;

		private TKey? latestKey;

		private bool hasValue;

		public MaxByAsync(Func<T, TKey> keySelector, IComparer<TKey> comparer, CancellationToken cancellationToken)
		{
			_003CkeySelector_003EP = keySelector;
			_003Ccomparer_003EP = comparer;
			base._002Ector(cancellationToken);
		}

		protected override void OnNextCore(T value)
		{
			if (!hasValue)
			{
				hasValue = true;
				latestValue = value;
				latestKey = _003CkeySelector_003EP(value);
				return;
			}
			TKey x = _003CkeySelector_003EP(value);
			if (_003Ccomparer_003EP.Compare(x, latestKey) > 0)
			{
				latestValue = value;
				latestKey = x;
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
			else if (hasValue)
			{
				TrySetResult(latestValue);
			}
			else
			{
				TrySetException(new InvalidOperationException("no elements"));
			}
		}
	}
}
