using System;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding
{
	public static class VectorMath
	{
		public static Vector2 ComplexMultiply(Vector2 a, Vector2 b)
		{
			return new Vector2(a.x * b.x - a.y * b.y, a.x * b.y + a.y * b.x);
		}

		public static float2 ComplexMultiply(float2 a, float2 b)
		{
			return a.x * b + a.y * new float2(0f - b.y, b.x);
		}

		public static float2 ComplexMultiplyConjugate(float2 a, float2 b)
		{
			return new float2(a.x * b.x + a.y * b.y, a.y * b.x - a.x * b.y);
		}

		public static Vector2 ComplexMultiplyConjugate(Vector2 a, Vector2 b)
		{
			return new Vector2(a.x * b.x + a.y * b.y, a.y * b.x - a.x * b.y);
		}

		public static Vector3 ClosestPointOnLine(Vector3 lineStart, Vector3 lineEnd, Vector3 point)
		{
			Vector3 vector = Vector3.Normalize(lineEnd - lineStart);
			float num = Vector3.Dot(point - lineStart, vector);
			return lineStart + num * vector;
		}

		public static float ClosestPointOnLineFactor(Vector3 lineStart, Vector3 lineEnd, Vector3 point)
		{
			Vector3 rhs = lineEnd - lineStart;
			float sqrMagnitude = rhs.sqrMagnitude;
			if (sqrMagnitude <= 1E-06f)
			{
				return 0f;
			}
			return Vector3.Dot(point - lineStart, rhs) / sqrMagnitude;
		}

		public static float ClosestPointOnLineFactor(float3 lineStart, float3 lineEnd, float3 point)
		{
			float3 float5 = lineEnd - lineStart;
			float num = math.dot(float5, float5);
			return math.select(0f, math.dot(point - lineStart, float5) / num, num > 1E-06f);
		}

		public static float ClosestPointOnLineFactor(Int3 lineStart, Int3 lineEnd, Int3 point)
		{
			Int3 rhs = lineEnd - lineStart;
			float sqrMagnitude = rhs.sqrMagnitude;
			float num = Int3.DotLong(point - lineStart, rhs);
			if (sqrMagnitude != 0f)
			{
				num /= sqrMagnitude;
			}
			return num;
		}

		public static float ClosestPointOnLineFactor(Int2 lineStart, Int2 lineEnd, Int2 point)
		{
			Int2 b = lineEnd - lineStart;
			double num = b.sqrMagnitudeLong;
			double num2 = Int2.DotLong(point - lineStart, b);
			if (num != 0.0)
			{
				num2 /= num;
			}
			return (float)num2;
		}

		public static Vector3 ClosestPointOnSegment(Vector3 lineStart, Vector3 lineEnd, Vector3 point)
		{
			Vector3 vector = lineEnd - lineStart;
			float sqrMagnitude = vector.sqrMagnitude;
			if ((double)sqrMagnitude <= 1E-06)
			{
				return lineStart;
			}
			float value = Vector3.Dot(point - lineStart, vector) / sqrMagnitude;
			return lineStart + Mathf.Clamp01(value) * vector;
		}

		public static Vector3 ClosestPointOnSegmentXZ(Vector3 lineStart, Vector3 lineEnd, Vector3 point)
		{
			lineStart.y = point.y;
			lineEnd.y = point.y;
			Vector3 vector = lineEnd - lineStart;
			vector.y = 0f;
			float magnitude = vector.magnitude;
			Vector3 vector2 = ((magnitude > float.Epsilon) ? (vector / magnitude) : Vector3.zero);
			float value = Vector3.Dot(point - lineStart, vector2);
			return lineStart + Mathf.Clamp(value, 0f, vector.magnitude) * vector2;
		}

		public static float SqrDistancePointSegmentApproximate(int x, int z, int px, int pz, int qx, int qz)
		{
			float num = qx - px;
			float num2 = qz - pz;
			float num3 = x - px;
			float num4 = z - pz;
			float num5 = num * num + num2 * num2;
			float num6 = num * num3 + num2 * num4;
			if (num5 > 0f)
			{
				num6 /= num5;
			}
			if (num6 < 0f)
			{
				num6 = 0f;
			}
			else if (num6 > 1f)
			{
				num6 = 1f;
			}
			num3 = (float)px + num6 * num - (float)x;
			num4 = (float)pz + num6 * num2 - (float)z;
			return num3 * num3 + num4 * num4;
		}

		public static float SqrDistancePointSegmentApproximate(Int3 a, Int3 b, Int3 p)
		{
			float num = b.x - a.x;
			float num2 = b.z - a.z;
			float num3 = p.x - a.x;
			float num4 = p.z - a.z;
			float num5 = num * num + num2 * num2;
			float num6 = num * num3 + num2 * num4;
			if (num5 > 0f)
			{
				num6 /= num5;
			}
			if (num6 < 0f)
			{
				num6 = 0f;
			}
			else if (num6 > 1f)
			{
				num6 = 1f;
			}
			num3 = (float)a.x + num6 * num - (float)p.x;
			num4 = (float)a.z + num6 * num2 - (float)p.z;
			return num3 * num3 + num4 * num4;
		}

		public static float SqrDistancePointSegment(Vector3 a, Vector3 b, Vector3 p)
		{
			return (ClosestPointOnSegment(a, b, p) - p).sqrMagnitude;
		}

		public static float SqrDistanceSegmentSegment(Vector3 s1, Vector3 e1, Vector3 s2, Vector3 e2)
		{
			Vector3 vector = e1 - s1;
			Vector3 vector2 = e2 - s2;
			Vector3 vector3 = s1 - s2;
			double num = Vector3.Dot(vector, vector);
			double num2 = Vector3.Dot(vector, vector2);
			double num3 = Vector3.Dot(vector2, vector2);
			double num4 = Vector3.Dot(vector, vector3);
			double num5 = Vector3.Dot(vector2, vector3);
			double num6;
			double num7;
			double num8;
			double num9;
			if ((num6 = (num7 = num * num3 - num2 * num2)) < 1E-06 * num * num3)
			{
				num8 = 0.0;
				num7 = 1.0;
				num9 = num5;
				num6 = num3;
			}
			else
			{
				num8 = num2 * num5 - num3 * num4;
				num9 = num * num5 - num2 * num4;
				if (num8 < 0.0)
				{
					num8 = 0.0;
					num9 = num5;
					num6 = num3;
				}
				else if (num8 > num7)
				{
					num8 = num7;
					num9 = num5 + num2;
					num6 = num3;
				}
			}
			if (num9 < 0.0)
			{
				num9 = 0.0;
				if (0.0 - num4 < 0.0)
				{
					num8 = 0.0;
				}
				else if (0.0 - num4 > num)
				{
					num8 = num7;
				}
				else
				{
					num8 = 0.0 - num4;
					num7 = num;
				}
			}
			else if (num9 > num6)
			{
				num9 = num6;
				if (0.0 - num4 + num2 < 0.0)
				{
					num8 = 0.0;
				}
				else if (0.0 - num4 + num2 > num)
				{
					num8 = num7;
				}
				else
				{
					num8 = 0.0 - num4 + num2;
					num7 = num;
				}
			}
			double num10 = ((Math.Abs(num8) < 9.999999747378752E-06) ? 0.0 : (num8 / num7));
			double num11 = ((Math.Abs(num9) < 9.999999747378752E-06) ? 0.0 : (num9 / num6));
			return (vector3 + (float)num10 * vector - (float)num11 * vector2).sqrMagnitude;
		}

		public static float Determinant(float2 c1, float2 c2)
		{
			return c1.x * c2.y - c1.y * c2.x;
		}

		public static float SqrDistanceXZ(Vector3 a, Vector3 b)
		{
			Vector3 vector = a - b;
			return vector.x * vector.x + vector.z * vector.z;
		}

		public static long SignedTriangleAreaTimes2XZ(Int3 a, Int3 b, Int3 c)
		{
			return (long)(b.x - a.x) * (long)(c.z - a.z) - (long)(c.x - a.x) * (long)(b.z - a.z);
		}

		public static float SignedTriangleAreaTimes2XZ(Vector3 a, Vector3 b, Vector3 c)
		{
			return (b.x - a.x) * (c.z - a.z) - (c.x - a.x) * (b.z - a.z);
		}

		public static bool RightXZ(Vector3 a, Vector3 b, Vector3 p)
		{
			return (b.x - a.x) * (p.z - a.z) - (p.x - a.x) * (b.z - a.z) < -1E-45f;
		}

		public static bool RightXZ(Int3 a, Int3 b, Int3 p)
		{
			return (long)(b.x - a.x) * (long)(p.z - a.z) - (long)(p.x - a.x) * (long)(b.z - a.z) < 0;
		}

		public static Side SideXZ(Int3 a, Int3 b, Int3 p)
		{
			long num = (long)(b.x - a.x) * (long)(p.z - a.z) - (long)(p.x - a.x) * (long)(b.z - a.z);
			if (num <= 0)
			{
				if (num >= 0)
				{
					return Side.Colinear;
				}
				return Side.Right;
			}
			return Side.Left;
		}

		public static bool RightOrColinear(Vector2 a, Vector2 b, Vector2 p)
		{
			return (b.x - a.x) * (p.y - a.y) - (p.x - a.x) * (b.y - a.y) <= 0f;
		}

		public static bool RightOrColinear(Int2 a, Int2 b, Int2 p)
		{
			return (long)(b.x - a.x) * (long)(p.y - a.y) - (long)(p.x - a.x) * (long)(b.y - a.y) <= 0;
		}

		public static bool RightOrColinearXZ(Vector3 a, Vector3 b, Vector3 p)
		{
			return (b.x - a.x) * (p.z - a.z) - (p.x - a.x) * (b.z - a.z) <= 0f;
		}

		public static bool RightOrColinearXZ(Int3 a, Int3 b, Int3 p)
		{
			return (long)(b.x - a.x) * (long)(p.z - a.z) - (long)(p.x - a.x) * (long)(b.z - a.z) <= 0;
		}

		public static bool IsClockwiseMarginXZ(Vector3 a, Vector3 b, Vector3 c)
		{
			return (b.x - a.x) * (c.z - a.z) - (c.x - a.x) * (b.z - a.z) <= float.Epsilon;
		}

		public static bool IsClockwiseXZ(Vector3 a, Vector3 b, Vector3 c)
		{
			return (b.x - a.x) * (c.z - a.z) - (c.x - a.x) * (b.z - a.z) < 0f;
		}

		public static bool IsClockwiseXZ(Int3 a, Int3 b, Int3 c)
		{
			return RightXZ(a, b, c);
		}

		public static bool IsClockwiseOrColinearXZ(Int3 a, Int3 b, Int3 c)
		{
			return RightOrColinearXZ(a, b, c);
		}

		public static bool IsClockwiseOrColinear(Int2 a, Int2 b, Int2 c)
		{
			return RightOrColinear(a, b, c);
		}

		public static bool IsColinear(Vector3 a, Vector3 b, Vector3 c)
		{
			Vector3 vector = b - a;
			Vector3 vector2 = c - a;
			float num = vector.y * vector2.z - vector.z * vector2.y;
			float num2 = vector.z * vector2.x - vector.x * vector2.z;
			float num3 = vector.x * vector2.y - vector.y * vector2.x;
			float num4 = num * num + num2 * num2 + num3 * num3;
			float num5 = vector.sqrMagnitude * vector2.sqrMagnitude;
			if (!(num4 <= math.sqrt(num5) * 0.0001f))
			{
				return num5 == 0f;
			}
			return true;
		}

		public static bool IsColinear(Vector2 a, Vector2 b, Vector2 c)
		{
			float num = (b.x - a.x) * (c.y - a.y) - (c.x - a.x) * (b.y - a.y);
			if (num <= 0.0001f)
			{
				return num >= -0.0001f;
			}
			return false;
		}

		public static bool IsColinearXZ(Int3 a, Int3 b, Int3 c)
		{
			return (long)(b.x - a.x) * (long)(c.z - a.z) - (long)(c.x - a.x) * (long)(b.z - a.z) == 0;
		}

		public static bool IsColinearXZ(Vector3 a, Vector3 b, Vector3 c)
		{
			float num = (b.x - a.x) * (c.z - a.z) - (c.x - a.x) * (b.z - a.z);
			if (num <= 1E-07f)
			{
				return num >= -1E-07f;
			}
			return false;
		}

		public static bool IsColinearAlmostXZ(Int3 a, Int3 b, Int3 c)
		{
			long num = (long)(b.x - a.x) * (long)(c.z - a.z) - (long)(c.x - a.x) * (long)(b.z - a.z);
			if (num > -1)
			{
				return num < 1;
			}
			return false;
		}

		public static bool SegmentsIntersect(Int2 start1, Int2 end1, Int2 start2, Int2 end2)
		{
			if (RightOrColinear(start1, end1, start2) != RightOrColinear(start1, end1, end2))
			{
				return RightOrColinear(start2, end2, start1) != RightOrColinear(start2, end2, end1);
			}
			return false;
		}

		public static bool SegmentsIntersectXZ(Int3 start1, Int3 end1, Int3 start2, Int3 end2)
		{
			if (RightOrColinearXZ(start1, end1, start2) != RightOrColinearXZ(start1, end1, end2))
			{
				return RightOrColinearXZ(start2, end2, start1) != RightOrColinearXZ(start2, end2, end1);
			}
			return false;
		}

		public static bool SegmentsIntersectXZ(Vector3 start1, Vector3 end1, Vector3 start2, Vector3 end2)
		{
			Vector3 vector = end1 - start1;
			Vector3 vector2 = end2 - start2;
			float num = vector2.z * vector.x - vector2.x * vector.z;
			if (num == 0f)
			{
				return false;
			}
			float num2 = vector2.x * (start1.z - start2.z) - vector2.z * (start1.x - start2.x);
			float num3 = vector.x * (start1.z - start2.z) - vector.z * (start1.x - start2.x);
			float num4 = num2 / num;
			float num5 = num3 / num;
			if (num4 < 0f || num4 > 1f || num5 < 0f || num5 > 1f)
			{
				return false;
			}
			return true;
		}

		public static float2 CapsuleLineIntersectionFactors(float2 capsuleStart, float2 capsuleDir, float capsuleLength, float2 lineStart, float2 lineDir, float radius)
		{
			float num = math.dot(capsuleDir, lineDir);
			float num2 = math.sqrt(1f - num * num);
			float x = float.PositiveInfinity;
			float num3 = float.NegativeInfinity;
			if (LineCircleIntersectionFactors(lineStart - capsuleStart, lineDir, radius, out var t, out var t2))
			{
				x = math.min(x, t);
				num3 = math.max(num3, t2);
			}
			if (LineCircleIntersectionFactors(lineStart - (capsuleStart + capsuleDir * capsuleLength), lineDir, radius, out var t3, out var t4))
			{
				x = math.min(x, t3);
				num3 = math.max(num3, t4);
			}
			if (LineLineIntersectionFactor(capsuleStart, capsuleDir, lineStart, lineDir, out var t5))
			{
				float2 float5 = new float2(0f - capsuleDir.y, capsuleDir.x);
				float num4 = radius * num / num2;
				float num5 = math.sign(capsuleDir.y * lineDir.x - capsuleDir.x * lineDir.y);
				float num6 = t5 + num4 * num5;
				float num7 = t5 - num4 * num5;
				if (num6 >= 0f && num6 <= capsuleLength)
				{
					float y = math.dot(capsuleStart + capsuleDir * num6 - float5 * radius - lineStart, lineDir);
					x = math.min(x, y);
					num3 = math.max(num3, y);
				}
				if (num7 >= 0f && num7 <= capsuleLength)
				{
					float y2 = math.dot(capsuleStart + capsuleDir * num7 + float5 * radius - lineStart, lineDir);
					x = math.min(x, y2);
					num3 = math.max(num3, y2);
				}
			}
			return new float2(x, num3);
		}

		public static bool LineLineIntersectionFactor(float2 start1, float2 dir1, float2 start2, float2 dir2, out float t)
		{
			float num = dir2.y * dir1.x - dir2.x * dir1.y;
			if (math.abs(num) < 0.0001f)
			{
				t = 0f;
				return false;
			}
			float num2 = dir2.x * (start1.y - start2.y) - dir2.y * (start1.x - start2.x);
			t = num2 / num;
			return true;
		}

		public static bool LineLineIntersectionFactors(float2 start1, float2 dir1, float2 start2, float2 dir2, out float factor1, out float factor2)
		{
			float num = dir2.y * dir1.x - dir2.x * dir1.y;
			if (math.abs(num) < 0.0001f)
			{
				factor1 = (factor2 = 0f);
				return false;
			}
			float num2 = dir2.x * (start1.y - start2.y) - dir2.y * (start1.x - start2.x);
			float num3 = dir1.x * (start1.y - start2.y) - dir1.y * (start1.x - start2.x);
			factor1 = num2 / num;
			factor2 = num3 / num;
			return true;
		}

		public static Vector3 LineDirIntersectionPointXZ(Vector3 start1, Vector3 dir1, Vector3 start2, Vector3 dir2)
		{
			float num = dir2.z * dir1.x - dir2.x * dir1.z;
			if (num == 0f)
			{
				return start1;
			}
			float num2 = (dir2.x * (start1.z - start2.z) - dir2.z * (start1.x - start2.x)) / num;
			return start1 + dir1 * num2;
		}

		public static Vector3 LineDirIntersectionPointXZ(Vector3 start1, Vector3 dir1, Vector3 start2, Vector3 dir2, out bool intersects)
		{
			float num = dir2.z * dir1.x - dir2.x * dir1.z;
			if (num == 0f)
			{
				intersects = false;
				return start1;
			}
			float num2 = (dir2.x * (start1.z - start2.z) - dir2.z * (start1.x - start2.x)) / num;
			intersects = true;
			return start1 + dir1 * num2;
		}

		public static bool RaySegmentIntersectXZ(Int3 start1, Int3 end1, Int3 start2, Int3 end2)
		{
			Int3 int5 = end1 - start1;
			Int3 int6 = end2 - start2;
			long num = int6.z * int5.x - int6.x * int5.z;
			if (num == 0L)
			{
				return false;
			}
			long num2 = int6.x * (start1.z - start2.z) - int6.z * (start1.x - start2.x);
			long num3 = int5.x * (start1.z - start2.z) - int5.z * (start1.x - start2.x);
			if (!((num2 < 0) ^ (num < 0)))
			{
				return false;
			}
			if (!((num3 < 0) ^ (num < 0)))
			{
				return false;
			}
			if ((num >= 0 && num3 > num) || (num < 0 && num3 <= num))
			{
				return false;
			}
			return true;
		}

		public static bool LineIntersectionFactorXZ(Int3 start1, Int3 end1, Int3 start2, Int3 end2, out float factor1, out float factor2)
		{
			Int3 int5 = end1 - start1;
			Int3 int6 = end2 - start2;
			long num = int6.z * int5.x - int6.x * int5.z;
			if (num == 0L)
			{
				factor1 = 0f;
				factor2 = 0f;
				return false;
			}
			long num2 = int6.x * (start1.z - start2.z) - int6.z * (start1.x - start2.x);
			long num3 = int5.x * (start1.z - start2.z) - int5.z * (start1.x - start2.x);
			factor1 = (float)num2 / (float)num;
			factor2 = (float)num3 / (float)num;
			return true;
		}

		public static bool LineIntersectionFactorXZ(Vector3 start1, Vector3 end1, Vector3 start2, Vector3 end2, out float factor1, out float factor2)
		{
			Vector3 vector = end1 - start1;
			Vector3 vector2 = end2 - start2;
			float num = vector2.z * vector.x - vector2.x * vector.z;
			if (num <= 1E-05f && num >= -1E-05f)
			{
				factor1 = 0f;
				factor2 = 0f;
				return false;
			}
			float num2 = vector2.x * (start1.z - start2.z) - vector2.z * (start1.x - start2.x);
			float num3 = vector.x * (start1.z - start2.z) - vector.z * (start1.x - start2.x);
			float num4 = num2 / num;
			float num5 = num3 / num;
			factor1 = num4;
			factor2 = num5;
			return true;
		}

		public static float LineRayIntersectionFactorXZ(Int3 start1, Int3 end1, Int3 start2, Int3 end2)
		{
			Int3 int5 = end1 - start1;
			Int3 int6 = end2 - start2;
			int num = int6.z * int5.x - int6.x * int5.z;
			if (num == 0)
			{
				return float.NaN;
			}
			int num2 = int6.x * (start1.z - start2.z) - int6.z * (start1.x - start2.x);
			if ((float)(int5.x * (start1.z - start2.z) - int5.z * (start1.x - start2.x)) / (float)num < 0f)
			{
				return float.NaN;
			}
			return (float)num2 / (float)num;
		}

		public static float LineIntersectionFactorXZ(Vector3 start1, Vector3 end1, Vector3 start2, Vector3 end2)
		{
			Vector3 vector = end1 - start1;
			Vector3 vector2 = end2 - start2;
			float num = vector2.z * vector.x - vector2.x * vector.z;
			if (num == 0f)
			{
				return -1f;
			}
			return (vector2.x * (start1.z - start2.z) - vector2.z * (start1.x - start2.x)) / num;
		}

		public static Vector3 LineIntersectionPointXZ(Vector3 start1, Vector3 end1, Vector3 start2, Vector3 end2)
		{
			bool intersects;
			return LineIntersectionPointXZ(start1, end1, start2, end2, out intersects);
		}

		public static Vector3 LineIntersectionPointXZ(Vector3 start1, Vector3 end1, Vector3 start2, Vector3 end2, out bool intersects)
		{
			Vector3 vector = end1 - start1;
			Vector3 vector2 = end2 - start2;
			float num = vector2.z * vector.x - vector2.x * vector.z;
			if (num == 0f)
			{
				intersects = false;
				return start1;
			}
			float num2 = (vector2.x * (start1.z - start2.z) - vector2.z * (start1.x - start2.x)) / num;
			intersects = true;
			return start1 + vector * num2;
		}

		public static Vector2 LineIntersectionPoint(Vector2 start1, Vector2 end1, Vector2 start2, Vector2 end2)
		{
			bool intersects;
			return LineIntersectionPoint(start1, end1, start2, end2, out intersects);
		}

		public static Vector2 LineIntersectionPoint(Vector2 start1, Vector2 end1, Vector2 start2, Vector2 end2, out bool intersects)
		{
			Vector2 vector = end1 - start1;
			Vector2 vector2 = end2 - start2;
			float num = vector2.y * vector.x - vector2.x * vector.y;
			if (num == 0f)
			{
				intersects = false;
				return start1;
			}
			float num2 = (vector2.x * (start1.y - start2.y) - vector2.y * (start1.x - start2.x)) / num;
			intersects = true;
			return start1 + vector * num2;
		}

		public static Vector3 SegmentIntersectionPointXZ(Vector3 start1, Vector3 end1, Vector3 start2, Vector3 end2, out bool intersects)
		{
			Vector3 vector = end1 - start1;
			Vector3 vector2 = end2 - start2;
			float num = vector2.z * vector.x - vector2.x * vector.z;
			if (num == 0f)
			{
				intersects = false;
				return start1;
			}
			float num2 = vector2.x * (start1.z - start2.z) - vector2.z * (start1.x - start2.x);
			float num3 = vector.x * (start1.z - start2.z) - vector.z * (start1.x - start2.x);
			float num4 = num2 / num;
			float num5 = num3 / num;
			if (num4 < 0f || num4 > 1f || num5 < 0f || num5 > 1f)
			{
				intersects = false;
				return start1;
			}
			intersects = true;
			return start1 + vector * num4;
		}

		public static bool SegmentIntersectsBounds(Bounds bounds, Vector3 a, Vector3 b)
		{
			a -= bounds.center;
			b -= bounds.center;
			Vector3 vector = (a + b) * 0.5f;
			Vector3 vector2 = a - vector;
			Vector3 vector3 = new Vector3(Math.Abs(vector2.x), Math.Abs(vector2.y), Math.Abs(vector2.z));
			Vector3 extents = bounds.extents;
			if (Math.Abs(vector.x) > extents.x + vector3.x)
			{
				return false;
			}
			if (Math.Abs(vector.y) > extents.y + vector3.y)
			{
				return false;
			}
			if (Math.Abs(vector.z) > extents.z + vector3.z)
			{
				return false;
			}
			if (Math.Abs(vector.y * vector2.z - vector.z * vector2.y) > extents.y * vector3.z + extents.z * vector3.y)
			{
				return false;
			}
			if (Math.Abs(vector.x * vector2.z - vector.z * vector2.x) > extents.x * vector3.z + extents.z * vector3.x)
			{
				return false;
			}
			if (Math.Abs(vector.x * vector2.y - vector.y * vector2.x) > extents.x * vector3.y + extents.y * vector3.x)
			{
				return false;
			}
			return true;
		}

		public static bool LineCircleIntersectionFactors(float2 point, float2 direction, float radius, out float t1, out float t2)
		{
			float num = math.dot(point, direction);
			float num2 = math.lengthsq(point) - num * num;
			float num3 = radius * radius - num2;
			if (num3 < 0f)
			{
				t1 = float.PositiveInfinity;
				t2 = float.NegativeInfinity;
				return false;
			}
			float num4 = math.sqrt(num3);
			t1 = 0f - num - num4;
			t2 = 0f - num + num4;
			return true;
		}

		public static bool SegmentCircleIntersectionFactors(float2 point1, float2 point2, float radiusSq, out float t1, out float t2)
		{
			float2 float5 = point2 - point1;
			float num = math.lengthsq(float5);
			float num2 = math.dot(point1, float5) / num;
			float num3 = math.lengthsq(point1) / num - num2 * num2;
			float num4 = radiusSq / num - num3;
			if (num4 < 0f)
			{
				t1 = float.PositiveInfinity;
				t2 = float.NegativeInfinity;
				return false;
			}
			float num5 = math.sqrt(num4);
			t1 = 0f - num2 - num5;
			t2 = 0f - num2 + num5;
			t1 = math.max(0f, t1);
			t2 = math.min(1f, t2);
			if (t1 >= 1f || t2 <= 0f)
			{
				return false;
			}
			return true;
		}

		public static float LineCircleIntersectionFactor(Vector3 circleCenter, Vector3 linePoint1, Vector3 linePoint2, float radius)
		{
			float magnitude;
			Vector3 rhs = Normalize(linePoint2 - linePoint1, out magnitude);
			Vector3 lhs = linePoint1 - circleCenter;
			float num = Vector3.Dot(lhs, rhs);
			float num2 = num * num - (lhs.sqrMagnitude - radius * radius);
			if (num2 < 0f)
			{
				num2 = 0f;
			}
			float num3 = 0f - num + Mathf.Sqrt(num2);
			if (!(magnitude > 1E-05f))
			{
				return 1f;
			}
			return num3 / magnitude;
		}

		public static bool ReversesFaceOrientations(Matrix4x4 matrix)
		{
			Vector3 lhs = matrix.MultiplyVector(new Vector3(1f, 0f, 0f));
			Vector3 rhs = matrix.MultiplyVector(new Vector3(0f, 1f, 0f));
			return Vector3.Dot(rhs: matrix.MultiplyVector(new Vector3(0f, 0f, 1f)), lhs: Vector3.Cross(lhs, rhs)) < 0f;
		}

		public static Vector3 Normalize(Vector3 v, out float magnitude)
		{
			magnitude = v.magnitude;
			if (magnitude > 1E-05f)
			{
				return v / magnitude;
			}
			return Vector3.zero;
		}

		public static Vector2 Normalize(Vector2 v, out float magnitude)
		{
			magnitude = v.magnitude;
			if (magnitude > 1E-05f)
			{
				return v / magnitude;
			}
			return Vector2.zero;
		}

		public static Vector3 ClampMagnitudeXZ(Vector3 v, float maxMagnitude)
		{
			float num = v.x * v.x + v.z * v.z;
			if (num > maxMagnitude * maxMagnitude && maxMagnitude > 0f)
			{
				float num2 = maxMagnitude / Mathf.Sqrt(num);
				v.x *= num2;
				v.z *= num2;
			}
			return v;
		}

		public static float MagnitudeXZ(Vector3 v)
		{
			return Mathf.Sqrt(v.x * v.x + v.z * v.z);
		}

		public static float QuaternionAngle(quaternion rot)
		{
			return 2f * math.atan2(math.length(rot.value.xyz), rot.value.w);
		}
	}
}
