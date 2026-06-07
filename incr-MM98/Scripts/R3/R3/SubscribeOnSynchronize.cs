using System;

namespace R3
{
	internal sealed class SubscribeOnSynchronize<T> : Observable<T>
	{
		public SubscribeOnSynchronize(Observable<T> source, object gate, bool rawObserver)
		{
			_003Csource_003EP = source;
			_003Cgate_003EP = gate;
			_003CrawObserver_003EP = rawObserver;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			observer = (Observer<T>)(_003CrawObserver_003EP ? ((IDisposable)observer) : ((IDisposable)observer.Wrap()));
			lock (_003Cgate_003EP)
			{
				return _003Csource_003EP.Subscribe(observer);
			}
		}
	}
}
