using System;
using System.Collections.Specialized;
using System.Threading;
using R3;

namespace ObservableCollections
{
	internal sealed class SynchronizedViewClear<T, TView> : Observable<Unit>
	{
		private sealed class _SynchronizedViewClear : SynchronizedViewObserverBase<T, TView, Unit>
		{
			public _SynchronizedViewClear(ISynchronizedView<T, TView> source, Observer<Unit> observer, CancellationToken cancellationToken)
				: base(source, observer, cancellationToken)
			{
			}

			protected override void Handler(in SynchronizedViewChangedEventArgs<T, TView> eventArgs)
			{
				if (eventArgs.Action == NotifyCollectionChangedAction.Reset && eventArgs.SortOperation.IsClear)
				{
					observer.OnNext(Unit.Default);
				}
			}
		}

		public SynchronizedViewClear(ISynchronizedView<T, TView> source, CancellationToken cancellationToken)
		{
			_003Csource_003EP = source;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<Unit> observer)
		{
			return new _SynchronizedViewClear(_003Csource_003EP, observer, _003CcancellationToken_003EP);
		}
	}
}
