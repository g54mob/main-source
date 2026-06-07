using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class SkipTime<T> : Observable<T>
	{
		private sealed class _SkipTime : Observer<T>, IDisposable
		{
			private static readonly TimerCallback timerCallback = TimerStopped;

			private readonly Observer<T> observer;

			private ITimer? timer;

			public _SkipTime(Observer<T> observer, TimeSpan duration, TimeProvider timeProvider)
			{
				this.observer = observer;
				timer = timeProvider.CreateStoppedTimer(timerCallback, this);
				timer.InvokeOnce(duration);
			}

			protected override void OnNextCore(T value)
			{
				if (Volatile.Read(ref timer) == null)
				{
					observer.OnNext(value);
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

			private static void TimerStopped(object? state)
			{
				_SkipTime obj = (_SkipTime)state;
				Volatile.Read(ref obj.timer)?.Dispose();
				Volatile.Write(ref obj.timer, null);
			}

			protected override void DisposeCore()
			{
				Volatile.Read(ref timer)?.Dispose();
				Volatile.Write(ref timer, null);
			}
		}

		public SkipTime(Observable<T> source, TimeSpan duration, TimeProvider timeProvider)
		{
			_003Csource_003EP = source;
			_003Cduration_003EP = duration;
			_003CtimeProvider_003EP = timeProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _SkipTime(observer, _003Cduration_003EP, _003CtimeProvider_003EP));
		}
	}
}
