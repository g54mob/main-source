using System;

namespace R3
{
	internal sealed class IObservableToObservable<T> : Observable<T>
	{
		private sealed class ObserverToObserver : IObserver<T>
		{
			public ObserverToObserver(Observer<T> observer)
			{
				_003Cobserver_003EP = observer;
				base._002Ector();
			}

			public void OnNext(T value)
			{
				_003Cobserver_003EP.OnNext(value);
			}

			public void OnError(Exception error)
			{
				_003Cobserver_003EP.OnCompleted(error);
			}

			public void OnCompleted()
			{
				_003Cobserver_003EP.OnCompleted();
			}
		}

		public IObservableToObservable(IObservable<T> source)
		{
			_003Csource_003EP = source;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new ObserverToObserver(observer));
		}
	}
}
