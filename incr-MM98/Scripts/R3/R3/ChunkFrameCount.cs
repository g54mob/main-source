using System;

namespace R3
{
	internal sealed class ChunkFrameCount<T> : Observable<T[]>
	{
		private sealed class _Chunk : Observer<T>, IFrameRunnerWorkItem
		{
			private readonly Observer<T[]> observer;

			private readonly int periodFrame;

			private readonly int count;

			private readonly object gate = new object();

			private readonly FrameProvider frameProvider;

			private bool running;

			private T[] buffer;

			private int index;

			private int currentFrame;

			public _Chunk(Observer<T[]> observer, int frameCount, int count, FrameProvider frameProvider)
			{
				this.observer = observer;
				periodFrame = frameCount;
				this.count = count;
				buffer = new T[count];
				this.frameProvider = frameProvider;
			}

			protected override void OnNextCore(T value)
			{
				lock (gate)
				{
					buffer[index++] = value;
					if (index == count)
					{
						currentFrame = 0;
						index = 0;
						observer.OnNext(buffer);
						buffer = new T[count];
					}
					else if (!running)
					{
						currentFrame = 0;
						running = true;
						frameProvider.Register(this);
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

			bool IFrameRunnerWorkItem.MoveNext(long _)
			{
				if (base.IsDisposed)
				{
					return false;
				}
				lock (gate)
				{
					if (index == 0)
					{
						running = false;
						return false;
					}
					if (++currentFrame == periodFrame)
					{
						Span<T> span = buffer.AsSpan(0, index);
						observer.OnNext(span.ToArray());
						span.Clear();
						index = 0;
						running = false;
						return false;
					}
				}
				return true;
			}
		}

		public ChunkFrameCount(Observable<T> source, int frameCount, int count, FrameProvider frameProvider)
		{
			_003Csource_003EP = source;
			_003CframeCount_003EP = frameCount;
			_003Ccount_003EP = count;
			_003CframeProvider_003EP = frameProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T[]> observer)
		{
			return _003Csource_003EP.Subscribe(new _Chunk(observer, _003CframeCount_003EP, _003Ccount_003EP, _003CframeProvider_003EP));
		}
	}
}
