using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies
{
	[BurstCompile(CompileSynchronously = true)]
	public struct IncludeVegetatiomMaskPolygonJob : IJobParallelForDefer
	{
		public NativeArray<byte> Excluded;

		public NativeArray<float3> Position;

		public NativeArray<float> VegetationMaskScale;

		public NativeArray<float> VegetationMaskDensity;

		[ReadOnly]
		public NativeArray<Vector2> PolygonArray;

		public float Denisty;

		public float Scale;

		public void Execute(int index)
		{
			if (Excluded[index] != 1)
			{
				Vector2 p = new Vector2(Position[index].x, Position[index].z);
				if (IsInPolygon(p))
				{
					VegetationMaskScale[index] = math.max(VegetationMaskScale[index], Scale);
					VegetationMaskDensity[index] = math.max(VegetationMaskDensity[index], Denisty);
				}
			}
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
