using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class SumFloatAsync : TaskObserverBase<float, float>
	{
		private float sum;

		public SumFloatAsync(CancellationToken cancellationToken)
			: base(cancellationToken)
		{
		}

		protected override void OnNextCore(float value)
		{
			sum += value;
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
	internal sealed class SumFloatAsync<TSource> : TaskObserverBase<TSource, float>
	{
		private float sum;

		public SumFloatAsync(Func<TSource, float> selector, CancellationToken cancellationToken)
		{
			_003Cselector_003EP = selector;
			base._002Ector(cancellationToken);
		}

		protected override void OnNextCore(TSource value)
		{
			float num = _003Cselector_003EP(value);
			sum += num;
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
