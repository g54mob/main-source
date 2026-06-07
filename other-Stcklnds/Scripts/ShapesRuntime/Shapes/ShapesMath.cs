using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Shapes
{
	public static class ShapesMath
	{
		private const MethodImplOptions INLINE = MethodImplOptions.AggressiveInlining;

		public const float TAU = MathF.PI * 2f;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Frac(float x)
		{
			return x - Mathf.Floor(x);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Eerp(float a, float b, float t)
		{
			return Mathf.Pow(a, 1f - t) * Mathf.Pow(b, t);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float SmoothCos01(float x)
		{
			return Mathf.Cos(x * MathF.PI) * -0.5f + 0.5f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 AngToDir(float angRad)
		{
			return new Vector2(Mathf.Cos(angRad), Mathf.Sin(angRad));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float DirToAng(Vector2 dir)
		{
			return Mathf.Atan2(dir.y, dir.x);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 Rotate90CW(Vector2 v)
		{
			return new Vector2(v.y, 0f - v.x);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 Rotate90CCW(Vector2 v)
		{
			return new Vector2(0f - v.y, v.x);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector4 AtLeast0(Vector4 v)
		{
			return new Vector4(Mathf.Max(0f, v.x), Mathf.Max(0f, v.y), Mathf.Max(0f, v.z), Mathf.Max(0f, v.w));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float MaxComp(Vector4 v)
		{
			return Mathf.Max(Mathf.Max(Mathf.Max(v.y, v.x), v.z), v.w);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasNegativeValues(Vector4 v)
		{
			if (!(v.x < 0f) && !(v.y < 0f) && !(v.z < 0f))
			{
				return v.w < 0f;
			}
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Determinant(Vector2 a, Vector2 b)
		{
			return a.x * b.y - a.y * b.x;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Luminance(Color c)
		{
			return c.r * 0.2126f + c.g * 0.7152f + c.b * 0.0722f;
		}

		public static float GetLineSegmentProjectionT(Vector3 a, Vector3 b, Vector3 p)
		{
			Vector3 vector = b - a;
			return Vector3.Dot(p - a, vector) / Vector3.Dot(vector, vector);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static PolylinePoint WeightedSum(Vector4 w, PolylinePoint a, PolylinePoint b, PolylinePoint c, PolylinePoint d)
		{
			return w.x * a + w.y * b + w.z * c + w.w * d;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 WeightedSum(Vector4 w, Vector3 a, Vector3 b, Vector3 c, Vector3 d)
		{
			return w.x * a + w.y * b + w.z * c + w.w * d;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 WeightedSum(Vector4 w, Vector2 a, Vector2 b, Vector2 c, Vector2 d)
		{
			return w.x * a + w.y * b + w.z * c + w.w * d;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Color WeightedSum(Vector4 w, Color a, Color b, Color c, Color d)
		{
			return w.x * a + w.y * b + w.z * c + w.w * d;
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
			return Mathf.Repeat(b - a + MathF.PI, MathF.PI * 2f) - MathF.PI;
		}

		public static float InverseLerpAngleRad(float a, float b, float v)
		{
			float num = DeltaAngleRad(a, b);
			b = a + num;
			float num2 = a + num * 0.5f;
			v = num2 + DeltaAngleRad(num2, v);
			return Mathf.InverseLerp(a, b, v);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static Vector2 Lerp(Vector2 a, Vector2 b, Vector2 t)
		{
			return new Vector2(Mathf.Lerp(a.x, b.x, t.x), Mathf.Lerp(a.y, b.y, t.y));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static Vector2 InverseLerp(Vector2 a, Vector2 b, Vector2 v)
		{
			return (v - a) / (b - a);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static Vector2 Remap(Vector2 iMin, Vector2 iMax, Vector2 oMin, Vector2 oMax, Vector2 value)
		{
			return Lerp(oMin, oMax, InverseLerp(iMin, iMax, value));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector2 Remap(Rect iRect, Rect oRect, Vector2 iPos)
		{
			return Remap(iRect.min, iRect.max, oRect.min, oRect.max, iPos);
		}

		public static Vector3 Abs(Vector3 v)
		{
			return new Vector3(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z));
		}

		public static float RandomGaussian(float min = 0f, float max = 1f)
		{
			float num;
			float num3;
			do
			{
				num = 2f * UnityEngine.Random.value - 1f;
				float num2 = 2f * UnityEngine.Random.value - 1f;
				num3 = num * num + num2 * num2;
			}
			while (num3 >= 1f);
			float num4 = num * Mathf.Sqrt(-2f * Mathf.Log(num3) / num3);
			float num5 = (min + max) / 2f;
			float num6 = (max - num5) / 3f;
			return Mathf.Clamp(num4 * num6 + num5, min, max);
		}

		public static Vector3 GetRandomPerpendicularVector(Vector3 a)
		{
			Vector3 onUnitSphere;
			do
			{
				onUnitSphere = UnityEngine.Random.onUnitSphere;
			}
			while (Mathf.Abs(Vector3.Dot(a, onUnitSphere)) > 0.98f);
			return onUnitSphere;
		}

		public static IEnumerable<PolylinePoint> GetArcPoints(PolylinePoint a, PolylinePoint b, Vector3 normA, Vector3 normB, Vector3 center, float radius, int count)
		{
			count = Mathf.Max(2, count);
			yield return DirToPt(normA, 0f);
			for (int i = 1; i < count - 1; i++)
			{
				float t = (float)i / ((float)count - 1f);
				yield return DirToPt(Vector3.Slerp(normA, normB, t), t);
			}
			yield return DirToPt(normB, 1f);
			PolylinePoint DirToPt(Vector3 dir, float num)
			{
				PolylinePoint result = ((num <= 0f) ? a : ((num >= 1f) ? b : PolylinePoint.Lerp(a, b, num)));
				result.point = center + dir * radius;
				return result;
			}
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

		public static IEnumerable<PolylinePoint> CubicBezierPointsSkipFirst(PolylinePoint a, PolylinePoint b, PolylinePoint c, PolylinePoint d, int count)
		{
			for (int i = 1; i < count - 1; i++)
			{
				float t = (float)i / ((float)count - 1f);
				yield return CubicBezier(a, b, c, d, t);
			}
			yield return d;
		}

		public static IEnumerable<PolylinePoint> CubicBezierPointsSkipFirstMatchStyle(PolylinePoint style, Vector3 a, Vector3 b, Vector3 c, Vector3 d, int count)
		{
			for (int i = 1; i < count - 1; i++)
			{
				float t = (float)i / ((float)count - 1f);
				PolylinePoint polylinePoint = style;
				polylinePoint.point = CubicBezier(a, b, c, d, t);
				yield return polylinePoint;
			}
			PolylinePoint polylinePoint2 = style;
			polylinePoint2.point = d;
			yield return polylinePoint2;
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

		public static Vector4 GetCubicBezierWeights(float t)
		{
			float num = 1f - t;
			float num2 = num * num;
			float num3 = t * t;
			return new Vector4(num2 * num, 3f * num2 * t, 3f * num * num3, num3 * t);
		}

		public static PolylinePoint CubicBezier(PolylinePoint a, PolylinePoint b, PolylinePoint c, PolylinePoint d, float t)
		{
			if (t <= 0f)
			{
				return a;
			}
			if (t >= 1f)
			{
				return d;
			}
			return WeightedSum(GetCubicBezierWeights(t), a, b, c, d);
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
			return WeightedSum(GetCubicBezierWeights(t), a, b, c, d);
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
			return WeightedSum(GetCubicBezierWeights(t), a, b, c, d);
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
