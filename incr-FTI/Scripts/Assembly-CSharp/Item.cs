using System;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
	public const ItemType researchItem = ItemType.ResearchTomeGeneral;

	public static NaturalResource NaturalResourceFromItem(ItemType t)
	{
		foreach (NaturalResource value in Enum.GetValues(typeof(NaturalResource)))
		{
			if (t == ItemFromNaturalResource(value))
			{
				return value;
			}
		}
		return NaturalResource.None;
	}

	public static ItemType ItemFromNaturalResource(NaturalResource r)
	{
		return r switch
		{
			NaturalResource.Tree => ItemType.Wood, 
			NaturalResource.AppleTree => ItemType.Apple, 
			NaturalResource.PearTree => ItemType.Pear, 
			NaturalResource.Wheat => ItemType.Grain, 
			NaturalResource.FishSource => ItemType.Fish, 
			NaturalResource.HerbBush => ItemType.Herb, 
			NaturalResource.BerryBush => ItemType.Berries, 
			NaturalResource.CarrotPlant => ItemType.Carrot, 
			NaturalResource.PotatoPlant => ItemType.Potato, 
			NaturalResource.TomatoPlant => ItemType.Tomato, 
			NaturalResource.CottonPlant => ItemType.Cotton, 
			NaturalResource.SugarCane => ItemType.Sugar, 
			NaturalResource.DragonFruitTree => ItemType.DragonFruit, 
			NaturalResource.CactusFruitTree => ItemType.CactusFruit, 
			NaturalResource.Sand => ItemType.Quartz, 
			NaturalResource.Rock => ItemType.Stone, 
			NaturalResource.IronOre => ItemType.IronOre, 
			NaturalResource.CoalOre => ItemType.Coal, 
			NaturalResource.CopperOre => ItemType.CopperOre, 
			NaturalResource.GoldOre => ItemType.GoldOre, 
			NaturalResource.SilverOre => ItemType.SilverOre, 
			NaturalResource.WaterSource => ItemType.Water, 
			NaturalResource.ManaCrystal => ItemType.Mana, 
			NaturalResource.Ruby => ItemType.RedRuby, 
			NaturalResource.Topaz => ItemType.YellowTopaz, 
			NaturalResource.Sapphire => ItemType.BlueSapphire, 
			NaturalResource.Amethyst => ItemType.PurpleAmethyst, 
			_ => ItemType.None, 
		};
	}

	public static bool IsDefaultPhysicalItem(ItemType itemType, bool includePackages = false)
	{
		if (itemType == ItemType.Invalid)
		{
			return false;
		}
		if (itemType >= (ItemType)1000000)
		{
			return true;
		}
		if (itemType >= ItemType.Wood)
		{
			return itemType < ItemType.FilterAnything;
		}
		return false;
	}

	public static bool IsEnabled(ItemType itemType)
	{
		return Crafting.GetCachedItemDef(itemType).enabled;
	}

	public static bool IsFilter(ItemType type)
	{
		if (type >= ItemType.FilterAnything)
		{
			return type < (ItemType)20000;
		}
		return false;
	}

	public static bool IsUpgrade(ItemType type)
	{
		if (type >= (ItemType)20000)
		{
			return type < ItemType.UtilityPopulationSize;
		}
		return false;
	}

	public static bool IsUtility(ItemType type)
	{
		if (type >= ItemType.UtilityPopulationSize)
		{
			return type < (ItemType)40000;
		}
		return false;
	}

	public static bool IsCostTrackedSeparately(ItemType type)
	{
		if (!IsUtility(type))
		{
			return type == ItemType.Worker;
		}
		return true;
	}

	public static bool IsPhysicalUtility(ItemType t)
	{
		if (t != ItemType.UtilitySteamPower && t != ItemType.UtilityRotationalPower)
		{
			return t == ItemType.UtilitySpecifiedItem;
		}
		return true;
	}

	public static bool IsCoinBooster(ItemType type)
	{
		if (type != ItemType.UtilityYellowCoinBoost && type != ItemType.UtilityRedCoinBoost && type != ItemType.UtilityBlueCoinBoost)
		{
			return type == ItemType.UtilityPurpleCoinBoost;
		}
		return true;
	}

	public static bool IsCurrency(ItemType itemType)
	{
		if (itemType >= ItemType.YellowCoin)
		{
			return itemType < ItemType.Worker;
		}
		return false;
	}

	public static bool MatchesFilter(ItemType type, ItemType filter)
	{
		if (type == ItemType.None || type == filter)
		{
			return true;
		}
		if (IsDynamicConsumptionFilter(filter))
		{
			return false;
		}
		switch (filter)
		{
		case ItemType.None:
		case ItemType.FilterAnything:
			return true;
		case ItemType.FilterFuel:
			if (type != ItemType.Coal && type != ItemType.Fertilizer && type != ItemType.Wood)
			{
				return type == ItemType.Magma;
			}
			return true;
		case ItemType.FilterNaturalResource:
			if (type != ItemType.Wood && type != ItemType.Grain && type != ItemType.Apple && type != ItemType.Fish && type != ItemType.Herb && type != ItemType.Berries && type != ItemType.Carrot && type != ItemType.Potato && type != ItemType.Pear && type != ItemType.Tomato && type != ItemType.Cotton && type != ItemType.Sugar && type != ItemType.DragonFruit && type != ItemType.CactusFruit && type != ItemType.Stone && type != ItemType.IronOre && type != ItemType.Coal && type != ItemType.Water && type != ItemType.Mana && type != ItemType.GoldOre && type != ItemType.RedRuby && type != ItemType.GemOrange && type != ItemType.YellowTopaz && type != ItemType.GemGreen && type != ItemType.BlueSapphire && type != ItemType.GemBlue && type != ItemType.PurpleAmethyst)
			{
				return type == ItemType.GemPink;
			}
			return true;
		case ItemType.FilterCurrency:
			return IsCurrency(type);
		case ItemType.FilterHouseCategories:
			return Data.Instance.houseSatisfactionCategories.Contains(type);
		case ItemType.FilterMarketFood:
			return type == ItemType.FilterCategoryBasicFood;
		case ItemType.FilterMarketHardware:
			return type == ItemType.FilterCategoryGeneralHardware;
		case ItemType.FilterMarketGeneralGoods:
			return type == ItemType.FilterCategoryGeneralGoods;
		default:
			switch (filter)
			{
			case ItemType.FilterMarketGeneralGoods:
				return type == ItemType.FilterCategoryGeneralGoods;
			case ItemType.FilterMarketClothing:
				return type == ItemType.FilterCategoryGeneralClothing;
			case ItemType.FilterMarketHospital:
				if (type != ItemType.FilterCategoryMedicineBasic)
				{
					return type == ItemType.FilterCategoryMedicineMagic;
				}
				return true;
			case ItemType.FilterMarketJewelry:
				return type == ItemType.FilterCategorySpecialtyJewelry;
			case ItemType.FilterMarketSpecialtyGoods:
				return type == ItemType.FilterCategorySpecialtyMagic;
			case ItemType.FilterMarketFancyFood:
				return type == ItemType.FilterCategorySpecialtyGourmet;
			case ItemType.FilterMarketKnowledge:
				if (type != ItemType.FilterCategoryKnowledgeBasic)
				{
					return type == ItemType.FilterCategoryKnowledgeMagic;
				}
				return true;
			case ItemType.FilterCategoryConstructionWood:
				if (type != ItemType.Plank)
				{
					return type == ItemType.ReinforcedPlank;
				}
				return true;
			case ItemType.FilterResearchGeneral:
				if (type != ItemType.Paper && type != ItemType.Book)
				{
					return type == ItemType.EnchantedBook;
				}
				return true;
			case ItemType.FilterResearchIndustry:
				if (type != ItemType.ResearchTomeIndustry1 && type != ItemType.ResearchTomeIndustry2)
				{
					return type == ItemType.ResearchTomeIndustry3;
				}
				return true;
			case ItemType.FilterResearchMedicine:
				if (type != ItemType.ResearchTomeNature1 && type != ItemType.ResearchTomeNature2)
				{
					return type == ItemType.ResearchTomeNature3;
				}
				return true;
			case ItemType.FilterResearchMagic:
				if (type != ItemType.ResearchTomeMagic1 && type != ItemType.ResearchTomeMagic2)
				{
					return type == ItemType.ResearchTomeMagic3;
				}
				return true;
			case ItemType.FilterResearchFire:
				if (type != ItemType.ResearchTomeFire1 && type != ItemType.ResearchTomeFire2)
				{
					return type == ItemType.ResearchTomeFire3;
				}
				return true;
			case ItemType.FilterResearchWater:
				if (type != ItemType.ResearchTomeWater1 && type != ItemType.ResearchTomeWater2)
				{
					return type == ItemType.ResearchTomeWater3;
				}
				return true;
			case ItemType.FilterResearchEarth:
				if (type != ItemType.ResearchTomeEarth1 && type != ItemType.ResearchTomeEarth2)
				{
					return type == ItemType.ResearchTomeEarth3;
				}
				return true;
			case ItemType.FilterResearchAir:
				if (type != ItemType.ResearchTomeAir1 && type != ItemType.ResearchTomeAir2)
				{
					return type == ItemType.ResearchTomeAir3;
				}
				return true;
			case ItemType.FilterHarvestableWorker:
				if (type != ItemType.Wood && type != ItemType.Grain && type != ItemType.Fish && type != ItemType.Apple && type != ItemType.Sugar && type != ItemType.Herb && type != ItemType.Berries && type != ItemType.Carrot && type != ItemType.Potato && type != ItemType.Pear && type != ItemType.Tomato && type != ItemType.Cotton && type != ItemType.DragonFruit && type != ItemType.CactusFruit && type != ItemType.Stone && type != ItemType.IronOre && type != ItemType.GoldOre && type != ItemType.Coal)
				{
					return type == ItemType.Water;
				}
				return true;
			case ItemType.FilterHarvestableDrill:
				if (type != ItemType.Stone && type != ItemType.IronOre && type != ItemType.GoldOre && type != ItemType.Coal && type != ItemType.Mana && type != ItemType.RedRuby && type != ItemType.GemOrange && type != ItemType.YellowTopaz && type != ItemType.GemGreen && type != ItemType.BlueSapphire && type != ItemType.GemBlue && type != ItemType.PurpleAmethyst)
				{
					return type == ItemType.GemPink;
				}
				return true;
			case ItemType.FilterCrushable:
				if (type != ItemType.RedRuby && type != ItemType.GemOrange && type != ItemType.YellowTopaz && type != ItemType.GemGreen && type != ItemType.BlueSapphire && type != ItemType.GemBlue && type != ItemType.PurpleAmethyst)
				{
					return type == ItemType.GemPink;
				}
				return true;
			case ItemType.FilterChargedElement:
				if (type != ItemType.PurifiedMana && type != ItemType.PurifiedFire && type != ItemType.PurifiedWater && type != ItemType.PurifiedEarth)
				{
					return type == ItemType.PurifiedAir;
				}
				return true;
			case ItemType.FilterPowerType:
				if (type != ItemType.UtilitySteamPower && type != ItemType.ManaPower && type != ItemType.UtilityElementalFirePower && type != ItemType.UtilityElementalWaterPower && type != ItemType.UtilityElementalEarthPower)
				{
					return type == ItemType.UtilityElementalAirPower;
				}
				return true;
			case ItemType.FilterFluid:
			{
				if (Crafting.cachedItemDefs.TryGetValue(type, out var value3))
				{
					return value3.phase == MatterPhase.Liquid;
				}
				return false;
			}
			case ItemType.FilterCategoryMedicineEthers:
			{
				if (Crafting.cachedItemDefs.TryGetValue(type, out var value2))
				{
					return value2.storageType == StorageType.Ether;
				}
				return false;
			}
			case ItemType.FilterOre:
				if (type != ItemType.IronOre && type != ItemType.Stone && type != ItemType.Coal && type != ItemType.CopperOre && type != ItemType.SilverOre && type != ItemType.GoldOre && type != ItemType.RedRuby && type != ItemType.YellowTopaz && type != ItemType.BlueSapphire && type != ItemType.PurpleAmethyst)
				{
					return type == ItemType.Mana;
				}
				return true;
			case ItemType.FilterLinkableBoosts:
				if (type != ItemType.UtilitySteamBoost && type != ItemType.UtilityElementalFireBoost && type != ItemType.UtilityElementalWaterBoost && type != ItemType.UtilityElementalEarthBoost)
				{
					return type == ItemType.UtilityElementalAirBoost;
				}
				return true;
			case ItemType.FilterPurifiedElement:
				if (type != ItemType.PurifiedMana && type != ItemType.PurifiedFire && type != ItemType.PurifiedWater && type != ItemType.PurifiedEarth && type != ItemType.PurifiedAir && type != ItemType.DepletedAir && type != ItemType.DepletedEarth && type != ItemType.DepletedFire && type != ItemType.DepletedWater)
				{
					return type == ItemType.DepletedMana;
				}
				return true;
			case ItemType.FilterCrushResult:
				if (type != ItemType.FireEther && type != ItemType.WaterEther && type != ItemType.EarthEther && type != ItemType.ManaEther)
				{
					return type == ItemType.AirEther;
				}
				return true;
			case ItemType.FilterEarthShrineRechargeable:
				if (type != ItemType.FilterFarmOutput && type != ItemType.FilterMineOutput)
				{
					return type == ItemType.FilterForesterOutput;
				}
				return true;
			case ItemType.FilterMineOutput:
				if (type != ItemType.Stone && type != ItemType.Coal && type != ItemType.Mana && type != ItemType.IronOre && type != ItemType.RedRuby && type != ItemType.YellowTopaz && type != ItemType.BlueSapphire && type != ItemType.GoldOre)
				{
					return type == ItemType.PurpleAmethyst;
				}
				return true;
			case ItemType.FilterResearch:
				if (type != ItemType.ResearchTomeGeneral && type != ItemType.ResearchTomeIndustry1 && type != ItemType.ResearchTomeIndustry2 && type != ItemType.ResearchTomeIndustry3 && type != ItemType.ResearchTomeMagic1 && type != ItemType.ResearchTomeMagic2)
				{
					return type == ItemType.ResearchTomeMagic3;
				}
				return true;
			case ItemType.FilterFarmOutput:
				if (type != ItemType.Grain && type != ItemType.Herb && type != ItemType.Sugar && type != ItemType.Berries && type != ItemType.Carrot && type != ItemType.Potato && type != ItemType.Tomato && type != ItemType.CactusFruit)
				{
					return type == ItemType.Cotton;
				}
				return true;
			case ItemType.FilterForesterOutput:
				if (type != ItemType.Wood && type != ItemType.Apple && type != ItemType.Pear)
				{
					return type == ItemType.DragonFruit;
				}
				return true;
			case ItemType.FilterDepletedElement:
				if (type != ItemType.DepletedMana && type != ItemType.DepletedAir && type != ItemType.DepletedEarth && type != ItemType.DepletedFire)
				{
					return type == ItemType.DepletedWater;
				}
				return true;
			case ItemType.FilterPlantable:
				if (type != ItemType.Grain && type != ItemType.Herb && type != ItemType.Sugar && type != ItemType.Apple && type != ItemType.Berries && type != ItemType.Carrot && type != ItemType.Potato && type != ItemType.Pear && type != ItemType.Tomato && type != ItemType.Cotton && type != ItemType.DragonFruit && type != ItemType.CactusFruit)
				{
					return type == ItemType.Wood;
				}
				return true;
			case ItemType.FilterRollable:
			{
				if (Crafting.cachedItemDefs.TryGetValue(type, out var value))
				{
					return value.isLooseBulk;
				}
				return false;
			}
			case ItemType.FilterSchoolKnowledge:
				if (type != ItemType.Paper && type != ItemType.Book && type != ItemType.EnchantedBook && type != ItemType.EnchantedBookRed && type != ItemType.EnchantedBookYellow && type != ItemType.EnchantedBookBlue)
				{
					return type == ItemType.EnchantedBookPurple;
				}
				return true;
			default:
				return false;
			}
		}
	}

	public static bool IsDynamicConsumptionFilter(ItemType filter)
	{
		if (filter == ItemType.FilterSellable || filter == ItemType.FilterCategoryConstructionStone)
		{
			return true;
		}
		return false;
	}

	public static bool IsWorkerUnit(ItemType testType)
	{
		if ((uint)(testType - 60000) <= 2u || (uint)(testType - 60005) <= 10u)
		{
			return true;
		}
		return false;
	}

	public static bool IsConveyor(ItemType testType)
	{
		switch (testType)
		{
		case ItemType.RailCart:
		case ItemType.PhysicalItemMover:
		case ItemType.ManaPipeItem:
		case ItemType.SteamTrainEngine:
		case ItemType.Boxcar:
		case ItemType.TankCar:
		case ItemType.HopperCar:
		case ItemType.RailCartWooden:
			return true;
		default:
			return false;
		}
	}

	public static bool IsBoat(ItemType testType)
	{
		if (testType == ItemType.FishingBoat || testType == ItemType.CargoBoat || testType == ItemType.Raft)
		{
			return true;
		}
		return false;
	}

	public static bool IsItemAgent(ItemType testType)
	{
		switch (testType)
		{
		case ItemType.Worker:
		case ItemType.Wagon:
		case ItemType.Harvester:
		case ItemType.FishingBoat:
		case ItemType.Caravan:
		case ItemType.CargoBoat:
		case ItemType.Airship:
		case ItemType.Raft:
			return true;
		default:
			return false;
		}
	}

	public static ItemType Deserialized(string itemString)
	{
		if (string.IsNullOrEmpty(itemString))
		{
			return ItemType.None;
		}
		if (itemString.StartsWith("*"))
		{
			string text = itemString.Remove(0, 1);
			if (int.TryParse(text, out var result))
			{
				text = ((ItemType)Mathf.Abs(result)/*cast due to .constrained prefix*/).ToString();
			}
			if (Enum.IsDefined(typeof(ItemType), text))
			{
				return (ItemType)(0 - (ItemType)Enum.Parse(typeof(ItemType), text));
			}
			Debug.LogError("Unable to parse package " + text);
			return ItemType.None;
		}
		if (int.TryParse(itemString, out var result2))
		{
			return (ItemType)result2;
		}
		if (Enum.IsDefined(typeof(ItemType), itemString))
		{
			return (ItemType)Enum.Parse(typeof(ItemType), itemString);
		}
		Debug.LogError("Unable to parse item " + itemString);
		return ItemType.None;
	}

	public static bool MatchesFilterCache(ItemType type, ItemType filter)
	{
		if (filter == ItemType.None || filter == ItemType.FilterAnything)
		{
			return true;
		}
		if (type == ItemType.None)
		{
			return true;
		}
		if (filter == type)
		{
			return true;
		}
		HashSet<ItemType> hashSet = Crafting.ItemsAndFiltersInRecursiveFilter(filter);
		if (hashSet != null && hashSet.Contains(type))
		{
			return true;
		}
		return false;
	}
}
