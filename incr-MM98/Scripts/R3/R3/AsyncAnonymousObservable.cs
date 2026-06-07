using System;
using System.Threading;
using System.Threading.Tasks;

namespace R3
{
	internal sealed class AsyncAnonymousObservable<T> : Observable<T>
	{
		public AsyncAnonymousObservable(Func<Observer<T>, CancellationToken, ValueTask> subscribe, bool rawObserver)
		{
			_003Csubscribe_003EP = subscribe;
			_003CrawObserver_003EP = rawObserver;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			CancellationDisposable cancellationDisposable = new CancellationDisposable();
			_003Csubscribe_003EP((Observer<T>)(_003CrawObserver_003EP ? ((IDisposable)observer) : ((IDisposable)observer.Wrap())), cancellationDisposable.Token);
			return cancellationDisposable;
		}
	}
	internal sealed class AsyncAnonymousObservable<T, TState> : Observable<T>
	{
		public AsyncAnonymousObservable(TState state, Func<Observer<T>, TState, CancellationToken, ValueTask> subscribe, bool rawObserver)
		{
			_003Cstate_003EP = state;
			_003Csubscribe_003EP = subscribe;
			_003CrawObserver_003EP = rawObserver;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			CancellationDisposable cancellationDisposable = new CancellationDisposable();
			_003Csubscribe_003EP((Observer<T>)(_003CrawObserver_003EP ? ((IDisposable)observer) : ((IDisposable)observer.Wrap())), _003Cstate_003EP, cancellationDisposable.Token);
			return cancellationDisposable;
		}
	}
}
