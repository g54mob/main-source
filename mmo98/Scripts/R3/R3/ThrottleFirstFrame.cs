using System;
using R3.Internal;

namespace R3
{
	internal sealed class ThrottleFirstFrame<T> : Observable<T>
	{
		private sealed class _ThrottleFirstFrame : Observer<T>, IFrameRunnerWorkItem
		{
			private readonly Observer<T> observer;

			private readonly int frameCount;

			private readonly FrameProvider frameProvider;

			private readonly object gate = new object();

			private int currentFrame;

			private bool closing;

			public _ThrottleFirstFrame(Observer<T> observer, int frameCount, FrameProvider frameProvider)
			{
				this.observer = observer;
				this.frameCount = frameCount;
				this.frameProvider = frameProvider;
			}

			protected override void OnNextCore(T value)
			{
				lock (gate)
				{
					if (!closing)
					{
						closing = true;
						observer.OnNext(value);
						currentFrame = 0;
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
					if (++currentFrame == frameCount)
					{
						closing = false;
						return false;
					}
				}
				return true;
			}
		}

		public ThrottleFirstFrame(Observable<T> source, int frameCount, FrameProvider frameProvider)
		{
			_003Csource_003EP = source;
			_003CframeCount_003EP = frameCount;
			_003CframeProvider_003EP = frameProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _ThrottleFirstFrame(observer, _003CframeCount_003EP.NormalizeFrame(), _003CframeProvider_003EP));
		}
	}
}
