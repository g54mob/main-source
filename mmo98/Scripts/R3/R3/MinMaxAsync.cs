using System;
using System.Collections.Generic;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class MinMaxAsync<T> : TaskObserverBase<T, (T, T)>
	{
		private T min;

		private T max;

		private bool hasValue;

		public MinMaxAsync(IComparer<T> comparer, CancellationToken cancellationToken)
		{
			_003Ccomparer_003EP = comparer;
			base._002Ector(cancellationToken);
		}

		protected override void OnNextCore(T value)
		{
			if (!hasValue)
			{
				min = value;
				max = value;
				hasValue = true;
				return;
			}
			if (_003Ccomparer_003EP.Compare(value, min) < 0)
			{
				min = value;
			}
			if (_003Ccomparer_003EP.Compare(value, max) > 0)
			{
				max = value;
			}
			hasValue = true;
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
				TrySetResult((min, max));
			}
			else
			{
				TrySetException(new InvalidOperationException("Sequence contains no elements"));
			}
		}
	}
	internal sealed class MinMaxAsync<TSource, TResult> : TaskObserverBase<TSource, (TResult, TResult)>
	{
		private TResult min;

		private TResult max;

		private bool hasValue;

		public MinMaxAsync(Func<TSource, TResult> selector, IComparer<TResult> comparer, CancellationToken cancellationToken)
		{
			_003Cselector_003EP = selector;
			_003Ccomparer_003EP = comparer;
			base._002Ector(cancellationToken);
		}

		protected override void OnNextCore(TSource value)
		{
			TResult x = _003Cselector_003EP(value);
			if (!hasValue)
			{
				min = x;
				max = x;
				hasValue = true;
				return;
			}
			if (_003Ccomparer_003EP.Compare(x, min) < 0)
			{
				min = x;
			}
			if (_003Ccomparer_003EP.Compare(x, max) > 0)
			{
				max = x;
			}
			hasValue = true;
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
				TrySetResult((min, max));
			}
			else
			{
				TrySetException(new InvalidOperationException("Sequence contains no elements"));
			}
		}
	}
}
