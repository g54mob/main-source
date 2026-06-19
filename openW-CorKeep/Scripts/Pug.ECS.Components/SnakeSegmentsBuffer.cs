using Unity.Entities;
using Unity.NetCode;

[InternalBufferCapacity(16)]
[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct SnakeSegmentsBuffer : IBufferElementData
{
	[GhostField]
	public Entity segment;
}
