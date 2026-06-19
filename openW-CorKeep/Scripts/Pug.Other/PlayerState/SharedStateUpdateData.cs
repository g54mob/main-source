using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;

namespace PlayerState
{
	public struct SharedStateUpdateData
	{
		public NetworkTick currentTick;

		[ReadOnly]
		public PhysicsWorld physicsWorld;

		[ReadOnly]
		public PhysicsWorldHistorySingleton physicsWorldHistory;

		public PugDatabase.DatabaseBankCD pugDatabaseBank;

		public EntityCommandBuffer ecb;

		public ConditionsTableCD conditionsTableCD;

		public float3 playerSpawnPosition;

		public float deltaTime;

		public uint tickRate;

		public bool isServer;

		public TileAccessor tileAccessor;

		public NativeList<Entity> octopusBosses;

		public FishingTableCD fishingTableCD;

		public LootTableBankCD lootTableBank;

		public bool isFirstTimeFullyPredictingTick;

		public Entity inventoryChangeBufferEntity;

		public Entity craftBufferEntity;

		public InventoryAuxDataSystemDataCD InventoryAuxDataSystemData;

		public bool isFinalFullPredictionTick;

		public bool isPartialTick;
	}
}
