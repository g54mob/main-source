using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class FirstLastSingle<T> : TaskObserverBase<T, T>
	{
		private bool hasValue;

		private T? latestValue;

		public FirstLastSingle(FirstLastSingleOperation operation, bool useDefaultIfEmpty, T? defaultValue, Func<T, bool> predicate, CancellationToken cancellationToken)
		{
			_003Coperation_003EP = operation;
			_003CuseDefaultIfEmpty_003EP = useDefaultIfEmpty;
			_003Cpredicate_003EP = predicate;
			latestValue = defaultValue;
			base._002Ector(cancellationToken);
		}

		protected override void OnNextCore(T value)
		{
			if (!_003Cpredicate_003EP(value))
			{
				return;
			}
			if (_003Coperation_003EP == FirstLastSingleOperation.Single && hasValue)
			{
				TrySetException(new InvalidOperationException("Sequence contains more than one element."));
				return;
			}
			hasValue = true;
			if (_003Coperation_003EP == FirstLastSingleOperation.First)
			{
				TrySetResult(value);
			}
			else
			{
				latestValue = value;
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
			else if (hasValue || _003CuseDefaultIfEmpty_003EP)
			{
				TrySetResult(latestValue);
			}
			else
			{
				TrySetException(new InvalidOperationException("Sequence contains no elements."));
			}
		}
	}
}
