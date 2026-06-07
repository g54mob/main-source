using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class ThrottleLast<T> : Observable<T>
	{
		private sealed class _ThrottleLast : Observer<T>
		{
			private static readonly TimerCallback timerCallback = RaiseOnNext;

			private readonly Observer<T> observer;

			private readonly TimeSpan interval;

			private readonly ITimer timer;

			private readonly object gate = new object();

			private T? lastValue;

			private bool hasValue;

			public _ThrottleLast(Observer<T> observer, TimeSpan interval, TimeProvider timeProvider)
			{
				this.observer = observer;
				this.interval = interval;
				timer = timeProvider.CreateStoppedTimer(timerCallback, this);
			}

			protected override void OnNextCore(T value)
			{
				lock (gate)
				{
					if (!hasValue)
					{
						timer.InvokeOnce(interval);
					}
					hasValue = true;
					lastValue = value;
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

			protected override void DisposeCore()
			{
				timer.Dispose();
			}

			private static void RaiseOnNext(object? state)
			{
				_ThrottleLast throttleLast = (_ThrottleLast)state;
				lock (throttleLast.gate)
				{
					if (throttleLast.hasValue)
					{
						throttleLast.observer.OnNext(throttleLast.lastValue);
						throttleLast.hasValue = false;
						throttleLast.lastValue = default(T);
					}
				}
			}
		}

		public ThrottleLast(Observable<T> source, TimeSpan interval, TimeProvider timeProvider)
		{
			_003Csource_003EP = source;
			_003Cinterval_003EP = interval;
			_003CtimeProvider_003EP = timeProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _ThrottleLast(observer, _003Cinterval_003EP.Normalize(), _003CtimeProvider_003EP));
		}
	}
}
