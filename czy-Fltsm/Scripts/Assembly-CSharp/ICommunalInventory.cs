using UnityEngine.Events;

public interface ICommunalInventory
{
	UnityEvent InventoryUpdatedEvent { get; }

	int ReturnCapacity(SubInventoryType subInventory = SubInventoryType.Storage);

	int ReturnCapacity(Item.Tags tag);

	int ReturnCount(SubInventoryType subInventory = SubInventoryType.Storage, bool includeReserved = false);

	int ReturnCount(Item.Tags tag, bool includeReserved = false);

	int ReturnIncomingItemsAmount(SubInventoryType subInventory);

	int ReturnIncomingItemsAmount(Item.Tags tags);
}
