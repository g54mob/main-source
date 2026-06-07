using System;
using System.Collections.Specialized;

namespace ObservableCollections
{
	public readonly ref struct SynchronizedViewChangedEventArgs<T, TView>
	{
		public readonly NotifyCollectionChangedAction Action;

		public readonly bool IsSingleItem;

		public readonly (T Value, TView View) NewItem;

		public readonly (T Value, TView View) OldItem;

		public readonly ReadOnlySpan<T> NewValues;

		public readonly ReadOnlySpan<TView> NewViews;

		public readonly ReadOnlySpan<T> OldValues;

		public readonly ReadOnlySpan<TView> OldViews;

		public readonly int NewStartingIndex;

		public readonly int OldStartingIndex;

		public readonly SortOperation<T> SortOperation;

		public SynchronizedViewChangedEventArgs(NotifyCollectionChangedAction action, bool isSingleItem, (T Value, TView View) newItem = default((T Value, TView View)), (T Value, TView View) oldItem = default((T Value, TView View)), ReadOnlySpan<T> newValues = default(ReadOnlySpan<T>), ReadOnlySpan<TView> newViews = default(ReadOnlySpan<TView>), ReadOnlySpan<T> oldValues = default(ReadOnlySpan<T>), ReadOnlySpan<TView> oldViews = default(ReadOnlySpan<TView>), int newStartingIndex = -1, int oldStartingIndex = -1, SortOperation<T> sortOperation = default(SortOperation<T>))
		{
			_003Caction_003EP = action;
			Action = _003Caction_003EP;
			IsSingleItem = isSingleItem;
			NewItem = newItem;
			OldItem = oldItem;
			NewValues = newValues;
			NewViews = newViews;
			OldValues = oldValues;
			OldViews = oldViews;
			NewStartingIndex = newStartingIndex;
			OldStartingIndex = oldStartingIndex;
			SortOperation = sortOperation;
		}

		public SynchronizedViewChangedEventArgs<T, TView> WithNewStartingIndex(int newStartingIndex)
		{
			return new SynchronizedViewChangedEventArgs<T, TView>(_003Caction_003EP, IsSingleItem, NewItem, OldItem, NewValues, NewViews, OldValues, OldViews, newStartingIndex, OldStartingIndex, SortOperation);
		}

		public SynchronizedViewChangedEventArgs<T, TView> WithOldStartingIndex(int oldStartingIndex)
		{
			return new SynchronizedViewChangedEventArgs<T, TView>(_003Caction_003EP, IsSingleItem, NewItem, OldItem, NewValues, NewViews, OldValues, OldViews, NewStartingIndex, oldStartingIndex, SortOperation);
		}

		public SynchronizedViewChangedEventArgs<T, TView> WithNewAndOldStartingIndex(int newStartingIndex, int oldStartingIndex)
		{
			return new SynchronizedViewChangedEventArgs<T, TView>(_003Caction_003EP, IsSingleItem, NewItem, OldItem, NewValues, NewViews, OldValues, OldViews, newStartingIndex, oldStartingIndex, SortOperation);
		}
	}
}
