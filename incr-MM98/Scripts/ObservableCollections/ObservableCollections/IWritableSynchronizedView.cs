using System;
using System.Collections;
using System.Collections.Generic;

namespace ObservableCollections
{
	public interface IWritableSynchronizedView<T, TView> : ISynchronizedView<T, TView>, IReadOnlyCollection<TView>, IEnumerable<TView>, IEnumerable, IDisposable
	{
		(T Value, TView View) GetAt(int index);

		void SetViewAt(int index, TView view);

		void SetToSourceCollection(int index, T value);

		void AddToSourceCollection(T value);

		void InsertIntoSourceCollection(int index, T value);

		bool RemoveFromSourceCollection(T value);

		void RemoveAtSourceCollection(int index);

		void ClearSourceCollection();

		IWritableSynchronizedViewList<TView> ToWritableViewList(WritableViewChangedEventHandler<T, TView> converter);

		NotifyCollectionChangedSynchronizedViewList<TView> ToWritableNotifyCollectionChanged();

		NotifyCollectionChangedSynchronizedViewList<TView> ToWritableNotifyCollectionChanged(WritableViewChangedEventHandler<T, TView> converter);

		NotifyCollectionChangedSynchronizedViewList<TView> ToWritableNotifyCollectionChanged(ICollectionEventDispatcher? collectionEventDispatcher);

		NotifyCollectionChangedSynchronizedViewList<TView> ToWritableNotifyCollectionChanged(WritableViewChangedEventHandler<T, TView> converter, ICollectionEventDispatcher? collectionEventDispatcher);
	}
}
