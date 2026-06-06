using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class AverageInt64Async : TaskObserverBase<long, double>
	{
		private long sum;

		private int count;

		public AverageInt64Async(CancellationToken cancellationToken)
			: base(cancellationToken)
		{
		}

		protected override void OnNextCore(long value)
		{
			sum += value;
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
			else if (count <= 0)
			{
				TrySetException(new InvalidOperationException("Sequence contains no elements"));
			}
			else
			{
				TrySetResult((double)sum / (double)count);
			}
		}
	}
	internal sealed class AverageInt64Async<TSource> : TaskObserverBase<TSource, double>
	{
		private long sum;

		private int count;

		public AverageInt64Async(Func<TSource, long> selector, CancellationToken cancellationToken)
		{
			_003Cselector_003EP = selector;
			base._002Ector(cancellationToken);
		}

		protected override void OnNextCore(TSource value)
		{
			sum += _003Cselector_003EP(value);
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
			else if (count <= 0)
			{
				TrySetException(new InvalidOperationException("Sequence contains no elements"));
			}
			else
			{
				TrySetResult((double)sum / (double)count);
			}
		}
	}
}
