using System;
using System.Collections.Generic;

namespace R3
{
	internal sealed class SkipLastTime<T> : Observable<T>
	{
		private sealed class _SkipLastTime : Observer<T>, IDisposable
		{
			private readonly Observer<T> observer;

			private readonly Queue<(long timestamp, T value)> queue = new Queue<(long, T)>();

			private readonly TimeSpan duration;

			private readonly TimeProvider timeProvider;

			public _SkipLastTime(Observer<T> observer, TimeSpan duration, TimeProvider timeProvider)
			{
				this.observer = observer;
				this.timeProvider = timeProvider;
				this.duration = duration;
			}

			protected override void OnNextCore(T value)
			{
				long timestamp = timeProvider.GetTimestamp();
				queue.Enqueue((timestamp, value));
				while (queue.Count > 0 && timeProvider.GetElapsedTime(queue.Peek().timestamp, timestamp) >= duration)
				{
					observer.OnNext(queue.Dequeue().value);
				}
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				observer.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				long timestamp = timeProvider.GetTimestamp();
				while (queue.Count > 0 && timeProvider.GetElapsedTime(queue.Peek().timestamp, timestamp) >= duration)
				{
					observer.OnNext(queue.Dequeue().value);
				}
				observer.OnCompleted(result);
			}

			protected override void DisposeCore()
			{
				queue.Clear();
			}
		}

		public SkipLastTime(Observable<T> source, TimeSpan duration, TimeProvider timeProvider)
		{
			_003Csource_003EP = source;
			_003Cduration_003EP = duration;
			_003CtimeProvider_003EP = timeProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _SkipLastTime(observer, _003Cduration_003EP, _003CtimeProvider_003EP));
		}
	}
}
