using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shapes
{
	public static class ShapesMath
	{
		public const float TAU = (float)Math.PI * 2f;

		public static float Frac(float x)
		{
			return x - Mathf.Floor(x);
		}

		public static float Eerp(float a, float b, float t)
		{
			return Mathf.Pow(a, 1f - t) * Mathf.Pow(b, t);
		}

		public static float SmoothCos01(float x)
		{
			return Mathf.Cos(x * (float)Math.PI) * -0.5f + 0.5f;
		}

		public static Vector2 AngToDir(float angRad)
		{
			return new Vector2(Mathf.Cos(angRad), Mathf.Sin(angRad));
		}

		public static float DirToAng(Vector2 dir)
		{
			return Mathf.Atan2(dir.y, dir.x);
		}

		public static Vector2 Rotate90CW(Vector2 v)
		{
			return new Vector2(v.y, 0f - v.x);
		}

		public static Vector2 Rotate90CCW(Vector2 v)
		{
			return new Vector2(0f - v.y, v.x);
		}

		public static Vector4 AtLeast0(Vector4 v)
		{
			return new Vector4(Mathf.Max(0f, v.x), Mathf.Max(0f, v.y), Mathf.Max(0f, v.z), Mathf.Max(0f, v.w));
		}

		public static float MaxComp(Vector4 v)
		{
			return Mathf.Max(Mathf.Max(Mathf.Max(v.y, v.x), v.z), v.w);
		}

		public static bool HasNegativeValues(Vector4 v)
		{
			if (!(v.x < 0f) && !(v.y < 0f) && !(v.z < 0f))
			{
				return v.w < 0f;
			}
			return true;
		}

		public static float Determinant(Vector2 a, Vector2 b)
		{
			return a.x * b.y - a.y * b.x;
		}

		public static float Luminance(Color c)
		{
			return c.r * 0.2126f + c.g * 0.7152f + c.b * 0.0722f;
		}

		public static bool PointInsideTriangle(Vector2 a, Vector2 b, Vector2 c, Vector2 point, float aMargin = 0f, float bMargin = 0f, float cMargin = 0f)
		{
			float num = Determinant(b - a, point - a);
			float num2 = Determinant(c - b, point - b);
			float num3 = Determinant(a - c, point - c);
			bool num4 = num < cMargin;
			bool flag = num2 < aMargin;
			bool flag2 = num3 < bMargin;
			if (num4 == flag)
			{
				return flag == flag2;
			}
			return false;
		}

		public static float PolygonSignedArea(List<Vector2> pts)
		{
			int count = pts.Count;
			float num = 0f;
			for (int i = 0; i < count; i++)
			{
				Vector2 vector = pts[i];
				Vector2 vector2 = pts[(i + 1) % count];
				num += (vector2.x - vector.x) * (vector2.y + vector.y);
			}
			return num;
		}

		public static Vector2 Rotate(Vector2 v, float angRad)
		{
			float num = Mathf.Cos(angRad);
			float num2 = Mathf.Sin(angRad);
			return new Vector2(num * v.x - num2 * v.y, num2 * v.x + num * v.y);
		}

		private static float DeltaAngleRad(float a, float b)
		{
			return Mathf.Repeat(b - a + (float)Math.PI, (float)Math.PI * 2f) - (float)Math.PI;
		}

		public static float InverseLerpAngleRad(float a, float b, float v)
		{
			float num = DeltaAngleRad(a, b);
			b = a + num;
			float num2 = a + num * 0.5f;
			v = num2 + DeltaAngleRad(num2, v);
			return Mathf.InverseLerp(a, b, v);
		}

		private static Vector2 Lerp(Vector2 a, Vector2 b, Vector2 t)
		{
			return new Vector2(Mathf.Lerp(a.x, b.x, t.x), Mathf.Lerp(a.y, b.y, t.y));
		}

		private static Vector2 InverseLerp(Vector2 a, Vector2 b, Vector2 v)
		{
			return (v - a) / (b - a);
		}

		private static Vector2 Remap(Vector2 iMin, Vector2 iMax, Vector2 oMin, Vector2 oMax, Vector2 value)
		{
			return Lerp(oMin, oMax, InverseLerp(iMin, iMax, value));
		}

		public static Vector2 Remap(Rect iRect, Rect oRect, Vector2 iPos)
		{
			return Remap(iRect.min, iRect.max, oRect.min, oRect.max, iPos);
		}

		public static Vector3 Abs(Vector3 v)
		{
			return new Vector3(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z));
		}

		public static IEnumerable<Vector3> GetArcPoints(Vector3 normA, Vector3 normB, Vector3 center, float radius, int count)
		{
			count = Mathf.Max(2, count);
			yield return DirToPt(normA);
			for (int i = 1; i < count - 1; i++)
			{
				float t = (float)i / ((float)count - 1f);
				yield return DirToPt(Vector3.Slerp(normA, normB, t));
			}
			yield return DirToPt(normB);
			Vector3 DirToPt(Vector3 dir)
			{
				return center + dir * radius;
			}
		}

		public static IEnumerable<Vector2> GetArcPoints(Vector2 normA, Vector2 normB, Vector2 center, float radius, int count)
		{
			count = Mathf.Max(2, count);
			yield return DirToPt(normA);
			for (int i = 1; i < count - 1; i++)
			{
				float t = (float)i / ((float)count - 1f);
				yield return DirToPt(Vector3.Slerp(normA, normB, t));
			}
			yield return DirToPt(normB);
			Vector2 DirToPt(Vector2 dir)
			{
				return center + dir * radius;
			}
		}

		public static IEnumerable<Vector3> CubicBezierPointsSkipFirst(Vector3 a, Vector3 b, Vector3 c, Vector3 d, int count)
		{
			for (int i = 1; i < count - 1; i++)
			{
				float t = (float)i / ((float)count - 1f);
				yield return CubicBezier(a, b, c, d, t);
			}
			yield return d;
		}

		public static IEnumerable<Vector2> CubicBezierPointsSkipFirst(Vector2 a, Vector2 b, Vector2 c, Vector2 d, int count)
		{
			for (int i = 1; i < count - 1; i++)
			{
				float t = (float)i / ((float)count - 1f);
				yield return CubicBezier(a, b, c, d, t);
			}
			yield return d;
		}

		public static Vector3 CubicBezier(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
		{
			if (t <= 0f)
			{
				return a;
			}
			if (t >= 1f)
			{
				return d;
			}
			float num = 1f - t;
			float num2 = num * num;
			float num3 = t * t;
			return a * (num2 * num) + b * (3f * num2 * t) + c * (3f * num * num3) + d * (num3 * t);
		}

		public static Vector2 CubicBezier(Vector2 a, Vector2 b, Vector2 c, Vector2 d, float t)
		{
			if (t <= 0f)
			{
				return a;
			}
			if (t >= 1f)
			{
				return d;
			}
			float num = 1f - t;
			float num2 = num * num;
			float num3 = t * t;
			return a * (num2 * num) + b * (3f * num2 * t) + c * (3f * num * num3) + d * (num3 * t);
		}

		public static Vector3 CubicBezierDerivative(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
		{
			float num = 1f - t;
			float num2 = num * num;
			float num3 = t * t;
			return a * (-3f * num2) + b * (9f * num3 - 12f * t + 3f) + c * (6f * t - 9f * num3) + d * (3f * num3);
		}

		public static float GetApproximateCurveSum(Vector3 a, Vector3 b, Vector3 c, Vector3 d, int vertCount)
		{
			Vector2[] array = new Vector2[vertCount];
			for (int i = 0; i < vertCount; i++)
			{
				float t = (float)i / ((float)vertCount - 1f);
				array[i] = CubicBezierDerivative(a, b, c, d, t);
			}
			float num = 0f;
			for (int j = 0; j < vertCount - 1; j++)
			{
				num += Vector2.Angle(array[j], array[j + 1]);
			}
			return num;
		}
	}
}
