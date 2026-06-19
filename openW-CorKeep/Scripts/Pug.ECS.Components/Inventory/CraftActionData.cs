using Unity.Entities;

namespace Inventory
{
	public struct CraftActionData
	{
		public CraftAction craftAction;

		public ObjectID objectId;

		public int amount;

		public int additionalFreeAmount;

		public Entity playerEntity;

		public Entity craftingEntity;

		public Entity mainInventoryEntity;

		public Entity targetInventoryEntity;

		public int int0;

		public int int1;

		public bool bool0;

		public bool bool1;
	}
}
