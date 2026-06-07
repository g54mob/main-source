using System;

namespace R3
{
	internal sealed class TakeWhile<T> : Observable<T>
	{
		private sealed class _TakeWhile : Observer<T>, IDisposable
		{
			public _TakeWhile(Observer<T> observer, Func<T, bool> predicate)
			{
				_003Cobserver_003EP = observer;
				_003Cpredicate_003EP = predicate;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				if (_003Cpredicate_003EP(value))
				{
					_003Cobserver_003EP.OnNext(value);
				}
				else
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

		public TakeWhile(Observable<T> source, Func<T, bool> predicate)
		{
			_003Csource_003EP = source;
			_003Cpredicate_003EP = predicate;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _TakeWhile(observer, _003Cpredicate_003EP));
		}
	}
}
