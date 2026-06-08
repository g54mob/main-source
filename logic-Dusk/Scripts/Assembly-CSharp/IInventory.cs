using System.Collections.Generic;

public interface IInventory
{
	int InventoryCount { get; }

	int MaxInventorySpace { get; }

	List<IInventoryItem> ItemsCopy { get; }

	int Scrap { get; set; }

	int TotalPropulsionFuel { get; }

	int PropulsionFuelCharge { get; }

	int PropulsionFuelReserve { get; set; }

	int JumpFuel { get; set; }

	bool CanHaveScrap { get; }

	string guiStatus { get; }

	string guiScrap { get; }

	void RemoveInventoryItem(IInventoryItem item);
}
