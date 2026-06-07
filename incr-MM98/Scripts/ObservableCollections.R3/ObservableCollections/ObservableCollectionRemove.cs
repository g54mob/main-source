using System;
using System.Collections.Specialized;
using System.Threading;
using R3;

namespace ObservableCollections
{
	internal sealed class ObservableCollectionRemove<T> : Observable<CollectionRemoveEvent<T>>
	{
		private sealed class _ObservableCollectionRemove : ObservableCollectionObserverBase<T, CollectionRemoveEvent<T>>
		{
			public _ObservableCollectionRemove(IObservableCollection<T> collection, Observer<CollectionRemoveEvent<T>> observer, CancellationToken cancellationToken)
				: base(collection, observer, cancellationToken)
			{
			}

			protected override void Handler(in NotifyCollectionChangedEventArgs<T> eventArgs)
			{
				if (eventArgs.Action != NotifyCollectionChangedAction.Remove)
				{
					return;
				}
				if (eventArgs.IsSingleItem)
				{
					observer.OnNext(new CollectionRemoveEvent<T>(eventArgs.OldStartingIndex, eventArgs.OldItem));
					return;
				}
				ReadOnlySpan<T> oldItems = eventArgs.OldItems;
				for (int i = 0; i < oldItems.Length; i++)
				{
					T value = oldItems[i];
					observer.OnNext(new CollectionRemoveEvent<T>(eventArgs.OldStartingIndex, value));
				}
			}
		}

		public ObservableCollectionRemove(IObservableCollection<T> collection, CancellationToken cancellationToken)
		{
			_003Ccollection_003EP = collection;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<CollectionRemoveEvent<T>> observer)
		{
			return new _ObservableCollectionRemove(_003Ccollection_003EP, observer, _003CcancellationToken_003EP);
		}
	}
}
