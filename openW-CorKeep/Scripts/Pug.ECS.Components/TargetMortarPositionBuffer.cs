using Unity.Entities;
using Unity.Mathematics;

[InternalBufferCapacity(0)]
public struct TargetMortarPositionBuffer : IBufferElementData
{
	public float3 position;
}
