using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

[BurstCompile]
public struct TransformAnimationDeltaJob : IJobParallelFor
{
	[ReadOnly]
	public float DeltaTime;

	[ReadOnly]
	public NativeArray<bool> AnimationPlaying;

	[ReadOnly]
	public NativeArray<float> TotalAnimationTime;

	public NativeArray<float> TimeAnimating;

	public NativeArray<float> Progresses01;

	public NativeArray<bool> AnimationsFinishedThisFrame;

	public void Execute(int index)
	{
		if (AnimationPlaying[index])
		{
			TimeAnimating[index] += DeltaTime;
			float num = math.clamp(TimeAnimating[index] / TotalAnimationTime[index], 0f, 1f);
			if (num >= 1f)
			{
				AnimationsFinishedThisFrame[index] = true;
			}
			Progresses01[index] = num;
		}
	}
}
