using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Pathfinding
{
	[BurstCompile]
	internal static class NavmeshCutJobs
	{
		public struct JobCalculateContour
		{
			public unsafe UnsafeList<float2>* outputVertices;

			public unsafe UnsafeList<NavmeshCut.ContourBurst>* outputContours;

			public unsafe UnsafeList<NavmeshCut.ContourBurst>* meshContours;

			public unsafe UnsafeList<float3>* meshContourVertices;

			public float4x4 matrix;

			public float4x4 localToWorldMatrix;

			public float radiusMargin;

			public int circleResolution;

			public float circleRadius;

			public float2 rectangleSize;

			public float height;

			public float meshScale;

			public NavmeshCut.MeshType meshType;

			public void Execute()
			{
			}

			private unsafe void WindCounterClockwise(UnsafeList<float2>* vertices, int startIndex, int endIndex)
			{
			}
		}

		private struct AngleComparator : IComparer<float2>
		{
			public float2 origin;

			public int Compare(float2 lhs, float2 rhs)
			{
				return 0;
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void CalculateContour_00000A09_0024PostfixBurstDelegate(ref JobCalculateContour job);

		internal static class CalculateContour_00000A09_0024BurstDirectCall
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

			public static void Invoke(ref JobCalculateContour job)
			{
			}
		}

		private static readonly float4[] BoxCorners;

		[BurstCompile(FloatPrecision.Standard, FloatMode.Fast)]
		[MonoPInvokeCallback(typeof(CalculateContour_00000A09_0024PostfixBurstDelegate))]
		public static void CalculateContour(ref JobCalculateContour job)
		{
		}

		private static float ApproximateCircleWithPolylineRadius(float radius, int resolution)
		{
			return 0f;
		}

		public unsafe static void CapsuleConvexHullXZ(float4x4 matrix, UnsafeList<float2>* points, float height, float radius, float radiusMargin, int circleResolution, out int numPoints, out float minY, out float maxY)
		{
			numPoints = default(int);
			minY = default(float);
			maxY = default(float);
		}

		public unsafe static void BoxConvexHullXZ(float4x4 matrix, UnsafeList<float2>* points, out int numPoints, out float minY, out float maxY)
		{
			numPoints = default(int);
			minY = default(float);
			maxY = default(float);
		}

		public unsafe static int ConvexHull(float2* points, int nPoints, float vertexMergeDistance)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile(FloatPrecision.Standard, FloatMode.Fast)]
		public static void CalculateContour_0024BurstManaged(ref JobCalculateContour job)
		{
		}
	}
}
