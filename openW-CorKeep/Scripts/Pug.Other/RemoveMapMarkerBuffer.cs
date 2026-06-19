using Unity.Entities;
using Unity.Mathematics;

[InternalBufferCapacity(0)]
public struct RemoveMapMarkerBuffer : IBufferElementData
{
	public Entity entity;

	public float2 position;
}
