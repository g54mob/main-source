using UnityEngine;

namespace RLD
{
	public static class LineMesh
	{
		public static Mesh CreateCoordSystemAxesLines(float axisLength, Color color)
		{
			if (axisLength < 0.0001f)
			{
				return null;
			}
			Vector3[] vertices = new Vector3[4]
			{
				Vector3.zero,
				Vector3.right * axisLength,
				Vector3.up * axisLength,
				Vector3.forward * axisLength
			};
			int[] indices = new int[6] { 0, 1, 0, 2, 0, 3 };
			Mesh mesh = new Mesh();
			mesh.vertices = vertices;
			mesh.colors = ColorEx.GetFilledColorArray(4, color);
			mesh.SetIndices(indices, MeshTopology.Lines, 0);
			mesh.UploadMeshData(markNoLongerReadable: false);
			return mesh;
		}

		public static Mesh CreateLine(Vector3 startPoint, Vector3 endPoint, Color color)
		{
			Mesh mesh = new Mesh();
			mesh.vertices = new Vector3[2] { startPoint, endPoint };
			mesh.colors = ColorEx.GetFilledColorArray(2, color);
			mesh.SetIndices(new int[2] { 0, 1 }, MeshTopology.Lines, 0);
			mesh.UploadMeshData(markNoLongerReadable: false);
			return mesh;
		}
	}
}
