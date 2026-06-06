using System;
using System.Collections.Specialized;
using System.Threading;
using R3;

namespace ObservableCollections
{
	internal sealed class ObservableCollectionReverse<T> : Observable<(int Index, int Count)>
	{
		private sealed class _ObservableCollectionReverse : ObservableCollectionObserverBase<T, (int Index, int Count)>
		{
			public _ObservableCollectionReverse(IObservableCollection<T> collection, Observer<(int Index, int Count)> observer, CancellationToken cancellationToken)
				: base(collection, observer, cancellationToken)
			{
			}

			protected override void Handler(in NotifyCollectionChangedEventArgs<T> eventArgs)
			{
				if (eventArgs.Action == NotifyCollectionChangedAction.Reset && eventArgs.SortOperation.IsReverse)
				{
					observer.OnNext((eventArgs.SortOperation.Index, eventArgs.SortOperation.Count));
				}
			}
		}

		public ObservableCollectionReverse(IObservableCollection<T> collection, CancellationToken cancellationToken)
		{
			_003Ccollection_003EP = collection;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<(int Index, int Count)> observer)
		{
			return new _ObservableCollectionReverse(_003Ccollection_003EP, observer, _003CcancellationToken_003EP);
		}
	}
}
