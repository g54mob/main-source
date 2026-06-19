using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

[InternalBufferCapacity(4)]
public struct PlayerChainTargetsBuffer : IBufferElementData
{
	[GhostField]
	public float3 targetPosition;
}
