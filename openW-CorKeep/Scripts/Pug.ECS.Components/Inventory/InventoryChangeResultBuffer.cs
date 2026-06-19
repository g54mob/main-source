using Unity.Entities;

namespace Inventory
{
	[InternalBufferCapacity(8)]
	public struct InventoryChangeResultBuffer : IBufferElementData
	{
		public bool inventoryChangeSuccessful;
	}
}
