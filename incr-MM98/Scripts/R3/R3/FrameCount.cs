using System;

namespace R3
{
	internal sealed class FrameCount<T> : Observable<(long FrameCount, T Value)>
	{
		private sealed class _FrameCount : Observer<T>
		{
			public _FrameCount(Observer<(long FrameCount, T Value)> observer, FrameProvider frameProvider)
			{
				_003Cobserver_003EP = observer;
				_003CframeProvider_003EP = frameProvider;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				_003Cobserver_003EP.OnNext((_003CframeProvider_003EP.GetFrameCount(), value));
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003Cobserver_003EP.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				_003Cobserver_003EP.OnCompleted(result);
			}
		}

		public FrameCount(Observable<T> source, FrameProvider frameProvider)
		{
			_003Csource_003EP = source;
			_003CframeProvider_003EP = frameProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<(long FrameCount, T Value)> observer)
		{
			return _003Csource_003EP.Subscribe(new _FrameCount(observer, _003CframeProvider_003EP));
		}
	}
}
