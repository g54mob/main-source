using System;

namespace R3
{
	internal sealed class Timestamp<T> : Observable<(long Timestamp, T Value)>
	{
		private sealed class _Timestamp : Observer<T>
		{
			public _Timestamp(Observer<(long Timestamp, T Value)> observer, TimeProvider timeProvider)
			{
				_003Cobserver_003EP = observer;
				_003CtimeProvider_003EP = timeProvider;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				_003Cobserver_003EP.OnNext((_003CtimeProvider_003EP.GetTimestamp(), value));
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

		public Timestamp(Observable<T> source, TimeProvider timeProvider)
		{
			_003Csource_003EP = source;
			_003CtimeProvider_003EP = timeProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<(long Timestamp, T Value)> observer)
		{
			return _003Csource_003EP.Subscribe(new _Timestamp(observer, _003CtimeProvider_003EP));
		}
	}
}
