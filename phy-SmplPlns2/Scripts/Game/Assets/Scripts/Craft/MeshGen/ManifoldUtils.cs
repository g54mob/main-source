using System;
using System.Collections.Generic;
using Assets.Scripts.Bindings.Manifold;
using Jundroo.Common.Extensions;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Craft.MeshGen
{
	[BurstCompile]
	public static class ManifoldUtils
	{
		[BurstCompile]
		private struct ManifoldToMeshJob : IJob
		{
			public float3 defaultUV;

			[ReadOnly]
			public bool makeSubmeshes;

			[ReadOnly]
			[NativeDisableUnsafePtrRestriction]
			public unsafe NativeMethods.Manifold* manifoldPtr;

			[ReadOnly]
			public NativeArray<float3> materialLevelToUV;

			public NativeReference<Bounds> meshBounds;

			public Mesh.MeshDataArray meshes;

			public int meshIndex;

			[ReadOnly]
			public NativeArray<VertexAttributeDescriptor> partMeshVertexAttributes;

			public NativeList<int> submeshLevels;

			unsafe void IJob.Execute()
			{
				NativeMethods.Manifold* m = manifoldPtr;
				NativeMethods.MeshGL* ptr = NativeMethods.manifold_get_meshgl_w_normals(UnsafeUtility.Malloc((long)(ulong)NativeMethods.manifold_meshgl_size(), sizeof(IntPtr), Allocator.Temp), m, Vertex.OffsetOfNormal());
				try
				{
					Mesh.MeshData meshData = meshes[meshIndex];
					meshData.subMeshCount = 0;
					int num = (int)(uint)NativeMethods.manifold_meshgl_vert_properties_length(ptr);
					NativeArray<Vertex> nativeArray = new NativeArray<Vertex>(num, Allocator.Temp);
					NativeMethods.manifold_meshgl_vert_properties(nativeArray.GetUnsafePtr(), ptr);
					for (int i = 0; i < nativeArray.Length; i++)
					{
						Vertex value = nativeArray[i];
						value.normal = (math.any(math.isnan(value.normal)) ? ((float3)0f) : value.normal);
						nativeArray[i] = value;
					}
					Box box = default(Box);
					box = *NativeMethods.manifold_bounding_box(&box, m);
					Bounds bounds = (meshBounds.Value = (Bounds)box);
					Bounds bounds3 = bounds;
					int num2 = (int)(uint)NativeMethods.manifold_meshgl_tri_length(ptr);
					meshData.SetIndexBufferParams(num2, IndexFormat.UInt32);
					NativeArray<uint> indexData = meshData.GetIndexData<uint>();
					NativeMethods.manifold_meshgl_tri_verts(indexData.GetUnsafePtr(), ptr);
					Span<MeshGLBase.Run> dest = stackalloc MeshGLBase.Run[GetRunDataLength(ptr)];
					GetRunData(ptr, dest);
					int x = -1;
					for (int j = 0; j < dest.Length; j++)
					{
						x = math.max(x, (int)dest[j].OriginalID);
					}
					NativeArray<float3> uvArray = materialLevelToUV;
					float3 defaultUv = defaultUV;
					if (dest.Length <= 1)
					{
						int value2 = (int)((dest.Length != 0) ? dest[0].OriginalID : 0);
						submeshLevels.Add(in value2);
						float3 uv = GetUV(value2);
						meshData.SetVertexBufferParams(nativeArray.Length, partMeshVertexAttributes);
						meshData.GetVertexData<Vertex>().CopyFrom(nativeArray);
						NativeArray<PartMeshVertexUVs> array = meshData.GetVertexData<PartMeshVertexUVs>(1);
						UnityEngine.Rendering.ArrayExtensions.FillArray(ref array, new PartMeshVertexUVs(uv));
						meshData.subMeshCount = 1;
						meshData.SetSubMesh(0, new SubMeshDescriptor
						{
							baseVertex = 0,
							firstVertex = 0,
							vertexCount = nativeArray.Length,
							bounds = bounds3,
							indexStart = 0,
							indexCount = num2
						});
						return;
					}
					NativeList<Vertex> nativeList = new NativeList<Vertex>(num * 2, Allocator.Temp);
					NativeList<PartMeshVertexUVs> list = new NativeList<PartMeshVertexUVs>(num * 2, Allocator.Temp);
					Span<int2> span = stackalloc int2[dest.Length];
					NativeHashMap<uint, uint> nativeHashMap = new NativeHashMap<uint, uint>(num, Allocator.Temp);
					for (int k = 0; k < dest.Length; k++)
					{
						MeshGLBase.Run run = dest[k];
						uint startIndex = run.StartIndex;
						int num3 = ((k == dest.Length - 1) ? num2 : ((int)dest[k + 1].StartIndex));
						int2 int5 = new int2(nativeList.Length, -1);
						PartMeshVertexUVs value3 = new PartMeshVertexUVs(GetUV((int)run.OriginalID));
						int num4 = 0;
						nativeHashMap.Clear();
						for (int l = (int)startIndex; l < num3; l++)
						{
							uint num5 = indexData[l];
							if (!nativeHashMap.TryGetValue(num5, out var item))
							{
								item = (uint)nativeList.Length;
								nativeList.Add(nativeArray[(int)num5]);
								num4++;
							}
							indexData[l] = item;
						}
						list.EnsureCapacity(nativeList.Length);
						for (int n = list.Length; n < nativeList.Length; n++)
						{
							list.AddNoResize(value3);
						}
						int5.y = nativeList.Length;
						span[k] = int5;
					}
					meshData.SetVertexBufferParams(nativeList.Length, partMeshVertexAttributes);
					meshData.GetVertexData<Vertex>().CopyFrom(nativeList.AsArray());
					meshData.GetVertexData<PartMeshVertexUVs>(1).CopyFrom(list.AsArray());
					if (makeSubmeshes)
					{
						int num6 = 0;
						for (int num7 = 0; num7 < dest.Length; num7++)
						{
							if (dest[num7].EndIndex > dest[num7].StartIndex)
							{
								num6++;
							}
						}
						meshData.subMeshCount = num6;
						for (int num8 = 0; num8 < dest.Length; num8++)
						{
							MeshGLBase.Run run2 = dest[num8];
							if (run2.EndIndex > run2.StartIndex)
							{
								int startIndex2 = (int)run2.StartIndex;
								int endIndex = (int)run2.EndIndex;
								int2 int6 = span[num8];
								meshData.SetSubMesh(submeshLevels.Length, new SubMeshDescriptor
								{
									baseVertex = 0,
									firstVertex = int6.x,
									vertexCount = int6.y - int6.x,
									bounds = bounds3,
									indexStart = startIndex2,
									indexCount = endIndex - startIndex2
								});
								ref NativeList<int> reference = ref submeshLevels;
								int value4 = (int)run2.OriginalID;
								reference.Add(in value4);
							}
						}
					}
					else
					{
						meshData.subMeshCount = 1;
						meshData.SetSubMesh(0, new SubMeshDescriptor
						{
							baseVertex = 0,
							firstVertex = 0,
							vertexCount = nativeList.Length,
							bounds = bounds3,
							indexStart = 0,
							indexCount = num2
						});
					}
					float3 GetUV(int materialLevel)
					{
						if (materialLevel >= uvArray.Length)
						{
							return defaultUv;
						}
						return uvArray[materialLevel];
					}
				}
				finally
				{
					NativeMethods.manifold_destruct_meshgl(ptr);
				}
			}
		}

		[BurstCompile]
		private struct ManifoldToNativeMeshJob : IJob
		{
			[ReadOnly]
			[NativeDisableUnsafePtrRestriction]
			public unsafe NativeMethods.Manifold* manifoldPtr;

			public NativeMesh outMesh;

			public ulong submeshMask;

			unsafe void IJob.Execute()
			{
				NativeMesh nativeMesh = outMesh;
				nativeMesh.Clear();
				NativeMethods.Manifold* m = manifoldPtr;
				NativeMethods.MeshGL* ptr = NativeMethods.manifold_get_meshgl_w_normals(UnsafeUtility.Malloc((long)(ulong)NativeMethods.manifold_meshgl_size(), sizeof(IntPtr), Allocator.Temp), m, Vertex.OffsetOfNormal());
				int length = (int)(uint)NativeMethods.manifold_meshgl_vert_properties_length(ptr);
				nativeMesh.Vertices.Length = length;
				NativeMethods.manifold_meshgl_vert_properties(nativeMesh.Vertices.AsArray().GetUnsafePtr(), ptr);
				Span<MeshGLBase.Run> dest = stackalloc MeshGLBase.Run[GetRunDataLength(ptr)];
				GetRunData(ptr, dest);
				nativeMesh.Runs.EnsureCapacity(dest.Length);
				bool flag = false;
				for (int i = 0; i < dest.Length; i++)
				{
					if ((submeshMask & (ulong)(1L << (int)dest[i].OriginalID)) == 0L)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					int num = (int)(uint)NativeMethods.manifold_meshgl_tri_length(ptr);
					nativeMesh.Triangles.Length = num / 3;
					NativeMethods.manifold_meshgl_tri_verts(nativeMesh.Triangles.AsArray().GetUnsafePtr(), ptr);
					for (int j = 0; j < dest.Length; j++)
					{
						MeshGLBase.Run run = dest[j];
						nativeMesh.Runs.AddNoResize(new NativeMesh.TriangleRun
						{
							MaterialId = (int)run.OriginalID,
							StartTriangles = (int)run.StartIndex / 3
						});
					}
					return;
				}
				Span<MeshGLBase.Run> span = stackalloc MeshGLBase.Run[dest.Length];
				int num2 = 0;
				uint num3 = 0u;
				for (int k = 0; k < dest.Length; k++)
				{
					if ((submeshMask & (ulong)(1L << (int)dest[k].OriginalID)) != 0L)
					{
						span[num2++] = dest[k];
						num3 += dest[k].EndIndex - dest[k].StartIndex;
					}
				}
				int length2 = (int)(uint)NativeMethods.manifold_meshgl_tri_length(ptr);
				NativeArray<uint> nativeArray = new NativeArray<uint>(length2, Allocator.Temp);
				NativeMethods.manifold_meshgl_tri_verts(nativeArray.GetUnsafePtr(), ptr);
				nativeMesh.Triangles.Length = (int)(num3 / 3);
				NativeArray<uint> nativeArray2 = nativeMesh.Triangles.AsArray().Reinterpret<uint>(12);
				int num4 = 0;
				for (int l = 0; l < num2; l++)
				{
					MeshGLBase.Run run2 = span[l];
					int num5 = (int)(run2.EndIndex - run2.StartIndex);
					nativeArray2.GetSubArray(num4, num5).CopyFrom(nativeArray.GetSubArray((int)run2.StartIndex, num5));
					nativeMesh.Runs.Add(new NativeMesh.TriangleRun
					{
						MaterialId = (int)run2.OriginalID,
						StartTriangles = num4 / 3
					});
					num4 += num5;
				}
			}
		}

		public static MeshGL<Vertex> ConvertToMeshGL(Allocator allocator, Mesh mesh, int[] submeshOriginalIDs)
		{
			using Mesh.MeshDataArray meshDataArray = Mesh.AcquireReadOnlyMeshData(mesh);
			return ConvertToMeshGL(allocator, meshDataArray[0], submeshOriginalIDs);
		}

		public static MeshGL<Vertex> ConvertToMeshGL(Allocator allocator, Mesh.MeshData meshData, int[] submeshOriginalIDs)
		{
			using NativeArray<Vertex> vertices = GetSimpleVertices(meshData, Allocator.Temp);
			using NativeArray<uint3> triangles = GetTriangles(meshData, Allocator.Temp);
			if (submeshOriginalIDs != null)
			{
				Span<MeshGLBase.Run> runs = stackalloc MeshGLBase.Run[meshData.subMeshCount];
				(int, SubMeshDescriptor, int)[] array = new(int, SubMeshDescriptor, int)[meshData.subMeshCount];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = (i, meshData.GetSubMesh(i), submeshOriginalIDs[i]);
				}
				Array.Sort(array, ((int Index, SubMeshDescriptor Submesh, int OriginalID) a, (int Index, SubMeshDescriptor Submesh, int OriginalID) b) => a.Submesh.indexStart.CompareTo(b.Submesh.indexStart));
				int num = 0;
				for (int num2 = 0; num2 < runs.Length; num2++)
				{
					(int, SubMeshDescriptor, int) tuple = array[num2];
					int item = tuple.Item1;
					int item2 = tuple.Item3;
					SubMeshDescriptor subMesh = meshData.GetSubMesh(item);
					if (subMesh.baseVertex != 0)
					{
						throw new NotSupportedException("baseVertex is not supported in ConvertToMeshGLSimple");
					}
					if (subMesh.indexStart != num)
					{
						throw new NotSupportedException("submeshes must be sequential, non-overlapping with no gaps in indices");
					}
					num = subMesh.indexStart + subMesh.indexCount;
					runs[num2] = new MeshGLBase.Run
					{
						StartIndex = (uint)subMesh.indexStart,
						EndIndex = (uint)num,
						OriginalID = (uint)item2
					};
				}
				return MeshGL<Vertex>.Create(allocator, vertices, triangles, runs);
			}
			return MeshGL<Vertex>.Create(allocator, vertices, triangles);
		}

		public static NativeArray<Vertex> GetSimpleVertices(Mesh.MeshData meshData, Allocator allocator)
		{
			NativeArray<Vertex> nativeArray = new NativeArray<Vertex>(meshData.vertexCount, allocator);
			meshData.CopyAttributeToSlice(VertexAttribute.Position, nativeArray.Slice().SliceWithStride<float3>(0));
			meshData.CopyAttributeToSlice(VertexAttribute.Normal, nativeArray.Slice().SliceWithStride<float3>(4 * (Vertex.OffsetOfNormal() + 3)));
			return nativeArray;
		}

		public unsafe static NativeArray<uint3> GetTriangles(Mesh.MeshData meshData, Allocator allocator)
		{
			NativeArray<uint3> result;
			if (meshData.indexFormat == IndexFormat.UInt32)
			{
				NativeArray<uint> indexData = meshData.GetIndexData<uint>();
				result = new NativeArray<uint3>(indexData.Length / 3, allocator);
				result.Reinterpret<uint>(sizeof(uint3)).CopyFrom(indexData);
			}
			else
			{
				if (meshData.indexFormat != IndexFormat.UInt16)
				{
					throw new NotSupportedException($"Index format {meshData.indexFormat}");
				}
				NativeArray<ushort> indexData2 = meshData.GetIndexData<ushort>();
				result = new NativeArray<uint3>(indexData2.Length / 3, allocator);
				NativeArray<uint> nativeArray = result.Reinterpret<uint>(sizeof(uint3));
				for (int i = 0; i < indexData2.Length; i++)
				{
					nativeArray[i] = indexData2[i];
				}
			}
			return result;
		}

		public static void SafeClear(this Mesh mesh)
		{
			mesh.SetIndexBufferParams(0, mesh.indexFormat);
			mesh.SetVertexBufferParams(0, mesh.GetVertexAttributes());
			mesh.subMeshCount = 0;
		}

		public unsafe static void ConvertManifoldToNativeMesh(Manifold<Vertex> manifold, NativeMesh mesh, ulong submeshMask = ulong.MaxValue)
		{
			new ManifoldToNativeMeshJob
			{
				manifoldPtr = manifold.Ptr,
				outMesh = mesh,
				submeshMask = (submeshMask & 0x7FFFFFFF)
			}.Run();
		}

		public static void ConvertManifoldToPartMesh(Manifold<Vertex> manifold, Mesh mesh, List<float3> materialLevelToUVs, float3 defaultUv, out int[] submeshToLevel, bool makeSubmeshes = true)
		{
			if (manifold.IsEmpty)
			{
				mesh.SafeClear();
				submeshToLevel = Array.Empty<int>();
				return;
			}
			using NativeArray<float3> nativeArray = new NativeArray<float3>(materialLevelToUVs.Count, Allocator.TempJob);
			NativeArray<float3> materialLevelToUV = nativeArray;
			for (int i = 0; i < materialLevelToUV.Length; i++)
			{
				materialLevelToUV[i] = materialLevelToUVs[i];
			}
			ConvertManifoldToPartMesh(manifold, mesh, materialLevelToUV, defaultUv, out submeshToLevel, makeSubmeshes);
		}

		public unsafe static void ConvertManifoldToPartMesh(Manifold<Vertex> manifold, Mesh mesh, NativeArray<float3> materialLevelToUV, float3 defaultUv, out int[] submeshToLevel, bool makeSubmeshes = true)
		{
			Mesh.MeshDataArray meshDataArray = Mesh.AllocateWritableMeshData(mesh);
			using NativeReference<Bounds> meshBounds = new NativeReference<Bounds>(Allocator.TempJob);
			using NativeList<int> submeshLevels = new NativeList<int>(Allocator.TempJob);
			new ManifoldToMeshJob
			{
				partMeshVertexAttributes = PartMeshVertexUVs.PartMeshVertexLayout,
				manifoldPtr = manifold.Ptr,
				meshes = meshDataArray,
				meshIndex = 0,
				makeSubmeshes = makeSubmeshes,
				materialLevelToUV = materialLevelToUV,
				defaultUV = defaultUv,
				meshBounds = meshBounds,
				submeshLevels = submeshLevels
			}.Run();
			Mesh.ApplyAndDisposeWritableMeshData(meshDataArray, mesh);
			mesh.bounds = meshBounds.Value;
			submeshToLevel = submeshLevels.AsArray().ToArray();
		}

		private unsafe static int GetRunData(NativeMethods.MeshGL* meshgl, Span<MeshGLBase.Run> dest)
		{
			int length = dest.Length;
			int num = (int)(uint)NativeMethods.manifold_meshgl_run_index_length(meshgl);
			if (num < length)
			{
				return -1;
			}
			uint num2 = (uint)NativeMethods.manifold_meshgl_tri_length(meshgl);
			uint* ptr = stackalloc uint[length];
			uint* ptr2 = stackalloc uint[num];
			NativeMethods.manifold_meshgl_run_original_id(ptr, meshgl);
			NativeMethods.manifold_meshgl_run_index(ptr2, meshgl);
			for (int i = 0; i < length; i++)
			{
				dest[i] = new MeshGLBase.Run
				{
					StartIndex = ptr2[i],
					EndIndex = ((i + 1 == num) ? num2 : ptr2[i + 1]),
					OriginalID = ptr[i]
				};
			}
			return length;
		}

		private unsafe static int GetRunDataLength(NativeMethods.MeshGL* meshgl)
		{
			return (int)(uint)NativeMethods.manifold_meshgl_run_original_id_length(meshgl);
		}
	}
}
