using UnityEngine;

public class TerrainMaterialChanger : MonoBehaviour
{
	public Material material;

	public float basemapDistance = 300f;

	public float pixelError = 20f;

	public float detailDistance = 80f;

	public float detailDensity = 0.3f;

	public void ChangeMaterials()
	{
		Terrain[] componentsInChildren = GetComponentsInChildren<Terrain>();
		Terrain[] array = componentsInChildren;
		foreach (Terrain terrain in array)
		{
			terrain.materialTemplate = material;
			if (material != null && material.enableInstancing)
			{
				terrain.drawInstanced = true;
			}
		}
		Debug.Log($"Changed {componentsInChildren.Length} terrain materials to {material.name}");
	}

	public void ChangeBasemapDistance()
	{
		Terrain[] componentsInChildren = GetComponentsInChildren<Terrain>();
		Terrain[] array = componentsInChildren;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].basemapDistance = basemapDistance;
		}
		Debug.Log($"Set basemap distance to {basemapDistance} for {componentsInChildren.Length} terrains");
	}

	public void ChangePixelError()
	{
		Terrain[] componentsInChildren = GetComponentsInChildren<Terrain>();
		Terrain[] array = componentsInChildren;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].heightmapPixelError = pixelError;
		}
		Debug.Log($"Set pixel error to {pixelError} for {componentsInChildren.Length} terrains");
	}

	public void ChangeDetailDistance()
	{
		Terrain[] componentsInChildren = GetComponentsInChildren<Terrain>();
		Terrain[] array = componentsInChildren;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].detailObjectDistance = detailDistance;
		}
		Debug.Log($"Set detail distance to {detailDistance} for {componentsInChildren.Length} terrains");
	}

	public void ChangeDetailDensity()
	{
		Terrain[] componentsInChildren = GetComponentsInChildren<Terrain>();
		Terrain[] array = componentsInChildren;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].detailObjectDensity = detailDensity;
		}
		Debug.Log($"Set detail density to {detailDensity} for {componentsInChildren.Length} terrains");
	}

	public void ApplyAllSettings()
	{
		Terrain[] componentsInChildren = GetComponentsInChildren<Terrain>();
		Terrain[] array = componentsInChildren;
		foreach (Terrain terrain in array)
		{
			terrain.basemapDistance = basemapDistance;
			terrain.heightmapPixelError = pixelError;
			terrain.detailObjectDistance = detailDistance;
			terrain.detailObjectDensity = detailDensity;
			if (material != null)
			{
				terrain.materialTemplate = material;
				if (material.enableInstancing)
				{
					terrain.drawInstanced = true;
				}
			}
		}
		Debug.Log($"Applied all settings to {componentsInChildren.Length} terrains");
	}

	public void ClearAllTerrainDetails()
	{
		Terrain[] componentsInChildren = GetComponentsInChildren<Terrain>();
		int num = 0;
		Terrain[] array = componentsInChildren;
		for (int i = 0; i < array.Length; i++)
		{
			TerrainData terrainData = array[i].terrainData;
			if (!(terrainData == null))
			{
				int detailWidth = terrainData.detailWidth;
				int detailHeight = terrainData.detailHeight;
				for (int j = 0; j < terrainData.detailPrototypes.Length; j++)
				{
					int[,] details = new int[detailWidth, detailHeight];
					terrainData.SetDetailLayer(0, 0, j, details);
					num++;
				}
			}
		}
		Debug.Log($"Cleared {num} detail layers from {componentsInChildren.Length} terrains (all grass and details removed)");
	}
}
