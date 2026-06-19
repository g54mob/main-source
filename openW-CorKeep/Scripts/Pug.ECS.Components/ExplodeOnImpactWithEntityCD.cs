using PugTilemap;
using Unity.Entities;

public struct ExplodeOnImpactWithEntityCD : IComponentData, IQueryTypeParameter
{
	public float distanceToExplode;

	public float explodeRadius;

	public int explodeDamage;

	public bool spawnTilesOnExplode;

	public TileType tileTypeToSpawn;

	public Tileset tilesetToSpawn;
}
