using System;
using AssembleSystem;

namespace UI.Inventory
{
	public interface IInventoryUIService
	{
		IMoveable MovingItem { get; }

		Action OnItemOfTheInventoryView { get; set; }

		Action<IInventoryManagable> OnItemAdded { get; set; }

		Action<IInventoryManagable> OnItemRemoved { get; set; }

		Action<bool> OnInventoryOpened { get; set; }

		bool InventoryOpened { get; }

		void AddItem(IInventoryManagable part);

		void RemoveItem(IInventoryManagable part);

		void SetMovingItem(IMoveable moveable);

		void OpenInventory();

		void CloseInventory();

		InventoryUIItemMover GetItemMover();
	}
}
