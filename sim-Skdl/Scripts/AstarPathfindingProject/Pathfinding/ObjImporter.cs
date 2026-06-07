using UnityEngine;

namespace Pathfinding
{
	public class ObjImporter
	{
		private struct meshStruct
		{
			public Vector3[] vertices;

			public Vector3[] normals;

			public Vector2[] uv;

			public int[] triangles;

			public Vector3[] faceData;

			public string fileName;
		}

		public static Mesh ImportFile(string filePath)
		{
			return null;
		}

		private static meshStruct createMeshStruct(string filename)
		{
			return default(meshStruct);
		}

		private static void populateMeshStruct(ref meshStruct mesh)
		{
		}
	}
}
