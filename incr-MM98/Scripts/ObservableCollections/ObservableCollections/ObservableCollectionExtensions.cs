using System;

namespace ObservableCollections
{
	public static class ObservableCollectionExtensions
	{
		public static ISynchronizedViewList<T> ToViewList<T>(this IObservableCollection<T> collection)
		{
			return collection.ToViewList((T x) => x);
		}

		public static ISynchronizedViewList<TView> ToViewList<T, TView>(this IObservableCollection<T> collection, Func<T, TView> transform)
		{
			return new NonFilteredSynchronizedViewList<T, TView>(collection.CreateView(transform), isSupportRangeFeature: true, null, null);
		}

		public static NotifyCollectionChangedSynchronizedViewList<T> ToNotifyCollectionChanged<T>(this IObservableCollection<T> collection)
		{
			return collection.ToNotifyCollectionChanged(null);
		}

		public static NotifyCollectionChangedSynchronizedViewList<T> ToNotifyCollectionChanged<T>(this IObservableCollection<T> collection, ICollectionEventDispatcher? collectionEventDispatcher)
		{
			return collection.ToNotifyCollectionChanged((T x) => x, collectionEventDispatcher);
		}

		public static NotifyCollectionChangedSynchronizedViewList<TView> ToNotifyCollectionChanged<T, TView>(this IObservableCollection<T> collection, Func<T, TView> transform)
		{
			return collection.ToNotifyCollectionChanged(transform, null);
		}

		public static NotifyCollectionChangedSynchronizedViewList<TView> ToNotifyCollectionChanged<T, TView>(this IObservableCollection<T> collection, Func<T, TView> transform, ICollectionEventDispatcher? collectionEventDispatcher)
		{
			return new NonFilteredSynchronizedViewList<T, TView>(collection.CreateView(transform), isSupportRangeFeature: false, collectionEventDispatcher, null);
		}
	}
}
