using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Dreamteck
{
	public class TS_Mesh
	{
		public Vector3[] vertices;

		public Vector3[] normals;

		public Vector4[] tangents;

		public Color[] colors;

		public Vector2[] uv;

		public Vector2[] uv2;

		public Vector2[] uv3;

		public Vector2[] uv4;

		public int[] triangles;

		public List<int[]> subMeshes;

		public TS_Bounds bounds;

		public IndexFormat indexFormat;

		public bool hasUpdate;

		private int[] _submeshTrisCount;

		private int[] _submeshOffsets;

		public int vertexCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public TS_Mesh()
		{
		}

		public TS_Mesh(Mesh mesh)
		{
		}

		public void Clear()
		{
		}

		public void CreateFromMesh(Mesh mesh)
		{
		}

		public void Combine(List<TS_Mesh> combineMeshes)
		{
		}

		public void AddMeshes(List<TS_Mesh> addedMeshes)
		{
		}

		public static TS_Mesh Copy(TS_Mesh input)
		{
			return null;
		}

		public void Absorb(TS_Mesh input)
		{
		}

		public void WriteMesh(ref Mesh input)
		{
		}
	}
}
