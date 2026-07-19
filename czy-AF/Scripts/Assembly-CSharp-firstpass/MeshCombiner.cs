using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MeshCombiner : MonoBehaviour
{
	public static GameObject Combine(GameObject gameObject)
	{
		GameObject gameObject2 = new GameObject();
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		List<MeshFilter> list = new List<MeshFilter>();
		if ((bool)gameObject.GetComponent<MeshFilter>())
		{
			list.Add(gameObject.GetComponent<MeshFilter>());
		}
		MeshFilter[] componentsInChildren = gameObject.GetComponentsInChildren<MeshFilter>();
		foreach (MeshFilter item in componentsInChildren)
		{
			list.Add(item);
		}
		foreach (MeshFilter item2 in list)
		{
			MeshRenderer component = item2.GetComponent<MeshRenderer>();
			if (!component || !item2.sharedMesh || component.sharedMaterials.Length != item2.sharedMesh.subMeshCount)
			{
				continue;
			}
			for (int j = 0; j < item2.sharedMesh.subMeshCount; j++)
			{
				int num = Contains(arrayList, component.sharedMaterials[j].name);
				if (num == -1)
				{
					arrayList.Add(component.sharedMaterials[j]);
					num = arrayList.Count - 1;
				}
				arrayList2.Add(new ArrayList());
				CombineInstance combineInstance = new CombineInstance
				{
					transform = component.transform.localToWorldMatrix,
					subMeshIndex = j,
					mesh = item2.sharedMesh
				};
				(arrayList2[num] as ArrayList).Add(combineInstance);
			}
		}
		MeshFilter meshFilter = gameObject2.GetComponent<MeshFilter>();
		if (meshFilter == null)
		{
			meshFilter = gameObject2.AddComponent<MeshFilter>();
		}
		MeshRenderer meshRenderer = gameObject2.GetComponent<MeshRenderer>();
		if (meshRenderer == null)
		{
			meshRenderer = gameObject2.AddComponent<MeshRenderer>();
		}
		Mesh[] array = new Mesh[arrayList.Count];
		CombineInstance[] array2 = new CombineInstance[arrayList.Count];
		for (int k = 0; k < arrayList.Count; k++)
		{
			CombineInstance[] combine = (arrayList2[k] as ArrayList).ToArray(typeof(CombineInstance)) as CombineInstance[];
			array[k] = new Mesh();
			array[k].indexFormat = IndexFormat.UInt32;
			array[k].CombineMeshes(combine, mergeSubMeshes: true, useMatrices: true);
			array2[k] = default(CombineInstance);
			array2[k].mesh = array[k];
			array2[k].subMeshIndex = 0;
		}
		meshFilter.sharedMesh = new Mesh();
		meshFilter.sharedMesh.indexFormat = IndexFormat.UInt32;
		meshFilter.sharedMesh.CombineMeshes(array2, mergeSubMeshes: false, useMatrices: false);
		Mesh[] array3 = array;
		for (int i = 0; i < array3.Length; i++)
		{
			_ = array3[i];
		}
		Material[] materials = arrayList.ToArray(typeof(Material)) as Material[];
		meshRenderer.materials = materials;
		foreach (MeshFilter item3 in list)
		{
			_ = item3;
		}
		return gameObject2;
	}

	public static int Contains(ArrayList searchList, string searchName)
	{
		for (int i = 0; i < searchList.Count; i++)
		{
			if (((Material)searchList[i]).name == searchName)
			{
				return i;
			}
		}
		return -1;
	}

	public static void CollapseSharedVertices(Mesh mesh)
	{
	}
}
