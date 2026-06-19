using PugTilemap;
using Unity.Entities;

public struct RemoveTileOnDeathCD : IComponentData, IQueryTypeParameter
{
	public TileType tileType;

	public Tileset tileset;

	public float removeChance;
}
