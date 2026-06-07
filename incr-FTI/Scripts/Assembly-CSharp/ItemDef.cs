using UnityEngine;

public class ItemDef
{
	public ItemType type;

	public bool enabled;

	public Sprite sprite;

	public MatterPhase phase;

	public StorageType storageType;

	public Specialty specialty;

	public bool isLooseBulk;

	public bool isRockResource;

	public BuildingType tradeBuilding;

	public bool countsTowardsCrafting;

	public double xpValue;

	public ItemDef(ItemType t)
	{
		type = t;
		enabled = true;
	}

	public ItemDef DeepCopy()
	{
		return new ItemDef(type)
		{
			enabled = enabled,
			sprite = sprite,
			phase = phase,
			storageType = storageType,
			isLooseBulk = isLooseBulk,
			isRockResource = isRockResource,
			tradeBuilding = tradeBuilding,
			specialty = specialty,
			countsTowardsCrafting = countsTowardsCrafting,
			xpValue = xpValue
		};
	}

	public static double XPForItem(ItemType t)
	{
		switch (t)
		{
		case ItemType.Wood:
		case ItemType.Grain:
		case ItemType.Sugar:
		case ItemType.Apple:
		case ItemType.Berries:
		case ItemType.CactusFruit:
		case ItemType.DragonFruit:
		case ItemType.Carrot:
		case ItemType.Cotton:
		case ItemType.Tomato:
		case ItemType.Pear:
		case ItemType.Potato:
		case ItemType.Herb:
		case ItemType.Water:
		case ItemType.Fish:
			return 1.0;
		case ItemType.Stone:
		case ItemType.IronOre:
		case ItemType.Coal:
		case ItemType.CopperOre:
		case ItemType.Quartz:
			return 1.0;
		case ItemType.SilverOre:
			return 2.0;
		case ItemType.GoldOre:
			return 3.0;
		case ItemType.Mana:
			return 3.0;
		case ItemType.RedRuby:
			return 3.0;
		case ItemType.YellowTopaz:
			return 3.0;
		case ItemType.BlueSapphire:
			return 3.0;
		case ItemType.PurpleAmethyst:
			return 3.0;
		case ItemType.RefinedSugar:
			return 2.0;
		case ItemType.FruitJuice:
			return 3.0;
		case ItemType.BerryJuice:
			return 3.0;
		case ItemType.PearJuice:
			return 3.0;
		case ItemType.Flour:
			return 2.0;
		case ItemType.Bread:
			return 5.0;
		case ItemType.AnimalFeed:
			return 2.0;
		case ItemType.FishFood:
			return 2.0;
		case ItemType.Leather:
			return 8.0;
		case ItemType.RawBeef:
			return 10.0;
		case ItemType.CookedBeef:
			return 15.0;
		case ItemType.Fertilizer:
			return 1.0;
		case ItemType.Milk:
			return 4.0;
		case ItemType.Egg:
			return 2.0;
		case ItemType.RawChicken:
			return 4.0;
		case ItemType.CookedChicken:
			return 8.0;
		case ItemType.FishCooked:
			return 2.0;
		case ItemType.Butter:
			return 8.0;
		case ItemType.Wool:
			return 4.0;
		case ItemType.FishingNet:
			return 4.0;
		case ItemType.MagicFishingNet:
			return 20.0;
		case ItemType.Paper:
			return 1.0;
		case ItemType.Book:
			return 5.0;
		case ItemType.ResearchTomeGeneral:
			return 2.0;
		case ItemType.ResearchTomeIndustry1:
			return 30.0;
		case ItemType.ResearchTomeIndustry2:
			return 60.0;
		case ItemType.ResearchTomeIndustry3:
			return 120.0;
		case ItemType.ResearchTomeMagic1:
			return 50.0;
		case ItemType.ResearchTomeMagic2:
			return 100.0;
		case ItemType.ResearchTomeMagic3:
			return 150.0;
		case ItemType.CottonCloth:
			return 2.0;
		case ItemType.WoolCloth:
			return 2.0;
		case ItemType.Outfit:
			return 5.0;
		case ItemType.Pants:
			return 8.0;
		case ItemType.Cloak:
			return 16.0;
		case ItemType.Shoe:
			return 14.0;
		case ItemType.WarmCoat:
			return 25.0;
		case ItemType.Boots:
			return 20.0;
		case ItemType.Hat:
			return 6.0;
		case ItemType.MagicCloak:
			return 50.0;
		case ItemType.MagicShirt:
			return 15.0;
		case ItemType.MagicPants:
			return 40.0;
		case ItemType.MagicBoots:
			return 45.0;
		case ItemType.MagicHat:
			return 35.0;
		case ItemType.ClothConveyorBelt:
			return 18.0;
		case ItemType.ConveyorBeltWooden:
			return 18.0;
		case ItemType.MetalConveyorBelt:
			return 30.0;
		case ItemType.MagicConveyorBelt:
			return 50.0;
		case ItemType.RailTileWood:
			return 20.0;
		case ItemType.RailTile:
			return 30.0;
		case ItemType.RailTileMagic:
			return 50.0;
		case ItemType.AirshipComponent:
			return 50.0;
		case ItemType.MagicBoatComponent:
			return 50.0;
		case ItemType.Gear:
			return 8.0;
		case ItemType.IronWheel:
			return 14.0;
		case ItemType.WaterPipe:
			return 2.0;
		case ItemType.SteamPipe:
			return 6.0;
		case ItemType.MagmaPipe:
			return 50.0;
		case ItemType.ManaPipe:
			return 25.0;
		case ItemType.OmniPipe:
			return 250.0;
		case ItemType.SolarCell:
			return 10.0;
		case ItemType.IronIngot:
			return 4.0;
		case ItemType.CopperIngot:
			return 4.0;
		case ItemType.SilverIngot:
			return 5.0;
		case ItemType.GoldIngot:
			return 10.0;
		case ItemType.CopperWire:
			return 8.0;
		case ItemType.Nails:
			return 2.0;
		case ItemType.Steel:
			return 20.0;
		case ItemType.Plank:
			return 2.0;
		case ItemType.RefinedPlank:
			return 3.0;
		case ItemType.ReinforcedPlank:
			return 10.0;
		case ItemType.WoodWheel:
			return 4.0;
		case ItemType.StoneSlab:
			return 3.0;
		case ItemType.RefinedStoneBrick:
			return 7.0;
		case ItemType.Shovel:
			return 3.0;
		case ItemType.Pickaxe:
			return 12.0;
		case ItemType.WoodAxe:
			return 5.0;
		case ItemType.GlassPanel:
			return 20.0;
		case ItemType.Cheese:
			return 30.0;
		case ItemType.DragonPunch:
			return 12.0;
		case ItemType.Jam:
			return 10.0;
		case ItemType.BerryJam:
			return 10.0;
		case ItemType.CactusJam:
			return 12.0;
		case ItemType.PearJam:
			return 10.0;
		case ItemType.ApplePie:
			return 45.0;
		case ItemType.FishStew:
			return 20.0;
		case ItemType.MeatStew:
			return 22.0;
		case ItemType.VeggieStew:
			return 10.0;
		case ItemType.Sandwich:
			return 60.0;
		case ItemType.Cake:
			return 50.0;
		case ItemType.BerryCake:
			return 90.0;
		case ItemType.Fire:
			return 0.1;
		case ItemType.Steam:
			return 0.1;
		case ItemType.Power:
			return 0.1;
		case ItemType.ManaPower:
			return 1.0;
		case ItemType.UtilityElementalFirePower:
			return 1.0;
		case ItemType.UtilityElementalWaterPower:
			return 1.0;
		case ItemType.UtilityElementalEarthPower:
			return 1.0;
		case ItemType.UtilityElementalAirPower:
			return 1.0;
		case ItemType.PurifiedMana:
			return 13.0;
		case ItemType.PurifiedFire:
			return 17.0;
		case ItemType.PurifiedWater:
			return 17.0;
		case ItemType.PurifiedEarth:
			return 17.0;
		case ItemType.PurifiedAir:
			return 17.0;
		case ItemType.Omnistone:
			return 1000.0;
		case ItemType.ManaEther:
			return 20.0;
		case ItemType.FireEther:
			return 60.0;
		case ItemType.WaterEther:
			return 60.0;
		case ItemType.AirEther:
			return 60.0;
		case ItemType.EarthEther:
			return 60.0;
		case ItemType.PolishedStone:
			return 15.0;
		case ItemType.CopperRing:
			return 10.0;
		case ItemType.SilverRing:
			return 15.0;
		case ItemType.GoldRing:
			return 18.0;
		case ItemType.SilverChain:
			return 25.0;
		case ItemType.GoldCrown:
			return 30.0;
		case ItemType.PolishedStoneRing:
			return 20.0;
		case ItemType.RubyRing:
			return 28.0;
		case ItemType.SapphireRing:
			return 26.0;
		case ItemType.AmethystNecklace:
			return 36.0;
		case ItemType.TopazCrown:
			return 40.0;
		case ItemType.MagicPlank:
			return 15.0;
		case ItemType.MagicStoneBrick:
			return 17.0;
		case ItemType.MagicRing:
			return 70.0;
		case ItemType.EnchantedAirCrown:
			return 82.0;
		case ItemType.EnchantedFireRing:
			return 70.0;
		case ItemType.EnchantedWaterRing:
			return 70.0;
		case ItemType.EnchantedEarthNecklace:
			return 78.0;
		case ItemType.EnchantedBook:
			return 20.0;
		case ItemType.EnchantedBookRed:
			return 50.0;
		case ItemType.EnchantedBookYellow:
			return 50.0;
		case ItemType.EnchantedBookBlue:
			return 50.0;
		case ItemType.EnchantedBookPurple:
			return 50.0;
		case ItemType.Bandage:
			return 3.0;
		case ItemType.Poultice:
			return 7.0;
		case ItemType.Ointment:
			return 12.0;
		case ItemType.MedicalWrap:
			return 26.0;
		case ItemType.FishOil:
			return 4.0;
		case ItemType.Remedy:
			return 6.0;
		case ItemType.Antidote:
			return 18.0;
		case ItemType.MagicPotion:
			return 30.0;
		case ItemType.HealthPotion:
			return 40.0;
		case ItemType.StealthPotion:
			return 40.0;
		case ItemType.AttackPotion:
			return 40.0;
		case ItemType.SpeedPotion:
			return 40.0;
		default:
			return 1.0;
		}
	}

	public static Specialty SpecialtyForItem(ItemType t)
	{
		switch (t)
		{
		case ItemType.Wood:
		case ItemType.Grain:
		case ItemType.Sugar:
		case ItemType.Apple:
		case ItemType.Berries:
		case ItemType.CactusFruit:
		case ItemType.DragonFruit:
		case ItemType.Carrot:
		case ItemType.Cotton:
		case ItemType.Tomato:
		case ItemType.Pear:
		case ItemType.Potato:
		case ItemType.Herb:
		case ItemType.Water:
			return Specialty.Crops;
		case ItemType.Stone:
		case ItemType.IronOre:
		case ItemType.GoldOre:
		case ItemType.Coal:
		case ItemType.Mana:
		case ItemType.RedRuby:
		case ItemType.YellowTopaz:
		case ItemType.BlueSapphire:
		case ItemType.PurpleAmethyst:
		case ItemType.CopperOre:
		case ItemType.SilverOre:
		case ItemType.Quartz:
			return Specialty.Minerals;
		case ItemType.Flour:
		case ItemType.Bread:
		case ItemType.FruitJuice:
		case ItemType.AnimalFeed:
		case ItemType.PearJuice:
		case ItemType.BerryJuice:
		case ItemType.RefinedSugar:
		case ItemType.FishFood:
			return Specialty.PlantProducts;
		case ItemType.Milk:
		case ItemType.Butter:
		case ItemType.Fertilizer:
		case ItemType.Leather:
		case ItemType.RawBeef:
		case ItemType.CookedBeef:
		case ItemType.Egg:
		case ItemType.CookedChicken:
		case ItemType.RawChicken:
		case ItemType.Fish:
		case ItemType.FishCooked:
		case ItemType.Wool:
		case ItemType.FishingNet:
		case ItemType.MagicFishingNet:
			return Specialty.AnimalProducts;
		case ItemType.Paper:
		case ItemType.Book:
		case ItemType.ResearchTomeIndustry1:
		case ItemType.ResearchTomeIndustry2:
		case ItemType.ResearchTomeIndustry3:
		case ItemType.ResearchTomeMagic1:
		case ItemType.ResearchTomeMagic2:
		case ItemType.ResearchTomeMagic3:
		case ItemType.ResearchTomeGeneral:
			return Specialty.Knowledge;
		case ItemType.CottonCloth:
		case ItemType.Outfit:
		case ItemType.Cloak:
		case ItemType.MagicCloak:
		case ItemType.Shoe:
		case ItemType.WarmCoat:
		case ItemType.MagicShirt:
		case ItemType.WoolCloth:
		case ItemType.Pants:
		case ItemType.MagicPants:
		case ItemType.Boots:
		case ItemType.MagicBoots:
		case ItemType.Hat:
		case ItemType.MagicHat:
			return Specialty.Clothing;
		case ItemType.MetalConveyorBelt:
		case ItemType.ClothConveyorBelt:
		case ItemType.MagicConveyorBelt:
		case ItemType.RailTile:
		case ItemType.RailTileMagic:
		case ItemType.SteamPipe:
		case ItemType.ManaPipe:
		case ItemType.OmniPipe:
		case ItemType.IronWheel:
		case ItemType.Gear:
		case ItemType.WaterPipe:
		case ItemType.RailTileWood:
		case ItemType.ConveyorBeltWooden:
		case ItemType.MagicBoatComponent:
		case ItemType.AirshipComponent:
		case ItemType.SolarCell:
		case ItemType.MagmaPipe:
			return Specialty.Tech;
		case ItemType.IronIngot:
		case ItemType.GoldIngot:
		case ItemType.Nails:
		case ItemType.Steel:
		case ItemType.SilverIngot:
		case ItemType.CopperIngot:
		case ItemType.CopperWire:
			return Specialty.Metal;
		case ItemType.Plank:
		case ItemType.StoneSlab:
		case ItemType.ReinforcedPlank:
		case ItemType.WoodWheel:
		case ItemType.WoodAxe:
		case ItemType.Pickaxe:
		case ItemType.RefinedPlank:
		case ItemType.RefinedStoneBrick:
		case ItemType.Shovel:
		case ItemType.GlassPanel:
			return Specialty.Construction;
		case ItemType.Jam:
		case ItemType.Cheese:
		case ItemType.Cake:
		case ItemType.BerryCake:
		case ItemType.ApplePie:
		case ItemType.FishStew:
		case ItemType.MeatStew:
		case ItemType.VeggieStew:
		case ItemType.Sandwich:
		case ItemType.PearJam:
		case ItemType.BerryJam:
		case ItemType.CactusJam:
		case ItemType.DragonPunch:
			return Specialty.Gourmet;
		case ItemType.Fire:
		case ItemType.Steam:
		case ItemType.Power:
		case ItemType.ManaPower:
		case ItemType.UtilityElementalFirePower:
		case ItemType.UtilityElementalWaterPower:
		case ItemType.UtilityElementalAirPower:
		case ItemType.UtilityElementalEarthPower:
			return Specialty.Energy;
		case ItemType.Omnistone:
		case ItemType.FireEther:
		case ItemType.WaterEther:
		case ItemType.EarthEther:
		case ItemType.AirEther:
		case ItemType.PurifiedMana:
		case ItemType.PurifiedFire:
		case ItemType.PurifiedWater:
		case ItemType.PurifiedEarth:
		case ItemType.PurifiedAir:
		case ItemType.ManaEther:
			return Specialty.Magic;
		case ItemType.PolishedStone:
		case ItemType.CopperRing:
		case ItemType.GoldRing:
		case ItemType.SilverChain:
		case ItemType.RubyRing:
		case ItemType.SapphireRing:
		case ItemType.GoldCrown:
		case ItemType.SilverRing:
		case ItemType.AmethystNecklace:
		case ItemType.TopazCrown:
		case ItemType.PolishedStoneRing:
			return Specialty.Jewelry;
		case ItemType.MagicStoneBrick:
		case ItemType.EnchantedAirCrown:
		case ItemType.EnchantedFireRing:
		case ItemType.EnchantedWaterRing:
		case ItemType.EnchantedEarthNecklace:
		case ItemType.MagicPlank:
		case ItemType.EnchantedBook:
		case ItemType.EnchantedBookRed:
		case ItemType.EnchantedBookYellow:
		case ItemType.EnchantedBookBlue:
		case ItemType.EnchantedBookPurple:
		case ItemType.MagicRing:
			return Specialty.Enchanting;
		case ItemType.Bandage:
		case ItemType.Poultice:
		case ItemType.Ointment:
		case ItemType.MedicalWrap:
		case ItemType.FishOil:
		case ItemType.Remedy:
		case ItemType.HealthPotion:
		case ItemType.Antidote:
		case ItemType.StealthPotion:
		case ItemType.MagicPotion:
		case ItemType.AttackPotion:
		case ItemType.SpeedPotion:
			return Specialty.Medicine;
		default:
			return Specialty.None;
		}
	}

	public void ConfigureForType()
	{
		Specialty specialty = SpecialtyForItem(type);
		if (specialty != Specialty.None)
		{
			this.specialty = specialty;
			tradeBuilding = BuildingType.TradingPost;
		}
		xpValue = XPForItem(type);
		switch (type)
		{
		case ItemType.Water:
			phase = MatterPhase.Liquid;
			storageType = StorageType.Reservoir;
			break;
		case ItemType.FruitJuice:
		case ItemType.PearJuice:
		case ItemType.BerryJuice:
		case ItemType.DragonPunch:
			phase = MatterPhase.Liquid;
			storageType = StorageType.Barrel;
			break;
		case ItemType.Milk:
			phase = MatterPhase.Liquid;
			storageType = StorageType.Barrel;
			break;
		case ItemType.Grain:
		case ItemType.Sugar:
		case ItemType.Apple:
		case ItemType.Berries:
		case ItemType.Carrot:
		case ItemType.Cotton:
		case ItemType.Tomato:
		case ItemType.Pear:
		case ItemType.Potato:
		case ItemType.Herb:
			phase = MatterPhase.Solid;
			isLooseBulk = true;
			storageType = StorageType.CropSilo;
			break;
		case ItemType.Paper:
		case ItemType.Book:
		case ItemType.EnchantedBook:
		case ItemType.ResearchTomeIndustry1:
		case ItemType.ResearchTomeIndustry2:
		case ItemType.ResearchTomeIndustry3:
		case ItemType.ResearchTomeMagic1:
		case ItemType.ResearchTomeMagic2:
		case ItemType.ResearchTomeMagic3:
		case ItemType.ResearchTomeGeneral:
			phase = MatterPhase.Solid;
			storageType = StorageType.Library;
			break;
		case ItemType.Plank:
		case ItemType.Stone:
		case ItemType.StoneSlab:
		case ItemType.IronOre:
		case ItemType.IronIngot:
		case ItemType.GoldOre:
		case ItemType.GoldIngot:
		case ItemType.Coal:
		case ItemType.ReinforcedPlank:
		case ItemType.MagicStoneBrick:
		case ItemType.Omnistone:
		case ItemType.MetalConveyorBelt:
		case ItemType.ClothConveyorBelt:
		case ItemType.MagicConveyorBelt:
		case ItemType.RailTile:
		case ItemType.RailTileMagic:
		case ItemType.SteamPipe:
		case ItemType.ManaPipe:
		case ItemType.OmniPipe:
		case ItemType.CactusFruit:
		case ItemType.DragonFruit:
		case ItemType.Magma:
		case ItemType.Flour:
		case ItemType.Bread:
		case ItemType.Jam:
		case ItemType.Butter:
		case ItemType.Cheese:
		case ItemType.Cake:
		case ItemType.BerryCake:
		case ItemType.ApplePie:
		case ItemType.FishStew:
		case ItemType.MeatStew:
		case ItemType.VeggieStew:
		case ItemType.Sandwich:
		case ItemType.Fertilizer:
		case ItemType.AnimalFeed:
		case ItemType.Leather:
		case ItemType.RawBeef:
		case ItemType.CookedBeef:
		case ItemType.Egg:
		case ItemType.CookedChicken:
		case ItemType.RawChicken:
		case ItemType.Fish:
		case ItemType.FishCooked:
		case ItemType.WoodWheel:
		case ItemType.IronWheel:
		case ItemType.Gear:
		case ItemType.Nails:
		case ItemType.WoodAxe:
		case ItemType.Pickaxe:
		case ItemType.Wool:
		case ItemType.CottonCloth:
		case ItemType.Outfit:
		case ItemType.Cloak:
		case ItemType.MagicCloak:
		case ItemType.Shoe:
		case ItemType.WarmCoat:
		case ItemType.MagicShirt:
		case ItemType.EnchantedAirCrown:
		case ItemType.EnchantedFireRing:
		case ItemType.EnchantedWaterRing:
		case ItemType.EnchantedEarthNecklace:
		case ItemType.PolishedStone:
		case ItemType.MagicPlank:
		case ItemType.Bandage:
		case ItemType.Poultice:
		case ItemType.Ointment:
		case ItemType.MedicalWrap:
		case ItemType.ProteinShake:
		case ItemType.FishOil:
		case ItemType.Remedy:
		case ItemType.HealthPotion:
		case ItemType.Antidote:
		case ItemType.StealthPotion:
		case ItemType.EnchantedBookRed:
		case ItemType.EnchantedBookYellow:
		case ItemType.EnchantedBookBlue:
		case ItemType.EnchantedBookPurple:
		case ItemType.Mana:
		case ItemType.RedRuby:
		case ItemType.GemOrange:
		case ItemType.YellowTopaz:
		case ItemType.GemGreen:
		case ItemType.BlueSapphire:
		case ItemType.GemBlue:
		case ItemType.PurpleAmethyst:
		case ItemType.GemPink:
		case ItemType.FireEther:
		case ItemType.WaterEther:
		case ItemType.EarthEther:
		case ItemType.AirEther:
		case ItemType.PurifiedMana:
		case ItemType.PurifiedFire:
		case ItemType.PurifiedWater:
		case ItemType.PurifiedEarth:
		case ItemType.PurifiedAir:
		case ItemType.DepletedMana:
		case ItemType.DepletedFire:
		case ItemType.DepletedWater:
		case ItemType.DepletedEarth:
		case ItemType.DepletedAir:
		case ItemType.GrainSeeds:
		case ItemType.TreeSeeds:
		case ItemType.ManaSeeds:
		case ItemType.RailTilePowered:
		case ItemType.WaterPipe:
		case ItemType.StoneAxe:
		case ItemType.PearJam:
		case ItemType.BerryJam:
		case ItemType.CactusJam:
		case ItemType.ResearchTomeAgriculture1:
		case ItemType.ResearchTomeAgriculture2:
		case ItemType.ResearchTomeAgriculture3:
		case ItemType.ResearchTomeNature1:
		case ItemType.ResearchTomeNature2:
		case ItemType.ResearchTomeNature3:
		case ItemType.ResearchTomeFire1:
		case ItemType.ResearchTomeFire2:
		case ItemType.ResearchTomeFire3:
		case ItemType.ResearchTomeWater1:
		case ItemType.ResearchTomeWater2:
		case ItemType.ResearchTomeWater3:
		case ItemType.ResearchTomeEarth1:
		case ItemType.ResearchTomeEarth2:
		case ItemType.ResearchTomeEarth3:
		case ItemType.ResearchTomeAir1:
		case ItemType.ResearchTomeAir2:
		case ItemType.ResearchTomeAir3:
		case ItemType.RailTileWood:
		case ItemType.ConveyorBeltWooden:
		case ItemType.CopperOre:
		case ItemType.RefinedPlank:
		case ItemType.Fire:
		case ItemType.Steam:
		case ItemType.WoolCloth:
		case ItemType.RefinedStoneBrick:
		case ItemType.RefinedSugar:
		case ItemType.Power:
		case ItemType.Steel:
		case ItemType.FishFood:
		case ItemType.Pants:
		case ItemType.CopperRing:
		case ItemType.GoldRing:
		case ItemType.SilverChain:
		case ItemType.ManaPower:
		case ItemType.RubyRing:
		case ItemType.SapphireRing:
		case ItemType.SilverOre:
		case ItemType.SilverIngot:
		case ItemType.GoldCrown:
		case ItemType.SilverRing:
		case ItemType.AmethystNecklace:
		case ItemType.TopazCrown:
		case ItemType.Shovel:
		case ItemType.ManaEther:
		case ItemType.MagicPotion:
		case ItemType.AttackPotion:
		case ItemType.SpeedPotion:
		case ItemType.MagicPants:
		case ItemType.Boots:
		case ItemType.MagicBoots:
		case ItemType.Hat:
		case ItemType.MagicHat:
		case ItemType.MagicRing:
		case ItemType.MagicBoatComponent:
		case ItemType.AirshipComponent:
		case ItemType.CopperIngot:
		case ItemType.CopperWire:
		case ItemType.PolishedStoneRing:
		case ItemType.FishingNet:
		case ItemType.MagicFishingNet:
		case ItemType.GlassPanel:
		case ItemType.Quartz:
		case ItemType.SolarCell:
		case ItemType.MagmaPipe:
			break;
		}
	}
}
