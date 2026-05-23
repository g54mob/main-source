using System;
using Beans.Unity.Collections;
using Beans.Unity.Mathematics;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Deform
{
	public class NativeMeshData : IDisposable
	{
		public NativeArray<float3> VertexBuffer;

		public NativeArray<float3> NormalBuffer;

		public NativeArray<float4> TangentBuffer;

		public NativeArray<float2> UVBuffer;

		public NativeArray<float4> ColorBuffer;

		public NativeArray<int> IndexBuffer;

		public NativeArray<float3> MaskVertexBuffer;

		public NativeArray<bounds> Bounds;

		public NativeMeshData(Mesh mesh, Allocator allocator = Allocator.Persistent)
		{
			int vertexCount = mesh.vertexCount;
			Vector3[] vertices = mesh.vertices;
			Vector3[] normals = mesh.normals;
			Vector4[] tangents = mesh.tangents;
			Vector2[] uv = mesh.uv;
			Color[] colors = mesh.colors;
			int[] triangles = mesh.triangles;
			Bounds bounds2 = mesh.bounds;
			if (vertices == null || vertices.Length != vertexCount)
			{
				VertexBuffer = new NativeArray<float3>(vertexCount, allocator);
				MaskVertexBuffer = new NativeArray<float3>(vertexCount, allocator);
			}
			else
			{
				VertexBuffer = new NativeArray<float3>(vertexCount, allocator, NativeArrayOptions.UninitializedMemory);
				MaskVertexBuffer = new NativeArray<float3>(vertexCount, allocator, NativeArrayOptions.UninitializedMemory);
				vertices.MemCpy(VertexBuffer);
				vertices.MemCpy(MaskVertexBuffer);
			}
			if (normals == null || normals.Length != vertexCount)
			{
				NormalBuffer = new NativeArray<float3>(vertexCount, allocator);
			}
			else
			{
				NormalBuffer = new NativeArray<float3>(vertexCount, allocator, NativeArrayOptions.UninitializedMemory);
				normals.MemCpy(NormalBuffer);
			}
			if (tangents == null || tangents.Length != vertexCount)
			{
				TangentBuffer = new NativeArray<float4>(vertexCount, allocator);
			}
			else
			{
				TangentBuffer = new NativeArray<float4>(vertexCount, allocator, NativeArrayOptions.UninitializedMemory);
				tangents.MemCpy(TangentBuffer);
			}
			if (uv == null || uv.Length != vertexCount)
			{
				UVBuffer = new NativeArray<float2>(vertexCount, allocator);
			}
			else
			{
				UVBuffer = new NativeArray<float2>(vertexCount, allocator, NativeArrayOptions.UninitializedMemory);
				uv.MemCpy(UVBuffer);
			}
			if (colors == null || colors.Length != vertexCount)
			{
				ColorBuffer = new NativeArray<float4>(vertexCount, allocator);
			}
			else
			{
				ColorBuffer = new NativeArray<float4>(vertexCount, allocator, NativeArrayOptions.UninitializedMemory);
				colors.MemCpy(ColorBuffer);
			}
			if (triangles == null)
			{
				IndexBuffer = new NativeArray<int>(0, allocator);
			}
			else
			{
				IndexBuffer = new NativeArray<int>(triangles.Length, allocator, NativeArrayOptions.UninitializedMemory);
				triangles.MemCpy(IndexBuffer);
			}
			Bounds = new NativeArray<bounds>(1, allocator, NativeArrayOptions.UninitializedMemory);
			Bounds[0] = bounds2;
			vertices?.MemCpy(VertexBuffer);
		}

		public NativeMeshData(ManagedMeshData data, Allocator allocator = Allocator.Persistent)
		{
			VertexBuffer = new NativeArray<float3>(data.Vertices.Length, allocator, NativeArrayOptions.UninitializedMemory);
			NormalBuffer = new NativeArray<float3>(data.Normals.Length, allocator, NativeArrayOptions.UninitializedMemory);
			TangentBuffer = new NativeArray<float4>(data.Tangents.Length, allocator, NativeArrayOptions.UninitializedMemory);
			UVBuffer = new NativeArray<float2>(data.UVs.Length, allocator, NativeArrayOptions.UninitializedMemory);
			ColorBuffer = new NativeArray<float4>(data.Colors.Length, allocator, NativeArrayOptions.UninitializedMemory);
			IndexBuffer = new NativeArray<int>(data.Triangles.Length, allocator, NativeArrayOptions.UninitializedMemory);
			MaskVertexBuffer = new NativeArray<float3>(data.Vertices.Length, allocator, NativeArrayOptions.UninitializedMemory);
			Bounds = new NativeArray<bounds>(1, allocator, NativeArrayOptions.UninitializedMemory);
			DataUtils.CopyManagedToNativeMeshData(data, this, DataFlags.All);
		}

		public void Dispose()
		{
			if (VertexBuffer.IsCreated)
			{
				VertexBuffer.Dispose();
			}
			if (NormalBuffer.IsCreated)
			{
				NormalBuffer.Dispose();
			}
			if (TangentBuffer.IsCreated)
			{
				TangentBuffer.Dispose();
			}
			if (UVBuffer.IsCreated)
			{
				UVBuffer.Dispose();
			}
			if (ColorBuffer.IsCreated)
			{
				ColorBuffer.Dispose();
			}
			if (IndexBuffer.IsCreated)
			{
				IndexBuffer.Dispose();
			}
			if (MaskVertexBuffer.IsCreated)
			{
				MaskVertexBuffer.Dispose();
			}
			if (Bounds.IsCreated)
			{
				Bounds.Dispose();
			}
		}

		public bool HasValidData()
		{
			if (VertexBuffer.IsCreated && NormalBuffer.IsCreated && TangentBuffer.IsCreated && UVBuffer.IsCreated && ColorBuffer.IsCreated && IndexBuffer.IsCreated && MaskVertexBuffer.IsCreated)
			{
				return Bounds.IsCreated;
			}
			return false;
		}
	}
}
