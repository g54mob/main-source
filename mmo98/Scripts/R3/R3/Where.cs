using System;

namespace R3
{
	internal sealed class Where<T> : Observable<T>
	{
		private class _Where : Observer<T>
		{
			public _Where(Observer<T> observer, Func<T, bool> predicate)
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

		internal Observable<T> source;

		internal Func<T, bool> predicate;

		public Where(Observable<T> source, Func<T, bool> predicate)
		{
			this.source = source;
			this.predicate = predicate;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return source.Subscribe(new _Where(observer, predicate));
		}
	}
	internal sealed class Where<T, TState> : Observable<T>
	{
		private class _Where : Observer<T>
		{
			public _Where(Observer<T> observer, Func<T, TState, bool> predicate, TState state)
			{
				_003Cobserver_003EP = observer;
				_003Cpredicate_003EP = predicate;
				_003Cstate_003EP = state;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				if (_003Cpredicate_003EP(value, _003Cstate_003EP))
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

		public Where(Observable<T> source, Func<T, TState, bool> predicate, TState state)
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
