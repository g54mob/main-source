using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;

public struct StateRequestData
{
	public NetworkTick _serverTick;

	public double _elapsedTime;

	public float _deltaTime;

	public Random _rng;

	public BlobAssetReference<PugDatabase.PugDatabaseBank> database;

	public TileAccessor tileLookup;

	[ReadOnly]
	public CollisionWorld collisionWorld;

	[ReadOnly]
	public WorldInfoCD worldInfo;

	public NativeList<Entity> playerEntities;

	public NativeList<Entity> playerExtrapolatedEntities;

	public NativeList<Entity> spawnLocationEntities;

	public uint tickRate;
}
