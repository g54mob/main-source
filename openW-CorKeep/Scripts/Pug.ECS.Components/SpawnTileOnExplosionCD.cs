using PugTilemap;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

public struct SpawnTileOnExplosionCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public TickTimer spawnTimer;

	[GhostField]
	public Random random;

	public TileType tileType;

	public Tileset tileset;

	public bool spawnRequiresWalkable;
}
