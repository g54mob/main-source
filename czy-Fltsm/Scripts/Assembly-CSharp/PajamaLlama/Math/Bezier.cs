using System.Collections.Generic;
using UnityEngine;

namespace PajamaLlama.Math
{
	public static class Bezier
	{
		private static float CalculateBinomialFactor(int n, int k)
		{
			return CalculateFactorial(n) / (CalculateFactorial(k) * CalculateFactorial(n - k));
		}

		private static int CalculateFactorial(int n)
		{
			if (n <= 1)
			{
				return 1;
			}
			return n * CalculateFactorial(n - 1);
		}

		private static Vector3 CalculateCurvePoint(float t, int n, int k, Vector3 point)
		{
			_ = Vector3.zero;
			return CalculateBernsteinPolynomial(t, n, k) * point;
		}

		public static Vector3 CalculatePointInTime(float t, List<Vector3> points)
		{
			int n = points.Count - 1;
			Vector3 zero = Vector3.zero;
			for (int i = 0; i < points.Count; i++)
			{
				int num = i;
				zero += CalculateCurvePoint(t, n, num, points[num]);
			}
			return zero;
		}

		private static float CalculateBernsteinPolynomial(float t, int n, int k)
		{
			return CalculateBinomialFactor(n, k) * Mathf.Pow(1f - t, n - k) * Mathf.Pow(t, k);
		}

		public static Vector3 CalculateDerivative(float t, List<Vector3> points)
		{
			Vector3 zero = Vector3.zero;
			int num = points.Count - 1;
			for (int i = 0; i < points.Count - 1; i++)
			{
				int num2 = i;
				zero += (points[num2 + 1] - points[num2]) * CalculateBernsteinPolynomial(t, num - 1, num2);
			}
			return zero * num;
		}

		public static Vector2 CalculateBezierPoint(float t, Vector2 startPosition, Vector2 startCurve, Vector2 endCurve, Vector2 endPosition)
		{
			float num = 1f - t;
			float num2 = t * t;
			float num3 = num * num;
			float num4 = num3 * num;
			float num5 = num2 * t;
			return num4 * startPosition + 3f * num3 * t * startCurve + 3f * num * num2 * endCurve + num5 * endPosition;
		}

		public static Vector3 CalculateQuadraticBezierPoint(float t, Vector3 startPoint, Vector3 middlePoint, Vector3 endPoint)
		{
			float num = 1f - t;
			float num2 = t * t;
			return num * num * startPoint + 2f * num * t * middlePoint + num2 * endPoint;
		}
	}
}
