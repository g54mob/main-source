using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine.Jobs;

[BurstCompile]
public struct TransformMovementJob : IJobParallelForTransform
{
	[ReadOnly]
	public NativeSlice<float3> StartPositions;

	[ReadOnly]
	public NativeSlice<float3> EndPositions;

	[ReadOnly]
	public NativeSlice<float> StartScales;

	[ReadOnly]
	public NativeSlice<float> EndScales;

	[ReadOnly]
	public NativeSlice<float> Progresses01;

	public NativeSlice<bool> AnimationPlaying;

	public void Execute(int index, TransformAccess transform)
	{
		if (AnimationPlaying[index])
		{
			transform.position = math.lerp(StartPositions[index], EndPositions[index], Progresses01[index]);
			float v = math.lerp(StartScales[index], EndScales[index], Progresses01[index]);
			transform.localScale = new float3(v);
			if (Progresses01[index] >= 1f)
			{
				AnimationPlaying[index] = false;
			}
		}
	}
}
