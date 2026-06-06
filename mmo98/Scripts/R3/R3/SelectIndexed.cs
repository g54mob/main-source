using System;

namespace R3
{
	internal sealed class SelectIndexed<T, TResult> : Observable<TResult>
	{
		private sealed class _Select : Observer<T>
		{
			private int index;

			public _Select(Observer<TResult> observer, Func<T, int, TResult> selector)
			{
				_003Cobserver_003EP = observer;
				_003Cselector_003EP = selector;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				_003Cobserver_003EP.OnNext(_003Cselector_003EP(value, index++));
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

		public SelectIndexed(Observable<T> source, Func<T, int, TResult> selector)
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
	internal sealed class SelectIndexed<T, TResult, TState> : Observable<TResult>
	{
		private sealed class _Select : Observer<T>
		{
			private int index;

			public _Select(Observer<TResult> observer, Func<T, int, TState, TResult> selector, TState state)
			{
				_003Cobserver_003EP = observer;
				_003Cselector_003EP = selector;
				_003Cstate_003EP = state;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				_003Cobserver_003EP.OnNext(_003Cselector_003EP(value, index++, _003Cstate_003EP));
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

		public SelectIndexed(Observable<T> source, Func<T, int, TState, TResult> selector, TState state)
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
