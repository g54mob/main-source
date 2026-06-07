using System;
using System.Threading;
using R3;

namespace ObservableCollections
{
	internal abstract class ObservableCollectionObserverBase<T, TEvent> : IDisposable
	{
		protected readonly IObservableCollection<T> collection;

		protected readonly Observer<TEvent> observer;

		private readonly CancellationTokenRegistration cancellationTokenRegistration;

		private readonly NotifyCollectionChangedEventHandler<T> handlerDelegate;

		public ObservableCollectionObserverBase(IObservableCollection<T> collection, Observer<TEvent> observer, CancellationToken cancellationToken)
		{
			this.collection = collection;
			this.observer = observer;
			handlerDelegate = Handler;
			collection.CollectionChanged += handlerDelegate;
			if (cancellationToken.CanBeCanceled)
			{
				cancellationTokenRegistration = cancellationToken.UnsafeRegister(delegate(object? state)
				{
					ObservableCollectionObserverBase<T, TEvent> obj = (ObservableCollectionObserverBase<T, TEvent>)state;
					obj.observer.OnCompleted();
					obj.Dispose();
				}, this);
			}
		}

		public void Dispose()
		{
			collection.CollectionChanged -= handlerDelegate;
			cancellationTokenRegistration.Dispose();
		}

		protected abstract void Handler(in NotifyCollectionChangedEventArgs<T> eventArgs);
	}
}
