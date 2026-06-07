using AwesomeTechnologies.VegetationSystem;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies.Vegetation.Masks
{
	[BurstCompile]
	public struct SampleRgbaChannelExcludeMaskJob : IJobParallelForDefer
	{
		public NativeArray<float3> Position;

		public NativeArray<byte> Excluded;

		[ReadOnly]
		public NativeArray<RGBABytes> RgbaNativeArray;

		public bool Inverse;

		public int SelectedChannel;

		public int Width;

		public int Height;

		public Rect TextureRect;

		public float MinValue;

		public float MaxValue;

		public float2 Repeat;

		public void Execute(int index)
		{
			if (Excluded[index] == 1)
			{
				return;
			}
			float2 float5 = new float2(TextureRect.width / (float)Width, TextureRect.height / (float)Height);
			float3 float6 = new float3(TextureRect.center.x - TextureRect.width / 2f, 0f, TextureRect.center.y - TextureRect.height / 2f);
			int num = Mathf.RoundToInt(MinValue * 256f);
			int num2 = Mathf.RoundToInt(MaxValue * 256f);
			float3 float7 = Position[index] - float6;
			float7 = new float3(float7.x / float5.x, 0f, float7.z / float5.y);
			float3 float8 = new float3(float7.x / (float)Width, 0f, float7.z / (float)Height);
			float8 = new float3(float8.x * Repeat.x, 0f, float8.z * Repeat.y);
			float8 = math.frac(float8);
			int num3 = Mathf.RoundToInt(float8.x * (float)Width);
			int num4 = Mathf.RoundToInt(float8.z * (float)Height);
			if (num3 >= 0 && num3 <= Width - 1 && num4 >= 0 && num4 <= Height - 1)
			{
				int num5 = 0;
				switch (SelectedChannel)
				{
				case 0:
					num5 = RgbaNativeArray[num3 + num4 * Width].R;
					break;
				case 1:
					num5 = RgbaNativeArray[num3 + num4 * Width].G;
					break;
				case 2:
					num5 = RgbaNativeArray[num3 + num4 * Width].B;
					break;
				case 3:
					num5 = RgbaNativeArray[num3 + num4 * Width].A;
					break;
				}
				if (Inverse)
				{
					num5 = 256 - num5;
				}
				if (num5 >= num && num5 <= num2)
				{
					Excluded[index] = 1;
				}
			}
		}
	}
}
