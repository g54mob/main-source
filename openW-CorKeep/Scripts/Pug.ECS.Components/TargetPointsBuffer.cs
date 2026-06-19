using Unity.Entities;
using Unity.Mathematics;

[InternalBufferCapacity(16)]
public struct TargetPointsBuffer : IBufferElementData
{
	public float3 targetPoint;
}
