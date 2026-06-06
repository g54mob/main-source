using System;
using System.Collections.Generic;

namespace R3
{
	internal sealed class ChunkFrame<T> : Observable<T[]>
	{
		private sealed class _Chunk : Observer<T>, IFrameRunnerWorkItem
		{
			private readonly Observer<T[]> observer;

			private readonly List<T> list;

			private readonly FrameProvider frameProvider;

			private readonly int periodFrame;

			private int currentFrame;

			private bool running;

			public _Chunk(Observer<T[]> observer, int frameCount, FrameProvider frameProvider)
			{
				this.observer = observer;
				periodFrame = frameCount;
				this.frameProvider = frameProvider;
				list = new List<T>();
			}

			protected override void OnNextCore(T value)
			{
				lock (list)
				{
					list.Add(value);
					if (!running)
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

			bool IFrameRunnerWorkItem.MoveNext(long _)
			{
				if (base.IsDisposed)
				{
					return false;
				}
				lock (list)
				{
					if (++currentFrame == periodFrame)
					{
						observer.OnNext(list.ToArray());
						list.Clear();
						running = false;
						return false;
					}
				}
				return true;
			}
		}

		public ChunkFrame(Observable<T> source, int frameCount, FrameProvider frameProvider)
		{
			_003Csource_003EP = source;
			_003CframeCount_003EP = frameCount;
			_003CframeProvider_003EP = frameProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T[]> observer)
		{
			return _003Csource_003EP.Subscribe(new _Chunk(observer, _003CframeCount_003EP, _003CframeProvider_003EP));
		}
	}
}
