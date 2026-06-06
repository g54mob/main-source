using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class ElementAtAsync<T> : TaskObserverBase<T, T>
	{
		private int count;

		public ElementAtAsync(int index, bool useDefaultValue, T? defaultValue, CancellationToken cancellationToken)
		{
			_003Cindex_003EP = index;
			_003CuseDefaultValue_003EP = useDefaultValue;
			_003CdefaultValue_003EP = defaultValue;
			base._002Ector(cancellationToken);
		}

		protected override void OnNextCore(T value)
		{
			if (count++ == _003Cindex_003EP)
			{
				TrySetResult(value);
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
			else if (_003CuseDefaultValue_003EP)
			{
				TrySetResult(_003CdefaultValue_003EP);
			}
			else
			{
				TrySetException(new ArgumentOutOfRangeException("index"));
			}
		}
	}
}
