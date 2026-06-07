using System.Collections.Generic;
using DV.CabControls;
using DV.Utils;
using UnityEngine;

namespace DV.InventorySystem
{
	public class InventoryItemDestructionNotifier : MonoBehaviour
	{
		private const InventoryActionType VALID_INVENTORY_ACTIONS = InventoryActionType.Add | InventoryActionType.Purge | InventoryActionType.Equip | InventoryActionType.Unequip | InventoryActionType.Reserve | InventoryActionType.Unreserve;

		private HashSet<GameObject> registeredInventoryItems = new HashSet<GameObject>();

		private void Awake()
		{
			SetupListeners(on: true);
		}

		private void OnDestroy()
		{
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				if (SingletonBehaviour<Inventory>.Instance != null)
				{
					SingletonBehaviour<Inventory>.Instance.InventoryStatusChanged += OnInventoryStatusChanged;
				}
				else
				{
					Debug.LogError("InventoryItemDestructionNotifier: Inventory does not exist. Cannot setup listeners.", this);
				}
				return;
			}
			if (SingletonBehaviour<Inventory>.Instance != null)
			{
				SingletonBehaviour<Inventory>.Instance.InventoryStatusChanged -= OnInventoryStatusChanged;
			}
			foreach (GameObject registeredInventoryItem in registeredInventoryItems)
			{
				ItemBase itemBase = ((registeredInventoryItem != null) ? registeredInventoryItem.GetComponent<ItemBase>() : null);
				if (!(itemBase == null))
				{
					itemBase.AboutToBeDestroyed -= OnItemAboutToBeDestroyed;
				}
			}
		}

		private void RegisterItemDestruction(GameObject item)
		{
			if (registeredInventoryItems.Add(item))
			{
				ItemBase component = item.GetComponent<ItemBase>();
				if (!(component == null))
				{
					component.AboutToBeDestroyed += OnItemAboutToBeDestroyed;
				}
			}
		}

		private void UnregisterItemDestruction(GameObject item)
		{
			if (registeredInventoryItems.Remove(item))
			{
				ItemBase component = item.GetComponent<ItemBase>();
				if (!(component == null))
				{
					component.AboutToBeDestroyed -= OnItemAboutToBeDestroyed;
				}
			}
		}

		private void OnInventoryStatusChanged(InventorySlotState originState, InventoryActionType originActionType, InventorySlotState _, InventoryActionType __)
		{
			if (!originActionType.HasAnyIntFlag(InventoryActionType.Add | InventoryActionType.Purge | InventoryActionType.Equip | InventoryActionType.Unequip | InventoryActionType.Reserve | InventoryActionType.Unreserve))
			{
				return;
			}
			GameObject item = originState.item;
			if (!(item == null))
			{
				if (originActionType.HasAnyIntFlag(InventoryActionType.Add | InventoryActionType.Equip | InventoryActionType.Reserve))
				{
					RegisterItemDestruction(item);
				}
				else if (originActionType.HasAnyIntFlag(InventoryActionType.Purge | InventoryActionType.Unequip | InventoryActionType.Unreserve) && !SingletonBehaviour<Inventory>.Instance.Contains(item))
				{
					UnregisterItemDestruction(item);
				}
			}
		}

		private void OnItemAboutToBeDestroyed(ItemBase item)
		{
			if (item == null)
			{
				Debug.LogError("InventoryItemDestructionNotifier cannot notify about item destruction, item is null.", this);
				return;
			}
			UnregisterItemDestruction(item.gameObject);
			SingletonBehaviour<Inventory>.Instance.PurgeFromInventory(item.gameObject);
		}
	}
}
