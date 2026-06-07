using System;
using System.Collections.Generic;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class SequenceEqualAsync<T> : TaskObserverBase<T, bool>
	{
		internal sealed class SequenceEqualAsyncObserver : Observer<T>
		{
			public Queue<T> values;

			public bool IsCompleted;

			public SequenceEqualAsyncObserver(SequenceEqualAsync<T> parent)
			{
				_003Cparent_003EP = parent;
				values = new Queue<T>();
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				lock (_003Cparent_003EP)
				{
					values.Enqueue(value);
					_003Cparent_003EP.CheckValues();
				}
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003Cparent_003EP.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				if (result.IsFailure)
				{
					_003Cparent_003EP.OnCompleted(result);
					return;
				}
				lock (_003Cparent_003EP)
				{
					IsCompleted = true;
					_003Cparent_003EP.CheckValues();
				}
			}
		}

		public readonly IEqualityComparer<T> equalityComparer;

		public SequenceEqualAsyncObserver leftObserver;

		public SequenceEqualAsyncObserver rightObserver;

		public SequenceEqualAsync(IEqualityComparer<T> equalityComparer, CancellationToken cancellationToken)
			: base(cancellationToken)
		{
			this.equalityComparer = equalityComparer;
			leftObserver = new SequenceEqualAsyncObserver(this);
			rightObserver = new SequenceEqualAsyncObserver(this);
		}

		protected override void OnNextCore(T value)
		{
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
		}

		protected override void DisposeCore()
		{
			leftObserver.Dispose();
			rightObserver.Dispose();
		}

		private void CheckValues()
		{
			while (leftObserver.values.Count != 0 && rightObserver.values.Count != 0)
			{
				T x = leftObserver.values.Dequeue();
				T y = rightObserver.values.Dequeue();
				if (!equalityComparer.Equals(x, y))
				{
					TrySetResult(result: false);
					return;
				}
			}
			if (leftObserver.IsCompleted && rightObserver.IsCompleted)
			{
				if (leftObserver.values.Count == 0 && rightObserver.values.Count == 0)
				{
					TrySetResult(result: true);
				}
				else
				{
					TrySetResult(result: false);
				}
			}
		}
	}
}
