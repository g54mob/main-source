using System;
using System.Collections.Generic;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class ContainsAsync<T> : TaskObserverBase<T, bool>
	{
		public ContainsAsync(T compareValue, IEqualityComparer<T> equalityComparer, CancellationToken cancellationToken)
		{
			_003CcompareValue_003EP = compareValue;
			_003CequalityComparer_003EP = equalityComparer;
			base._002Ector(cancellationToken);
		}

		protected override void OnNextCore(T value)
		{
			if (_003CequalityComparer_003EP.Equals(value, _003CcompareValue_003EP))
			{
				TrySetResult(result: true);
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
				TrySetResult(result: false);
			}
		}
	}
}
