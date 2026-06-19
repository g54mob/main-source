using PugTilemap;
using Unity.Entities;
using Unity.Mathematics;

public struct CrackableTileCleanupCD : ICleanupComponentData, IComponentData, IQueryTypeParameter
{
	public int2 tilePos;

	public TileType tileType;
}
