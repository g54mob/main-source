using System;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : Controller, IComparable<BlockController>
{
	[Header("ID")]
	public int blockID;

	public static int assignID;

	[Header("Location")]
	public int favourVertical;

	public List<CityTile> cityTiles;

	[NonSerialized]
	public float averageDensity;

	[NonSerialized]
	public float averageLandValue;

	public static Comparison<BlockController> LandValueComparison;

	public void Setup(DistrictController newDistrict)
	{
	}

	public void Load(CitySaveData.BlockCitySave data, DistrictController newDistrict)
	{
	}

	public void AddCityTile(CityTile newTile)
	{
	}

	public void UpdateAverageDensity()
	{
	}

	public void UpdateAverageLandValue()
	{
	}

	public int CompareTo(BlockController compare)
	{
		return 0;
	}

	public CitySaveData.BlockCitySave GenerateSaveData()
	{
		return null;
	}
}
