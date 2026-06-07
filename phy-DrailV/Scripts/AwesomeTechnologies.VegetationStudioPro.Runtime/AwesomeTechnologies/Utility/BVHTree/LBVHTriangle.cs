using System;
using AwesomeTechnologies.MeshTerrains;
using Unity.Collections;
using Unity.Mathematics;

namespace AwesomeTechnologies.Utility.BVHTree
{
	[Serializable]
	public struct LBVHTriangle
	{
		public float3 V0;

		public float3 V1;

		public float3 V2;

		public float3 N;

		public int TerrainSourceID;

		public LBVHTriangle(float3 v0, float3 v1, float3 v2, float3 n, int terrainSourceID)
		{
			V0 = v0;
			V1 = v1;
			V2 = v2;
			N = n;
			TerrainSourceID = terrainSourceID;
		}

		public bool IntersectRay(BVHRay ray, out HitInfo hitInfo)
		{
			bool result = false;
			hitInfo.HitPoint = new float3(0f, 0f, 0f);
			hitInfo.HitNormal = new float3(0f, 1f, 0f);
			hitInfo.HitDistance = float.MaxValue;
			hitInfo.TerrainSourceID = (byte)TerrainSourceID;
			float3 origin = ray.Origin;
			float3 direction = ray.Direction;
			float3 float5 = V0 - origin;
			float3 float6 = V1 - origin;
			float3 float7 = V2 - origin;
			float3 x = math.normalize(math.cross(float5, float6));
			float3 x2 = math.normalize(math.cross(float6, float7));
			float3 x3 = math.normalize(math.cross(float7, float5));
			float num = math.dot(x, direction);
			float num2 = math.dot(x2, direction);
			float num3 = math.dot(x3, direction);
			if (num < 0f && num2 < 0f && num3 < 0f)
			{
				float3 y = origin - V0;
				float num4 = 0f - math.dot(N, y);
				float num5 = math.dot(N, direction);
				float num6 = num4 / num5;
				float3 hitPoint = origin + direction * num6;
				if (num4 < 0f)
				{
					hitInfo.HitPoint = hitPoint;
					hitInfo.HitDistance = num6;
					hitInfo.HitNormal = math.normalize(N);
					result = true;
				}
			}
			return result;
		}

		public bool IntersectRay(BVHRay ray, ref NativeArray<HitInfo> hitInfos, int hitInfoID)
		{
			float3 origin = ray.Origin;
			float3 direction = ray.Direction;
			float3 float5 = V0 - origin;
			float3 float6 = V1 - origin;
			float3 float7 = V2 - origin;
			float3 x = math.normalize(math.cross(float5, float6));
			float3 x2 = math.normalize(math.cross(float6, float7));
			float3 x3 = math.normalize(math.cross(float7, float5));
			float num = math.dot(x, direction);
			float num2 = math.dot(x2, direction);
			float num3 = math.dot(x3, direction);
			if (num < 0f && num2 < 0f && num3 < 0f)
			{
				float3 y = origin - V0;
				float num4 = 0f - math.dot(N, y);
				float num5 = math.dot(N, direction);
				float num6 = num4 / num5;
				float3 hitPoint = origin + direction * num6;
				if (num4 < 0f)
				{
					HitInfo value = new HitInfo
					{
						HitNormal = math.normalize(N),
						HitPoint = hitPoint,
						HitDistance = num6,
						TerrainSourceID = (byte)TerrainSourceID
					};
					hitInfos[hitInfoID] = value;
					return true;
				}
			}
			return false;
		}
	}
}
