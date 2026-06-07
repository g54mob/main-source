using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Obi
{
	[BurstCompile]
	internal struct RenderableOrientationFromNormals : IJobParallelFor
	{
		[ReadOnly]
		public NativeArray<int> phases;

		public NativeArray<float4> normals;

		public NativeArray<float4> tangents;

		[WriteOnly]
		public NativeArray<quaternion> renderableOrientations;

		public void Execute(int i)
		{
			if (math.lengthsq(normals[i]) > 1E-07f && math.lengthsq(tangents[i]) > 1E-07f && (phases[i] & 0x2000000) == 0)
			{
				normals[i] = math.normalizesafe(normals[i]);
				tangents[i] = math.normalizesafe(tangents[i]);
				renderableOrientations[i] = quaternion.LookRotation(normals[i].xyz, tangents[i].xyz);
			}
		}
	}
}
