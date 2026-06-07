using UnityEngine;

public static class BezierCurveUpgrade
{
	public static void Upgrade(BezierCurve curve)
	{
		if (curve.version >= 2)
		{
			return;
		}
		if (curve.pointCount >= 2)
		{
			Debug.Log($"[BezierCurve upgrade] adapting curve resolution value for '{curve.name}'", curve);
			float num = float.MaxValue;
			for (int i = 0; i < curve.pointCount - 1; i++)
			{
				float num2 = BezierCurve.ApproximateLength(curve[i], curve[i + 1], 5);
				if (num2 < num)
				{
					num = num2;
				}
			}
			float num3 = curve.resolution / num;
			Debug.Log($"Old resolution: {curve.resolution}, new resolution: {num3}", curve);
			curve.resolution = num3;
		}
		curve.version = 2;
	}
}
