using System;
using System.Collections.Specialized;
using System.Threading;
using R3;

namespace ObservableCollections
{
	internal sealed class ObservableCollectionMove<T> : Observable<CollectionMoveEvent<T>>
	{
		private sealed class _ObservableCollectionMove : ObservableCollectionObserverBase<T, CollectionMoveEvent<T>>
		{
			public _ObservableCollectionMove(IObservableCollection<T> collection, Observer<CollectionMoveEvent<T>> observer, CancellationToken cancellationToken)
				: base(collection, observer, cancellationToken)
			{
			}

			protected override void Handler(in NotifyCollectionChangedEventArgs<T> eventArgs)
			{
				if (eventArgs.Action == NotifyCollectionChangedAction.Move)
				{
					observer.OnNext(new CollectionMoveEvent<T>(eventArgs.OldStartingIndex, eventArgs.NewStartingIndex, eventArgs.NewItem));
				}
			}
		}

		public ObservableCollectionMove(IObservableCollection<T> collection, CancellationToken cancellationToken)
		{
			_003Ccollection_003EP = collection;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<CollectionMoveEvent<T>> observer)
		{
			return new _ObservableCollectionMove(_003Ccollection_003EP, observer, _003CcancellationToken_003EP);
		}
	}
}
