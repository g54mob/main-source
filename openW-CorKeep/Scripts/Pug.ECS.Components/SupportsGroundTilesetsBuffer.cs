using PugTilemap;
using Unity.Entities;

[InternalBufferCapacity(1)]
public struct SupportsGroundTilesetsBuffer : IBufferElementData
{
	public Tileset tileset;
}
