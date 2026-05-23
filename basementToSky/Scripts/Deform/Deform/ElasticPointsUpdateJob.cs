using Beans.Unity.Mathematics;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Deform
{
	[BurstCompile(CompileSynchronously = true)]
	public struct ElasticPointsUpdateJob : IJobParallelFor
	{
		public float dampingRatio;

		public float angularFrequency;

		public float deltaTime;

		public NativeArray<float3> velocities;

		public NativeArray<float3> currentPoints;

		[ReadOnly]
		public NativeArray<float3> targetPoints;

		public void Execute(int index)
		{
			float3 value = currentPoints[index];
			float3 target = targetPoints[index];
			float3 velocity = velocities[index];
			mathx.spring(ref value, ref velocity, target, dampingRatio, angularFrequency, deltaTime);
			currentPoints[index] = value;
			velocities[index] = velocity;
		}
	}
}
