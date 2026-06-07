using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class AverageFloatAsync : TaskObserverBase<float, double>
	{
		private float sum;

		private int count;

		public AverageFloatAsync(CancellationToken cancellationToken)
			: base(cancellationToken)
		{
		}

		protected override void OnNextCore(float value)
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
	internal sealed class AverageFloatAsync<TSource> : TaskObserverBase<TSource, double>
	{
		private float sum;

		private int count;

		public AverageFloatAsync(Func<TSource, float> selector, CancellationToken cancellationToken)
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
