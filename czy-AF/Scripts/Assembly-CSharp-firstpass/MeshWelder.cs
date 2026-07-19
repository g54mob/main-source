using System.Collections.Generic;
using UnityEngine;

public class MeshWelder : MonoBehaviour
{
	public static Mesh WeldVertices(Mesh aMesh, float aMaxDelta = 0.01f)
	{
		Vector3[] vertices = aMesh.vertices;
		Vector3[] normals = aMesh.normals;
		Vector2[] uv = aMesh.uv;
		Dictionary<Vector3, int> dictionary = new Dictionary<Vector3, int>();
		List<int> list = new List<int>();
		int[] array = new int[vertices.Length];
		for (int i = 0; i < vertices.Length; i++)
		{
			if (!dictionary.ContainsKey(vertices[i]))
			{
				dictionary.Add(vertices[i], list.Count);
				array[i] = list.Count;
				list.Add(i);
			}
			else
			{
				array[i] = dictionary[vertices[i]];
			}
		}
		Vector3[] array2 = new Vector3[list.Count];
		Vector3[] array3 = new Vector3[list.Count];
		Vector2[] array4 = new Vector2[list.Count];
		for (int j = 0; j < list.Count; j++)
		{
			int num = list[j];
			array2[j] = vertices[num];
			array3[j] = normals[num];
			array4[j] = uv[num];
		}
		int[] triangles = aMesh.triangles;
		for (int k = 0; k < triangles.Length; k++)
		{
			triangles[k] = array[triangles[k]];
		}
		aMesh.triangles = triangles;
		aMesh.vertices = array2;
		aMesh.normals = array3;
		aMesh.uv = array4;
		aMesh.RecalculateBounds();
		aMesh.RecalculateNormals();
		return aMesh;
	}

	public static void Weld(Mesh mesh)
	{
		float num = 0.01f;
		Vector3[] vertices = mesh.vertices;
		List<Vector3> list = new List<Vector3>();
		List<Vector2> list2 = new List<Vector2>();
		int num2 = 0;
		Vector3[] array = vertices;
		foreach (Vector3 vector in array)
		{
			using (List<Vector3>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext() && !(Vector3.Distance(enumerator.Current, vector) <= num))
				{
					list.Add(vector);
					list2.Add(mesh.uv[num2]);
				}
			}
			num2++;
		}
		int[] triangles = mesh.triangles;
		for (int j = 0; j < triangles.Length; j++)
		{
			for (int k = 0; k < list.Count; k++)
			{
				if (Vector3.Distance(list[k], vertices[triangles[j]]) <= num)
				{
					triangles[j] = k;
					break;
				}
			}
		}
		mesh.Clear();
		mesh.vertices = list.ToArray();
		mesh.triangles = triangles;
		mesh.uv = list2.ToArray();
		mesh.RecalculateBounds();
	}

	public static void WeldVertices(Mesh mesh)
	{
		int[] triangles = mesh.triangles;
		Vector3[] vertices = mesh.vertices;
		Vector2[] uv = mesh.uv;
		Vector3[] normals = mesh.normals;
		List<int> list = new List<int>();
		List<Vector3> list2 = new List<Vector3>();
		List<Vector2> list3 = new List<Vector2>();
		List<Vector3> list4 = new List<Vector3>();
		Dictionary<float, int> dictionary = new Dictionary<float, int>();
		for (int i = 0; i < vertices.Length; i++)
		{
			list2.Add(vertices[i]);
			list3.Add(uv[i]);
			list4.Add(normals[i]);
		}
		for (int j = 0; j < triangles.Length; j += 3)
		{
			Vector3 vector = vertices[triangles[j]];
			Vector3 vector2 = vertices[triangles[j + 1]];
			Vector3 vector3 = vertices[triangles[j + 2]];
			float key = vector.magnitude + vector2.magnitude + vector3.magnitude;
			if (!dictionary.ContainsKey(key))
			{
				dictionary.Add(key, 0);
				continue;
			}
			dictionary[key]++;
			Debug.Log("Duplicate triangle found");
		}
		for (int k = 0; k < triangles.Length; k += 3)
		{
			Vector3 vector4 = vertices[triangles[k]];
			Vector3 vector5 = vertices[triangles[k + 1]];
			Vector3 vector6 = vertices[triangles[k + 2]];
			float key2 = vector4.magnitude + vector5.magnitude + vector6.magnitude;
			if (dictionary.ContainsKey(key2) && dictionary[key2] == 0)
			{
				list.Add(triangles[k]);
				list.Add(triangles[k + 1]);
				list.Add(triangles[k + 2]);
			}
		}
		triangles = list.ToArray();
		vertices = list2.ToArray();
		uv = list3.ToArray();
		normals = list4.ToArray();
		mesh.triangles = triangles;
		mesh.vertices = vertices;
		mesh.uv = uv;
		mesh.normals = normals;
	}

	public static Mesh RemoveDoubles(Mesh mesh)
	{
		int[] triangles = mesh.triangles;
		Vector3[] vertices = mesh.vertices;
		Vector2[] uv = mesh.uv;
		Vector2[] uv2 = mesh.uv2;
		Vector2[] uv3 = mesh.uv3;
		Vector2[] uv4 = mesh.uv4;
		Vector3[] normals = mesh.normals;
		Vector4[] tangents = mesh.tangents;
		Color[] colors = mesh.colors;
		bool flag = mesh.uv.Length != 0;
		bool flag2 = mesh.uv2.Length != 0;
		bool flag3 = mesh.uv3.Length != 0;
		bool flag4 = mesh.uv4.Length != 0;
		bool flag5 = mesh.normals.Length != 0;
		bool flag6 = mesh.tangents.Length != 0;
		bool flag7 = mesh.colors.Length != 0;
		List<int> list = new List<int>();
		List<Vector3> list2 = new List<Vector3>();
		List<Vector2> list3 = new List<Vector2>();
		List<Vector2> list4 = new List<Vector2>();
		List<Vector2> list5 = new List<Vector2>();
		List<Vector2> list6 = new List<Vector2>();
		List<Vector3> list7 = new List<Vector3>();
		List<Vector4> list8 = new List<Vector4>();
		List<Color> list9 = new List<Color>();
		Dictionary<Vector3ToHash, int> dictionary = new Dictionary<Vector3ToHash, int>();
		int num = 0;
		foreach (int num2 in triangles)
		{
			Vector3 vector = vertices[num2];
			Vector3ToHash key = new Vector3ToHash(vector);
			if (!dictionary.ContainsKey(key))
			{
				list2.Add(vector);
				dictionary.Add(key, num);
				if (flag)
				{
					list3.Add(uv[num2]);
				}
				if (flag2)
				{
					list4.Add(uv2[num2]);
				}
				if (flag3)
				{
					list5.Add(uv3[num2]);
				}
				if (flag4)
				{
					list6.Add(uv4[num2]);
				}
				if (flag5)
				{
					list7.Add(normals[num2]);
				}
				if (flag6)
				{
					list8.Add(tangents[num2]);
				}
				if (flag7)
				{
					list9.Add(colors[num2]);
				}
				list.Add(num);
				num++;
			}
			else
			{
				int item = dictionary[key];
				list.Add(item);
			}
		}
		Mesh mesh2 = new Mesh();
		mesh2.vertices = list2.ToArray();
		mesh2.triangles = list.ToArray();
		mesh2.uv = list3.ToArray();
		mesh2.uv2 = list4.ToArray();
		mesh2.uv3 = list5.ToArray();
		mesh2.uv4 = list6.ToArray();
		mesh2.normals = list7.ToArray();
		mesh2.tangents = list8.ToArray();
		mesh2.colors = list9.ToArray();
		mesh2.RecalculateNormals();
		mesh2.RecalculateTangents();
		return mesh2;
	}
}
