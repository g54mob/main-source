using AwesomeTechnologies.VegetationSystem;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies.Vegetation.Masks
{
	[BurstCompile]
	public struct SampleRgbaChannelDensityMaskJob : IJobParallelForDefer
	{
		public NativeArray<VegetationSpawnLocationInstance> SpawnLocations;

		[ReadOnly]
		public NativeArray<RGBABytes> RgbaNativeArray;

		public bool Inverse;

		public int SelectedChannel;

		public int Width;

		public int Height;

		public Rect TextureRect;

		public float DensityMultiplier;

		public float2 Repeat;

		public void Execute(int index)
		{
			VegetationSpawnLocationInstance value = SpawnLocations[index];
			float2 float5 = new float2(TextureRect.width / (float)Width, TextureRect.height / (float)Height);
			float3 float6 = new float3(TextureRect.center.x - TextureRect.width / 2f, 0f, TextureRect.center.y - TextureRect.height / 2f);
			float3 float7 = value.Position - float6;
			float7 = new float3(float7.x / float5.x, 0f, float7.z / float5.y);
			float3 float8 = new float3(float7.x / (float)Width, 0f, float7.z / (float)Height);
			float8 = new float3(float8.x * Repeat.x, 0f, float8.z * Repeat.y);
			float8 = math.frac(float8);
			int num = Mathf.RoundToInt(float8.x * (float)Width);
			int num2 = Mathf.RoundToInt(float8.z * (float)Height);
			if (num >= 0 && num <= Width - 1 && num2 >= 0 && num2 <= Height - 1)
			{
				int num3 = 0;
				switch (SelectedChannel)
				{
				case 0:
					num3 = RgbaNativeArray[num + num2 * Width].R;
					break;
				case 1:
					num3 = RgbaNativeArray[num + num2 * Width].G;
					break;
				case 2:
					num3 = RgbaNativeArray[num + num2 * Width].B;
					break;
				case 3:
					num3 = RgbaNativeArray[num + num2 * Width].A;
					break;
				}
				if (Inverse)
				{
					num3 = 256 - num3;
				}
				float num4 = (float)num3 / 256f * DensityMultiplier;
				value.SpawnChance *= num4;
				SpawnLocations[index] = value;
			}
		}
	}
}
