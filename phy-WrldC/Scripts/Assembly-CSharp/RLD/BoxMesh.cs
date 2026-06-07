using UnityEngine;

namespace RLD
{
	public static class BoxMesh
	{
		public static Mesh CreateBox(float width, float height, float depth, Color color)
		{
			if (width < 0.0001f)
			{
				return null;
			}
			if (height < 0.0001f)
			{
				return null;
			}
			if (depth < 0.0001f)
			{
				return null;
			}
			float num = width * 0.5f;
			float num2 = height * 0.5f;
			float num3 = depth * 0.5f;
			Vector3[] vertices = new Vector3[24]
			{
				new Vector3(0f - num, 0f - num2, 0f - num3),
				new Vector3(0f - num, num2, 0f - num3),
				new Vector3(num, num2, 0f - num3),
				new Vector3(num, 0f - num2, 0f - num3),
				new Vector3(num, 0f - num2, num3),
				new Vector3(num, num2, num3),
				new Vector3(0f - num, num2, num3),
				new Vector3(0f - num, 0f - num2, num3),
				new Vector3(0f - num, num2, 0f - num3),
				new Vector3(0f - num, num2, num3),
				new Vector3(num, num2, num3),
				new Vector3(num, num2, 0f - num3),
				new Vector3(num, 0f - num2, 0f - num3),
				new Vector3(num, 0f - num2, num3),
				new Vector3(0f - num, 0f - num2, num3),
				new Vector3(0f - num, 0f - num2, 0f - num3),
				new Vector3(0f - num, 0f - num2, num3),
				new Vector3(0f - num, num2, num3),
				new Vector3(0f - num, num2, 0f - num3),
				new Vector3(0f - num, 0f - num2, 0f - num3),
				new Vector3(num, 0f - num2, 0f - num3),
				new Vector3(num, num2, 0f - num3),
				new Vector3(num, num2, num3),
				new Vector3(num, 0f - num2, num3)
			};
			Vector3[] normals = new Vector3[24]
			{
				-Vector3.forward,
				-Vector3.forward,
				-Vector3.forward,
				-Vector3.forward,
				Vector3.forward,
				Vector3.forward,
				Vector3.forward,
				Vector3.forward,
				Vector3.up,
				Vector3.up,
				Vector3.up,
				Vector3.up,
				-Vector3.up,
				-Vector3.up,
				-Vector3.up,
				-Vector3.up,
				-Vector3.right,
				-Vector3.right,
				-Vector3.right,
				-Vector3.right,
				Vector3.right,
				Vector3.right,
				Vector3.right,
				Vector3.right
			};
			int[] indices = new int[36]
			{
				0, 1, 2, 2, 3, 0, 4, 5, 6, 6,
				7, 4, 8, 9, 10, 10, 11, 8, 12, 13,
				14, 14, 15, 12, 16, 17, 18, 18, 19, 16,
				20, 21, 22, 22, 23, 20
			};
			Mesh mesh = new Mesh();
			mesh.vertices = vertices;
			mesh.normals = normals;
			mesh.colors = ColorEx.GetFilledColorArray(24, color);
			mesh.SetIndices(indices, MeshTopology.Triangles, 0);
			mesh.UploadMeshData(markNoLongerReadable: false);
			return mesh;
		}

		public static Mesh CreateWireBox(float width, float height, float depth, Color color)
		{
			if (width < 0.0001f)
			{
				return null;
			}
			if (height < 0.0001f)
			{
				return null;
			}
			if (depth < 0.0001f)
			{
				return null;
			}
			float num = width * 0.5f;
			float num2 = height * 0.5f;
			float num3 = depth * 0.5f;
			Vector3[] vertices = new Vector3[24]
			{
				new Vector3(0f - num, 0f - num2, 0f - num3),
				new Vector3(0f - num, num2, 0f - num3),
				new Vector3(num, num2, 0f - num3),
				new Vector3(num, 0f - num2, 0f - num3),
				new Vector3(num, 0f - num2, num3),
				new Vector3(num, num2, num3),
				new Vector3(0f - num, num2, num3),
				new Vector3(0f - num, 0f - num2, num3),
				new Vector3(0f - num, num2, 0f - num3),
				new Vector3(0f - num, num2, num3),
				new Vector3(num, num2, num3),
				new Vector3(num, num2, 0f - num3),
				new Vector3(num, 0f - num2, 0f - num3),
				new Vector3(num, 0f - num2, num3),
				new Vector3(0f - num, 0f - num2, num3),
				new Vector3(0f - num, 0f - num2, 0f - num3),
				new Vector3(0f - num, 0f - num2, num3),
				new Vector3(0f - num, num2, num3),
				new Vector3(0f - num, num2, 0f - num3),
				new Vector3(0f - num, 0f - num2, 0f - num3),
				new Vector3(num, 0f - num2, 0f - num3),
				new Vector3(num, num2, 0f - num3),
				new Vector3(num, num2, num3),
				new Vector3(num, 0f - num2, num3)
			};
			Vector3[] normals = new Vector3[24]
			{
				-Vector3.forward,
				-Vector3.forward,
				-Vector3.forward,
				-Vector3.forward,
				Vector3.forward,
				Vector3.forward,
				Vector3.forward,
				Vector3.forward,
				Vector3.up,
				Vector3.up,
				Vector3.up,
				Vector3.up,
				-Vector3.up,
				-Vector3.up,
				-Vector3.up,
				-Vector3.up,
				-Vector3.right,
				-Vector3.right,
				-Vector3.right,
				-Vector3.right,
				Vector3.right,
				Vector3.right,
				Vector3.right,
				Vector3.right
			};
			int[] indices = new int[48]
			{
				0, 1, 1, 2, 2, 3, 3, 0, 4, 5,
				5, 6, 6, 7, 7, 4, 8, 9, 9, 10,
				10, 11, 11, 8, 12, 13, 13, 14, 14, 15,
				15, 12, 16, 17, 17, 18, 18, 19, 19, 16,
				20, 21, 21, 22, 22, 23, 23, 20
			};
			Mesh mesh = new Mesh();
			mesh.vertices = vertices;
			mesh.normals = normals;
			mesh.colors = ColorEx.GetFilledColorArray(24, color);
			mesh.SetIndices(indices, MeshTopology.Lines, 0);
			mesh.UploadMeshData(markNoLongerReadable: false);
			return mesh;
		}
	}
}
