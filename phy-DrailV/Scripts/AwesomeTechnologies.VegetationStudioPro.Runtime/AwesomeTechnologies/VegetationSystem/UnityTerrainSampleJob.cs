using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile(CompileSynchronously = true)]
	public struct UnityTerrainSampleJob : IJobParallelFor
	{
		[ReadOnly]
		public NativeArray<float> InputHeights;

		[ReadOnly]
		public NativeArray<VegetationSpawnLocationInstance> SpawnLocationList;

		public NativeArray<float3> Position;

		public NativeArray<quaternion> Rotation;

		public NativeArray<float3> Scales;

		public NativeArray<float3> TerrainNormal;

		public NativeArray<float> BiomeDistance;

		public NativeArray<byte> TerrainTextureData;

		public NativeArray<int> RandomNumberIndex;

		public NativeArray<float> DistanceFalloff;

		public NativeArray<float> VegetationMaskDensity;

		public NativeArray<float> VegetationMaskScale;

		public NativeArray<byte> TerrainSourceIDs;

		public NativeArray<byte> TextureMaskData;

		public NativeArray<byte> Excluded;

		public NativeArray<byte> HeightmapSampled;

		public int HeightmapWidth;

		public int HeightmapHeight;

		public Vector3 Scale;

		public Vector3 Size;

		public Vector3 HeightMapScale;

		public Vector3 TerrainPosition;

		public byte TerrainSourceID;

		public void Execute(int index)
		{
			if (HeightmapSampled[index] == 1)
			{
				return;
			}
			VegetationSpawnLocationInstance vegetationSpawnLocationInstance = SpawnLocationList[index];
			if (vegetationSpawnLocationInstance.SpawnChance < 0f)
			{
				Excluded[index] = 1;
				HeightmapSampled[index] = 1;
				return;
			}
			Vector3 vector = (Vector3)vegetationSpawnLocationInstance.Position - TerrainPosition;
			float2 float5 = new float2(vector.x / Size.x, vector.z / Size.z);
			if (float5.x < 0f || float5.x > 1f || float5.y < 0f || float5.y > 1f)
			{
				Excluded[index] = 1;
				return;
			}
			float triangleInterpolatedHeight = GetTriangleInterpolatedHeight(float5.x, float5.y);
			Position[index] = new float3(vegetationSpawnLocationInstance.Position.x, triangleInterpolatedHeight + TerrainPosition.y, vegetationSpawnLocationInstance.Position.z);
			TerrainNormal[index] = GetInterpolatedNormal(float5.x, float5.y);
			Scales[index] = new float3(1f, 1f, 1f);
			Rotation[index] = Quaternion.Euler(0f, 0f, 0f);
			RandomNumberIndex[index] = vegetationSpawnLocationInstance.RandomNumberIndex;
			BiomeDistance[index] = vegetationSpawnLocationInstance.BiomeDistance;
			DistanceFalloff[index] = 1f;
			TerrainSourceIDs[index] = TerrainSourceID;
			Excluded[index] = 0;
			HeightmapSampled[index] = 1;
			TerrainTextureData[index] = 0;
			VegetationMaskDensity[index] = 0f;
			VegetationMaskScale[index] = 0f;
			TextureMaskData[index] = 0;
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
