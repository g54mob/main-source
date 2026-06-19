using PugTilemap;
using Unity.Entities;
using Unity.Mathematics;

public struct WaterSourceCD : IComponentData, IQueryTypeParameter
{
	public Tileset waterTileset;

	public float3 splashPosition;
}
