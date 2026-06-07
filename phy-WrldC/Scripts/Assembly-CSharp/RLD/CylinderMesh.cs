using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class CylinderMesh
	{
		public static Mesh CreateCylinder(float bottomRadius, float topRadius, float height, int numSlices, int numStacks, int numBottomCapRings, int numTopCapRings, Color color)
		{
			if (bottomRadius < 0.0001f)
			{
				bottomRadius = 0.0001f;
			}
			if (topRadius < 0.0001f)
			{
				topRadius = 0.0001f;
			}
			if (height < 0.0001f)
			{
				height = 0.0001f;
			}
			if (numSlices < 3)
			{
				numSlices = 3;
			}
			if (numStacks < 1)
			{
				numStacks = 1;
			}
			int num = 1;
			bool flag = numBottomCapRings >= num;
			bool flag2 = numTopCapRings >= num;
			int num2 = numStacks + 1;
			int num3 = numSlices + 1;
			int num5;
			int num4 = (num5 = num2 * num3);
			Vector3[] array = new Vector3[num4];
			Vector3[] array2 = new Vector3[num4];
			List<Vector3> list = new List<Vector3>(num4);
			List<Vector3> list2 = new List<Vector3>(num4);
			int num6 = 0;
			Vector3 zero = Vector3.zero;
			Vector3 vector = Vector3.up * height;
			Vector3 up = Vector3.up;
			float num7 = height / (float)numStacks;
			float num8 = 360f / (float)numSlices;
			for (int i = 0; i < num2; i++)
			{
				float num9 = zero.y + (float)i * num7;
				float num10 = Mathf.Lerp(bottomRadius, topRadius, num9 / vector.y);
				for (int j = 0; j < num3; j++)
				{
					float num11 = (float)j * num8;
					Vector3 vector2 = (array2[num6] = new Vector3(Mathf.Cos(num11 * ((float)Math.PI / 180f)), 0f, Mathf.Sin(num11 * ((float)Math.PI / 180f))).normalized);
					array[num6] = zero + num9 * up + vector2 * num10;
					num6++;
				}
			}
			list.AddRange(array);
			list2.AddRange(array2);
			int num12 = 0;
			List<int> list3 = new List<int>(100);
			int[] array3 = new int[numSlices * numStacks * 6];
			for (int k = 0; k < num2 - 1; k++)
			{
				for (int l = 0; l < num3 - 1; l++)
				{
					int num13 = k * num3 + l;
					array3[num12++] = num13;
					array3[num12++] = num13 + num3;
					array3[num12++] = num13 + 1;
					array3[num12++] = num13 + num3;
					array3[num12++] = num13 + num3 + 1;
					array3[num12++] = num13 + 1;
				}
			}
			list3.AddRange(array3);
			if (flag)
			{
				int num14 = numBottomCapRings + 1;
				int num15 = numSlices + 1;
				int num16 = num14 * num15;
				num5 += num16;
				num6 = 0;
				Vector3[] array4 = new Vector3[num16];
				Vector3[] array5 = new Vector3[num16];
				for (int m = 0; m < num14; m++)
				{
					float num17 = Mathf.Lerp(bottomRadius, 0f, (float)m / (float)(num14 - 1));
					for (int n = 0; n < num15; n++)
					{
						float num18 = (float)n * num8;
						Vector3 normalized = new Vector3(Mathf.Cos(num18 * ((float)Math.PI / 180f)), 0f, Mathf.Sin(num18 * ((float)Math.PI / 180f))).normalized;
						array4[num6] = zero + normalized * num17;
						array5[num6] = -up;
						num6++;
					}
				}
				int count = list.Count;
				list.AddRange(array4);
				list2.AddRange(array5);
				num12 = 0;
				int[] array6 = new int[numSlices * numBottomCapRings * 6];
				for (int num19 = 0; num19 < num14 - 1; num19++)
				{
					for (int num20 = 0; num20 < num15 - 1; num20++)
					{
						int num21 = count + num19 * num15 + num20;
						array6[num12++] = num21;
						array6[num12++] = num21 + 1;
						array6[num12++] = num21 + num15;
						array6[num12++] = num21 + num15;
						array6[num12++] = num21 + 1;
						array6[num12++] = num21 + num15 + 1;
					}
				}
				list3.AddRange(array6);
			}
			if (flag2)
			{
				int num22 = numTopCapRings + 1;
				int num23 = numSlices + 1;
				int num24 = num22 * num23;
				num5 += num24;
				num6 = 0;
				Vector3[] array7 = new Vector3[num24];
				Vector3[] array8 = new Vector3[num24];
				for (int num25 = 0; num25 < num22; num25++)
				{
					float num26 = Mathf.Lerp(topRadius, 0f, (float)num25 / (float)(num22 - 1));
					for (int num27 = 0; num27 < num23; num27++)
					{
						float num28 = (float)num27 * num8;
						Vector3 normalized2 = new Vector3(Mathf.Cos(num28 * ((float)Math.PI / 180f)), 0f, Mathf.Sin(num28 * ((float)Math.PI / 180f))).normalized;
						array7[num6] = vector + normalized2 * num26;
						array8[num6] = up;
						num6++;
					}
				}
				int count2 = list.Count;
				list.AddRange(array7);
				list2.AddRange(array8);
				num12 = 0;
				int[] array9 = new int[numSlices * numTopCapRings * 6];
				for (int num29 = 0; num29 < num22 - 1; num29++)
				{
					for (int num30 = 0; num30 < num23 - 1; num30++)
					{
						int num31 = count2 + num29 * num23 + num30;
						array9[num12++] = num31;
						array9[num12++] = num31 + num23;
						array9[num12++] = num31 + 1;
						array9[num12++] = num31 + num23;
						array9[num12++] = num31 + num23 + 1;
						array9[num12++] = num31 + 1;
					}
				}
				list3.AddRange(array9);
			}
			Mesh mesh = new Mesh();
			mesh.vertices = list.ToArray();
			mesh.normals = list2.ToArray();
			mesh.colors = ColorEx.GetFilledColorArray(num5, color);
			mesh.SetIndices(list3.ToArray(), MeshTopology.Triangles, 0);
			mesh.UploadMeshData(markNoLongerReadable: false);
			return mesh;
		}
	}
}
