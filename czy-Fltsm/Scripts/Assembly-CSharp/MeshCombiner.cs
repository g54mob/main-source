using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MeshCombiner : MonoBehaviour
{
	public static void CombineMeshesInChildren(GameObject parentObject, bool destroyOriginal = true)
	{
		List<GameObject> list = new List<GameObject>();
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		int num9 = 0;
		int num10 = 0;
		int num11 = 0;
		for (int i = 0; i < parentObject.transform.childCount; i++)
		{
			Transform child = parentObject.transform.GetChild(i);
			if (child.gameObject.activeSelf)
			{
				if (child.gameObject.GetComponent<MeshFilter>() != null)
				{
					list.Add(child.gameObject);
				}
				else
				{
					CombineMeshesInChildren(child.gameObject, destroyOriginal);
				}
			}
		}
		if (list.Count == 0)
		{
			return;
		}
		list = list.OrderBy((GameObject x) => x.GetComponent<MeshRenderer>().sharedMaterial.name).ToList();
		List<MeshFilter> list2 = list.Select((GameObject x) => x.GetComponent<MeshFilter>()).ToList();
		List<MeshRenderer> list3 = list.Select((GameObject x) => x.GetComponent<MeshRenderer>()).ToList();
		if (list2.Count != list3.Count)
		{
			return;
		}
		foreach (MeshFilter item in list2)
		{
			if (item.sharedMesh == null)
			{
				return;
			}
			num += item.sharedMesh.vertices.Length;
			num2 += item.sharedMesh.normals.Length;
			num3 += item.sharedMesh.tangents.Length;
			num4 += item.sharedMesh.triangles.Length;
			num5 += item.sharedMesh.uv.Length;
			num6 += item.sharedMesh.colors.Length;
		}
		Vector3[] array = new Vector3[num];
		Vector3[] array2 = new Vector3[num2];
		Vector4[] array3 = new Vector4[num3];
		Vector2[] array4 = new Vector2[num5];
		Color[] array5 = new Color[num6];
		List<List<int>> list4 = new List<List<int>>();
		List<Material> list5 = new List<Material>();
		Material material = null;
		for (int num12 = 0; num12 < list.Count; num12++)
		{
			MeshRenderer meshRenderer = list3[num12];
			MeshFilter meshFilter = list2[num12];
			if (material != meshRenderer.sharedMaterial)
			{
				list5.Add(meshRenderer.sharedMaterial);
				list4.Add(new List<int>());
			}
			Vector3 localPosition = list[num12].transform.localPosition;
			Quaternion rotation = list[num12].transform.rotation;
			Vector3 localScale = list[num12].transform.localScale;
			int[] triangles = meshFilter.sharedMesh.triangles;
			foreach (int num14 in triangles)
			{
				list4.Last().Add(num14 + num7);
			}
			Vector3[] vertices = meshFilter.sharedMesh.vertices;
			for (int num13 = 0; num13 < vertices.Length; num13++)
			{
				Vector3 vector = Vector3.Scale(vertices[num13], localScale);
				vector = rotation * vector;
				array[num7++] = vector + localPosition;
			}
			Vector4[] tangents = meshFilter.sharedMesh.tangents;
			for (int num13 = 0; num13 < tangents.Length; num13++)
			{
				Vector4 vector2 = tangents[num13];
				Vector3 vector3 = rotation * vector2;
				array3[num9++] = new Vector4(vector3.x, vector3.y, vector3.z, vector2.w);
			}
			vertices = meshFilter.sharedMesh.normals;
			foreach (Vector3 vector4 in vertices)
			{
				Vector3 vector5 = rotation * vector4;
				array2[num8++] = vector5;
			}
			Vector2[] uv = meshFilter.sharedMesh.uv;
			foreach (Vector2 vector6 in uv)
			{
				array4[num10++] = vector6;
			}
			Color[] colors = meshFilter.sharedMesh.colors;
			foreach (Color color in colors)
			{
				array5[num11++] = color;
			}
			material = meshRenderer.sharedMaterial;
		}
		Mesh mesh = new Mesh();
		mesh.name = "Combined construction mesh";
		mesh.vertices = array;
		mesh.normals = array2;
		mesh.uv = array4;
		if (array5.Length < array.Length)
		{
			Color white = Color.white;
			PadArray(ref array5, array.Length, white);
		}
		mesh.colors = array5;
		if (array3.Length < array.Length)
		{
			Vector4 one = Vector4.one;
			PadArray(ref array3, array.Length, one);
		}
		mesh.tangents = array3;
		mesh.subMeshCount = list4.Count;
		for (int num15 = 0; num15 < list4.Count; num15++)
		{
			mesh.SetTriangles(list4[num15], num15);
		}
		GameObject obj = new GameObject($"Combined_{parentObject.name}");
		obj.transform.rotation = parentObject.transform.rotation;
		obj.transform.position = parentObject.transform.position;
		obj.transform.parent = parentObject.transform;
		obj.AddComponent<MeshFilter>().sharedMesh = mesh;
		MeshRenderer meshRenderer2 = obj.AddComponent<MeshRenderer>();
		meshRenderer2.sharedMaterials = list5.ToArray();
		meshRenderer2.shadowCastingMode = list3[0].shadowCastingMode;
		if (!destroyOriginal)
		{
			return;
		}
		foreach (GameObject item2 in list)
		{
			UnityEngine.Object.Destroy(item2);
		}
	}

	private static void PadArray<T>(ref T[] array, int size, T paddingValue)
	{
		int num = ((array.Length != 0) ? (array.Length - 1) : 0);
		Array.Resize(ref array, size);
		for (int i = num; i < array.Length; i++)
		{
			array[i] = paddingValue;
		}
	}
}
