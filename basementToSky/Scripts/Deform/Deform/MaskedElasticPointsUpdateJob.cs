using Beans.Unity.Mathematics;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Deform
{
	[BurstCompile(CompileSynchronously = true)]
	public struct MaskedElasticPointsUpdateJob : IJobParallelFor
	{
		public float unmaskedDampingRatio;

		public float unmaskedAngularFrequency;

		public float maskedDampingRatio;

		public float maskedAngularFrequency;

		public float deltaTime;

		public int maskIndex;

		public NativeArray<float3> velocities;

		public NativeArray<float3> currentPoints;

		[ReadOnly]
		public NativeArray<float3> targetPoints;

		[ReadOnly]
		public NativeArray<float4> colors;

		public void Execute(int index)
		{
			float3 value = currentPoints[index];
			float3 target = targetPoints[index];
			float3 velocity = velocities[index];
			float t = colors[index][maskIndex];
			float dampingRatio = math.lerp(maskedDampingRatio, unmaskedDampingRatio, t);
			float angularFrequency = math.lerp(maskedAngularFrequency, unmaskedAngularFrequency, t);
			mathx.spring(ref value, ref velocity, target, dampingRatio, angularFrequency, deltaTime);
			currentPoints[index] = value;
			velocities[index] = velocity;
		}
	}
}
