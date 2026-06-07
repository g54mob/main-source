using UnityEngine;

namespace RLD
{
	public static class PyramidMesh
	{
		public static Mesh CreatePyramid(Vector3 baseCenter, float baseWidth, float baseDepth, float height, Color color)
		{
			baseWidth = Mathf.Max(Mathf.Abs(baseWidth), 0.0001f);
			baseDepth = Mathf.Max(Mathf.Abs(baseDepth), 0.0001f);
			height = Mathf.Max(Mathf.Abs(height), 0.0001f);
			float num = baseWidth * 0.5f;
			float num2 = baseDepth * 0.5f;
			Vector3 vector = baseCenter + Vector3.up * height;
			Vector3[] array = new Vector3[16]
			{
				vector,
				baseCenter + Vector3.right * num - Vector3.forward * num2,
				baseCenter - Vector3.right * num - Vector3.forward * num2,
				vector,
				baseCenter + Vector3.right * num + Vector3.forward * num2,
				baseCenter + Vector3.right * num - Vector3.forward * num2,
				vector,
				baseCenter - Vector3.right * num + Vector3.forward * num2,
				baseCenter + Vector3.right * num + Vector3.forward * num2,
				vector,
				baseCenter - Vector3.right * num - Vector3.forward * num2,
				baseCenter - Vector3.right * num + Vector3.forward * num2,
				baseCenter - Vector3.right * num - Vector3.forward * num2,
				baseCenter + Vector3.right * num - Vector3.forward * num2,
				baseCenter + Vector3.right * num + Vector3.forward * num2,
				baseCenter - Vector3.right * num + Vector3.forward * num2
			};
			int[] array2 = new int[18]
			{
				0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
				10, 11, 12, 13, 14, 12, 14, 15
			};
			Vector3[] array3 = new Vector3[array.Length];
			for (int i = 0; i < 4; i++)
			{
				int num3 = array2[i * 3];
				int num4 = array2[i * 3 + 1];
				int num5 = array2[i * 3 + 2];
				Vector3 lhs = array[num4] - array[num3];
				Vector3 rhs = array[num5] - array[num3];
				array3[num5] = (array3[num4] = (array3[num3] = Vector3.Cross(lhs, rhs).normalized));
			}
			array3[array3.Length - 4] = -Vector3.up;
			array3[array3.Length - 3] = -Vector3.up;
			array3[array3.Length - 2] = -Vector3.up;
			array3[array3.Length - 1] = -Vector3.up;
			Mesh mesh = new Mesh();
			mesh.vertices = array;
			mesh.colors = ColorEx.GetFilledColorArray(array.Length, color);
			mesh.normals = array3;
			mesh.SetIndices(array2, MeshTopology.Triangles, 0);
			mesh.UploadMeshData(markNoLongerReadable: false);
			return mesh;
		}

		public static Mesh CreateWirePyramid(Vector3 baseCenter, float baseWidth, float baseDepth, float height, Color color)
		{
			baseWidth = Mathf.Max(Mathf.Abs(baseWidth), 0.0001f);
			baseDepth = Mathf.Max(Mathf.Abs(baseDepth), 0.0001f);
			height = Mathf.Max(Mathf.Abs(height), 0.0001f);
			float num = baseWidth * 0.5f;
			float num2 = baseDepth * 0.5f;
			Vector3[] array = new Vector3[5]
			{
				baseCenter - Vector3.right * num - Vector3.forward * num2,
				baseCenter + Vector3.right * num - Vector3.forward * num2,
				baseCenter + Vector3.right * num + Vector3.forward * num2,
				baseCenter - Vector3.right * num + Vector3.forward * num2,
				baseCenter + Vector3.up * height
			};
			int[] indices = new int[16]
			{
				0, 1, 1, 2, 2, 3, 3, 0, 0, 4,
				1, 4, 2, 4, 3, 4
			};
			Mesh mesh = new Mesh();
			mesh.vertices = array;
			mesh.colors = ColorEx.GetFilledColorArray(array.Length, color);
			mesh.SetIndices(indices, MeshTopology.Lines, 0);
			mesh.UploadMeshData(markNoLongerReadable: false);
			return mesh;
		}
	}
}
