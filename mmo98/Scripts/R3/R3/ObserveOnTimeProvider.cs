using System;
using System.Collections.Generic;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class ObserveOnTimeProvider<T> : Observable<T>
	{
		internal sealed class _ObserveOn : Observer<T>
		{
			private static readonly TimerCallback timerCallback = DrainMessages;

			private readonly Observer<T> observer;

			private readonly TimeProvider timeProvider;

			private readonly Queue<Notification<T>> queue;

			private ITimer? timer;

			private bool running;

			protected override bool AutoDisposeOnCompleted => false;

			public _ObserveOn(Observer<T> observer, TimeProvider timeProvider)
			{
				this.observer = observer;
				this.timeProvider = timeProvider;
				queue = new Queue<Notification<T>>();
				timer = timeProvider.CreateStoppedTimer(timerCallback, this);
			}

			protected override void OnNextCore(T value)
			{
				lock (queue)
				{
					if (timer != null)
					{
						queue.Enqueue(new Notification<T>(value));
						if (queue.Count == 1 && !running)
						{
							running = true;
							timer.RestartImmediately();
						}
					}
				}
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				lock (queue)
				{
					if (timer != null)
					{
						queue.Enqueue(new Notification<T>(error));
						if (queue.Count == 1 && !running)
						{
							running = true;
							timer.RestartImmediately();
						}
					}
				}
			}

			protected override void OnCompletedCore(Result result)
			{
				lock (queue)
				{
					if (timer != null)
					{
						queue.Enqueue(new Notification<T>(result));
						if (queue.Count == 1 && !running)
						{
							running = true;
							timer.RestartImmediately();
						}
					}
				}
			}

			private static void DrainMessages(object? state)
			{
				_ObserveOn observeOn = (_ObserveOn)state;
				Queue<Notification<T>> queue = observeOn.queue;
				Notification<T> result = default(Notification<T>);
				while (true)
				{
					lock (queue)
					{
						if (observeOn.timer == null || !queue.TryDequeue(out result))
						{
							observeOn.running = false;
							break;
						}
					}
					try
					{
						switch (result.Kind)
						{
						case NotificationKind.OnNext:
							observeOn.observer.OnNext(result.Value);
							break;
						case NotificationKind.OnErrorResume:
							observeOn.observer.OnErrorResume(result.Error);
							break;
						case NotificationKind.OnCompleted:
							try
							{
								observeOn.observer.OnCompleted(result.Result);
							}
							finally
							{
								observeOn.Dispose();
							}
							break;
						}
					}
					catch (Exception obj)
					{
						ObservableSystem.GetUnhandledExceptionHandler()(obj);
					}
				}
			}

			protected override void DisposeCore()
			{
				lock (queue)
				{
					if (timer != null)
					{
						timer.Dispose();
						timer = null;
					}
					queue.Clear();
				}
			}
		}

		public ObserveOnTimeProvider(Observable<T> source, TimeProvider timeProvider)
		{
			_003Csource_003EP = source;
			_003CtimeProvider_003EP = timeProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _ObserveOn(observer, _003CtimeProvider_003EP));
		}
	}
}
