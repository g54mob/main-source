using System;
using System.Collections.Specialized;
using System.Threading;
using R3;

namespace ObservableCollections
{
	internal sealed class SynchronizedViewReplace<T, TView> : Observable<CollectionReplaceEvent<(T, TView)>>
	{
		private sealed class _SynchronizedViewReplace : SynchronizedViewObserverBase<T, TView, CollectionReplaceEvent<(T, TView)>>
		{
			public _SynchronizedViewReplace(ISynchronizedView<T, TView> source, Observer<CollectionReplaceEvent<(T, TView)>> observer, CancellationToken cancellationToken)
				: base(source, observer, cancellationToken)
			{
			}

			protected override void Handler(in SynchronizedViewChangedEventArgs<T, TView> eventArgs)
			{
				if (eventArgs.Action == NotifyCollectionChangedAction.Replace)
				{
					observer.OnNext(new CollectionReplaceEvent<(T, TView)>(eventArgs.NewStartingIndex, eventArgs.OldItem, eventArgs.NewItem));
				}
			}
		}

		public SynchronizedViewReplace(ISynchronizedView<T, TView> source, CancellationToken cancellationToken)
		{
			_003Csource_003EP = source;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<CollectionReplaceEvent<(T, TView)>> observer)
		{
			return new _SynchronizedViewReplace(_003Csource_003EP, observer, _003CcancellationToken_003EP);
		}
	}
}
