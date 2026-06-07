using System;
using System.Threading;
using R3;

namespace ObservableCollections
{
	internal abstract class SynchronizedViewObserverBase<T, TView, TEvent> : IDisposable
	{
		protected readonly ISynchronizedView<T, TView> source;

		protected readonly Observer<TEvent> observer;

		private readonly CancellationTokenRegistration cancellationTokenRegistration;

		private readonly NotifyViewChangedEventHandler<T, TView> handlerDelegate;

		public SynchronizedViewObserverBase(ISynchronizedView<T, TView> source, Observer<TEvent> observer, CancellationToken cancellationToken)
		{
			this.source = source;
			this.observer = observer;
			handlerDelegate = Handler;
			source.ViewChanged += handlerDelegate;
			if (cancellationToken.CanBeCanceled)
			{
				cancellationTokenRegistration = cancellationToken.UnsafeRegister(delegate(object? state)
				{
					SynchronizedViewObserverBase<T, TView, TEvent> obj = (SynchronizedViewObserverBase<T, TView, TEvent>)state;
					obj.observer.OnCompleted();
					obj.Dispose();
				}, this);
			}
		}

		public void Dispose()
		{
			source.ViewChanged -= handlerDelegate;
			cancellationTokenRegistration.Dispose();
		}

		protected abstract void Handler(in SynchronizedViewChangedEventArgs<T, TView> eventArgs);
	}
}
