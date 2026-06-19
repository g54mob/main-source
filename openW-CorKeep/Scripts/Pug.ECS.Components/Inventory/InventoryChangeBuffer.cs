using Unity.Entities;

namespace Inventory
{
	public struct InventoryChangeBuffer : IBufferElementData
	{
		public Entity playerEntity;

		public InventoryChangeData inventoryChangeData;
	}
}
