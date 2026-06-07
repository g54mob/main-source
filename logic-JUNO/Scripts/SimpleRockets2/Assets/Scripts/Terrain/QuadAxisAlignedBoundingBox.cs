using System;
using UnityEngine;

namespace Assets.Scripts.Terrain
{
	[Serializable]
	public struct QuadAxisAlignedBoundingBox
	{
		public Vector3d Max;

		public Vector3d Min;

		public QuadAxisAlignedBoundingBox(Vector3d min, Vector3d max)
		{
			Min = min;
			Max = max;
		}

		public double GetSquaredDistanceToClosestPoint(Vector3d p)
		{
			double num = 0.0;
			if (p.x < Min.x)
			{
				double num2 = Min.x - p.x;
				num += num2 * num2;
			}
			if (p.x > Max.x)
			{
				double num2 = p.x - Max.x;
				num += num2 * num2;
			}
			if (p.y < Min.y)
			{
				double num2 = Min.y - p.y;
				num += num2 * num2;
			}
			if (p.y > Max.y)
			{
				double num2 = p.y - Max.y;
				num += num2 * num2;
			}
			if (p.z < Min.z)
			{
				double num2 = Min.z - p.z;
				num += num2 * num2;
			}
			if (p.z > Max.z)
			{
				double num2 = p.z - Max.z;
				num += num2 * num2;
			}
			return num;
		}
	}
}
