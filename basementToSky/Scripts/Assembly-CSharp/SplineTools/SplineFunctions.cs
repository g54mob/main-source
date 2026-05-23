using UnityEngine;
using UnityEngine.Splines;

namespace SplineTools
{
	public static class SplineFunctions
	{
		public static float GetDistanceAlongSpline(SplineContainer splineContainer, int index, Vector3 point, int samples = 100)
		{
			if (splineContainer == null)
			{
				Debug.LogError("SplineContainer is not assigned.");
				return -1f;
			}
			Spline spline = splineContainer.Splines[index];
			float num = float.MaxValue;
			float num2 = 0f;
			for (int i = 0; i <= samples; i++)
			{
				float num3 = (float)i / (float)samples;
				Vector3 b = spline.EvaluatePosition(num3);
				float num4 = Vector3.Distance(point, b);
				if (num4 < num)
				{
					num = num4;
					num2 = num3;
				}
			}
			float num5 = 0f;
			Vector3 a = spline.EvaluatePosition(0f);
			int num6 = 1000;
			for (int j = 1; j <= num6; j++)
			{
				float t = (float)j / (float)num6 * num2;
				Vector3 vector = spline.EvaluatePosition(t);
				num5 += Vector3.Distance(a, vector);
				a = vector;
			}
			return num5;
		}
	}
}
