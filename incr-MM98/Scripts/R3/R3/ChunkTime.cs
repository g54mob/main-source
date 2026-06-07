using System;
using System.Collections.Generic;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class ChunkTime<T> : Observable<T[]>
	{
		private sealed class _Chunk : Observer<T>
		{
			private static readonly TimerCallback timerCallback = TimerCallback;

			private readonly Observer<T[]> observer;

			private readonly List<T> list;

			private readonly TimeProvider timeProvider;

			private readonly TimeSpan timeSpan;

			private ITimer? timer;

			public _Chunk(Observer<T[]> observer, TimeSpan timeSpan, TimeProvider timeProvider)
			{
				this.observer = observer;
				this.timeSpan = timeSpan;
				this.timeProvider = timeProvider;
				list = new List<T>();
			}

			protected override void OnNextCore(T value)
			{
				lock (list)
				{
					list.Add(value);
					if (timer == null)
					{
						timer = timeProvider.CreateStoppedTimer(timerCallback, this);
						timer.InvokeOnce(timeSpan);
					}
				}
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				observer.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				lock (list)
				{
					if (list.Count > 0)
					{
						observer.OnNext(list.ToArray());
						list.Clear();
					}
				}
				observer.OnCompleted(result);
			}

			protected override void DisposeCore()
			{
				lock (list)
				{
					timer?.Dispose();
				}
			}

			private static void TimerCallback(object? state)
			{
				_Chunk chunk = (_Chunk)state;
				lock (chunk.list)
				{
					if (chunk.list.Count == 0)
					{
						chunk.observer.OnNext(Array.Empty<T>());
					}
					else
					{
						chunk.observer.OnNext(chunk.list.ToArray());
						chunk.list.Clear();
					}
					chunk.timer = null;
				}
			}
		}

		public ChunkTime(Observable<T> source, TimeSpan timeSpan, TimeProvider timeProvider)
		{
			_003Csource_003EP = source;
			_003CtimeSpan_003EP = timeSpan;
			_003CtimeProvider_003EP = timeProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T[]> observer)
		{
			return _003Csource_003EP.Subscribe(new _Chunk(observer, _003CtimeSpan_003EP, _003CtimeProvider_003EP));
		}
	}
}
