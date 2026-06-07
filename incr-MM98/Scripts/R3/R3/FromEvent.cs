using System;
using System.Threading;

namespace R3
{
	internal sealed class FromEvent<TDelegate> : Observable<Unit>
	{
		private sealed class _FromEventPattern : IDisposable
		{
			private Observer<Unit>? observer;

			private Action<TDelegate>? removeHandler;

			private TDelegate registeredHandler;

			private CancellationTokenRegistration cancellationTokenRegistration;

			public _FromEventPattern(Func<Action, TDelegate> conversion, Action<TDelegate> addHandler, Action<TDelegate> removeHandler, Observer<Unit> observer, CancellationToken cancellationToken)
			{
				this.observer = observer;
				this.removeHandler = removeHandler;
				registeredHandler = conversion(OnNext);
				addHandler(registeredHandler);
				if (cancellationToken.CanBeCanceled)
				{
					cancellationTokenRegistration = cancellationToken.UnsafeRegister(delegate(object? state)
					{
						((_FromEventPattern)state).CompleteDispose();
					}, this);
				}
			}

			private void OnNext()
			{
				observer?.OnNext(default(Unit));
			}

			private void CompleteDispose()
			{
				observer?.OnCompleted();
				Dispose();
			}

			public void Dispose()
			{
				Action<TDelegate> action = Interlocked.Exchange(ref removeHandler, null);
				if (action != null)
				{
					observer = null;
					removeHandler = null;
					cancellationTokenRegistration.Dispose();
					action(registeredHandler);
				}
			}
		}

		public FromEvent(Func<Action, TDelegate> conversion, Action<TDelegate> addHandler, Action<TDelegate> removeHandler, CancellationToken cancellationToken)
		{
			_003Cconversion_003EP = conversion;
			_003CaddHandler_003EP = addHandler;
			_003CremoveHandler_003EP = removeHandler;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<Unit> observer)
		{
			return new _FromEventPattern(_003Cconversion_003EP, _003CaddHandler_003EP, _003CremoveHandler_003EP, observer, _003CcancellationToken_003EP);
		}
	}
	internal sealed class FromEvent<TDelegate, T> : Observable<T>
	{
		private sealed class _FromEventPattern : IDisposable
		{
			private Observer<T>? observer;

			private Action<TDelegate>? removeHandler;

			private TDelegate registeredHandler;

			private CancellationTokenRegistration cancellationTokenRegistration;

			public _FromEventPattern(Func<Action<T>, TDelegate> conversion, Action<TDelegate> addHandler, Action<TDelegate> removeHandler, Observer<T> observer, CancellationToken cancellationToken)
			{
				this.observer = observer;
				this.removeHandler = removeHandler;
				registeredHandler = conversion(OnNext);
				addHandler(registeredHandler);
				if (cancellationToken.CanBeCanceled)
				{
					cancellationTokenRegistration = cancellationToken.UnsafeRegister(delegate(object? state)
					{
						((_FromEventPattern)state).CompleteDispose();
					}, this);
				}
			}

			private void OnNext(T value)
			{
				observer?.OnNext(value);
			}

			private void CompleteDispose()
			{
				observer?.OnCompleted();
				Dispose();
			}

			public void Dispose()
			{
				Action<TDelegate> action = Interlocked.Exchange(ref removeHandler, null);
				if (action != null)
				{
					observer = null;
					removeHandler = null;
					cancellationTokenRegistration.Dispose();
					action(registeredHandler);
				}
			}
		}

		public FromEvent(Func<Action<T>, TDelegate> conversion, Action<TDelegate> addHandler, Action<TDelegate> removeHandler, CancellationToken cancellationToken)
		{
			_003Cconversion_003EP = conversion;
			_003CaddHandler_003EP = addHandler;
			_003CremoveHandler_003EP = removeHandler;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return new _FromEventPattern(_003Cconversion_003EP, _003CaddHandler_003EP, _003CremoveHandler_003EP, observer, _003CcancellationToken_003EP);
		}
	}
}
