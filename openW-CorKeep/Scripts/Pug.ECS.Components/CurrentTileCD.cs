using PugTilemap;
using Unity.Entities;

public struct CurrentTileCD : IComponentData, IQueryTypeParameter
{
	public TileType TileType;

	public Tileset Tileset;
}
