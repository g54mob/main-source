using PugTilemap;
using Unity.Entities;
using Unity.Mathematics;

public struct TileCreatedFromEntityCD : ICleanupComponentData, IComponentData, IQueryTypeParameter
{
	public TileType tileType;

	public int tileset;

	public int2 pos;
}
