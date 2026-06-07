using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class SumInt32Async : TaskObserverBase<int, int>
	{
		private int sum;

		public SumInt32Async(CancellationToken cancellationToken)
			: base(cancellationToken)
		{
		}

		protected override void OnNextCore(int value)
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
	internal sealed class SumInt32Async<TSource> : TaskObserverBase<TSource, int>
	{
		private int sum;

		public SumInt32Async(Func<TSource, int> selector, CancellationToken cancellationToken)
		{
			_003Cselector_003EP = selector;
			base._002Ector(cancellationToken);
		}

		protected override void OnNextCore(TSource value)
		{
			int num = _003Cselector_003EP(value);
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
