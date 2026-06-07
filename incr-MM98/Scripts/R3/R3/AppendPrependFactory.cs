using System;

namespace R3
{
	internal sealed class AppendPrependFactory<T> : Observable<T>
	{
		private sealed class _Append : Observer<T>
		{
			public _Append(Observer<T> observer, Func<T> valueFactory)
			{
				_003Cobserver_003EP = observer;
				_003CvalueFactory_003EP = valueFactory;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				_003Cobserver_003EP.OnNext(value);
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003Cobserver_003EP.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				if (result.IsFailure)
				{
					_003Cobserver_003EP.OnCompleted(result);
					return;
				}
				_003Cobserver_003EP.OnNext(_003CvalueFactory_003EP());
				_003Cobserver_003EP.OnCompleted();
			}
		}

		public AppendPrependFactory(Observable<T> source, Func<T> valueFactory, bool append)
		{
			_003Csource_003EP = source;
			_003CvalueFactory_003EP = valueFactory;
			_003Cappend_003EP = append;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			if (!_003Cappend_003EP)
			{
				observer.OnNext(_003CvalueFactory_003EP());
				return _003Csource_003EP.Subscribe(observer.Wrap());
			}
			return _003Csource_003EP.Subscribe(new _Append(observer, _003CvalueFactory_003EP));
		}
	}
	internal sealed class AppendPrependFactory<T, TState> : Observable<T>
	{
		private sealed class _Append : Observer<T>
		{
			public _Append(Observer<T> observer, TState state, Func<TState, T> valueFactory)
			{
				_003Cobserver_003EP = observer;
				_003Cstate_003EP = state;
				_003CvalueFactory_003EP = valueFactory;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				_003Cobserver_003EP.OnNext(value);
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003Cobserver_003EP.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				if (result.IsFailure)
				{
					_003Cobserver_003EP.OnCompleted(result);
					return;
				}
				_003Cobserver_003EP.OnNext(_003CvalueFactory_003EP(_003Cstate_003EP));
				_003Cobserver_003EP.OnCompleted();
			}
		}

		public AppendPrependFactory(Observable<T> source, TState state, Func<TState, T> valueFactory, bool append)
		{
			_003Csource_003EP = source;
			_003Cstate_003EP = state;
			_003CvalueFactory_003EP = valueFactory;
			_003Cappend_003EP = append;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			if (!_003Cappend_003EP)
			{
				observer.OnNext(_003CvalueFactory_003EP(_003Cstate_003EP));
				return _003Csource_003EP.Subscribe(observer.Wrap());
			}
			return _003Csource_003EP.Subscribe(new _Append(observer, _003Cstate_003EP, _003CvalueFactory_003EP));
		}
	}
}
