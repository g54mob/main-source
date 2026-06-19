using PugTilemap;
using Unity.Entities;

public struct PseudoTileCD : IComponentData, IQueryTypeParameter
{
	public int tileset;

	public TileType tileType;
}
