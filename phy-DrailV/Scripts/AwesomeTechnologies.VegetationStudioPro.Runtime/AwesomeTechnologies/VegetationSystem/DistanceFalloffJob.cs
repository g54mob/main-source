using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile(CompileSynchronously = true)]
	public struct DistanceFalloffJob : IJobParallelForDefer
	{
		public NativeArray<int> RandomNumberIndex;

		public NativeArray<float> DistanceFalloff;

		public NativeArray<byte> Excluded;

		[ReadOnly]
		public NativeArray<float> RandomNumbers;

		[ReadOnly]
		public float DistanceFalloffStartDistance;

		public void Execute(int index)
		{
			if (Excluded[index] != 1)
			{
				DistanceFalloff[index] = math.clamp(DistanceFalloffStartDistance + RandomRange(RandomNumberIndex[index], 0f, 1f - DistanceFalloffStartDistance), 0f, 1f);
				RandomNumberIndex[index]++;
			}
		}

		public float RandomRange(int randomNumberIndex, float min, float max)
		{
			while (randomNumberIndex > 9999)
			{
				randomNumberIndex -= 10000;
			}
			return Mathf.Lerp(min, max, RandomNumbers[randomNumberIndex]);
		}
	}
}
