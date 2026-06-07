using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using R3;

namespace ObservableCollections
{
	internal sealed class ObservableCollectionSort<T> : Observable<(int Index, int Count, IComparer<T>? Comparer)>
	{
		private sealed class _ObservableCollectionSort : ObservableCollectionObserverBase<T, (int Index, int Count, IComparer<T>? Comparer)>
		{
			public _ObservableCollectionSort(IObservableCollection<T> collection, Observer<(int Index, int Count, IComparer<T>? Comparer)> observer, CancellationToken cancellationToken)
				: base(collection, observer, cancellationToken)
			{
			}

			protected override void Handler(in NotifyCollectionChangedEventArgs<T> eventArgs)
			{
				if (eventArgs.Action == NotifyCollectionChangedAction.Reset && eventArgs.SortOperation.IsSort)
				{
					observer.OnNext(eventArgs.SortOperation.AsTuple());
				}
			}
		}

		public ObservableCollectionSort(IObservableCollection<T> collection, CancellationToken cancellationToken)
		{
			_003Ccollection_003EP = collection;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<(int Index, int Count, IComparer<T>? Comparer)> observer)
		{
			return new _ObservableCollectionSort(_003Ccollection_003EP, observer, _003CcancellationToken_003EP);
		}
	}
}
