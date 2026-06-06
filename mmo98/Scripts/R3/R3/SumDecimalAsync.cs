using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class SumDecimalAsync : TaskObserverBase<decimal, decimal>
	{
		private decimal sum;

		public SumDecimalAsync(CancellationToken cancellationToken)
			: base(cancellationToken)
		{
		}

		protected override void OnNextCore(decimal value)
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
	internal sealed class SumDecimalAsync<TSource> : TaskObserverBase<TSource, decimal>
	{
		private decimal sum;

		public SumDecimalAsync(Func<TSource, decimal> selector, CancellationToken cancellationToken)
		{
			_003Cselector_003EP = selector;
			base._002Ector(cancellationToken);
		}

		protected override void OnNextCore(TSource value)
		{
			decimal num = _003Cselector_003EP(value);
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
