using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class DelaySubscription<T> : Observable<T>
	{
		private sealed class _DelaySubscription : Observer<T>
		{
			private static readonly TimerCallback timerCallback = Subscribe;

			private readonly Observer<T> observer;

			private readonly Observable<T> source;

			private readonly TimeSpan dueTime;

			private readonly ITimer timer;

			public _DelaySubscription(Observer<T> observer, Observable<T> source, TimeSpan dueTime, TimeProvider timeProvider)
			{
				this.observer = observer;
				this.source = source;
				this.dueTime = dueTime;
				timer = timeProvider.CreateStoppedTimer(timerCallback, this);
			}

			public IDisposable Run()
			{
				timer.InvokeOnce(dueTime);
				return this;
			}

			protected override void OnNextCore(T value)
			{
				observer.OnNext(value);
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

			private static void Subscribe(object? state)
			{
				_DelaySubscription delaySubscription = (_DelaySubscription)state;
				try
				{
					delaySubscription.source.Subscribe(delaySubscription);
				}
				catch (Exception obj)
				{
					ObservableSystem.GetUnhandledExceptionHandler()(obj);
					delaySubscription.Dispose();
				}
			}
		}

		public DelaySubscription(Observable<T> source, TimeSpan dueTime, TimeProvider timeProvider)
		{
			_003Csource_003EP = source;
			_003CdueTime_003EP = dueTime;
			_003CtimeProvider_003EP = timeProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return new _DelaySubscription(observer, _003Csource_003EP, _003CdueTime_003EP.Normalize(), _003CtimeProvider_003EP).Run();
		}
	}
}
