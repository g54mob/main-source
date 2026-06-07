using System;

namespace R3
{
	internal sealed class TimeInterval<T> : Observable<(TimeSpan Interval, T Value)>
	{
		private sealed class _TimeInterval : Observer<T>
		{
			private long previousTimestamp;

			public _TimeInterval(Observer<(TimeSpan Interval, T Value)> observer, TimeProvider timeProvider)
			{
				_003Cobserver_003EP = observer;
				_003CtimeProvider_003EP = timeProvider;
				previousTimestamp = _003CtimeProvider_003EP.GetTimestamp();
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				long timestamp = _003CtimeProvider_003EP.GetTimestamp();
				TimeSpan elapsedTime = _003CtimeProvider_003EP.GetElapsedTime(previousTimestamp, timestamp);
				previousTimestamp = timestamp;
				_003Cobserver_003EP.OnNext((elapsedTime, value));
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

		public TimeInterval(Observable<T> source, TimeProvider timeProvider)
		{
			_003Csource_003EP = source;
			_003CtimeProvider_003EP = timeProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<(TimeSpan Interval, T Value)> observer)
		{
			return _003Csource_003EP.Subscribe(new _TimeInterval(observer, _003CtimeProvider_003EP));
		}
	}
}
