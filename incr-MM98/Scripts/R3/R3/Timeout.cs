using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class Timeout<T> : Observable<T>
	{
		private sealed class _Timeout : Observer<T>
		{
			private static readonly TimerCallback timerCallback = PublishTimeoutError;

			private readonly Observer<T> observer;

			private readonly TimeSpan timeSpan;

			private readonly ITimer timer;

			private readonly object gate = new object();

			private int timerId;

			public _Timeout(Observer<T> observer, TimeSpan timeSpan, TimeProvider timeProvider)
			{
				this.observer = observer;
				this.timeSpan = timeSpan;
				timer = timeProvider.CreateStoppedTimer(timerCallback, this);
			}

			protected override void OnNextCore(T value)
			{
				lock (gate)
				{
					Volatile.Write(ref timerId, timerId + 1);
					observer.OnNext(value);
					timer.InvokeOnce(timeSpan);
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

			private static void PublishTimeoutError(object? state)
			{
				_Timeout timeout = (_Timeout)state;
				int num = Volatile.Read(ref timeout.timerId);
				lock (timeout.gate)
				{
					if (num == timeout.timerId)
					{
						timeout.OnCompleted(new TimeoutException());
					}
				}
			}
		}

		public Timeout(Observable<T> source, TimeSpan dueTime, TimeProvider timeProvider)
		{
			_003Csource_003EP = source;
			_003CdueTime_003EP = dueTime;
			_003CtimeProvider_003EP = timeProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _Timeout(observer, _003CdueTime_003EP.Normalize(), _003CtimeProvider_003EP));
		}
	}
}
