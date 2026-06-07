using System;
using System.Threading;

namespace R3
{
	internal sealed class SkipUntilC<T> : Observable<T>
	{
		private sealed class _SkipUntil : Observer<T>, IDisposable
		{
			private static readonly Action<object?> cancellationCallback = CancellationCallback;

			private readonly Observer<T> observer;

			private CancellationTokenRegistration tokenRegistration;

			private bool open;

			public _SkipUntil(Observer<T> observer, CancellationToken cancellationToken)
			{
				this.observer = observer;
				tokenRegistration = cancellationToken.Register(cancellationCallback, this);
			}

			protected override void OnNextCore(T value)
			{
				if (Volatile.Read(ref open))
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

			private static void CancellationCallback(object? state)
			{
				Volatile.Write(ref ((_SkipUntil)state).open, value: true);
			}

			protected override void DisposeCore()
			{
				tokenRegistration.Dispose();
			}
		}

		public SkipUntilC(Observable<T> source, CancellationToken cancellationToken)
		{
			_003Csource_003EP = source;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _SkipUntil(observer, _003CcancellationToken_003EP));
		}
	}
}
