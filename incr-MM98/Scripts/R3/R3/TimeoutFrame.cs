using System;
using R3.Internal;

namespace R3
{
	internal sealed class TimeoutFrame<T> : Observable<T>
	{
		private sealed class _TimeoutFrame : Observer<T>, IFrameRunnerWorkItem
		{
			private readonly Observer<T> observer;

			private readonly FrameProvider frameProvider;

			private readonly int periodFrame;

			private readonly object gate = new object();

			private int currentFrame;

			private bool running;

			public _TimeoutFrame(Observer<T> observer, int frameCount, FrameProvider frameProvider)
			{
				this.observer = observer;
				periodFrame = frameCount;
				this.frameProvider = frameProvider;
			}

			protected override void OnNextCore(T value)
			{
				lock (gate)
				{
					observer.OnNext(value);
					currentFrame = 0;
					if (!running)
					{
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
					if (++currentFrame == periodFrame)
					{
						this.OnCompleted(new TimeoutException());
						running = false;
						return false;
					}
				}
				return true;
			}
		}

		public TimeoutFrame(Observable<T> source, int frameCount, FrameProvider frameProvider)
		{
			_003Csource_003EP = source;
			_003CframeCount_003EP = frameCount;
			_003CframeProvider_003EP = frameProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _TimeoutFrame(observer, _003CframeCount_003EP.NormalizeFrame(), _003CframeProvider_003EP));
		}
	}
}
