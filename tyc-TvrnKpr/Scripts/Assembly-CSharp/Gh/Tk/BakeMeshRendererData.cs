using UnityEngine;

namespace Gh.Tk
{
	public struct BakeMeshRendererData
	{
		public GameObject GameObject;

		public MeshRenderer Renderer;

		public MeshFilter MeshFilter;

		public int HashCode;

		public BakeMeshRendererData(Transform root, GameObject gameObject, MeshRenderer renderer, MeshFilter meshFilter)
		{
			GameObject = null;
			Renderer = null;
			MeshFilter = null;
			HashCode = 0;
		}

		public static int CalculateHash(Transform rootTransform, GameObject go, MeshFilter mf)
		{
			return 0;
		}
	}
}
