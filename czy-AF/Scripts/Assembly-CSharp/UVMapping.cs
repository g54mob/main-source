using System.Collections.Generic;
using UnityEngine;

public class UVMapping : MonoBehaviour
{
	public static void BoxUV(Mesh mesh, Transform transform)
	{
		Matrix4x4 localToWorldMatrix = transform.localToWorldMatrix;
		Vector3[] vertices = mesh.vertices;
		Vector3[] normals = mesh.normals;
		Vector2[] uv = mesh.uv;
		Vector3[] array = new Vector3[vertices.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = localToWorldMatrix.MultiplyPoint(vertices[i]);
		}
		List<Vector3> list = new List<Vector3>(vertices.Length);
		List<Vector3> list2 = new List<Vector3>(vertices.Length);
		List<Vector2> list3 = new List<Vector2>(vertices.Length);
		List<List<int>> list4 = new List<List<int>>();
		Dictionary<int, int[]> dictionary = new Dictionary<int, int[]>();
		for (int j = -3; j <= 3; j++)
		{
			if (j != 0)
			{
				int[] array2 = new int[vertices.Length];
				for (int k = 0; k < array2.Length; k++)
				{
					array2[k] = -1;
				}
				dictionary.Add(j, array2);
			}
		}
		bool flag = true;
		for (int l = 0; l < mesh.subMeshCount; l++)
		{
			Material material = transform.GetComponent<MeshRenderer>().sharedMaterials[l];
			int[] triangles = mesh.GetTriangles(l);
			list4.Add(new List<int>());
			for (int m = 0; m < triangles.Length; m += 3)
			{
				int num = triangles[m];
				int num2 = triangles[m + 1];
				int num3 = triangles[m + 2];
				int boxDir = GetBoxDir(TriangleNormal(array[num], array[num2], array[num3]));
				for (int n = 0; n < 3; n++)
				{
					int num4 = triangles[m + n];
					if (dictionary[boxDir][num4] < 0)
					{
						Vector2 boxUV = GetBoxUV(array[num4], boxDir);
						dictionary[boxDir][num4] = list.Count;
						list.Add(vertices[num4]);
						list2.Add(normals[num4]);
						if (material != null && material.HasInteger("_Overwrite") && material.GetInt("_Overwrite") == 1)
						{
							list3.Add(uv[num4]);
						}
						else
						{
							list3.Add(boxUV);
						}
					}
					list4[l].Add(dictionary[boxDir][num4]);
				}
			}
		}
		if (flag)
		{
			mesh.vertices = list.ToArray();
			mesh.normals = list2.ToArray();
			mesh.uv = list3.ToArray();
			for (int num5 = 0; num5 < list4.Count; num5++)
			{
				mesh.SetTriangles(list4[num5].ToArray(), num5);
			}
		}
	}

	public static Vector3 TriangleNormal(Vector3 a, Vector3 b, Vector3 c)
	{
		return Vector3.Cross(b - a, c - a).normalized;
	}

	public static int GetBoxDir(Vector3 v)
	{
		float num = Mathf.Abs(v.x);
		float num2 = Mathf.Abs(v.y);
		float num3 = Mathf.Abs(v.z);
		if (num > num2 && num > num3)
		{
			if (!(v.x < 0f))
			{
				return 1;
			}
			return -1;
		}
		if (num2 > num3)
		{
			if (!(v.y < 0f))
			{
				return 2;
			}
			return -2;
		}
		if (!(v.z < 0f))
		{
			return 3;
		}
		return -3;
	}

	public static Vector2 GetBoxUV(Vector3 vertex, int boxDir)
	{
		switch (boxDir)
		{
		case -1:
		case 1:
			return new Vector2(vertex.z * Mathf.Sign(boxDir), vertex.y);
		case -2:
		case 2:
			return new Vector2(vertex.x, vertex.z * Mathf.Sign(boxDir));
		default:
			return new Vector2(vertex.x * (0f - Mathf.Sign(boxDir)), vertex.y);
		}
	}
}
