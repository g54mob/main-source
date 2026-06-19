using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FMODUnity;
using UnityEngine;

public class BuildingsManager : MonoBehaviour
{
	public List<Building> Buildings;

	public List<Building> ActiveBuildings;

	[SerializeField]
	public EventReference _buildSound;

	public BlueprintHandler BlueprintHandler;

	public EventReference UnlockBuildingSound;

	public BuildingSelectorSymbolHandler BuildingSelectorSymbolHandler;

	[field: SerializeField]
	public float BuildGridScale { get; private set; }

	public static BuildingsManager Instance { get; private set; }

	[field: SerializeField]
	public List<BuildingAsset> UnlockedBuildings { get; private set; }

	public List<Construction> ActiveConstructions { get; private set; }

	public event Action<BuildingAsset> AnnounceUnlockBuilding
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void Initiate()
	{
	}

	public void ShowAllRadii()
	{
	}

	public void HideAllRadii()
	{
	}

	public void AddBuildings(List<Building> buildings)
	{
	}

	public Building GetBuildingPrefab(BuildingAsset asset)
	{
		return null;
	}

	private void OnDestroy()
	{
	}

	public Vector2Int GetMouseBuildGridPosition()
	{
		return default(Vector2Int);
	}

	public void UnlockBuilding(BuildingAsset buildingAsset, bool notify = true)
	{
	}

	public List<BuildingAsset> GetUnlockableBuildings()
	{
		return null;
	}

	public void OnConstructionStarted(Construction construction)
	{
	}

	public void OnConstructionDestroyed(Construction construction)
	{
	}

	public void OnBuildBuilding(Building building)
	{
	}

	public void OnBuildingStart(Building building)
	{
	}

	public void OnBuildingDestroy(Building building)
	{
	}
}
