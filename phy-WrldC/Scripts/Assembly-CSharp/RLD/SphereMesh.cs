using System;
using UnityEngine;

namespace RLD
{
	public static class SphereMesh
	{
		public static Mesh CreateSphere(float radius, int numSlices, int numStacks, Color color)
		{
			if (radius < 0.0001f || numSlices < 3 || numStacks < 2)
			{
				return null;
			}
			int num = numStacks + 1;
			int num2 = numSlices + 1;
			int num3 = num * num2;
			Vector3[] array = new Vector3[num3];
			Vector3[] array2 = new Vector3[num3];
			int num4 = 0;
			float num5 = 360f / (float)(num2 - 1);
			for (int i = 0; i < num; i++)
			{
				float f = (float)Math.PI * (float)i / (float)(num - 1);
				float num6 = Mathf.Cos(f);
				float num7 = Mathf.Sin(f);
				for (int j = 0; j < num2; j++)
				{
					float f2 = num5 * (float)j * ((float)Math.PI / 180f);
					Vector3 vector = Vector3.right * Mathf.Sin(f2) + Vector3.forward * Mathf.Cos(f2);
					array[num4] = vector * num7 * radius + Vector3.up * num6 * radius;
					array2[num4] = Vector3.Normalize(array[num4]);
					num4++;
				}
			}
			int num8 = 0;
			int[] array3 = new int[numSlices * numStacks * 6];
			for (int k = 0; k < num - 1; k++)
			{
				for (int l = 0; l < num2 - 1; l++)
				{
					int num9 = k * num2 + l;
					array3[num8++] = num9;
					array3[num8++] = num9 + num2;
					array3[num8++] = num9 + num2 + 1;
					array3[num8++] = num9 + num2 + 1;
					array3[num8++] = num9 + 1;
					array3[num8++] = num9;
				}
			}
			Mesh mesh = new Mesh();
			mesh.vertices = array;
			mesh.normals = array2;
			mesh.colors = ColorEx.GetFilledColorArray(num3, color);
			mesh.SetIndices(array3, MeshTopology.Triangles, 0);
			mesh.UploadMeshData(markNoLongerReadable: false);
			return mesh;
		}
	}
}
