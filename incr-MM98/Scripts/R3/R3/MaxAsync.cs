using System;
using System.Collections.Generic;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class MaxAsync<T> : TaskObserverBase<T, T>
	{
		private T current;

		private bool hasValue;

		public MaxAsync(IComparer<T> comparer, CancellationToken cancellation)
		{
			_003Ccomparer_003EP = comparer;
			base._002Ector(cancellation);
		}

		protected override void OnNextCore(T value)
		{
			if (!hasValue)
			{
				hasValue = true;
				current = value;
			}
			else if (_003Ccomparer_003EP.Compare(value, current) > 0)
			{
				current = value;
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
				TrySetResult(current);
			}
			else
			{
				TrySetException(new InvalidOperationException("Sequence contains no elements"));
			}
		}
	}
	internal sealed class MaxAsync<TSource, TResult> : TaskObserverBase<TSource, TResult>
	{
		private TResult current;

		private bool hasValue;

		public MaxAsync(Func<TSource, TResult> selector, IComparer<TResult> comparer, CancellationToken cancellation)
		{
			_003Cselector_003EP = selector;
			_003Ccomparer_003EP = comparer;
			base._002Ector(cancellation);
		}

		protected override void OnNextCore(TSource value)
		{
			TResult x = _003Cselector_003EP(value);
			if (!hasValue)
			{
				hasValue = true;
				current = x;
			}
			else if (_003Ccomparer_003EP.Compare(x, current) > 0)
			{
				current = x;
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
				TrySetResult(current);
			}
			else
			{
				TrySetException(new InvalidOperationException("Sequence contains no elements"));
			}
		}
	}
}
