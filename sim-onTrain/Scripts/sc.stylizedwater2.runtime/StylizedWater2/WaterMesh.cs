using System;
using System.Collections.Generic;
using UnityEngine;

namespace StylizedWater2
{
	[Serializable]
	public class WaterMesh
	{
		public enum Shape
		{
			Rectangle = 0,
			Disk = 1
		}

		public Shape shape;

		[Range(10f, 1000f)]
		public float size = 100f;

		public float UVTiling = 1f;

		[Range(1f, 255f)]
		public int subdivisions = 32;

		[Tooltip("Shifts the vertices in a random direction. Definitely use this when using flat shading")]
		[Range(0f, 1f)]
		public float noise;

		private const float BOUNDS_HEIGHT_PADDING = 4f;

		public Mesh Rebuild()
		{
			return shape switch
			{
				Shape.Rectangle => CreatePlane(), 
				Shape.Disk => CreateCircle(), 
				_ => null, 
			};
		}

		public static Mesh Create(Shape shape, float size, int subdivisions, float uvTiling = 1f, float noise = 0f)
		{
			return new WaterMesh
			{
				shape = shape,
				size = size,
				subdivisions = subdivisions,
				UVTiling = uvTiling,
				noise = noise
			}.Rebuild();
		}

		private int GetPointIndex(int c, int x)
		{
			if (c < 0)
			{
				return 0;
			}
			x %= (c + 1) * 6;
			return 3 * c * (c + 1) + x + 1;
		}

		private Mesh CreateCircle()
		{
			Mesh mesh = new Mesh();
			mesh.name = "WaterDisk";
			float num = 1f / (float)subdivisions;
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			List<Vector2> list3 = new List<Vector2>();
			list.Add(Vector3.zero);
			List<int> list4 = new List<int>();
			for (int i = 0; i < subdivisions; i++)
			{
				float num2 = MathF.PI * 2f / (float)((i + 1) * 6);
				for (int j = 0; j < (i + 1) * 6; j++)
				{
					Vector3 vector = new Vector3(Mathf.Sin(num2 * (float)j), 0f, Mathf.Cos(num2 * (float)j));
					UnityEngine.Random.InitState(i + j);
					vector.x += UnityEngine.Random.Range((0f - noise) * 0.01f, noise * 0.01f);
					vector.z -= UnityEngine.Random.Range(noise * 0.01f, (0f - noise) * 0.01f);
					list.Add(vector * (size * 0.5f) * num * (i + 1));
				}
			}
			for (int k = 0; k < list.Count; k++)
			{
				list2.Add(new Vector2(0.5f + list[k].x / size * UVTiling, 0.5f + list[k].z / size * UVTiling));
				list3.Add(new Vector2(0.5f + list[k].x / size, 0.5f + list[k].z / size));
			}
			for (int l = 0; l < subdivisions; l++)
			{
				int m = 0;
				int num3 = 0;
				for (; m < (l + 1) * 6; m++)
				{
					if (m % (l + 1) != 0)
					{
						list4.Add(GetPointIndex(l - 1, num3 + 1));
						list4.Add(GetPointIndex(l - 1, num3));
						list4.Add(GetPointIndex(l, m));
						list4.Add(GetPointIndex(l, m));
						list4.Add(GetPointIndex(l, m + 1));
						list4.Add(GetPointIndex(l - 1, num3 + 1));
						num3++;
					}
					else
					{
						list4.Add(GetPointIndex(l, m));
						list4.Add(GetPointIndex(l, m + 1));
						list4.Add(GetPointIndex(l - 1, num3));
					}
				}
			}
			mesh.SetVertices(list);
			mesh.SetTriangles(list4, 0);
			mesh.RecalculateNormals();
			mesh.RecalculateTangents();
			mesh.SetUVs(0, list2);
			mesh.SetUVs(1, list3);
			mesh.colors = new Color[list.Count];
			mesh.bounds = new Bounds(Vector3.zero, new Vector3(size, 4f, size));
			return mesh;
		}

		private Mesh CreatePlane()
		{
			Mesh mesh = new Mesh();
			mesh.name = "WaterPlane";
			size = Mathf.Max(1f, size);
			int num = subdivisions + 1;
			int num2 = subdivisions + 1;
			int num3 = subdivisions * subdivisions * 6;
			int num4 = num * num2;
			Vector3[] array = new Vector3[num4];
			Vector2[] array2 = new Vector2[num4];
			Vector2[] array3 = new Vector2[num4];
			int[] array4 = new int[num3];
			Vector4[] array5 = new Vector4[num4];
			Vector3[] array6 = new Vector3[num4];
			Vector4 vector = new Vector4(1f, 0f, 0f, -1f);
			int num5 = 0;
			float num6 = size / (float)subdivisions;
			float num7 = size / (float)subdivisions;
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					array[num5] = new Vector3((float)j * num6 - size * 0.5f, 0f, (float)i * num7 - size * 0.5f);
					UnityEngine.Random.InitState(i + j);
					array[num5].x += UnityEngine.Random.Range(0f - noise, noise);
					array[num5].z -= UnityEngine.Random.Range(noise, 0f - noise);
					array5[num5] = vector;
					array2[num5] = new Vector2(0.5f + array[num5].x / size * UVTiling, 0.5f + array[num5].z / size * UVTiling);
					array3[num5] = new Vector2(0.5f + array[num5].x / size, 0.5f + array[num5].z / size);
					array6[num5] = Vector3.up;
					num5++;
				}
			}
			num5 = 0;
			for (int k = 0; k < subdivisions; k++)
			{
				for (int l = 0; l < subdivisions; l++)
				{
					array4[num5] = k * num + l;
					array4[num5 + 1] = (k + 1) * num + l;
					array4[num5 + 2] = k * num + l + 1;
					array4[num5 + 3] = (k + 1) * num + l;
					array4[num5 + 4] = (k + 1) * num + l + 1;
					array4[num5 + 5] = k * num + l + 1;
					num5 += 6;
				}
			}
			mesh.vertices = array;
			mesh.triangles = array4;
			mesh.uv = array2;
			mesh.uv2 = array3;
			mesh.tangents = array5;
			mesh.normals = array6;
			mesh.colors = new Color[array.Length];
			mesh.bounds = new Bounds(Vector3.zero, new Vector3(size, 4f, size));
			return mesh;
		}
	}
}
