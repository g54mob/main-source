using Inventory;
using PlayerEquipment;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.NetCode;
using Unity.Physics;

public struct PlayerAttackShared
{
	public NetworkTick currentTick;

	public PugDatabase.DatabaseBankCD databaseBank;

	[ReadOnly]
	public ConditionsTableCD conditionsTableCD;

	public PhysicsWorldHistorySingleton physicsWorldHistory;

	[ReadOnly]
	public PhysicsWorld physicsWorld;

	[ReadOnly]
	public TileAccessor tileAccessor;

	[ReadOnly]
	public WorldInfoCD worldInfo;

	public Entity tileDamageBufferSingleton;

	public CollisionFilter critterFilter;

	public ColliderCacheCD colliderCache;

	[ReadOnly]
	public NativeList<Entity> playerEntities;

	public EntityCommandBuffer ecb;

	public bool isFirstTimeFullyPredictingTick;

	public bool isServer;

	public uint tickRate;

	public Entity healthChangeBufferEntity;

	public ServerSeedCD serverSeedCD;

	public Entity inventoryChangeBufferEntity;

	public SfxID chestOpenSfxID;

	public EntityArchetype achievementArchetype;

	public Entity tileUpdateBufferEntity;

	[NativeDisableUnsafePtrRestriction]
	private EntityQuery networkTimeQuery;

	[NativeDisableUnsafePtrRestriction]
	private EntityQuery physicsWorldHistoryQuery;

	[NativeDisableUnsafePtrRestriction]
	private EntityQuery physicsWorldQuery;

	[NativeDisableUnsafePtrRestriction]
	private EntityQuery worldInfoQuery;

	[NativeDisableUnsafePtrRestriction]
	private EntityQuery clientServerTickRateQuery;

	public PlayerAttackShared(ref SystemState state)
	{
		currentTick = default(NetworkTick);
		databaseBank = default(PugDatabase.DatabaseBankCD);
		conditionsTableCD = default(ConditionsTableCD);
		physicsWorldHistory = default(PhysicsWorldHistorySingleton);
		physicsWorld = default(PhysicsWorld);
		tileAccessor = default(TileAccessor);
		worldInfo = default(WorldInfoCD);
		tileDamageBufferSingleton = default(Entity);
		critterFilter = new CollisionFilter
		{
			BelongsTo = uint.MaxValue,
			CollidesWith = 32784u
		};
		colliderCache = default(ColliderCacheCD);
		playerEntities = default(NativeList<Entity>);
		ecb = default(EntityCommandBuffer);
		isFirstTimeFullyPredictingTick = false;
		isServer = state.WorldUnmanaged.IsServer();
		tickRate = 0u;
		healthChangeBufferEntity = default(Entity);
		serverSeedCD = default(ServerSeedCD);
		inventoryChangeBufferEntity = default(Entity);
		chestOpenSfxID = SfxID.chestopen;
		achievementArchetype = AchievementSystem.GetRpcArchetype(state.EntityManager);
		tileUpdateBufferEntity = default(Entity);
		networkTimeQuery = state.GetEntityQuery(ComponentType.ReadOnly<NetworkTime>());
		physicsWorldHistoryQuery = state.GetEntityQuery(ComponentType.ReadOnly<PhysicsWorldHistorySingleton>());
		physicsWorldQuery = state.GetEntityQuery(ComponentType.ReadOnly<PhysicsWorldSingleton>());
		worldInfoQuery = state.GetEntityQuery(ComponentType.ReadOnly<WorldInfoCD>());
		clientServerTickRateQuery = state.GetEntityQuery(ComponentType.ReadOnly<ClientServerTickRate>());
		state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
		state.RequireForUpdate<ConditionsTableCD>();
		state.RequireForUpdate<PhysicsWorldSingleton>();
		state.RequireForUpdate<WorldInfoCD>();
		state.RequireForUpdate<TileDamageBuffer>();
		state.RequireForUpdate<ColliderCacheCD>();
		state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
		state.RequireForUpdate<ClientServerTickRate>();
		state.RequireForUpdate<HealthChangeBuffer>();
		state.RequireForUpdate<ServerSeedCD>();
		state.RequireForUpdate<InventoryChangeBuffer>();
		state.RequireForUpdate<TileUpdateBuffer>();
	}

	public void Init(ref SystemState state)
	{
		tileAccessor = new TileAccessor(ref state);
		databaseBank = state.GetSingleton<PugDatabase.DatabaseBankCD>();
		conditionsTableCD = state.GetSingleton<ConditionsTableCD>();
		tileDamageBufferSingleton = state.GetSingletonEntity<TileDamageBuffer>();
		colliderCache = state.GetSingleton<ColliderCacheCD>();
		healthChangeBufferEntity = state.GetSingletonEntity<HealthChangeBuffer>();
		serverSeedCD = state.GetSingleton<ServerSeedCD>();
		inventoryChangeBufferEntity = state.GetSingletonEntity<InventoryChangeBuffer>();
		tileUpdateBufferEntity = state.GetSingletonEntity<TileUpdateBuffer>();
	}

	public void Update(ref SystemState state, EntityCommandBuffer ecb, NativeList<Entity> playerEntities)
	{
		tileAccessor.Update(ref state);
		NetworkTime singleton = networkTimeQuery.GetSingleton<NetworkTime>();
		currentTick = singleton.ServerTick;
		isFirstTimeFullyPredictingTick = singleton.IsFirstTimeFullyPredictingTick;
		physicsWorldHistory = physicsWorldHistoryQuery.GetSingleton<PhysicsWorldHistorySingleton>();
		physicsWorld = physicsWorldQuery.GetSingleton<PhysicsWorldSingleton>().PhysicsWorld;
		worldInfo = worldInfoQuery.GetSingleton<WorldInfoCD>();
		tickRate = (uint)clientServerTickRateQuery.GetSingleton<ClientServerTickRate>().SimulationTickRate;
		this.playerEntities = playerEntities;
		this.ecb = ecb;
	}
}
