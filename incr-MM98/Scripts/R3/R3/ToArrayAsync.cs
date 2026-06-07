using System;
using System.Collections.Generic;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class ToArrayAsync<T> : TaskObserverBase<T, T[]>
	{
		private readonly List<T> buffer = new List<T>();

		public ToArrayAsync(CancellationToken cancellationToken)
			: base(cancellationToken)
		{
		}

		protected override void OnNextCore(T value)
		{
			buffer.Add(value);
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
				TrySetResult(buffer.ToArray());
			}
		}
	}
}
