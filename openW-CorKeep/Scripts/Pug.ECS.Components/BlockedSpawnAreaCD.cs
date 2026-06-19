using Unity.Entities;
using Unity.Mathematics;

public struct BlockedSpawnAreaCD : IComponentData, IQueryTypeParameter
{
	public BlockedSpawnArea Value;

	public BlockedSpawnAreaCD(float2 center, float radius)
	{
		this = default(BlockedSpawnAreaCD);
		Value.Center = center;
		Value.Radius = radius;
		Value.ElapsedTicks = 0;
	}
}
