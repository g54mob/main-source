using AwesomeTechnologies.Utility;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies
{
	[BurstCompile(CompileSynchronously = true)]
	public struct SampleVegetatiomMaskPolygonJob : IJobParallelForDefer
	{
		public NativeArray<float3> Position;

		public NativeArray<byte> Excluded;

		[ReadOnly]
		public NativeArray<Vector2> PolygonArray;

		[ReadOnly]
		public NativeArray<LineSegment2D> SegmentArray;

		public float AdditionalWidth;

		public float AdditionalWidthMax;

		public float NoiseScale;

		public void Execute(int index)
		{
			if (Excluded[index] != 1)
			{
				Vector2 vector = new Vector2(Position[index].x, Position[index].z);
				float num = noise.snoise(new float2(vector.x / NoiseScale, vector.y / NoiseScale));
				num += 1f;
				num /= 2f;
				num = math.clamp(num, 0f, 1f);
				float num2 = math.lerp(AdditionalWidth, AdditionalWidthMax, num);
				if (IsInPolygon(vector) || DistanceToEdge(vector) < num2)
				{
					Excluded[index] = 1;
				}
			}
		}

		private float DistanceToEdge(Vector2 point)
		{
			float num = float.MaxValue;
			for (int i = 0; i < SegmentArray.Length; i++)
			{
				num = math.min(num, SegmentArray[i].DistanceToPoint(point));
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
