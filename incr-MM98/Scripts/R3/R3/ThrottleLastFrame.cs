using System;
using R3.Internal;

namespace R3
{
	internal sealed class ThrottleLastFrame<T> : Observable<T>
	{
		private sealed class _ThrottleLastFrame : Observer<T>, IFrameRunnerWorkItem
		{
			private readonly Observer<T> observer;

			private readonly FrameProvider frameProvider;

			private readonly int frameCount;

			private readonly object gate = new object();

			private T? lastValue;

			private int currentFrame;

			private bool running;

			public _ThrottleLastFrame(Observer<T> observer, int frameCount, FrameProvider frameProvider)
			{
				this.observer = observer;
				this.frameCount = frameCount;
				this.frameProvider = frameProvider;
			}

			protected override void OnNextCore(T value)
			{
				lock (gate)
				{
					if (!running)
					{
						running = true;
						currentFrame = 0;
						frameProvider.Register(this);
					}
					lastValue = value;
				}
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				observer.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
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
					if (++currentFrame == frameCount)
					{
						observer.OnNext(lastValue);
						lastValue = default(T);
						running = false;
						return false;
					}
				}
				return true;
			}
		}

		public ThrottleLastFrame(Observable<T> source, int frameCount, FrameProvider frameProvider)
		{
			_003Csource_003EP = source;
			_003CframeCount_003EP = frameCount;
			_003CframeProvider_003EP = frameProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _ThrottleLastFrame(observer, _003CframeCount_003EP.NormalizeFrame(), _003CframeProvider_003EP));
		}
	}
}
