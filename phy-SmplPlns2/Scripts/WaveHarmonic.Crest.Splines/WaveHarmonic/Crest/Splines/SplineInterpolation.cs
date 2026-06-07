using System;
using System.Collections.Generic;
using UnityEngine;

namespace WaveHarmonic.Crest.Splines
{
	internal static class SplineInterpolation
	{
		public static void InterpolateLinearPosition(Vector3[] points, float t, out Vector3 position)
		{
			float num = t * ((float)points.Length - 1f);
			int num2 = Mathf.FloorToInt(num);
			float t2 = num - (float)num2;
			if (num2 == points.Length - 1)
			{
				num2--;
				t2 = 1f;
			}
			position = Vector3.Lerp(points[num2], points[num2 + 1], t2);
		}

		public static void InterpolateCubicPosition(float splinePointCount, Span<Vector3> splinePointsAndTangents, float t, out Vector3 position)
		{
			float num = t * (splinePointCount - 1f);
			int num2 = Mathf.FloorToInt(num);
			float num3 = num - (float)num2;
			if ((float)num2 == splinePointCount - 1f)
			{
				num2--;
				num3 = 1f;
			}
			int num4 = num2 * 3;
			position = (1f - num3) * (1f - num3) * (1f - num3) * splinePointsAndTangents[num4] + 3f * num3 * (1f - num3) * (1f - num3) * splinePointsAndTangents[num4 + 1] + 3f * num3 * num3 * (1f - num3) * splinePointsAndTangents[num4 + 2] + num3 * num3 * num3 * splinePointsAndTangents[num4 + 3];
		}

		public static bool GenerateCubicSplineHull(List<SplinePoint> splinePoints, Span<Vector3> splinePointsAndTangents, bool closed)
		{
			if (splinePoints.Count < 2)
			{
				return false;
			}
			for (int i = 0; i < splinePointsAndTangents.Length; i++)
			{
				int num = i / 3 % splinePoints.Count;
				int num2 = (num + 1) % splinePoints.Count;
				float num3 = 0.39f;
				if (i % 3 == 0)
				{
					splinePointsAndTangents[i] = splinePoints[num].transform.position;
					continue;
				}
				if (i % 3 == 1)
				{
					int num4 = num;
					Vector3 vector = TangentAfter(splinePoints, num4, closed).normalized * (splinePoints[num2].transform.position - splinePoints[num].transform.position).magnitude;
					splinePointsAndTangents[i] = splinePoints[num4].transform.position + num3 * vector;
					if (i == 1 && !closed)
					{
						vector = TangentBefore(splinePoints, num4 + 1, closed);
						Vector3 normalized = (splinePoints[num4 + 1].transform.position - splinePoints[num4].transform.position).normalized;
						Vector3 vector2 = Vector3.Dot(vector, normalized) * normalized;
						vector = (vector + 2f * (vector2 - vector)).normalized * (splinePoints[num2].transform.position - splinePoints[num].transform.position).magnitude;
						splinePointsAndTangents[i] = splinePoints[num4].transform.position + num3 * vector;
					}
					continue;
				}
				int num5 = num2;
				Vector3 vector3 = TangentBefore(splinePoints, num5, closed).normalized * (splinePoints[num2].transform.position - splinePoints[num].transform.position).magnitude;
				splinePointsAndTangents[i] = splinePoints[num5].transform.position - num3 * vector3;
				if (i == splinePointsAndTangents.Length - 2 && !closed)
				{
					int num6 = num5 - 1;
					if (num6 < 0 && closed)
					{
						num6 += splinePoints.Count;
					}
					vector3 = TangentAfter(splinePoints, num6, closed);
					Vector3 normalized2 = (splinePoints[num6].transform.position - splinePoints[num5].transform.position).normalized;
					Vector3 vector4 = Vector3.Dot(vector3, normalized2) * normalized2;
					vector3 = (vector3 + 2f * (vector4 - vector3)).normalized * (splinePoints[num2].transform.position - splinePoints[num].transform.position).magnitude;
					splinePointsAndTangents[i] = splinePoints[num5].transform.position - num3 * vector3;
				}
			}
			return true;
		}

		private static Vector3 TangentAfter(List<SplinePoint> splinePoints, int idx, bool closed)
		{
			Vector3 zero = Vector3.zero;
			float num = 0f;
			int num2 = idx - 1;
			if (num2 < 0 && closed)
			{
				num2 += splinePoints.Count;
			}
			int num3 = idx + 1;
			if (num3 >= splinePoints.Count && closed)
			{
				num3 -= splinePoints.Count;
			}
			if (num2 >= 0)
			{
				zero += splinePoints[idx].transform.position - splinePoints[num2].transform.position;
				num += 1f;
			}
			if (num3 < splinePoints.Count)
			{
				zero += splinePoints[num3].transform.position - splinePoints[idx].transform.position;
				num += 1f;
			}
			return zero / num;
		}

		private static Vector3 TangentBefore(List<SplinePoint> splinePoints, int idx, bool closed)
		{
			Vector3 zero = Vector3.zero;
			float num = 0f;
			int num2 = idx - 1;
			if (num2 < 0 && closed)
			{
				num2 += splinePoints.Count;
			}
			int num3 = idx + 1;
			if (num3 >= splinePoints.Count && closed)
			{
				num3 -= splinePoints.Count;
			}
			if (num2 >= 0)
			{
				zero += splinePoints[idx].transform.position - splinePoints[num2].transform.position;
				num += 1f;
			}
			if (num3 < splinePoints.Count)
			{
				zero += splinePoints[num3].transform.position - splinePoints[idx].transform.position;
				num += 1f;
			}
			return zero / num;
		}
	}
}
