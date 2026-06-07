using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	public class DecalInstance
	{
		private float offset;

		public Vector3[] vertexes;

		public Vector3[] normals;

		public Vector4[] tangents;

		public Color32[] colors32;

		public Vector2[] uv;

		public int[] TriangleList;

		public byte[] bonesPerVertex;

		public BoneWeight1[] boneWeights;

		public bool Create(Transform t, Mesh m, Vector3 RayOrigin, UMAMeshData meshData, Plane[] planes)
		{
			return false;
		}

		private bool OnRight(Vector3 vert, Plane[] planes)
		{
			return false;
		}

		private Dictionary<int, List<faceData>> CalculateFaceNormals(Mesh m, UMAMeshData meshData)
		{
			return null;
		}
	}
}
