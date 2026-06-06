using System;
using System.Collections.Generic;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class ToHashSetAsync<T> : TaskObserverBase<T, HashSet<T>>
	{
		private readonly HashSet<T> hashSet;

		public ToHashSetAsync(IEqualityComparer<T>? comparer, CancellationToken cancellationToken)
		{
			hashSet = new HashSet<T>(comparer);
			base._002Ector(cancellationToken);
		}

		protected override void OnNextCore(T value)
		{
			hashSet.Add(value);
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
				TrySetResult(hashSet);
			}
		}
	}
}
