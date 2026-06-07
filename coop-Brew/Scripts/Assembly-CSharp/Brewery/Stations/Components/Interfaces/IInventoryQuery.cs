using System.Collections.Generic;

namespace Brewery.Stations.Components.Interfaces
{
	public interface IInventoryQuery
	{
		int GetQuantity(string itemId);

		bool HasItem(string itemId, int quantity);

		IEnumerable<InventorySlotSnapshot> Enumerate();
	}
}
