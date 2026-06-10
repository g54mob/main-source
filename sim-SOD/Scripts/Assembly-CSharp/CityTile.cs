using System;
using System.Collections.Generic;
using UnityEngine;

public class CityTile : Controller, IComparable<CityTile>
{
	[Header("Location")]
	public Vector2Int cityCoord;

	public DistrictController district;

	public int districtID;

	public BlockController block;

	public int blockID;

	public NewBuilding building;

	public List<NewTile> outsideTiles;

	public bool isInPlayerVicinity;

	public bool playerPresent;

	[Header("Details")]
	public BuildingPreset.Density density;

	public BuildingPreset.LandValue landValue;

	public void Setup(Vector2Int newCoord)
	{
	}

	public void LoadTileOnly(CitySaveData.CityTileCitySave data)
	{
	}

	public void SetDensity(BuildingPreset.Density newDensity)
	{
	}

	public void SetLandVlaue(BuildingPreset.LandValue newLandvalue)
	{
	}

	public void AddOutsideTile(NewTile newTile)
	{
	}

	public int CompareTo(CityTile compare)
	{
		return 0;
	}

	public void SetPlayerInVicinity(bool val)
	{
	}

	public void SetPlayerPresentOnGroundmap(bool val)
	{
	}

	public CitySaveData.CityTileCitySave GenerateSaveData()
	{
		return null;
	}
}
