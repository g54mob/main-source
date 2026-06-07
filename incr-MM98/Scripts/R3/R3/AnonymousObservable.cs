using System;

namespace R3
{
	internal sealed class AnonymousObservable<T> : Observable<T>
	{
		public AnonymousObservable(Func<Observer<T>, IDisposable> subscribe, bool rawObserver)
		{
			_003Csubscribe_003EP = subscribe;
			_003CrawObserver_003EP = rawObserver;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csubscribe_003EP((Observer<T>)(_003CrawObserver_003EP ? ((IDisposable)observer) : ((IDisposable)observer.Wrap())));
		}
	}
	internal sealed class AnonymousObservable<T, TState> : Observable<T>
	{
		public AnonymousObservable(TState state, Func<Observer<T>, TState, IDisposable> subscribe, bool rawObserver)
		{
			_003Cstate_003EP = state;
			_003Csubscribe_003EP = subscribe;
			_003CrawObserver_003EP = rawObserver;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csubscribe_003EP((Observer<T>)(_003CrawObserver_003EP ? ((IDisposable)observer) : ((IDisposable)observer.Wrap())), _003Cstate_003EP);
		}
	}
}
