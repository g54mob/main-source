using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Presentation.FactoryFloor.Culling.Jobs
{
	[BurstCompile]
	public struct FrustumCullingBurstJob : IJobParallelFor
	{
		[ReadOnly]
		public NativeSlice<CullableJobItem> Input;

		[ReadOnly]
		public NativeArray<float4> FrustumPlanes;

		[ReadOnly]
		public float FrustumPlaneDistanceForShadowsOnly;

		[ReadOnly]
		public float FrustumPlaneDistanceForCulling;

		[NativeDisableParallelForRestriction]
		public NativeSlice<CullableObjectState> Output;

		public void Execute(int index)
		{
			if (!Input[index].IsValid || Output[index] == CullableObjectState.Culled)
			{
				return;
			}
			CullableJobItem cullableJobItem = Input[index];
			bool flag = false;
			bool flag2 = false;
			for (int i = 0; i < 6; i++)
			{
				float3 y = math.select(cullableJobItem.WorldPosition - cullableJobItem.Bounds / 2f, cullableJobItem.WorldPosition + cullableJobItem.Bounds / 2f, FrustumPlanes[i].xyz > 0f);
				if (math.dot(FrustumPlanes[i].xyz, y) + (FrustumPlanes[i].w + 10f * FrustumPlaneDistanceForCulling) < 0f)
				{
					flag = true;
					break;
				}
				if (math.dot(FrustumPlanes[i].xyz, y) + (FrustumPlanes[i].w + 10f * FrustumPlaneDistanceForShadowsOnly) < 0f)
				{
					flag2 = true;
					break;
				}
			}
			if (flag)
			{
				Output[index] = CullableObjectState.Culled;
			}
			else if (flag2)
			{
				Output[index] = CullableObjectState.ShadowsOnly;
			}
		}
	}
}
