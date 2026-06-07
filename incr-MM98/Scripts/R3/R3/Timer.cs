using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class Timer : Observable<Unit>
	{
		private sealed class _Timer : IDisposable
		{
			public static readonly TimerCallback singleTimerCallback = SingleTick;

			public static readonly TimerCallback periodicTimerCallback = PeriodicTick;

			internal CancellationTokenRegistration cancellationTokenRegistration;

			private Observer<Unit> observer;

			public ITimer? Timer { get; set; }

			public _Timer(Observer<Unit> observer)
			{
				this.observer = observer;
				base._002Ector();
			}

			private static void SingleTick(object? state)
			{
				_Timer timer = (_Timer)state;
				try
				{
					timer.observer.OnNext(default(Unit));
					timer.observer.OnCompleted();
				}
				finally
				{
					timer.Dispose();
				}
			}

			private static void PeriodicTick(object? state)
			{
				_Timer timer = (_Timer)state;
				lock (timer)
				{
					timer.observer.OnNext(default(Unit));
				}
			}

			public void CompleteDispose()
			{
				observer.OnCompleted();
				Dispose();
			}

			public void Dispose()
			{
				cancellationTokenRegistration.Dispose();
				Timer?.Dispose();
				Timer = null;
			}
		}

		private readonly TimeSpan? dueTime1;

		private readonly DateTimeOffset? dueTime2;

		private readonly TimeSpan? period;

		private readonly TimeProvider timeProvider;

		private readonly CancellationToken cancellationToken;

		public Timer(TimeSpan dueTime, TimeSpan? period, TimeProvider timeProvider, CancellationToken cancellationToken)
		{
			dueTime1 = dueTime;
			this.period = period;
			this.timeProvider = timeProvider;
			this.cancellationToken = cancellationToken;
		}

		public Timer(DateTimeOffset dueTime, TimeSpan? period, TimeProvider timeProvider, CancellationToken cancellationToken)
		{
			dueTime2 = dueTime;
			this.period = period;
			this.timeProvider = timeProvider;
			this.cancellationToken = cancellationToken;
		}

		protected override IDisposable SubscribeCore(Observer<Unit> observer)
		{
			TimerCallback timerCallback = ((!period.HasValue) ? _Timer.singleTimerCallback : _Timer.periodicTimerCallback);
			_Timer timer = new _Timer(observer);
			timer.Timer = timeProvider.CreateStoppedTimer(timerCallback, timer);
			TimeSpan timeSpan = (dueTime1.HasValue ? dueTime1.Value : (dueTime2.Value - timeProvider.GetUtcNow()));
			if (cancellationToken.CanBeCanceled)
			{
				timer.cancellationTokenRegistration = cancellationToken.UnsafeRegister(delegate(object? state)
				{
					((_Timer)state).CompleteDispose();
				}, timer);
			}
			if (!period.HasValue)
			{
				timer.Timer.InvokeOnce(timeSpan.Normalize());
			}
			else
			{
				timer.Timer.Change(timeSpan.Normalize(), period.Value);
			}
			return timer;
		}
	}
}
