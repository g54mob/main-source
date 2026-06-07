using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class ThrottleFirstLast<T> : Observable<T>
	{
		private sealed class _ThrottleFirstLast : Observer<T>
		{
			private static readonly TimerCallback timerCallback = RaiseOnNext;

			private readonly Observer<T> observer;

			private readonly TimeSpan interval;

			private readonly ITimer timer;

			private readonly object gate = new object();

			private T? lastValue;

			private bool hasValue;

			private bool timerIsRunning;

			public _ThrottleFirstLast(Observer<T> observer, TimeSpan interval, TimeProvider timeProvider)
			{
				this.observer = observer;
				this.interval = interval;
				timer = timeProvider.CreateStoppedTimer(timerCallback, this);
			}

			protected override void OnNextCore(T value)
			{
				lock (gate)
				{
					if (!timerIsRunning)
					{
						timerIsRunning = true;
						timer.InvokeOnce(interval);
						observer.OnNext(value);
					}
					else
					{
						hasValue = true;
						lastValue = value;
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

			protected override void DisposeCore()
			{
				timer.Dispose();
			}

			private static void RaiseOnNext(object? state)
			{
				_ThrottleFirstLast throttleFirstLast = (_ThrottleFirstLast)state;
				lock (throttleFirstLast.gate)
				{
					throttleFirstLast.timerIsRunning = false;
					if (throttleFirstLast.hasValue)
					{
						throttleFirstLast.observer.OnNext(throttleFirstLast.lastValue);
						throttleFirstLast.hasValue = false;
						throttleFirstLast.lastValue = default(T);
					}
				}
			}
		}

		public ThrottleFirstLast(Observable<T> source, TimeSpan interval, TimeProvider timeProvider)
		{
			_003Csource_003EP = source;
			_003Cinterval_003EP = interval;
			_003CtimeProvider_003EP = timeProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _ThrottleFirstLast(observer, _003Cinterval_003EP.Normalize(), _003CtimeProvider_003EP));
		}
	}
}
