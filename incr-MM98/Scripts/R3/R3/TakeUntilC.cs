using System;
using System.Threading;

namespace R3
{
	internal sealed class TakeUntilC<T> : Observable<T>
	{
		private sealed class _TakeUntil : Observer<T>, IDisposable
		{
			private static readonly Action<object?> cancellationCallback = CancellationCallback;

			private readonly Observer<T> observer;

			private CancellationTokenRegistration tokenRegistration;

			public _TakeUntil(Observer<T> observer, CancellationToken cancellationToken)
			{
				this.observer = observer;
				tokenRegistration = cancellationToken.Register(cancellationCallback, this);
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

			private static void CancellationCallback(object? state)
			{
				((_TakeUntil)state).OnCompleted();
			}

			protected override void DisposeCore()
			{
				tokenRegistration.Dispose();
			}
		}

		public TakeUntilC(Observable<T> source, CancellationToken cancellationToken)
		{
			_003Csource_003EP = source;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _TakeUntil(observer, _003CcancellationToken_003EP));
		}
	}
}
