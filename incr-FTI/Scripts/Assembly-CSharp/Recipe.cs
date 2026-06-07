using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
	public RecipeType type;

	public readonly ItemList inputs = new ItemList();

	public readonly ItemList outputs = new ItemList();

	public float craftingTime;

	public float xpValue;

	public BuildingType producingBuildingType;

	public bool suppressNotification;

	public readonly List<EntityId> productivityUpgrades = new List<EntityId>();

	public readonly List<RequirementId> requirements = new List<RequirementId>();

	public bool enabled;

	public string overrideLocalizationKey;

	public RecipeCategory category;

	public Recipe(RecipeType t)
	{
		type = t;
	}

	public static Recipe Default(RecipeType assignedType)
	{
		Recipe recipe = new Recipe(assignedType);
		recipe.LoadDefaultRecipe();
		return recipe;
	}

	public void LoadDefaultRecipe()
	{
		enabled = true;
		craftingTime = 5f;
		switch (type)
		{
		case RecipeType.BurnWood:
			LoadBasic(ItemType.Wood, 2, ItemType.Fire);
			craftingTime = 1f;
			break;
		case RecipeType.BurnCoal:
			LoadBasic(ItemType.Coal, 1, ItemType.Fire);
			craftingTime = 1f;
			AddProductivityUpgrade(UpgradeType.FurnaceProductivity);
			break;
		case RecipeType.MakePlank:
			LoadBasic(ItemType.Wood, 2, ItemType.Plank);
			craftingTime = 4f;
			break;
		case RecipeType.MakeRefinedPlank:
			LoadBasic(ItemType.Plank, 2, ItemType.RefinedPlank);
			craftingTime = 8f;
			requirements.Add(new RequirementId(QuestType.PlanksForRefinedPlank));
			break;
		case RecipeType.MakeRefinedStoneBrick:
			LoadBasic(ItemType.StoneSlab, 2, ItemType.RefinedStoneBrick);
			craftingTime = 8f;
			requirements.Add(new RequirementId(QuestType.StoneBricksForRefinedStoneBricks));
			break;
		case RecipeType.MakePaper:
			AddInput(ItemType.Wood, 1);
			AddInput(ItemType.Water, 1);
			AddOutput(ItemType.Paper, 2);
			requirements.Add(new RequirementId(QuestType.SkillsForPaper));
			craftingTime = 4f;
			break;
		case RecipeType.MakeBook:
			AddInput(ItemType.Paper, 4);
			AddOutput(ItemType.Book);
			requirements.Add(new RequirementId(QuestType.PaperSkillsForBook));
			craftingTime = 5f;
			break;
		case RecipeType.MakeClothBook:
			AddInput(ItemType.Paper, 4);
			AddInput(ItemType.CottonCloth, 2);
			AddOutput(ItemType.Book);
			craftingTime = 6f;
			enabled = false;
			break;
		case RecipeType.GeneralResearchFromPaper:
			AddInput(ItemType.Paper, 1);
			AddOutput(ItemType.ResearchTomeGeneral);
			craftingTime = 10f;
			break;
		case RecipeType.GeneralResearchFromBook:
			AddInput(ItemType.Book, 1);
			AddOutput(ItemType.ResearchTomeGeneral, 10);
			requirements.Add(new RequirementId(QuestType.PaperSkillsForBook));
			craftingTime = 10f;
			break;
		case RecipeType.GeneralResearchFromEnchantedBook:
			AddInput(ItemType.EnchantedBook, 1);
			AddOutput(ItemType.ResearchTomeGeneral, 25);
			craftingTime = 10f;
			requirements.Add(new RequirementId(ResearchType.Enchanting));
			break;
		case RecipeType.PurifiedManaPower:
			AddInput(ItemType.PurifiedMana, 1);
			AddInput(ItemType.Power, 2);
			AddOutput(ItemType.ManaPower);
			requirements.Add(new RequirementId(ResearchType.ManaTransmitter));
			AddProductivityUpgrade(ResearchType.EtherBonusManaPower);
			craftingTime = 20f;
			break;
		case RecipeType.PurifiedFirePower:
			AddInput(ItemType.PurifiedFire, 1);
			AddInput(ItemType.Power, 2);
			AddOutput(ItemType.UtilityElementalFirePower);
			requirements.Add(new RequirementId(ResearchType.PurifiedFirePower));
			AddProductivityUpgrade(ResearchType.EtherBonusFirePower);
			craftingTime = 20f;
			break;
		case RecipeType.PurifiedWaterPower:
			AddInput(ItemType.PurifiedWater, 1);
			AddInput(ItemType.Power, 2);
			AddOutput(ItemType.UtilityElementalWaterPower);
			requirements.Add(new RequirementId(ResearchType.PurifiedWaterPower));
			AddProductivityUpgrade(ResearchType.EtherBonusWaterPower);
			craftingTime = 20f;
			break;
		case RecipeType.PurifiedEarthPower:
			AddInput(ItemType.PurifiedEarth, 1);
			AddInput(ItemType.Power, 2);
			AddOutput(ItemType.UtilityElementalEarthPower);
			requirements.Add(new RequirementId(ResearchType.PurifiedEarthPower));
			AddProductivityUpgrade(ResearchType.EtherBonusEarthPower);
			craftingTime = 20f;
			break;
		case RecipeType.PurifiedAirPower:
			AddInput(ItemType.PurifiedAir, 1);
			AddInput(ItemType.Power, 2);
			AddOutput(ItemType.UtilityElementalAirPower);
			requirements.Add(new RequirementId(ResearchType.PurifiedAirPower));
			AddProductivityUpgrade(ResearchType.EtherBonusAirPower);
			craftingTime = 20f;
			break;
		case RecipeType.MakeEnchantedBook:
			AddInput(ItemType.Book, 1);
			AddInput(ItemType.ManaPower, 1);
			AddOutput(ItemType.EnchantedBook);
			requirements.Add(new RequirementId(ResearchType.Enchanting));
			requirements.Add(new RequirementId(QuestType.PaperSkillsForBook));
			craftingTime = 15f;
			break;
		case RecipeType.MakeEnchantedBookRed:
			AddInput(ItemType.EnchantedBook, 1);
			AddInput(ItemType.UtilityElementalFirePower, 2);
			AddOutput(ItemType.EnchantedBookRed);
			requirements.Add(new RequirementId(ResearchType.PurifiedFirePower));
			requirements.Add(new RequirementId(ResearchType.Enchanting));
			craftingTime = 30f;
			break;
		case RecipeType.MakeEnchantedBookYellow:
			AddInput(ItemType.EnchantedBook, 1);
			AddInput(ItemType.UtilityElementalAirPower, 2);
			AddOutput(ItemType.EnchantedBookYellow);
			requirements.Add(new RequirementId(ResearchType.PurifiedAirPower));
			requirements.Add(new RequirementId(ResearchType.Enchanting));
			craftingTime = 30f;
			break;
		case RecipeType.MakeEnchantedBookBlue:
			AddInput(ItemType.EnchantedBook, 1);
			AddInput(ItemType.UtilityElementalWaterPower, 2);
			AddOutput(ItemType.EnchantedBookBlue);
			requirements.Add(new RequirementId(ResearchType.PurifiedWaterPower));
			requirements.Add(new RequirementId(ResearchType.Enchanting));
			craftingTime = 30f;
			break;
		case RecipeType.MakeEnchantedBookPurple:
			AddInput(ItemType.EnchantedBook, 1);
			AddInput(ItemType.UtilityElementalEarthPower, 2);
			AddOutput(ItemType.EnchantedBookPurple);
			requirements.Add(new RequirementId(ResearchType.PurifiedEarthPower));
			requirements.Add(new RequirementId(ResearchType.Enchanting));
			craftingTime = 30f;
			break;
		case RecipeType.MakeOmniStone:
			AddInput(ItemType.UtilityElementalFirePower, 10);
			AddInput(ItemType.UtilityElementalWaterPower, 10);
			AddInput(ItemType.UtilityElementalEarthPower, 10);
			AddInput(ItemType.UtilityElementalAirPower, 10);
			AddInput(ItemType.PurifiedMana, 20);
			AddOutput(ItemType.Omnistone);
			craftingTime = 30f;
			break;
		case RecipeType.MakeWoolCloth:
			AddInput(ItemType.Wool, 1);
			AddOutput(ItemType.WoolCloth);
			craftingTime = 4f;
			requirements.Add(new RequirementId(QuestType.WoolSkillForWoolCloth));
			break;
		case RecipeType.MakeCottonCloth:
			AddInput(ItemType.Cotton, 2);
			AddOutput(ItemType.CottonCloth);
			craftingTime = 4f;
			break;
		case RecipeType.MakeShirt:
			AddInput(ItemType.CottonCloth, 2);
			AddOutput(ItemType.Outfit);
			craftingTime = 4f;
			requirements.Add(new RequirementId(QuestType.CottonClothSkillForShirt));
			break;
		case RecipeType.MakePants:
			AddInput(ItemType.CottonCloth, 3);
			AddOutput(ItemType.Pants);
			craftingTime = 6f;
			requirements.Add(new RequirementId(QuestType.ShirtSkillForPants));
			break;
		case RecipeType.MakeBoots:
			AddInput(ItemType.Leather, 2);
			AddOutput(ItemType.Boots);
			craftingTime = 6f;
			requirements.Add(new RequirementId(QuestType.ShoeSkillForBoots));
			break;
		case RecipeType.MakeHat:
			AddInput(ItemType.WoolCloth, 1);
			AddOutput(ItemType.Hat);
			craftingTime = 6f;
			requirements.Add(new RequirementId(QuestType.WoolClothSkillForHat));
			break;
		case RecipeType.MakePolishedStoneRing:
			AddInput(ItemType.CopperRing, 1);
			AddInput(ItemType.PolishedStone, 2);
			AddOutput(ItemType.PolishedStoneRing);
			craftingTime = 6f;
			requirements.Add(new RequirementId(ResearchType.GemJewelry));
			break;
		case RecipeType.MakeRubyRing:
			AddInput(ItemType.GoldRing, 1);
			AddInput(ItemType.RedRuby, 2);
			AddOutput(ItemType.RubyRing);
			craftingTime = 10f;
			requirements.Add(new RequirementId(QuestType.SkillsForRubyRing));
			break;
		case RecipeType.MakeSapphireRing:
			AddInput(ItemType.SilverRing, 1);
			AddInput(ItemType.BlueSapphire, 2);
			AddOutput(ItemType.SapphireRing);
			craftingTime = 10f;
			requirements.Add(new RequirementId(QuestType.SkillsForSapphireRing));
			break;
		case RecipeType.MakeAmethystNecklace:
			AddInput(ItemType.SilverChain, 1);
			AddInput(ItemType.PurpleAmethyst, 2);
			AddOutput(ItemType.AmethystNecklace);
			craftingTime = 10f;
			requirements.Add(new RequirementId(QuestType.SkillsForAmethystNecklace));
			break;
		case RecipeType.MakeTopazCrown:
			AddInput(ItemType.GoldCrown, 1);
			AddInput(ItemType.YellowTopaz, 2);
			AddOutput(ItemType.TopazCrown);
			craftingTime = 10f;
			requirements.Add(new RequirementId(QuestType.SkillsForTopazCrown));
			break;
		case RecipeType.MakeMagicRing:
			AddInput(ItemType.PolishedStoneRing, 1);
			AddInput(ItemType.ManaPower, 2);
			AddOutput(ItemType.MagicRing);
			craftingTime = 20f;
			requirements.Add(new RequirementId(QuestType.SkillsForMagicRing));
			requirements.Add(new RequirementId(ResearchType.MagicJewelry));
			break;
		case RecipeType.MakeFireRing:
			AddInput(ItemType.RubyRing, 1);
			AddInput(ItemType.UtilityElementalFirePower, 2);
			AddOutput(ItemType.EnchantedFireRing);
			craftingTime = 30f;
			requirements.Add(new RequirementId(QuestType.SkillsForFireRing));
			requirements.Add(new RequirementId(ResearchType.MagicJewelry));
			break;
		case RecipeType.MakeWaterRing:
			AddInput(ItemType.SapphireRing, 1);
			AddInput(ItemType.UtilityElementalWaterPower, 2);
			AddOutput(ItemType.EnchantedWaterRing);
			craftingTime = 30f;
			requirements.Add(new RequirementId(QuestType.SkillsForWaterRing));
			requirements.Add(new RequirementId(ResearchType.MagicJewelry));
			break;
		case RecipeType.MakeEarthNecklace:
			AddInput(ItemType.AmethystNecklace, 1);
			AddInput(ItemType.UtilityElementalEarthPower, 2);
			AddOutput(ItemType.EnchantedEarthNecklace);
			craftingTime = 30f;
			requirements.Add(new RequirementId(QuestType.SkillsForEnchantedNecklace));
			requirements.Add(new RequirementId(ResearchType.MagicJewelry));
			break;
		case RecipeType.MakeAirCrown:
			AddInput(ItemType.TopazCrown, 1);
			AddInput(ItemType.UtilityElementalAirPower, 2);
			AddOutput(ItemType.EnchantedAirCrown);
			craftingTime = 30f;
			requirements.Add(new RequirementId(QuestType.SkillsForEnchantedCrown));
			requirements.Add(new RequirementId(ResearchType.MagicJewelry));
			break;
		case RecipeType.MakePolishedStone:
			AddInput(ItemType.Quartz, 2);
			AddOutput(ItemType.PolishedStone);
			craftingTime = 10f;
			break;
		case RecipeType.MakeCopperRing:
			AddInput(ItemType.CopperIngot, 1);
			AddOutput(ItemType.CopperRing);
			craftingTime = 10f;
			requirements.Add(new RequirementId(QuestType.SkillsForCopperRing));
			break;
		case RecipeType.MakeGoldRing:
			AddInput(ItemType.GoldIngot, 1);
			AddOutput(ItemType.GoldRing);
			craftingTime = 10f;
			requirements.Add(new RequirementId(QuestType.SkillsForGoldJewelry));
			break;
		case RecipeType.MakeSilverRing:
			AddInput(ItemType.SilverIngot, 1);
			AddOutput(ItemType.SilverRing);
			craftingTime = 10f;
			requirements.Add(new RequirementId(QuestType.SkillsForSilverJewelry));
			break;
		case RecipeType.MakeSilverChain:
			AddInput(ItemType.SilverIngot, 2);
			AddOutput(ItemType.SilverChain);
			craftingTime = 10f;
			requirements.Add(new RequirementId(QuestType.SkillsForSilverJewelry));
			break;
		case RecipeType.MakeGoldCrown:
			AddInput(ItemType.GoldIngot, 2);
			AddOutput(ItemType.GoldCrown);
			craftingTime = 10f;
			requirements.Add(new RequirementId(QuestType.SkillsForGoldJewelry));
			break;
		case RecipeType.MoveTrainCargo:
			AddInput(ItemType.UtilityParkedTrain, 1);
			AddOutput(ItemType.UtilityMoveTrainCargo, 20);
			craftingTime = 0.5f;
			enabled = false;
			break;
		case RecipeType.MakeCloak:
			AddInput(ItemType.CottonCloth, 2);
			AddInput(ItemType.Leather, 1);
			AddOutput(ItemType.Cloak);
			craftingTime = 4f;
			requirements.Add(new RequirementId(QuestType.SkillsForCloak));
			break;
		case RecipeType.MakeWarmCoat:
			AddInput(ItemType.WoolCloth, 2);
			AddInput(ItemType.Leather, 1);
			AddOutput(ItemType.WarmCoat);
			craftingTime = 12f;
			requirements.Add(new RequirementId(QuestType.SkillsForWarmCoat));
			break;
		case RecipeType.MakePoultice:
			AddInput(ItemType.Herb, 2);
			AddInput(ItemType.CottonCloth, 1);
			AddOutput(ItemType.Poultice);
			requirements.Add(new RequirementId(ResearchType.MedicineBasic));
			craftingTime = 8f;
			break;
		case RecipeType.MakeMedicalWrap:
			AddInput(ItemType.Poultice, 1);
			AddInput(ItemType.Ointment, 1);
			AddInput(ItemType.CottonCloth, 1);
			AddOutput(ItemType.MedicalWrap);
			requirements.Add(new RequirementId(ResearchType.MedicineAdvanced));
			craftingTime = 15f;
			break;
		case RecipeType.MakeRemedy:
			AddInput(ItemType.Herb, 2);
			AddInput(ItemType.Water, 1);
			AddInput(ItemType.Fire, 1);
			AddOutput(ItemType.Remedy);
			requirements.Add(new RequirementId(ResearchType.MedicineBasic));
			craftingTime = 6f;
			break;
		case RecipeType.MakeAntidote:
			AddInput(ItemType.Remedy, 2);
			AddInput(ItemType.FishOil, 1);
			AddInput(ItemType.RefinedSugar, 1);
			AddOutput(ItemType.Antidote);
			requirements.Add(new RequirementId(ResearchType.MedicineIntermediate));
			requirements.Add(new RequirementId(QuestType.SkillsForFishOil));
			requirements.Add(new RequirementId(QuestType.SugarForRefinedSugar));
			craftingTime = 18f;
			break;
		case RecipeType.MakeMagicPotion:
			AddInput(ItemType.Remedy, 1);
			AddInput(ItemType.ManaPower, 1);
			AddOutput(ItemType.MagicPotion);
			requirements.Add(new RequirementId(ResearchType.MagicMedicine));
			craftingTime = 16f;
			break;
		case RecipeType.MakeAttackPotion:
			AddInput(ItemType.MagicPotion, 1);
			AddInput(ItemType.UtilityElementalFirePower, 1);
			AddOutput(ItemType.AttackPotion);
			requirements.Add(new RequirementId(ResearchType.PurifiedFirePower));
			requirements.Add(new RequirementId(ResearchType.MagicMedicine));
			craftingTime = 20f;
			break;
		case RecipeType.MakeStealthPotion:
			AddInput(ItemType.MagicPotion, 1);
			AddInput(ItemType.UtilityElementalWaterPower, 1);
			AddOutput(ItemType.StealthPotion);
			requirements.Add(new RequirementId(ResearchType.PurifiedWaterPower));
			requirements.Add(new RequirementId(ResearchType.MagicMedicine));
			craftingTime = 20f;
			break;
		case RecipeType.MakeHealthPotion:
			AddInput(ItemType.MagicPotion, 1);
			AddInput(ItemType.UtilityElementalEarthPower, 1);
			AddOutput(ItemType.HealthPotion);
			requirements.Add(new RequirementId(ResearchType.PurifiedEarthPower));
			requirements.Add(new RequirementId(ResearchType.MagicMedicine));
			craftingTime = 20f;
			break;
		case RecipeType.MakeSpeedPotion:
			AddInput(ItemType.MagicPotion, 1);
			AddInput(ItemType.UtilityElementalAirPower, 1);
			AddOutput(ItemType.SpeedPotion);
			requirements.Add(new RequirementId(ResearchType.PurifiedAirPower));
			requirements.Add(new RequirementId(ResearchType.MagicMedicine));
			craftingTime = 20f;
			break;
		case RecipeType.MakeMagicPlank:
			AddInput(ItemType.RefinedPlank, 1);
			AddInput(ItemType.ManaPower, 1);
			AddOutput(ItemType.MagicPlank);
			requirements.Add(new RequirementId(QuestType.PlanksForRefinedPlank));
			craftingTime = 10f;
			break;
		case RecipeType.MakeMagicStoneBrick:
			AddInput(ItemType.RefinedStoneBrick, 1);
			AddInput(ItemType.ManaPower, 1);
			AddOutput(ItemType.MagicStoneBrick);
			requirements.Add(new RequirementId(QuestType.StoneBricksForRefinedStoneBricks));
			craftingTime = 10f;
			break;
		case RecipeType.MakeManaPipe:
			AddInput(ItemType.SteamPipe, 1);
			AddInput(ItemType.PurifiedMana, 1);
			AddOutput(ItemType.ManaPipe);
			craftingTime = 6f;
			requirements.Add(new RequirementId(ResearchType.MagicTech));
			requirements.Add(new RequirementId(ResearchType.MagicForge));
			requirements.Add(new RequirementId(ResearchType.ManaPipe));
			break;
		case RecipeType.MakeRailTileMagic:
			AddInput(ItemType.RailTile, 1);
			AddInput(ItemType.PurifiedFire, 1);
			AddOutput(ItemType.RailTileMagic);
			requirements.Add(new RequirementId(ResearchType.MagicTech));
			requirements.Add(new RequirementId(ResearchType.FirePurification));
			requirements.Add(new RequirementId(ResearchType.MagicRail));
			craftingTime = 10f;
			break;
		case RecipeType.MakeMagicBoatComponent:
			AddInput(ItemType.MagicPlank, 3);
			AddInput(ItemType.PurifiedWater, 1);
			AddOutput(ItemType.MagicBoatComponent);
			requirements.Add(new RequirementId(ResearchType.MagicTech));
			requirements.Add(new RequirementId(ResearchType.WaterPurification));
			requirements.Add(new RequirementId(ResearchType.MagicBoat));
			craftingTime = 20f;
			break;
		case RecipeType.MakeMagicConveyorBelt:
			AddInput(ItemType.MetalConveyorBelt, 1);
			AddInput(ItemType.PurifiedEarth, 1);
			AddOutput(ItemType.MagicConveyorBelt);
			requirements.Add(new RequirementId(ResearchType.MagicTech));
			requirements.Add(new RequirementId(ResearchType.EarthPurification));
			requirements.Add(new RequirementId(ResearchType.MagicConveyorBelt));
			craftingTime = 20f;
			break;
		case RecipeType.MakeAirshipComponent:
			AddInput(ItemType.MagicPlank, 3);
			AddInput(ItemType.PurifiedAir, 1);
			AddOutput(ItemType.AirshipComponent);
			requirements.Add(new RequirementId(ResearchType.MagicTech));
			requirements.Add(new RequirementId(ResearchType.AirPurification));
			requirements.Add(new RequirementId(ResearchType.Airship));
			craftingTime = 20f;
			break;
		case RecipeType.MakeMagicShirt:
			AddInput(ItemType.Outfit, 1);
			AddInput(ItemType.CottonCloth, 1);
			AddInput(ItemType.ManaPower, 1);
			AddOutput(ItemType.MagicShirt);
			requirements.Add(new RequirementId(ResearchType.MagicClothing));
			requirements.Add(new RequirementId(QuestType.SkillsForMagicShirt));
			craftingTime = 6f;
			break;
		case RecipeType.MakeMagicCloak:
			AddInput(ItemType.Cloak, 1);
			AddInput(ItemType.WoolCloth, 1);
			AddInput(ItemType.UtilityElementalFirePower, 1);
			AddOutput(ItemType.MagicCloak);
			requirements.Add(new RequirementId(ResearchType.MagicClothing));
			requirements.Add(new RequirementId(QuestType.SkillsForMagicCloak));
			craftingTime = 6f;
			break;
		case RecipeType.MakeMagicPants:
			AddInput(ItemType.Pants, 1);
			AddInput(ItemType.Leather, 1);
			AddInput(ItemType.UtilityElementalWaterPower, 1);
			AddOutput(ItemType.MagicPants);
			requirements.Add(new RequirementId(ResearchType.MagicClothing));
			requirements.Add(new RequirementId(QuestType.SkillsForMagicPants));
			craftingTime = 6f;
			break;
		case RecipeType.MakeMagicBoots:
			AddInput(ItemType.Boots, 1);
			AddInput(ItemType.IronIngot, 1);
			AddInput(ItemType.UtilityElementalEarthPower, 1);
			AddOutput(ItemType.MagicBoots);
			requirements.Add(new RequirementId(ResearchType.MagicClothing));
			requirements.Add(new RequirementId(QuestType.SkillsForMagicBoots));
			craftingTime = 6f;
			break;
		case RecipeType.MakeMagicHat:
			AddInput(ItemType.Hat, 1);
			AddInput(ItemType.Leather, 1);
			AddInput(ItemType.UtilityElementalAirPower, 1);
			AddOutput(ItemType.MagicHat);
			requirements.Add(new RequirementId(ResearchType.MagicClothing));
			requirements.Add(new RequirementId(QuestType.SkillsForMagicHat));
			craftingTime = 6f;
			break;
		case RecipeType.MakeRawBeef:
			AddInput(ItemType.AnimalFeed, 4);
			AddInput(ItemType.Water, 4);
			AddOutput(ItemType.RawBeef);
			craftingTime = 10f;
			requirements.Add(new RequirementId(QuestType.MilkSkillForBeef));
			break;
		case RecipeType.MakeCookedBeef:
			AddInput(ItemType.RawBeef, 1);
			AddInput(ItemType.Fire, 1);
			AddOutput(ItemType.CookedBeef);
			requirements.Add(new RequirementId(QuestType.MilkSkillForBeef));
			craftingTime = 5f;
			break;
		case RecipeType.MakeCookedFish:
			AddInput(ItemType.Fish, 1);
			AddInput(ItemType.Fire, 1);
			AddOutput(ItemType.FishCooked);
			requirements.Add(RequirementId.BiomeTownLevel(BiomeType.River, 0));
			craftingTime = 5f;
			break;
		case RecipeType.MakeCookedChicken:
			AddInput(ItemType.RawChicken, 1);
			AddInput(ItemType.Fire, 1);
			AddOutput(ItemType.CookedChicken);
			requirements.Add(new RequirementId(QuestType.EggSkillForChicken));
			craftingTime = 5f;
			break;
		case RecipeType.MakeMilk:
			AddInput(ItemType.AnimalFeed, 2);
			AddInput(ItemType.Water, 2);
			AddOutput(ItemType.Milk);
			craftingTime = 2f;
			break;
		case RecipeType.MakeAppleJam:
			AddInput(ItemType.Apple, 4);
			AddInput(ItemType.RefinedSugar, 1);
			AddInput(ItemType.Fire, 1);
			AddOutput(ItemType.Jam);
			craftingTime = 6f;
			requirements.Add(new RequirementId(QuestType.AppleJuiceSkillsForJam));
			break;
		case RecipeType.MakePearJam:
			AddInput(ItemType.Pear, 4);
			AddInput(ItemType.RefinedSugar, 1);
			AddInput(ItemType.Fire, 1);
			AddOutput(ItemType.PearJam);
			craftingTime = 6f;
			requirements.Add(new RequirementId(QuestType.PearJuiceSkillsForJam));
			break;
		case RecipeType.MakeBerryJam:
			AddInput(ItemType.Berries, 4);
			AddInput(ItemType.RefinedSugar, 1);
			AddInput(ItemType.Fire, 1);
			AddOutput(ItemType.BerryJam);
			craftingTime = 6f;
			requirements.Add(new RequirementId(QuestType.BerryJuiceSkillsForJam));
			break;
		case RecipeType.MakeAppleJuice:
			AddInput(ItemType.Apple, 2);
			AddOutput(ItemType.FruitJuice);
			requirements.Add(new RequirementId(Quest.ResourceUnlockQuestApples));
			craftingTime = 3f;
			break;
		case RecipeType.MakePearJuice:
			AddInput(ItemType.Pear, 2);
			AddOutput(ItemType.PearJuice);
			requirements.Add(new RequirementId(QuestType.DiscoverPear));
			craftingTime = 3f;
			break;
		case RecipeType.MakeBerryJuice:
			AddInput(ItemType.Berries, 2);
			AddOutput(ItemType.BerryJuice);
			craftingTime = 3f;
			requirements.Add(new RequirementId(QuestType.DiscoverBerries));
			break;
		case RecipeType.MakeDragonPunch:
			AddInput(ItemType.DragonFruit, 1);
			AddInput(ItemType.BerryJuice, 1);
			AddInput(ItemType.FruitJuice, 1);
			AddOutput(ItemType.DragonPunch);
			requirements.Add(new RequirementId(QuestType.SkillsForDragonPunch));
			requirements.Add(RequirementId.BiomeTownLevel(BiomeType.Jungle, 0));
			craftingTime = 6f;
			break;
		case RecipeType.MakeCactusJam:
			AddInput(ItemType.CactusFruit, 1);
			AddInput(ItemType.PearJuice, 1);
			AddInput(ItemType.RefinedSugar, 1);
			AddInput(ItemType.Fire, 2);
			AddOutput(ItemType.CactusJam);
			requirements.Add(new RequirementId(QuestType.SkillsForCactusJam));
			craftingTime = 7f;
			break;
		case RecipeType.MakeButter:
			AddInput(ItemType.Milk, 2);
			AddOutput(ItemType.Butter);
			requirements.Add(new RequirementId(QuestType.MilkSkillForButter));
			craftingTime = 5f;
			break;
		case RecipeType.MakeCheese:
			AddInput(ItemType.Milk, 5);
			AddInput(ItemType.CottonCloth, 1);
			AddOutput(ItemType.Cheese, 2);
			craftingTime = 10f;
			break;
		case RecipeType.MakeSandwich:
			AddInput(ItemType.Bread, 1);
			AddInput(ItemType.Cheese, 1);
			AddInput(ItemType.CookedChicken, 1);
			AddOutput(ItemType.Sandwich);
			craftingTime = 10f;
			requirements.Add(new RequirementId(QuestType.CookedChickenSkillsForSandwich));
			break;
		case RecipeType.MakeFishStew:
			AddInput(ItemType.FishCooked, 1);
			AddInput(ItemType.Butter, 1);
			AddInput(ItemType.Tomato, 2);
			AddInput(ItemType.Fire, 2);
			AddOutput(ItemType.FishStew);
			craftingTime = 10f;
			requirements.Add(new RequirementId(QuestType.CookedFishSkillsForFishStew));
			requirements.Add(RequirementId.BiomeTownLevel(BiomeType.River, 0));
			requirements.Add(new RequirementId(QuestType.DiscoverTomato));
			break;
		case RecipeType.MakeProteinShake:
			AddInput(ItemType.Milk, 1);
			AddInput(ItemType.Egg, 1);
			AddInput(ItemType.RefinedSugar, 1);
			AddOutput(ItemType.ProteinShake);
			craftingTime = 8f;
			requirements.Add(new RequirementId(ResearchType.MedicineBasic));
			enabled = false;
			break;
		case RecipeType.MakeVeggieStew:
			AddInput(ItemType.Tomato, 1);
			AddInput(ItemType.Potato, 1);
			AddInput(ItemType.Carrot, 1);
			AddInput(ItemType.Fire, 2);
			AddOutput(ItemType.VeggieStew);
			requirements.Add(new RequirementId(QuestType.DiscoverTomato));
			requirements.Add(RequirementId.BiomeTownLevel(BiomeType.Snow, 0));
			requirements.Add(RequirementId.BiomeTownLevel(BiomeType.Mountains, 0));
			craftingTime = 10f;
			break;
		case RecipeType.MakeMeatStew:
			AddInput(ItemType.CookedBeef, 1);
			AddInput(ItemType.Potato, 1);
			AddInput(ItemType.Carrot, 1);
			AddInput(ItemType.Fire, 2);
			AddOutput(ItemType.MeatStew);
			craftingTime = 10f;
			requirements.Add(new RequirementId(QuestType.CookedBeefSkillsForBeefStew));
			break;
		case RecipeType.MakeApplePie:
			AddInput(ItemType.Flour, 4);
			AddInput(ItemType.RefinedSugar, 2);
			AddInput(ItemType.Butter, 1);
			AddInput(ItemType.Apple, 2);
			AddInput(ItemType.Fire, 2);
			AddOutput(ItemType.ApplePie);
			requirements.Add(new RequirementId(Quest.ResourceUnlockQuestApples));
			requirements.Add(new RequirementId(QuestType.MilkSkillForButter));
			requirements.Add(new RequirementId(QuestType.SugarForRefinedSugar));
			craftingTime = 12f;
			break;
		case RecipeType.MakeCake:
			AddInput(ItemType.Flour, 4);
			AddInput(ItemType.RefinedSugar, 2);
			AddInput(ItemType.Butter, 1);
			AddInput(ItemType.Egg, 2);
			AddInput(ItemType.Fire, 2);
			AddOutput(ItemType.Cake);
			craftingTime = 12f;
			requirements.Add(new RequirementId(QuestType.SkillsForCake));
			break;
		case RecipeType.MakeBerryCake:
			AddInput(ItemType.Cake, 1);
			AddInput(ItemType.Jam, 2);
			AddInput(ItemType.RefinedSugar, 2);
			AddInput(ItemType.Berries, 4);
			AddOutput(ItemType.BerryCake);
			craftingTime = 15f;
			requirements.Add(new RequirementId(QuestType.CakeSkillsForBerryCake));
			break;
		case RecipeType.MakeReinforcedPlank:
			AddInput(ItemType.Plank, 1);
			AddInput(ItemType.IronIngot, 1);
			AddInput(ItemType.Nails, 2);
			AddOutput(ItemType.ReinforcedPlank);
			requirements.Add(new RequirementId(QuestType.SkillsForReinforcedPlank));
			craftingTime = 6f;
			break;
		case RecipeType.MakeShoe:
			AddInput(ItemType.Leather, 1);
			AddInput(ItemType.Nails, 2);
			AddOutput(ItemType.Shoe);
			craftingTime = 5f;
			requirements.Add(new RequirementId(QuestType.SkillsForShoe));
			break;
		case RecipeType.MakeNails:
			AddInput(ItemType.IronOre, 1);
			AddInput(ItemType.Fire, 1);
			AddOutput(ItemType.Nails);
			craftingTime = 3f;
			requirements.Add(new RequirementId(QuestType.SkillsForNails));
			break;
		case RecipeType.MakeStoneAxe:
			AddInput(ItemType.Plank, 1);
			AddInput(ItemType.Stone, 1);
			AddOutput(ItemType.StoneAxe);
			craftingTime = 6f;
			enabled = false;
			break;
		case RecipeType.MakeShovel:
			AddInput(ItemType.Stone, 1);
			AddInput(ItemType.Plank, 1);
			AddOutput(ItemType.Shovel);
			craftingTime = 4f;
			break;
		case RecipeType.MakeWoodAxe:
			AddInput(ItemType.Plank, 1);
			AddInput(ItemType.IronIngot, 1);
			AddOutput(ItemType.WoodAxe);
			requirements.Add(new RequirementId(QuestType.IronIngotForWoodAxe));
			craftingTime = 8f;
			break;
		case RecipeType.MakePickaxe:
			AddInput(ItemType.RefinedPlank, 1);
			AddInput(ItemType.IronIngot, 1);
			AddOutput(ItemType.Pickaxe);
			requirements.Add(new RequirementId(QuestType.WoodAxeForPickaxe));
			craftingTime = 12f;
			break;
		case RecipeType.MakeBandage:
			AddInput(ItemType.CottonCloth, 1);
			AddOutput(ItemType.Bandage);
			craftingTime = 10f;
			enabled = false;
			requirements.Add(new RequirementId(ResearchType.MedicineBasic));
			break;
		case RecipeType.MakeFishOil:
			AddInput(ItemType.Fish, 1);
			AddOutput(ItemType.FishOil);
			craftingTime = 10f;
			requirements.Add(new RequirementId(QuestType.SkillsForFishOil));
			break;
		case RecipeType.MakeOintment:
			AddInput(ItemType.FishOil, 2);
			AddInput(ItemType.Herb, 4);
			AddOutput(ItemType.Ointment);
			craftingTime = 15f;
			requirements.Add(new RequirementId(ResearchType.MedicineIntermediate));
			break;
		case RecipeType.MakeRailTile:
			AddInput(ItemType.ReinforcedPlank, 2);
			AddInput(ItemType.IronIngot, 2);
			AddInput(ItemType.Power, 2);
			AddOutput(ItemType.RailTile, 1);
			requirements.Add(new RequirementId(ResearchType.MetalRailway));
			craftingTime = 6f;
			break;
		case RecipeType.MakeRailTilePowered:
			AddInput(ItemType.RailTile, 1);
			AddInput(ItemType.Gear, 8);
			AddOutput(ItemType.RailTilePowered);
			requirements.Add(new RequirementId(ResearchType.PoweredRail));
			craftingTime = 8f;
			enabled = false;
			break;
		case RecipeType.MakeRailTilePoweredFromScratch:
			AddInput(ItemType.Plank, 2);
			AddInput(ItemType.IronIngot, 4);
			AddInput(ItemType.Gear, 8);
			AddOutput(ItemType.RailTilePowered);
			requirements.Add(new RequirementId(ResearchType.PoweredRail));
			craftingTime = 12f;
			enabled = false;
			break;
		case RecipeType.MakeWoodWheel:
			AddInput(ItemType.Plank, 2);
			AddOutput(ItemType.WoodWheel);
			craftingTime = 5f;
			break;
		case RecipeType.MakeFishingNet:
			AddInput(ItemType.CottonCloth, 1);
			AddInput(ItemType.Plank, 1);
			AddOutput(ItemType.FishingNet);
			craftingTime = 4f;
			requirements.Add(new RequirementId(BiomeType.River));
			requirements.Add(new RequirementId(ResearchType.FishingNet));
			break;
		case RecipeType.MakeMagicFishingNet:
			AddInput(ItemType.FishingNet, 1);
			AddInput(ItemType.Plank, 1);
			AddOutput(ItemType.MagicFishingNet);
			craftingTime = 4f;
			requirements.Add(new RequirementId(BiomeType.River));
			requirements.Add(new RequirementId(ResearchType.MagicFishingNet));
			break;
		case RecipeType.MakeConveyorBeltWooden:
			AddInput(ItemType.Plank, 2);
			AddInput(ItemType.Wood, 2);
			AddOutput(ItemType.ConveyorBeltWooden);
			craftingTime = 4f;
			requirements.Add(new RequirementId(ResearchType.BeltWooden));
			enabled = false;
			break;
		case RecipeType.MakeConveyorBeltCloth:
			AddInput(ItemType.WoodWheel, 2);
			AddInput(ItemType.CottonCloth, 1);
			AddOutput(ItemType.ClothConveyorBelt);
			craftingTime = 6f;
			requirements.Add(new RequirementId(ResearchType.ClothConveyorBelt));
			break;
		case RecipeType.MakeConveyorBelt:
			AddInput(ItemType.ClothConveyorBelt, 1);
			AddInput(ItemType.IronIngot, 2);
			AddInput(ItemType.Gear, 1);
			AddOutput(ItemType.MetalConveyorBelt);
			requirements.Add(new RequirementId(ResearchType.MetalConveyorBelt));
			craftingTime = 6f;
			break;
		case RecipeType.MakeWaterPipe:
			enabled = false;
			break;
		case RecipeType.MakeSteamPipe:
			AddInput(ItemType.IronIngot, 1);
			AddInput(ItemType.Power, 2);
			AddOutput(ItemType.SteamPipe, 1);
			craftingTime = 3f;
			requirements.Add(new RequirementId(QuestType.SkillsForSteamPipe));
			break;
		case RecipeType.MakeMagmaPipe:
			AddInput(ItemType.Steel, 10);
			AddInput(ItemType.Power, 10);
			AddOutput(ItemType.MagmaPipe, 1);
			craftingTime = 10f;
			requirements.Add(new RequirementId(ResearchType.MagmaPipe));
			break;
		case RecipeType.MakeOmniPipe:
			AddInput(ItemType.ManaPipe, 5);
			AddInput(ItemType.Omnistone, 1);
			AddInput(ItemType.Fire, 50);
			AddOutput(ItemType.OmniPipe, 5);
			craftingTime = 20f;
			requirements.Add(new RequirementId(ResearchType.OmniPipe));
			break;
		case RecipeType.OmniTemple1:
			AddInput(ItemType.AttackPotion, 8);
			AddInput(ItemType.StealthPotion, 8);
			AddInput(ItemType.HealthPotion, 8);
			AddInput(ItemType.SpeedPotion, 8);
			AddOutput(ItemType.Star);
			craftingTime = 20f;
			overrideLocalizationKey = "ProvideOffering";
			break;
		case RecipeType.OmniTemple2:
			AddInput(ItemType.EnchantedBookRed, 5);
			AddInput(ItemType.EnchantedBookBlue, 5);
			AddInput(ItemType.EnchantedBookPurple, 5);
			AddInput(ItemType.EnchantedBookYellow, 5);
			AddOutput(ItemType.Star);
			craftingTime = 20f;
			overrideLocalizationKey = "ProvideOffering";
			break;
		case RecipeType.OmniTemple3:
			AddInput(ItemType.EnchantedFireRing, 4);
			AddInput(ItemType.EnchantedWaterRing, 4);
			AddInput(ItemType.EnchantedEarthNecklace, 4);
			AddInput(ItemType.EnchantedAirCrown, 4);
			AddOutput(ItemType.Star);
			craftingTime = 20f;
			overrideLocalizationKey = "ProvideOffering";
			break;
		case RecipeType.OmniTemple4:
			AddInput(ItemType.RailTileMagic, 4);
			AddInput(ItemType.MagicBoatComponent, 4);
			AddInput(ItemType.MagicConveyorBelt, 4);
			AddInput(ItemType.AirshipComponent, 4);
			AddOutput(ItemType.Star);
			craftingTime = 20f;
			overrideLocalizationKey = "ProvideOffering";
			break;
		case RecipeType.OmniTemple5:
			AddInput(ItemType.FireEther, 3);
			AddInput(ItemType.WaterEther, 3);
			AddInput(ItemType.EarthEther, 3);
			AddInput(ItemType.AirEther, 3);
			AddOutput(ItemType.Star);
			craftingTime = 20f;
			overrideLocalizationKey = "ProvideOffering";
			break;
		case RecipeType.OmniTemple6:
			AddInput(ItemType.MagicCloak, 6);
			AddInput(ItemType.MagicPants, 6);
			AddInput(ItemType.MagicBoots, 6);
			AddInput(ItemType.MagicHat, 6);
			AddOutput(ItemType.Star);
			craftingTime = 20f;
			overrideLocalizationKey = "ProvideOffering";
			break;
		case RecipeType.OmniTemple7:
			AddInput(ItemType.BerryCake, 3);
			AddInput(ItemType.ApplePie, 6);
			AddInput(ItemType.DragonPunch, 10);
			AddInput(ItemType.ResearchTomeGeneral, 20);
			AddOutput(ItemType.Star);
			craftingTime = 20f;
			overrideLocalizationKey = "ProvideOffering";
			break;
		case RecipeType.OmniTemple8:
			AddInput(ItemType.ResearchTomeIndustry3, 4);
			AddOutput(ItemType.Star);
			craftingTime = 20f;
			overrideLocalizationKey = "ProvideOffering";
			break;
		case RecipeType.OmniTemple9:
			AddInput(ItemType.ResearchTomeMagic3, 3);
			AddOutput(ItemType.Star);
			craftingTime = 20f;
			overrideLocalizationKey = "ProvideOffering";
			break;
		case RecipeType.CreateRailCart:
		case RecipeType.CreateHarvester:
			enabled = false;
			break;
		case RecipeType.DrawWater:
			AddOutput(ItemType.Water, 1);
			craftingTime = 2f;
			enabled = false;
			break;
		case RecipeType.MakeIronWheel:
			AddInput(ItemType.IronIngot, 2);
			AddInput(ItemType.Power, 4);
			AddOutput(ItemType.IronWheel);
			craftingTime = 10f;
			break;
		case RecipeType.MakeIronIngot:
			AddInput(ItemType.IronOre, 2);
			AddInput(ItemType.Fire, 2);
			AddOutput(ItemType.IronIngot);
			requirements.Add(new RequirementId(NaturalResource.IronOre));
			craftingTime = 6f;
			break;
		case RecipeType.MakeCopperIngot:
			AddInput(ItemType.CopperOre, 2);
			AddInput(ItemType.Fire, 2);
			AddOutput(ItemType.CopperIngot);
			craftingTime = 6f;
			requirements.Add(new RequirementId(NaturalResource.CopperOre));
			break;
		case RecipeType.MakeGlass:
			AddInput(ItemType.Quartz, 4);
			AddInput(ItemType.Fire, 4);
			AddOutput(ItemType.GlassPanel);
			craftingTime = 4f;
			requirements.Add(new RequirementId(ResearchType.Glassmaking));
			break;
		case RecipeType.MakeSteel:
			AddInput(ItemType.IronIngot, 4);
			AddInput(ItemType.Fire, 4);
			AddOutput(ItemType.Steel);
			craftingTime = 6f;
			requirements.Add(new RequirementId(ResearchType.Steel));
			break;
		case RecipeType.MakeSolarCell:
			AddInput(ItemType.CopperWire, 4);
			AddInput(ItemType.GlassPanel, 2);
			AddInput(ItemType.Steel, 1);
			AddOutput(ItemType.SolarCell);
			craftingTime = 6f;
			requirements.Add(new RequirementId(ResearchType.SolarPower));
			enabled = false;
			break;
		case RecipeType.MakeFishBait:
			AddInput(ItemType.Grain, 2);
			AddOutput(ItemType.FishFood);
			craftingTime = 6f;
			requirements.Add(RequirementId.BiomeTownLevel(BiomeType.River, 0));
			break;
		case RecipeType.MakeGoldIngot:
			AddInput(ItemType.GoldOre, 4);
			AddInput(ItemType.Fire, 4);
			AddOutput(ItemType.GoldIngot);
			craftingTime = 8f;
			requirements.Add(new RequirementId(NaturalResource.GoldOre));
			break;
		case RecipeType.SmeltSilverIngot:
			AddInput(ItemType.SilverOre, 4);
			AddInput(ItemType.Fire, 4);
			AddOutput(ItemType.SilverIngot);
			craftingTime = 8f;
			requirements.Add(new RequirementId(NaturalResource.SilverOre));
			break;
		case RecipeType.SmeltPurifiedMana:
			AddInput(ItemType.Mana, 2);
			AddInput(ItemType.Fire, 4);
			AddOutput(ItemType.PurifiedMana);
			AddProductivityUpgrade(BuildingType.ManaTemple);
			craftingTime = 8f;
			break;
		case RecipeType.SmeltPurifiedFire:
			AddInput(ItemType.RedRuby, 4);
			AddInput(ItemType.Fire, 5);
			AddOutput(ItemType.PurifiedFire);
			AddProductivityUpgrade(BuildingType.FireTemple);
			requirements.Add(new RequirementId(ResearchType.FirePurification));
			craftingTime = 10f;
			break;
		case RecipeType.SmeltPurifiedWater:
			AddInput(ItemType.BlueSapphire, 4);
			AddInput(ItemType.Fire, 5);
			AddOutput(ItemType.PurifiedWater);
			AddProductivityUpgrade(BuildingType.WaterTemple);
			requirements.Add(new RequirementId(ResearchType.WaterPurification));
			craftingTime = 10f;
			break;
		case RecipeType.SmeltPurifiedEarth:
			AddInput(ItemType.PurpleAmethyst, 4);
			AddInput(ItemType.Fire, 5);
			AddOutput(ItemType.PurifiedEarth);
			AddProductivityUpgrade(BuildingType.EarthTemple);
			requirements.Add(new RequirementId(ResearchType.EarthPurification));
			craftingTime = 10f;
			break;
		case RecipeType.SmeltPurifiedAir:
			AddInput(ItemType.YellowTopaz, 4);
			AddInput(ItemType.Fire, 5);
			AddOutput(ItemType.PurifiedAir);
			AddProductivityUpgrade(BuildingType.AirTemple);
			requirements.Add(new RequirementId(ResearchType.AirPurification));
			craftingTime = 10f;
			break;
		case RecipeType.Teleport:
			enabled = false;
			break;
		case RecipeType.GenerateSteam:
			AddInput(ItemType.Water, 1);
			AddInput(ItemType.Fire, 1);
			AddOutput(ItemType.Steam, 2);
			craftingTime = 1f;
			break;
		case RecipeType.GenerateShrineWater:
			AddInput(ItemType.UtilityElementalWaterPower, 1);
			AddOutput(ItemType.Water, 10);
			craftingTime = 4f;
			break;
		case RecipeType.GenerateShrineFire:
			AddInput(ItemType.UtilityElementalFirePower, 1);
			AddOutput(ItemType.Fire, 10);
			craftingTime = 4f;
			break;
		case RecipeType.GenerateShrinePower:
			AddInput(ItemType.UtilityElementalEarthPower, 1);
			AddOutput(ItemType.Power, 10);
			craftingTime = 4f;
			break;
		case RecipeType.GenerateShrineSteam:
			AddInput(ItemType.UtilityElementalAirPower, 1);
			AddOutput(ItemType.Steam, 10);
			craftingTime = 4f;
			break;
		case RecipeType.ApplyFireBoost:
			AddInput(ItemType.PurifiedFire, 1);
			AddOutput(ItemType.UtilitySendFireBoost);
			AddOutput(ItemType.DepletedFire);
			craftingTime = 1f;
			enabled = false;
			break;
		case RecipeType.ApplyWaterBoost:
			AddInput(ItemType.PurifiedWater, 1);
			AddOutput(ItemType.UtilitySendWaterBoost);
			AddOutput(ItemType.DepletedWater);
			craftingTime = 1f;
			enabled = false;
			break;
		case RecipeType.ApplyEarthBoost:
			AddInput(ItemType.PurifiedEarth, 1);
			AddOutput(ItemType.UtilitySendEarthBoost);
			AddOutput(ItemType.DepletedEarth);
			craftingTime = 1f;
			enabled = false;
			break;
		case RecipeType.ApplyAirBoost:
			AddInput(ItemType.PurifiedAir, 1);
			AddOutput(ItemType.UtilitySendAirBoost);
			AddOutput(ItemType.DepletedAir);
			craftingTime = 1f;
			enabled = false;
			break;
		case RecipeType.WaterWheelPower:
			AddOutput(ItemType.Power, 1);
			craftingTime = 0.5f;
			break;
		case RecipeType.SolarPanelPower:
			AddOutput(ItemType.Power, 50);
			craftingTime = 0.5f;
			requirements.Add(new RequirementId(BiomeType.Desert));
			break;
		case RecipeType.SteamPower:
			AddInput(ItemType.Steam, 1);
			AddOutput(ItemType.Power, 1);
			craftingTime = 1f;
			break;
		case RecipeType.Explore1:
			AddInput(ItemType.YellowCoin, 10);
			AddOutput(ItemType.ExplorationCoin, 1);
			craftingTime = 10f;
			enabled = false;
			break;
		case RecipeType.PumpWater:
			AddInput(ItemType.Power, 1);
			AddOutput(ItemType.Water, 2);
			craftingTime = 1f;
			break;
		case RecipeType.PumpWaterSteam:
			AddInput(ItemType.Steam, 1);
			AddOutput(ItemType.Water, 2);
			craftingTime = 1f;
			enabled = false;
			break;
		case RecipeType.MakeGear:
			AddInput(ItemType.IronIngot, 1);
			AddInput(ItemType.Power, 2);
			AddOutput(ItemType.Gear);
			craftingTime = 10f;
			break;
		case RecipeType.MakeCopperWire:
			AddInput(ItemType.CopperIngot, 1);
			AddInput(ItemType.Power, 2);
			AddOutput(ItemType.CopperWire);
			requirements.Add(new RequirementId(QuestType.CopperSkillForWire));
			craftingTime = 10f;
			break;
		case RecipeType.GrindFlour:
			LoadBasic(ItemType.Grain, 3, ItemType.Flour);
			craftingTime = 4f;
			break;
		case RecipeType.RefineSugar:
			AddInput(ItemType.Sugar, 2);
			AddOutput(ItemType.RefinedSugar);
			craftingTime = 5f;
			requirements.Add(new RequirementId(QuestType.SugarForRefinedSugar));
			break;
		case RecipeType.DiffuseManaPipeItem:
			AddInput(ItemType.ManaPipeItem, 1);
			AddOutput(ItemType.FilterPurifiedElement);
			overrideLocalizationKey = "ReceiveMana";
			craftingTime = 0.25f;
			enabled = false;
			break;
		case RecipeType.GrindAnimalFeed:
			LoadBasic(ItemType.Grain, 2, ItemType.AnimalFeed);
			craftingTime = 2f;
			requirements.Add(new RequirementId(QuestType.FlourForAnimalFeed));
			break;
		case RecipeType.MakeAnimalFeedCarrots:
			LoadBasic(ItemType.Carrot, 2, ItemType.AnimalFeed);
			craftingTime = 2f;
			enabled = false;
			break;
		case RecipeType.MakeAnimalFeedPotatoes:
			LoadBasic(ItemType.Potato, 2, ItemType.AnimalFeed);
			craftingTime = 2f;
			enabled = false;
			break;
		case RecipeType.BakeBread:
			AddInput(ItemType.Flour, 2);
			AddInput(ItemType.Fire, 1);
			AddOutput(ItemType.Bread);
			craftingTime = 4f;
			break;
		case RecipeType.BakePotatoBread:
			AddInput(ItemType.Flour, 1);
			AddInput(ItemType.Potato, 1);
			AddInput(ItemType.Fire, 1);
			AddOutput(ItemType.Bread);
			craftingTime = 4f;
			enabled = false;
			break;
		case RecipeType.MakeEther:
			AddInput(ItemType.Steam, 10);
			AddInput(ItemType.ManaPower, 4);
			AddOutput(ItemType.ManaEther, 1);
			craftingTime = 25f;
			break;
		case RecipeType.MakeFireEther:
			AddInput(ItemType.Steam, 10);
			AddInput(ItemType.UtilityElementalFirePower, 4);
			AddOutput(ItemType.FireEther, 1);
			requirements.Add(new RequirementId(ResearchType.FireEther));
			craftingTime = 25f;
			break;
		case RecipeType.MakeWaterEther:
			AddInput(ItemType.Steam, 10);
			AddInput(ItemType.UtilityElementalWaterPower, 4);
			AddOutput(ItemType.WaterEther, 1);
			requirements.Add(new RequirementId(ResearchType.WaterEther));
			craftingTime = 25f;
			break;
		case RecipeType.MakeEarthEther:
			AddInput(ItemType.Steam, 10);
			AddInput(ItemType.UtilityElementalEarthPower, 4);
			AddOutput(ItemType.EarthEther, 1);
			requirements.Add(new RequirementId(ResearchType.EarthEther));
			craftingTime = 25f;
			break;
		case RecipeType.MakeAirEther:
			AddInput(ItemType.Steam, 10);
			AddInput(ItemType.UtilityElementalAirPower, 4);
			AddOutput(ItemType.AirEther, 1);
			requirements.Add(new RequirementId(ResearchType.AirEther));
			craftingTime = 25f;
			break;
		case RecipeType.ExtractGemShards:
			AddInput(ItemType.FilterCrushable, 1);
			AddOutput(ItemType.FilterCrushResult, 2);
			craftingTime = 10f;
			enabled = false;
			break;
		case RecipeType.MakeStoneBrick:
			AddInput(ItemType.Stone, 3);
			AddOutput(ItemType.StoneSlab);
			craftingTime = 4f;
			break;
		case RecipeType.MakeQuartzFromStone:
			AddInput(ItemType.Stone, 8);
			AddOutput(ItemType.Quartz);
			craftingTime = 10f;
			requirements.Add(new RequirementId(QuestType.RefinedStoneBricksForQuartz));
			break;
		case RecipeType.FarmGrain:
			AddOutput(ItemType.Grain);
			craftingTime = 2f;
			enabled = false;
			break;
		case RecipeType.FarmHerbs:
			AddOutput(ItemType.Herb);
			craftingTime = 3f;
			enabled = false;
			break;
		case RecipeType.FarmSugar:
			AddOutput(ItemType.Sugar);
			craftingTime = 4f;
			enabled = false;
			break;
		case RecipeType.FarmApples:
			AddOutput(ItemType.Apple);
			craftingTime = 2f;
			enabled = false;
			break;
		case RecipeType.FarmBerries:
			AddOutput(ItemType.Berries);
			craftingTime = 2f;
			enabled = false;
			break;
		case RecipeType.FarmCarrots:
			AddOutput(ItemType.Carrot);
			craftingTime = 3f;
			enabled = false;
			break;
		case RecipeType.FarmPotatoes:
			AddOutput(ItemType.Potato);
			craftingTime = 3f;
			enabled = false;
			break;
		case RecipeType.FarmTomatoes:
			AddOutput(ItemType.Tomato);
			craftingTime = 3f;
			enabled = false;
			break;
		case RecipeType.FarmCotton:
			AddOutput(ItemType.Cotton);
			craftingTime = 2f;
			enabled = false;
			break;
		case RecipeType.FarmCactusFruit:
			AddOutput(ItemType.CactusFruit);
			craftingTime = 4f;
			enabled = false;
			break;
		case RecipeType.FarmDragonFruit:
			AddOutput(ItemType.DragonFruit);
			craftingTime = 4f;
			enabled = false;
			break;
		case RecipeType.FarmPears:
			AddOutput(ItemType.Pear);
			craftingTime = 2f;
			enabled = false;
			break;
		case RecipeType.ProduceWood:
			AddOutput(ItemType.Wood);
			craftingTime = 4f;
			enabled = false;
			break;
		case RecipeType.ProduceMineOutput:
			enabled = false;
			break;
		case RecipeType.MineStone:
			AddOutput(ItemType.Stone, 2);
			craftingTime = 4f;
			enabled = false;
			break;
		case RecipeType.MineCoal:
			AddOutput(ItemType.Coal, 1);
			craftingTime = 4f;
			enabled = false;
			break;
		case RecipeType.MineIronOre:
			AddOutput(ItemType.IronOre, 1);
			craftingTime = 4f;
			enabled = false;
			break;
		case RecipeType.MineMana:
			AddOutput(ItemType.Mana, 1);
			craftingTime = 6f;
			enabled = false;
			break;
		case RecipeType.MineGemRed:
			AddOutput(ItemType.RedRuby, 4);
			craftingTime = 6f;
			enabled = false;
			break;
		case RecipeType.MineGemYellow:
			AddOutput(ItemType.YellowTopaz, 4);
			craftingTime = 6f;
			enabled = false;
			break;
		case RecipeType.MineGemAqua:
			AddOutput(ItemType.BlueSapphire, 4);
			craftingTime = 6f;
			enabled = false;
			break;
		case RecipeType.MineGemPurple:
			AddOutput(ItemType.PurpleAmethyst, 4);
			craftingTime = 6f;
			enabled = false;
			break;
		case RecipeType.MineGoldOre:
			AddOutput(ItemType.GoldOre, 1);
			craftingTime = 10f;
			enabled = false;
			break;
		case RecipeType.ProduceFarmOutput:
			AddOutput(ItemType.FilterFarmOutput);
			craftingTime = 2f;
			enabled = false;
			break;
		case RecipeType.ProduceForesterOutput:
			AddInput(ItemType.RedCoin, 1);
			AddOutput(ItemType.FilterForesterOutput);
			craftingTime = 4f;
			enabled = false;
			break;
		case RecipeType.GrowTreeSeeds:
			AddInput(ItemType.Water, 2);
			AddOutput(ItemType.TreeSeeds);
			craftingTime = 8f;
			enabled = false;
			break;
		case RecipeType.GrowManaSeeds:
			AddInput(ItemType.Mana, 1);
			AddInput(ItemType.Water, 2);
			AddOutput(ItemType.ManaSeeds);
			craftingTime = 8f;
			enabled = false;
			break;
		case RecipeType.FarmWool:
			AddInput(ItemType.AnimalFeed, 2);
			AddInput(ItemType.Water, 2);
			AddOutput(ItemType.Wool);
			craftingTime = 6f;
			break;
		case RecipeType.FarmChicken:
			AddInput(ItemType.AnimalFeed, 2);
			AddOutput(ItemType.RawChicken);
			requirements.Add(new RequirementId(QuestType.EggSkillForChicken));
			craftingTime = 5f;
			break;
		case RecipeType.FarmFertilizer:
			AddInput(ItemType.AnimalFeed, 1);
			AddInput(ItemType.Water, 1);
			AddOutput(ItemType.Fertilizer);
			craftingTime = 3f;
			break;
		case RecipeType.FarmEgg:
			AddInput(ItemType.AnimalFeed, 1);
			AddOutput(ItemType.Egg);
			craftingTime = 3f;
			break;
		case RecipeType.HarvestFish:
			AddInput(ItemType.FishFood, 1);
			AddOutput(ItemType.Fish);
			craftingTime = 4f;
			enabled = false;
			break;
		case RecipeType.FarmLeather:
			AddInput(ItemType.AnimalFeed, 4);
			AddInput(ItemType.Water, 4);
			AddOutput(ItemType.Leather);
			requirements.Add(new RequirementId(QuestType.BeefSkillForLeather));
			craftingTime = 8f;
			break;
		case RecipeType.MakeTomeIndustry1:
			AddInput(ItemType.ResearchTomeGeneral, 10);
			AddInput(ItemType.IronIngot, 1);
			AddInput(ItemType.WoodWheel, 1);
			AddOutput(ItemType.ResearchTomeIndustry1);
			craftingTime = 10f;
			break;
		case RecipeType.MakeTomeIndustry2:
			AddInput(ItemType.ResearchTomeIndustry1, 2);
			AddInput(ItemType.IronWheel, 1);
			AddInput(ItemType.SteamPipe, 2);
			AddOutput(ItemType.ResearchTomeIndustry2);
			requirements.Add(new RequirementId(ResearchType.IndustryTomeIntermediate));
			craftingTime = 10f;
			break;
		case RecipeType.MakeTomeIndustry3:
			AddInput(ItemType.ResearchTomeIndustry2, 2);
			AddInput(ItemType.RailTile, 1);
			AddInput(ItemType.MetalConveyorBelt, 1);
			AddOutput(ItemType.ResearchTomeIndustry3);
			requirements.Add(new RequirementId(ResearchType.IndustryTomeAdvanced));
			craftingTime = 10f;
			break;
		case RecipeType.MakeTomeMagic1:
			AddInput(ItemType.ResearchTomeGeneral, 25);
			AddInput(ItemType.PurifiedMana, 2);
			AddOutput(ItemType.ResearchTomeMagic1);
			craftingTime = 6f;
			break;
		case RecipeType.MakeTomeMagic2:
			AddInput(ItemType.ResearchTomeMagic1, 2);
			AddInput(ItemType.MagicStoneBrick, 1);
			AddInput(ItemType.MagicPlank, 1);
			AddOutput(ItemType.ResearchTomeMagic2);
			requirements.Add(new RequirementId(ResearchType.MagicTomeIntermediate));
			craftingTime = 8f;
			break;
		case RecipeType.MakeTomeMagic3:
			AddInput(ItemType.ResearchTomeMagic2, 2);
			AddInput(ItemType.ManaEther, 1);
			AddInput(ItemType.ManaPipe, 1);
			AddOutput(ItemType.ResearchTomeMagic3);
			requirements.Add(new RequirementId(ResearchType.MagicTomeAdvanced));
			craftingTime = 10f;
			break;
		default:
			Debug.LogWarning("No recipe def for" + type);
			enabled = false;
			craftingTime = 10f;
			break;
		}
	}

	public void DeriveRequirements()
	{
	}

	public void LoadBasic(ItemType inputItem, int inputCount, ItemType outputItem)
	{
		AddInput(inputItem, inputCount);
		AddOutput(outputItem, 1);
	}

	private void AddInput(ItemType itemType, int count)
	{
		inputs.AddItem(itemType, count);
	}

	private void AddOutput(ItemType itemType)
	{
		AddOutput(itemType, 1);
	}

	private void AddOutput(ItemType itemType, int count)
	{
		outputs.AddItem(itemType, count);
		if (Item.IsUpgrade(itemType))
		{
			category = RecipeCategory.Upgrade;
		}
	}

	public static Recipe GetCopy(Recipe other)
	{
		Recipe recipe = new Recipe(other.type);
		recipe.CopyFrom(other);
		return recipe;
	}

	public void CopyFrom(Recipe other)
	{
		Clear();
		type = other.type;
		category = other.category;
		enabled = other.enabled;
		craftingTime = other.craftingTime;
		inputs.Clear();
		inputs.AddList(other.inputs);
		outputs.Clear();
		outputs.AddList(other.outputs);
		overrideLocalizationKey = other.overrideLocalizationKey;
		suppressNotification = other.suppressNotification;
		foreach (RequirementId requirement in other.requirements)
		{
			requirements.Add(requirement);
		}
		productivityUpgrades.AddRange(other.productivityUpgrades);
		FinalizeMetadata();
	}

	public void Clear()
	{
		type = RecipeType.None;
		category = RecipeCategory.DefaultItem;
		inputs.Clear();
		outputs.Clear();
		requirements.Clear();
		productivityUpgrades.Clear();
		enabled = false;
		craftingTime = 0f;
		overrideLocalizationKey = null;
	}

	public void FinalizeMetadata()
	{
	}

	private void AddProductivityUpgrade(UpgradeType t)
	{
		productivityUpgrades.Add(EntityId.FromUpgrade(t));
	}

	private void AddProductivityUpgrade(BuildingType t)
	{
		productivityUpgrades.Add(EntityId.FromBuilding(t));
	}

	private void AddProductivityUpgrade(ResearchType t)
	{
		productivityUpgrades.Add(EntityId.FromResearch(t));
	}

	public float GetBaseProductionRate()
	{
		if (craftingTime >= 0f)
		{
			return 1f / craftingTime;
		}
		return 1f;
	}

	private void AddCultivationRequirement(ResearchType cultivationResearch)
	{
		requirements.Add(new RequirementId(cultivationResearch));
	}

	public ItemType PrimaryOutputItem()
	{
		using (Dictionary<ItemType, double>.Enumerator enumerator = outputs.items.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				return enumerator.Current.Key;
			}
		}
		return ItemType.None;
	}
}
