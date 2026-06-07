using System;
using System.Collections.Generic;

namespace R3
{
	internal sealed class Trampoline<T> : Observable<T>
	{
		private sealed class _Trampoline : Observer<T>
		{
			private readonly Queue<Notification<T>> queue;

			private bool running;

			protected override bool AutoDisposeOnCompleted => false;

			public _Trampoline(Observer<T> observer)
			{
				_003Cobserver_003EP = observer;
				queue = new Queue<Notification<T>>();
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				EnqueueMessage(new Notification<T>(value));
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				EnqueueMessage(new Notification<T>(error));
			}

			protected override void OnCompletedCore(Result result)
			{
				EnqueueMessage(new Notification<T>(result));
			}

			private void EnqueueMessage(Notification<T> notification)
			{
				lock (queue)
				{
					queue.Enqueue(notification);
					if (!running)
					{
						running = true;
						DrainMessages();
					}
				}
			}

			private void DrainMessages()
			{
				while (true)
				{
					Notification<T> result;
					lock (queue)
					{
						if (base.IsDisposed)
						{
							queue.Clear();
							break;
						}
						if (!queue.TryDequeue(out result))
						{
							running = false;
							break;
						}
					}
					try
					{
						switch (result.Kind)
						{
						case NotificationKind.OnNext:
							_003Cobserver_003EP.OnNext(result.Value);
							break;
						case NotificationKind.OnErrorResume:
							_003Cobserver_003EP.OnErrorResume(result.Error);
							break;
						case NotificationKind.OnCompleted:
							try
							{
								_003Cobserver_003EP.OnCompleted(result.Result);
							}
							finally
							{
								Dispose();
							}
							break;
						}
					}
					catch (Exception obj)
					{
						try
						{
							ObservableSystem.GetUnhandledExceptionHandler()(obj);
						}
						catch
						{
						}
					}
				}
			}
		}

		public Trampoline(Observable<T> source)
		{
			_003Csource_003EP = source;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _Trampoline(observer));
		}
	}
}
