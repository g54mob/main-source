using Unity.Entities;
using Unity.Mathematics;

public struct PrefabTileSizeOptionalCD : IComponentData, IQueryTypeParameter
{
	public int2 prefabTileSize;

	public int2 prefabCornerOffset;
}
