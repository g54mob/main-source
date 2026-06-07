using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Presentation.FactoryFloor.Culling.Jobs
{
	[BurstCompile]
	public struct DistanceCullingBurstJob : IJobParallelFor
	{
		[ReadOnly]
		public NativeSlice<CullableJobItem> Input;

		[ReadOnly]
		public float3 CameraPosition;

		[ReadOnly]
		public CullingGraphicsQualityLevel CurrentQualityLevel;

		[ReadOnly]
		public int MaxZoomAdjustment;

		[NativeDisableParallelForRestriction]
		public NativeSlice<CullableObjectState> Output;

		public void Execute(int index)
		{
			if (!Input[index].IsValid || CurrentQualityLevel == CullingGraphicsQualityLevel.CullingDisabled || Output[index] == CullableObjectState.Culled)
			{
				return;
			}
			CullableJobItem cullableJobItem = Input[index];
			bool flag = false;
			if (cullableJobItem.Settings.CullWithCameraDistance)
			{
				float num = math.lengthsq(CameraPosition - cullableJobItem.WorldPosition);
				float num2 = 0f;
				if (CurrentQualityLevel == CullingGraphicsQualityLevel.High)
				{
					num2 = cullableJobItem.Settings.CameraCullDistance_High + (float)MaxZoomAdjustment;
				}
				num2 = ((CurrentQualityLevel != CullingGraphicsQualityLevel.Medium) ? (cullableJobItem.Settings.CameraCullDistance_Low + (float)MaxZoomAdjustment) : (cullableJobItem.Settings.CameraCullDistance_Medium + (float)MaxZoomAdjustment));
				flag = flag || num > num2 * num2;
			}
			if (flag)
			{
				Output[index] = CullableObjectState.Culled;
				return;
			}
			bool flag2 = false;
			if (cullableJobItem.Settings.LODWithCameraDistance)
			{
				float num3 = math.lengthsq(CameraPosition - cullableJobItem.WorldPosition);
				float num4 = 0f;
				if (CurrentQualityLevel == CullingGraphicsQualityLevel.High)
				{
					num4 = cullableJobItem.Settings.CameraLODDistance_High + (float)MaxZoomAdjustment;
				}
				num4 = ((CurrentQualityLevel != CullingGraphicsQualityLevel.Medium) ? (cullableJobItem.Settings.CameraLODDistance_Low + (float)MaxZoomAdjustment) : (cullableJobItem.Settings.CameraLODDistance_Medium + (float)MaxZoomAdjustment));
				flag2 = flag2 || num3 > num4 * num4;
			}
			Output[index] = (flag2 ? CullableObjectState.LOD : CullableObjectState.Normal);
		}
	}
}
