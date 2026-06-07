using System;

namespace R3
{
	internal sealed class Defer<T> : Observable<T>
	{
		public Defer(Func<Observable<T>> observableFactory, bool rawObserver)
		{
			_003CobservableFactory_003EP = observableFactory;
			_003CrawObserver_003EP = rawObserver;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			Observable<T> observable = null;
			try
			{
				observable = _003CobservableFactory_003EP();
			}
			catch (Exception exception)
			{
				observer.OnCompleted(exception);
				return Disposable.Empty;
			}
			return observable.Subscribe((Observer<T>)(_003CrawObserver_003EP ? ((IDisposable)observer) : ((IDisposable)observer.Wrap())));
		}
	}
}
