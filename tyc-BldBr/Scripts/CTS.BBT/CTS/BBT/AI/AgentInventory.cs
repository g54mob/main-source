using System;
using System.Collections.Generic;
using System.Linq;

namespace CTS.BBT.AI
{
	internal sealed class AgentInventory
	{
		private HashSet<Item> _inventory = new HashSet<Item>();

		public bool HasItem(Item p_item)
		{
			return _inventory.Contains(p_item);
		}

		public void PickupItem(Item p_item)
		{
			_inventory.Add(p_item);
			p_item.gameObject.SetActive(value: false);
		}

		public void RemoveItem(Item p_item)
		{
			_inventory.Remove(p_item);
		}

		public T GetFirst<T>() where T : Item
		{
			Type typeKey = typeof(T);
			return (T)_inventory.FirstOrDefault((Item item) => item.GetType() == typeKey);
		}

		public int ItemTypeCount<T>() where T : Item
		{
			return _inventory.OfType<T>().Count();
		}

		public bool HasAny<T>() where T : Item
		{
			Type typeFromHandle = typeof(T);
			using (HashSet<Item>.Enumerator enumerator = _inventory.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					Type type = enumerator.Current.GetType();
					return type == typeFromHandle || type.IsSubclassOf(typeFromHandle);
				}
			}
			return false;
		}

		public bool HasAny<T>(Func<T, bool> p_filter) where T : Item
		{
			Type typeFromHandle = typeof(T);
			foreach (Item item in _inventory)
			{
				Type type = item.GetType();
				if ((!(type != typeFromHandle) || type.IsSubclassOf(typeFromHandle)) && p_filter((T)item))
				{
					return true;
				}
			}
			return false;
		}

		public void Clear()
		{
			_inventory.Clear();
		}
	}
}
