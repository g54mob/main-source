using UnityEngine;

namespace CTS.Utilities
{
	public static class MeshUtility
	{
		public static Mesh GetQuad(Vector3 scale, Quaternion rotation)
		{
			Matrix4x4 matrix4x = Matrix4x4.TRS(Vector3.zero, rotation, scale);
			Vector3[] array = new Vector3[4]
			{
				new Vector3(-0.5f, -0.5f, 0f),
				new Vector3(0.5f, -0.5f, 0f),
				new Vector3(-0.5f, 0.5f, 0f),
				new Vector3(0.5f, 0.5f, 0f)
			};
			int[] triangles = new int[6] { 0, 1, 2, 2, 1, 3 };
			Vector3[] array2 = new Vector3[4]
			{
				new Vector3(0f, 0f, 1f),
				new Vector3(0f, 0f, 1f),
				new Vector3(0f, 0f, 1f),
				new Vector3(0f, 0f, 1f)
			};
			for (int i = 0; i < array.Length; i++)
			{
				Vector3 point = array[i];
				array[i] = matrix4x.MultiplyPoint3x4(point);
				array2[i] = matrix4x.MultiplyVector(array2[i]);
			}
			Mesh mesh = new Mesh();
			mesh.SetVertices(array);
			mesh.SetTriangles(triangles, 0);
			mesh.SetNormals(array2);
			return mesh;
		}
	}
}
