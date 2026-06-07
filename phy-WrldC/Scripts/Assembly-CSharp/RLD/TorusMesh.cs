using System;
using UnityEngine;

namespace RLD
{
	public static class TorusMesh
	{
		public static Mesh CreateCylindricalTorus(Vector3 center, float coreRadius, float tubeHrzRadius, float tubeVertRadius, int numTubeSlices, Color color)
		{
			if (coreRadius < 0.0001f || tubeHrzRadius < 0.0001f || numTubeSlices < 3)
			{
				return null;
			}
			int num = 8;
			int num2 = num * (numTubeSlices + 1);
			Vector3[] array = new Vector3[num2];
			Vector3[] array2 = new Vector3[num2];
			Vector2[] array3 = new Vector2[num2];
			int num3 = 0;
			float num4 = 360f / (float)(numTubeSlices - 1);
			for (int i = 0; i <= numTubeSlices; i++)
			{
				float f = num4 * (float)i * ((float)Math.PI / 180f);
				Vector3 normalized = new Vector3(z: Mathf.Cos(f), x: Mathf.Sin(f), y: 0f).normalized;
				Vector3 vector = center + normalized * coreRadius;
				Vector2 vector2 = (array3[num3] = new Vector2(normalized.x, normalized.z));
				array[num3] = vector + Vector3.up * tubeVertRadius - normalized * tubeHrzRadius;
				array2[num3++] = Vector3.up;
				array3[num3] = vector2;
				array[num3] = vector + Vector3.up * tubeVertRadius + normalized * tubeHrzRadius;
				array2[num3++] = Vector3.up;
				array3[num3] = vector2;
				array[num3] = vector + Vector3.up * tubeVertRadius + normalized * tubeHrzRadius;
				array2[num3++] = normalized;
				array3[num3] = vector2;
				array[num3] = vector - Vector3.up * tubeVertRadius + normalized * tubeHrzRadius;
				array2[num3++] = normalized;
				array3[num3] = vector2;
				array[num3] = vector - Vector3.up * tubeVertRadius + normalized * tubeHrzRadius;
				array2[num3++] = -Vector3.up;
				array3[num3] = vector2;
				array[num3] = vector - Vector3.up * tubeVertRadius - normalized * tubeHrzRadius;
				array2[num3++] = -Vector3.up;
				array3[num3] = vector2;
				array[num3] = vector - Vector3.up * tubeVertRadius - normalized * tubeHrzRadius;
				array2[num3++] = -normalized;
				array3[num3] = vector2;
				array[num3] = vector + Vector3.up * tubeVertRadius - normalized * tubeHrzRadius;
				array2[num3++] = -normalized;
			}
			int num5 = 0;
			int[] array4 = new int[numTubeSlices * 24];
			for (int j = 0; j < numTubeSlices - 1; j++)
			{
				int num6 = j * num;
				array4[num5++] = num6;
				array4[num5++] = num6 + 1;
				array4[num5++] = num6 + 1 + num;
				array4[num5++] = num6;
				array4[num5++] = num6 + 1 + num;
				array4[num5++] = num6 + num;
				num6 += 2;
				array4[num5++] = num6;
				array4[num5++] = num6 + 1;
				array4[num5++] = num6 + 1 + num;
				array4[num5++] = num6;
				array4[num5++] = num6 + 1 + num;
				array4[num5++] = num6 + num;
				num6 += 2;
				array4[num5++] = num6;
				array4[num5++] = num6 + 1;
				array4[num5++] = num6 + 1 + num;
				array4[num5++] = num6;
				array4[num5++] = num6 + 1 + num;
				array4[num5++] = num6 + num;
				num6 += 2;
				array4[num5++] = num6;
				array4[num5++] = num6 + 1;
				array4[num5++] = num6 + 1 + num;
				array4[num5++] = num6;
				array4[num5++] = num6 + 1 + num;
				array4[num5++] = num6 + num;
			}
			Mesh mesh = new Mesh();
			mesh.vertices = array;
			mesh.normals = array2;
			mesh.uv2 = array3;
			mesh.colors = ColorEx.GetFilledColorArray(num2, color);
			mesh.SetIndices(array4, MeshTopology.Triangles, 0);
			mesh.UploadMeshData(markNoLongerReadable: false);
			return mesh;
		}

		public static Mesh CreateTorus(Vector3 center, float coreRadius, float tubeRadius, int numTubeSlices, int numSlices, Color color)
		{
			if (coreRadius < 0.0001f || tubeRadius < 0.0001f || numTubeSlices < 3 || numSlices < 3)
			{
				return null;
			}
			int num = numSlices + 1;
			int num2 = num * (numTubeSlices + 1);
			Vector3[] array = new Vector3[num2];
			Vector3[] array2 = new Vector3[num2];
			int num3 = 0;
			float num4 = 360f / (float)(numSlices - 1);
			float num5 = 360f / (float)(numTubeSlices - 1);
			for (int i = 0; i <= numTubeSlices; i++)
			{
				float f = num5 * (float)i * ((float)Math.PI / 180f);
				float num6 = Mathf.Cos(f);
				float num7 = Mathf.Sin(f);
				Vector3 vector = new Vector3(num7 * coreRadius, 0f, num6 * coreRadius);
				for (int j = 0; j <= numSlices; j++)
				{
					float f2 = num4 * (float)j * ((float)Math.PI / 180f);
					float num8 = Mathf.Cos(f2);
					float num9 = Mathf.Sin(f2);
					Vector3 vector2 = vector;
					vector2.x += num7 * num9 * tubeRadius;
					vector2.y += num8 * tubeRadius;
					vector2.z += num6 * num9 * tubeRadius;
					vector2 += center;
					array[num3] = vector2;
					array2[num3] = (vector2 - center).normalized;
					num3++;
				}
			}
			int num10 = 0;
			int[] array3 = new int[numTubeSlices * numSlices * 6];
			for (int k = 0; k < numTubeSlices; k++)
			{
				for (int l = 0; l < numSlices; l++)
				{
					int num11 = k * num + l;
					array3[num10++] = num11;
					array3[num10++] = num11 + 1;
					array3[num10++] = num11 + num;
					array3[num10++] = num11 + 1;
					array3[num10++] = num11 + 1 + num;
					array3[num10++] = num11 + num;
				}
			}
			Mesh mesh = new Mesh();
			mesh.vertices = array;
			mesh.normals = array2;
			mesh.colors = ColorEx.GetFilledColorArray(num2, color);
			mesh.SetIndices(array3, MeshTopology.Triangles, 0);
			mesh.UploadMeshData(markNoLongerReadable: false);
			return mesh;
		}
	}
}
