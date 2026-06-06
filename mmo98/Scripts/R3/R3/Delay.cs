using System;
using System.Collections.Generic;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class Delay<T> : Observable<T>
	{
		private sealed class _Delay : Observer<T>
		{
			private static readonly TimerCallback timerCallback = DrainMessages;

			private readonly Observer<T> observer;

			private readonly TimeSpan dueTime;

			private readonly TimeProvider timeProvider;

			private readonly Queue<(long timestamp, Notification<T> value)> queue = new Queue<(long, Notification<T>)>();

			private ITimer timer;

			private bool running;

			protected override bool AutoDisposeOnCompleted => false;

			public _Delay(Observer<T> observer, TimeSpan dueTime, TimeProvider timeProvider)
			{
				this.dueTime = dueTime;
				this.observer = observer;
				this.timeProvider = timeProvider;
				timer = timeProvider.CreateStoppedTimer(timerCallback, this);
			}

			protected override void OnNextCore(T value)
			{
				lock (queue)
				{
					queue.Enqueue((timeProvider.GetTimestamp(), new Notification<T>(value)));
					if (queue.Count == 1 && !running)
					{
						running = true;
						timer.RestartImmediately();
					}
				}
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				lock (queue)
				{
					queue.Enqueue((timeProvider.GetTimestamp(), new Notification<T>(error)));
					if (queue.Count == 1 && !running)
					{
						running = true;
						timer.RestartImmediately();
					}
				}
			}

			protected override void OnCompletedCore(Result result)
			{
				lock (queue)
				{
					queue.Enqueue((timeProvider.GetTimestamp(), new Notification<T>(result)));
					if (queue.Count == 1 && !running)
					{
						running = true;
						timer.RestartImmediately();
					}
				}
			}

			protected override void DisposeCore()
			{
				lock (queue)
				{
					timer.Dispose();
					queue.Clear();
				}
			}

			private static void DrainMessages(object? state)
			{
				_Delay delay = (_Delay)state;
				Queue<(long, Notification<T>)> queue = delay.queue;
				while (!delay.IsDisposed)
				{
					Notification<T> item;
					lock (queue)
					{
						if (!queue.TryPeek(out var result))
						{
							delay.running = false;
							break;
						}
						TimeSpan elapsedTime = delay.timeProvider.GetElapsedTime(result.Item1);
						if (!(elapsedTime >= delay.dueTime))
						{
							delay.timer.InvokeOnce(delay.dueTime - elapsedTime);
							break;
						}
						item = queue.Dequeue().Item2;
					}
					try
					{
						switch (item.Kind)
						{
						case NotificationKind.OnNext:
							delay.observer.OnNext(item.Value);
							break;
						case NotificationKind.OnErrorResume:
							delay.observer.OnErrorResume(item.Error);
							break;
						case NotificationKind.OnCompleted:
							try
							{
								delay.observer.OnCompleted(item.Result);
							}
							finally
							{
								delay.Dispose();
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
		}

		public Delay(Observable<T> source, TimeSpan dueTime, TimeProvider timeProvider)
		{
			_003Csource_003EP = source;
			_003CdueTime_003EP = dueTime;
			_003CtimeProvider_003EP = timeProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _Delay(observer, _003CdueTime_003EP.Normalize(), _003CtimeProvider_003EP));
		}
	}
}
