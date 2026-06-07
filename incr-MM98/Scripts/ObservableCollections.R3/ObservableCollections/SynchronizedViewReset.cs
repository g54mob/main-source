using System;
using System.Collections.Specialized;
using System.Threading;
using R3;

namespace ObservableCollections
{
	internal sealed class SynchronizedViewReset<T, TView> : Observable<CollectionResetEvent<T>>
	{
		private sealed class _SynchronizedViewReset : SynchronizedViewObserverBase<T, TView, CollectionResetEvent<T>>
		{
			public _SynchronizedViewReset(ISynchronizedView<T, TView> source, Observer<CollectionResetEvent<T>> observer, CancellationToken cancellationToken)
				: base(source, observer, cancellationToken)
			{
			}

			protected override void Handler(in SynchronizedViewChangedEventArgs<T, TView> eventArgs)
			{
				if (eventArgs.Action == NotifyCollectionChangedAction.Reset)
				{
					observer.OnNext(new CollectionResetEvent<T>(eventArgs.SortOperation));
				}
			}
		}

		public SynchronizedViewReset(ISynchronizedView<T, TView> source, CancellationToken cancellationToken)
		{
			_003Csource_003EP = source;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<CollectionResetEvent<T>> observer)
		{
			return new _SynchronizedViewReset(_003Csource_003EP, observer, _003CcancellationToken_003EP);
		}
	}
}
