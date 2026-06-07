using System;
using System.Collections.Generic;
using UnityEngine;

public class BezierArcApproximation : MonoBehaviour
{
	public struct Arc
	{
		public Vector3 center;

		public float s;

		public float e;

		public float r;

		public float bezierStartT;

		public float bezierEndT;

		public float Length => Mathf.Abs(r * (e - s));
	}

	private const float MIN_ERROR = 0.1f;

	public float error = 0.5f;

	public BezierCurve curve;

	private static Vector3 LineLineIntersection2D(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
	{
		float num = (x1 * y2 - y1 * x2) * (x3 - x4) - (x1 - x2) * (x3 * y4 - y3 * x4);
		float num2 = (x1 * y2 - y1 * x2) * (y3 - y4) - (y1 - y2) * (x3 * y4 - y3 * x4);
		float num3 = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);
		if (num3 != 0f)
		{
			return new Vector3(num / num3, 0f, num2 / num3);
		}
		return Vector3.negativeInfinity;
	}

	private static Arc GetCCenter(Vector3 p1, Vector3 p2, Vector3 p3)
	{
		float num = p2.x - p1.x;
		float num2 = p2.z - p1.z;
		float num3 = p3.x - p2.x;
		float num4 = p3.z - p2.z;
		float num5 = Mathf.Sin((float)Math.PI / 2f);
		float num6 = Mathf.Cos((float)Math.PI / 2f);
		float num7 = num * num6 - num2 * num5;
		float num8 = num * num5 + num2 * num6;
		float num9 = num3 * num6 - num4 * num5;
		float num10 = num3 * num5 + num4 * num6;
		float num11 = (p1.x + p2.x) / 2f;
		float num12 = (p1.z + p2.z) / 2f;
		float num13 = (p2.x + p3.x) / 2f;
		float num14 = (p2.z + p3.z) / 2f;
		float x = num11 + num7;
		float y = num12 + num8;
		float x2 = num13 + num9;
		float y2 = num14 + num10;
		Vector3 a = LineLineIntersection2D(num11, num12, x, y, num13, num14, x2, y2);
		float r = Vector3.Distance(a, p1);
		float num15 = Mathf.Atan2(p1.z - a.z, p1.x - a.x);
		float num16 = Mathf.Atan2(p2.z - a.z, p2.x - a.x);
		float num17 = Mathf.Atan2(p3.z - a.z, p3.x - a.x);
		if (num15 < num17)
		{
			if (num15 > num16 || num16 > num17)
			{
				num15 += (float)Math.PI * 2f;
			}
			if (num15 > num17)
			{
				float num18 = num17;
				num17 = num15;
				num15 = num18;
			}
		}
		else if (num17 < num16 && num16 < num15)
		{
			float num19 = num17;
			num17 = num15;
			num15 = num19;
		}
		else
		{
			num17 += (float)Math.PI * 2f;
		}
		return new Arc
		{
			center = new Vector3(a.x, 0f, a.z),
			s = num15,
			e = num17,
			r = r
		};
	}

	private static Vector3 GetPoint2D(BezierCurve bez, float t)
	{
		Vector3 pointAt = bez.GetPointAt(t);
		pointAt.y = 0f;
		return pointAt;
	}

	public static void CalculateArcs(BezierCurve bez, float errorThreshold, List<Arc> result)
	{
		errorThreshold = Mathf.Max(0.1f, errorThreshold);
		float num = 0f;
		float num3;
		do
		{
			float num2 = 0f;
			num3 = 1f;
			Vector3 point2D = GetPoint2D(bez, num);
			Arc arc = default(Arc);
			bool flag = false;
			float num4 = 1f;
			int num5 = 0;
			Arc? arc2;
			bool flag2;
			do
			{
				bool num6 = flag;
				arc2 = arc;
				float num7 = (num + num3) / 2f;
				num5++;
				Vector3 point2D2 = GetPoint2D(bez, num7);
				Vector3 point2D3 = GetPoint2D(bez, num3);
				arc = GetCCenter(point2D, point2D2, point2D3);
				arc.bezierStartT = num;
				arc.bezierEndT = num3;
				flag = Error(bez, arc.center, point2D, num, num3) <= errorThreshold;
				flag2 = num6 && !flag;
				if (!flag2)
				{
					num4 = num3;
				}
				if (flag)
				{
					if (num3 >= 1f)
					{
						num4 = (arc.bezierEndT = 1f);
						arc2 = arc;
						if (num3 > 1f)
						{
							Vector3 to = new Vector3(arc.center.x + arc.r * Mathf.Cos(arc.e), 0f, arc.center.z + arc.r * Mathf.Sin(arc.e));
							arc.e += Vector3.Angle(arc.center, to);
						}
						break;
					}
					num3 += (num3 - num) / 2f;
				}
				else
				{
					num3 = num7;
				}
			}
			while (!flag2 && num2++ < 100f);
			if (num2 >= 100f)
			{
				Debug.Log("Hit safety");
				break;
			}
			arc2 = (arc2.HasValue ? arc2.Value : arc);
			result.Add(arc2.Value);
			num = num4;
		}
		while (num3 < 1f);
	}

	private static float Error(BezierCurve bez, Vector3 pc, Vector3 np1, float s, float e)
	{
		float num = (e - s) / 4f;
		Vector3 point2D = GetPoint2D(bez, s + num);
		Vector3 point2D2 = GetPoint2D(bez, e - num);
		float num2 = Vector3.Distance(pc, np1);
		float num3 = Vector3.Distance(pc, point2D);
		float num4 = Vector3.Distance(pc, point2D2);
		return Mathf.Abs(num3 - num2) + Mathf.Abs(num4 - num2);
	}

	private void OnValidate()
	{
		if (!curve)
		{
			curve = GetComponent<BezierCurve>();
		}
		error = Mathf.Max(error, 0.1f);
	}
}
