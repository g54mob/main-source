using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace Presentation.FactoryFloor.Culling.Jobs
{
	[BurstCompile]
	public struct QualityLevelCullingBurstJob : IJobParallelFor
	{
		[ReadOnly]
		public NativeSlice<CullableJobItem> Input;

		[ReadOnly]
		public CullingGraphicsQualityLevel CurrentQualityLevel;

		[NativeDisableParallelForRestriction]
		public NativeSlice<CullableObjectState> Output;

		public void Execute(int index)
		{
			if (Input[index].IsValid && CurrentQualityLevel != CullingGraphicsQualityLevel.CullingDisabled && Output[index] != CullableObjectState.Culled)
			{
				CullableJobItem cullableJobItem = Input[index];
				if (cullableJobItem.Settings.CullWithQualityLevel && CurrentQualityLevel >= cullableJobItem.Settings.CullAtQualityThreshold)
				{
					Output[index] = CullableObjectState.Culled;
					return;
				}
				bool flag = cullableJobItem.Settings.LODWithQualityLevel && CurrentQualityLevel >= cullableJobItem.Settings.LODAtQualityThreshold;
				Output[index] = (flag ? CullableObjectState.LOD : CullableObjectState.Normal);
			}
		}
	}
}
