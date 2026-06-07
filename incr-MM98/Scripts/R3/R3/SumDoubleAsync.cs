using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class SumDoubleAsync : TaskObserverBase<double, double>
	{
		private double sum;

		public SumDoubleAsync(CancellationToken cancellationToken)
			: base(cancellationToken)
		{
		}

		protected override void OnNextCore(double value)
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
	internal sealed class SumDoubleAsync<TSource> : TaskObserverBase<TSource, double>
	{
		private double sum;

		public SumDoubleAsync(Func<TSource, double> selector, CancellationToken cancellationToken)
		{
			_003Cselector_003EP = selector;
			base._002Ector(cancellationToken);
		}

		protected override void OnNextCore(TSource value)
		{
			double num = _003Cselector_003EP(value);
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
