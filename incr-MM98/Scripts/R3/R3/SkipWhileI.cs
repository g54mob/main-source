using System;

namespace R3
{
	internal sealed class SkipWhileI<T> : Observable<T>
	{
		private sealed class _SkipWhile : Observer<T>, IDisposable
		{
			private int count;

			private bool open;

			public _SkipWhile(Observer<T> observer, Func<T, int, bool> predicate)
			{
				_003Cobserver_003EP = observer;
				_003Cpredicate_003EP = predicate;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				if (open)
				{
					_003Cobserver_003EP.OnNext(value);
				}
				else if (!_003Cpredicate_003EP(value, count++))
				{
					open = true;
					_003Cobserver_003EP.OnNext(value);
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

		public SkipWhileI(Observable<T> source, Func<T, int, bool> predicate)
		{
			_003Csource_003EP = source;
			_003Cpredicate_003EP = predicate;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _SkipWhile(observer, _003Cpredicate_003EP));
		}
	}
}
