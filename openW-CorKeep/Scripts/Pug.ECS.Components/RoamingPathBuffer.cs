using Unity.Entities;
using Unity.Mathematics;

[InternalBufferCapacity(0)]
public struct RoamingPathBuffer : IBufferElementData
{
	public float3 Value;

	public RoamingPathBuffer(float3 value)
	{
		Value = value;
	}
}
