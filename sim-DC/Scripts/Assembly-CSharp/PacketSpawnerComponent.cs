using Unity.Entities;
using Unity.Mathematics;

public struct PacketSpawnerComponent : IComponentData, IQueryTypeParameter
{
	public Entity packetPrefab;

	public float3 spawnPos;

	public float nextSpawnTime;

	public float spawnRate;

	public float moveSpeed;

	public float maxSpeed;

	public int connectedServersCount;

	public float avgServerProcessingSpeed;

	public BlobAssetReference<WaypointsBlob> waypoints;

	public bool waypointsInitialized;

	public bool isPaused;

	public int customerId;
}
