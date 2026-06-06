using System;
using System.Collections.Specialized;
using System.Threading;
using R3;

namespace ObservableCollections
{
	internal sealed class SynchronizedViewCountChanged<T, TView> : Observable<int>
	{
		private sealed class _SynchronizedViewCountChanged : SynchronizedViewObserverBase<T, TView, int>
		{
			private int countPrev;

			public _SynchronizedViewCountChanged(ISynchronizedView<T, TView> source, bool notifyCurrentCount, Observer<int> observer, CancellationToken cancellationToken)
				: base(source, observer, cancellationToken)
			{
				countPrev = source.Count;
				if (notifyCurrentCount)
				{
					observer.OnNext(source.Count);
				}
			}

			protected override void Handler(in SynchronizedViewChangedEventArgs<T, TView> eventArgs)
			{
				NotifyCollectionChangedAction action = eventArgs.Action;
				if ((uint)action <= 1u || (action == NotifyCollectionChangedAction.Reset && countPrev != source.Count))
				{
					observer.OnNext(source.Count);
				}
				countPrev = source.Count;
			}
		}

		public SynchronizedViewCountChanged(ISynchronizedView<T, TView> source, bool notifyCurrentCount, CancellationToken cancellationToken)
		{
			_003Csource_003EP = source;
			_003CnotifyCurrentCount_003EP = notifyCurrentCount;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<int> observer)
		{
			return new _SynchronizedViewCountChanged(_003Csource_003EP, _003CnotifyCurrentCount_003EP, observer, _003CcancellationToken_003EP);
		}
	}
}
