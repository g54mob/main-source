using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Obi
{
	[BurstCompile]
	internal struct ApplyInertialForcesJob : IJobParallelFor
	{
		[ReadOnly]
		public NativeArray<int> activeParticles;

		[ReadOnly]
		public NativeArray<float4> positions;

		[ReadOnly]
		public NativeArray<float> invMasses;

		[ReadOnly]
		public float4 angularVel;

		[ReadOnly]
		public float4 inertialAccel;

		[ReadOnly]
		public float4 eulerAccel;

		[ReadOnly]
		public float worldLinearInertiaScale;

		[ReadOnly]
		public float worldAngularInertiaScale;

		[NativeDisableParallelForRestriction]
		public NativeArray<float4> velocities;

		[ReadOnly]
		public float deltaTime;

		public void Execute(int index)
		{
			int index2 = activeParticles[index];
			if (invMasses[index2] > 0f)
			{
				float4 obj = new float4(math.cross(eulerAccel.xyz, positions[index2].xyz), 0f);
				float4 float5 = new float4(math.cross(angularVel.xyz, math.cross(angularVel.xyz, positions[index2].xyz)), 0f);
				float4 float6 = 2f * new float4(math.cross(angularVel.xyz, velocities[index2].xyz), 0f);
				float4 float7 = obj + float6 + float5;
				velocities[index2] -= (inertialAccel * worldLinearInertiaScale + float7 * worldAngularInertiaScale) * deltaTime;
			}
		}
	}
}
