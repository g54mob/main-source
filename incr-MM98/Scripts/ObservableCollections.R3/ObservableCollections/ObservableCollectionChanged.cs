using System;
using System.Collections.Specialized;
using System.Threading;
using R3;

namespace ObservableCollections
{
	internal sealed class ObservableCollectionChanged<T> : Observable<CollectionChangedEvent<T>>
	{
		private sealed class _ObservableCollectionAdd : ObservableCollectionObserverBase<T, CollectionChangedEvent<T>>
		{
			public _ObservableCollectionAdd(IObservableCollection<T> collection, Observer<CollectionChangedEvent<T>> observer, CancellationToken cancellationToken)
				: base(collection, observer, cancellationToken)
			{
			}

			protected override void Handler(in NotifyCollectionChangedEventArgs<T> eventArgs)
			{
				if (eventArgs.IsSingleItem)
				{
					CollectionChangedEvent<T> value = new CollectionChangedEvent<T>(eventArgs.Action, eventArgs.NewItem, eventArgs.OldItem, eventArgs.NewStartingIndex, eventArgs.OldStartingIndex, eventArgs.SortOperation);
					observer.OnNext(value);
				}
				else if (eventArgs.Action == NotifyCollectionChangedAction.Add)
				{
					int num = eventArgs.NewStartingIndex;
					ReadOnlySpan<T> newItems = eventArgs.NewItems;
					for (int i = 0; i < newItems.Length; i++)
					{
						T newItem = newItems[i];
						CollectionChangedEvent<T> value2 = new CollectionChangedEvent<T>(eventArgs.Action, newItem, eventArgs.OldItem, num, eventArgs.OldStartingIndex, eventArgs.SortOperation);
						if (eventArgs.NewStartingIndex != -1)
						{
							num++;
						}
						observer.OnNext(value2);
					}
				}
				else if (eventArgs.Action == NotifyCollectionChangedAction.Remove)
				{
					ReadOnlySpan<T> newItems = eventArgs.OldItems;
					for (int i = 0; i < newItems.Length; i++)
					{
						T oldItem = newItems[i];
						CollectionChangedEvent<T> value3 = new CollectionChangedEvent<T>(eventArgs.Action, eventArgs.NewItem, oldItem, eventArgs.NewStartingIndex, eventArgs.OldStartingIndex, eventArgs.SortOperation);
						observer.OnNext(value3);
					}
				}
			}
		}

		public ObservableCollectionChanged(IObservableCollection<T> collection, CancellationToken cancellationToken)
		{
			_003Ccollection_003EP = collection;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<CollectionChangedEvent<T>> observer)
		{
			return new _ObservableCollectionAdd(_003Ccollection_003EP, observer, _003CcancellationToken_003EP);
		}
	}
}
