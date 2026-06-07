using DV.CabControls;
using DV.InventorySystem;
using DV.Utils;
using UnityEngine;

namespace DV.Items
{
	public class InventoryItemEventsPropagator : MonoBehaviour
	{
		private void Start()
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
					Debug.LogError("InventoryItemEventsPropagator: Inventory does not exist. Cannot setup listeners.", this);
				}
			}
			else if (!(SingletonBehaviour<Inventory>.Instance == null))
			{
				SingletonBehaviour<Inventory>.Instance.InventoryStatusChanged -= OnInventoryStatusChanged;
			}
		}

		private void OnInventoryStatusChanged(InventorySlotState primarySlotState, InventoryActionType primaryActionType, InventorySlotState secondarySlotState, InventoryActionType secondaryActionType)
		{
			if (secondaryActionType.HasAnyIntFlag(InventoryActionType.Move))
			{
				PropagateToItem(secondarySlotState.item, secondaryActionType, secondarySlotState.itemState);
				return;
			}
			PropagateToItem(primarySlotState.item, primaryActionType, primarySlotState.itemState);
			if (primaryActionType.HasAnyIntFlag(InventoryActionType.Swap))
			{
				PropagateToItem(secondarySlotState.item, secondaryActionType, secondarySlotState.itemState);
			}
		}

		private void PropagateToItem(GameObject item, InventoryActionType actionType, InventoryItemState itemState)
		{
			bool flag = actionType.HasAnyIntFlag(InventoryActionType.BeltVisible | InventoryActionType.BeltHidden | InventoryActionType.BeltDisabled | InventoryActionType.BeltEnabled);
			if (!(itemState == InventoryItemState.None && flag))
			{
				ItemBase itemBase = ((item != null) ? item.GetComponent<ItemBase>() : null);
				if (itemBase == null)
				{
					Debug.LogError("InventoryItemEventsPropagator trying to propagate event with a missing itemBase component. This should never happen. Aborting.", this);
				}
				else
				{
					itemBase.FireInventoryStateChanged(actionType, itemState);
				}
			}
		}
	}
}
