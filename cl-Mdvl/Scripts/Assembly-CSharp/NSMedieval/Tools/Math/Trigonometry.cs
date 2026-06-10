using System;
using UnityEngine;

namespace NSMedieval.Tools.Math
{
	public static class Trigonometry
	{
		public static Vector3[] GetPointsAroundCircle(int pointCount, int radius, Vector3 center)
		{
			Vector3[] array = new Vector3[pointCount];
			int num = (int)center.x;
			int num2 = (int)center.z;
			for (int i = 0; i < pointCount; i++)
			{
				int num3 = (int)((float)num + (float)radius * Mathf.Cos(MathF.PI * 2f * (float)i / (float)pointCount));
				int num4 = (int)((float)num2 + (float)radius * Mathf.Sin(MathF.PI * 2f * (float)i / (float)pointCount));
				array[i] = new Vector3(num3, center.y, num4);
			}
			return array;
		}

		public static bool IsWithinTriangle(Vector3 p, Vector3 p1, Vector3 p2, Vector3 p3)
		{
			float num = (p2.z - p3.z) * (p1.x - p3.x) + (p3.x - p2.x) * (p1.z - p3.z);
			float num2 = ((p2.z - p3.z) * (p.x - p3.x) + (p3.x - p2.x) * (p.z - p3.z)) / num;
			float num3 = ((p3.z - p1.z) * (p.x - p3.x) + (p1.x - p3.x) * (p.z - p3.z)) / num;
			float num4 = 1f - num2 - num3;
			if (num2 >= 0f && num2 <= 1f && num3 >= 0f && num3 <= 1f && num4 >= 0f)
			{
				return num4 <= 1f;
			}
			return false;
		}
	}
}
