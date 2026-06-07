using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile(CompileSynchronously = true)]
	public struct InstanceHeightRuleJob : IJobParallelForDefer
	{
		public NativeArray<byte> Excluded;

		public NativeArray<float3> Position;

		public NativeArray<int> RandomNumberIndex;

		public float MinHeight;

		public float MaxHeight;

		[ReadOnly]
		public NativeArray<float> HeightRuleCurveArray;

		[ReadOnly]
		public NativeArray<float> RandomNumbers;

		public bool Advanced;

		public float MaxCurveHeight;

		public void Execute(int index)
		{
			if (Excluded[index] == 1)
			{
				return;
			}
			if (Advanced)
			{
				float value = (Position[index].y - MinHeight) / MaxCurveHeight;
				float value2 = SampleCurveArray(value);
				if (RandomCutoff(value2, RandomNumberIndex[index]))
				{
					Excluded[index] = 1;
				}
				RandomNumberIndex[index]++;
			}
			else if (Position[index].y < MinHeight || Position[index].y > MaxHeight)
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
			if (HeightRuleCurveArray.Length == 0)
			{
				return 0f;
			}
			int value2 = Mathf.RoundToInt(value * (float)HeightRuleCurveArray.Length);
			value2 = Mathf.Clamp(value2, 0, HeightRuleCurveArray.Length - 1);
			return HeightRuleCurveArray[value2];
		}
	}
}
