using System;

namespace R3
{
	internal sealed class Select<T, TResult> : Observable<TResult>
	{
		private sealed class _Select : Observer<T>
		{
			public _Select(Observer<TResult> observer, Func<T, TResult> selector)
			{
				_003Cobserver_003EP = observer;
				_003Cselector_003EP = selector;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				_003Cobserver_003EP.OnNext(_003Cselector_003EP(value));
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

		public Select(Observable<T> source, Func<T, TResult> selector)
		{
			_003Csource_003EP = source;
			_003Cselector_003EP = selector;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<TResult> observer)
		{
			return _003Csource_003EP.Subscribe(new _Select(observer, _003Cselector_003EP));
		}
	}
	internal sealed class Select<T, TResult, TState> : Observable<TResult>
	{
		private sealed class _Select : Observer<T>
		{
			public _Select(Observer<TResult> observer, Func<T, TState, TResult> selector, TState state)
			{
				_003Cobserver_003EP = observer;
				_003Cselector_003EP = selector;
				_003Cstate_003EP = state;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				_003Cobserver_003EP.OnNext(_003Cselector_003EP(value, _003Cstate_003EP));
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

		public Select(Observable<T> source, Func<T, TState, TResult> selector, TState state)
		{
			_003Csource_003EP = source;
			_003Cselector_003EP = selector;
			_003Cstate_003EP = state;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<TResult> observer)
		{
			return _003Csource_003EP.Subscribe(new _Select(observer, _003Cselector_003EP, _003Cstate_003EP));
		}
	}
}
