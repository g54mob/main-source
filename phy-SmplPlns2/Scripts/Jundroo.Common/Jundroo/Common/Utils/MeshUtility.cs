using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace Jundroo.Common.Utils
{
	public static class MeshUtility
	{
		public static Mesh CombineSubmeshes(Mesh mesh)
		{
			NativeArray<Vector2>? v2Array = null;
			NativeArray<Vector3>? v3Array = null;
			NativeArray<Vector4>? v4Array = null;
			NativeArray<Color32>? nativeArray = null;
			NativeArray<int>? nativeArray2 = null;
			NativeArray<ushort>? nativeArray3 = null;
			try
			{
				Mesh mesh2 = new Mesh();
				Mesh.MeshData meshData = Mesh.AcquireReadOnlyMeshData(mesh)[0];
				int vertexCount = meshData.vertexCount;
				v3Array = CreateNativeArray<Vector3>(vertexCount);
				meshData.GetVertices(v3Array.Value);
				mesh2.SetVertices(v3Array.Value);
				if (meshData.HasVertexAttribute(VertexAttribute.Normal))
				{
					meshData.GetNormals(v3Array.Value);
					mesh2.SetNormals(v3Array.Value);
				}
				if (meshData.HasVertexAttribute(VertexAttribute.Tangent))
				{
					NativeArray<Vector4> valueOrDefault = v4Array.GetValueOrDefault();
					if (!v4Array.HasValue)
					{
						valueOrDefault = CreateNativeArray<Vector4>(vertexCount);
						v4Array = valueOrDefault;
					}
					meshData.GetTangents(v4Array.Value);
					mesh2.SetTangents(v4Array.Value);
				}
				if (meshData.HasVertexAttribute(VertexAttribute.Color))
				{
					NativeArray<Color32> valueOrDefault2 = nativeArray.GetValueOrDefault();
					if (!nativeArray.HasValue)
					{
						valueOrDefault2 = CreateNativeArray<Color32>(vertexCount);
						nativeArray = valueOrDefault2;
					}
					meshData.GetColors(nativeArray.Value);
					mesh2.SetColors(nativeArray.Value);
				}
				CopyUVs(VertexAttribute.TexCoord0, 0, vertexCount, meshData, mesh2, ref v2Array, ref v3Array, ref v4Array);
				CopyUVs(VertexAttribute.TexCoord1, 1, vertexCount, meshData, mesh2, ref v2Array, ref v3Array, ref v4Array);
				CopyUVs(VertexAttribute.TexCoord2, 2, vertexCount, meshData, mesh2, ref v2Array, ref v3Array, ref v4Array);
				CopyUVs(VertexAttribute.TexCoord3, 3, vertexCount, meshData, mesh2, ref v2Array, ref v3Array, ref v4Array);
				CopyUVs(VertexAttribute.TexCoord4, 4, vertexCount, meshData, mesh2, ref v2Array, ref v3Array, ref v4Array);
				CopyUVs(VertexAttribute.TexCoord5, 5, vertexCount, meshData, mesh2, ref v2Array, ref v3Array, ref v4Array);
				CopyUVs(VertexAttribute.TexCoord6, 6, vertexCount, meshData, mesh2, ref v2Array, ref v3Array, ref v4Array);
				CopyUVs(VertexAttribute.TexCoord7, 7, vertexCount, meshData, mesh2, ref v2Array, ref v3Array, ref v4Array);
				int num = 0;
				int subMeshCount = mesh.subMeshCount;
				for (int i = 0; i < subMeshCount; i++)
				{
					num += meshData.GetSubMesh(i).indexCount;
				}
				int num2 = 0;
				mesh2.SetIndexBufferParams(num, meshData.indexFormat);
				for (int j = 0; j < subMeshCount; j++)
				{
					int indexCount = meshData.GetSubMesh(j).indexCount;
					if (meshData.indexFormat == IndexFormat.UInt16)
					{
						NativeArray<ushort> valueOrDefault3 = nativeArray3.GetValueOrDefault();
						if (!nativeArray3.HasValue)
						{
							valueOrDefault3 = CreateNativeArray<ushort>(num);
							nativeArray3 = valueOrDefault3;
						}
						meshData.GetIndices(nativeArray3.Value, j);
						mesh2.SetIndexBufferData(nativeArray3.Value, 0, num2, indexCount);
					}
					else if (meshData.indexFormat == IndexFormat.UInt32)
					{
						NativeArray<int> valueOrDefault4 = nativeArray2.GetValueOrDefault();
						if (!nativeArray2.HasValue)
						{
							valueOrDefault4 = CreateNativeArray<int>(num);
							nativeArray2 = valueOrDefault4;
						}
						meshData.GetIndices(nativeArray2.Value, j);
						mesh2.SetIndexBufferData(nativeArray2.Value, 0, num2, indexCount);
					}
					num2 += indexCount;
				}
				mesh2.subMeshCount = 1;
				mesh2.SetSubMesh(0, new SubMeshDescriptor(0, num));
				mesh2.bounds = mesh.bounds;
				return mesh2;
			}
			finally
			{
				v2Array?.Dispose();
				v3Array?.Dispose();
				v4Array?.Dispose();
				nativeArray?.Dispose();
				nativeArray3?.Dispose();
				nativeArray2?.Dispose();
			}
			static void CopyUVs(VertexAttribute va, int channel, int count, Mesh.MeshData meshData2, Mesh m, ref NativeArray<Vector2>? reference2, ref NativeArray<Vector3>? reference3, ref NativeArray<Vector4>? reference)
			{
				if (meshData2.HasVertexAttribute(va))
				{
					switch (meshData2.GetVertexAttributeDimension(va))
					{
					case 2:
					{
						NativeArray<Vector2> valueOrDefault6 = reference2.GetValueOrDefault();
						if (!reference2.HasValue)
						{
							valueOrDefault6 = CreateNativeArray<Vector2>(count);
							reference2 = valueOrDefault6;
						}
						meshData2.GetUVs(channel, reference2.Value);
						m.SetUVs(channel, reference2.Value);
						break;
					}
					case 3:
					{
						NativeArray<Vector3> valueOrDefault7 = reference3.GetValueOrDefault();
						if (!reference3.HasValue)
						{
							valueOrDefault7 = CreateNativeArray<Vector3>(count);
							reference3 = valueOrDefault7;
						}
						meshData2.GetUVs(channel, reference3.Value);
						m.SetUVs(channel, reference3.Value);
						break;
					}
					case 4:
					{
						NativeArray<Vector4> valueOrDefault5 = reference.GetValueOrDefault();
						if (!reference.HasValue)
						{
							valueOrDefault5 = CreateNativeArray<Vector4>(count);
							reference = valueOrDefault5;
						}
						meshData2.GetUVs(channel, reference.Value);
						m.SetUVs(channel, reference.Value);
						break;
					}
					}
				}
			}
			static NativeArray<T> CreateNativeArray<T>(int count) where T : struct
			{
				return new NativeArray<T>(count, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			}
		}
	}
}
