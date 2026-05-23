using System;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

namespace Pathfinding.Util
{
	[BurstCompile]
	internal static class MeshUtility
	{
		[BurstCompile]
		public struct JobRemoveDuplicateVertices : IJob
		{
			[ReadOnly]
			public NativeArray<Int3> vertices;

			[ReadOnly]
			public NativeArray<int> triangles;

			[ReadOnly]
			public NativeArray<int> tags;

			public unsafe UnsafeAppendBuffer* outputVertices;

			public unsafe UnsafeAppendBuffer* outputTriangles;

			public unsafe UnsafeAppendBuffer* outputTags;

			public static int3 cross(int3 x, int3 y)
			{
				return (x * y.yzx - x.yzx * y).yzx;
			}

			public unsafe void Execute()
			{
				int num = 0;
				outputVertices->Reset();
				outputTriangles->Reset();
				outputTags->Reset();
				NativeHashMap<Int3, int> nativeHashMap = new NativeHashMap<Int3, int>(vertices.Length, Allocator.Temp);
				NativeArray<int> nativeArray = new NativeArray<int>(vertices.Length, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
				int num2 = 0;
				for (int i = 0; i < vertices.Length; i++)
				{
					if (nativeHashMap.TryAdd(vertices[i], num2))
					{
						nativeArray[i] = num2;
						outputVertices->Add(vertices[i]);
						num2++;
					}
					else
					{
						nativeArray[i] = nativeHashMap[vertices[i]];
					}
				}
				int num3 = 0;
				int num4 = 0;
				while (num3 < triangles.Length)
				{
					int num5 = triangles[num3];
					int num6 = triangles[num3 + 1];
					int num7 = triangles[num3 + 2];
					if (math.all(cross(vertices.ReinterpretLoad<int3>(num6) - vertices.ReinterpretLoad<int3>(num5), vertices.ReinterpretLoad<int3>(num7) - vertices.ReinterpretLoad<int3>(num5)) == 0))
					{
						num++;
					}
					else
					{
						outputTriangles->Add(new int3(nativeArray[num5], nativeArray[num6], nativeArray[num7]));
						outputTags->Add(tags[num4]);
					}
					num3 += 3;
					num4++;
				}
				if (num > 0)
				{
					Debug.LogWarning($"Input mesh contained {num} degenerate triangles. These have been removed.\nA degenerate triangle is a triangle with zero area. It resembles a line or a point.");
				}
			}
		}

		public delegate void MakeTrianglesClockwise_00000E58_0024PostfixBurstDelegate(ref UnsafeSpan<Int3> vertices, ref UnsafeSpan<int> triangles);

		internal static class MakeTrianglesClockwise_00000E58_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			private static IntPtr DeferredCompilation;

			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = (nint)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(MakeTrianglesClockwise_00000E58_0024PostfixBurstDelegate).TypeHandle);
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

			static MakeTrianglesClockwise_00000E58_0024BurstDirectCall()
			{
				Constructor();
			}

			public unsafe static void Invoke(ref UnsafeSpan<Int3> vertices, ref UnsafeSpan<int> triangles)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref UnsafeSpan<Int3>, ref UnsafeSpan<int>, void>)functionPointer)(ref vertices, ref triangles);
						return;
					}
				}
				MakeTrianglesClockwise_0024BurstManaged(ref vertices, ref triangles);
			}
		}

		public static void GetMeshData(Mesh.MeshDataArray meshData, int meshIndex, out NativeArray<Vector3> vertices, out NativeArray<int> indices)
		{
			Mesh.MeshData meshData2 = meshData[meshIndex];
			vertices = new NativeArray<Vector3>(meshData2.vertexCount, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			meshData2.GetVertices(vertices);
			int num = 0;
			for (int i = 0; i < meshData2.subMeshCount; i++)
			{
				num += meshData2.GetSubMesh(i).indexCount;
			}
			indices = new NativeArray<int>(num, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
			int num2 = 0;
			for (int j = 0; j < meshData2.subMeshCount; j++)
			{
				SubMeshDescriptor subMesh = meshData2.GetSubMesh(j);
				meshData2.GetIndices(indices.GetSubArray(num2, subMesh.indexCount), j);
				num2 += subMesh.indexCount;
			}
		}

		[BurstCompile]
		public static void MakeTrianglesClockwise(ref UnsafeSpan<Int3> vertices, ref UnsafeSpan<int> triangles)
		{
			MakeTrianglesClockwise_00000E58_0024BurstDirectCall.Invoke(ref vertices, ref triangles);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static void MakeTrianglesClockwise_0024BurstManaged(ref UnsafeSpan<Int3> vertices, ref UnsafeSpan<int> triangles)
		{
			for (int i = 0; i < triangles.Length; i += 3)
			{
				if (!VectorMath.IsClockwiseXZ(vertices[triangles[i]], vertices[triangles[i + 1]], vertices[triangles[i + 2]]))
				{
					int num = triangles[i];
					triangles[i] = triangles[i + 2];
					triangles[i + 2] = num;
				}
			}
		}
	}
}
