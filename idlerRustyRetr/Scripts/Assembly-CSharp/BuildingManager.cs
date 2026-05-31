using UnityEngine;

[ExecuteInEditMode]
public class BuildingManager : MonoBehaviour
{
	public BuildingSO[] buildCatalog;

	public Decoration[] decorCatalog;

	public House[] houseCatalog;

	public bool savePrefab;

	private void Awake()
	{
		UpdateIndexes();
	}

	private void Update()
	{
		if (!Application.isPlaying)
		{
			UpdateIndexes();
		}
	}

	public void UpdateIndexes()
	{
		for (int i = 0; i < buildCatalog.Length; i++)
		{
			if (buildCatalog[i] != null)
			{
				buildCatalog[i].buildIndexInList = i;
			}
		}
		for (int j = 0; j < decorCatalog.Length; j++)
		{
			if (decorCatalog[j] != null)
			{
				decorCatalog[j].decorId = j;
			}
		}
	}

	public House getHouseOfType(HouseType type)
	{
		for (int i = 0; i < houseCatalog.Length; i++)
		{
			if (houseCatalog[i].houseType == type)
			{
				return houseCatalog[i];
			}
		}
		return null;
	}
}
