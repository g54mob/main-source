using System;
using System.Threading;

namespace R3
{
	internal sealed class SkipFrame<T> : Observable<T>
	{
		private sealed class _SkipFrame : Observer<T>, IDisposable, IFrameRunnerWorkItem
		{
			private readonly Observer<T> observer;

			private long remaining;

			public _SkipFrame(Observer<T> observer, int frameCount, FrameProvider frameProvider)
			{
				this.observer = observer;
				remaining = frameCount;
				frameProvider.Register(this);
			}

			protected override void OnNextCore(T value)
			{
				if (Volatile.Read(ref remaining) <= 0)
				{
					observer.OnNext(value);
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
				if (remaining > 0)
				{
					remaining--;
					return true;
				}
				return false;
			}
		}

		public SkipFrame(Observable<T> source, int frameCount, FrameProvider frameProvider)
		{
			_003Csource_003EP = source;
			_003CframeCount_003EP = frameCount;
			_003CframeProvider_003EP = frameProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _SkipFrame(observer, _003CframeCount_003EP, _003CframeProvider_003EP));
		}
	}
}
