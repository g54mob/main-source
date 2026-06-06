using System;

namespace R3
{
	internal sealed class WhereIndexed<T> : Observable<T>
	{
		private class _Where : Observer<T>
		{
			private int index;

			public _Where(Observer<T> observer, Func<T, int, bool> predicate)
			{
				_003Cobserver_003EP = observer;
				_003Cpredicate_003EP = predicate;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				if (_003Cpredicate_003EP(value, index++))
				{
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

		public WhereIndexed(Observable<T> source, Func<T, int, bool> predicate)
		{
			_003Csource_003EP = source;
			_003Cpredicate_003EP = predicate;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _Where(observer, _003Cpredicate_003EP));
		}
	}
	internal sealed class WhereIndexed<T, TState> : Observable<T>
	{
		private class _Where : Observer<T>
		{
			private int index;

			public _Where(Observer<T> observer, Func<T, int, TState, bool> predicate, TState state)
			{
				_003Cobserver_003EP = observer;
				_003Cpredicate_003EP = predicate;
				_003Cstate_003EP = state;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				if (_003Cpredicate_003EP(value, index++, _003Cstate_003EP))
				{
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

		public WhereIndexed(Observable<T> source, Func<T, int, TState, bool> predicate, TState state)
		{
			_003Csource_003EP = source;
			_003Cpredicate_003EP = predicate;
			_003Cstate_003EP = state;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _Where(observer, _003Cpredicate_003EP, _003Cstate_003EP));
		}
	}
}
