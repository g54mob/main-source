using System.Collections.Generic;
using UnityEngine;

namespace NSMedieval
{
	public static class BezierPath
	{
		public static List<Vector3> CreateCurve(List<Vector3> controlPoints, int pointCount = 20)
		{
			List<Vector3> list = new List<Vector3>();
			int num = controlPoints.Count / 3;
			for (int i = 0; i < controlPoints.Count - 3; i += 3)
			{
				Vector3 p = controlPoints[i];
				Vector3 p2 = controlPoints[i + 1];
				Vector3 p3 = controlPoints[i + 2];
				Vector3 p4 = controlPoints[i + 3];
				if (i == 0)
				{
					list.Add(EvaluateCubic(p, p2, p3, p4, 0f));
				}
				for (int j = 0; j < pointCount / num; j++)
				{
					float t = 1f / ((float)pointCount / (float)num) * (float)j;
					list.Add(EvaluateCubic(p, p2, p3, p4, t));
				}
			}
			return list;
		}

		public static Vector3 EvaluateCubic(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
		{
			float num = t * t;
			float num2 = t * num;
			float num3 = 1f - t;
			float num4 = num3 * num3;
			return num3 * num4 * p0 + 3f * num4 * t * p1 + 3f * num3 * num * p2 + num2 * p3;
		}

		public static Vector3 EvaluateQuadratic(Vector3 p0, Vector3 p1, Vector3 p2, float t)
		{
			return Mathf.Pow(1f - t, 2f) * p0 + 2f * (1f - t) * t * p1 + t * t * p2;
		}
	}
}
