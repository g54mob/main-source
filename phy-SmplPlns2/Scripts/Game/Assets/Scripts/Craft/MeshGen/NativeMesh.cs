using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Assets.Scripts.Bindings.Manifold;
using Jundroo.Common.Extensions;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Mathematics.Geometry;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Craft.MeshGen
{
	public struct NativeMesh : IDisposable
	{
		public struct TriangleRun
		{
			public int MaterialId;

			public int StartTriangles;
		}

		public readonly struct ReadOnlyUnsafe
		{
			[NativeDisableUnsafePtrRestriction]
			private unsafe readonly Vertex* _vertexPtr;

			private readonly int _vertexCount;

			[NativeDisableUnsafePtrRestriction]
			private unsafe readonly int3* _trianglePtr;

			private readonly int _triangleCount;

			[NativeDisableUnsafePtrRestriction]
			private unsafe readonly TriangleRun* _runsPtr;

			private readonly int _runCount;

			public unsafe NativeArray<Vertex>.ReadOnly VerticesArray => NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<Vertex>(_vertexPtr, _vertexCount, Allocator.None).AsReadOnly();

			public unsafe ReadOnlySpan<Vertex> Vertices => new ReadOnlySpan<Vertex>(_vertexPtr, _vertexCount);

			public unsafe ReadOnlySpan<int3> Triangles => new ReadOnlySpan<int3>(_trianglePtr, _triangleCount);

			public unsafe ReadOnlySpan<TriangleRun> Runs => new ReadOnlySpan<TriangleRun>(_runsPtr, _runCount);

			private unsafe ReadOnlyUnsafe(NativeMesh mesh)
			{
				_vertexPtr = (Vertex*)mesh.Vertices.AsArray().GetUnsafeReadOnlyPtr();
				_vertexCount = mesh.Vertices.Length;
				_trianglePtr = (int3*)mesh.Triangles.AsArray().GetUnsafeReadOnlyPtr();
				_triangleCount = mesh.Triangles.Length;
				_runsPtr = (TriangleRun*)mesh.Runs.AsArray().GetUnsafeReadOnlyPtr();
				_runCount = mesh.Runs.Length;
			}

			internal static ReadOnlyUnsafe Create(NativeMesh mesh)
			{
				return new ReadOnlyUnsafe(mesh);
			}
		}

		[BurstCompile]
		private struct WriteToSimpleMeshDataJob : IJob
		{
			public NativeMesh builder;

			public Mesh.MeshDataArray array;

			public int arrayIndex;

			public bool makeSubmeshes;

			public NativeReference<Bounds> outBounds;

			public NativeList<int> outSubmeshToLevel;

			[ReadOnly]
			public NativeArray<VertexAttributeDescriptor> simpleMeshVad;

			public void Execute()
			{
				builder.WriteToSimpleMeshDataBurst(array[arrayIndex], simpleMeshVad, makeSubmeshes, out var bounds, outSubmeshToLevel);
				outBounds.Value = bounds;
			}
		}

		[BurstCompile]
		private struct WriteToPartMeshDataJob : IJob
		{
			public NativeMesh builder;

			public Mesh.MeshDataArray array;

			public int arrayIndex;

			public bool makeSubmeshes;

			public float3 defaultUV;

			public NativeReference<Bounds> outBounds;

			public NativeList<int> outSubmeshToLevel;

			[ReadOnly]
			public NativeArray<VertexAttributeDescriptor> partMeshVad;

			[ReadOnly]
			public NativeArray<float3> levelToUV;

			public void Execute()
			{
				builder.WriteToPartMeshDataBurst(array[arrayIndex], partMeshVad, levelToUV, defaultUV, outSubmeshToLevel, makeSubmeshes, out var bounds);
				outBounds.Value = bounds;
			}
		}

		public NativeList<TriangleRun> Runs;

		public NativeList<int3> Triangles;

		public NativeList<Vertex> Vertices;

		private int _triOffset;

		public readonly int CurrentOffset => _triOffset;

		public NativeMesh(int capacityVerts, int capacityTriangles, AllocatorManager.AllocatorHandle allocator, int materialIdStart = 0)
		{
			Vertices = new NativeList<Vertex>(capacityVerts, allocator);
			Triangles = new NativeList<int3>(capacityTriangles, allocator);
			Runs = new NativeList<TriangleRun>(8, allocator);
			_triOffset = 0;
			SetRunMaterial(materialIdStart);
		}

		public void Combine(ReadOnlyUnsafe otherMesh)
		{
			int length = Vertices.Length;
			int length2 = Triangles.Length;
			ReadOnlySpan<Vertex> vertices = otherMesh.Vertices;
			Vertices.Length = length + vertices.Length;
			Span<Vertex> span = Vertices.AsArray().AsSpan();
			int num = length;
			vertices.CopyTo(span.Slice(num, span.Length - num));
			ReadOnlySpan<int3> triangles = otherMesh.Triangles;
			Triangles.EnsureFreeCapacity(triangles.Length);
			for (int i = 0; i < triangles.Length; i++)
			{
				Triangles.AddNoResize(triangles[i] + length);
			}
			ReadOnlySpan<TriangleRun> runs = otherMesh.Runs;
			int num2;
			if (Runs.Length > 0 && runs.Length > 0)
			{
				ref NativeList<TriangleRun> runs2 = ref Runs;
				if (runs2[runs2.Length - 1].MaterialId == runs[0].MaterialId)
				{
					num2 = 1;
					goto IL_0103;
				}
			}
			num2 = 0;
			goto IL_0103;
			IL_0103:
			int num3 = num2;
			Runs.EnsureFreeCapacity(runs.Length - num3);
			for (int j = num3; j < runs.Length; j++)
			{
				TriangleRun value = runs[j];
				value.StartTriangles += length2;
				Runs.AddNoResize(value);
			}
		}

		public void Combine(ReadOnlyUnsafe otherMesh, ulong materialIdMask)
		{
			int length = Vertices.Length;
			ReadOnlySpan<Vertex> vertices = otherMesh.Vertices;
			Vertices.Length = length + vertices.Length;
			Span<Vertex> span = Vertices.AsArray().AsSpan();
			int num = length;
			vertices.CopyTo(span.Slice(num, span.Length - num));
			ReadOnlySpan<TriangleRun> runs = otherMesh.Runs;
			ReadOnlySpan<int3> triangles = otherMesh.Triangles;
			for (int i = 0; i < runs.Length; i++)
			{
				TriangleRun triangleRun = runs[i];
				if (((ulong)(1L << triangleRun.MaterialId) & materialIdMask) != 0L)
				{
					SetRunMaterial(triangleRun.MaterialId);
					int num2 = ((i == runs.Length - 1) ? runs.Length : runs[i + 1].StartTriangles);
					Triangles.EnsureFreeCapacity(num2 - triangleRun.StartTriangles);
					for (int j = triangleRun.StartTriangles; j < num2; j++)
					{
						Triangles.AddNoResize(triangles[j] + length);
					}
				}
			}
		}

		public readonly ReadOnlyUnsafe AsReadOnlyUnsafe()
		{
			return ReadOnlyUnsafe.Create(this);
		}

		public void Clear()
		{
			Vertices.Clear();
			Triangles.Clear();
			Runs.Clear();
		}

		public void CopyFrom(NativeMesh other)
		{
			Vertices.CopyFrom(in other.Vertices);
			Triangles.CopyFrom(in other.Triangles);
			Runs.CopyFrom(in other.Runs);
			_triOffset = other._triOffset;
		}

		public void Dispose()
		{
			Vertices.Dispose();
			Triangles.Dispose();
			Runs.Dispose();
		}

		public void DisposeIfCreated()
		{
			Extensions.DisposeIfCreated(ref Vertices);
			Extensions.DisposeIfCreated(ref Triangles);
			Extensions.DisposeIfCreated(ref Runs);
		}

		public void SetRunMaterial(int materialID)
		{
			if (!Runs.IsEmpty)
			{
				ref NativeList<TriangleRun> runs = ref Runs;
				if (runs[runs.Length - 1].MaterialId == materialID)
				{
					return;
				}
				ref NativeList<TriangleRun> runs2 = ref Runs;
				if (runs2[runs2.Length - 1].StartTriangles == Triangles.Length)
				{
					Runs.Length--;
				}
			}
			Runs.Add(new TriangleRun
			{
				MaterialId = materialID,
				StartTriangles = Triangles.Length
			});
		}

		public void Start()
		{
			_triOffset = Vertices.Length;
		}

		public int Tri(int3 triangle)
		{
			int length = Triangles.Length;
			Triangles.Add(triangle + _triOffset);
			return length;
		}

		public void Tri(int a, int b, int c)
		{
			Triangles.Add(new int3(a, b, c) + _triOffset);
		}

		public int Vert(Vertex vertex)
		{
			int result = Vertices.Length - _triOffset;
			Vertices.Add(in vertex);
			return result;
		}

		public int Vert(float3 position, float3 normal)
		{
			int result = Vertices.Length - _triOffset;
			Vertices.Add(new Vertex(position, normal));
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Quad(int a, int b, int c, int d)
		{
			int triOffset = _triOffset;
			Triangles.Add(new int3(triOffset + a, triOffset + b, triOffset + c));
			Triangles.Add(new int3(triOffset + a, triOffset + c, triOffset + d));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void RQuad(int a, int b, int c, int d)
		{
			int triOffset = _triOffset;
			Triangles.Add(new int3(triOffset + d, triOffset + c, triOffset + b));
			Triangles.Add(new int3(triOffset + d, triOffset + b, triOffset + a));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Quad(float3 a, float3 b, float3 c, float3 d)
		{
			float3 normal = math.normalizesafe(math.cross(b - c, b - a));
			int length = Vertices.Length;
			Vertices.Add(new Vertex(a, normal));
			Vertices.Add(new Vertex(b, normal));
			Vertices.Add(new Vertex(c, normal));
			Vertices.Add(new Vertex(d, normal));
			Triangles.Add(new int3(length, length + 1, length + 2));
			Triangles.Add(new int3(length, length + 2, length + 3));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void RQuad(float3 a, float3 b, float3 c, float3 d)
		{
			float3 normal = -math.normalizesafe(math.cross(b - c, b - a));
			int length = Vertices.Length;
			Vertices.Add(new Vertex(d, normal));
			Vertices.Add(new Vertex(c, normal));
			Vertices.Add(new Vertex(b, normal));
			Vertices.Add(new Vertex(a, normal));
			Triangles.Add(new int3(length, length + 1, length + 2));
			Triangles.Add(new int3(length, length + 2, length + 3));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Tri(float3 a, float3 b, float3 c)
		{
			float3 normal = math.normalizesafe(math.cross(b - c, b - a));
			int length = Vertices.Length;
			Vertices.Add(new Vertex(a, normal));
			Vertices.Add(new Vertex(b, normal));
			Vertices.Add(new Vertex(c, normal));
			Triangles.Add(new int3(length, length + 1, length + 2));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void RTri(float3 a, float3 b, float3 c)
		{
			float3 normal = -math.normalizesafe(math.cross(b - c, b - a));
			int length = Vertices.Length;
			Vertices.Add(new Vertex(c, normal));
			Vertices.Add(new Vertex(b, normal));
			Vertices.Add(new Vertex(a, normal));
			Triangles.Add(new int3(length, length + 1, length + 2));
		}

		public unsafe readonly NativeMethods.Manifold* ToManifoldNative(void* storage, uint idOffset = 0u)
		{
			Span<MeshGLBase.Run> runs = stackalloc MeshGLBase.Run[Runs.Length];
			MakeRuns(runs, idOffset);
			NativeMethods.MeshGL* ptr = MeshGL<Vertex>.CreateNative(Allocator.Temp, Vertices.AsArray(), Triangles.AsArray().Reinterpret<uint3>(), runs);
			void* ptr2 = MeshGL<Vertex>.AllocNative(Allocator.Temp);
			NativeMethods.MeshGL* ptr3 = NativeMethods.manifold_meshgl_merge(ptr2, ptr);
			if (ptr3 != ptr)
			{
				MeshGL<Vertex>.DestroyNative(ptr, Allocator.Temp);
			}
			if (ptr3 != ptr2)
			{
				UnsafeUtility.Free(ptr2, Allocator.Temp);
			}
			NativeMethods.Manifold* result = NativeMethods.manifold_of_meshgl(storage, ptr3);
			MeshGL<Vertex>.DestroyNative(ptr3, Allocator.Temp);
			return result;
		}

		public readonly Manifold<Vertex> ToManifold(Allocator allocator, out Error status, uint idOffset = 0u)
		{
			Span<MeshGLBase.Run> runs = stackalloc MeshGLBase.Run[Runs.Length];
			MakeRuns(runs, idOffset);
			MeshGL<Vertex> meshGL = MeshGL<Vertex>.Create(allocator, Vertices.AsArray(), Triangles.AsArray().Reinterpret<uint3>(), runs);
			MeshGL<Vertex> meshGL2 = meshGL.Merge(Allocator.Temp);
			if (meshGL2 != meshGL)
			{
				meshGL.Dispose();
			}
			Manifold<Vertex> manifold;
			try
			{
				manifold = Manifold.Create(allocator, meshGL2);
			}
			finally
			{
				meshGL2.Dispose();
			}
			status = manifold.Status;
			if (status != Error.NO_ERROR)
			{
				Debug.LogError($"Failed to create manifold for mesh: {manifold.Status}");
				manifold.Dispose();
				return null;
			}
			return manifold;
		}

		[BurstDiscard]
		public readonly void DebugMeshOutput()
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(Path.Join(new DirectoryInfo(Application.dataPath).Parent.Parent.Parent.FullName, "Temp"));
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
			string path = $"export-{directoryInfo.GetFiles().Length}.obj";
			using StreamWriter streamWriter = new StreamWriter(Path.Combine(directoryInfo.FullName, path));
			streamWriter.WriteLine("#debug exported mesh");
			foreach (Vertex vertex in Vertices)
			{
				float3 position = vertex.position;
				float3 normal = vertex.normal;
				streamWriter.WriteLine($"v {position.x} {position.y} {position.z}");
				streamWriter.WriteLine($"vn {normal.x} {normal.y} {normal.z}");
			}
			foreach (int3 triangle in Triangles)
			{
				int3 int5 = triangle + 1;
				streamWriter.WriteLine($"f {int5.x}/{int5.x} {int5.y}/{int5.y} {int5.z}/{int5.z}");
			}
			Debug.Log("Exported mesh to '" + Path.Combine(directoryInfo.FullName, path) + "'");
		}

		public int MaxMaterial()
		{
			int num = -1;
			for (int i = 0; i < Runs.Length; i++)
			{
				num = math.max(num, Runs[i].MaterialId);
			}
			return num;
		}

		public void SortSubmeshes()
		{
			bool flag = false;
			int num = -1;
			for (int i = 0; i < Runs.Length; i++)
			{
				int materialId = Runs[i].MaterialId;
				if (materialId <= num)
				{
					flag = true;
					break;
				}
				num = materialId;
			}
			if (!flag)
			{
				return;
			}
			int num2 = MaxMaterial();
			NativeArray<int3> nativeArray = new NativeArray<int3>(Triangles.AsArray(), Allocator.Temp);
			NativeArray<TriangleRun> nativeArray2 = new NativeArray<TriangleRun>(Runs.AsArray(), Allocator.Temp);
			Triangles.Clear();
			Runs.Clear();
			for (int j = 0; j <= num2; j++)
			{
				SetRunMaterial(j);
				for (int k = 0; k < nativeArray2.Length; k++)
				{
					TriangleRun triangleRun = nativeArray2[k];
					if (triangleRun.MaterialId == j)
					{
						int num3 = ((k == nativeArray2.Length - 1) ? nativeArray.Length : nativeArray2[k + 1].StartTriangles);
						Triangles.AddRange(nativeArray.GetSubArray(triangleRun.StartTriangles, num3 - triangleRun.StartTriangles));
					}
				}
			}
		}

		public void WriteToSimpleMeshData(Mesh mesh, out int[] submeshToLevel, bool makeSubmeshes = true)
		{
			Mesh.MeshDataArray meshDataArray = Mesh.AllocateWritableMeshData(mesh);
			using NativeList<int> outSubmeshToLevel = new NativeList<int>(Allocator.TempJob);
			using NativeReference<Bounds> outBounds = new NativeReference<Bounds>(Allocator.TempJob);
			new WriteToSimpleMeshDataJob
			{
				array = meshDataArray,
				arrayIndex = 0,
				builder = this,
				makeSubmeshes = makeSubmeshes,
				simpleMeshVad = Vertex.SimpleMeshVertexLayout,
				outBounds = outBounds,
				outSubmeshToLevel = outSubmeshToLevel
			}.Run();
			Mesh.ApplyAndDisposeWritableMeshData(meshDataArray, mesh);
			mesh.bounds = outBounds.Value;
			submeshToLevel = outSubmeshToLevel.AsArray().ToArray();
		}

		public void WriteToPartMeshData(Mesh mesh, List<float3> levelToUV, float3 defaultUV, out int[] submeshToLevel, bool makeSubmeshes = true)
		{
			Mesh.MeshDataArray meshDataArray = Mesh.AllocateWritableMeshData(mesh);
			using NativeArray<float3> nativeArray = new NativeArray<float3>(levelToUV.Count, Allocator.TempJob);
			NativeArray<float3> nativeArray2 = nativeArray;
			for (int i = 0; i < nativeArray.Length; i++)
			{
				nativeArray2[i] = levelToUV[i];
			}
			using NativeList<int> outSubmeshToLevel = new NativeList<int>(Allocator.TempJob);
			using NativeReference<Bounds> outBounds = new NativeReference<Bounds>(Allocator.TempJob);
			new WriteToPartMeshDataJob
			{
				array = meshDataArray,
				arrayIndex = 0,
				builder = this,
				makeSubmeshes = makeSubmeshes,
				partMeshVad = PartMeshVertexUVs.PartMeshVertexLayout,
				levelToUV = nativeArray,
				outBounds = outBounds,
				defaultUV = defaultUV,
				outSubmeshToLevel = outSubmeshToLevel
			}.Run();
			Mesh.ApplyAndDisposeWritableMeshData(meshDataArray, mesh);
			mesh.bounds = outBounds.Value;
			submeshToLevel = outSubmeshToLevel.AsArray().ToArray();
		}

		public MinMaxAABB CalculateAABB()
		{
			if (Vertices.Length == 0)
			{
				return new MinMaxAABB(0f, 0f);
			}
			MinMaxAABB result = new MinMaxAABB(Vertices[0].position, Vertices[0].position);
			for (int i = 0; i < Vertices.Length; i++)
			{
				float3 position = Vertices[i].position;
				result.Min = math.min(result.Min, position);
				result.Max = math.max(result.Max, position);
			}
			return result;
		}

		private void WriteToSimpleMeshDataBurst(Mesh.MeshData dst, NativeArray<VertexAttributeDescriptor> simpleMeshVad, bool makeSubmeshes, out Bounds bounds, NativeList<int> outSubmeshToLevel)
		{
			dst.subMeshCount = 0;
			if (Vertices.Length == 0 || Triangles.Length == 0)
			{
				dst.SetVertexBufferParams(0, simpleMeshVad);
				dst.SetIndexBufferParams(0, IndexFormat.UInt32);
				dst.subMeshCount = 0;
				bounds = default(Bounds);
				return;
			}
			NativeArray<Vertex> array = Vertices.AsArray();
			NativeArray<int3> array2 = Triangles.AsArray();
			MinMaxAABB minMaxAABB = new MinMaxAABB(array[0].position, array[0].position);
			for (int i = 0; i < array.Length; i++)
			{
				minMaxAABB.Min = math.min(minMaxAABB.Min, array[i].position);
				minMaxAABB.Max = math.max(minMaxAABB.Max, array[i].position);
			}
			bounds = new Bounds((minMaxAABB.Min + minMaxAABB.Max) * 0.5f, minMaxAABB.Max - minMaxAABB.Min);
			dst.SetVertexBufferParams(array.Length, simpleMeshVad);
			dst.GetVertexData<Vertex>().CopyFrom(array);
			dst.SetIndexBufferParams(array2.Length * 3, IndexFormat.UInt32);
			dst.GetIndexData<uint>().Reinterpret<int3>(4).CopyFrom(array2);
			if (makeSubmeshes && Runs.Length > 0)
			{
				int num = (dst.subMeshCount = Runs.Length);
				for (int j = 0; j < Runs.Length; j++)
				{
					TriangleRun triangleRun = Runs[j];
					int num2 = triangleRun.StartTriangles * 3;
					int num3 = ((j == num - 1) ? array2.Length : Runs[j + 1].StartTriangles) * 3;
					outSubmeshToLevel.Add(in triangleRun.MaterialId);
					dst.SetSubMesh(j, new SubMeshDescriptor
					{
						baseVertex = 0,
						firstVertex = 0,
						vertexCount = array.Length,
						bounds = bounds,
						indexStart = num2,
						indexCount = num3 - num2
					});
				}
			}
			else
			{
				dst.subMeshCount = 1;
				dst.SetSubMesh(0, new SubMeshDescriptor
				{
					baseVertex = 0,
					firstVertex = 0,
					vertexCount = array.Length,
					bounds = bounds,
					indexStart = 0,
					indexCount = array2.Length * 3
				});
			}
		}

		private void WriteToPartMeshDataBurst(Mesh.MeshData dst, NativeArray<VertexAttributeDescriptor> partMeshVad, NativeArray<float3> levelToUV, float3 defaultUV, NativeList<int> outSubmeshToLevel, bool makeSubmeshes, out Bounds bounds)
		{
			dst.subMeshCount = 0;
			if (Vertices.Length == 0 || Triangles.Length == 0)
			{
				dst.SetVertexBufferParams(0, partMeshVad);
				dst.SetIndexBufferParams(0, IndexFormat.UInt32);
				dst.subMeshCount = 0;
				bounds = default(Bounds);
				return;
			}
			NativeArray<Vertex> array = Vertices.AsArray();
			NativeArray<int3> array2 = Triangles.AsArray();
			MinMaxAABB minMaxAABB = new MinMaxAABB(array[0].position, array[0].position);
			for (int i = 0; i < array.Length; i++)
			{
				minMaxAABB.Min = math.min(minMaxAABB.Min, array[i].position);
				minMaxAABB.Max = math.max(minMaxAABB.Max, array[i].position);
			}
			bounds = new Bounds((minMaxAABB.Min + minMaxAABB.Max) * 0.5f, minMaxAABB.Max - minMaxAABB.Min);
			if (Runs.Length <= 1)
			{
				int value = ((Runs.Length != 0) ? Runs[0].MaterialId : 0);
				outSubmeshToLevel.Add(in value);
				float3 uv = GetUV(value);
				dst.SetVertexBufferParams(array.Length, partMeshVad);
				dst.GetVertexData<Vertex>().CopyFrom(array);
				NativeArray<PartMeshVertexUVs> array3 = dst.GetVertexData<PartMeshVertexUVs>(1);
				UnityEngine.Rendering.ArrayExtensions.FillArray(ref array3, new PartMeshVertexUVs(uv));
				dst.SetIndexBufferParams(array2.Length * 3, IndexFormat.UInt32);
				dst.GetIndexData<uint>().Reinterpret<int3>(4).CopyFrom(array2);
				dst.subMeshCount = 1;
				dst.SetSubMesh(0, new SubMeshDescriptor
				{
					baseVertex = 0,
					firstVertex = 0,
					vertexCount = array.Length,
					bounds = bounds,
					indexStart = 0,
					indexCount = array2.Length * 3
				});
				return;
			}
			int length = Runs.Length;
			NativeList<Vertex> nativeList = new NativeList<Vertex>(array.Length * 2, Allocator.Temp);
			NativeList<PartMeshVertexUVs> list = new NativeList<PartMeshVertexUVs>(array.Length * 2, Allocator.Temp);
			Span<int2> span = stackalloc int2[length];
			NativeHashMap<int, int> nativeHashMap = new NativeHashMap<int, int>(nativeList.Length, Allocator.Temp);
			Span<int2> span2 = stackalloc int2[length];
			Span<int> span3 = stackalloc int[length];
			int num = 0;
			NativeArray<int> nativeArray = array2.Reinterpret<int>(12);
			int num2 = 0;
			for (int j = 0; j < length; j++)
			{
				TriangleRun triangleRun = Runs[j];
				if (triangleRun.MaterialId < 63 && triangleRun.MaterialId >= 0)
				{
					int num3 = ((j == length - 1) ? array2.Length : Runs[j + 1].StartTriangles) - triangleRun.StartTriangles;
					span2[num] = new int2(num2, num2 + num3);
					span3[num] = j;
					num++;
					num2 += num3;
				}
			}
			dst.SetIndexBufferParams(num2 * 3, IndexFormat.UInt32);
			NativeArray<uint> indexData = dst.GetIndexData<uint>();
			int num4 = 0;
			for (int k = 0; k < num; k++)
			{
				int num5 = span3[k];
				TriangleRun triangleRun2 = Runs[num5];
				int num6 = triangleRun2.StartTriangles * 3;
				int num7 = ((num5 == length - 1) ? array2.Length : Runs[num5 + 1].StartTriangles) * 3;
				int2 int5 = new int2(nativeList.Length, -1);
				PartMeshVertexUVs value2 = new PartMeshVertexUVs(GetUV(triangleRun2.MaterialId));
				int num8 = 0;
				nativeHashMap.Clear();
				for (int l = num6; l < num7; l++)
				{
					int num9 = nativeArray[l];
					if (!nativeHashMap.TryGetValue(num9, out var item))
					{
						item = nativeList.Length;
						nativeList.Add(array[num9]);
						num8++;
					}
					indexData[num4++] = (uint)item;
				}
				list.EnsureCapacity(nativeList.Length);
				for (int m = list.Length; m < nativeList.Length; m++)
				{
					list.AddNoResize(value2);
				}
				int5.y = nativeList.Length;
				span[num5] = int5;
			}
			dst.SetVertexBufferParams(nativeList.Length, partMeshVad);
			dst.GetVertexData<Vertex>().CopyFrom(nativeList.AsArray());
			dst.GetVertexData<PartMeshVertexUVs>(1).CopyFrom(list.AsArray());
			if (makeSubmeshes)
			{
				dst.subMeshCount = num;
				for (int n = 0; n < num; n++)
				{
					int num10 = span2[n].x * 3;
					int num11 = span2[n].y * 3;
					int2 int6 = span[n];
					TriangleRun triangleRun3 = Runs[span3[n]];
					outSubmeshToLevel.Add(in triangleRun3.MaterialId);
					dst.SetSubMesh(n, new SubMeshDescriptor
					{
						baseVertex = 0,
						firstVertex = int6.x,
						vertexCount = int6.y - int6.x,
						bounds = bounds,
						indexStart = num10,
						indexCount = num11 - num10
					});
				}
			}
			else
			{
				dst.subMeshCount = 1;
				dst.SetSubMesh(0, new SubMeshDescriptor
				{
					baseVertex = 0,
					firstVertex = 0,
					vertexCount = nativeList.Length,
					bounds = bounds,
					indexStart = 0,
					indexCount = num2 * 3
				});
			}
			float3 GetUV(int materialLevel)
			{
				if (materialLevel >= levelToUV.Length)
				{
					return defaultUV;
				}
				return levelToUV[materialLevel];
			}
		}

		private readonly void MakeRuns(Span<MeshGLBase.Run> runs, uint idOffset)
		{
			for (int i = 0; i < Runs.Length; i++)
			{
				TriangleRun triangleRun = Runs[i];
				runs[i] = new MeshGLBase.Run
				{
					StartIndex = (uint)(triangleRun.StartTriangles * 3),
					EndIndex = (uint)(((i == Runs.Length - 1) ? Triangles.Length : Runs[i + 1].StartTriangles) * 3),
					OriginalID = idOffset + (uint)triangleRun.MaterialId
				};
			}
		}
	}
}
