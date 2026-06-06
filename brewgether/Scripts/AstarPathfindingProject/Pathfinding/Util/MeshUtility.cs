using System;
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
		public struct JobRemoveDuplicateVertices : IJob
		{
			public NativeList<Int3> vertices;

			public NativeList<int> triangles;

			public NativeList<int> tags;

			public static int3 cross(int3 x, int3 y)
			{
				return default(int3);
			}

			public void Execute()
			{
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void MakeTrianglesClockwise_00000EAF_0024PostfixBurstDelegate(ref UnsafeSpan<Int3> vertices, ref UnsafeSpan<int> triangles);

		internal static class MakeTrianglesClockwise_00000EAF_0024BurstDirectCall
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
		[MonoPInvokeCallback(typeof(MakeTrianglesClockwise_00000EAF_0024PostfixBurstDelegate))]
		public static void MakeTrianglesClockwise(ref UnsafeSpan<Int3> vertices, ref UnsafeSpan<int> triangles)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void MakeTrianglesClockwise_0024BurstManaged(ref UnsafeSpan<Int3> vertices, ref UnsafeSpan<int> triangles)
		{
		}
	}
}
