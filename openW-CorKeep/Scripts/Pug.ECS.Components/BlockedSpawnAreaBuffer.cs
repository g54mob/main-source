using Unity.Entities;
using Unity.Mathematics;

[InternalBufferCapacity(0)]
public struct BlockedSpawnAreaBuffer : IBufferElementData
{
	public BlockedSpawnArea Value;

	public BlockedSpawnAreaBuffer(float2 center, float radius)
	{
		this = default(BlockedSpawnAreaBuffer);
		Value.Center = center;
		Value.Radius = radius;
		Value.ElapsedTicks = 0;
	}
}
