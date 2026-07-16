using System.Collections.Generic;
using UnityEngine;

namespace PathCreation.Utility
{
	public static class CubicBezierUtility
	{
		public static Vector3 EvaluateCurve(Vector3[] points, float t)
		{
			return EvaluateCurve(points[0], points[1], points[2], points[3], t);
		}

		public static Vector3 EvaluateCurve(Vector3 a1, Vector3 c1, Vector3 c2, Vector3 a2, float t)
		{
			t = Mathf.Clamp01(t);
			return (1f - t) * (1f - t) * (1f - t) * a1 + 3f * (1f - t) * (1f - t) * t * c1 + 3f * (1f - t) * t * t * c2 + t * t * t * a2;
		}

		public static Vector3 EvaluateCurveDerivative(Vector3[] points, float t)
		{
			return EvaluateCurveDerivative(points[0], points[1], points[2], points[3], t);
		}

		public static Vector3 EvaluateCurveDerivative(Vector3 a1, Vector3 c1, Vector3 c2, Vector3 a2, float t)
		{
			t = Mathf.Clamp01(t);
			return 3f * (1f - t) * (1f - t) * (c1 - a1) + 6f * (1f - t) * t * (c2 - c1) + 3f * t * t * (a2 - c2);
		}

		public static Vector3 EvaluateCurveSecondDerivative(Vector3[] points, float t)
		{
			return EvaluateCurveSecondDerivative(points[0], points[1], points[2], points[3], t);
		}

		public static Vector3 EvaluateCurveSecondDerivative(Vector3 a1, Vector3 c1, Vector3 c2, Vector3 a2, float t)
		{
			t = Mathf.Clamp01(t);
			return 6f * (1f - t) * (c2 - 2f * c1 + a1) + 6f * t * (a2 - 2f * c2 + c1);
		}

		public static Vector3 Normal(Vector3[] points, float t)
		{
			return Normal(points[0], points[1], points[2], points[3], t);
		}

		public static Vector3 Normal(Vector3 a1, Vector3 c1, Vector3 c2, Vector3 a2, float t)
		{
			Vector3 rhs = EvaluateCurveDerivative(a1, c1, c2, a2, t);
			return Vector3.Cross(Vector3.Cross(EvaluateCurveSecondDerivative(a1, c1, c2, a2, t), rhs), rhs).normalized;
		}

		public static Bounds CalculateSegmentBounds(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
		{
			MinMax3D minMax3D = new MinMax3D();
			minMax3D.AddValue(p0);
			minMax3D.AddValue(p3);
			foreach (float item in ExtremePointTimes(p0, p1, p2, p3))
			{
				minMax3D.AddValue(EvaluateCurve(p0, p1, p2, p3, item));
			}
			return new Bounds((minMax3D.Min + minMax3D.Max) / 2f, minMax3D.Max - minMax3D.Min);
		}

		public static Vector3[][] SplitCurve(Vector3[] points, float t)
		{
			Vector3 vector = Vector3.Lerp(points[0], points[1], t);
			Vector3 vector2 = Vector3.Lerp(points[1], points[2], t);
			Vector3 vector3 = Vector3.Lerp(points[2], points[3], t);
			Vector3 vector4 = Vector3.Lerp(vector, vector2, t);
			Vector3 vector5 = Vector3.Lerp(vector2, vector3, t);
			Vector3 vector6 = Vector3.Lerp(vector4, vector5, t);
			return new Vector3[2][]
			{
				new Vector3[4]
				{
					points[0],
					vector,
					vector4,
					vector6
				},
				new Vector3[4]
				{
					vector6,
					vector5,
					vector3,
					points[3]
				}
			};
		}

		public static float EstimateCurveLength(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
		{
			float num = (p0 - p1).magnitude + (p1 - p2).magnitude + (p2 - p3).magnitude;
			return (p0 - p3).magnitude + num / 2f;
		}

		public static List<float> ExtremePointTimes(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
		{
			Vector3 vector = 3f * (-p0 + 3f * p1 - 3f * p2 + p3);
			Vector3 vector2 = 6f * (p0 - 2f * p1 + p2);
			Vector3 vector3 = 3f * (p1 - p0);
			List<float> list = new List<float>();
			list.AddRange(StationaryPointTimes(vector.x, vector2.x, vector3.x));
			list.AddRange(StationaryPointTimes(vector.y, vector2.y, vector3.y));
			list.AddRange(StationaryPointTimes(vector.z, vector2.z, vector3.z));
			return list;
		}

		private static IEnumerable<float> StationaryPointTimes(float a, float b, float c)
		{
			List<float> list = new List<float>();
			if (a != 0f)
			{
				float num = b * b - 4f * a * c;
				if (num >= 0f)
				{
					float num2 = Mathf.Sqrt(num);
					float num3 = (0f - b + num2) / (2f * a);
					if (num3 >= 0f && num3 <= 1f)
					{
						list.Add(num3);
					}
					if (num != 0f)
					{
						float num4 = (0f - b - num2) / (2f * a);
						if (num4 >= 0f && num4 <= 1f)
						{
							list.Add(num4);
						}
					}
				}
			}
			return list;
		}
	}
}
