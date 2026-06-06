using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace ObservableCollections
{
	public interface ISynchronizedView<T, TView> : IReadOnlyCollection<TView>, IEnumerable<TView>, IEnumerable, IDisposable
	{
		object SyncRoot { get; }

		ISynchronizedViewFilter<T, TView> Filter { get; }

		IEnumerable<(T Value, TView View)> Filtered { get; }

		IEnumerable<(T Value, TView View)> Unfiltered { get; }

		int UnfilteredCount { get; }

		event NotifyViewChangedEventHandler<T, TView>? ViewChanged;

		event Action<RejectedViewChangedAction, int, int>? RejectedViewChanged;

		event Action<NotifyCollectionChangedAction>? CollectionStateChanged;

		void AttachFilter(ISynchronizedViewFilter<T, TView> filter);

		void ResetFilter();

		ISynchronizedViewList<TView> ToViewList();

		NotifyCollectionChangedSynchronizedViewList<TView> ToNotifyCollectionChanged();

		NotifyCollectionChangedSynchronizedViewList<TView> ToNotifyCollectionChanged(ICollectionEventDispatcher? collectionEventDispatcher);
	}
}
