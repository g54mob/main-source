using System;
using System.Collections.Specialized;
using System.Threading;
using R3;

namespace ObservableCollections
{
	internal sealed class SynchronizedViewAdd<T, TView> : Observable<CollectionAddEvent<(T, TView)>>
	{
		private sealed class _SynchronizedViewAdd : SynchronizedViewObserverBase<T, TView, CollectionAddEvent<(T, TView)>>
		{
			public _SynchronizedViewAdd(ISynchronizedView<T, TView> source, Observer<CollectionAddEvent<(T, TView)>> observer, CancellationToken cancellationToken)
				: base(source, observer, cancellationToken)
			{
			}

			protected override void Handler(in SynchronizedViewChangedEventArgs<T, TView> eventArgs)
			{
				if (eventArgs.Action != NotifyCollectionChangedAction.Add)
				{
					return;
				}
				if (eventArgs.IsSingleItem)
				{
					observer.OnNext(new CollectionAddEvent<(T, TView)>(eventArgs.NewStartingIndex, eventArgs.NewItem));
					return;
				}
				int newStartingIndex = eventArgs.NewStartingIndex;
				for (int i = 0; i < eventArgs.NewValues.Length; i++)
				{
					observer.OnNext(new CollectionAddEvent<(T, TView)>(newStartingIndex++, (eventArgs.NewValues[i], eventArgs.NewViews[i])));
				}
			}
		}

		public SynchronizedViewAdd(ISynchronizedView<T, TView> source, CancellationToken cancellationToken)
		{
			_003Csource_003EP = source;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<CollectionAddEvent<(T, TView)>> observer)
		{
			return new _SynchronizedViewAdd(_003Csource_003EP, observer, _003CcancellationToken_003EP);
		}
	}
}
