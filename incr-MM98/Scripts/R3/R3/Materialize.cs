using System;

namespace R3
{
	internal sealed class Materialize<T> : Observable<Notification<T>>
	{
		private sealed class _Materialize : Observer<T>
		{
			public _Materialize(Observer<Notification<T>> observer)
			{
				_003Cobserver_003EP = observer;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				_003Cobserver_003EP.OnNext(new Notification<T>(value));
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003Cobserver_003EP.OnNext(new Notification<T>(error));
			}

			protected override void OnCompletedCore(Result result)
			{
				try
				{
					_003Cobserver_003EP.OnNext(new Notification<T>(result));
				}
				finally
				{
					_003Cobserver_003EP.OnCompleted();
				}
			}
		}

		public Materialize(Observable<T> source)
		{
			_003Csource_003EP = source;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<Notification<T>> observer)
		{
			return _003Csource_003EP.Subscribe(new _Materialize(observer));
		}
	}
}
