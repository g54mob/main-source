using Unity.Collections;
using Unity.Entities;
using Unity.NetCode;
using Unity.Physics;

namespace PlayerEquipment
{
	public struct EquipmentUpdateSharedData
	{
		public NetworkTick currentTick;

		public PugDatabase.DatabaseBankCD databaseBank;

		public WorldInfoCD worldInfoCD;

		public uint tickRate;

		[ReadOnly]
		public PhysicsWorld physicsWorld;

		[ReadOnly]
		public PhysicsWorldHistorySingleton physicsWorldHistory;

		public Entity inventoryUpdateBufferEntity;

		public Entity tileUpdateBufferEntity;

		public TileAccessor tileAccessor;

		public TileWithTilesetToObjectDataMapCD tileWithTilesetToObjectDataMapCD;

		public ColliderCacheCD colliderCacheCD;

		public bool isServer;

		public EntityCommandBuffer ecb;

		public bool isFirstTimeFullyPredictingTick;

		public EntityArchetype achievementArchetype;
	}
}
