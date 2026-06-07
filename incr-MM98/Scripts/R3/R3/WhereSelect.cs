using System;

namespace R3
{
	internal sealed class WhereSelect<T, TResult> : Observable<TResult>
	{
		private sealed class _WhereSelect : Observer<T>
		{
			public _WhereSelect(Observer<TResult> observer, Func<T, TResult> selector, Func<T, bool> predicate)
			{
				_003Cobserver_003EP = observer;
				_003Cselector_003EP = selector;
				_003Cpredicate_003EP = predicate;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				if (_003Cpredicate_003EP(value))
				{
					_003Cobserver_003EP.OnNext(_003Cselector_003EP(value));
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

		public WhereSelect(Observable<T> source, Func<T, TResult> selector, Func<T, bool> predicate)
		{
			_003Csource_003EP = source;
			_003Cselector_003EP = selector;
			_003Cpredicate_003EP = predicate;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<TResult> observer)
		{
			return _003Csource_003EP.Subscribe(new _WhereSelect(observer, _003Cselector_003EP, _003Cpredicate_003EP));
		}
	}
}
