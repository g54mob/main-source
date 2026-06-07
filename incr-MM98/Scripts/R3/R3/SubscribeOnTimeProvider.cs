using System;
using System.Threading;
using R3.Internal;

namespace R3
{
	internal sealed class SubscribeOnTimeProvider<T> : Observable<T>
	{
		private sealed class _SubscribeOn : Observer<T>
		{
			private static readonly TimerCallback timerCallback = Subscribe;

			private readonly Observer<T> observer;

			private readonly Observable<T> source;

			private readonly TimeProvider timeProvider;

			private readonly ITimer timer;

			private SingleAssignmentDisposableCore disposable;

			public _SubscribeOn(Observer<T> observer, Observable<T> source, TimeProvider timeProvider)
			{
				this.observer = observer;
				this.source = source;
				this.timeProvider = timeProvider;
				timer = timeProvider.CreateStoppedTimer(timerCallback, this);
			}

			public IDisposable Run()
			{
				timer.RestartImmediately();
				return this;
			}

			private static void Subscribe(object? state)
			{
				_SubscribeOn subscribeOn = (_SubscribeOn)state;
				subscribeOn.disposable.Disposable = subscribeOn.source.Subscribe(subscribeOn);
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
				disposable.Dispose();
			}
		}

		public SubscribeOnTimeProvider(Observable<T> source, TimeProvider timeProvider)
		{
			_003Csource_003EP = source;
			_003CtimeProvider_003EP = timeProvider;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return new _SubscribeOn(observer, _003Csource_003EP, _003CtimeProvider_003EP).Run();
		}
	}
}
