using System.Collections.Generic;
using UnityEngine;

public class FurnitureManager : NoktaSingleton<FurnitureManager>
{
	[SerializeField]
	private List<Transform> m_DefaultLightSpawnPoints;

	public Transform TrashBin;

	private List<FurnitureData> m_FurnituresDatas;

	private Furniture[] m_DefaultFurnitures;

	private void Awake()
	{
	}

	private void LoadSaveProgress()
	{
	}

	public void AddFurniture(FurnitureData furnitureData)
	{
	}

	public void RemoveFurniture(FurnitureData furnitureData)
	{
	}

	private void LoadFurnitureDatas()
	{
	}

	public void SyncCurrentLights_RPC(bool isStoreLightsOpen, bool isStorageLightsOpen)
	{
	}
}
