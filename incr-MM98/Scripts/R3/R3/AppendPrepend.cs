using System;

namespace R3
{
	internal sealed class AppendPrepend<T> : Observable<T>
	{
		private sealed class _Append : Observer<T>
		{
			public _Append(Observer<T> observer, T value)
			{
				_003Cobserver_003EP = observer;
				_003Cvalue_003EP = value;
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
				_003Cobserver_003EP.OnNext(_003Cvalue_003EP);
				_003Cobserver_003EP.OnCompleted();
			}
		}

		public AppendPrepend(Observable<T> source, T value, bool append)
		{
			_003Csource_003EP = source;
			_003Cvalue_003EP = value;
			_003Cappend_003EP = append;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			if (!_003Cappend_003EP)
			{
				observer.OnNext(_003Cvalue_003EP);
				return _003Csource_003EP.Subscribe(observer.Wrap());
			}
			return _003Csource_003EP.Subscribe(new _Append(observer, _003Cvalue_003EP));
		}
	}
}
