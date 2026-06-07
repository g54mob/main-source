using UnityEngine;

namespace RLD
{
	public static class QuadMesh
	{
		public static Mesh CreateQuadXZ(float width, float depth, Color color)
		{
			if (width < 0.0001f)
			{
				return null;
			}
			if (depth < 0.0001f)
			{
				return null;
			}
			float num = width * 0.5f;
			float num2 = depth * 0.5f;
			Vector3[] vertices = new Vector3[4]
			{
				-Vector3.right * num - Vector3.forward * num2,
				-Vector3.right * num + Vector3.forward * num2,
				Vector3.right * num + Vector3.forward * num2,
				Vector3.right * num - Vector3.forward * num2
			};
			Vector3[] normals = new Vector3[4]
			{
				Vector3.up,
				Vector3.up,
				Vector3.up,
				Vector3.up
			};
			Vector2[] uv = new Vector2[4]
			{
				Vector2.zero,
				new Vector2(0f, 1f),
				new Vector2(1f, 1f),
				new Vector2(1f, 0f)
			};
			Mesh mesh = new Mesh();
			mesh.vertices = vertices;
			mesh.normals = normals;
			mesh.uv = uv;
			mesh.colors = ColorEx.GetFilledColorArray(4, color);
			mesh.SetIndices(new int[6] { 0, 1, 2, 2, 3, 0 }, MeshTopology.Triangles, 0);
			mesh.UploadMeshData(markNoLongerReadable: false);
			return mesh;
		}

		public static Mesh CreateQuadXY(float width, float height, Color color)
		{
			if (width < 0.0001f)
			{
				return null;
			}
			if (height < 0.0001f)
			{
				return null;
			}
			float num = width * 0.5f;
			float num2 = height * 0.5f;
			Vector3[] vertices = new Vector3[4]
			{
				-Vector3.right * num - Vector3.up * num2,
				-Vector3.right * num + Vector3.up * num2,
				Vector3.right * num + Vector3.up * num2,
				Vector3.right * num - Vector3.up * num2
			};
			Vector3[] normals = new Vector3[4]
			{
				-Vector3.forward,
				-Vector3.forward,
				-Vector3.forward,
				-Vector3.forward
			};
			Vector2[] uv = new Vector2[4]
			{
				Vector2.zero,
				new Vector2(0f, 1f),
				new Vector2(1f, 1f),
				new Vector2(1f, 0f)
			};
			Mesh mesh = new Mesh();
			mesh.vertices = vertices;
			mesh.normals = normals;
			mesh.uv = uv;
			mesh.colors = ColorEx.GetFilledColorArray(4, color);
			mesh.SetIndices(new int[6] { 0, 1, 2, 2, 3, 0 }, MeshTopology.Triangles, 0);
			mesh.UploadMeshData(markNoLongerReadable: false);
			return mesh;
		}

		public static Mesh CreateWireQuadXY(Vector3 center, Vector2 size, Color color)
		{
			Vector2 vector = size * 0.5f;
			Vector3[] vertices = new Vector3[4]
			{
				center - Vector3.right * vector.x - Vector3.up * vector.y,
				center - Vector3.right * vector.x + Vector3.up * vector.y,
				center + Vector3.right * vector.x + Vector3.up * vector.y,
				center + Vector3.right * vector.x - Vector3.up * vector.y
			};
			int[] indices = new int[8] { 0, 1, 1, 2, 2, 3, 3, 0 };
			Mesh mesh = new Mesh();
			mesh.vertices = vertices;
			mesh.colors = ColorEx.GetFilledColorArray(4, color);
			mesh.SetIndices(indices, MeshTopology.Lines, 0);
			mesh.UploadMeshData(markNoLongerReadable: false);
			return mesh;
		}
	}
}
