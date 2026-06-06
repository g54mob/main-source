using System;

namespace R3
{
	internal sealed class TakeUntilI<T> : Observable<T>
	{
		private sealed class _TakeUntil : Observer<T>, IDisposable
		{
			private int count;

			public _TakeUntil(Observer<T> observer, Func<T, int, bool> predicate)
			{
				_003Cobserver_003EP = observer;
				_003Cpredicate_003EP = predicate;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				_003Cobserver_003EP.OnNext(value);
				if (_003Cpredicate_003EP(value, count++))
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

		public TakeUntilI(Observable<T> source, Func<T, int, bool> predicate)
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
