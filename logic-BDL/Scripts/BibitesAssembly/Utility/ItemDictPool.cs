using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utility
{
	public class ItemDictPool<TKey, T> : ItemPool<Dictionary<TKey, T>, T> where T : PoolableDictItem<TKey, T>
	{
		public List<TKey> activeKeys => activeItems.Select((KeyValuePair<TKey, T> p) => p.Key).ToList();

		public List<T> activeItemsList => activeItems.Select((KeyValuePair<TKey, T> p) => p.Value).ToList();

		public List<T> allItemsList => activeItems.Select((KeyValuePair<TKey, T> p) => p.Value).Union(itemPool).ToList();

		public T this[TKey key] => GetItemWithKey(key);

		public ItemDictPool(GameObject itemPrefab, Transform itemHolder, int itemLimit = int.MaxValue)
			: base(itemPrefab, itemHolder, itemLimit)
		{
		}

		protected override void AssignActiveCollection()
		{
			activeItems = new Dictionary<TKey, T>();
		}

		public virtual T GetItemWithKey(TKey key, Action<T> actionOnWakeUp = null)
		{
			if (activeItems.TryGetValue(key, out var value))
			{
				return value;
			}
			T orCreateItemFromPool = GetOrCreateItemFromPool();
			activeItems.Add(key, orCreateItemFromPool);
			orCreateItemFromPool.AssignKey(key);
			actionOnWakeUp?.Invoke(orCreateItemFromPool);
			return orCreateItemFromPool;
		}

		public bool TryGetItemWithKey(TKey key, out T item)
		{
			return activeItems.TryGetValue(key, out item);
		}

		public bool HasItemWithKey(TKey key)
		{
			return activeItems.ContainsKey(key);
		}

		public void RetireItemWithKey(TKey key)
		{
			if (key != null && activeItems.ContainsKey(key))
			{
				T val = activeItems[key];
				val.Retire();
				activeItems.Remove(key);
				itemPool.Add(val);
			}
		}

		protected override void RemoveFromActive(T item)
		{
			TKey key = activeItems.FirstOrDefault((KeyValuePair<TKey, T> pair) => pair.Value == item).Key;
			if (key != null)
			{
				activeItems.Remove(key);
			}
		}

		public override void ForEachActive(Action<T> action)
		{
			foreach (KeyValuePair<TKey, T> activeItem in activeItems)
			{
				action(activeItem.Value);
			}
		}

		public void RetireKeys(List<TKey> keys)
		{
			keys.ForEach(RetireItemWithKey);
		}

		protected override void RetireAllItemsToPool()
		{
			foreach (KeyValuePair<TKey, T> activeItem in activeItems)
			{
				activeItem.Value.Retire();
				itemPool.Add(activeItem.Value);
			}
			activeItems.Clear();
		}
	}
}
