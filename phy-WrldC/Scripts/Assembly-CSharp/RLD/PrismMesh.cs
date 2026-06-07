using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class PrismMesh
	{
		public static Mesh CreateTriangularPrism(Vector3 baseCenter, float baseWidth, float baseDepth, float topWidth, float topDepth, float height, Color color)
		{
			baseWidth = Mathf.Max(Mathf.Abs(baseWidth), 0.0001f);
			baseDepth = Mathf.Max(Mathf.Abs(baseDepth), 0.0001f);
			topWidth = Mathf.Max(Mathf.Abs(topWidth), 0.0001f);
			topDepth = Mathf.Max(Mathf.Abs(topDepth), 0.0001f);
			height = Mathf.Max(Mathf.Abs(height), 0.0001f);
			List<Vector3> list = PrismMath.CalcTriangPrismCornerPoints(baseCenter, baseWidth, baseDepth, topWidth, topDepth, height, Quaternion.identity);
			Vector3 vector = list[0];
			Vector3 vector2 = list[1];
			Vector3 vector3 = list[2];
			Vector3 vector4 = list[3];
			Vector3 vector5 = list[5];
			Vector3 vector6 = list[4];
			Vector3[] array = new Vector3[18]
			{
				vector4, vector6, vector5, vector, vector2, vector3, vector, vector4, vector5, vector2,
				vector, vector3, vector6, vector4, vector2, vector5, vector6, vector3
			};
			int[] indices = new int[24]
			{
				0, 1, 2, 3, 4, 5, 6, 7, 8, 8,
				9, 6, 10, 11, 12, 12, 13, 10, 14, 15,
				16, 16, 17, 14
			};
			Vector3 normalized = Vector3.Cross(array[11] - array[10], array[13] - array[10]).normalized;
			Vector3 normalized2 = Vector3.Cross(array[15] - array[14], array[17] - array[14]).normalized;
			Vector3[] normals = new Vector3[18]
			{
				Vector3.up,
				Vector3.up,
				Vector3.up,
				-Vector3.up,
				-Vector3.up,
				-Vector3.up,
				-Vector3.forward,
				-Vector3.forward,
				-Vector3.forward,
				-Vector3.forward,
				normalized,
				normalized,
				normalized,
				normalized,
				normalized2,
				normalized2,
				normalized2,
				normalized2
			};
			Mesh mesh = new Mesh();
			mesh.vertices = array;
			mesh.colors = ColorEx.GetFilledColorArray(array.Length, color);
			mesh.normals = normals;
			mesh.SetIndices(indices, MeshTopology.Triangles, 0);
			mesh.UploadMeshData(markNoLongerReadable: false);
			return mesh;
		}

		public static Mesh CreateWireTriangularPrism(Vector3 baseCenter, float baseWidth, float baseDepth, float topWidth, float topDepth, float height, Color color)
		{
			baseWidth = Mathf.Max(Mathf.Abs(baseWidth), 0.0001f);
			baseDepth = Mathf.Max(Mathf.Abs(baseDepth), 0.0001f);
			topWidth = Mathf.Max(Mathf.Abs(topWidth), 0.0001f);
			topDepth = Mathf.Max(Mathf.Abs(topDepth), 0.0001f);
			height = Mathf.Max(Mathf.Abs(height), 0.0001f);
			List<Vector3> list = PrismMath.CalcTriangPrismCornerPoints(baseCenter, baseWidth, baseDepth, topWidth, topDepth, height, Quaternion.identity);
			Vector3 vector = list[0];
			Vector3 vector2 = list[1];
			Vector3 vector3 = list[2];
			Vector3 vector4 = list[3];
			Vector3 vector5 = list[5];
			Vector3 vector6 = list[4];
			Vector3[] array = new Vector3[6] { vector, vector3, vector2, vector4, vector6, vector5 };
			int[] indices = new int[18]
			{
				0, 1, 1, 2, 2, 0, 3, 4, 4, 5,
				5, 3, 0, 3, 1, 4, 2, 5
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
