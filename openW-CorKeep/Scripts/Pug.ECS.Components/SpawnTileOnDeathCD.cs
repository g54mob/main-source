using PugTilemap;
using Unity.Entities;

public struct SpawnTileOnDeathCD : IComponentData, IQueryTypeParameter
{
	public TileType tileType;

	public Tileset tileset;

	public float spawnChance;

	public bool clearOtherTiles;
}
