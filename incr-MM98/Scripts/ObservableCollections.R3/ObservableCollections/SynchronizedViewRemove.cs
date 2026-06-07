using System;
using System.Collections.Specialized;
using System.Threading;
using R3;

namespace ObservableCollections
{
	internal sealed class SynchronizedViewRemove<T, TView> : Observable<CollectionRemoveEvent<(T, TView)>>
	{
		private sealed class _SynchronizedViewRemove : SynchronizedViewObserverBase<T, TView, CollectionRemoveEvent<(T, TView)>>
		{
			public _SynchronizedViewRemove(ISynchronizedView<T, TView> source, Observer<CollectionRemoveEvent<(T, TView)>> observer, CancellationToken cancellationToken)
				: base(source, observer, cancellationToken)
			{
			}

			protected override void Handler(in SynchronizedViewChangedEventArgs<T, TView> eventArgs)
			{
				if (eventArgs.Action != NotifyCollectionChangedAction.Remove)
				{
					return;
				}
				if (eventArgs.IsSingleItem)
				{
					observer.OnNext(new CollectionRemoveEvent<(T, TView)>(eventArgs.OldStartingIndex, eventArgs.OldItem));
					return;
				}
				for (int i = 0; i < eventArgs.OldValues.Length; i++)
				{
					observer.OnNext(new CollectionRemoveEvent<(T, TView)>(eventArgs.OldStartingIndex, (eventArgs.OldValues[i], eventArgs.OldViews[i])));
				}
			}
		}

		public SynchronizedViewRemove(ISynchronizedView<T, TView> source, CancellationToken cancellationToken)
		{
			_003Csource_003EP = source;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<CollectionRemoveEvent<(T, TView)>> observer)
		{
			return new _SynchronizedViewRemove(_003Csource_003EP, observer, _003CcancellationToken_003EP);
		}
	}
}
