using System;
using System.Collections.Concurrent;

namespace R3
{
	internal sealed class ObserveOnThreadPool<T> : Observable<T>
	{
		private sealed class _ObserveOn : Observer<T>, IThreadPoolWorkItem
		{
			private Observer<T> observer;

			private ConcurrentQueue<Notification<T>> q;

			private bool running;

			protected override bool AutoDisposeOnCompleted => false;

			public _ObserveOn(Observer<T> observer)
			{
				this.observer = observer;
				q = new ConcurrentQueue<Notification<T>>();
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				q.Enqueue(new Notification<T>(value));
				TryStartWorker();
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				q.Enqueue(new Notification<T>(error));
				TryStartWorker();
			}

			protected override void OnCompletedCore(Result result)
			{
				q.Enqueue(new Notification<T>(result));
				TryStartWorker();
			}

			private void TryStartWorker()
			{
				lock (q)
				{
					if (!running)
					{
						running = true;
						ThreadPool.UnsafeQueueUserWorkItem(this, preferLocal: false);
					}
				}
			}

			void IThreadPoolWorkItem.Execute()
			{
				while (true)
				{
					if (q.TryDequeue(out var result))
					{
						switch (result.Kind)
						{
						case NotificationKind.OnNext:
							observer.OnNext(result.Value);
							break;
						case NotificationKind.OnErrorResume:
							observer.OnErrorResume(result.Error);
							break;
						case NotificationKind.OnCompleted:
							try
							{
								observer.OnCompleted(result.Result);
							}
							finally
							{
								Dispose();
							}
							break;
						}
						continue;
					}
					lock (q)
					{
						if (q.Count != 0)
						{
							continue;
						}
						running = false;
						break;
					}
				}
			}
		}

		public ObserveOnThreadPool(Observable<T> source)
		{
			_003Csource_003EP = source;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _ObserveOn(observer));
		}
	}
}
