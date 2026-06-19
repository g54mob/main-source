using Unity.Entities;
using Unity.NetCode;
using Unity.Physics;

namespace PlayerEquipment
{
	public struct AttackWithEquipmentShared
	{
		public NetworkTick currentTick;

		public uint tickRate;

		public PugDatabase.DatabaseBankCD databaseBank;

		public EntityCommandBuffer ecb;

		public bool isFirstTimeFullyPredictingTick;

		public ConditionsTableCD conditionsTableCD;

		public Entity inventoryChangeBufferEntity;

		public CollisionWorld collisionWorld;

		public TileAccessor tileAccessor;
	}
}
