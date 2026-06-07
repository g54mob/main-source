using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	public class MeshCutterSimpleSTD : IMeshCutter
	{
		private static List<Vector3> _vertices;

		private static List<Vector3> _normals;

		private static List<Vector4> _tangents;

		private static List<int> _triangles;

		private static List<Vector2>[] _uvs;

		private static int _maxUVsCount;

		static MeshCutterSimpleSTD()
		{
			_maxUVsCount = 4;
			_vertices = new List<Vector3>();
			_normals = new List<Vector3>();
			_tangents = new List<Vector4>();
			_triangles = new List<int>();
			_uvs = new List<Vector2>[_maxUVsCount];
			for (int i = 0; i < _maxUVsCount; i++)
			{
				_uvs[i] = new List<Vector2>();
			}
		}

		public void Cut(Mesh mesh, MeshCuttingInfo info)
		{
			Cut(mesh, new MeshCuttingInfo[1] { info });
		}

		public void Cut(Mesh mesh, IList<MeshCuttingInfo> infos)
		{
			ValidateMeshOrThrowException(mesh);
			CollectData(mesh);
			foreach (MeshCuttingInfo item in infos.OrderByDescending((MeshCuttingInfo i) => i.triangleStart))
			{
				RemoveData(item);
				OffsetTriangles(item);
			}
			ApplyDataToMesh(mesh);
			ClearData();
		}

		private void ValidateMeshOrThrowException(Mesh mesh)
		{
			if (mesh == null)
			{
				throw new ArgumentNullException("mesh is null");
			}
			if (mesh.subMeshCount > 1)
			{
				throw new ArgumentException("SimpleMeshCutter::'mesh' should has only 1 submesh");
			}
		}

		private void CollectData(Mesh mesh)
		{
			mesh.GetVertices(_vertices);
			mesh.GetNormals(_normals);
			mesh.GetTangents(_tangents);
			mesh.GetTriangles(_triangles, 0);
			for (int i = 0; i < _maxUVsCount; i++)
			{
				mesh.GetUVs(i, _uvs[i]);
			}
		}

		private void RemoveData(MeshCuttingInfo cuttingInfo)
		{
			int vertexStart = cuttingInfo.vertexStart;
			int vertexCount = cuttingInfo.vertexCount;
			_vertices.RemoveRange(vertexStart, vertexCount);
			if (_normals.Count > 0)
			{
				_normals.RemoveRange(vertexStart, vertexCount);
			}
			if (_tangents.Count > 0)
			{
				_tangents.RemoveRange(vertexStart, vertexCount);
			}
			_triangles.RemoveRange(cuttingInfo.triangleStart, cuttingInfo.triangleCount);
			for (int i = 0; i < _uvs.Length; i++)
			{
				if (_uvs[i].Count > 0)
				{
					_uvs[i].RemoveRange(vertexStart, vertexCount);
				}
			}
		}

		private void OffsetTriangles(MeshCuttingInfo info)
		{
			int vertexCount = info.vertexCount;
			int triangleStart = info.triangleStart;
			int count = _triangles.Count;
			for (int i = triangleStart; i < count; i++)
			{
				_triangles[i] -= vertexCount;
			}
		}

		private void ApplyDataToMesh(Mesh mesh)
		{
			mesh.SetTriangles(_triangles, 0);
			mesh.SetVertices(_vertices);
			mesh.SetNormals(_normals);
			mesh.SetTangents(_tangents);
			for (int i = 0; i < _maxUVsCount; i++)
			{
				if (_uvs[i].Count > 0)
				{
					mesh.SetUVs(i, _uvs[i]);
				}
			}
		}

		private void ClearData()
		{
			_vertices.Clear();
			_normals.Clear();
			_tangents.Clear();
			_triangles.Clear();
			for (int i = 0; i < _maxUVsCount; i++)
			{
				_uvs[i].Clear();
			}
		}
	}
}
