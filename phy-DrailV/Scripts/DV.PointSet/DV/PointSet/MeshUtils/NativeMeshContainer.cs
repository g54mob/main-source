using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

namespace DV.PointSet.MeshUtils
{
	[NativeContainer]
	public struct NativeMeshContainer : IDisposable
	{
		public struct Vertex
		{
			public float3 pos;

			public float3 normal;

			public float2 uv;
		}

		private static readonly VertexAttributeDescriptor[] VertexAttributeDescriptors = new VertexAttributeDescriptor[3]
		{
			new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 3, 0),
			new VertexAttributeDescriptor(VertexAttribute.Normal),
			new VertexAttributeDescriptor(VertexAttribute.TexCoord0, VertexAttributeFormat.Float32, 2)
		};

		private Allocator m_AllocatorLabel;

		[NativeDisableContainerSafetyRestriction]
		public NativeList<Vertex> vertices;

		[NativeDisableContainerSafetyRestriction]
		public NativeList<int> indices;

		public NativeMeshContainer(Allocator allocator)
		{
			m_AllocatorLabel = allocator;
			vertices = new NativeList<Vertex>(8, allocator);
			indices = new NativeList<int>(8, allocator);
		}

		public void ApplyMesh(Mesh mesh)
		{
			mesh.SetVertexBufferParams(vertices.Length, VertexAttributeDescriptors);
			mesh.SetVertexBufferData(vertices.ToArray(), 0, 0, vertices.Length);
			mesh.SetIndexBufferParams(indices.Length, IndexFormat.UInt32);
			mesh.SetIndexBufferData<int>(indices, 0, 0, indices.Length);
			mesh.subMeshCount = 1;
			mesh.SetSubMesh(0, new SubMeshDescriptor(0, indices.Length));
			mesh.RecalculateBounds();
		}

		public void LoadMesh(Mesh mesh)
		{
			Clear();
			Vector3[] array = mesh.vertices;
			int[] triangles = mesh.triangles;
			Vector3[] normals = mesh.normals;
			Vector2[] uv = mesh.uv;
			for (int i = 0; i < array.Length; i++)
			{
				vertices.Add(new Vertex
				{
					pos = array[i],
					normal = normals[i],
					uv = uv[i]
				});
			}
			for (int j = 0; j < triangles.Length; j++)
			{
				indices.Add(triangles[j]);
			}
		}

		public void Clear()
		{
			vertices.Clear();
			indices.Clear();
		}

		public void Dispose()
		{
			vertices.Dispose();
			indices.Dispose();
		}
	}
}
