using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class TakeTime<T> : Observable<T>
	{
		private sealed class _TakeTime : Observer<T>, IDisposable
		{
			private static readonly TimerCallback timerCallback = TimerStopped;

			private readonly Observer<T> observer;

			private readonly ITimer timer;

			private readonly object gate = new object();

			public _TakeTime(Observer<T> observer, TimeSpan duration, TimeProvider timeProvider)
			{
				this.observer = observer;
				timer = timeProvider.CreateStoppedTimer(timerCallback, this);
				timer.InvokeOnce(duration);
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

			private static void TimerStopped(object? state)
			{
				((_TakeTime)state).OnCompleted();
			}

			protected override void DisposeCore()
			{
				timer.Dispose();
			}
		}

		public TakeTime(Observable<T> source, TimeSpan duration, TimeProvider timeProvider)
		{
			_003Csource_003EP = source;
			_003Cduration_003EP = duration;
			_003CtimeProvider_003EP = timeProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _TakeTime(observer, _003Cduration_003EP, _003CtimeProvider_003EP));
		}
	}
}
