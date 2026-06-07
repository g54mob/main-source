using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pathfinding.Collections;
using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh
{
	[BurstCompile]
	internal static class ColliderMeshBuilder2D
	{
		public struct ShapeMesh
		{
			public Matrix4x4 matrix;

			public Bounds bounds;

			public int startIndex;

			public int endIndex;

			public int tag;
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int GenerateMeshesFromShapes_00000BE6_0024PostfixBurstDelegate(ref UnsafeSpan<PhysicsShape2D> shapes, ref UnsafeSpan<float2> vertices, ref UnsafeSpan<Matrix4x4> shapeMatrices, ref UnsafeSpan<int> groupIndices, ref UnsafeList<float3> outputVertices, ref UnsafeList<int3> outputIndices, ref UnsafeSpan<ShapeMesh> outputShapeMeshes, float maxError);

		internal static class GenerateMeshesFromShapes_00000BE6_0024BurstDirectCall
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

			public static int Invoke(ref UnsafeSpan<PhysicsShape2D> shapes, ref UnsafeSpan<float2> vertices, ref UnsafeSpan<Matrix4x4> shapeMatrices, ref UnsafeSpan<int> groupIndices, ref UnsafeList<float3> outputVertices, ref UnsafeList<int3> outputIndices, ref UnsafeSpan<ShapeMesh> outputShapeMeshes, float maxError)
			{
				return 0;
			}
		}

		private static int GetShapes(Collider2D coll, PhysicsShapeGroup2D group, HashSet<Rigidbody2D> handledRigidbodies)
		{
			return 0;
		}

		public static int GenerateMeshesFromColliders(Collider2D[] colliders, int numColliders, float maxError, out UnsafeSpan<float3> outputVertices, out UnsafeSpan<int> outputIndices, out UnsafeSpan<ShapeMesh> outputShapeMeshes)
		{
			outputVertices = default(UnsafeSpan<float3>);
			outputIndices = default(UnsafeSpan<int>);
			outputShapeMeshes = default(UnsafeSpan<ShapeMesh>);
			return 0;
		}

		private static void AddCapsuleMesh(float2 c1, float2 c2, ref Matrix4x4 shapeMatrix, float radius, float maxError, ref UnsafeList<float3> outputVertices, ref UnsafeList<int3> outputIndices, ref float3 mn, ref float3 mx)
		{
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(GenerateMeshesFromShapes_00000BE6_0024PostfixBurstDelegate))]
		public static int GenerateMeshesFromShapes(ref UnsafeSpan<PhysicsShape2D> shapes, ref UnsafeSpan<float2> vertices, ref UnsafeSpan<Matrix4x4> shapeMatrices, ref UnsafeSpan<int> groupIndices, ref UnsafeList<float3> outputVertices, ref UnsafeList<int3> outputIndices, ref UnsafeSpan<ShapeMesh> outputShapeMeshes, float maxError)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static int GenerateMeshesFromShapes_0024BurstManaged(ref UnsafeSpan<PhysicsShape2D> shapes, ref UnsafeSpan<float2> vertices, ref UnsafeSpan<Matrix4x4> shapeMatrices, ref UnsafeSpan<int> groupIndices, ref UnsafeList<float3> outputVertices, ref UnsafeList<int3> outputIndices, ref UnsafeSpan<ShapeMesh> outputShapeMeshes, float maxError)
		{
			return 0;
		}
	}
}
