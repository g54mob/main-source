using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class SumInt64Async : TaskObserverBase<long, long>
	{
		private long sum;

		public SumInt64Async(CancellationToken cancellationToken)
			: base(cancellationToken)
		{
		}

		protected override void OnNextCore(long value)
		{
			checked
			{
				sum += value;
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
				TrySetResult(sum);
			}
		}
	}
	internal sealed class SumInt64Async<TSource> : TaskObserverBase<TSource, long>
	{
		private long sum;

		public SumInt64Async(Func<TSource, long> selector, CancellationToken cancellationToken)
		{
			_003Cselector_003EP = selector;
			base._002Ector(cancellationToken);
		}

		protected override void OnNextCore(TSource value)
		{
			long num = _003Cselector_003EP(value);
			checked
			{
				sum += num;
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
				TrySetResult(sum);
			}
		}
	}
}
