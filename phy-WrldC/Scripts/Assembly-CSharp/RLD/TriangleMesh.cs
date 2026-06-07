using UnityEngine;

namespace RLD
{
	public static class TriangleMesh
	{
		public static Mesh CreateEqXY(Vector3 centroid, float sideLength, Color color)
		{
			Vector3[] vertices = TriangleMath.CalcEqTriangle3DPoints(centroid, sideLength, Quaternion.identity).ToArray();
			Vector3[] normals = new Vector3[3]
			{
				-Vector3.forward,
				-Vector3.forward,
				-Vector3.forward
			};
			Mesh mesh = new Mesh();
			mesh.vertices = vertices;
			mesh.colors = new Color[3] { color, color, color };
			mesh.normals = normals;
			mesh.SetIndices(new int[3] { 0, 1, 2 }, MeshTopology.Triangles, 0);
			mesh.UploadMeshData(markNoLongerReadable: false);
			return mesh;
		}

		public static Mesh CreateWireEqXY(Vector3 centroid, float sideLength, Color color)
		{
			Vector3[] vertices = TriangleMath.CalcEqTriangle3DPoints(centroid, sideLength, Quaternion.identity).ToArray();
			Mesh mesh = new Mesh();
			mesh.vertices = vertices;
			mesh.colors = new Color[3] { color, color, color };
			mesh.SetIndices(new int[4] { 0, 1, 2, 0 }, MeshTopology.LineStrip, 0);
			mesh.UploadMeshData(markNoLongerReadable: false);
			return mesh;
		}

		public static Mesh CreateRightAngledTriangleXY(Vector3 cornerPosition, float xLength, float yLength, Color color)
		{
			if (xLength < 0.0001f || yLength < 0.0001f)
			{
				return null;
			}
			Vector3[] vertices = new Vector3[3]
			{
				cornerPosition,
				cornerPosition + Vector3.up * xLength,
				cornerPosition + Vector3.right * yLength
			};
			Mesh mesh = new Mesh();
			mesh.vertices = vertices;
			mesh.colors = new Color[3] { color, color, color };
			mesh.SetIndices(new int[3] { 0, 1, 2 }, MeshTopology.Triangles, 0);
			mesh.UploadMeshData(markNoLongerReadable: false);
			return mesh;
		}

		public static Mesh CreateWireRightAngledTriangleXY(Vector3 cornerPosition, float xLength, float yLength, Color color)
		{
			if (xLength < 0.0001f || yLength < 0.0001f)
			{
				return null;
			}
			Vector3[] vertices = new Vector3[3]
			{
				cornerPosition,
				cornerPosition + Vector3.up * xLength,
				cornerPosition + Vector3.right * yLength
			};
			Mesh mesh = new Mesh();
			mesh.vertices = vertices;
			mesh.colors = new Color[3] { color, color, color };
			mesh.SetIndices(new int[4] { 0, 1, 2, 0 }, MeshTopology.LineStrip, 0);
			mesh.UploadMeshData(markNoLongerReadable: false);
			return mesh;
		}
	}
}
