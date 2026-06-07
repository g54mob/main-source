using System.Linq;
using DV.CabControls;
using DV.Interaction;
using DV.InventorySystem;
using DV.Items;
using DV.Utils;
using UnityEngine;

public static class ItemUtils
{
	private static Grabber grabber;

	private static readonly string[] SinglePrefabNameCache = new string[1];

	private static Grabber Grabber
	{
		get
		{
			if (VRManager.IsVREnabled())
			{
				return null;
			}
			if (grabber == null && PlayerManager.PlayerTransform != null)
			{
				grabber = PlayerManager.PlayerTransform.GetComponentInChildren<Grabber>(includeInactive: true);
			}
			return grabber;
		}
	}

	public static bool IsBoundToPlayer(this ItemBase item, bool includeInStashedContainer = false)
	{
		if (item == null)
		{
			Debug.LogError("IsBoundToPlayer method requires a valid ItemBase reference. Returning false.");
			return false;
		}
		if (!(includeInStashedContainer ? item.IsGrabbedOrInGrabbedContainer() : item.IsGrabbed()) && !item.IsInInventory(includeInStashedContainer))
		{
			return item.IsInBelt(includeInStashedContainer);
		}
		return true;
	}

	public static bool IsGrabbedOrInGrabbedContainer(this ItemBase item)
	{
		if (item.IsGrabbed())
		{
			return true;
		}
		ItemContainer lastNestedContainer = item.GetLastNestedContainer();
		if (lastNestedContainer != null)
		{
			return lastNestedContainer.ItemBase.IsGrabbed();
		}
		return false;
	}

	public static ItemContainer GetLastNestedContainer(this ItemBase item)
	{
		ItemContainer inContainer = item.InContainer;
		if (inContainer == null)
		{
			return null;
		}
		AItemContainer item2 = inContainer.NestedIn.lastNest;
		ItemContainer itemContainer = item2 as ItemContainer;
		if (item2 != null && itemContainer == null)
		{
			return null;
		}
		if (!(itemContainer != null))
		{
			return inContainer;
		}
		return itemContainer;
	}

	public static bool IsWithin(this ItemBase item, AItemContainer container)
	{
		if (item.InContainer == container)
		{
			return true;
		}
		if (item.InContainer == null)
		{
			return false;
		}
		AItemContainer aItemContainer = item.InContainer;
		while (aItemContainer != null)
		{
			if (aItemContainer == container)
			{
				return true;
			}
			aItemContainer = aItemContainer.NestedIn.firstNest;
		}
		return false;
	}

	public static bool IsInInventory(this ItemBase item, bool includeInStashedContainer = false)
	{
		if (item == null)
		{
			Debug.LogError("IsInInventory method requires a valid ItemBase reference. Returning false.");
			return false;
		}
		if (!SingletonBehaviour<Inventory>.Instance)
		{
			Debug.LogError("IsInInventory couldn't find Inventory instance. Returning false.");
			return false;
		}
		if (SingletonBehaviour<Inventory>.Instance.Contains(item.gameObject, includeDropped: false))
		{
			return true;
		}
		if (!includeInStashedContainer)
		{
			return false;
		}
		ItemContainer lastNestedContainer = item.GetLastNestedContainer();
		if (lastNestedContainer != null)
		{
			return SingletonBehaviour<Inventory>.Instance.Contains(lastNestedContainer.gameObject, includeDropped: false);
		}
		return false;
	}

	public static bool IsInBelt(this ItemBase item, bool includeInStashedContainer = false)
	{
		if (item == null)
		{
			Debug.LogError("IsInBelt method requires a valid ItemBase reference. Returning false.");
			return false;
		}
		if (!VRManager.IsVREnabled())
		{
			return false;
		}
		ItemBase itemBase = item;
		if (!item.IsBeltSnappable)
		{
			if (!includeInStashedContainer)
			{
				return false;
			}
			ItemContainer lastNestedContainer = item.GetLastNestedContainer();
			if (lastNestedContainer == null || !lastNestedContainer.ItemBase.IsBeltSnappable)
			{
				return false;
			}
			itemBase = lastNestedContainer.ItemBase;
		}
		int num = SingletonBehaviour<Inventory>.Instance.IndexOf(itemBase.gameObject);
		if (InventoryUtils.IsValidBeltIndex(num))
		{
			return !SingletonBehaviour<Inventory>.Instance.GetSlotDroppedState(num);
		}
		return false;
	}

	public static bool IsInHotbar(this ItemBase item, bool includeInStashedContainer = false)
	{
		if (item == null)
		{
			Debug.LogError("IsInBelt method requires a valid ItemBase reference. Returning false.");
			return false;
		}
		if (item.InContainer != null && !includeInStashedContainer)
		{
			return false;
		}
		ItemBase itemBase = ((item.InContainer == null) ? item : item.GetLastNestedContainer().GetComponent<ItemBase>());
		return InventoryUtils.IsValidHotbarIndex(SingletonBehaviour<Inventory>.Instance.IndexOf(itemBase.gameObject));
	}

	public static bool BelongsToPlayer(this ItemBase item)
	{
		if (item == null)
		{
			Debug.LogError("BelongsToPlayer method requires a valid ItemBase reference. Returning false.");
			return false;
		}
		if (item.InventorySpecs == null)
		{
			Debug.LogError("ItemBase doesn't have a valid InventoryItemSpec reference. This should not happen. BelongsToPlayer returning false.");
			return false;
		}
		return item.InventorySpecs.BelongsToPlayer;
	}

	public static bool IsEssential(this ItemBase item)
	{
		if (item == null)
		{
			Debug.LogError("IsEssential method requires a valid ItemBase reference. Returning false.");
			return false;
		}
		if (item.InventorySpecs == null)
		{
			Debug.LogError("ItemBase doesn't have a valid InventoryItemSpec reference. This should not happen. IsEssential returning false.");
			return false;
		}
		return item.InventorySpecs.IsEssential;
	}

	public static ItemBase GetFirstItemByPrefabName(this IRecursiveItemStorage storage, string prefabName, bool recursive = true, bool includeDropped = true)
	{
		SinglePrefabNameCache[0] = prefabName;
		return storage.GetFirstItemByPrefabNames(SinglePrefabNameCache, recursive, includeDropped);
	}

	public static ItemBase GetFirstItemByPrefabNames(this IRecursiveItemStorage storage, string[] prefabNames, bool recursive = true, bool includeDropped = true)
	{
		GameObject gameObject = storage.FindFirst(delegate(GameObject o)
		{
			InventoryItemSpec component = o.GetComponent<InventoryItemSpec>();
			return (bool)component && prefabNames.Contains(component.ItemPrefabName);
		}, recursive, includeDropped);
		if (!gameObject)
		{
			return null;
		}
		return gameObject.GetComponent<ItemBase>();
	}

	public static ItemBase[] GetAllItemsByPrefabName(this IRecursiveItemStorage storage, string prefabName, bool recursive = true, bool includeDropped = true)
	{
		SinglePrefabNameCache[0] = prefabName;
		return storage.GetAllItemsByPrefabNames(SinglePrefabNameCache, recursive, includeDropped);
	}

	public static ItemBase[] GetAllItemsByPrefabNames(this IRecursiveItemStorage storage, string[] prefabNames, bool recursive = true, bool includeDropped = true)
	{
		return (from o in storage.FindAll(delegate(GameObject o)
			{
				InventoryItemSpec component = o.GetComponent<InventoryItemSpec>();
				return (bool)component && prefabNames.Contains(component.ItemPrefabName);
			}, recursive, includeDropped)
			select o.GetComponent<ItemBase>()).ToArray();
	}
}
