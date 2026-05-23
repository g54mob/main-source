using Data.FactoryFloor.Maps;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace Presentation.FactoryFloor.Culling.Jobs
{
	[BurstCompile]
	public struct IslandCullingBurstJob : IJobParallelFor
	{
		[ReadOnly]
		public NativeSlice<CullableJobItem> Input;

		[ReadOnly]
		public NativeArray<IslandCullState> IslandCullStates;

		[NativeDisableParallelForRestriction]
		public NativeSlice<CullableObjectState> Output;

		public void Execute(int index)
		{
			CullableJobItem cullableJobItem = Input[index];
			if (!cullableJobItem.IsValid)
			{
				return;
			}
			Output[index] = CullableObjectState.Normal;
			if (cullableJobItem.IslandID != -1)
			{
				IslandCullState islandCullState = IslandCullStates[cullableJobItem.IslandID];
				if (islandCullState == IslandCullState.Virtual || islandCullState == IslandCullState.PlayerNearby)
				{
					Output[index] = CullableObjectState.Culled;
				}
			}
		}
	}
}
