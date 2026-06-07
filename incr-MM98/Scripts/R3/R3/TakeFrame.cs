using System;

namespace R3
{
	internal sealed class TakeFrame<T> : Observable<T>
	{
		private sealed class _TakeFrame : Observer<T>, IDisposable, IFrameRunnerWorkItem
		{
			private readonly Observer<T> observer;

			private long remaining;

			private readonly object gate = new object();

			public _TakeFrame(Observer<T> observer, int frameCount, FrameProvider frameProvider)
			{
				this.observer = observer;
				remaining = frameProvider.GetFrameCount() + frameCount;
				frameProvider.Register(this);
			}

			protected override void OnNextCore(T value)
			{
				lock (gate)
				{
					observer.OnNext(value);
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
					observer.OnCompleted(result);
				}
			}

			bool IFrameRunnerWorkItem.MoveNext(long _)
			{
				if (base.IsDisposed)
				{
					return false;
				}
				if (remaining > 0)
				{
					remaining--;
					if (remaining == 0L)
					{
						OnCompleted(Result.Success);
						return false;
					}
					return true;
				}
				return false;
			}
		}

		public TakeFrame(Observable<T> source, int frameCount, FrameProvider frameProvider)
		{
			_003Csource_003EP = source;
			_003CframeCount_003EP = frameCount;
			_003CframeProvider_003EP = frameProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _TakeFrame(observer, _003CframeCount_003EP, _003CframeProvider_003EP));
		}
	}
}
