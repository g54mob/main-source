using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pathfinding.Collections;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding
{
	[BurstCompile]
	public static class Polygon
	{
		public struct BarycentricTriangleInterpolator
		{
			private int2 origin;

			private double2x2 barycentricMapping;

			private double3 thresholds;

			private double3 linear1;

			private double3 linear2;

			private double3 linear3;

			private double3 ys;

			public BarycentricTriangleInterpolator(Int3 p1, Int3 p2, Int3 p3)
			{
				origin = default(int2);
				barycentricMapping = default(double2x2);
				thresholds = default(double3);
				linear1 = default(double3);
				linear2 = default(double3);
				linear3 = default(double3);
				ys = default(double3);
			}

			public int SampleY(int2 p)
			{
				return 0;
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate bool ContainsPoint_000002DD_0024PostfixBurstDelegate(ref int3 aWorld, ref int3 bWorld, ref int3 cWorld, ref int3 pWorld, ref NativeMovementPlane movementPlane);

		internal static class ContainsPoint_000002DD_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
			}

			private static IntPtr GetFunctionPointer()
			{
				return (IntPtr)0;
			}

			public static bool Invoke(ref int3 aWorld, ref int3 bWorld, ref int3 cWorld, ref int3 pWorld, ref NativeMovementPlane movementPlane)
			{
				return false;
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate bool ClosestPointOnTriangleByRef_000002E3_0024PostfixBurstDelegate(in float3 a, in float3 b, in float3 c, in float3 p, [NoAlias] out float3 output);

		internal static class ClosestPointOnTriangleByRef_000002E3_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
			}

			private static IntPtr GetFunctionPointer()
			{
				return (IntPtr)0;
			}

			public static bool Invoke(in float3 a, in float3 b, in float3 c, in float3 p, [NoAlias] out float3 output)
			{
				output = default(float3);
				return false;
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void ClosestPointOnTriangleProjected_000002E6_0024PostfixBurstDelegate(ref Int3 vi1, ref Int3 vi2, ref Int3 vi3, ref BBTree.ProjectionParams projection, ref float3 point, [NoAlias] out float3 closest, [NoAlias] out float sqrDist, [NoAlias] out float distAlongProjection);

		internal static class ClosestPointOnTriangleProjected_000002E6_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
			}

			private static IntPtr GetFunctionPointer()
			{
				return (IntPtr)0;
			}

			public static void Invoke(ref Int3 vi1, ref Int3 vi2, ref Int3 vi3, ref BBTree.ProjectionParams projection, ref float3 point, [NoAlias] out float3 closest, [NoAlias] out float sqrDist, [NoAlias] out float distAlongProjection)
			{
				closest = default(float3);
				sqrDist = default(float);
				distAlongProjection = default(float);
			}
		}

		private static readonly Dictionary<Int3, int> cached_Int3_int_dict;

		public static bool ContainsPointXZ(Vector3 a, Vector3 b, Vector3 c, Vector3 p)
		{
			return false;
		}

		public static bool ContainsPointXZ(Int3 a, Int3 b, Int3 c, Int3 p)
		{
			return false;
		}

		public static bool ContainsPoint(Vector2Int a, Vector2Int b, Vector2Int c, Vector2Int p)
		{
			return false;
		}

		public static bool ContainsPoint(Vector2[] polyPoints, Vector2 p)
		{
			return false;
		}

		public static bool ContainsPointXZ(Vector3[] polyPoints, Vector3 p)
		{
			return false;
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(ContainsPoint_000002DD_0024PostfixBurstDelegate))]
		public static bool ContainsPoint(ref int3 aWorld, ref int3 bWorld, ref int3 cWorld, ref int3 pWorld, ref NativeMovementPlane movementPlane)
		{
			return false;
		}

		public static bool ContainsPoint(ref int3 aWorld, ref int3 bWorld, ref int3 cWorld, ref int3 pWorld, in float2x3 planeProjection)
		{
			return false;
		}

		public static Vector3[] ConvexHullXZ(Vector3[] points)
		{
			return null;
		}

		public static Vector2 ClosestPointOnTriangle(Vector2 a, Vector2 b, Vector2 c, Vector2 p)
		{
			return default(Vector2);
		}

		public static Vector3 ClosestPointOnTriangleXZ(Vector3 a, Vector3 b, Vector3 c, Vector3 p)
		{
			return default(Vector3);
		}

		public static float3 ClosestPointOnTriangle(float3 a, float3 b, float3 c, float3 p)
		{
			return default(float3);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(ClosestPointOnTriangleByRef_000002E3_0024PostfixBurstDelegate))]
		public static bool ClosestPointOnTriangleByRef(in float3 a, in float3 b, in float3 c, in float3 p, [NoAlias] out float3 output)
		{
			output = default(float3);
			return false;
		}

		public static float3 ClosestPointOnTriangleBarycentric(float2 a, float2 b, float2 c, float2 p)
		{
			return default(float3);
		}

		public static float3 ClosestPointOnTriangleBarycentric(float3 a, float3 b, float3 c, float3 p)
		{
			return default(float3);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(ClosestPointOnTriangleProjected_000002E6_0024PostfixBurstDelegate))]
		public static void ClosestPointOnTriangleProjected(ref Int3 vi1, ref Int3 vi2, ref Int3 vi3, ref BBTree.ProjectionParams projection, ref float3 point, [NoAlias] out float3 closest, [NoAlias] out float sqrDist, [NoAlias] out float distAlongProjection)
		{
			closest = default(float3);
			sqrDist = default(float);
			distAlongProjection = default(float);
		}

		public static void CompressMesh(List<Int3> vertices, List<int> triangles, List<uint> tags, out Int3[] outVertices, out int[] outTriangles, out uint[] outTags)
		{
			outVertices = null;
			outTriangles = null;
			outTags = null;
		}

		public static void TraceContours(Dictionary<int, int> outline, HashSet<int> hasInEdge, Action<List<int>, bool> results)
		{
		}

		public static void Subdivide(List<Vector3> points, List<Vector3> result, int subSegments)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static bool ContainsPoint_0024BurstManaged(ref int3 aWorld, ref int3 bWorld, ref int3 cWorld, ref int3 pWorld, ref NativeMovementPlane movementPlane)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static bool ClosestPointOnTriangleByRef_0024BurstManaged(in float3 a, in float3 b, in float3 c, in float3 p, [NoAlias] out float3 output)
		{
			output = default(float3);
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void ClosestPointOnTriangleProjected_0024BurstManaged(ref Int3 vi1, ref Int3 vi2, ref Int3 vi3, ref BBTree.ProjectionParams projection, ref float3 point, [NoAlias] out float3 closest, [NoAlias] out float sqrDist, [NoAlias] out float distAlongProjection)
		{
			closest = default(float3);
			sqrDist = default(float);
			distAlongProjection = default(float);
		}
	}
}
