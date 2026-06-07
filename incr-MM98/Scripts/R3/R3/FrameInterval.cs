using System;

namespace R3
{
	internal sealed class FrameInterval<T> : Observable<(long Interval, T Value)>
	{
		private sealed class _FrameInterval : Observer<T>
		{
			private long previousFrameCount;

			public _FrameInterval(Observer<(long Interval, T Value)> observer, FrameProvider frameProvider)
			{
				_003Cobserver_003EP = observer;
				_003CframeProvider_003EP = frameProvider;
				previousFrameCount = _003CframeProvider_003EP.GetFrameCount();
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				long frameCount = _003CframeProvider_003EP.GetFrameCount();
				long item = frameCount - previousFrameCount;
				previousFrameCount = frameCount;
				_003Cobserver_003EP.OnNext((item, value));
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

		public FrameInterval(Observable<T> source, FrameProvider frameProvider)
		{
			_003Csource_003EP = source;
			_003CframeProvider_003EP = frameProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<(long Interval, T Value)> observer)
		{
			return _003Csource_003EP.Subscribe(new _FrameInterval(observer, _003CframeProvider_003EP));
		}
	}
}
