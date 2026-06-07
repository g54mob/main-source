using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utility
{
	public class ItemPool<T> : ItemPool<List<T>, T> where T : PoolableItem<T>
	{
		public T this[int i] => activeItems[i];

		protected override void AssignActiveCollection()
		{
			activeItems = new List<T>();
		}

		public T GetItemFromPool()
		{
			T orCreateItemFromPool = GetOrCreateItemFromPool();
			activeItems.Add(orCreateItemFromPool);
			return orCreateItemFromPool;
		}

		public void WakeUpItems(int n)
		{
			for (int i = 0; i < n; i++)
			{
				GetItemFromPool();
			}
		}

		public override void ForEachActive(Action<T> action)
		{
			activeItems.ForEach(action.Invoke);
		}

		protected override void RemoveFromActive(T item)
		{
			activeItems.Remove(item);
		}

		public void RetireLasts(int n)
		{
			if (n >= base.activeCount)
			{
				RetireAll();
				return;
			}
			int num = base.activeCount - n;
			for (int num2 = base.activeCount - 1; num2 >= num; num2--)
			{
				ReturnItem(activeItems[num2]);
			}
		}

		protected override void RetireAllItemsToPool()
		{
			activeItems.ForEach(delegate(T t)
			{
				t.Retire();
				itemPool.Add(t);
			});
			activeItems.Clear();
		}

		public ItemPool(GameObject itemPrefab, Transform itemHolder, int itemLimit = int.MaxValue)
			: base(itemPrefab, itemHolder, itemLimit)
		{
		}
	}
	public abstract class ItemPool<TCollection, T> : IItemPool<T> where TCollection : ICollection where T : PoolableItem<T>
	{
		protected readonly GameObject prefab;

		protected readonly Transform holder;

		protected readonly int limit;

		protected readonly List<T> itemPool = new List<T>();

		public TCollection activeItems;

		protected readonly List<T> delayedReturnItems = new List<T>();

		public Action<T> actionOnCreate;

		public int activeCount => activeItems.Count;

		public ItemPool(GameObject itemPrefab, Transform itemHolder, int itemLimit = int.MaxValue)
		{
			prefab = itemPrefab;
			holder = itemHolder;
			limit = itemLimit;
			AssignActiveCollection();
		}

		protected abstract void AssignActiveCollection();

		protected T GetOrCreateItemFromPool()
		{
			T val;
			if (itemPool.Count > 0)
			{
				val = itemPool.First();
				itemPool.Remove(val);
			}
			else
			{
				val = UnityEngine.Object.Instantiate(prefab, holder).GetComponent<T>();
				val.InitPoolableItem(this);
				actionOnCreate?.Invoke(val);
			}
			val.WakeUp();
			return val;
		}

		public void ReturnItem(T item)
		{
			item.Retire();
			RemoveFromActive(item);
			itemPool.Add(item);
		}

		protected abstract void RemoveFromActive(T item);

		public void ReturnItemDelayed(T item)
		{
			item.Retire();
			delayedReturnItems.Add(item);
		}

		public abstract void ForEachActive(Action<T> action);

		public void ReturnDelayedItems()
		{
			foreach (T delayedReturnItem in delayedReturnItems)
			{
				RemoveFromActive(delayedReturnItem);
				itemPool.Add(delayedReturnItem);
			}
			delayedReturnItems.Clear();
		}

		public void RetireAll()
		{
			RetireAllItemsToPool();
			if (itemPool.Count < limit)
			{
				return;
			}
			foreach (T item in itemPool.Skip(limit).ToList())
			{
				itemPool.Remove(item);
				item.Destroy();
			}
		}

		protected abstract void RetireAllItemsToPool();
	}
}
