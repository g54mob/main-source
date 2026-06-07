using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile(CompileSynchronously = true)]
	public struct FilterSpawnLocationsChanceJob : IJobParallelFor
	{
		public NativeArray<VegetationSpawnLocationInstance> SpawnLocationList;

		[ReadOnly]
		public NativeArray<float> RandomNumbers;

		public float Density;

		public float RandomRange(int randomNumberIndex, float min, float max)
		{
			while (randomNumberIndex > 9999)
			{
				randomNumberIndex -= 10000;
			}
			return Mathf.Lerp(min, max, RandomNumbers[randomNumberIndex]);
		}

		private bool RandomCutoff(float value, int randomNumberIndex)
		{
			float num = RandomRange(randomNumberIndex, 0f, 1f);
			return !(value > num);
		}

		public void Execute(int index)
		{
			VegetationSpawnLocationInstance value = SpawnLocationList[index];
			if (RandomCutoff(value.SpawnChance * Density, value.RandomNumberIndex))
			{
				value.RandomNumberIndex++;
				value.SpawnChance = -1f;
				SpawnLocationList[index] = value;
			}
			else
			{
				value.RandomNumberIndex++;
				SpawnLocationList[index] = value;
			}
		}
	}
}
