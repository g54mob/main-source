using System;
using System.Collections.Specialized;
using System.Threading;
using R3;

namespace ObservableCollections
{
	internal sealed class ObservableCollectionAdd<T> : Observable<CollectionAddEvent<T>>
	{
		private sealed class _ObservableCollectionAdd : ObservableCollectionObserverBase<T, CollectionAddEvent<T>>
		{
			public _ObservableCollectionAdd(IObservableCollection<T> collection, Observer<CollectionAddEvent<T>> observer, CancellationToken cancellationToken)
				: base(collection, observer, cancellationToken)
			{
			}

			protected override void Handler(in NotifyCollectionChangedEventArgs<T> eventArgs)
			{
				if (eventArgs.Action != NotifyCollectionChangedAction.Add)
				{
					return;
				}
				if (eventArgs.IsSingleItem)
				{
					observer.OnNext(new CollectionAddEvent<T>(eventArgs.NewStartingIndex, eventArgs.NewItem));
					return;
				}
				int newStartingIndex = eventArgs.NewStartingIndex;
				ReadOnlySpan<T> newItems = eventArgs.NewItems;
				for (int i = 0; i < newItems.Length; i++)
				{
					T value = newItems[i];
					observer.OnNext(new CollectionAddEvent<T>(newStartingIndex++, value));
				}
			}
		}

		public ObservableCollectionAdd(IObservableCollection<T> collection, CancellationToken cancellationToken)
		{
			_003Ccollection_003EP = collection;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<CollectionAddEvent<T>> observer)
		{
			return new _ObservableCollectionAdd(_003Ccollection_003EP, observer, _003CcancellationToken_003EP);
		}
	}
}
