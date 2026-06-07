using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies
{
	[BurstCompile(CompileSynchronously = true)]
	public struct ProcessIncludeVegetationMaskJob : IJobParallelForDefer
	{
		public NativeArray<byte> Excluded;

		public NativeArray<float> VegetationMaskDensity;

		public NativeArray<float> VegetationMaskScale;

		public NativeArray<float3> Scale;

		public NativeArray<int> RandomNumberIndex;

		[ReadOnly]
		public NativeArray<float> RandomNumbers;

		public void Execute(int index)
		{
			if (Excluded[index] != 1)
			{
				if (RandomCutoff(VegetationMaskDensity[index], RandomNumberIndex[index]))
				{
					Excluded[index] = 1;
				}
				else
				{
					Scale[index] *= VegetationMaskScale[index];
				}
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

		private bool RandomCutoff(float value, int randomNumberIndex)
		{
			float num = RandomRange(randomNumberIndex, 0f, 1f);
			return !(value > num);
		}
	}
}
