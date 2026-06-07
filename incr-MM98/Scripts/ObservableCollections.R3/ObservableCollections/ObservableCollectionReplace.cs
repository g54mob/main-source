using System;
using System.Collections.Specialized;
using System.Threading;
using R3;

namespace ObservableCollections
{
	internal sealed class ObservableCollectionReplace<T> : Observable<CollectionReplaceEvent<T>>
	{
		private sealed class _ObservableCollectionReplace : ObservableCollectionObserverBase<T, CollectionReplaceEvent<T>>
		{
			public _ObservableCollectionReplace(IObservableCollection<T> collection, Observer<CollectionReplaceEvent<T>> observer, CancellationToken cancellationToken)
				: base(collection, observer, cancellationToken)
			{
			}

			protected override void Handler(in NotifyCollectionChangedEventArgs<T> eventArgs)
			{
				if (eventArgs.Action == NotifyCollectionChangedAction.Replace)
				{
					observer.OnNext(new CollectionReplaceEvent<T>(eventArgs.NewStartingIndex, eventArgs.OldItem, eventArgs.NewItem));
				}
			}
		}

		public ObservableCollectionReplace(IObservableCollection<T> collection, CancellationToken cancellationToken)
		{
			_003Ccollection_003EP = collection;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<CollectionReplaceEvent<T>> observer)
		{
			return new _ObservableCollectionReplace(_003Ccollection_003EP, observer, _003CcancellationToken_003EP);
		}
	}
}
