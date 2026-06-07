using System;
using System.Collections.Generic;

namespace R3
{
	internal sealed class SkipLast<T> : Observable<T>
	{
		private sealed class _SkipLast : Observer<T>, IDisposable
		{
			private Queue<T> queue;

			public _SkipLast(Observer<T> observer, int count)
			{
				_003Cobserver_003EP = observer;
				_003Ccount_003EP = count;
				queue = new Queue<T>(_003Ccount_003EP);
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				queue.Enqueue(value);
				if (queue.Count > _003Ccount_003EP)
				{
					_003Cobserver_003EP.OnNext(queue.Dequeue());
				}
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003Cobserver_003EP.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				_003Cobserver_003EP.OnCompleted(result);
			}

			protected override void DisposeCore()
			{
				queue.Clear();
			}
		}

		public SkipLast(Observable<T> source, int count)
		{
			_003Csource_003EP = source;
			_003Ccount_003EP = count;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _SkipLast(observer, _003Ccount_003EP));
		}
	}
}
