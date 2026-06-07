using System;
using System.Collections.Specialized;
using System.Threading;
using R3;

namespace ObservableCollections
{
	internal sealed class ObservableCollectionReset<T> : Observable<CollectionResetEvent<T>>
	{
		private sealed class _ObservableCollectionReset : ObservableCollectionObserverBase<T, CollectionResetEvent<T>>
		{
			public _ObservableCollectionReset(IObservableCollection<T> collection, Observer<CollectionResetEvent<T>> observer, CancellationToken cancellationToken)
				: base(collection, observer, cancellationToken)
			{
			}

			protected override void Handler(in NotifyCollectionChangedEventArgs<T> eventArgs)
			{
				if (eventArgs.Action == NotifyCollectionChangedAction.Reset)
				{
					observer.OnNext(new CollectionResetEvent<T>(eventArgs.SortOperation));
				}
			}
		}

		public ObservableCollectionReset(IObservableCollection<T> collection, CancellationToken cancellationToken)
		{
			_003Ccollection_003EP = collection;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<CollectionResetEvent<T>> observer)
		{
			return new _ObservableCollectionReset(_003Ccollection_003EP, observer, _003CcancellationToken_003EP);
		}
	}
}
