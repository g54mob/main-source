using System;
using R3.Internal;

namespace R3
{
	internal sealed class ThrottleFirstLastFrame<T> : Observable<T>
	{
		private sealed class _ThrottleFirstLastFrame : Observer<T>, IFrameRunnerWorkItem
		{
			private readonly Observer<T> observer;

			private readonly FrameProvider frameProvider;

			private readonly int frameCount;

			private readonly object gate = new object();

			private T? lastValue;

			private bool hasValue;

			private int currentFrame;

			private bool running;

			public _ThrottleFirstLastFrame(Observer<T> observer, int frameCount, FrameProvider frameProvider)
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
						observer.OnNext(value);
					}
					else
					{
						hasValue = true;
						lastValue = value;
					}
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
						if (hasValue)
						{
							observer.OnNext(lastValue);
							lastValue = default(T);
						}
						running = false;
						return false;
					}
				}
				return true;
			}
		}

		public ThrottleFirstLastFrame(Observable<T> source, int frameCount, FrameProvider frameProvider)
		{
			_003Csource_003EP = source;
			_003CframeCount_003EP = frameCount;
			_003CframeProvider_003EP = frameProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _ThrottleFirstLastFrame(observer, _003CframeCount_003EP.NormalizeFrame(), _003CframeProvider_003EP));
		}
	}
}
