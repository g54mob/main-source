using System;
using System.Collections.Specialized;
using System.Threading;
using R3;

namespace ObservableCollections
{
	internal sealed class SynchronizedViewChanged<T, TView> : Observable<ViewChangedEvent<T, TView>>
	{
		private sealed class _SynchronizedViewChanged : SynchronizedViewObserverBase<T, TView, ViewChangedEvent<T, TView>>
		{
			public _SynchronizedViewChanged(ISynchronizedView<T, TView> source, Observer<ViewChangedEvent<T, TView>> observer, CancellationToken cancellationToken)
				: base(source, observer, cancellationToken)
			{
			}

			protected override void Handler(in SynchronizedViewChangedEventArgs<T, TView> eventArgs)
			{
				if (eventArgs.IsSingleItem)
				{
					ViewChangedEvent<T, TView> value = new ViewChangedEvent<T, TView>(eventArgs.Action, eventArgs.NewItem, eventArgs.OldItem, eventArgs.NewStartingIndex, eventArgs.OldStartingIndex, eventArgs.SortOperation);
					observer.OnNext(value);
				}
				else if (eventArgs.Action == NotifyCollectionChangedAction.Add)
				{
					int newStartingIndex = eventArgs.NewStartingIndex;
					for (int i = 0; i < eventArgs.NewValues.Length; i++)
					{
						ViewChangedEvent<T, TView> value2 = new ViewChangedEvent<T, TView>(newItem: (eventArgs.NewValues[i], eventArgs.NewViews[i]), action: eventArgs.Action, oldItem: default((T, TView)), newStartingIndex: newStartingIndex++, oldStartingIndex: eventArgs.OldStartingIndex, sortOperation: eventArgs.SortOperation);
						observer.OnNext(value2);
					}
				}
				else if (eventArgs.Action == NotifyCollectionChangedAction.Remove)
				{
					for (int j = 0; j < eventArgs.OldValues.Length; j++)
					{
						ViewChangedEvent<T, TView> value3 = new ViewChangedEvent<T, TView>(oldItem: (eventArgs.OldValues[j], eventArgs.OldViews[j]), action: eventArgs.Action, newItem: default((T, TView)), newStartingIndex: eventArgs.NewStartingIndex, oldStartingIndex: eventArgs.OldStartingIndex, sortOperation: eventArgs.SortOperation);
						observer.OnNext(value3);
					}
				}
			}
		}

		public SynchronizedViewChanged(ISynchronizedView<T, TView> source, CancellationToken cancellationToken)
		{
			_003Csource_003EP = source;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<ViewChangedEvent<T, TView>> observer)
		{
			return new _SynchronizedViewChanged(_003Csource_003EP, observer, _003CcancellationToken_003EP);
		}
	}
}
