using Beans.Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace Deform
{
	public static class DataUtils
	{
		public static bool CopyManagedToNativeMeshData(ManagedMeshData managed, NativeMeshData native, DataFlags dataFlags)
		{
			bool flag = true;
			if (!managed.HasValidData())
			{
				flag = false;
				Debug.LogError("Cannot copy data as the managed data is invalid");
			}
			if (!native.HasValidData())
			{
				Debug.LogError("Cannot copy data as the native data is invalid");
				flag = false;
			}
			if (!flag)
			{
				return false;
			}
			if ((dataFlags & DataFlags.Vertices) != DataFlags.None)
			{
				managed.Vertices.MemCpy(native.VertexBuffer);
			}
			if ((dataFlags & DataFlags.Normals) != DataFlags.None)
			{
				managed.Normals.MemCpy(native.NormalBuffer);
			}
			if ((dataFlags & DataFlags.MaskVertices) != DataFlags.None)
			{
				managed.Vertices.MemCpy(native.MaskVertexBuffer);
			}
			if ((dataFlags & DataFlags.Tangents) != DataFlags.None)
			{
				managed.Tangents.MemCpy(native.TangentBuffer);
			}
			if ((dataFlags & DataFlags.UVs) != DataFlags.None)
			{
				managed.UVs.MemCpy(native.UVBuffer);
			}
			if ((dataFlags & DataFlags.Colors) != DataFlags.None)
			{
				managed.Colors.MemCpy(native.ColorBuffer);
			}
			if ((dataFlags & DataFlags.Triangles) != DataFlags.None)
			{
				managed.Triangles.MemCpy(native.IndexBuffer);
			}
			if ((dataFlags & DataFlags.Bounds) != DataFlags.None)
			{
				native.Bounds[0] = managed.Bounds;
			}
			return true;
		}

		public static bool CopyToNativeData(this ManagedMeshData from, NativeMeshData to, DataFlags dataFlags)
		{
			return CopyManagedToNativeMeshData(from, to, dataFlags);
		}

		public static bool CopyNativeDataToManagedData(ManagedMeshData managed, NativeMeshData native, DataFlags dataFlags)
		{
			bool flag = true;
			if (!managed.HasValidData())
			{
				flag = false;
				Debug.LogError("Cannot copy data as the managed data is invalid");
			}
			if (!native.HasValidData())
			{
				Debug.LogError("Cannot copy data as the native data is invalid");
				flag = false;
			}
			if (!flag)
			{
				return false;
			}
			if ((dataFlags & DataFlags.Vertices) != DataFlags.None)
			{
				native.VertexBuffer.MemCpy(managed.Vertices);
			}
			if ((dataFlags & DataFlags.Normals) != DataFlags.None)
			{
				native.NormalBuffer.MemCpy(managed.Normals);
			}
			if ((dataFlags & DataFlags.Tangents) != DataFlags.None)
			{
				native.TangentBuffer.MemCpy(managed.Tangents);
			}
			if ((dataFlags & DataFlags.UVs) != DataFlags.None)
			{
				native.UVBuffer.MemCpy(managed.UVs);
			}
			if ((dataFlags & DataFlags.Colors) != DataFlags.None)
			{
				native.ColorBuffer.MemCpy(managed.Colors);
			}
			if ((dataFlags & DataFlags.Triangles) != DataFlags.None)
			{
				native.IndexBuffer.CopyTo(managed.Triangles);
			}
			if ((dataFlags & DataFlags.Bounds) != DataFlags.None)
			{
				managed.Bounds = native.Bounds[0];
			}
			return true;
		}

		public static bool CopyToManagedData(this NativeMeshData from, ManagedMeshData to, DataFlags dataFlags)
		{
			return CopyNativeDataToManagedData(to, from, dataFlags);
		}

		public static bool CopyNativeDataToNativeData(NativeMeshData from, NativeMeshData to, DataFlags dataFlags)
		{
			if (!to.HasValidData() || !from.HasValidData())
			{
				Debug.LogError("Cannot copy data as some of it is invalid");
				return false;
			}
			if ((dataFlags & DataFlags.Vertices) != DataFlags.None)
			{
				from.VertexBuffer.CopyTo(to.VertexBuffer);
			}
			if ((dataFlags & DataFlags.Normals) != DataFlags.None)
			{
				from.NormalBuffer.CopyTo(to.NormalBuffer);
			}
			if ((dataFlags & DataFlags.MaskVertices) != DataFlags.None)
			{
				from.MaskVertexBuffer.CopyTo(to.MaskVertexBuffer);
			}
			if ((dataFlags & DataFlags.Tangents) != DataFlags.None)
			{
				from.TangentBuffer.CopyTo(to.TangentBuffer);
			}
			if ((dataFlags & DataFlags.UVs) != DataFlags.None)
			{
				from.UVBuffer.CopyTo(to.UVBuffer);
			}
			if ((dataFlags & DataFlags.Colors) != DataFlags.None)
			{
				from.ColorBuffer.CopyTo(to.ColorBuffer);
			}
			if ((dataFlags & DataFlags.Triangles) != DataFlags.None)
			{
				from.IndexBuffer.CopyTo(to.IndexBuffer);
			}
			if ((dataFlags & DataFlags.Bounds) != DataFlags.None)
			{
				from.Bounds.CopyTo(to.Bounds);
			}
			return true;
		}

		public static bool CopyToNativeData(this NativeMeshData from, NativeMeshData to, DataFlags dataFlags)
		{
			return CopyNativeDataToNativeData(from, to, dataFlags);
		}

		public static bool CopyManagedDataToMesh(ManagedMeshData from, Mesh to, DataFlags dataFlags)
		{
			if (!from.HasValidData())
			{
				Debug.LogError("Cannot copy data as some of it is invalid");
				return false;
			}
			if (to == null)
			{
				Debug.LogError("Cannot copy data to null mesh");
				return false;
			}
			if ((dataFlags & DataFlags.Vertices) != DataFlags.None)
			{
				to.vertices = from.Vertices;
			}
			if ((dataFlags & DataFlags.Normals) != DataFlags.None)
			{
				to.normals = from.Normals;
			}
			if ((dataFlags & DataFlags.Tangents) != DataFlags.None)
			{
				to.tangents = from.Tangents;
			}
			if ((dataFlags & DataFlags.UVs) != DataFlags.None)
			{
				to.uv = from.UVs;
			}
			if ((dataFlags & DataFlags.Colors) != DataFlags.None)
			{
				to.colors = from.Colors;
			}
			if ((dataFlags & DataFlags.Triangles) != DataFlags.None)
			{
				to.triangles = from.Triangles;
			}
			if ((dataFlags & DataFlags.Bounds) != DataFlags.None)
			{
				to.bounds = from.Bounds;
			}
			return true;
		}

		public static bool CopyToMesh(ManagedMeshData from, Mesh to, DataFlags dataFlags)
		{
			return CopyManagedDataToMesh(from, to, dataFlags);
		}

		public static bool CopyNativeDataToMesh(NativeMeshData from, Mesh to, DataFlags dataFlags)
		{
			if (!from.HasValidData())
			{
				Debug.LogError("Cannot copy data as some of it is invalid");
				return false;
			}
			if (to == null)
			{
				Debug.LogError("Cannot copy data to null mesh");
				return false;
			}
			if ((dataFlags & DataFlags.Vertices) != DataFlags.None)
			{
				to.SetVertices(from.VertexBuffer);
			}
			if ((dataFlags & DataFlags.Normals) != DataFlags.None)
			{
				to.SetNormals(from.NormalBuffer);
			}
			if ((dataFlags & DataFlags.Tangents) != DataFlags.None)
			{
				to.SetTangents(from.TangentBuffer);
			}
			if ((dataFlags & DataFlags.UVs) != DataFlags.None)
			{
				to.SetUVs(0, from.UVBuffer);
			}
			if ((dataFlags & DataFlags.Colors) != DataFlags.None)
			{
				to.SetColors(from.ColorBuffer);
			}
			if ((dataFlags & DataFlags.Triangles) != DataFlags.None)
			{
				for (int i = 0; i < to.subMeshCount; i++)
				{
					SubMeshDescriptor subMesh = to.GetSubMesh(i);
					to.SetIndices(from.IndexBuffer, subMesh.indexStart, subMesh.indexCount, subMesh.topology, i, calculateBounds: false, subMesh.baseVertex);
				}
			}
			if ((dataFlags & DataFlags.Bounds) != DataFlags.None)
			{
				to.bounds = from.Bounds[0];
			}
			return true;
		}

		public static bool CopyToMesh(this NativeMeshData from, Mesh to, DataFlags dataFlags)
		{
			return CopyNativeDataToMesh(from, to, dataFlags);
		}
	}
}
