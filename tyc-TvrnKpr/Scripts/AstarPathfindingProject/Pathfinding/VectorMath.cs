using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding
{
	public static class VectorMath
	{
		public static Vector2 ComplexMultiply(Vector2 a, Vector2 b)
		{
			return default(Vector2);
		}

		public static float2 ComplexMultiply(float2 a, float2 b)
		{
			return default(float2);
		}

		public static float2 ComplexMultiplyConjugate(float2 a, float2 b)
		{
			return default(float2);
		}

		public static Vector2 ComplexMultiplyConjugate(Vector2 a, Vector2 b)
		{
			return default(Vector2);
		}

		public static Vector3 ClosestPointOnLine(Vector3 lineStart, Vector3 lineEnd, Vector3 point)
		{
			return default(Vector3);
		}

		public static float3 ClosestPointOnLine(float3 lineStart, float3 lineEnd, float3 point)
		{
			return default(float3);
		}

		public static float ClosestPointOnLineFactor(Vector3 lineStart, Vector3 lineEnd, Vector3 point)
		{
			return 0f;
		}

		public static float ClosestPointOnLineFactor(float3 lineStart, float3 lineEnd, float3 point)
		{
			return 0f;
		}

		public static float ClosestPointOnLineFactor(Int3 lineStart, Int3 lineEnd, Int3 point)
		{
			return 0f;
		}

		public static float ClosestPointOnLineFactor(Vector2Int lineStart, Vector2Int lineEnd, Vector2Int point)
		{
			return 0f;
		}

		public static Vector3 ClosestPointOnSegment(Vector3 lineStart, Vector3 lineEnd, Vector3 point)
		{
			return default(Vector3);
		}

		public static Vector3 ClosestPointOnSegmentXZ(Vector3 lineStart, Vector3 lineEnd, Vector3 point)
		{
			return default(Vector3);
		}

		public static float SqrDistancePointSegmentApproximate(int x, int z, int px, int pz, int qx, int qz)
		{
			return 0f;
		}

		public static float SqrDistancePointSegmentApproximate(Int3 a, Int3 b, Int3 p)
		{
			return 0f;
		}

		public static float SqrDistancePointSegment(Vector3 a, Vector3 b, Vector3 p)
		{
			return 0f;
		}

		public static float SqrDistanceSegmentSegment(Vector3 s1, Vector3 e1, Vector3 s2, Vector3 e2)
		{
			return 0f;
		}

		public static float Determinant(float2 c1, float2 c2)
		{
			return 0f;
		}

		public static float SqrDistanceXZ(Vector3 a, Vector3 b)
		{
			return 0f;
		}

		public static long SignedTriangleAreaTimes2(int2 a, int2 b, int2 c)
		{
			return 0L;
		}

		public static long SignedTriangleAreaTimes2XZ(Int3 a, Int3 b, Int3 c)
		{
			return 0L;
		}

		public static float SignedTriangleAreaTimes2XZ(Vector3 a, Vector3 b, Vector3 c)
		{
			return 0f;
		}

		public static bool RightXZ(Vector3 a, Vector3 b, Vector3 p)
		{
			return false;
		}

		public static bool RightXZ(Int3 a, Int3 b, Int3 p)
		{
			return false;
		}

		public static bool Right(int2 a, int2 b, int2 p)
		{
			return false;
		}

		public static Side SideXZ(Int3 a, Int3 b, Int3 p)
		{
			return default(Side);
		}

		public static bool RightOrColinear(Vector2 a, Vector2 b, Vector2 p)
		{
			return false;
		}

		public static bool RightOrColinear(Vector2Int a, Vector2Int b, Vector2Int p)
		{
			return false;
		}

		public static bool RightOrColinearXZ(Vector3 a, Vector3 b, Vector3 p)
		{
			return false;
		}

		public static bool RightOrColinearXZ(Int3 a, Int3 b, Int3 p)
		{
			return false;
		}

		public static bool IsClockwiseMarginXZ(Vector3 a, Vector3 b, Vector3 c)
		{
			return false;
		}

		public static bool IsClockwiseXZ(Vector3 a, Vector3 b, Vector3 c)
		{
			return false;
		}

		public static bool IsClockwiseXZ(Int3 a, Int3 b, Int3 c)
		{
			return false;
		}

		public static bool IsClockwise(int2 a, int2 b, int2 c)
		{
			return false;
		}

		public static bool IsClockwiseOrColinearXZ(Int3 a, Int3 b, Int3 c)
		{
			return false;
		}

		public static bool IsClockwiseOrColinear(Vector2Int a, Vector2Int b, Vector2Int c)
		{
			return false;
		}

		public static bool IsColinear(Vector3 a, Vector3 b, Vector3 c)
		{
			return false;
		}

		public static bool IsColinear(Vector2 a, Vector2 b, Vector2 c)
		{
			return false;
		}

		public static bool IsColinear(int2 a, int2 b, int2 c)
		{
			return false;
		}

		public static bool IsColinearXZ(Int3 a, Int3 b, Int3 c)
		{
			return false;
		}

		public static bool IsColinearXZ(Vector3 a, Vector3 b, Vector3 c)
		{
			return false;
		}

		public static bool IsColinearAlmostXZ(Int3 a, Int3 b, Int3 c)
		{
			return false;
		}

		public static bool SegmentsIntersect(Vector2Int start1, Vector2Int end1, Vector2Int start2, Vector2Int end2)
		{
			return false;
		}

		public static bool SegmentsIntersectXZ(Int3 start1, Int3 end1, Int3 start2, Int3 end2)
		{
			return false;
		}

		public static bool SegmentsIntersectXZ(Vector3 start1, Vector3 end1, Vector3 start2, Vector3 end2)
		{
			return false;
		}

		public static float2 CapsuleLineIntersectionFactors(float2 capsuleStart, float2 capsuleDir, float capsuleLength, float2 lineStart, float2 lineDir, float radius)
		{
			return default(float2);
		}

		public static bool LineLineIntersectionFactor(float2 start1, float2 dir1, float2 start2, float2 dir2, out float t)
		{
			t = default(float);
			return false;
		}

		public static bool LineLineIntersectionFactors(float2 start1, float2 dir1, float2 start2, float2 dir2, out float factor1, out float factor2)
		{
			factor1 = default(float);
			factor2 = default(float);
			return false;
		}

		public static Vector3 LineDirIntersectionPointXZ(Vector3 start1, Vector3 dir1, Vector3 start2, Vector3 dir2)
		{
			return default(Vector3);
		}

		public static Vector3 LineDirIntersectionPointXZ(Vector3 start1, Vector3 dir1, Vector3 start2, Vector3 dir2, out bool intersects)
		{
			intersects = default(bool);
			return default(Vector3);
		}

		public static bool RaySegmentIntersectXZ(Int3 start1, Int3 end1, Int3 start2, Int3 end2)
		{
			return false;
		}

		public static bool LineIntersectionFactorXZ(Int3 start1, Int3 end1, Int3 start2, Int3 end2, out float factor1, out float factor2)
		{
			factor1 = default(float);
			factor2 = default(float);
			return false;
		}

		public static bool LineIntersectionFactorXZ(Vector3 start1, Vector3 end1, Vector3 start2, Vector3 end2, out float factor1, out float factor2)
		{
			factor1 = default(float);
			factor2 = default(float);
			return false;
		}

		public static float LineRayIntersectionFactorXZ(Int3 start1, Int3 end1, Int3 start2, Int3 end2)
		{
			return 0f;
		}

		public static float LineIntersectionFactorXZ(Vector3 start1, Vector3 end1, Vector3 start2, Vector3 end2)
		{
			return 0f;
		}

		public static Vector3 LineIntersectionPointXZ(Vector3 start1, Vector3 end1, Vector3 start2, Vector3 end2)
		{
			return default(Vector3);
		}

		public static Vector3 LineIntersectionPointXZ(Vector3 start1, Vector3 end1, Vector3 start2, Vector3 end2, out bool intersects)
		{
			intersects = default(bool);
			return default(Vector3);
		}

		public static Vector2 LineIntersectionPoint(Vector2 start1, Vector2 end1, Vector2 start2, Vector2 end2)
		{
			return default(Vector2);
		}

		public static Vector2 LineIntersectionPoint(Vector2 start1, Vector2 end1, Vector2 start2, Vector2 end2, out bool intersects)
		{
			intersects = default(bool);
			return default(Vector2);
		}

		public static Vector3 SegmentIntersectionPointXZ(Vector3 start1, Vector3 end1, Vector3 start2, Vector3 end2, out bool intersects)
		{
			intersects = default(bool);
			return default(Vector3);
		}

		public static bool SegmentIntersectsBounds(Bounds bounds, Vector3 a, Vector3 b)
		{
			return false;
		}

		public static bool LineCircleIntersectionFactors(float2 point, float2 direction, float radius, out float t1, out float t2)
		{
			t1 = default(float);
			t2 = default(float);
			return false;
		}

		public static bool SegmentCircleIntersectionFactors(float2 point1, float2 point2, float radiusSq, out float t1, out float t2)
		{
			t1 = default(float);
			t2 = default(float);
			return false;
		}

		public static float LineCircleIntersectionFactor(Vector3 circleCenter, Vector3 linePoint1, Vector3 linePoint2, float radius)
		{
			return 0f;
		}

		public static bool ReversesFaceOrientations(Matrix4x4 matrix)
		{
			return false;
		}

		public static Vector3 Normalize(Vector3 v, out float magnitude)
		{
			magnitude = default(float);
			return default(Vector3);
		}

		public static Vector2 Normalize(Vector2 v, out float magnitude)
		{
			magnitude = default(float);
			return default(Vector2);
		}

		public static Vector3 ClampMagnitudeXZ(Vector3 v, float maxMagnitude)
		{
			return default(Vector3);
		}

		public static float MagnitudeXZ(Vector3 v)
		{
			return 0f;
		}

		public static float QuaternionAngle(quaternion rot)
		{
			return 0f;
		}
	}
}
