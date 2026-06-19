using Unity.Entities;
using Unity.Mathematics;

[InternalBufferCapacity(1)]
public struct CompanionEntityBuffer : IBufferElementData
{
	public Entity Value;

	public float3 SpawnOffset;
}
