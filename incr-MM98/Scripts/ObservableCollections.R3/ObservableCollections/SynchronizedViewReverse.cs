using System;
using System.Collections.Specialized;
using System.Threading;
using R3;

namespace ObservableCollections
{
	internal sealed class SynchronizedViewReverse<T, TView> : Observable<(int Index, int Count)>
	{
		private sealed class _SynchronizedViewReverse : SynchronizedViewObserverBase<T, TView, (int Index, int Count)>
		{
			public _SynchronizedViewReverse(ISynchronizedView<T, TView> source, Observer<(int Index, int Count)> observer, CancellationToken cancellationToken)
				: base(source, observer, cancellationToken)
			{
			}

			protected override void Handler(in SynchronizedViewChangedEventArgs<T, TView> eventArgs)
			{
				if (eventArgs.Action == NotifyCollectionChangedAction.Reset && eventArgs.SortOperation.IsReverse)
				{
					observer.OnNext((eventArgs.SortOperation.Index, eventArgs.SortOperation.Count));
				}
			}
		}

		public SynchronizedViewReverse(ISynchronizedView<T, TView> source, CancellationToken cancellationToken)
		{
			_003Csource_003EP = source;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<(int Index, int Count)> observer)
		{
			return new _SynchronizedViewReverse(_003Csource_003EP, observer, _003CcancellationToken_003EP);
		}
	}
}
