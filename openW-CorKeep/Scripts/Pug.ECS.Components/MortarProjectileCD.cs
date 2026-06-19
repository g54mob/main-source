using PugTilemap;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct MortarProjectileCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public MortarProjectileState internalState;

	[GhostField]
	public float3 targetPosition;

	[GhostField]
	public TickTimer timer;

	[GhostField]
	public float totalAirTime;

	public float radius;

	public bool spawnTilesOnGoingDown;

	public TileType tileTypeToSpawnOnGoingDown;

	public Tileset tilesetToSpawnOnGoingDown;

	public float spawnTilesOnGoingDownExtraRadius;

	public bool canSpawnTilesOnWaterOrPits;

	public bool randomizeEdgeForTilesToSpawn;

	public float goUpTime;

	[GhostField]
	public float airTime;

	public float goDownTime;

	public float explodeTime;
}
