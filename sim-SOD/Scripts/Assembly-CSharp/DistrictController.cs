using System;
using System.Collections.Generic;
using UnityEngine;

public class DistrictController : Controller, IComparable<DistrictController>
{
	[Header("ID")]
	public int districtID;

	public static int assignID;

	public string seed;

	[Header("Location")]
	public List<BlockController> blocks;

	public List<CityTile> cityTiles;

	[Header("Details")]
	public DistrictPreset preset;

	public float averageLandValue;

	public List<SocialStatistics.EthnicityFrequency> dominantEthnicities;

	public void Setup(DistrictPreset newPreset)
	{
	}

	public void Load(CitySaveData.DistrictCitySave data)
	{
	}

	public void AddCityTile(CityTile newCityTile)
	{
	}

	public void AddBlock(BlockController newBlock)
	{
	}

	public void PopulateData()
	{
	}

	public void UpdateName()
	{
	}

	public Descriptors.EthnicGroup EthnictiyBasedOnDominance()
	{
		return default(Descriptors.EthnicGroup);
	}

	public int CompareTo(DistrictController otherObject)
	{
		return 0;
	}

	public CitySaveData.DistrictCitySave GenerateSaveData()
	{
		return null;
	}
}
