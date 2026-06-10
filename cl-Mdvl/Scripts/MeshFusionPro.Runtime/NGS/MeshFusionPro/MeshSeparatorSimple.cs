using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace NGS.MeshFusionPro
{
	public class MeshSeparatorSimple
	{
		private const int MAX_UV_CHANNELS = 4;

		private static Dictionary<Mesh, Mesh[]> _meshToSubmeshes;

		private static List<int> _srcTriangles;

		private static List<Vector3> _srcVertices;

		private static List<Vector3> _srcNormals;

		private static List<Vector4> _srcTangents;

		private static List<Color32> _srcColors;

		private static List<Vector2> _srcUV;

		static MeshSeparatorSimple()
		{
			_meshToSubmeshes = new Dictionary<Mesh, Mesh[]>();
			_srcTriangles = new List<int>();
			_srcVertices = new List<Vector3>();
			_srcNormals = new List<Vector3>();
			_srcTangents = new List<Vector4>();
			_srcColors = new List<Color32>();
			_srcUV = new List<Vector2>();
		}

		public static void ClearCache()
		{
			_meshToSubmeshes.Clear();
			ClearMeshData();
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
			ClearMeshData();
			return array;
		}

		private void CollectMeshData(Mesh mesh)
		{
			mesh.GetVertices(_srcVertices);
			mesh.GetNormals(_srcNormals);
			mesh.GetTangents(_srcTangents);
			mesh.GetColors(_srcColors);
		}

		private Mesh CreateFromSubmesh(Mesh mesh, int submesh)
		{
			SubMeshDescriptor subMesh = mesh.GetSubMesh(submesh);
			Mesh mesh2 = new Mesh();
			int indexCount = subMesh.indexCount;
			int firstVertex = subMesh.firstVertex;
			int vertexCount = subMesh.vertexCount;
			mesh.GetIndices(_srcTriangles, submesh);
			for (int i = 0; i < indexCount; i++)
			{
				_srcTriangles[i] -= firstVertex;
			}
			mesh2.SetVertices(_srcVertices, firstVertex, vertexCount);
			if (_srcNormals.Count > 0)
			{
				mesh2.SetNormals(_srcNormals, firstVertex, vertexCount);
			}
			if (_srcTangents.Count > 0)
			{
				mesh2.SetTangents(_srcTangents, firstVertex, vertexCount);
			}
			if (_srcColors.Count > 0)
			{
				mesh2.SetColors(_srcColors, firstVertex, vertexCount);
			}
			mesh2.SetTriangles(_srcTriangles, 0, calculateBounds: false);
			mesh2.bounds = subMesh.bounds;
			for (int j = 0; j < 4; j++)
			{
				mesh.GetUVs(j, _srcUV);
				if (_srcUV.Count != 0)
				{
					mesh2.SetUVs(j, _srcUV, firstVertex, vertexCount);
				}
			}
			return mesh2;
		}

		private static void ClearMeshData()
		{
			_srcTriangles?.Clear();
			_srcVertices?.Clear();
			_srcNormals?.Clear();
			_srcTangents?.Clear();
			_srcColors?.Clear();
			_srcUV?.Clear();
		}
	}
}
