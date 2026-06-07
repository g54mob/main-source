using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using R3;

namespace ObservableCollections
{
	internal sealed class SynchronizedViewSort<T, TView> : Observable<(int Index, int Count, IComparer<T>? Comparer)>
	{
		private sealed class _SynchronizedViewSort : SynchronizedViewObserverBase<T, TView, (int Index, int Count, IComparer<T>? Comparer)>
		{
			public _SynchronizedViewSort(ISynchronizedView<T, TView> source, Observer<(int Index, int Count, IComparer<T>? Comparer)> observer, CancellationToken cancellationToken)
				: base(source, observer, cancellationToken)
			{
			}

			protected override void Handler(in SynchronizedViewChangedEventArgs<T, TView> eventArgs)
			{
				if (eventArgs.Action == NotifyCollectionChangedAction.Reset && eventArgs.SortOperation.IsSort)
				{
					observer.OnNext(eventArgs.SortOperation.AsTuple());
				}
			}
		}

		public SynchronizedViewSort(ISynchronizedView<T, TView> source, CancellationToken cancellationToken)
		{
			_003Csource_003EP = source;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<(int Index, int Count, IComparer<T>? Comparer)> observer)
		{
			return new _SynchronizedViewSort(_003Csource_003EP, observer, _003CcancellationToken_003EP);
		}
	}
}
