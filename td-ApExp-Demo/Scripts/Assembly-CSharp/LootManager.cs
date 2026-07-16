using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class LootManager : MonoBehaviour
{
	public List<WorldLoots> LevelLoots;

	public SerializedDictionary<Rarity, int> CostPerRarity;

	public SerializedDictionary<Rarity, int> CostPerRarityModules;

	[Header("Wagon Weights")]
	[SerializeField]
	[Range(0f, 100f)]
	private float wagon1Weight = 30f;

	[SerializeField]
	[Range(0f, 100f)]
	private float wagon2Weight = 60f;

	[SerializeField]
	[Range(0f, 100f)]
	private float wagon3Weight = 8f;

	[SerializeField]
	[Range(0f, 100f)]
	private float wagon4Weight = 2f;

	[Header("Shop Enhancement Weights")]
	[SerializeField]
	[Range(0f, 10f)]
	private float upgradeWeight = 8f;

	[SerializeField]
	[Range(0f, 10f)]
	private float moduleWeight = 3f;

	[SerializeField]
	[Range(0f, 10f)]
	private float relicWeight = 1f;

	[SerializeField]
	[Range(0f, 10f)]
	private float cannonWeight = 1f;

	private List<CostModifier> costModifiers;

	public static LootManager Instance { get; private set; }

	public float[] WagonWeights => new float[4] { wagon1Weight, wagon2Weight, wagon3Weight, wagon4Weight };

	public float[] ShopWeights => new float[4] { upgradeWeight, moduleWeight, relicWeight, cannonWeight };

	[field: Header("Shop Ammo")]
	[field: SerializeField]
	public int AmmoQuantity1 { get; private set; } = 50;

	[field: SerializeField]
	public int AmmoCost1 { get; private set; } = 100;

	[field: SerializeField]
	public int AmmoQuantity2 { get; private set; } = 250;

	[field: SerializeField]
	public int AmmoCost2 { get; private set; } = 200;

	[field: Header("Shop Hull")]
	[field: SerializeField]
	public int HullQuantity1 { get; private set; } = 10;

	[field: SerializeField]
	public int HullCost1 { get; private set; } = 100;

	[field: SerializeField]
	public int HullQuantity2 { get; private set; } = 25;

	[field: SerializeField]
	public int HullCost2 { get; private set; } = 200;

	[field: Header("Shop Cores")]
	[field: SerializeField]
	public int CoresQuantity { get; private set; } = 1;

	[field: SerializeField]
	public int CoresCost { get; private set; } = 500;

	public float DiscountProbShop1 { get; set; }

	public float DiscountProbShop2 { get; set; }

	public float DiscountProbAmmoAndHull1 { get; set; }

	public float DiscountProbAmmoAndHull2 { get; set; }

	public float DiscountProbWagon { get; set; }

	public float CacheMult { get; set; } = 1f;

	private void Awake()
	{
		Instance = this;
		costModifiers = new List<CostModifier>();
	}

	public void AddCostModifier(float costModifier, ShopItemType itemType)
	{
		CostModifier item = new CostModifier(itemType, costModifier);
		costModifiers.Add(item);
		ShopWindow.Instance.CheckForScrap();
		ShopWindow.Instance.UpdatePrices();
	}

	public int ApplyCostModifier(int cost, ShopItemType itemType)
	{
		float num = 1f;
		foreach (CostModifier costModifier in costModifiers)
		{
			if (costModifier.ItemType == ShopItemType.General || costModifier.ItemType == itemType)
			{
				num += costModifier.Value;
			}
		}
		return Mathf.FloorToInt((float)cost * num);
	}

	public void RemoveCostModifier(float costModifier, ShopItemType itemType)
	{
		if (costModifier == 0f)
		{
			return;
		}
		foreach (CostModifier costModifier2 in costModifiers)
		{
			if (costModifier2.CheckForMatch(itemType, costModifier))
			{
				costModifiers.Remove(costModifier2);
				break;
			}
		}
	}

	public LevelLoot GetLootByLootType(LootType lootType, int zoneIndex)
	{
		return LevelLoots[zoneIndex].Loots.FirstOrDefault((LevelLoot ll) => ll.LootType == lootType);
	}
}
