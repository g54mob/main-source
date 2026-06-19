using UnityEngine;

namespace Battlehub.SplineEditor
{
	public static class CurveUtils
	{
		public static float GetT(this SplineBase spline, int curveIndex, Vector3 testPoint, float eps = 0.01f)
		{
			float num = 1f / (float)spline.CurveCount * (float)curveIndex;
			float tEnd = num + 1f / (float)spline.CurveCount;
			int iter = 0;
			return spline.GetT(num, tEnd, testPoint, ref iter, eps);
		}

		private static float GetT(this SplineBase spline, float tStart, float tEnd, Vector3 testPoint, ref int iter, float eps = 0.01f)
		{
			iter++;
			float num = eps * eps;
			Vector3 point = spline.GetPoint(tStart);
			Vector3 point2 = spline.GetPoint(tEnd);
			Vector3 vector = point - testPoint;
			Vector3 vector2 = point2 - testPoint;
			if (vector.sqrMagnitude < vector2.sqrMagnitude)
			{
				if ((point2 - point).sqrMagnitude <= num)
				{
					return tStart;
				}
				return spline.GetT(tStart, (tStart + tEnd) / 2f, testPoint, ref iter, eps);
			}
			if ((point2 - point).sqrMagnitude <= num)
			{
				return tEnd;
			}
			return spline.GetT((tStart + tEnd) / 2f, tEnd, testPoint, ref iter, eps);
		}

		public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
		{
			t = Mathf.Clamp01(t);
			float num = 1f - t;
			return num * num * num * p0 + 3f * num * num * t * p1 + 3f * num * t * t * p2 + t * t * t * p3;
		}

		public static Vector3 GetFirstDerivative(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
		{
			t = Mathf.Clamp01(t);
			float num = 1f - t;
			return 3f * num * num * (p1 - p0) + 6f * num * t * (p2 - p1) + 3f * t * t * (p3 - p2);
		}
	}
}
