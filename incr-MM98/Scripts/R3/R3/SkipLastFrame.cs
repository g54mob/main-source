using System;
using System.Collections.Generic;

namespace R3
{
	internal sealed class SkipLastFrame<T> : Observable<T>
	{
		private sealed class _SkipLastFrame : Observer<T>, IDisposable
		{
			private readonly Observer<T> observer;

			private readonly Queue<(long frameCount, T value)> queue = new Queue<(long, T)>();

			private readonly int frameCount;

			private readonly FrameProvider frameProvider;

			public _SkipLastFrame(Observer<T> observer, int frameCount, FrameProvider frameProvider)
			{
				this.observer = observer;
				this.frameCount = frameCount;
				this.frameProvider = frameProvider;
			}

			protected override void OnNextCore(T value)
			{
				long num = frameProvider.GetFrameCount();
				queue.Enqueue((num, value));
				while (queue.Count > 0 && num - queue.Peek().frameCount >= frameCount)
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
				long num = frameProvider.GetFrameCount();
				while (queue.Count > 0 && num - queue.Peek().frameCount >= frameCount)
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

		public SkipLastFrame(Observable<T> source, int frameCount, FrameProvider frameProvider)
		{
			_003Csource_003EP = source;
			_003CframeCount_003EP = frameCount;
			_003CframeProvider_003EP = frameProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _SkipLastFrame(observer, _003CframeCount_003EP, _003CframeProvider_003EP));
		}
	}
}
