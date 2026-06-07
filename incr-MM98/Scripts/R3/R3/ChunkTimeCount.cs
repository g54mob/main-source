using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class ChunkTimeCount<T> : Observable<T[]>
	{
		private sealed class _Chunk : Observer<T>
		{
			private static readonly TimerCallback timerCallback = TimerCallback;

			private readonly Observer<T[]> observer;

			private readonly int count;

			private readonly TimeSpan timeSpan;

			private readonly TimeProvider timeProvider;

			private readonly object gate = new object();

			private ITimer? timer;

			private T[] buffer;

			private int index;

			private int timerId;

			public _Chunk(Observer<T[]> observer, TimeSpan timeSpan, int count, TimeProvider timeProvider)
			{
				this.observer = observer;
				this.count = count;
				this.timeSpan = timeSpan;
				this.timeProvider = timeProvider;
				buffer = new T[count];
			}

			protected override void OnNextCore(T value)
			{
				lock (gate)
				{
					buffer[index++] = value;
					if (index == count)
					{
						timer?.Stop();
						timer = null;
						try
						{
							index = 0;
							observer.OnNext(buffer);
							buffer = new T[count];
							return;
						}
						finally
						{
							timerId = ++timerId;
						}
					}
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
				lock (gate)
				{
					if (index > 0)
					{
						observer.OnNext(buffer.AsSpan(0, index).ToArray());
					}
				}
				observer.OnCompleted(result);
			}

			protected override void DisposeCore()
			{
				timer?.Dispose();
			}

			private static void TimerCallback(object? state)
			{
				_Chunk chunk = (_Chunk)state;
				int num = Volatile.Read(ref chunk.timerId);
				lock (chunk.gate)
				{
					if (Volatile.Read(ref chunk.timerId) == num)
					{
						if (chunk.index == 0)
						{
							chunk.observer.OnNext(Array.Empty<T>());
						}
						else
						{
							Span<T> span = chunk.buffer.AsSpan(0, chunk.index);
							chunk.observer.OnNext(span.ToArray());
							span.Clear();
							chunk.index = 0;
						}
						chunk.timer = null;
					}
				}
			}
		}

		public ChunkTimeCount(Observable<T> source, TimeSpan timeSpan, int count, TimeProvider timeProvider)
		{
			_003Csource_003EP = source;
			_003CtimeSpan_003EP = timeSpan;
			_003Ccount_003EP = count;
			_003CtimeProvider_003EP = timeProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T[]> observer)
		{
			return _003Csource_003EP.Subscribe(new _Chunk(observer, _003CtimeSpan_003EP, _003Ccount_003EP, _003CtimeProvider_003EP));
		}
	}
}
