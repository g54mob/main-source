using System;
using System.Collections.Generic;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class ElementAtFromEndAsync<T> : TaskObserverBase<T, T>
	{
		private Queue<T> queue;

		public ElementAtFromEndAsync(int fromEndIndex, bool useDefaultValue, T? defaultValue, CancellationToken cancellationToken)
		{
			_003CfromEndIndex_003EP = fromEndIndex;
			_003CuseDefaultValue_003EP = useDefaultValue;
			_003CdefaultValue_003EP = defaultValue;
			queue = new Queue<T>(_003CfromEndIndex_003EP);
			base._002Ector(cancellationToken);
		}

		protected override void OnNextCore(T value)
		{
			if (queue.Count == _003CfromEndIndex_003EP && queue.Count != 0)
			{
				queue.Dequeue();
			}
			queue.Enqueue(value);
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
			else if (queue.Count == _003CfromEndIndex_003EP)
			{
				T result2 = queue.Dequeue();
				TrySetResult(result2);
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
