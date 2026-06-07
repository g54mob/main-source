using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile(CompileSynchronously = true)]
	public struct CalculateCellSpawnLocationsWideJob : IJobParallelFor
	{
		[WriteOnly]
		public NativeArray<VegetationSpawnLocationInstance> SpawnLocations;

		[ReadOnly]
		public NativeArray<float> RandomNumbers;

		public Vector3 CellCorner;

		public Vector3 CellSize;

		public Rect CellRect;

		public int CellIndex;

		public float SampleDistance;

		public float Density;

		public float DefaultSpawnChance;

		public int Seed;

		public bool UseSamplePointOffset;

		public float SamplePointMinOffset;

		public float SamplePointMaxOffset;

		public bool RandomizePosition;

		public float CalculatedSampleDistance;

		public int XSamples;

		public int ZSamples;

		public void Execute(int index)
		{
			int num = Mathf.FloorToInt((float)index / (float)XSamples);
			int num2 = index - num * XSamples;
			Vector3 vector = new Vector3(CellCorner.x + (float)num2 * CalculatedSampleDistance, CellCorner.y + 10f, CellCorner.z + (float)num * CalculatedSampleDistance);
			VegetationSpawnLocationInstance value = new VegetationSpawnLocationInstance
			{
				Position = vector,
				SpawnChance = DefaultSpawnChance,
				BiomeDistance = 1000000f
			};
			int num3;
			for (num3 = num2 + num * ZSamples + CellIndex + Seed; num3 > 9999; num3 -= 10000)
			{
			}
			value.RandomNumberIndex = num3;
			if (RandomizePosition)
			{
				float3 randomOffset = GetRandomOffset(CalculatedSampleDistance / 2f, value.RandomNumberIndex);
				value.RandomNumberIndex += 2;
				value.Position += randomOffset;
			}
			if (UseSamplePointOffset)
			{
				float x = RandomRange(value.RandomNumberIndex, SamplePointMinOffset, SamplePointMaxOffset);
				value.RandomNumberIndex++;
				float y = math.frac(SamplePointMinOffset) * 365f;
				float3 float5 = Quaternion.Euler(0f, y, 0f) * new Vector3(x, 0f, 0f);
				value.Position += float5;
			}
			if (!CellRect.Contains(new Vector2(value.Position.x, value.Position.z)))
			{
				value.SpawnChance = 0f;
			}
			SpawnLocations[index] = value;
		}

		private float3 GetRandomOffset(float distance, int randomNumberIndex)
		{
			return new float3(RandomRange(randomNumberIndex, 0f - distance, distance), 0f, RandomRange(randomNumberIndex + 1, 0f - distance, distance));
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
