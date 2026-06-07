using System.Collections.Generic;
using UnityEngine;

public static class MeshExtension
{
	private class Vertices
	{
		private List<Vector3> verts;

		private List<Vector2> uv1;

		private List<Vector2> uv2;

		private List<Vector2> uv3;

		private List<Vector2> uv4;

		private List<Vector3> normals;

		private List<Vector4> tangents;

		private List<Color32> colors;

		private List<BoneWeight> boneWeights;

		public Vertices()
		{
		}

		public Vertices(Mesh aMesh)
		{
		}

		private List<T> CreateList<T>(T[] aSource)
		{
			return null;
		}

		private void Copy<T>(ref List<T> aDest, List<T> aSource, int aIndex)
		{
		}

		public int Add(Vertices aOther, int aIndex)
		{
			return 0;
		}

		public void AssignTo(Mesh aTarget)
		{
		}
	}

	public static Mesh GetSubmesh(this Mesh aMesh, int aSubMeshIndex)
	{
		return null;
	}
}
