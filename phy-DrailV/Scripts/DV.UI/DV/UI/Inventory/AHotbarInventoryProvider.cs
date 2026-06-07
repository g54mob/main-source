using System;
using DV.Common;
using DV.InventorySystem;
using DV.UIFramework;
using UnityEngine;

namespace DV.UI.Inventory
{
	public abstract class AHotbarInventoryProvider : NullCheckingMonoBehaviour
	{
		public abstract DV.InventorySystem.Inventory Inventory { get; }

		public abstract bool IsGameInitialized { get; }

		public abstract bool IsBigInventoryOpen { get; }

		public abstract bool IsTimePaused { get; }

		public abstract bool IsHotbarAllowed { get; }

		public abstract bool IsHotbarButtonHeld { get; }

		public abstract int? SlotKey { get; }

		public abstract int MouseScroll { get; }

		public event Action<int> HotbarSelectionChangedInBigInventory;

		protected void HotbarSelectionChanged_Fire(int slot)
		{
			this.HotbarSelectionChangedInBigInventory?.Invoke(slot);
		}

		public abstract Vector2 GetMouseAxis();

		public abstract void RequestSlowMouse(bool slow);

		public abstract void OnSlotChanged(int slot);

		public abstract void StashToggle(int slot);

		public abstract string GetLocalizedNameForItem(IInventoryItemSpec item);

		public virtual bool CanAddToInventory(GameObject item)
		{
			if (!Inventory.HasFreeSlots() && !Inventory.IsDestroyedOnAddedToInventory(item))
			{
				return Inventory.FindReservedSlotForDroppedItem(item) != -1;
			}
			return true;
		}
	}
}
