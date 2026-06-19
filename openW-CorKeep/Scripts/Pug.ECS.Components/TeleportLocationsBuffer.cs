using Unity.Entities;
using Unity.Mathematics;

[InternalBufferCapacity(0)]
public struct TeleportLocationsBuffer : IBufferElementData
{
	public float3 position;
}
