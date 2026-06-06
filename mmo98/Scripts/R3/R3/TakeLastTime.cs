using System;
using System.Collections.Generic;

namespace R3
{
	internal sealed class TakeLastTime<T> : Observable<T>
	{
		private sealed class _TakeLastTime : Observer<T>, IDisposable
		{
			private readonly Observer<T> observer;

			private readonly object gate = new object();

			private readonly Queue<(long timestamp, T value)> queue = new Queue<(long, T)>();

			private readonly TimeSpan duration;

			private readonly TimeProvider timeProvider;

			private bool takeCompleted;

			public _TakeLastTime(Observer<T> observer, TimeSpan duration, TimeProvider timeProvider)
			{
				this.observer = observer;
				this.timeProvider = timeProvider;
				this.duration = duration;
			}

			protected override void OnNextCore(T value)
			{
				lock (gate)
				{
					if (!takeCompleted)
					{
						long timestamp = timeProvider.GetTimestamp();
						queue.Enqueue((timestamp, value));
						Trim(timestamp);
					}
				}
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				lock (gate)
				{
					observer.OnErrorResume(error);
				}
			}

			protected override void OnCompletedCore(Result result)
			{
				lock (gate)
				{
					takeCompleted = true;
					if (result.IsFailure)
					{
						observer.OnCompleted(result);
						return;
					}
					Trim(timeProvider.GetTimestamp());
					foreach (var item in queue)
					{
						observer.OnNext(item.value);
						if (base.IsDisposed)
						{
							return;
						}
					}
					observer.OnCompleted();
				}
			}

			protected override void DisposeCore()
			{
				lock (gate)
				{
					queue.Clear();
				}
			}

			private void Trim(long currentTimestamp)
			{
				while (queue.Count > 0 && timeProvider.GetElapsedTime(queue.Peek().timestamp, currentTimestamp) > duration)
				{
					queue.Dequeue();
				}
			}
		}

		public TakeLastTime(Observable<T> source, TimeSpan duration, TimeProvider timeProvider)
		{
			_003Csource_003EP = source;
			_003Cduration_003EP = duration;
			_003CtimeProvider_003EP = timeProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _TakeLastTime(observer, _003Cduration_003EP, _003CtimeProvider_003EP));
		}
	}
}
