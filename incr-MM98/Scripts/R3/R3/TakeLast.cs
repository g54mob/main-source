using System;
using System.Collections.Generic;

namespace R3
{
	internal sealed class TakeLast<T> : Observable<T>
	{
		private sealed class _TakeLast : Observer<T>, IDisposable
		{
			private Queue<T> queue;

			private bool takeCompleted;

			public _TakeLast(Observer<T> observer, int count)
			{
				_003Cobserver_003EP = observer;
				_003Ccount_003EP = count;
				queue = new Queue<T>(_003Ccount_003EP);
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				lock (queue)
				{
					if (!takeCompleted)
					{
						if (queue.Count == _003Ccount_003EP && queue.Count != 0)
						{
							queue.Dequeue();
						}
						queue.Enqueue(value);
					}
				}
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003Cobserver_003EP.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				if (result.IsFailure)
				{
					_003Cobserver_003EP.OnCompleted(result);
					return;
				}
				lock (queue)
				{
					takeCompleted = true;
					foreach (T item in queue)
					{
						_003Cobserver_003EP.OnNext(item);
						if (base.IsDisposed)
						{
							return;
						}
					}
				}
				_003Cobserver_003EP.OnCompleted();
			}

			protected override void DisposeCore()
			{
				lock (queue)
				{
					queue.Clear();
				}
			}
		}

		public TakeLast(Observable<T> source, int count)
		{
			_003Csource_003EP = source;
			_003Ccount_003EP = count;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _TakeLast(observer, _003Ccount_003EP));
		}
	}
}
