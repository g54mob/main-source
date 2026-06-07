using System;
using UnityEngine;

namespace Utils.Geometry
{
	public class LineIntersection
	{
		public enum LineIntersectMode
		{
			Lines = 0,
			Rays = 1,
			RayLine = 2,
			RaySegment = 3,
			Segments = 4
		}

		public struct IntersectionInfo
		{
			public enum IntersectionType
			{
				Point = 0,
				Collinear = 1,
				None = 2
			}

			public IntersectionType type;

			public Vector2 intersection;

			public IntersectionInfo(IntersectionType type, Vector2 intersection)
			{
				this.type = type;
				this.intersection = intersection;
			}

			public IntersectionInfo(IntersectionType type)
			{
				this.type = type;
				intersection = new Vector2(0f, 0f);
			}
		}

		public static readonly int None = -1;

		public static readonly int Collinear = -2;

		public static readonly int Point = -3;

		private static float Cross(float aX, float aY, float bX, float bY)
		{
			return aX * bY - aY * bX;
		}

		public static bool IntersectLines(Vector2 a1, Vector2 a2, Vector2 b1, Vector2 b2, out Vector2 intersect, LineIntersectMode lineIntersectMode = LineIntersectMode.Segments)
		{
			intersect = new Vector2(float.NaN, float.NaN);
			if (lineIntersectMode == LineIntersectMode.Segments)
			{
				Rect rect = RectFromSegment(a1, a2);
				Rect other = RectFromSegment(b1, b2);
				if (!rect.Overlaps(other))
				{
					return false;
				}
			}
			Vector3 vector = Vector3.Cross(Vector3.Cross(HCoord(a1), HCoord(a2)), Vector3.Cross(HCoord(b1), HCoord(b2)));
			if (Mathf.Abs(vector.z) < 1E-06f)
			{
				return false;
			}
			Vector2 vector2 = (Vector2)vector * (1f / vector.z);
			if (lineIntersectMode switch
			{
				LineIntersectMode.Rays => !IsIntersectPointWithinSegment(vector2, a1, a2) || !IsIntersectPointWithinSegment(vector2, b1, b2), 
				LineIntersectMode.RayLine => !IsIntersectPointWithinSegment(vector2, a1, a2), 
				LineIntersectMode.RaySegment => !IsIntersectPointWithinSegment(vector2, a1, a2) || !IsIntersectPointWithinSegment(vector2, b1, b2, bidirectional: true), 
				LineIntersectMode.Segments => !IsIntersectPointWithinSegment(vector2, a1, a2, bidirectional: true) || !IsIntersectPointWithinSegment(vector2, b1, b2, bidirectional: true), 
				_ => false, 
			})
			{
				return false;
			}
			intersect = vector2;
			return true;
			static Vector3 HCoord(Vector2 p)
			{
				return new Vector3(p.x, p.y, 1f);
			}
			static bool IsIntersectPointWithinSegment(Vector2 p, Vector2 vector4, Vector2 vector3, bool bidirectional = false)
			{
				int index = ((Mathf.Abs(vector3.x - vector4.x) < Mathf.Abs(vector3.y - vector4.y)) ? 1 : 0);
				float num = p[index] - vector4[index];
				float num2 = vector3[index] - vector4[index];
				if (bidirectional && Mathf.Abs(num) > Mathf.Abs(num2))
				{
					return false;
				}
				return num >= 0f == num2 >= 0f;
			}
			static Vector2 MaxFrom(Vector2 vector3, Vector2 vector4)
			{
				return new Vector2(Math.Max(vector3.x, vector4.x), Math.Max(vector3.y, vector4.y));
			}
			static Vector2 MinFrom(Vector2 vector3, Vector2 vector4)
			{
				return new Vector2(Math.Min(vector3.x, vector4.x), Math.Min(vector3.y, vector4.y));
			}
			static Rect RectFromSegment(Vector2 a3, Vector2 b3)
			{
				Vector2 vector3 = MinFrom(a3, b3);
				return new Rect(vector3, MaxFrom(a3, b3) - vector3);
			}
		}

		public static int LineLineIntersection(float startAx, float startAy, float endAx, float endAy, float startBx, float startBy, float endBx, float endBy, out float pointX, out float pointY)
		{
			pointX = 0f;
			pointY = 0f;
			float aX = startBx - startAx;
			float aY = startBy - startAy;
			float a = Cross(endAx, endAy, endBx, endBy);
			float num = Cross(aX, aY, endAx, endAy);
			bool flag = Mathf.Approximately(a, 0f);
			bool flag2 = Mathf.Approximately(num, 0f);
			if (flag && flag2)
			{
				return Collinear;
			}
			if (!flag)
			{
				float num2 = Cross(endAx, endAy, endBx, endBy);
				float num3 = Cross(aX, aY, endBx, endBy) / num2;
				float num4 = num / num2;
				if (num3 >= 0f && num3 <= 1f && num4 >= 0f && num4 <= 1f)
				{
					pointX = startAx + num3 * endAx;
					pointY = startAy + num3 * endAy;
					return Point;
				}
			}
			return None;
		}

		public static IntersectionInfo LineLineIntersection(Vector2 startA, Vector2 endA, Vector2 startB, Vector2 endB)
		{
			Vector2 lhs = startB - startA;
			float a = endA.Cross(endB);
			float a2 = lhs.Cross(endA);
			if (Mathf.Approximately(a, 0f) && Mathf.Approximately(a2, 0f))
			{
				return new IntersectionInfo(IntersectionInfo.IntersectionType.Collinear);
			}
			if (!Mathf.Approximately(a, 0f))
			{
				float num = lhs.Cross(endB) / endA.Cross(endB);
				float num2 = lhs.Cross(endA) / endA.Cross(endB);
				if (num >= 0f && num <= 1f && num2 >= 0f && num2 <= 1f)
				{
					Vector2 intersection = startA + num * endA;
					return new IntersectionInfo(IntersectionInfo.IntersectionType.Point, intersection);
				}
			}
			return new IntersectionInfo(IntersectionInfo.IntersectionType.None);
		}
	}
}
