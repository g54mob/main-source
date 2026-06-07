using System;
using System.Collections.Specialized;
using System.Threading;
using R3;

namespace ObservableCollections
{
	internal sealed class SynchronizedViewMove<T, TView> : Observable<CollectionMoveEvent<(T, TView)>>
	{
		private sealed class _SynchronizedViewMove : SynchronizedViewObserverBase<T, TView, CollectionMoveEvent<(T, TView)>>
		{
			public _SynchronizedViewMove(ISynchronizedView<T, TView> source, Observer<CollectionMoveEvent<(T, TView)>> observer, CancellationToken cancellationToken)
				: base(source, observer, cancellationToken)
			{
			}

			protected override void Handler(in SynchronizedViewChangedEventArgs<T, TView> eventArgs)
			{
				if (eventArgs.Action == NotifyCollectionChangedAction.Move)
				{
					observer.OnNext(new CollectionMoveEvent<(T, TView)>(eventArgs.OldStartingIndex, eventArgs.NewStartingIndex, eventArgs.NewItem));
				}
			}
		}

		public SynchronizedViewMove(ISynchronizedView<T, TView> source, CancellationToken cancellationToken)
		{
			_003Csource_003EP = source;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<CollectionMoveEvent<(T, TView)>> observer)
		{
			return new _SynchronizedViewMove(_003Csource_003EP, observer, _003CcancellationToken_003EP);
		}
	}
}
