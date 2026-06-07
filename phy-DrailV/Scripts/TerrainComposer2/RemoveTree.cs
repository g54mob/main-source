using TerrainComposer2;
using UnityEngine;

public class RemoveTree : MonoBehaviour
{
	public bool removeTree;

	public int index;

	public GameObject prefab;

	private void Update()
	{
		if (removeTree)
		{
			removeTree = false;
			RemoveTreeAtIndex(index);
		}
	}

	private void RemoveTreeAtIndex(int index)
	{
		TerrainData terrainData = TC_Area2D.current.terrainAreas[0].terrains[0].terrain.terrainData;
		prefab = terrainData.treePrototypes[0].prefab;
		TreeInstance treeInstance = terrainData.GetTreeInstance(index);
		float heightScale = treeInstance.heightScale;
		float widthScale = treeInstance.widthScale;
		Vector3 position = treeInstance.position;
		position.Scale(terrainData.size);
		position -= new Vector3(1024f, 0f, 1024f);
		float y = treeInstance.rotation * 57.29578f;
		treeInstance.heightScale = 0f;
		treeInstance.widthScale = 0f;
		terrainData.SetTreeInstance(index, treeInstance);
		Object.Instantiate(prefab, position, Quaternion.Euler(0f, y, 0f)).transform.localScale = new Vector3(widthScale, heightScale, widthScale);
		this.index++;
	}
}
