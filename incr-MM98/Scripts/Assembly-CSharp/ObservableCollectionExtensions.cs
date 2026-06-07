using System.Collections.Generic;
using System.Collections.Specialized;
using ObservableCollections;
using R3;
using UnityEngine.Pool;
using ZLinq;

public static class ObservableCollectionExtensions
{
	public static void RemoveAll<TKey, TValue>(this ObservableDictionary<TKey, TValue> collection)
	{
		if (collection.Count == 0)
		{
			return;
		}
		List<TKey> list = CollectionPool<List<TKey>, TKey>.Get();
		list.AddRange((from x in collection.AsValueEnumerable()
			select x.Key).AsEnumerable());
		foreach (TKey item in list)
		{
			collection.Remove(item);
		}
	}

	public static Observable<bool> ObserveContains<T>(this IObservableCollection<T> source, T value)
	{
		EqualityComparer<T> comparer = EqualityComparer<T>.Default;
		int count = (from x in source.AsValueEnumerable()
			where comparer.Equals(x, value)
			select x).Count();
		return source.ObserveChanged().Select(ValueComparer).Prepend(count > 0)
			.DistinctUntilChanged();
		bool ValueComparer(CollectionChangedEvent<T> ctx)
		{
			if (ctx.Action == NotifyCollectionChangedAction.Reset)
			{
				count = 0;
			}
			else
			{
				if (comparer.Equals(ctx.NewItem, value))
				{
					count++;
				}
				if (comparer.Equals(ctx.OldItem, value))
				{
					count--;
				}
			}
			return count > 0;
		}
	}
}
