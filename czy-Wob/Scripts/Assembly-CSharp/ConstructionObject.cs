using System.Collections.Generic;
using UnityEngine;

public class ConstructionObject : MonoBehaviour
{
	private List<Renderer> rendererKeyList = new List<Renderer>();

	private Dictionary<Renderer, Material[]> defaultMaterialDict = new Dictionary<Renderer, Material[]>();

	public void SetMaterials(Material newMat)
	{
		if (newMat == null)
		{
			if (defaultMaterialDict.Count != 0)
			{
				RestoreMaterials();
			}
			return;
		}
		if (defaultMaterialDict.Count == 0)
		{
			StoreDefaultMaterials();
		}
		for (int i = 0; i < rendererKeyList.Count; i++)
		{
			rendererKeyList[i].materials = new Material[1] { newMat };
		}
	}

	public void RestoreMaterials()
	{
		if (defaultMaterialDict.Count == 0)
		{
			return;
		}
		for (int i = 0; i < rendererKeyList.Count; i++)
		{
			if (rendererKeyList[i] != null)
			{
				rendererKeyList[i].materials = defaultMaterialDict[rendererKeyList[i]];
			}
		}
		rendererKeyList.Clear();
		defaultMaterialDict.Clear();
	}

	private void StoreDefaultMaterials()
	{
		Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>();
		foreach (Renderer renderer in componentsInChildren)
		{
			rendererKeyList.Add(renderer);
			defaultMaterialDict[renderer] = renderer.materials;
		}
	}
}
