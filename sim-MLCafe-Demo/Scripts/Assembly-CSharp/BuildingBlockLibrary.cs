using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingBlock Library", menuName = "Libraries/BuildingBlock Library", order = 5)]
public class BuildingBlockLibrary : ScriptableObject
{
	public List<BuildingBlockProperties> buildingBlockProperties = new List<BuildingBlockProperties>();

	public BuildingBlockProperties GetProperties(int index)
	{
		return buildingBlockProperties[index];
	}

	public BuildingBlockProperties GetProperties(string name)
	{
		return buildingBlockProperties.Find((BuildingBlockProperties x) => x.name == name);
	}

	public GameObject GetBlockPrefab(int index)
	{
		return buildingBlockProperties[index].blockPrefab;
	}

	public GameObject GetBlockPrefab(string name)
	{
		return buildingBlockProperties.Find((BuildingBlockProperties x) => x.name == name).blockPrefab;
	}

	public List<LibraryProperty> GetProperties()
	{
		return new List<LibraryProperty>(buildingBlockProperties);
	}
}
