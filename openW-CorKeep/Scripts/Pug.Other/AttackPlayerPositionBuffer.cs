using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

[InternalBufferCapacity(12)]
public struct AttackPlayerPositionBuffer : IBufferElementData
{
	public NetworkTick tick;

	public float tickFraction;

	public float3 position;

	public bool dead;
}
