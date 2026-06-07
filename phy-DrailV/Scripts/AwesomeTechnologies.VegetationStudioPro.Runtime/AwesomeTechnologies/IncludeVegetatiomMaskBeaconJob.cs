using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies
{
	[BurstCompile(CompileSynchronously = true)]
	public struct IncludeVegetatiomMaskBeaconJob : IJobParallelForDefer
	{
		public NativeArray<byte> Excluded;

		public NativeArray<float3> Position;

		public NativeArray<float> VegetationMaskScale;

		public NativeArray<float> VegetationMaskDensity;

		[ReadOnly]
		public NativeArray<float> FalloutCurveArray;

		public float Denisty;

		public float Scale;

		public float Radius;

		public float3 MaskPosition;

		public void Execute(int index)
		{
			if (Excluded[index] != 1)
			{
				float num = math.distance(new Vector2(Position[index].x, Position[index].z), new float2(MaskPosition.x, MaskPosition.z));
				if (num < Radius)
				{
					float value = num / Radius;
					float num2 = SampleFalloutCurveArray(value);
					VegetationMaskScale[index] = math.max(VegetationMaskScale[index], Scale);
					VegetationMaskDensity[index] = math.max(VegetationMaskDensity[index], Denisty * num2);
				}
			}
		}

		private float SampleFalloutCurveArray(float value)
		{
			if (FalloutCurveArray.Length == 0)
			{
				return 0f;
			}
			int value2 = Mathf.RoundToInt(value * (float)FalloutCurveArray.Length);
			value2 = Mathf.Clamp(value2, 0, FalloutCurveArray.Length - 1);
			return FalloutCurveArray[value2];
		}
	}
}
