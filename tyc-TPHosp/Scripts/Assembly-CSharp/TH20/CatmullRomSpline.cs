using UnityEngine;

namespace TH20
{
	public static class CatmullRomSpline
	{
		public static Vector2 EvaluateCatmullRomSpline(Vector2[] pts, float t)
		{
			int num = pts.Length - 3;
			int num2 = Mathf.Min(Mathf.FloorToInt(t * (float)num), num - 1);
			float num3 = t * (float)num - (float)num2;
			Vector2 vector = pts[num2];
			Vector2 vector2 = pts[num2 + 1];
			Vector2 vector3 = pts[num2 + 2];
			Vector2 vector4 = pts[num2 + 3];
			return 0.5f * ((-vector + 3f * vector2 - 3f * vector3 + vector4) * (num3 * num3 * num3) + (2f * vector - 5f * vector2 + 4f * vector3 - vector4) * (num3 * num3) + (-vector + vector3) * num3 + 2f * vector2);
		}

		public static Vector3 EvaluateCatmullRomSpline(Vector3[] pts, float t)
		{
			int num = pts.Length - 3;
			int num2 = Mathf.Min(Mathf.FloorToInt(t * (float)num), num - 1);
			float num3 = t * (float)num - (float)num2;
			Vector3 vector = pts[num2];
			Vector3 vector2 = pts[num2 + 1];
			Vector3 vector3 = pts[num2 + 2];
			Vector3 vector4 = pts[num2 + 3];
			return 0.5f * ((-vector + 3f * vector2 - 3f * vector3 + vector4) * (num3 * num3 * num3) + (2f * vector - 5f * vector2 + 4f * vector3 - vector4) * (num3 * num3) + (-vector + vector3) * num3 + 2f * vector2);
		}

		public static Vector3 EvaluateCatmullRomSplineDerivative(Vector3[] pts, float t)
		{
			int num = pts.Length - 3;
			int num2 = Mathf.Min(Mathf.FloorToInt(t * (float)num), num - 1);
			float num3 = t * (float)num - (float)num2;
			Vector3 vector = pts[num2];
			Vector3 vector2 = pts[num2 + 1];
			Vector3 vector3 = pts[num2 + 2];
			Vector3 vector4 = pts[num2 + 3];
			return 0.5f * ((-3f * vector + 9f * vector2 - 9f * vector3 + 3f * vector4) * (num3 * num3) + (4f * vector - 10f * vector2 + 8f * vector3 - 2f * vector4) * num3 + (-vector + vector3));
		}

		public static Vector3 EvaluateCatmullRomSplineNormal(Vector3[] pts, float t)
		{
			return MathUtils.NormalizeOrZeroIfUnsafe(EvaluateCatmullRomSplineDerivative(pts, t));
		}

		public static Vector3 ClosestPointOnCatmullRomSplineToPoint(Vector3[] splinePoints, Vector3 point)
		{
			return EvaluateCatmullRomSpline(splinePoints, TOfClosestPointOnCatmullRomSplineToPoint(splinePoints, point));
		}

		public static float TOfClosestPointOnCatmullRomSplineToPoint(Vector3[] splinePoints, Vector3 point)
		{
			float num = float.PositiveInfinity;
			float result = float.NaN;
			for (int i = 0; i < 17; i++)
			{
				float num2 = (float)i / 16f;
				Vector3 b = EvaluateCatmullRomSpline(splinePoints, num2);
				float num3 = Vector3.Distance(point, b);
				if (num3 < num)
				{
					num = num3;
					result = num2;
				}
			}
			return result;
		}

		public static float SplineLength(Vector3[] nodes)
		{
			if (nodes.Length > 3)
			{
				float num = 0f;
				Vector3 b = nodes[1];
				int num2 = (nodes.Length - 3) * 20;
				for (int i = 1; i <= num2; i++)
				{
					float t = (float)i / (float)num2;
					Vector3 vector = EvaluateCatmullRomSpline(nodes, t);
					num += Vector3.Distance(vector, b);
					b = vector;
				}
				return num;
			}
			return 0f;
		}

		public static void DrawCatmullRomSpline(Vector3[] nodes, Color colour)
		{
			if (nodes.Length > 3)
			{
				Vector3 to = nodes[1];
				Gizmos.color = colour;
				int num = (nodes.Length - 3) * 10;
				for (int i = 1; i <= num; i++)
				{
					float t = (float)i / (float)num;
					Vector3 vector = EvaluateCatmullRomSpline(nodes, t);
					Gizmos.DrawLine(vector, to);
					to = vector;
				}
			}
		}

		public static void DrawEvenlySpacedPointsAlongCatmullRomSpline(Vector3[] nodes, Color colour, int numPoints, float pointRadius)
		{
			if (nodes.Length > 3)
			{
				Gizmos.color = colour;
				for (int i = 0; i <= numPoints; i++)
				{
					float t = (float)i / (float)numPoints;
					Gizmos.DrawSphere(EvaluateCatmullRomSpline(nodes, t), pointRadius);
				}
			}
		}
	}
}
