using System;
using DV.Common;
using DV.InventorySystem;
using DV.UIFramework;

namespace DV.UI.Inventory
{
	public abstract class AInventoryProvider : NullCheckingMonoBehaviour
	{
		public bool IsVREnabled => Inventory.IsVREnabled();

		public abstract DV.InventorySystem.Inventory Inventory { get; }

		public abstract bool IsEssentialItemsGetterAllowed { get; }

		public abstract bool IsGameInitialized { get; }

		public abstract bool IsInventoryOpenKeyDown { get; }

		public abstract bool IsInventoryCloseKeyDown { get; }

		public event Action IsEssentialItemsGetterAllowedChanged;

		protected void IsEssentialItemsGetterAllowedChanged_Fire()
		{
			this.IsEssentialItemsGetterAllowedChanged?.Invoke();
		}

		public abstract bool IsBeltSnappable(IInventoryItemSpec spec);

		public void RequestEquipItem(int equipSlot, int inventorySlot, IInventoryItemSpec itemSpec)
		{
			Inventory.EquipItem(itemSpec.GetGameObject(), inventorySlot, equipSlot);
		}

		public void RequestUnequipItem(bool addToInventory, int equippedSlot)
		{
			Inventory.UnequipItem(addToInventory, equippedSlot);
		}
	}
}
