using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile(CompileSynchronously = true)]
	public struct PerlinNoiseDensityJob : IJobParallelFor
	{
		public NativeArray<VegetationSpawnLocationInstance> SpawnLocationList;

		public float PerlinScale;

		public bool InversePerlinMask;

		public float2 Offset;

		public void Execute(int index)
		{
			VegetationSpawnLocationInstance value = SpawnLocationList[index];
			if (value.SpawnChance > float.Epsilon)
			{
				float num = noise.cnoise(new float2((value.Position.x + Offset.x) / PerlinScale, (value.Position.z + Offset.y) / PerlinScale));
				num += 1f;
				num /= 2f;
				num = math.clamp(num, 0f, 1f);
				num = math.select(num, 1f - num, InversePerlinMask);
				value.SpawnChance *= num;
				SpawnLocationList[index] = value;
			}
		}
	}
}
