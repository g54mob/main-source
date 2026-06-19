using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

namespace Inventory
{
	public struct InventoryChangeData
	{
		public InventoryAction inventoryAction;

		public Entity inventory1;

		public Entity entityOrInventory2;

		public Entity entityOrInventory3;

		public int index1;

		public int index2;

		public int index3;

		public int index4;

		public ObjectID objectID;

		public int amount;

		public int variation;

		public float3 position1;

		public float3 position2;

		public bool bool1;

		public bool bool2;

		public FixedString64Bytes string1;
	}
}
