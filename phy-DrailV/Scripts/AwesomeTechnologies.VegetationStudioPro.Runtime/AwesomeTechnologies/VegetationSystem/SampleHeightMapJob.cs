using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile(CompileSynchronously = true)]
	public struct SampleHeightMapJob : IJobParallelFor
	{
		public NativeArray<HeightMapSample> HeightMapSamples;

		[ReadOnly]
		public NativeArray<float> InputHeights;

		public int Width;

		public int Height;

		public int HeightmapWidth;

		public int HeightmapHeight;

		public Vector3 Scale;

		public Vector3 Size;

		public Vector3 HeightMapScale;

		public void Execute(int index)
		{
			int num = Mathf.FloorToInt((float)index / (float)Width);
			float x = (float)(index - num * Width) / (float)Width;
			float y = (float)num / (float)Height;
			float3 interpolatedNormal = GetInterpolatedNormal(x, y);
			HeightMapSample value = new HeightMapSample
			{
				Height = GetTriangleInterpolatedHeight(x, y)
			};
			float x2 = math.dot(interpolatedNormal, new float3(0f, 1f, 0f));
			value.Steepness = math.acos(x2) * 57.29578f;
			HeightMapSamples[index] = value;
		}

		private float GetTriangleInterpolatedHeight(float x, float y)
		{
			float num = x * (float)(HeightmapWidth - 1);
			float num2 = y * (float)(HeightmapHeight - 1);
			int num3 = (int)num;
			int num4 = (int)num2;
			float num5 = num - (float)num3;
			float num6 = num2 - (float)num4;
			if (num5 > num6)
			{
				float height = GetHeight(num3, num4);
				float height2 = GetHeight(num3 + 1, num4);
				float height3 = GetHeight(num3 + 1, num4 + 1);
				return height + (height2 - height) * num5 + (height3 - height2) * num6;
			}
			float height4 = GetHeight(num3, num4);
			float height5 = GetHeight(num3, num4 + 1);
			float height6 = GetHeight(num3 + 1, num4 + 1);
			return height4 + (height6 - height5) * num5 + (height5 - height4) * num6;
		}

		private float GetHeight(int x, int y)
		{
			x = math.clamp(x, 0, HeightmapWidth - 1);
			y = math.clamp(y, 0, HeightmapHeight - 1);
			return InputHeights[y * HeightmapWidth + x] * HeightMapScale.y;
		}

		public float3 GetInterpolatedNormal(float x, float y)
		{
			float num = x * (float)(HeightmapWidth - 1);
			float num2 = y * (float)(HeightmapHeight - 1);
			int num3 = (int)num;
			int num4 = (int)num2;
			float3 start = CalculateNormalSobel(num3, num4);
			float3 end = CalculateNormalSobel(num3 + 1, num4);
			float3 start2 = CalculateNormalSobel(num3, num4 + 1);
			float3 end2 = CalculateNormalSobel(num3 + 1, num4 + 1);
			float t = num - (float)num3;
			float t2 = num2 - (float)num4;
			float3 start3 = math.lerp(start, end, t);
			float3 end3 = math.lerp(start2, end2, t);
			return math.normalize(math.lerp(start3, end3, t2));
		}

		private float3 CalculateNormalSobel(int x, int y)
		{
			float num = GetHeight(x - 1, y - 1) * -1f;
			num += GetHeight(x - 1, y) * -2f;
			num += GetHeight(x - 1, y + 1) * -1f;
			num += GetHeight(x + 1, y - 1) * 1f;
			num += GetHeight(x + 1, y) * 2f;
			num += GetHeight(x + 1, y + 1) * 1f;
			num /= Scale.x;
			float num2 = GetHeight(x - 1, y - 1) * -1f;
			num2 += GetHeight(x, y - 1) * -2f;
			num2 += GetHeight(x + 1, y - 1) * -1f;
			num2 += GetHeight(x - 1, y + 1) * 1f;
			num2 += GetHeight(x, y + 1) * 2f;
			num2 += GetHeight(x + 1, y + 1) * 1f;
			num2 /= Scale.z;
			float3 x2 = default(float3);
			x2.x = 0f - num;
			x2.y = 8f;
			x2.z = 0f - num2;
			return math.normalize(x2);
		}
	}
}
