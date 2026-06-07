using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pathfinding.Collections;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Util
{
	[BurstCompile]
	internal static class MeshUtility
	{
		[BurstCompile]
		public struct JobMergeNearbyVertices : IJob
		{
			private struct CoordinateSorter : IComparer<int>
			{
				public UnsafeSpan<int3> vertices;

				public int Compare(int a, int b)
				{
					return 0;
				}
			}

			public NativeList<Int3> vertices;

			public NativeList<int> triangles;

			public int mergeRadiusSq;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		public struct JobRemoveDegenerateTriangles : IJob
		{
			public NativeList<Int3> vertices;

			public NativeList<int> triangles;

			public NativeList<int> tags;

			public bool verbose;

			public static int3 cross(int3 lhs, int3 rhs)
			{
				return default(int3);
			}

			public void Execute()
			{
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void MakeTrianglesClockwise_0000101E_0024PostfixBurstDelegate(ref UnsafeSpan<Int3> vertices, ref UnsafeSpan<int> triangles);

		internal static class MakeTrianglesClockwise_0000101E_0024BurstDirectCall
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

			public static void Invoke(ref UnsafeSpan<Int3> vertices, ref UnsafeSpan<int> triangles)
			{
			}
		}

		public static void GetMeshData(Mesh.MeshDataArray meshData, int meshIndex, out NativeArray<Vector3> vertices, out NativeArray<int> indices)
		{
			vertices = default(NativeArray<Vector3>);
			indices = default(NativeArray<int>);
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(MakeTrianglesClockwise_0000101E_0024PostfixBurstDelegate))]
		public static void MakeTrianglesClockwise(ref UnsafeSpan<Int3> vertices, ref UnsafeSpan<int> triangles)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static void MakeTrianglesClockwise_0024BurstManaged(ref UnsafeSpan<Int3> vertices, ref UnsafeSpan<int> triangles)
		{
		}
	}
}
