using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile(CompileSynchronously = true)]
	public struct BiomeEdgeDistanceScaleRuleJob : IJobParallelForDefer
	{
		public NativeArray<float3> Scale;

		public NativeArray<byte> Excluded;

		public NativeArray<float> BiomeDistance;

		public float MaxDistance;

		public float MinScale;

		public float MaxScale;

		public bool InverseScale;

		public void Execute(int index)
		{
			if (Excluded[index] != 1 && BiomeDistance[index] < MaxDistance)
			{
				float num = math.select(math.lerp(MinScale, MaxScale, BiomeDistance[index] / MaxDistance), math.lerp(MaxScale, MinScale, BiomeDistance[index] / MaxDistance), InverseScale);
				Scale[index] *= new float3(num, num, num);
			}
		}
	}
}
