using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

namespace MagicaCloth2
{
	public static class MathUtility
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsNaN(float3 v)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsNaN(float4 v)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsNaN(quaternion q)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsZeroDistance(float3 v)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Clamp1(float a)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 Project(in float3 v, in float3 n)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 ProjectOnPlane(in float3 v, in float3 n)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Angle(in float3 v1, in float3 v2)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 ClampVector(float3 v, float minlength, float maxlength)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 ClampVector(float3 v, float maxlength)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 ClampDistance(float3 from, float3 to, float maxlength)
		{
			return default(float3);
		}

		public static bool ClampAngle(in float3 dir, in float3 basedir, float maxAngle, out float3 outdir)
		{
			outdir = default(float3);
			return false;
		}

		public static quaternion FromToRotation(in float3 from, in float3 to, float t = 1f)
		{
			return default(quaternion);
		}

		public static quaternion FromToRotationWithoutNormalize(in float3 v1, in float3 v2, float t = 1f)
		{
			return default(quaternion);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quaternion FromToRotation(in quaternion from, in quaternion to)
		{
			return default(quaternion);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Angle(in quaternion a, in quaternion b)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quaternion ClampAngle(quaternion from, quaternion to, float maxAngle)
		{
			return default(quaternion);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quaternion ToRotation(in float3 nor, in float3 tan)
		{
			return default(quaternion);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ToNormalTangent(in quaternion rot, out float3 nor, out float3 tan)
		{
			nor = default(float3);
			tan = default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 ToNormal(in quaternion rot)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 ToTangent(in quaternion rot)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 ToBinormal(in quaternion rot)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 Binormal(in float3 nor, in float3 tan)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 AxisToEuler(in float3 axis)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quaternion AxisQuaternion(float3 dir)
		{
			return default(quaternion);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ToAngleAxis(in quaternion q, out float angle, out float3 axis)
		{
			angle = default(float);
			axis = default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 ToEuler(in quaternion q)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float ClosestPtPointSegmentRatio(in float3 c, in float3 a, in float3 b)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float ClosestPtPointSegmentRatioNoClamp(float3 c, float3 a, float3 b)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 ClosestPtPointSegment(float3 c, float3 a, float3 b)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 ClosestPtPointSegmentNoClamp(float3 c, float3 a, float3 b)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float ClosestPtSegmentSegment(in float3 p1, in float3 q1, in float3 p2, in float3 q2, out float s, out float t, out float3 c1, out float3 c2)
		{
			s = default(float);
			t = default(float);
			c1 = default(float3);
			c2 = default(float3);
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ClosestPtSegmentSegment2(in float3 p1, in float3 q1, in float3 p2, in float3 q2, out float s, out float t)
		{
			s = default(float);
			t = default(float);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 ClosestPtPointTriangle(in float3 p, in float3 a, in float3 b, in float3 c, out float3 uvw)
		{
			uvw = default(float3);
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool PointInTriangleUVW(float3 uvw)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 TriangleCenter(in float3 p0, in float3 p1, in float3 p2)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 TriangleNormal(in float3 p0, in float3 p1, in float3 p2)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float TriangleArea(in float3 p0, in float3 p1, in float3 p2)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsSafeTriangle(in float3 p0, in float3 p1, in float3 p2)
		{
			return false;
		}

		public static float3 TriangleTangent(in float3 p0, in float3 p1, in float3 p2, in float2 uv0, in float2 uv1, in float2 uv2)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float TriangleAngle(in float3 v0, in float3 v1, in float3 v2, in float3 v3)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float DistanceTriangleCenter(float3 p, float3 p0, float3 p1, float3 p2)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float DirectionPointTriangle(float3 p, float3 a, float3 b, float3 c)
		{
			return 0f;
		}

		public static int2 GetRestTriangleVertex(int3 tri1, int3 tri2, int2 edge)
		{
			return default(int2);
		}

		public static int2 GetCommonEdgeFromTrianglePair(int3 tri1, int3 tri2)
		{
			return default(int2);
		}

		public static int4 GetTrianglePairIndices(int3 tri1, int3 tri2)
		{
			return default(int4);
		}

		public static int GetUnuseTriangleIndex(int3 tri, int2 edge)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float GetTrianglePairAngle(float3 pos0, float3 pos1, float3 pos2, float3 pos3)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 FlipTriangle(in int3 tri)
		{
			return default(int3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void GetTriangleSphere(float3 pos0, float3 pos1, float3 pos2, out float3 sc, out float sr)
		{
			sc = default(float3);
			sr = default(float);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 LocalToWorldMatrix(in float3 wpos, in quaternion wrot, in float3 wscl)
		{
			return default(float4x4);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 WorldToLocalMatrix(in float3 wpos, in quaternion wrot, in float3 wscl)
		{
			return default(float4x4);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 TransformPoint(in float3 pos, in float3 wpos, in quaternion wrot, in float3 wscl)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 TransformPoint(in float3 pos, in float4x4 m)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 TransformVector(in float3 vec, in float4x4 m)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 TransformDirection(in float3 dir, in float4x4 m)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 TransformNormal(in float3 dir, in float4x4 m, float3 errDir)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quaternion TransformRotation(in quaternion rot, in float4x4 m, in float3 normalTangentFlip)
		{
			return default(quaternion);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float TransformDistance(in float dist, in float4x4 localToWorldMatrix)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TransformPositionNormalTangent(in float3 tpos, in quaternion trot, in float3 tscl, ref float3 pos, ref float3 nor, ref float3 tan)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float TransformLength(float length, in float4x4 matrix)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 InverseTransformPoint(in float3 pos, in float4x4 worldToLocalMatrix)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 InverseTransformPoint(in float3 pos, in float3 wpos, in quaternion wrot, in float3 wscl)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 InverseTransformVector(in float3 vec, in float4x4 worldToLocalMatrix)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 InverseTransformVector(in float3 vec, in quaternion rot)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 InverseTransformDirection(in float3 dir, in float4x4 worldToLocalMatrix)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4x4 Transform(in float4x4 fromLocalToWorldMatrix, in float4x4 toWorldToLocalMatrix)
		{
			return default(float4x4);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool CompareMatrix(in float4x4 m1, in float4x4 m2)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool CompareTransform(in float3 pos1, in quaternion rot1, in float3 scl1, in float3 pos2, in quaternion rot2, in float3 scl2)
		{
			return false;
		}

		public static bool IntersectSegmentTriangle(in float3 p, in float3 q, float3 a, float3 b, float3 c, bool doubleSide, out float u, out float v, out float w, out float t)
		{
			u = default(float);
			v = default(float);
			w = default(float);
			t = default(float);
			return false;
		}

		public static bool IntersectSegmentTriangle(in float3 p, in float3 q, float3 a, float3 b, float3 c)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float IntersectPointPlaneDist(in float3 planePos, in float3 planeDir, in float3 pos, out float3 outPos)
		{
			outPos = default(float3);
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IntersectRaySphere(in float3 p, in float3 d, in float3 sc, in float sr, ref float t, ref float3 q)
		{
			return false;
		}

		public static float SqDistPointSegment(Vector3 a, Vector3 b, Vector3 c)
		{
			return 0f;
		}

		public static float3 ShiftPosition(in float3 oldPos, in float3 oldPivotPosition, in float3 shiftVector, in quaternion shiftRotation)
		{
			return default(float3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float CalcMass(float depth)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float CalcInverseMass(float friction)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float CalcInverseMass(float friction, float depth)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float CalcInverseMass(float friction, float depth, bool fix, float fixMass)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float CalcSelfCollisionInverseMass(float friction, bool fix, float clothMass)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 CalcSplitRange(int dataLength, int divCount, int divIndex)
		{
			return default(int2);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static DataChunk GetWorkerChunk(int dataLenght, int workerCount, int workerIndex)
		{
			return default(DataChunk);
		}
	}
}
