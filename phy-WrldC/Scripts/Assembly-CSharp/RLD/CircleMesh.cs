using System;
using UnityEngine;

namespace RLD
{
	public static class CircleMesh
	{
		public static Mesh CreateCircleXY(float circleRadius, int numBorderPoints, Color color)
		{
			if (circleRadius < 0.0001f || numBorderPoints < 4)
			{
				return null;
			}
			int num = numBorderPoints + 1;
			int num2 = numBorderPoints - 1;
			Vector3[] array = new Vector3[numBorderPoints + 1];
			Vector3[] array2 = new Vector3[array.Length];
			int[] array3 = new int[num2 * 3];
			int num3 = 0;
			array[0] = Vector3.zero;
			float num4 = 360f / (float)(numBorderPoints - 1);
			for (int i = 0; i < numBorderPoints; i++)
			{
				float f = num4 * (float)i * ((float)Math.PI / 180f);
				int num5 = i + 1;
				array[num5] = new Vector3(Mathf.Sin(f) * circleRadius, Mathf.Cos(f) * circleRadius, 0f);
				array2[num5] = Vector3.forward;
			}
			for (int j = 1; j < num - 1; j++)
			{
				array3[num3++] = 0;
				array3[num3++] = j;
				array3[num3++] = j + 1;
			}
			Mesh mesh = new Mesh();
			mesh.vertices = array;
			mesh.colors = ColorEx.GetFilledColorArray(array.Length, color);
			mesh.normals = array2;
			mesh.SetIndices(array3, MeshTopology.Triangles, 0);
			mesh.UploadMeshData(markNoLongerReadable: false);
			return mesh;
		}

		public static Mesh CreateWireCircleXY(float circleRadius, int numBorderPoints, Color color)
		{
			if (circleRadius < 0.0001f || numBorderPoints < 4)
			{
				return null;
			}
			Vector3[] array = new Vector3[numBorderPoints];
			int[] array2 = new int[numBorderPoints];
			float num = 360f / (float)(numBorderPoints - 1);
			for (int i = 0; i < numBorderPoints; i++)
			{
				float f = num * (float)i * ((float)Math.PI / 180f);
				array[i] = new Vector3(Mathf.Sin(f) * circleRadius, Mathf.Cos(f) * circleRadius, 0f);
				array2[i] = i;
			}
			Mesh mesh = new Mesh();
			mesh.vertices = array;
			mesh.colors = ColorEx.GetFilledColorArray(numBorderPoints, color);
			mesh.SetIndices(array2, MeshTopology.LineStrip, 0);
			mesh.UploadMeshData(markNoLongerReadable: false);
			return mesh;
		}
	}
}
