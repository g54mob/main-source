using System;

namespace R3
{
	internal sealed class TakeUntil<T, TOther> : Observable<T>
	{
		private sealed class _TakeUntil : Observer<T>
		{
			private readonly Observer<T> observer;

			internal readonly TakeUntilStopperObserver stopper;

			public _TakeUntil(Observer<T> observer)
			{
				this.observer = observer;
				stopper = new TakeUntilStopperObserver(this);
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
				stopper.Dispose();
			}
		}

		private sealed class TakeUntilStopperObserver : Observer<TOther>
		{
			public TakeUntilStopperObserver(_TakeUntil parent)
			{
				_003Cparent_003EP = parent;
				base._002Ector();
			}

			protected override void OnNextCore(TOther value)
			{
				_003Cparent_003EP.OnCompleted(Result.Success);
				Dispose();
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003Cparent_003EP.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				_003Cparent_003EP.OnCompleted(result);
			}
		}

		public TakeUntil(Observable<T> source, Observable<TOther> other)
		{
			_003Csource_003EP = source;
			_003Cother_003EP = other;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			_TakeUntil takeUntil = new _TakeUntil(observer);
			IDisposable disposable = _003Cother_003EP.Subscribe(takeUntil.stopper);
			try
			{
				return _003Csource_003EP.Subscribe(takeUntil);
			}
			catch
			{
				disposable.Dispose();
				throw;
			}
		}
	}
	internal sealed class TakeUntil<T> : Observable<T>
	{
		private sealed class _TakeUntil : Observer<T>, IDisposable
		{
			public _TakeUntil(Observer<T> observer, Func<T, bool> predicate)
			{
				_003Cobserver_003EP = observer;
				_003Cpredicate_003EP = predicate;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				_003Cobserver_003EP.OnNext(value);
				if (_003Cpredicate_003EP(value))
				{
					_003Cobserver_003EP.OnCompleted();
				}
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003Cobserver_003EP.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				_003Cobserver_003EP.OnCompleted(result);
			}
		}

		public TakeUntil(Observable<T> source, Func<T, bool> predicate)
		{
			_003Csource_003EP = source;
			_003Cpredicate_003EP = predicate;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _TakeUntil(observer, _003Cpredicate_003EP));
		}
	}
}
