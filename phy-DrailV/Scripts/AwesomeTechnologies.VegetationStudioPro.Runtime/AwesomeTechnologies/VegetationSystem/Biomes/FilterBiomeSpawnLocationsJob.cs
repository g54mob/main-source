using AwesomeTechnologies.Utility;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem.Biomes
{
	[BurstCompile(CompileSynchronously = true)]
	public struct FilterBiomeSpawnLocationsJob : IJobParallelFor
	{
		public NativeArray<VegetationSpawnLocationInstance> SpawnLocationList;

		[ReadOnly]
		public NativeArray<float> CurveArray;

		[ReadOnly]
		public NativeArray<float> InverseCurveArray;

		[ReadOnly]
		public NativeArray<Vector2> PolygonArray;

		[ReadOnly]
		public NativeArray<LineSegment2D> SegmentArray;

		public bool Include;

		public bool UseNoise;

		public float NoiseScale;

		public float BlendDistance;

		public Rect PolygonRect;

		public void Execute(int index)
		{
			VegetationSpawnLocationInstance value = SpawnLocationList[index];
			float spawnChance = value.SpawnChance;
			Vector2 vector = new Vector2(SpawnLocationList[index].Position.x, SpawnLocationList[index].Position.z);
			if (PolygonRect.Contains(vector) && IsInPolygon(vector))
			{
				value.SpawnChance = math.select(value.SpawnChance = math.min(0f, value.SpawnChance), value.SpawnChance = math.max(1f, value.SpawnChance), Include);
				float num = DistanceToEdge(vector);
				value.BiomeDistance = math.select(value.BiomeDistance, math.min(num, value.BiomeDistance), Include);
				if (num < BlendDistance)
				{
					float falseValue = math.select(1f, Mathf.PerlinNoise(vector.x / NoiseScale, vector.y / NoiseScale), UseNoise);
					falseValue = math.select(falseValue, 0f, !Include && !UseNoise);
					value.SpawnChance = math.select(math.max(SampleInverseCurveArray(num / BlendDistance) * (1f - falseValue), value.SpawnChance), math.min(SampleCurveArray(num / BlendDistance) * falseValue, value.SpawnChance), Include);
					value.SpawnChance = math.select(math.min(value.SpawnChance, spawnChance), math.max(value.SpawnChance, spawnChance), Include);
				}
				SpawnLocationList[index] = value;
			}
		}

		private float SampleCurveArray(float value)
		{
			if (CurveArray.Length == 0)
			{
				return 0f;
			}
			int value2 = Mathf.RoundToInt(value * (float)CurveArray.Length);
			value2 = Mathf.Clamp(value2, 0, CurveArray.Length - 1);
			return CurveArray[value2];
		}

		private float SampleInverseCurveArray(float value)
		{
			if (InverseCurveArray.Length == 0)
			{
				return 0f;
			}
			int value2 = Mathf.RoundToInt(value * (float)InverseCurveArray.Length);
			value2 = Mathf.Clamp(value2, 0, InverseCurveArray.Length - 1);
			return InverseCurveArray[value2];
		}

		private float DistanceToEdge(Vector2 point)
		{
			float num = float.MaxValue;
			for (int i = 0; i < SegmentArray.Length; i++)
			{
				if (SegmentArray[i].DisableEdge == 0)
				{
					num = math.min(num, SegmentArray[i].DistanceToPoint(point));
				}
			}
			return num;
		}

		private bool IsInPolygon(Vector2 p)
		{
			bool flag = false;
			if (PolygonArray.Length < 3)
			{
				return false;
			}
			Vector2 vector = new Vector2(PolygonArray[PolygonArray.Length - 1].x, PolygonArray[PolygonArray.Length - 1].y);
			for (int i = 0; i < PolygonArray.Length; i++)
			{
				Vector2 vector2 = new Vector2(PolygonArray[i].x, PolygonArray[i].y);
				Vector2 vector3;
				Vector2 vector4;
				if (vector2.x > vector.x)
				{
					vector3 = vector;
					vector4 = vector2;
				}
				else
				{
					vector3 = vector2;
					vector4 = vector;
				}
				if (vector2.x < p.x == p.x <= vector.x && (p.y - (float)(long)vector3.y) * (vector4.x - vector3.x) < (vector4.y - (float)(long)vector3.y) * (p.x - vector3.x))
				{
					flag = !flag;
				}
				vector = vector2;
			}
			return flag;
		}
	}
}
