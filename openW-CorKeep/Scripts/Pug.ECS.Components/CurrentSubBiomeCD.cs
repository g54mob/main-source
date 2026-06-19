using PugTilemap;
using Unity.Entities;

public struct CurrentSubBiomeCD : IComponentData, IQueryTypeParameter
{
	public Tileset subBiome;
}
