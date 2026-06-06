using System.Collections.Generic;
using UnityEngine.Events;

public interface IInventorySlot
{
	ItemProperties ItemProperties { get; }

	bool IsEmpty { get; }

	bool IsFull { get; }

	int Capacity { get; }

	int Count { get; }

	int UnreservedCount { get; }

	int ReservedCount { get; }

	event UnityAction<IInventorySlot> OnReservationUpdated;

	void Clear();

	bool AddItem(Item item);

	bool SimulateAddItem(Item item);

	bool CanAddItem(Item item);

	Item PeekItem();

	Item TakeItem(Item item);

	bool TryTakeItem(out Item item, bool allowReserved);

	bool TryReturnFirstAvailableItem(SubInventoryType subInventory, out Item item, IInventorySpaceLimiter limiter = null);

	bool ReserveItem(ItemProperties itemProperties, List<Item> reservedItems);

	bool ReturnHasUnreservedItem();

	void PopulateItemList(List<Item> itemList, bool includeReserved);

	void Trim();

	void StartSimulation();
}
