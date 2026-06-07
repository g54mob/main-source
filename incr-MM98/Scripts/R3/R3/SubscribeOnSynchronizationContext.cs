using System;
using System.Threading;

namespace R3
{
	internal sealed class SubscribeOnSynchronizationContext<T> : Observable<T>
	{
		private sealed class _SubscribeOn : Observer<T>
		{
			private static readonly SendOrPostCallback postCallback = Subscribe;

			private readonly Observer<T> observer;

			private readonly Observable<T> source;

			private readonly SynchronizationContext synchronizationContext;

			private SingleAssignmentDisposableCore disposable;

			public _SubscribeOn(Observer<T> observer, Observable<T> source, SynchronizationContext synchronizationContext)
			{
				this.observer = observer;
				this.source = source;
				this.synchronizationContext = synchronizationContext;
			}

			public IDisposable Run()
			{
				synchronizationContext.Post(postCallback, this);
				return this;
			}

			private static void Subscribe(object? state)
			{
				_SubscribeOn subscribeOn = (_SubscribeOn)state;
				subscribeOn.disposable.Disposable = subscribeOn.source.Subscribe(subscribeOn);
			}

			protected override void OnNextCore(T value)
			{
				observer.OnNext(value);
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				observer.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				observer.OnCompleted(result);
			}

			protected override void DisposeCore()
			{
				disposable.Dispose();
			}
		}

		public SubscribeOnSynchronizationContext(Observable<T> source, SynchronizationContext synchronizationContext)
		{
			_003Csource_003EP = source;
			_003CsynchronizationContext_003EP = synchronizationContext;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return new _SubscribeOn(observer, _003Csource_003EP, _003CsynchronizationContext_003EP).Run();
		}
	}
}
