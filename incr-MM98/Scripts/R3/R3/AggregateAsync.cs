using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class AggregateAsync<T> : TaskObserverBase<T, T>
	{
		private T currentResult;

		private bool hasValue;

		public AggregateAsync(Func<T, T, T> func, CancellationToken cancellationToken)
		{
			_003Cfunc_003EP = func;
			base._002Ector(cancellationToken);
		}

		protected override void OnNextCore(T value)
		{
			if (hasValue)
			{
				currentResult = _003Cfunc_003EP(currentResult, value);
				return;
			}
			currentResult = value;
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
				TrySetResult(currentResult);
			}
			else
			{
				TrySetException(new InvalidOperationException("Sequence contains no elements"));
			}
		}
	}
	internal sealed class AggregateAsync<T, TResult> : TaskObserverBase<T, TResult>
	{
		private TResult currentValue;

		public AggregateAsync(TResult seed, Func<TResult, T, TResult> func, CancellationToken cancellationToken)
		{
			_003Cfunc_003EP = func;
			currentValue = seed;
			base._002Ector(cancellationToken);
		}

		protected override void OnNextCore(T value)
		{
			currentValue = _003Cfunc_003EP(currentValue, value);
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
				TrySetResult(currentValue);
			}
		}
	}
	internal sealed class AggregateAsync<T, TAccumulate, TResult> : TaskObserverBase<T, TResult>
	{
		private TAccumulate value;

		public AggregateAsync(TAccumulate seed, Func<TAccumulate, T, TAccumulate> func, Func<TAccumulate, TResult> resultSelector, CancellationToken cancellationToken)
		{
			_003Cfunc_003EP = func;
			_003CresultSelector_003EP = resultSelector;
			value = seed;
			base._002Ector(cancellationToken);
		}

		protected override void OnNextCore(T value)
		{
			this.value = _003Cfunc_003EP(this.value, value);
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
				return;
			}
			try
			{
				TResult result2 = _003CresultSelector_003EP(value);
				TrySetResult(result2);
			}
			catch (Exception exception)
			{
				TrySetException(exception);
			}
		}
	}
}
