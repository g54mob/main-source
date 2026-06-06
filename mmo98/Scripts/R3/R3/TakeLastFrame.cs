using System;
using System.Collections.Generic;

namespace R3
{
	internal sealed class TakeLastFrame<T> : Observable<T>
	{
		private sealed class _TakeLastFrame : Observer<T>, IDisposable
		{
			private readonly Observer<T> observer;

			private readonly object gate = new object();

			private readonly Queue<(long frameCount, T value)> queue = new Queue<(long, T)>();

			private readonly int frameCount;

			private readonly FrameProvider frameProvider;

			private bool takeCompleted;

			public _TakeLastFrame(Observer<T> observer, int frameCount, FrameProvider frameProvider)
			{
				this.observer = observer;
				this.frameCount = frameCount;
				this.frameProvider = frameProvider;
			}

			protected override void OnNextCore(T value)
			{
				lock (gate)
				{
					if (!takeCompleted)
					{
						long num = frameProvider.GetFrameCount();
						queue.Enqueue((num, value));
						Trim(num);
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
					Trim(frameProvider.GetFrameCount());
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

			private void Trim(long currentFrameCount)
			{
				while (queue.Count > 0 && currentFrameCount - queue.Peek().frameCount > frameCount)
				{
					queue.Dequeue();
				}
			}

			protected override void DisposeCore()
			{
				lock (gate)
				{
					queue.Clear();
				}
			}
		}

		public TakeLastFrame(Observable<T> source, int frameCount, FrameProvider frameProvider)
		{
			_003Csource_003EP = source;
			_003CframeCount_003EP = frameCount;
			_003CframeProvider_003EP = frameProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _TakeLastFrame(observer, _003CframeCount_003EP, _003CframeProvider_003EP));
		}
	}
}
