using System;
using R3.Internal;

namespace R3
{
	internal sealed class DebounceFrame<T> : Observable<T>
	{
		private sealed class _DebounceFrame : Observer<T>, IFrameRunnerWorkItem
		{
			private readonly Observer<T> observer;

			private readonly int frameCount;

			private readonly object gate = new object();

			private readonly FrameProvider frameProvider;

			private T? latestValue;

			private bool hasvalue;

			private int currentFrame;

			private bool isRunning;

			public _DebounceFrame(Observer<T> observer, int frameCount, FrameProvider frameProvider)
			{
				this.observer = observer;
				this.frameCount = frameCount;
				this.frameProvider = frameProvider;
			}

			protected override void OnNextCore(T value)
			{
				lock (gate)
				{
					latestValue = value;
					hasvalue = true;
					currentFrame = 0;
					if (!isRunning)
					{
						isRunning = true;
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
					if (hasvalue)
					{
						observer.OnNext(latestValue);
						hasvalue = false;
						latestValue = default(T);
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
					if (!hasvalue)
					{
						currentFrame = 0;
						isRunning = false;
						return false;
					}
					if (++currentFrame == frameCount)
					{
						observer.OnNext(latestValue);
						hasvalue = false;
						latestValue = default(T);
						currentFrame = 0;
						isRunning = false;
						return false;
					}
				}
				return true;
			}
		}

		public DebounceFrame(Observable<T> source, int frameCount, FrameProvider frameProvider)
		{
			_003Csource_003EP = source;
			_003CframeCount_003EP = frameCount;
			_003CframeProvider_003EP = frameProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _DebounceFrame(observer, _003CframeCount_003EP.NormalizeFrame(), _003CframeProvider_003EP));
		}
	}
}
