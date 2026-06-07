using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class Debounce<T> : Observable<T>
	{
		private sealed class _Debounce : Observer<T>
		{
			private static readonly TimerCallback timerCallback = RaiseOnNext;

			private readonly Observer<T> observer;

			private readonly TimeSpan timeSpan;

			private readonly ITimer timer;

			private readonly object gate = new object();

			private T? latestValue;

			private bool hasvalue;

			private int timerId;

			public _Debounce(Observer<T> observer, TimeSpan timeSpan, TimeProvider timeProvider)
			{
				this.observer = observer;
				this.timeSpan = timeSpan;
				timer = timeProvider.CreateStoppedTimer(timerCallback, this);
			}

			protected override void OnNextCore(T value)
			{
				lock (gate)
				{
					latestValue = value;
					hasvalue = true;
					Volatile.Write(ref timerId, timerId + 1);
					timer.InvokeOnce(timeSpan);
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
					if (hasvalue)
					{
						observer.OnNext(latestValue);
						hasvalue = false;
						latestValue = default(T);
					}
					observer.OnCompleted(result);
				}
			}

			protected override void DisposeCore()
			{
				timer.Dispose();
			}

			private static void RaiseOnNext(object? state)
			{
				_Debounce debounce = (_Debounce)state;
				int num = Volatile.Read(ref debounce.timerId);
				lock (debounce.gate)
				{
					if (num == debounce.timerId && debounce.hasvalue)
					{
						debounce.observer.OnNext(debounce.latestValue);
						debounce.hasvalue = false;
						debounce.latestValue = default(T);
					}
				}
			}
		}

		public Debounce(Observable<T> source, TimeSpan timeSpan, TimeProvider timeProvider)
		{
			_003Csource_003EP = source;
			_003CtimeSpan_003EP = timeSpan;
			_003CtimeProvider_003EP = timeProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _Debounce(observer, _003CtimeSpan_003EP.Normalize(), _003CtimeProvider_003EP));
		}
	}
}
