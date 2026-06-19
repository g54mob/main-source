using System;
using System.Collections.Generic;
using AssembleSystem;

public interface IInventoryService
{
	List<IInventoryManagable> Items { get; }

	Action<IInventoryManagable> OnItemPicked { get; set; }

	Action<IInventoryManagable> OnItemDropped { get; set; }

	void AddItem(IInventoryManagable item);

	void RemoveItem(IInventoryManagable item);
}
