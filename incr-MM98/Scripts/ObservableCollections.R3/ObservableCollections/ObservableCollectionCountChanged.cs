using System;
using System.Collections.Specialized;
using System.Threading;
using R3;

namespace ObservableCollections
{
	internal sealed class ObservableCollectionCountChanged<T> : Observable<int>
	{
		private sealed class _ObservableCollectionCountChanged : ObservableCollectionObserverBase<T, int>
		{
			private int countPrev;

			public _ObservableCollectionCountChanged(IObservableCollection<T> collection, bool notifyCurrentCount, Observer<int> observer, CancellationToken cancellationToken)
				: base(collection, observer, cancellationToken)
			{
				countPrev = collection.Count;
				if (notifyCurrentCount)
				{
					observer.OnNext(collection.Count);
				}
			}

			protected override void Handler(in NotifyCollectionChangedEventArgs<T> eventArgs)
			{
				NotifyCollectionChangedAction action = eventArgs.Action;
				if ((uint)action <= 1u || (action == NotifyCollectionChangedAction.Reset && countPrev != collection.Count))
				{
					observer.OnNext(collection.Count);
				}
				countPrev = collection.Count;
			}
		}

		public ObservableCollectionCountChanged(IObservableCollection<T> collection, bool notifyCurrentCount, CancellationToken cancellationToken)
		{
			_003Ccollection_003EP = collection;
			_003CnotifyCurrentCount_003EP = notifyCurrentCount;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<int> observer)
		{
			return new _ObservableCollectionCountChanged(_003Ccollection_003EP, _003CnotifyCurrentCount_003EP, observer, _003CcancellationToken_003EP);
		}
	}
}
