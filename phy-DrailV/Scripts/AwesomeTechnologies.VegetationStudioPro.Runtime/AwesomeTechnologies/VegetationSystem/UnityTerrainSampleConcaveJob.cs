using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile(CompileSynchronously = true)]
	public struct UnityTerrainSampleConcaveJob : IJobParallelForDefer
	{
		public NativeArray<byte> Excluded;

		public NativeArray<float3> Position;

		[ReadOnly]
		public NativeArray<float> InputHeights;

		public float Distance;

		public float MinHeightDifference;

		public bool Inverse;

		public bool Average;

		public int HeightmapWidth;

		public int HeightmapHeight;

		public Vector3 HeightMapScale;

		public Vector3 Size;

		public Vector3 TerrainPosition;

		public void Execute(int index)
		{
			if (Excluded[index] != 1)
			{
				Vector3 vector = (Vector3)Position[index] - TerrainPosition;
				float2 obj = new float2(vector.x / HeightMapScale.x, vector.z / HeightMapScale.z);
				int num = Mathf.RoundToInt(obj.x);
				int num2 = Mathf.RoundToInt(obj.y);
				int num3 = Mathf.RoundToInt(Distance / HeightMapScale.x);
				float height = GetHeight(num, num2);
				float height2 = GetHeight(num - num3, num2 - num3);
				float height3 = GetHeight(num, num2 - num3);
				float height4 = GetHeight(num + num3, num2 - num3);
				float height5 = GetHeight(num - num3, num2);
				float height6 = GetHeight(num + num3, num2);
				float height7 = GetHeight(num - num3, num2 + num3);
				float height8 = GetHeight(num, num2 + num3);
				float height9 = GetHeight(num + num3, num2 + num3);
				float num4 = ((!Average) ? GetMinimumHeight(height2, height3, height4, height5, height6, height7, height8, height9) : ((height2 + height3 + height4 + height5 + height6 + height7 + height8 + height9) / 8f));
				bool flag = num4 < height + MinHeightDifference;
				if (Inverse)
				{
					flag = !flag;
				}
				if (flag)
				{
					Excluded[index] = 1;
				}
			}
		}

		private float GetMinimumHeight(float height1, float height2, float height3, float height4, float height5, float height6, float height7, float height8)
		{
			return math.min(math.min(math.min(math.min(math.min(math.min(math.min(height1, height2), height3), height4), height5), height6), height7), height8);
		}

		private float GetHeight(int x, int y)
		{
			x = math.clamp(x, 0, HeightmapWidth - 1);
			y = math.clamp(y, 0, HeightmapHeight - 1);
			return InputHeights[y * HeightmapWidth + x] * HeightMapScale.y;
		}
	}
}
