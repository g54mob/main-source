using System;
using System.Collections.Specialized;
using System.Threading;
using R3;

namespace ObservableCollections
{
	internal sealed class ObservableCollectionClear<T> : Observable<Unit>
	{
		private sealed class _ObservableCollectionClear : ObservableCollectionObserverBase<T, Unit>
		{
			public _ObservableCollectionClear(IObservableCollection<T> collection, Observer<Unit> observer, CancellationToken cancellationToken)
				: base(collection, observer, cancellationToken)
			{
			}

			protected override void Handler(in NotifyCollectionChangedEventArgs<T> eventArgs)
			{
				if (eventArgs.Action == NotifyCollectionChangedAction.Reset && eventArgs.SortOperation.IsClear)
				{
					observer.OnNext(Unit.Default);
				}
			}
		}

		public ObservableCollectionClear(IObservableCollection<T> collection, CancellationToken cancellationToken)
		{
			_003Ccollection_003EP = collection;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<Unit> observer)
		{
			return new _ObservableCollectionClear(_003Ccollection_003EP, observer, _003CcancellationToken_003EP);
		}
	}
}
