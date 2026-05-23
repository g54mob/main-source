using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Pathfinding.Graphs.Navmesh
{
	[BurstCompile]
	public static class ColliderMeshBuilder2D
	{
		public struct ShapeMesh
		{
			public Matrix4x4 matrix;

			public Bounds bounds;

			public int startIndex;

			public int endIndex;

			public int tag;
		}

		public delegate int GenerateMeshesFromShapes_00000AC3_0024PostfixBurstDelegate(ref UnsafeSpan<PhysicsShape2D> shapes, ref UnsafeSpan<float2> vertices, ref UnsafeSpan<Matrix4x4> shapeMatrices, ref UnsafeSpan<int> groupIndices, ref UnsafeList<float3> outputVertices, ref UnsafeList<int3> outputIndices, ref UnsafeSpan<ShapeMesh> outputShapeMeshes, float maxError);

		internal static class GenerateMeshesFromShapes_00000AC3_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			private static IntPtr DeferredCompilation;

			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = (nint)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(GenerateMeshesFromShapes_00000AC3_0024PostfixBurstDelegate).TypeHandle);
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public static void Constructor()
			{
				DeferredCompilation = BurstCompiler.CompileILPPMethod2((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/);
			}

			public static void Initialize()
			{
			}

			static GenerateMeshesFromShapes_00000AC3_0024BurstDirectCall()
			{
				Constructor();
			}

			public unsafe static int Invoke(ref UnsafeSpan<PhysicsShape2D> shapes, ref UnsafeSpan<float2> vertices, ref UnsafeSpan<Matrix4x4> shapeMatrices, ref UnsafeSpan<int> groupIndices, ref UnsafeList<float3> outputVertices, ref UnsafeList<int3> outputIndices, ref UnsafeSpan<ShapeMesh> outputShapeMeshes, float maxError)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<ref UnsafeSpan<PhysicsShape2D>, ref UnsafeSpan<float2>, ref UnsafeSpan<Matrix4x4>, ref UnsafeSpan<int>, ref UnsafeList<float3>, ref UnsafeList<int3>, ref UnsafeSpan<ShapeMesh>, float, int>)functionPointer)(ref shapes, ref vertices, ref shapeMatrices, ref groupIndices, ref outputVertices, ref outputIndices, ref outputShapeMeshes, maxError);
					}
				}
				return GenerateMeshesFromShapes_0024BurstManaged(ref shapes, ref vertices, ref shapeMatrices, ref groupIndices, ref outputVertices, ref outputIndices, ref outputShapeMeshes, maxError);
			}
		}

		private static int GetShapes(Collider2D coll, PhysicsShapeGroup2D group, HashSet<Rigidbody2D> handledRigidbodies)
		{
			Rigidbody2D attachedRigidbody = coll.attachedRigidbody;
			if (attachedRigidbody != null)
			{
				if (handledRigidbodies.Add(attachedRigidbody))
				{
					return attachedRigidbody.GetShapes(group);
				}
				return 0;
			}
			if (coll is TilemapCollider2D tilemapCollider2D)
			{
				tilemapCollider2D.ProcessTilemapChanges();
			}
			return coll.GetShapes(group);
		}

		public unsafe static int GenerateMeshesFromColliders(Collider2D[] colliders, int numColliders, float maxError, out NativeArray<float3> outputVertices, out NativeArray<int> outputIndices, out NativeArray<ShapeMesh> outputShapeMeshes)
		{
			PhysicsShapeGroup2D physicsShapeGroup2D = new PhysicsShapeGroup2D();
			NativeList<PhysicsShape2D> list = new NativeList<PhysicsShape2D>(numColliders, Allocator.Temp);
			NativeList<Vector2> list2 = new NativeList<Vector2>(numColliders * 4, Allocator.Temp);
			NativeList<Matrix4x4> list3 = new NativeList<Matrix4x4>(numColliders, Allocator.Temp);
			NativeList<int> list4 = new NativeList<int>(numColliders, Allocator.Temp);
			HashSet<Rigidbody2D> handledRigidbodies = new HashSet<Rigidbody2D>();
			int num = 0;
			for (int i = 0; i < numColliders; i++)
			{
				Collider2D collider2D = colliders[i];
				if (collider2D == null || collider2D.shapeCount == 0)
				{
					continue;
				}
				int shapes = GetShapes(collider2D, physicsShapeGroup2D, handledRigidbodies);
				if (shapes != 0)
				{
					list.Length += shapes;
					list2.Length += physicsShapeGroup2D.vertexCount;
					NativeArray<PhysicsShape2D> subArray = list.AsArray().GetSubArray(list.Length - shapes, shapes);
					NativeArray<Vector2> subArray2 = list2.AsArray().GetSubArray(list2.Length - physicsShapeGroup2D.vertexCount, physicsShapeGroup2D.vertexCount);
					physicsShapeGroup2D.GetShapeData(subArray, subArray2);
					for (int j = 0; j < shapes; j++)
					{
						PhysicsShape2D value = subArray[j];
						value.vertexStartIndex += num;
						subArray[j] = value;
					}
					num += subArray2.Length;
					list3.AddReplicate(physicsShapeGroup2D.localToWorldMatrix, shapes);
					list4.AddReplicate(in i, shapes);
				}
			}
			NativeList<float3> nativeList = new NativeList<float3>(Allocator.Temp);
			NativeList<int3> nativeList2 = new NativeList<int3>(Allocator.Temp);
			UnsafeSpan<PhysicsShape2D> shapes2 = list.AsUnsafeSpan();
			UnsafeSpan<float2> vertices = list2.AsUnsafeSpan().Reinterpret<float2>();
			UnsafeSpan<Matrix4x4> shapeMatrices = list3.AsUnsafeSpan();
			UnsafeSpan<int> groupIndices = list4.AsUnsafeSpan();
			outputShapeMeshes = new NativeArray<ShapeMesh>(list.Length, Allocator.Persistent);
			UnsafeSpan<ShapeMesh> outputShapeMeshes2 = outputShapeMeshes.AsUnsafeSpan();
			int result = GenerateMeshesFromShapes(ref shapes2, ref vertices, ref shapeMatrices, ref groupIndices, ref UnsafeUtility.AsRef<UnsafeList<float3>>(nativeList.GetUnsafeList()), ref UnsafeUtility.AsRef<UnsafeList<int3>>(nativeList2.GetUnsafeList()), ref outputShapeMeshes2, maxError);
			outputVertices = nativeList.ToArray(Allocator.Persistent);
			outputIndices = new NativeArray<int>(nativeList2.AsArray().Reinterpret<int>(12), Allocator.Persistent);
			return result;
		}

		private static void AddCapsuleMesh(float2 c1, float2 c2, ref Matrix4x4 shapeMatrix, float radius, float maxError, ref UnsafeList<float3> outputVertices, ref UnsafeList<int3> outputIndices, ref float3 mn, ref float3 mx)
		{
			int num = math.max(4, CircleGeometryUtilities.CircleSteps(shapeMatrix, radius, maxError));
			num = num / 2 + 1;
			radius *= CircleGeometryUtilities.CircleRadiusAdjustmentFactor(2 * (num - 1));
			Vector3 vector = new Vector3(c1.x, c1.y, 0f);
			Vector3 vector2 = new Vector3(c2.x, c2.y, 0f);
			float2 float5 = math.normalizesafe(c2 - c1);
			float2 float6 = new float2(0f - float5.y, float5.x);
			Vector3 vector3 = radius * new Vector3(float6.x, float6.y, 0f);
			Vector3 vector4 = radius * new Vector3(float5.x, float5.y, 0f);
			float num2 = MathF.PI / (float)(num - 1);
			int length = outputVertices.Length;
			int num3 = length + num;
			outputVertices.Length += num * 2;
			for (int i = 0; i < num; i++)
			{
				math.sincos(num2 * (float)i, out var s, out var c3);
				Vector3 vector5 = vector + c3 * vector3 - s * vector4;
				mn = math.min(mn, vector5);
				mx = math.max(mx, vector5);
				outputVertices[length + i] = vector5;
				vector5 = vector2 - c3 * vector3 + s * vector4;
				mn = math.min(mn, vector5);
				mx = math.max(mx, vector5);
				outputVertices[num3 + i] = vector5;
			}
			int length2 = outputIndices.Length;
			int num4 = length2 + num - 2;
			outputIndices.Length += (num - 2) * 2;
			for (int j = 1; j < num - 1; j++)
			{
				outputIndices[length2 + j - 1] = new int3(length, length + j, length + j + 1);
				outputIndices[num4 + j - 1] = new int3(num3, num3 + j, num3 + j + 1);
			}
			outputIndices.Add(new int3(length, length + num - 1, num3));
			outputIndices.Add(new int3(length, num3, num3 + num - 1));
		}

		[BurstCompile]
		public static int GenerateMeshesFromShapes(ref UnsafeSpan<PhysicsShape2D> shapes, ref UnsafeSpan<float2> vertices, ref UnsafeSpan<Matrix4x4> shapeMatrices, ref UnsafeSpan<int> groupIndices, ref UnsafeList<float3> outputVertices, ref UnsafeList<int3> outputIndices, ref UnsafeSpan<ShapeMesh> outputShapeMeshes, float maxError)
		{
			return GenerateMeshesFromShapes_00000AC3_0024BurstDirectCall.Invoke(ref shapes, ref vertices, ref shapeMatrices, ref groupIndices, ref outputVertices, ref outputIndices, ref outputShapeMeshes, maxError);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static int GenerateMeshesFromShapes_0024BurstManaged(ref UnsafeSpan<PhysicsShape2D> shapes, ref UnsafeSpan<float2> vertices, ref UnsafeSpan<Matrix4x4> shapeMatrices, ref UnsafeSpan<int> groupIndices, ref UnsafeList<float3> outputVertices, ref UnsafeList<int3> outputIndices, ref UnsafeSpan<ShapeMesh> outputShapeMeshes, float maxError)
		{
			int num = 0;
			float3 mn = new float3(float.MaxValue, float.MaxValue, float.MaxValue);
			float3 mx = new float3(float.MinValue, float.MinValue, float.MinValue);
			int result = 0;
			for (int i = 0; i < shapes.Length; i++)
			{
				PhysicsShape2D physicsShape2D = shapes[i];
				UnsafeSpan<float2> unsafeSpan = vertices.Slice(physicsShape2D.vertexStartIndex, physicsShape2D.vertexCount);
				Matrix4x4 shapeMatrix = shapeMatrices[i];
				switch (physicsShape2D.shapeType)
				{
				case PhysicsShapeType2D.Circle:
				{
					int num2 = CircleGeometryUtilities.CircleSteps(shapeMatrix, physicsShape2D.radius, maxError);
					float num3 = physicsShape2D.radius * CircleGeometryUtilities.CircleRadiusAdjustmentFactor(num2);
					Vector3 vector3 = new Vector3(unsafeSpan[0].x, unsafeSpan[0].y, 0f);
					Vector3 vector4 = new Vector3(num3, 0f, 0f);
					Vector3 vector5 = new Vector3(0f, num3, 0f);
					float num4 = MathF.PI * 2f / (float)num2;
					int length3 = outputVertices.Length;
					for (int num5 = 0; num5 < num2; num5++)
					{
						math.sincos(num4 * (float)num5, out var s, out var c3);
						Vector3 vector6 = vector3 + c3 * vector4 + s * vector5;
						mn = math.min(mn, vector6);
						mx = math.max(mx, vector6);
						outputVertices.Add((float3)vector6);
					}
					for (int num6 = 1; num6 < num2; num6++)
					{
						outputIndices.Add(new int3(length3, length3 + num6, length3 + (num6 + 1) % num2));
					}
					break;
				}
				case PhysicsShapeType2D.Capsule:
				{
					float2 c = unsafeSpan[0];
					float2 c2 = unsafeSpan[1];
					AddCapsuleMesh(c, c2, ref shapeMatrix, physicsShape2D.radius, maxError, ref outputVertices, ref outputIndices, ref mn, ref mx);
					break;
				}
				case PhysicsShapeType2D.Polygon:
				{
					int length2 = outputVertices.Length;
					outputVertices.Resize(length2 + physicsShape2D.vertexCount);
					for (int m = 0; m < physicsShape2D.vertexCount; m++)
					{
						Vector3 vector2 = new Vector3(unsafeSpan[m].x, unsafeSpan[m].y, 0f);
						mn = math.min(mn, vector2);
						mx = math.max(mx, vector2);
						outputVertices[length2 + m] = vector2;
					}
					outputIndices.SetCapacity(math.ceilpow2(outputIndices.Length + (physicsShape2D.vertexCount - 2)));
					for (int n = 1; n < physicsShape2D.vertexCount - 1; n++)
					{
						outputIndices.AddNoResize(new int3(length2, length2 + n, length2 + n + 1));
					}
					break;
				}
				case PhysicsShapeType2D.Edges:
				{
					if (physicsShape2D.radius > maxError)
					{
						for (int j = 0; j < physicsShape2D.vertexCount - 1; j++)
						{
							AddCapsuleMesh(unsafeSpan[j], unsafeSpan[j + 1], ref shapeMatrix, physicsShape2D.radius, maxError, ref outputVertices, ref outputIndices, ref mn, ref mx);
						}
						break;
					}
					int length = outputVertices.Length;
					outputVertices.Resize(length + physicsShape2D.vertexCount);
					for (int k = 0; k < physicsShape2D.vertexCount; k++)
					{
						Vector3 vector = new Vector3(unsafeSpan[k].x, unsafeSpan[k].y, 0f);
						mn = math.min(mn, vector);
						mx = math.max(mx, vector);
						outputVertices[length + k] = vector;
					}
					outputIndices.SetCapacity(math.ceilpow2(outputIndices.Length + (physicsShape2D.vertexCount - 1)));
					for (int l = 0; l < physicsShape2D.vertexCount - 1; l++)
					{
						outputIndices.AddNoResize(new int3(length + l, length + l + 1, length + l + 1));
					}
					break;
				}
				default:
					throw new Exception("Unexpected PhysicsShapeType2D");
				}
				if (i == shapes.Length - 1 || groupIndices[i] != groupIndices[i + 1] || outputIndices.Length - num > 100)
				{
					ToWorldMatrix toWorldMatrix = new ToWorldMatrix(new float3x3(shapeMatrix));
					Bounds bounds = new Bounds((mn + mx) * 0.5f, mx - mn);
					bounds = toWorldMatrix.ToWorld(bounds);
					bounds.center += (Vector3)shapeMatrix.GetColumn(3);
					outputShapeMeshes[result++] = new ShapeMesh
					{
						bounds = bounds,
						matrix = shapeMatrix,
						startIndex = num * 3,
						endIndex = outputIndices.Length * 3,
						tag = groupIndices[i]
					};
					mn = new float3(float.MaxValue, float.MaxValue, float.MaxValue);
					mx = new float3(float.MinValue, float.MinValue, float.MinValue);
					num = outputIndices.Length;
				}
			}
			return result;
		}
	}
}
