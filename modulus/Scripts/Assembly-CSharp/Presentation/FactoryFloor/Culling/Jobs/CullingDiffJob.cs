using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace Presentation.FactoryFloor.Culling.Jobs
{
	[BurstCompile]
	public struct CullingDiffJob : IJobParallelFor
	{
		[ReadOnly]
		public NativeSlice<CullableJobItem> Input;

		[ReadOnly]
		public NativeSlice<CullableObjectState> NewState;

		[NativeDisableParallelForRestriction]
		public NativeSlice<CullableObjectState> PrevState;

		public NativeQueue<int>.ParallelWriter Output;

		public void Execute(int index)
		{
			if (Input[index].IsValid && PrevState[index] != NewState[index])
			{
				PrevState[index] = NewState[index];
				Output.Enqueue(index);
			}
		}
	}
}
