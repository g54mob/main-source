using System;
using UnityEngine;

[CreateAssetMenu]
public class BuildingSO : ScriptableObject
{
	[Serializable]
	public struct BotUpgrade
	{
		public int level;

		public int sPPrice;

		public int bFPrice;
	}

	public string buildName;

	public BuildingType buildType;

	public Vector2Int size;

	public int constructionTime;

	[Space]
	public int spareParts;

	public float sparePartsCoef = 1f;

	public int sparePartsStartIncrease;

	[Space]
	public int biofuel;

	public float biofuelCoef = 1f;

	public int biofuelStartIncrease;

	[Space]
	public GameObject prefab;

	public Sprite buildImage;

	[Header("Range cursor")]
	public int rangeSize;

	[Header("Description")]
	public string buildDesc;

	public string extraInfo;

	public int buildIndexInList;

	[Header("Fossil cost")]
	public bool hasFossilCost;

	public int fossilCost;

	public float fossilCoef = 3f;

	public int fossilStartIncrease = 1;

	[Header("Speed upgrades")]
	public int speedFrost = 2;

	public int speedUpgradeBasePriceSP = 100;

	public float speedUpgradeCoefficientSP = 1f;

	public int speedUpgradeBasePriceBF = 3;

	public float speedUpgradeCoefficientBF = 1f;

	public BotUpgrade[] speedUpgrade;

	[Header("Capacity upgrades")]
	public int capacityFrost = 2;

	public int capacityUpgradeBasePriceSP = 100;

	public float capacityUpgradeCoefficientSP = 1f;

	public int capacityUpgradeBasePriceBF = 3;

	public float capacityUpgradeCoefficientBF = 1f;

	public BotUpgrade[] capacityUpgrade;
}
