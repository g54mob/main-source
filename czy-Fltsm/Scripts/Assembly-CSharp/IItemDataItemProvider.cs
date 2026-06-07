using System.Collections.Generic;
using UnityEngine.Events;

public interface IItemDataItemProvider : IPathfindingNodeProvider
{
	TownQueryCache.Path Path { get; }

	event UnityAction<IItemDataItemProvider> Update;

	event UnityAction<IItemDataItemProvider> LateUpdate;

	bool ReserveItems(IEnumerable<CountedItemProperty> countedItems, List<Item> reservedItems);

	void PopulatePath(IPathfindingNodeProvider destination);

	bool ContainsUnreservedItem(ItemProperties itemProperties);

	int ReturnItemCount(ItemProperties itemProperties, bool includeReserved = false);

	int ReturnStoredAndIncomingItemCount(ItemProperties itemProperties, bool includeReserved = false);
}
