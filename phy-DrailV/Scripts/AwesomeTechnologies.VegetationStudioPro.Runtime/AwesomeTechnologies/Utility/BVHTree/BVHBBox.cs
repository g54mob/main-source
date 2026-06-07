using System;
using AwesomeTechnologies.MeshTerrains;
using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies.Utility.BVHTree
{
	[Serializable]
	public class BVHBBox
	{
		public Vector3 Center = Vector3.zero;

		public Vector3 Min = Vector3.one * float.MaxValue;

		public Vector3 Max = Vector3.one * float.MinValue;

		public static bool IntersectRay(BVHRay r, float3 min, float3 max, out float hitDist)
		{
			float num = 1f / r.Direction.x;
			float num2 = 1f / r.Direction.y;
			float num3 = 1f / r.Direction.z;
			float x = r.Origin.x;
			float y = r.Origin.y;
			float z = r.Origin.z;
			float x2;
			float x3;
			if (num >= 0f)
			{
				x2 = (min.x - x) * num;
				x3 = (max.x - x) * num;
			}
			else
			{
				x2 = (max.x - x) * num;
				x3 = (min.x - x) * num;
			}
			float x4;
			float x5;
			if (num2 >= 0f)
			{
				x4 = (min.y - y) * num2;
				x5 = (max.y - y) * num2;
			}
			else
			{
				x4 = (max.y - y) * num2;
				x5 = (min.y - y) * num2;
			}
			float y2;
			float y3;
			if (num3 >= 0f)
			{
				y2 = (min.z - z) * num3;
				y3 = (max.z - z) * num3;
			}
			else
			{
				y2 = (max.z - z) * num3;
				y3 = (min.z - z) * num3;
			}
			float num4 = math.max(x2, math.max(x4, y2));
			float num5 = math.min(x3, math.min(x5, y3));
			hitDist = num4;
			return num4 <= num5;
		}
	}
}
