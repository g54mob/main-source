using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile(CompileSynchronously = true)]
	public struct InstanceSteepnessRuleJob : IJobParallelForDefer
	{
		public NativeArray<byte> Excluded;

		public NativeArray<float3> TerrainNormal;

		public NativeArray<int> RandomNumberIndex;

		[ReadOnly]
		public NativeArray<float> SteepnessRuleCurveArray;

		[ReadOnly]
		public NativeArray<float> RandomNumbers;

		public bool Advanced;

		public float MinSteepness;

		public float MaxSteepness;

		public void Execute(int index)
		{
			if (Excluded[index] == 1)
			{
				return;
			}
			float num = math.acos(math.dot(TerrainNormal[index], new float3(0f, 1f, 0f))) * 57.29578f;
			if (Advanced)
			{
				float value = num / 90f;
				float value2 = SampleCurveArray(value);
				if (RandomCutoff(value2, RandomNumberIndex[index]))
				{
					Excluded[index] = 1;
				}
				RandomNumberIndex[index]++;
			}
			else if (num < MinSteepness || num > MaxSteepness)
			{
				Excluded[index] = 1;
			}
		}

		private bool RandomCutoff(float value, int randomNumberIndex)
		{
			float num = RandomRange(randomNumberIndex, 0f, 1f);
			return !(value > num);
		}

		public float RandomRange(int randomNumberIndex, float min, float max)
		{
			while (randomNumberIndex > 9999)
			{
				randomNumberIndex -= 10000;
			}
			return Mathf.Lerp(min, max, RandomNumbers[randomNumberIndex]);
		}

		private float SampleCurveArray(float value)
		{
			if (SteepnessRuleCurveArray.Length == 0)
			{
				return 0f;
			}
			int value2 = Mathf.RoundToInt(value * (float)SteepnessRuleCurveArray.Length);
			value2 = Mathf.Clamp(value2, 0, SteepnessRuleCurveArray.Length - 1);
			return SteepnessRuleCurveArray[value2];
		}
	}
}
