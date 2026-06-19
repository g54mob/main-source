using Unity.Entities;
using Unity.Mathematics;

[InternalBufferCapacity(16)]
public struct LarvaTargetPointsBuffer : IBufferElementData
{
	public float3 targetPoint;
}
