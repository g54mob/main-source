using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class ThrottleFirst<T> : Observable<T>
	{
		private sealed class _ThrottleFirst : Observer<T>
		{
			private static readonly TimerCallback timerCallback = OpenGate;

			private readonly Observer<T> observer;

			private readonly ITimer timer;

			private readonly TimeSpan timeSpan;

			private readonly object gate = new object();

			private bool closing;

			public _ThrottleFirst(Observer<T> observer, TimeSpan timeSpan, TimeProvider timeProvider)
			{
				this.observer = observer;
				timer = timeProvider.CreateStoppedTimer(timerCallback, this);
				this.timeSpan = timeSpan;
			}

			protected override void OnNextCore(T value)
			{
				lock (gate)
				{
					if (!closing)
					{
						closing = true;
						timer.InvokeOnce(timeSpan);
						observer.OnNext(value);
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

			private static void OpenGate(object? state)
			{
				_ThrottleFirst throttleFirst = (_ThrottleFirst)state;
				lock (throttleFirst.gate)
				{
					throttleFirst.closing = false;
				}
			}
		}

		public ThrottleFirst(Observable<T> source, TimeSpan timeSpan, TimeProvider timeProvider)
		{
			_003Csource_003EP = source;
			_003CtimeSpan_003EP = timeSpan;
			_003CtimeProvider_003EP = timeProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _ThrottleFirst(observer, _003CtimeSpan_003EP.Normalize(), _003CtimeProvider_003EP));
		}
	}
}
