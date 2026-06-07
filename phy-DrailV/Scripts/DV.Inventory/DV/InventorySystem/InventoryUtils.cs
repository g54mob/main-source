using System.Collections.Generic;
using DV.Utils;
using UnityEngine;

namespace DV.InventorySystem
{
	public static class InventoryUtils
	{
		public delegate bool ItemSearchDelegate(GameObject item);

		public const int INVENTORY_SIZE = 36;

		public const int INVENTORY_START_INDEX = 0;

		public const int INVENTORY_LAST_INDEX = 35;

		public const int HAND_SIZE_NON_VR = 1;

		public const int HAND_SIZE_VR = 2;

		public const int HOTBAR_SIZE = 12;

		public const int HOTBAR_START_INDEX = 0;

		public const int HOTBAR_END_INDEX = 11;

		public const int BACKPACK_SIZE = 24;

		public const int BACKPACK_START_INDEX = 12;

		public const int BACKPACK_END_INDEX = 35;

		public const int VR_BELT_SIZE = 3;

		public const int VR_BELT_START_INDEX = 33;

		public const int VR_BELT_END_INDEX = 35;

		public static bool IsValidInventoryIndex(int index)
		{
			return index.IsInRange(0, 35);
		}

		public static bool IsValidHotbarIndex(int index)
		{
			return index.IsInRange(0, 11);
		}

		public static bool IsValidBeltIndex(int index)
		{
			return index.IsInRange(33, 35);
		}

		public static bool IsInInventory(this InventoryItemState state)
		{
			if (state != InventoryItemState.Enabled)
			{
				return state == InventoryItemState.Disabled;
			}
			return true;
		}

		public static bool StashMoney(this IMoney money)
		{
			if (money == null)
			{
				return false;
			}
			if (!money.ShouldDestroyOnUse || money.Amount <= double.Epsilon)
			{
				return false;
			}
			if (SingletonBehaviour<Inventory>.Instance != null)
			{
				return IsValidInventoryIndex(SingletonBehaviour<Inventory>.Instance.AddItemToInventory(money.gameObject));
			}
			return false;
		}

		public static bool Contains(this IRecursiveItemStorage storage, ItemSearchDelegate predicate, bool recursive = true, bool includingDropped = true)
		{
			return storage.FindFirst(predicate, recursive, includingDropped) != null;
		}

		public static GameObject FindFirst(this IRecursiveItemStorage storage, ItemSearchDelegate predicate, bool recursive, bool includingDropped)
		{
			GameObject[] itemsArray = storage.GetItemsArray();
			for (int i = 0; i < storage.Capacity; i++)
			{
				if (itemsArray[i] == null)
				{
					continue;
				}
				if (predicate(itemsArray[i]))
				{
					return itemsArray[i];
				}
				if (!recursive)
				{
					continue;
				}
				AItemContainer component = itemsArray[i].GetComponent<AItemContainer>();
				if (component != null)
				{
					GameObject gameObject = component.FindFirst(predicate, recursive: true, includingDropped);
					if ((bool)gameObject)
					{
						return gameObject;
					}
				}
			}
			return null;
		}

		public static List<GameObject> FindAll(this IRecursiveItemStorage storage, ItemSearchDelegate predicate, bool recursive, bool includingDropped, List<GameObject> results = null)
		{
			if (results == null)
			{
				results = new List<GameObject>();
			}
			GameObject[] itemsArray = storage.GetItemsArray();
			for (int i = 0; i < storage.Capacity; i++)
			{
				if (itemsArray[i] == null)
				{
					continue;
				}
				if (predicate(itemsArray[i]))
				{
					results.Add(itemsArray[i]);
				}
				if (recursive)
				{
					AItemContainer component = itemsArray[i].GetComponent<AItemContainer>();
					if (component != null)
					{
						component.FindAll(predicate, recursive: true, includingDropped, results);
					}
				}
			}
			return results;
		}
	}
}
