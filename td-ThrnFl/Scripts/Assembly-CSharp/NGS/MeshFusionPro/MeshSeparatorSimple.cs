using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace NGS.MeshFusionPro
{
	public class MeshSeparatorSimple
	{
		private const int MAX_UV_CHANNELS = 4;

		private static Dictionary<Mesh, Mesh[]> _meshToSubmeshes;

		private static List<Vector3> _srcVertices;

		private static List<Vector3> _srcNormals;

		private static List<Vector4> _srcTangents;

		private static List<Vector2> _srcUV;

		private static List<int> _triangles;

		private static List<Vector3> _vertices;

		private static List<Vector3> _normals;

		private static List<Vector4> _tangents;

		private static List<Vector2> _uv;

		static MeshSeparatorSimple()
		{
			_meshToSubmeshes = new Dictionary<Mesh, Mesh[]>();
			_srcVertices = new List<Vector3>();
			_srcNormals = new List<Vector3>();
			_srcTangents = new List<Vector4>();
			_srcUV = new List<Vector2>();
			_triangles = new List<int>();
			_vertices = new List<Vector3>();
			_normals = new List<Vector3>();
			_tangents = new List<Vector4>();
			_uv = new List<Vector2>();
		}

		public Mesh GetSubmesh(Mesh source, int submesh)
		{
			if (!_meshToSubmeshes.TryGetValue(source, out var value))
			{
				value = Separate(source);
				_meshToSubmeshes.Add(source, value);
			}
			return value[submesh];
		}

		private Mesh[] Separate(Mesh mesh)
		{
			int subMeshCount = mesh.subMeshCount;
			Mesh[] array = new Mesh[subMeshCount];
			CollectMeshData(mesh);
			for (int i = 0; i < subMeshCount; i++)
			{
				array[i] = CreateFromSubmesh(mesh, i);
			}
			ClearData();
			return array;
		}

		private void CollectMeshData(Mesh mesh)
		{
			mesh.GetVertices(_srcVertices);
			mesh.GetNormals(_srcNormals);
			mesh.GetTangents(_srcTangents);
		}

		private Mesh CreateFromSubmesh(Mesh mesh, int submesh)
		{
			SubMeshDescriptor subMesh = mesh.GetSubMesh(submesh);
			Mesh mesh2 = new Mesh();
			int indexCount = subMesh.indexCount;
			int vertexCount = subMesh.vertexCount;
			int firstVertex = subMesh.firstVertex;
			int num = firstVertex + vertexCount;
			_vertices.Clear();
			_normals.Clear();
			_tangents.Clear();
			mesh.GetIndices(_triangles, submesh);
			for (int i = firstVertex; i < num; i++)
			{
				_vertices.Add(_srcVertices[i]);
				_normals.Add(_srcNormals[i]);
				_tangents.Add(_srcTangents[i]);
			}
			for (int j = 0; j < indexCount; j++)
			{
				_triangles[j] -= firstVertex;
			}
			mesh2.SetVertices(_vertices);
			mesh2.SetNormals(_normals);
			mesh2.SetTangents(_tangents);
			mesh2.SetTriangles(_triangles, 0, calculateBounds: false);
			mesh2.bounds = subMesh.bounds;
			for (int k = 0; k < 4; k++)
			{
				mesh.GetUVs(k, _srcUV);
				if (_srcUV.Count != 0)
				{
					_uv.Clear();
					for (int l = firstVertex; l < num; l++)
					{
						_uv.Add(_srcUV[l]);
					}
					mesh2.SetUVs(k, _uv);
				}
			}
			return mesh2;
		}

		private void ClearData()
		{
			_srcVertices.Clear();
			_srcNormals.Clear();
			_srcTangents.Clear();
			_srcUV.Clear();
			_triangles.Clear();
			_vertices.Clear();
			_normals.Clear();
			_tangents.Clear();
			_uv.Clear();
		}
	}
}
