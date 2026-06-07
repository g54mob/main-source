using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

[BurstCompile]
public struct CalculateAABBs : IJobParallelFor
{
	[NativeDisableParallelForRestriction]
	public NativeArray<AABB> AABBs;

	[ReadOnly]
	public NativeArray<InstanceBoundsData> InstanceBoundsData;

	public void Execute(int index)
	{
	}

	private bool TryUpdateBounds(int index, AABB expected, AABB desired)
	{
		return false;
	}
}
