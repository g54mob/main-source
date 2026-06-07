using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class IconManager : MonoBehaviour
{
	public SpriteAtlas spriteAtlas;

	public Sprite airCrown;

	public Sprite airshipComponent;

	public Sprite animalFeed;

	public Sprite antidote;

	public Sprite apple;

	public Sprite appleJam;

	public Sprite appleJuice;

	public Sprite bandage;

	public Sprite beef;

	public Sprite beefCooked;

	public Sprite berries;

	public Sprite berryJam;

	public Sprite berryJuice;

	public Sprite butter;

	public Sprite bread;

	public Sprite book;

	public Sprite boots;

	public Sprite cactusFruit;

	public Sprite cactusJam;

	public Sprite cake;

	public Sprite cakeBerry;

	public Sprite carrot;

	public Sprite cheese;

	public Sprite chickenCooked;

	public Sprite chickenRaw;

	public Sprite cloak;

	public Sprite cloakMagic;

	public Sprite cloth;

	public Sprite clothCotton;

	public Sprite coal;

	public Sprite conveyorBeltItemWood;

	public Sprite conveyorBeltItemCloth;

	public Sprite conveyorBeltItemMetal;

	public Sprite conveyorBeltItemMagic;

	public Sprite cotton;

	public Sprite copperOre;

	public Sprite copperWire;

	public Sprite copperIngot;

	public Sprite copperRing;

	public Sprite crown;

	public Sprite depletedMana;

	public Sprite depletedFire;

	public Sprite depletedWater;

	public Sprite depletedEarth;

	public Sprite depletedAir;

	public Sprite dragonFruit;

	public Sprite dragonPunch;

	public Sprite egg;

	public Sprite earthNecklace;

	public Sprite elixer;

	public Sprite enchantedBook;

	public Sprite enchantedBookRed;

	public Sprite enchantedBookBlue;

	public Sprite enchantedBookYellow;

	public Sprite enchantedBookPurple;

	public Sprite enchantedPlank;

	public Sprite enchantedStoneBrick;

	public Sprite fertilizer;

	public Sprite fish;

	public Sprite fishCooked;

	public Sprite fishFood;

	public Sprite fishStew;

	public Sprite fishOil;

	public Sprite fishingNet;

	public Sprite flour;

	public Sprite fruitJuice;

	public Sprite gear;

	public Sprite grain;

	public Sprite glassPanel;

	public Sprite gold;

	public Sprite goldChain;

	public Sprite goldOre;

	public Sprite goldCrown;

	public Sprite goldIngot;

	public Sprite goldRing;

	public Sprite redCoin;

	public Sprite blueCoin;

	public Sprite purpleCoin;

	public Sprite hat;

	public Sprite healthPotion;

	public Sprite herb;

	public Sprite holyWater;

	public Sprite invalidItem;

	public Sprite inventory;

	public Sprite iron;

	public Sprite ironPlate;

	public Sprite ironPlateEnchanted;

	public Sprite ironRing;

	public Sprite knowledgeOrb;

	public Sprite ironWheel;

	public Sprite leather;

	public Sprite milk;

	public Sprite ointment;

	public Sprite outfit;

	public Sprite omniCoin;

	public Sprite omnistone;

	public Sprite omnipipe;

	public Sprite omniplanter;

	public Sprite pants;

	public Sprite potionBlue;

	public Sprite potionPurple;

	public Sprite potionWhite;

	public Sprite magicBoots;

	public Sprite magicPants;

	public Sprite magicHat;

	public Sprite magicBoatComponent;

	public Sprite magicRobe;

	public Sprite magicRing;

	public Sprite magicFishingNet;

	public Sprite magma;

	public Sprite magmaPipe;

	public Sprite mana;

	public Sprite manaPipeItem;

	public Sprite meatStew;

	public Sprite medicalWrap;

	public Sprite nails;

	public Sprite necklace;

	public Sprite paper;

	public Sprite pear;

	public Sprite pearJam;

	public Sprite pearJuice;

	public Sprite pickaxe;

	public Sprite pie;

	public Sprite plank;

	public Sprite proteinShake;

	public Sprite polishedStone;

	public Sprite polishedStoneRing;

	public Sprite potato;

	public Sprite poultice;

	public Sprite purifiedMana;

	public Sprite quartz;

	public Sprite questCoin;

	public Sprite railTileItemWooden;

	public Sprite railTileItem;

	public Sprite railTileItemPowered;

	public Sprite railTileItemMagic;

	public Sprite refinedPlank;

	public Sprite refinedStone;

	public Sprite reinforcedBeam;

	public Sprite remedy;

	public Sprite research;

	public Sprite ringFire;

	public Sprite ringWater;

	public Sprite rubyRing;

	public Sprite sandwich;

	public Sprite sapphireRing;

	public Sprite shoe;

	public Sprite shovel;

	public Sprite silverIngot;

	public Sprite silverOre;

	public Sprite silverRing;

	public Sprite silverChain;

	public Sprite silverCoin;

	public Sprite star;

	public Sprite steamPipeItem;

	public Sprite steel;

	public Sprite stone;

	public Sprite stoneAxe;

	public Sprite stoneSlab;

	public Sprite sugar;

	public Sprite sugarcane;

	public Sprite timeToken;

	public Sprite tomato;

	public Sprite veggieStew;

	public Sprite ward;

	public Sprite warmCoat;

	public Sprite water;

	public Sprite waterPipe;

	public Sprite waterPipeItem;

	public Sprite wood;

	public Sprite woodAxe;

	public Sprite woodPipeItem;

	public Sprite woodWheel;

	public Sprite wool;

	public Sprite woolCloth;

	public Sprite filterWorkerFood;

	public Sprite filterWorkerRollable;

	public Sprite filterSellable;

	public Sprite filterMarketFood;

	public Sprite filterMarketGeneral;

	public Sprite filterMarketMedicine;

	public Sprite filterMarketSpecial;

	public Sprite filterSchoolKnowledge;

	public Sprite itemPackageBackground;

	public Sprite researchTomeGeneral;

	public Sprite researchTomeIndustry1;

	public Sprite researchTomeIndustry2;

	public Sprite researchTomeIndustry3;

	public Sprite researchTomeNature1;

	public Sprite researchTomeNature2;

	public Sprite researchTomeNature3;

	public Sprite researchTomeMagic1;

	public Sprite researchTomeMagic2;

	public Sprite researchTomeMagic3;

	public Sprite researchTomeFire1;

	public Sprite researchTomeFire2;

	public Sprite researchTomeFire3;

	public Sprite researchTomeWater1;

	public Sprite researchTomeWater2;

	public Sprite researchTomeWater3;

	public Sprite researchTomeEarth1;

	public Sprite researchTomeEarth2;

	public Sprite researchTomeEarth3;

	public Sprite researchTomeAir1;

	public Sprite researchTomeAir2;

	public Sprite researchTomeAir3;

	[Header("Natural Resources")]
	public Sprite resourceAirStone;

	public Sprite resourceApple;

	public Sprite resourceBerry;

	public Sprite resourceCarrot;

	public Sprite resourceCoal;

	public Sprite resourceCopper;

	public Sprite resourceCotton;

	public Sprite resourceEarthStone;

	public Sprite resourceFireStone;

	public Sprite resourceGoldOre;

	public Sprite resourceGrain;

	public Sprite resourceHerb;

	public Sprite resourceIronOre;

	public Sprite resourceManaCrystal;

	public Sprite resourcePear;

	public Sprite resourcePotato;

	public Sprite resourceRock;

	public Sprite resourceSandDunes;

	public Sprite resourceSilverOre;

	public Sprite resourceSugar;

	public Sprite resourceTomato;

	public Sprite resourceWood;

	public Sprite resourceWaterStone;

	public Sprite resourceCactusFruit;

	public Sprite resourceDragonFruit;

	public Sprite resourceFish;

	public Sprite resourceWater;

	[Header("Planted Crops")]
	public Sprite plantedApple;

	public Sprite plantedBerry;

	public Sprite plantedCarrot;

	public Sprite plantedCotton;

	public Sprite plantedGrain;

	public Sprite plantedHerb;

	public Sprite plantedPear;

	public Sprite plantedPotato;

	public Sprite plantedSugar;

	public Sprite plantedTomato;

	public Sprite plantedWood;

	public Sprite plantedCactusFruit;

	public Sprite plantedDragonFruit;

	[Header("Minigames")]
	public Sprite minigameEnergyWood;

	public Sprite minigameEnergyWater;

	public Sprite minigameEnergyDice;

	public Sprite minigameEnergyResearch;

	public Sprite minigameEnergyFarming;

	public Sprite minigameEnergyMining;

	public Sprite miningMinigameGemBlock;

	public Sprite miningMinigameRockBlock;

	public Texture2D miningDirectoryMiniBlock;

	public Sprite waterPathStart;

	public Sprite waterPathEnd;

	public Sprite farmingTerrainGrass;

	public Sprite farmingTerrainRock;

	public Sprite farmingTerrainFarm;

	public Sprite farmingTerrainWater;

	public Sprite farmingTerrainDirt;

	public Sprite farmingTerrainTrench;

	public Sprite scythe;

	public Sprite hoe;

	public Sprite wateringCan;

	public Sprite growingCrops;

	public Sprite dice1;

	public Sprite dice2;

	public Sprite dice3;

	public Sprite dice4;

	public Sprite dice5;

	public Sprite dice6;

	public Sprite diceLocked;

	public Sprite diceUnlocked;

	public Sprite diceGamePoint;

	public Sprite luckyPickaxe;

	[Header("Agents")]
	public Sprite wagon;

	public Sprite worker;

	public Sprite woodenRailCart;

	public Sprite railCart;

	public Sprite steamTrainEngine;

	public Sprite boxcar;

	public Sprite tankCar;

	public Sprite hopperCar;

	public Sprite harvester;

	public Sprite fishingBoat;

	public Sprite caravan;

	public Sprite cargoBoat;

	public Sprite airship;

	public Sprite raft;

	[Header("Gems")]
	public Sprite gemRed;

	public Sprite gemOrange;

	public Sprite gemYellow;

	public Sprite gemGreen;

	public Sprite gemAqua;

	public Sprite gemBlue;

	public Sprite gemPurple;

	public Sprite gemPink;

	public Sprite ether;

	public Sprite etherFire;

	public Sprite etherWater;

	public Sprite etherEarth;

	public Sprite etherAir;

	public Sprite fireCrystal;

	public Sprite waterCrystal;

	public Sprite earthCrystal;

	public Sprite airCrystal;

	public Sprite upgrade;

	public Sprite downgrade;

	public Sprite voidOutput;

	public Sprite teleport;

	public Sprite happinessIngredient;

	[Header("Buildings")]
	public Sprite arcaneEmporium;

	public Sprite aqueduct;

	public Sprite airshipDock;

	public Sprite bakery;

	public Sprite bank;

	public Sprite barn;

	public Sprite barrel;

	public Sprite baseBuilding;

	public Sprite battery;

	public Sprite bookstore;

	public Sprite chainsawTank;

	public Sprite clothingStore;

	public Sprite crate;

	public Sprite cropHarvester;

	public Sprite crystalarium;

	public Sprite crusher;

	public Sprite desertBazaar;

	public Sprite diffuser;

	public Sprite enchanter;

	public Sprite enchantedForge;

	public Sprite etherStorage;

	public Sprite extractor;

	public Sprite fancyFoods;

	public Sprite factory;

	public Sprite farm;

	public Sprite fishery;

	public Sprite floatingIsland;

	public Sprite forester;

	public Sprite forestMonastery;

	public Sprite foundry;

	public Sprite forge;

	public Sprite furnace;

	public Sprite gemMine;

	public Sprite generalLab;

	public Sprite generalGoodsStore;

	public Sprite grainMill;

	public Sprite hardwareStore;

	public Sprite hearth;

	public Sprite house;

	public Sprite hospital;

	public Sprite harvesterHut;

	public Sprite itemGenerator;

	public Sprite incinerator;

	public Sprite jeweler;

	public Sprite jewelryStore;

	public Sprite junglePyramid;

	public Sprite kitchen;

	public Sprite library;

	public Sprite lodge;

	public Sprite lumberMill;

	public Sprite machineShop;

	public Sprite manaBattery;

	public Sprite mansion;

	public Sprite market;

	public Sprite medicineBuilding;

	public Sprite magicLab;

	public Sprite magicBoat;

	public Sprite magicObelisk;

	public Sprite megaRecharger;

	public Sprite mine;

	public Sprite mountainObservatory;

	public Sprite omnistoneStorage;

	public Sprite oreSilo;

	public Sprite packager;

	public Sprite palace;

	public Sprite railDepot;

	public Sprite recharger;

	public Sprite pantry;

	public Sprite pasture;

	public Sprite powerGear;

	public Sprite powerLine;

	public Sprite riverHarbor;

	public Sprite plainsUniversity;

	public Sprite school;

	public Sprite silo;

	public Sprite solarPanel;

	public Sprite specialtyGoodsStore;

	public Sprite stockpile;

	public Sprite stoneMason;

	public Sprite steamPowerPlant;

	public Sprite snowTreasureVault;

	public Sprite manaReactor;

	public Sprite quarry;

	public Sprite reservoir;

	public Sprite tailor;

	public Sprite techLab;

	public Sprite tractor;

	public Sprite tradingPost;

	public Sprite treasury;

	public Sprite voidBuilding;

	public Sprite waterPump;

	public Sprite well;

	public Sprite workshop;

	public Sprite fireShrine;

	public Sprite waterShrine;

	public Sprite earthShrine;

	public Sprite airShrine;

	public Sprite manaTemple;

	public Sprite fireTemple;

	public Sprite waterTemple;

	public Sprite earthTemple;

	public Sprite airTemple;

	public Sprite omniTemple;

	[Header("Filters")]
	public Sprite filterAnything;

	public Sprite filterFruit;

	public Sprite filterFuel;

	public Sprite filterPackable;

	public Sprite filterUnpackable;

	public Sprite filterEthers;

	public Sprite filterFluids;

	public Sprite filterOre;

	public Sprite filterPurifiedElement;

	public Sprite filterDepletedCrystal;

	public Sprite filterChargedCrystal;

	public Sprite filterTempleOfferings;

	public Sprite satisfactionCategoryStoneConstruction;

	public Sprite satisfactionCategoryWoodConstruction;

	[Header("Satisfaction Categories")]
	public Sprite satisfactionCategoryKnowledgeGeneral;

	public Sprite satisfactionCategoryKnowledgeNature;

	public Sprite satisfactionCategoryKnowledgeIndustry;

	public Sprite satisfactionCategoryKnowledgeMagic;

	public Sprite satisfactionCategoryKnowledgeFire;

	public Sprite satisfactionCategoryKnowledgeWater;

	public Sprite satisfactionCategoryKnowledgeEarth;

	public Sprite satisfactionCategoryKnowledgeAir;

	[Header("Structures")]
	public Sprite chute;

	public Sprite conveyorBeltWood;

	public Sprite conveyorBeltCloth;

	public Sprite conveyorBeltMetal;

	public Sprite conveyorBeltMagic;

	public Sprite railTileMagic;

	public Sprite railTilePowered;

	public Sprite woodenRail;

	public Sprite rail;

	public Sprite steamPipe;

	public Sprite treePlanter;

	public Sprite manaPipe;

	public Sprite mineShaft;

	public Sprite waterWheel;

	[Header("Menus")]
	public Sprite explore;

	public Sprite harvest;

	public Sprite panelBuildings;

	public Sprite panelMinigames;

	public Sprite panelFarming;

	public Sprite panelClickables;

	public Sprite panelMining;

	public Sprite panelCrafting;

	public Sprite panelHarvesting;

	public Sprite panelStorage;

	public Sprite panelWorld;

	public Sprite panelResearch;

	public Sprite panelUpgrades;

	public Sprite panelGameMenu;

	public Sprite panelLog;

	public Sprite panelControls;

	public Sprite panelMarkets;

	public Sprite researchCategory;

	[Header("Utility")]
	public Sprite autoTradeLocalBalance;

	public Sprite autoTradeGlobalBalance;

	public Sprite autoTradeLocalFill;

	public Sprite autoTradeGlobalFill;

	public Sprite filter;

	public Sprite invalidSlash;

	public Sprite workUnits;

	public Sprite productionTime;

	public Sprite productionSpeedBoost;

	public Sprite happinessSpeedBoost;

	public Sprite powerSteam;

	public Sprite powerManaConnector;

	public Sprite powerMana;

	public Sprite powerElementalFire;

	public Sprite powerElementalWater;

	public Sprite powerElementalAir;

	public Sprite powerElementalEarth;

	public Sprite sendBoostFire;

	public Sprite sendBoostWater;

	public Sprite sendBoostEarth;

	public Sprite sendBoostAir;

	public Sprite powerRotational;

	public Sprite perkPoint;

	public Sprite elementalFireBoost;

	public Sprite elementalWaterBoost;

	public Sprite elementalEarthBoost;

	public Sprite elementalAirBoost;

	public Sprite experiencePointBlue;

	public Sprite experiencePointGreen;

	public Sprite experiencePointOrb;

	public Sprite experiencePointPurple;

	public Sprite experiencePointYellow;

	public Sprite experiencePointText;

	public Sprite exploration;

	public Sprite steamBoost;

	public Sprite resourceRegenBoost;

	public Sprite houseUpgrade;

	public Sprite infoButton;

	public Sprite accessIn;

	public Sprite accessOut;

	public Sprite accessInOut;

	public Sprite waterBlock;

	public Sprite moveTrainCargo;

	public Sprite locked;

	public Sprite unknownItem;

	public Sprite satisfactionCheckmark;

	public Sprite workerSpeedBoost;

	public Sprite affinity;

	public Sprite cropYield;

	public Sprite miningYield;

	public Sprite consumptionDuration;

	public Sprite happinessDuration;

	public Sprite coinBoostYellow;

	public Sprite coinBoostRed;

	public Sprite coinBoostBlue;

	public Sprite coinBoostPurple;

	public Sprite omnistoneBoost;

	public Sprite farmingPlots;

	public Sprite land;

	public Sprite skill;

	public Sprite resourceRegen;

	public Sprite caratExpanded;

	public Sprite caratCollapsed;

	public Sprite caratUp;

	public Sprite caratDown;

	public Sprite regenerateFish;

	public Sprite delete;

	public Sprite productionArrow;

	public Sprite importOn;

	public Sprite importOff;

	public Sprite tradeModeNoneOn;

	public Sprite tradeModeNoneOff;

	public Sprite exportOn;

	public Sprite exportOff;

	public Sprite townReset;

	public Sprite buttonBackgroundCombined;

	public Sprite buttonBackgroundTransparentOutline;

	public Sprite buttonBackgroundSimple;

	public Sprite specialtyOff;

	public Sprite specialtyOn;

	public Sprite speedStopped;

	public Sprite speedNormal;

	public Sprite speedFast;

	public Sprite speedUltra;

	public Sprite rewardBoost;

	public Sprite increasing;

	public Sprite decreasing;

	[Header("Upgrades")]
	public Sprite sellSpeed;

	[Header("Research")]
	public Sprite researchSilver;

	[Header("Market Categories")]
	public Sprite categoryFoodBasic;

	public Sprite categoryFoodGourmet;

	public Sprite categoryGeneralGoods;

	public Sprite categorySpecialtyGoods;

	public Sprite categoryMedicine;

	public Sprite categoryKnowledge;

	[Header("Build Categories")]
	public Sprite categoryBuilding;

	public Sprite categoryFarming;

	public Sprite categoryPower;

	public Sprite categoryTools;

	[Header("Research")]
	public Sprite civics1;

	public Sprite civics2;

	public Sprite civics3;

	public Sprite civics4;

	public Sprite civics5;

	public Sprite researchPointsGeneral;

	public Sprite researchPointsAgriculture;

	public Sprite researchPointsIndustry;

	public Sprite researchPointsMedicine;

	public Sprite researchPointsMagic;

	public Sprite researchPointsFire;

	public Sprite researchPointsWater;

	public Sprite researchPointsEarth;

	public Sprite researchPointsAir;

	public Sprite researchPointsInfinite;

	public Sprite grainProcessingSpeed;

	public Sprite stoneProcessingSpeed;

	public Sprite woodProcessingSpeed;

	public Sprite metalProcessingSpeed;

	public Sprite cashRegister;

	public Sprite friendFace;

	public Sprite friendFace64;

	public Sprite magicMedicine;

	public Sprite magicTech;

	public Sprite logicBasic;

	public Sprite logicIntermediate;

	public Sprite logicAdvanced;

	[Header("Biomes")]
	public Sprite biomeDesert;

	public Sprite biomePlains;

	public Sprite biomeSnow;

	public Sprite biomeJungle;

	public Sprite biomeForest;

	public Sprite biomeMagic;

	public Sprite biomeRiver;

	public Sprite biomeMountains;

	public Sprite biomeDesertMedium;

	public Sprite biomePlainsMedium;

	public Sprite biomeSnowMedium;

	public Sprite biomeJungleMedium;

	public Sprite biomeForestMedium;

	public Sprite biomeMagicMedium;

	public Sprite biomeRiverMedium;

	public Sprite biomeMountainsMedium;

	[Header("Misc")]
	public Sprite tutorial;

	public Sprite search;

	public Sprite happiness1;

	public Sprite happiness2;

	public Sprite happiness3;

	public Sprite happiness4;

	public Sprite happiness5;

	public Sprite happinessGeneral;

	public Sprite happiness16;

	public Sprite techLevel;

	public Sprite housingLevel;

	public Sprite population;

	public Sprite townLevel;

	public Sprite victory;

	public Sprite quests;

	public Sprite pause;

	public Sprite pauseStateDefault;

	public Sprite unpause;

	public Sprite play;

	public Sprite caratLeft;

	public Sprite caratRight;

	public Sprite automaticAssignmentOn;

	public Sprite automaticAssignmentOff;

	public Sprite automaticClaimOn;

	public Sprite automaticClaimOff;

	public Sprite automaticClaimNeutral;

	public Sprite controlSchemeKeyboard;

	public Sprite controlSchemeGamepad;

	public Sprite priorityHigh;

	public Sprite priorityHighest;

	public Sprite priorityRegular;

	public Sprite priorityDefault;

	public Sprite priorityLow;

	public Sprite priorityLowest;

	public Sprite productionLimitOn;

	public Sprite productionLimitOff;

	public Sprite upgradeOn;

	public Sprite upgradeOff;

	public Sprite tierNumeral1;

	public Sprite tierNumeral2;

	public Sprite tierNumeral3;

	public Sprite tierNumeral4;

	public Sprite tierNumeral5;

	public Sprite tierNumeralSmall1;

	public Sprite tierNumeralSmall2;

	public Sprite tierNumeralSmall3;

	public Sprite tierNumeralSmall4;

	public Sprite tierNumeralSmall5;

	public Sprite unlock;

	public Sprite menuQuestionMark;

	public Sprite activeStateOn;

	public Sprite activeStateOff;

	public Sprite load;

	public Sprite checkboxOn;

	public Sprite checkboxOff;

	public Sprite checkboxImpossible;

	public Sprite valueTrue;

	public Sprite valueFalse;

	public Sprite filterUnpackedOnly;

	public Sprite filterRequired;

	public Sprite filterExcluded;

	public Sprite inputLMB;

	public Sprite inputMMB;

	public Sprite inputRMB;

	public Sprite controllerButtonColorA;

	public Sprite controllerButtonColorB;

	public Sprite controllerButtonColorX;

	public Sprite controllerButtonColorY;

	public Sprite controllerButtonPlainA;

	public Sprite controllerButtonPlainB;

	public Sprite controllerButtonPlainX;

	public Sprite controllerButtonPlainY;

	public Sprite controllerButtonPS4_Circle;

	public Sprite controllerButtonPS4_Square;

	public Sprite controllerButtonPS4_Triangle;

	public Sprite controllerButtonPS4_X;

	public Sprite backgroundPlains;

	public Sprite backgroundRiver;

	public Sprite backgroundForest;

	public Sprite backgroundMountains;

	public Sprite backgroundDesert;

	public Sprite backgroundJungle;

	public Sprite backgroundSnow;

	public Sprite backgroundMagic;

	public Sprite buttonBackgroundPlains;

	public Sprite buttonBackgroundRiver;

	public Sprite buttonBackgroundForest;

	public Sprite buttonBackgroundMountains;

	public Sprite buttonBackgroundDesert;

	public Sprite buttonBackgroundJungle;

	public Sprite buttonBackgroundSnow;

	public Sprite buttonBackgroundMagic;

	public Sprite buttonHighlightOutline;

	public Sprite buttonHighlightSolid;

	public Sprite arrowNavigateBack;

	private static IconManager instance;

	private Sprite[] terrainTextureSprites;

	private readonly Dictionary<(ItemType, int), Sprite> modifiedSpriteDictionary = new Dictionary<(ItemType, int), Sprite>();

	public static IconManager Instance => instance;

	private void Awake()
	{
		instance = this;
	}

	public static Texture2D TextureFromSprite(Sprite sprite)
	{
		_ = null == sprite;
		Texture2D texture2D = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
		Color[] pixels = sprite.texture.GetPixels((int)sprite.rect.x, (int)sprite.rect.y, (int)sprite.rect.width, (int)sprite.rect.height);
		texture2D.SetPixels(pixels);
		texture2D.Apply();
		return texture2D;
	}

	public static Sprite SpriteForTradeMode(TradeMode t)
	{
		return t switch
		{
			TradeMode.Export => instance.exportOn, 
			TradeMode.Import => instance.importOn, 
			TradeMode.None => instance.tradeModeNoneOff, 
			TradeMode.Off => instance.tradeModeNoneOn, 
			TradeMode.AutoTradeLocalBalance => instance.autoTradeLocalBalance, 
			TradeMode.AutoTradeGlobalBalance => instance.autoTradeGlobalBalance, 
			TradeMode.AutoTradeLocalFill => instance.autoTradeLocalFill, 
			TradeMode.AutoTradeGlobalFill => instance.autoTradeGlobalFill, 
			_ => null, 
		};
	}

	public static Sprite SpriteForBuildingCategory(BuildingCategory t)
	{
		return t switch
		{
			BuildingCategory.Housing => Instance.house, 
			BuildingCategory.Cultivation => SpriteForMenuPanel(MenuPanelType.Cultivation), 
			BuildingCategory.Prospecting => SpriteForMenuPanel(MenuPanelType.Prospecting), 
			BuildingCategory.Harvesting => SpriteForMenuPanel(MenuPanelType.Harvesting), 
			BuildingCategory.Research => instance.researchCategory, 
			BuildingCategory.Trading => SpriteForMenuPanel(MenuPanelType.Trading), 
			BuildingCategory.Markets => instance.panelMarkets, 
			BuildingCategory.Production => SpriteForMenuPanel(MenuPanelType.CombinedProduction), 
			BuildingCategory.Storage => Instance.panelStorage, 
			BuildingCategory.None => Instance.townLevel, 
			_ => null, 
		};
	}

	public static Sprite SpriteForHarvestRecipe(HarvestRecipeType t)
	{
		switch (t)
		{
		case HarvestRecipeType.FishingBoatNet:
			return instance.fishingNet;
		case HarvestRecipeType.FishingBoatMagicNet:
			return instance.magicFishingNet;
		case HarvestRecipeType.Tree:
		case HarvestRecipeType.AppleTree:
		case HarvestRecipeType.PearTree:
		case HarvestRecipeType.Wheat:
		case HarvestRecipeType.FishSource:
		case HarvestRecipeType.HerbBush:
		case HarvestRecipeType.BerryBush:
		case HarvestRecipeType.CarrotPlant:
		case HarvestRecipeType.PotatoPlant:
		case HarvestRecipeType.TomatoPlant:
		case HarvestRecipeType.CottonPlant:
		case HarvestRecipeType.SugarCane:
		case HarvestRecipeType.DragonFruitTree:
		case HarvestRecipeType.CactusFruitTree:
		case HarvestRecipeType.Rock:
		case HarvestRecipeType.IronOre:
		case HarvestRecipeType.CoalOre:
		case HarvestRecipeType.CopperOre:
		case HarvestRecipeType.GoldOre:
		case HarvestRecipeType.WaterSource:
		case HarvestRecipeType.ManaCrystal:
		case HarvestRecipeType.Ruby:
		case HarvestRecipeType.Topaz:
		case HarvestRecipeType.Sapphire:
		case HarvestRecipeType.Amethyst:
		case HarvestRecipeType.SilverOre:
		case HarvestRecipeType.ChainsawTree:
		case HarvestRecipeType.DrillRock:
		case HarvestRecipeType.DrillIron:
		case HarvestRecipeType.DrillCoal:
		case HarvestRecipeType.DrillCopper:
		case HarvestRecipeType.DrillSilver:
		case HarvestRecipeType.DrillGold:
		case HarvestRecipeType.DrillRuby:
		case HarvestRecipeType.DrillTopaz:
		case HarvestRecipeType.DrillAmethyst:
		case HarvestRecipeType.DrillSapphire:
		case HarvestRecipeType.DrillMana:
		case HarvestRecipeType.CropHarvesterGrain:
		case HarvestRecipeType.CropHarvesterBerries:
		case HarvestRecipeType.CropHarvesterHerb:
		case HarvestRecipeType.CropHarvesterApple:
		case HarvestRecipeType.CropHarvesterPear:
		case HarvestRecipeType.CropHarvesterCarrot:
		case HarvestRecipeType.CropHarvesterPotato:
		case HarvestRecipeType.CropHarvesterTomato:
		case HarvestRecipeType.CropHarvesterCotton:
		case HarvestRecipeType.CropHarvesterSugar:
		case HarvestRecipeType.CropHarvesterDragonFruit:
		case HarvestRecipeType.CropHarvesterCactusFruit:
		case HarvestRecipeType.HarvestSand:
		case HarvestRecipeType.AqueductHarvestWater:
		{
			if (Crafting.harvestRecipeCache.TryGetValue(t, out var value))
			{
				return SpriteForItem(value.harvestedItemType);
			}
			break;
		}
		}
		return null;
	}

	public static Sprite SpriteForBiome(BiomeType t)
	{
		return t switch
		{
			BiomeType.Desert => instance.biomeDesert, 
			BiomeType.Plains => instance.biomePlains, 
			BiomeType.Jungle => instance.biomeJungle, 
			BiomeType.Magic => instance.biomeMagic, 
			BiomeType.Mountains => instance.biomeMountains, 
			BiomeType.River => instance.biomeRiver, 
			BiomeType.Snow => instance.biomeSnow, 
			BiomeType.Forest => instance.biomeForest, 
			_ => null, 
		};
	}

	public static Sprite MediumSpriteForBiome(BiomeType t)
	{
		return t switch
		{
			BiomeType.Desert => instance.biomeDesertMedium, 
			BiomeType.Plains => instance.biomePlainsMedium, 
			BiomeType.Jungle => instance.biomeJungleMedium, 
			BiomeType.Magic => instance.biomeMagicMedium, 
			BiomeType.Mountains => instance.biomeMountainsMedium, 
			BiomeType.River => instance.biomeRiverMedium, 
			BiomeType.Snow => instance.biomeSnowMedium, 
			BiomeType.Forest => instance.biomeForestMedium, 
			_ => null, 
		};
	}

	public static Sprite SpriteForRequirement(Requirement r)
	{
		if (!(r is RequiredPopulationCount))
		{
			if (!(r is RequiredTownLevel requiredTownLevel))
			{
				if (!(r is RequiredBiome requiredBiome))
				{
					if (!(r is RequiredFullGame))
					{
						if (!(r is RequiredProductionCount requiredProductionCount))
						{
							if (!(r is RequiredNaturalResource requiredNaturalResource))
							{
								if (!(r is RequiredHarvestRecipe requiredHarvestRecipe))
								{
									if (!(r is RequiredItem requiredItem))
									{
										if (!(r is RequiredMarketSellCount requiredMarketSellCount))
										{
											if (!(r is RequiredMinBuildingCount requiredMinBuildingCount))
											{
												if (!(r is RequiredCoinSpendCount requiredCoinSpendCount))
												{
													if (!(r is RequiredMinigameLevel requiredMinigameLevel))
													{
														if (!(r is RequiredMinResearchCount))
														{
															if (!(r is RequiredResearch requiredResearch))
															{
																if (!(r is RequiredGenericFlag requiredGenericFlag))
																{
																	if (!(r is RequiredGenericCount requiredGenericCount))
																	{
																		if (!(r is RequiredSkillLevel requiredSkillLevel))
																		{
																			if (!(r is RequiredSkillXP requiredSkillXP))
																			{
																				if (!(r is RequiredSkillLevelCount requiredSkillLevelCount))
																				{
																					if (!(r is RequiredBuildingSkills requiredBuildingSkills))
																					{
																						if (!(r is RequiredUpgradeCount))
																						{
																							if (!(r is RequiredUpgrade requiredUpgrade))
																							{
																								if (!(r is RequiredPerk requiredPerk))
																								{
																									if (r is RequiredQuest requiredQuest)
																									{
																										if (Crafting.questCache.TryGetValue(requiredQuest.questType, out var value))
																										{
																											if (value.localizationEntity.type != EntityType.None)
																											{
																												return SpriteForEntity(value.localizationEntity);
																											}
																											Requirement requirement = GameManager.Instance.DisplayedRequirementForQuest(value.type);
																											if (requirement != null && requirement != r)
																											{
																												return SpriteForRequirement(requirement);
																											}
																										}
																										return null;
																									}
																									return null;
																								}
																								return SpriteForPerk(requiredPerk.perkType);
																							}
																							return SpriteForUpgrade(requiredUpgrade.upgradeType);
																						}
																						return instance.upgrade;
																					}
																					return SpriteForBuilding(requiredBuildingSkills.buildingType);
																				}
																				return SpriteForSkillType(requiredSkillLevelCount.skillType);
																			}
																			return SpriteForSkillType(requiredSkillXP.skillType);
																		}
																		if (requiredSkillLevel.skillType == SkillType.Prospecting || requiredSkillLevel.skillType == SkillType.Crafting || requiredSkillLevel.skillType == SkillType.Cultivation)
																		{
																			return SpriteForEntity(requiredSkillLevel.skillId);
																		}
																		if (requiredSkillLevel.skillType == SkillType.Harvesting && requiredSkillLevel.skillId.TryAsHarvestRecipe(out var i))
																		{
																			return SpriteForHarvestRecipe(i);
																		}
																		return null;
																	}
																	return SpriteForEntity(requiredGenericCount.imageItem);
																}
																return SpriteForEntity(requiredGenericFlag.imageItem);
															}
															return SpriteForResearch(requiredResearch.researchType);
														}
														return instance.research;
													}
													return SpriteForMenuPanel(requiredMinigameLevel.minigamePanelType);
												}
												return SpriteForItem(requiredCoinSpendCount.coinType);
											}
											if (requiredMinBuildingCount.buildingType == BuildingType.None)
											{
												return instance.panelBuildings;
											}
											return SpriteForBuilding(requiredMinBuildingCount.buildingType);
										}
										return SpriteForBuilding(requiredMarketSellCount.buildingType);
									}
									return SpriteForItem(requiredItem.itemType);
								}
								return SpriteForHarvestRecipe(requiredHarvestRecipe.harvestRecipeType);
							}
							return SpriteForNaturalResource(requiredNaturalResource.resourceType);
						}
						return SpriteForItem(requiredProductionCount.itemType);
					}
					return instance.friendFace;
				}
				return SpriteForBiome(requiredBiome.biomeType);
			}
			if (requiredTownLevel.requiredBiome != BiomeType.None)
			{
				return SpriteForBiome(requiredTownLevel.requiredBiome);
			}
			return instance.townLevel;
		}
		return instance.population;
	}

	public static Sprite SpriteForUpgrade(UpgradeType t)
	{
		if (Crafting.upgradeCache.TryGetValue(t, out var value) && value.linkedEntity.type != EntityType.None && value.linkedEntity.type != EntityType.Upgrade)
		{
			return SpriteForEntity(value.linkedEntity);
		}
		switch (t)
		{
		case UpgradeType.UpgradeEfficiency:
			return instance.upgrade;
		case UpgradeType.ConstructionEfficiency:
			return instance.reinforcedBeam;
		case UpgradeType.MarketCostFood:
			return instance.market;
		case UpgradeType.MarketCostGeneral:
			return instance.generalGoodsStore;
		case UpgradeType.MarketCostHardware:
			return instance.hardwareStore;
		case UpgradeType.MarketCostBookstore:
			return instance.bookstore;
		case UpgradeType.MarketCostClothing:
			return instance.clothingStore;
		case UpgradeType.MarketCostGourmet:
			return instance.fancyFoods;
		case UpgradeType.MarketCostApothecary:
			return instance.hospital;
		case UpgradeType.MarketCostJewelry:
			return instance.specialtyGoodsStore;
		case UpgradeType.MarketCostArcane:
			return instance.arcaneEmporium;
		case UpgradeType.ResearchSpeed:
			return instance.research;
		case UpgradeType.OmniResearchSpeed:
			return instance.research;
		case UpgradeType.SkillGainSpeed:
			return instance.skill;
		case UpgradeType.SkillEffectCrafting:
			return instance.skill;
		case UpgradeType.SkillEffectHarvesting:
			return instance.skill;
		case UpgradeType.SkillEffectCultivation:
			return instance.skill;
		case UpgradeType.SkillEffectProspecting:
			return instance.skill;
		case UpgradeType.FurnaceSpeed:
			return instance.furnace;
		case UpgradeType.HouseCost:
			return instance.house;
		case UpgradeType.HouseCapacity:
			return instance.worker;
		case UpgradeType.BuildingConstructionSpeedGrowth:
			return instance.categoryBuilding;
		case UpgradeType.FuelEfficiency:
			return instance.filterFuel;
		case UpgradeType.Exploration:
			return instance.exploration;
		case UpgradeType.Supermarket:
			return instance.market;
		case UpgradeType.SellSpeedYellowCoin:
		case UpgradeType.SellSpeedRedCoin:
		case UpgradeType.SellSpeedBlueCoin:
		case UpgradeType.SellSpeedPurpleCoin:
		case UpgradeType.SellSpeedOmniCoin:
			return instance.cashRegister;
		case UpgradeType.YellowCoinXP:
			return instance.experiencePointText;
		case UpgradeType.RedCoinXP:
			return instance.experiencePointText;
		case UpgradeType.BlueCoinXP:
			return instance.experiencePointText;
		case UpgradeType.PurpleCoinXP:
			return instance.experiencePointText;
		case UpgradeType.OmniCoinXP:
			return instance.experiencePointText;
		default:
			return instance.upgrade;
		}
	}

	public static Sprite SpriteForStructure(StructureType type)
	{
		return null;
	}

	public static Sprite SpriteForSkillType(SkillType t)
	{
		return t switch
		{
			SkillType.Crafting => instance.panelCrafting, 
			SkillType.Cultivation => instance.panelFarming, 
			SkillType.Harvesting => instance.panelHarvesting, 
			SkillType.Prospecting => instance.panelMining, 
			_ => instance.skill, 
		};
	}

	public static Sprite SpriteForModifierType(BiomeModifierType t)
	{
		switch (t)
		{
		case BiomeModifierType.CultivationProductivity:
		case BiomeModifierType.ProspectingProductivity:
		case BiomeModifierType.RecipeProductivity:
		case BiomeModifierType.BuildingEffectiveness:
		case BiomeModifierType.CraftingSpeed:
		case BiomeModifierType.Land:
			return instance.upgrade;
		default:
			return null;
		}
	}

	public static Sprite SpriteForEntity(EntityId entityId)
	{
		switch (entityId.type)
		{
		case EntityType.Building:
			return SpriteForBuilding(entityId.AsBuilding);
		case EntityType.Structure:
			return SpriteForStructure(entityId.AsStructure);
		case EntityType.Recipe:
			return SpriteForRecipeType(entityId.AsRecipe);
		case EntityType.Item:
			return SpriteForItem(entityId.AsItem);
		case EntityType.ItemConveyor:
			return SpriteForItem(entityId.AsItemConveyor);
		case EntityType.NaturalResource:
			return SpriteForNaturalResource(entityId.AsNaturalResource);
		case EntityType.Farming:
			return SpriteForNaturalResource(entityId.AsFarming);
		case EntityType.Mining:
			return SpriteForNaturalResource(entityId.AsMining);
		case EntityType.MenuPanel:
			return SpriteForMenuPanel(entityId.AsMenuPanel);
		case EntityType.Quest:
			return instance.quests;
		case EntityType.Upgrade:
			return SpriteForUpgrade(entityId.AsUpgrade);
		case EntityType.Research:
			return SpriteForResearch(entityId.AsResearch);
		case EntityType.FarmingTool:
			return SpriteForFarmingTool(entityId.AsFarmingTool);
		case EntityType.Biome:
			return SpriteForBiome(entityId.AsBiome);
		case EntityType.HarvestRecipe:
			return SpriteForHarvestRecipe(entityId.AsHarvestRecipe);
		case EntityType.Perk:
			return SpriteForPerk(entityId.AsPerk);
		case EntityType.BuildingCategory:
			return SpriteForBuildingCategory(entityId.AsBuildingCategory);
		default:
			Debug.LogError("No sprite method specified for " + entityId.type);
			return null;
		}
	}

	public static Sprite GetSprite(object obj)
	{
		if (obj == null)
		{
			return null;
		}
		if (obj is EntityId entityId)
		{
			return SpriteForEntity(entityId);
		}
		if (obj is BuildingType type)
		{
			return SpriteForBuilding(type);
		}
		if (obj is StructureType type2)
		{
			return SpriteForStructure(type2);
		}
		if (obj is ItemType itemType)
		{
			return SpriteForItem(itemType);
		}
		if (obj is Recipe r)
		{
			return SpriteForRecipe(r);
		}
		if (obj is RecipeType recipeType)
		{
			return SpriteForRecipe(Crafting.GetRecipe(recipeType));
		}
		Debug.LogError("No logic specified for GetSprite of " + obj);
		return null;
	}

	public static Sprite SpriteForMiningShape(List<Coord> offsets)
	{
		int num = 100;
		Texture2D texture2D = new Texture2D(num, num);
		texture2D.filterMode = FilterMode.Point;
		int num2 = num / 5;
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num; j++)
			{
				texture2D.SetPixel(i, j, Color.clear);
			}
		}
		Texture2D texture2D2 = instance.miningDirectoryMiniBlock;
		foreach (Coord offset in offsets)
		{
			if (offset.x < -2 || offset.x > 2 || offset.y < -2 || offset.y > 2)
			{
				continue;
			}
			Coord coord = new Coord((offset.x + 2) * num2, (-offset.y + 2) * num2);
			for (int k = 0; k < num2; k++)
			{
				for (int l = 0; l < num2; l++)
				{
					Color pixel = texture2D2.GetPixel(k, l);
					int x = k + coord.x;
					int y = l + coord.y;
					texture2D.SetPixel(x, y, pixel);
				}
			}
		}
		texture2D.Apply();
		return Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 100f);
	}

	public static Sprite CombinedSprites(params Sprite[] sprites)
	{
		if (sprites.Length == 0)
		{
			return null;
		}
		if (sprites.Length == 1)
		{
			return sprites[0];
		}
		Sprite sprite = sprites[0];
		Texture2D texture2D = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
		for (int i = 0; i < texture2D.width; i++)
		{
			for (int j = 0; j < texture2D.height; j++)
			{
				texture2D.SetPixel(i, j, Color.clear);
			}
		}
		texture2D.filterMode = FilterMode.Point;
		foreach (Sprite sprite2 in sprites)
		{
			if (null == sprite2)
			{
				continue;
			}
			Rect textureRect = sprite2.textureRect;
			int num = Mathf.RoundToInt(textureRect.position.x);
			int num2 = Mathf.RoundToInt(textureRect.position.y);
			int num3 = Mathf.RoundToInt(textureRect.size.x);
			int num4 = Mathf.RoundToInt(textureRect.size.y);
			for (int l = 0; l < num3; l++)
			{
				for (int m = 0; m < num4; m++)
				{
					Color pixel = texture2D.GetPixel(l, m);
					Color pixel2 = sprite2.texture.GetPixel(l + num, m + num2);
					if (pixel.a > 0f)
					{
						Color color = Color.Lerp(pixel, pixel2, pixel2.a);
						texture2D.SetPixel(l, m, color);
					}
					else
					{
						texture2D.SetPixel(l, m, pixel2);
					}
				}
			}
		}
		texture2D.Apply();
		return Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 100f);
	}

	public static Sprite SpriteForBuilding(BuildingType type)
	{
		return type switch
		{
			BuildingType.Aqueduct => instance.aqueduct, 
			BuildingType.Bakery => instance.bakery, 
			BuildingType.ChainsawTank => instance.chainsawTank, 
			BuildingType.GourmetKitchen => instance.kitchen, 
			BuildingType.Jeweler => instance.specialtyGoodsStore, 
			BuildingType.Bank => instance.bank, 
			BuildingType.Barrel => instance.barrel, 
			BuildingType.Pantry => instance.pantry, 
			BuildingType.Stockpile => instance.stockpile, 
			BuildingType.Warehouse => instance.barn, 
			BuildingType.RailDepot => instance.railDepot, 
			BuildingType.Base => instance.baseBuilding, 
			BuildingType.Crate => instance.crate, 
			BuildingType.Refinery => instance.crusher, 
			BuildingType.Chute => instance.chute, 
			BuildingType.WaterWheel => instance.waterWheel, 
			BuildingType.SolarPanel => instance.solarPanel, 
			BuildingType.PowerLine => instance.powerLine, 
			BuildingType.HarvesterDrill => instance.harvester, 
			BuildingType.HarvesterHut => instance.harvesterHut, 
			BuildingType.CropHarvester => instance.cropHarvester, 
			BuildingType.Tractor => instance.tractor, 
			BuildingType.Minecart => instance.railCart, 
			BuildingType.SteamTrain => instance.steamTrainEngine, 
			BuildingType.Caravan => instance.caravan, 
			BuildingType.SteamPipeline => instance.steamPipe, 
			BuildingType.MagmaPipeline => instance.magmaPipe, 
			BuildingType.OmniPipeline => instance.omnipipe, 
			BuildingType.ManaPipeline => instance.manaPipe, 
			BuildingType.Diffuser => instance.diffuser, 
			BuildingType.Enchanter => instance.enchanter, 
			BuildingType.FishingBoat => instance.fishingBoat, 
			BuildingType.FloatingIsland => instance.floatingIsland, 
			BuildingType.MagicForge => instance.enchantedForge, 
			BuildingType.ManaTransmitter => instance.extractor, 
			BuildingType.FancyFoods => instance.fancyFoods, 
			BuildingType.Furnace => instance.furnace, 
			BuildingType.Forge => instance.forge, 
			BuildingType.GrainMill => instance.grainMill, 
			BuildingType.GeneralGoods => instance.generalGoodsStore, 
			BuildingType.ClothingStore => instance.clothingStore, 
			BuildingType.Hearth => instance.hearth, 
			BuildingType.Apothecary => instance.hospital, 
			BuildingType.Incinerator => instance.incinerator, 
			BuildingType.LumberMill => instance.lumberMill, 
			BuildingType.Market => instance.market, 
			BuildingType.HardwareStore => instance.hardwareStore, 
			BuildingType.Bookstore => instance.bookstore, 
			BuildingType.MachineShop => instance.machineShop, 
			BuildingType.MedicineHut => instance.medicineBuilding, 
			BuildingType.MagicLab => instance.magicLab, 
			BuildingType.Mine => instance.mine, 
			BuildingType.Quarry => instance.quarry, 
			BuildingType.GemMine => instance.gemMine, 
			BuildingType.OmniTemple => instance.omniTemple, 
			BuildingType.Factory => instance.factory, 
			BuildingType.Foundry => instance.foundry, 
			BuildingType.Packager => instance.packager, 
			BuildingType.SteamPowerGenerator => instance.powerGear, 
			BuildingType.Airship => instance.airship, 
			BuildingType.MagicBoat => instance.magicBoat, 
			BuildingType.MagicRailTile => instance.railTileMagic, 
			BuildingType.MagicConveyorBelt => instance.conveyorBeltMagic, 
			BuildingType.Recharger => instance.recharger, 
			BuildingType.MegaRecharger => instance.megaRecharger, 
			BuildingType.Tailor => instance.tailor, 
			BuildingType.GeneralLab => instance.generalLab, 
			BuildingType.TechLab => instance.techLab, 
			BuildingType.TradingPost => instance.tradingPost, 
			BuildingType.Workshop => instance.workshop, 
			BuildingType.CropSilo => instance.silo, 
			BuildingType.OreSilo => instance.oreSilo, 
			BuildingType.JewelryStore => instance.jewelryStore, 
			BuildingType.ArcaneStore => instance.arcaneEmporium, 
			BuildingType.SteamBoiler => instance.steamPowerPlant, 
			BuildingType.ManaReactor => instance.manaReactor, 
			BuildingType.Treasury => instance.treasury, 
			BuildingType.EtherStorage => instance.etherStorage, 
			BuildingType.OmnistoneStorage => instance.omnistoneStorage, 
			BuildingType.Battery => instance.battery, 
			BuildingType.Library => instance.library, 
			BuildingType.Reservoir => instance.reservoir, 
			BuildingType.ManaBattery => instance.manaBattery, 
			BuildingType.Crystalarium => instance.crystalarium, 
			BuildingType.Void => instance.voidBuilding, 
			BuildingType.Well => instance.well, 
			BuildingType.WaterPump => instance.waterPump, 
			BuildingType.Farm => instance.farm, 
			BuildingType.Forester => instance.forester, 
			BuildingType.Pasture => instance.pasture, 
			BuildingType.Fishery => instance.fishery, 
			BuildingType.StoneMason => instance.stoneMason, 
			BuildingType.School => instance.school, 
			BuildingType.Hut => instance.house, 
			BuildingType.Lodge => instance.house, 
			BuildingType.House => instance.house, 
			BuildingType.Mansion => instance.house, 
			BuildingType.Palace => instance.house, 
			BuildingType.FireShrine => instance.fireShrine, 
			BuildingType.WaterShrine => instance.waterShrine, 
			BuildingType.EarthShrine => instance.earthShrine, 
			BuildingType.AirShrine => instance.airShrine, 
			BuildingType.ManaTemple => instance.manaTemple, 
			BuildingType.FireTemple => instance.fireTemple, 
			BuildingType.WaterTemple => instance.waterTemple, 
			BuildingType.EarthTemple => instance.earthTemple, 
			BuildingType.AirTemple => instance.airTemple, 
			BuildingType.PlainsUniversity => instance.plainsUniversity, 
			BuildingType.ForestMonastery => instance.forestMonastery, 
			BuildingType.RiverHarbor => instance.riverHarbor, 
			BuildingType.MountainObservatory => instance.mountainObservatory, 
			BuildingType.JunglePyramid => instance.junglePyramid, 
			BuildingType.DesertBazaar => instance.desertBazaar, 
			BuildingType.SnowTreasureVault => instance.snowTreasureVault, 
			BuildingType.MagicObelisk => instance.magicObelisk, 
			_ => null, 
		};
	}

	public static Sprite SpriteForRecipeType(RecipeType r)
	{
		if (Crafting.recipeCache.TryGetValue(r, out var value))
		{
			return SpriteForRecipe(value);
		}
		return null;
	}

	public static Sprite SpriteForRecipe(Recipe r)
	{
		if (r == null)
		{
			Debug.LogError("Can't load recipe sprite, null recipe");
			return null;
		}
		using (Dictionary<ItemType, double>.Enumerator enumerator = r.outputs.items.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				return SpriteForItem(enumerator.Current.Key);
			}
		}
		return null;
	}

	public static Sprite SpriteForMenuPanel(MenuPanelType t)
	{
		return t switch
		{
			MenuPanelType.Buildings => instance.panelBuildings, 
			MenuPanelType.Cultivation => instance.resourceWood, 
			MenuPanelType.Clickables => instance.panelClickables, 
			MenuPanelType.Prospecting => instance.resourceIronOre, 
			MenuPanelType.Inventory => instance.inventory, 
			MenuPanelType.Markets => instance.happinessGeneral, 
			MenuPanelType.Quests => instance.quests, 
			MenuPanelType.QuestsPopup => instance.quests, 
			MenuPanelType.InventoryPopup => instance.inventory, 
			MenuPanelType.Recipes => instance.panelCrafting, 
			MenuPanelType.Research => instance.panelResearch, 
			MenuPanelType.GameMenu => instance.panelGameMenu, 
			MenuPanelType.FileList => instance.load, 
			MenuPanelType.GameSetup => instance.load, 
			MenuPanelType.Harvesting => instance.panelHarvesting, 
			MenuPanelType.Upgrades => instance.panelUpgrades, 
			MenuPanelType.UpgradesPopup => instance.panelUpgrades, 
			MenuPanelType.World => instance.panelWorld, 
			MenuPanelType.Trading => instance.caravan, 
			MenuPanelType.TownStats => instance.population, 
			MenuPanelType.Perks => instance.questCoin, 
			MenuPanelType.TownPerks => instance.experiencePointPurple, 
			MenuPanelType.Minigames => instance.panelMinigames, 
			MenuPanelType.MinigameFarming => instance.categoryFarming, 
			MenuPanelType.MinigameResearch => instance.research, 
			MenuPanelType.MinigameWater => instance.water, 
			MenuPanelType.MinigameDice => instance.dice1, 
			MenuPanelType.MinigameMining => instance.pickaxe, 
			MenuPanelType.MinigameWood => instance.wood, 
			MenuPanelType.FullGame => instance.friendFace64, 
			MenuPanelType.ProductionConfig => instance.productionLimitOn, 
			MenuPanelType.RecipeConfig => instance.panelCrafting, 
			MenuPanelType.TimeTokens => instance.productionTime, 
			MenuPanelType.CombinedProduction => instance.panelCrafting, 
			MenuPanelType.All => instance.townLevel, 
			MenuPanelType.Log => instance.panelLog, 
			MenuPanelType.Controls => instance.panelControls, 
			_ => null, 
		};
	}

	public static Sprite SpriteForPlantedResource(NaturalResource t)
	{
		return t switch
		{
			NaturalResource.AppleTree => instance.plantedApple, 
			NaturalResource.BerryBush => instance.plantedBerry, 
			NaturalResource.CarrotPlant => instance.plantedCarrot, 
			NaturalResource.CottonPlant => instance.plantedCotton, 
			NaturalResource.Wheat => instance.plantedGrain, 
			NaturalResource.HerbBush => instance.plantedHerb, 
			NaturalResource.PearTree => instance.plantedPear, 
			NaturalResource.PotatoPlant => instance.plantedPotato, 
			NaturalResource.SugarCane => instance.plantedSugar, 
			NaturalResource.TomatoPlant => instance.plantedTomato, 
			NaturalResource.Tree => instance.plantedWood, 
			NaturalResource.CactusFruitTree => instance.plantedCactusFruit, 
			NaturalResource.DragonFruitTree => instance.plantedDragonFruit, 
			_ => null, 
		};
	}

	public static Sprite SpriteForNaturalResource(NaturalResource t)
	{
		return SpriteForNaturalResource(Item.ItemFromNaturalResource(t));
	}

	public static Sprite SpriteForNaturalResource(ItemType itemType)
	{
		return itemType switch
		{
			ItemType.YellowTopaz => instance.resourceAirStone, 
			ItemType.PurpleAmethyst => instance.resourceEarthStone, 
			ItemType.BlueSapphire => instance.resourceWaterStone, 
			ItemType.RedRuby => instance.resourceFireStone, 
			ItemType.Apple => instance.resourceApple, 
			ItemType.Berries => instance.resourceBerry, 
			ItemType.Carrot => instance.resourceCarrot, 
			ItemType.Coal => instance.resourceCoal, 
			ItemType.Cotton => instance.resourceCotton, 
			ItemType.GoldOre => instance.resourceGoldOre, 
			ItemType.SilverOre => instance.resourceSilverOre, 
			ItemType.Grain => instance.resourceGrain, 
			ItemType.Herb => instance.resourceHerb, 
			ItemType.IronOre => instance.resourceIronOre, 
			ItemType.Mana => instance.resourceManaCrystal, 
			ItemType.Pear => instance.resourcePear, 
			ItemType.Potato => instance.resourcePotato, 
			ItemType.Stone => instance.resourceRock, 
			ItemType.Sugar => instance.resourceSugar, 
			ItemType.Tomato => instance.resourceTomato, 
			ItemType.Wood => instance.resourceWood, 
			ItemType.CactusFruit => instance.resourceCactusFruit, 
			ItemType.DragonFruit => instance.resourceDragonFruit, 
			ItemType.Fish => instance.resourceFish, 
			ItemType.CopperOre => instance.resourceCopper, 
			ItemType.Water => instance.resourceWater, 
			ItemType.Quartz => instance.resourceSandDunes, 
			_ => SpriteForItem(itemType), 
		};
	}

	public static Sprite SpriteForOmniPipeItem(ItemType itemType)
	{
		if (itemType == ItemType.None)
		{
			return instance.menuQuestionMark;
		}
		return SpriteForItem(itemType);
	}

	public static Sprite SpriteForPipeItem(ItemType itemType)
	{
		return itemType switch
		{
			ItemType.Water => instance.waterPipeItem, 
			ItemType.UtilitySteamPower => instance.steamPipeItem, 
			_ => SpriteForItem(itemType), 
		};
	}

	public static Sprite SpriteForToggleState(bool toggleState)
	{
		if (!toggleState)
		{
			return instance.checkboxOff;
		}
		return instance.checkboxOn;
	}

	public static Sprite SpriteForSellCategory(ItemType itemType)
	{
		if (itemType == ItemType.None)
		{
			return instance.menuQuestionMark;
		}
		return CachedSpriteForItem(itemType, 0);
	}

	public static void TestRefreshSpriteCache(ItemType t)
	{
		if (instance.modifiedSpriteDictionary.TryGetValue((t, 0), out var value) && Crafting.cachedItemDefs.TryGetValue(t, out var value2) && value2.sprite != value)
		{
			instance.modifiedSpriteDictionary[(t, 0)] = value2.sprite;
			for (int i = 1; i < 16; i++)
			{
				instance.modifiedSpriteDictionary.Remove((t, i));
			}
		}
	}

	public static Sprite CachedSpriteForItem(ItemType itemType, int modifiers)
	{
		if (null == instance)
		{
			return DefaultSpriteForItem(itemType);
		}
		if (instance.modifiedSpriteDictionary.TryGetValue((itemType, modifiers), out var value))
		{
			return value;
		}
		Sprite sprite = Crafting.GetCachedItemDef(itemType).sprite;
		instance.modifiedSpriteDictionary[(itemType, modifiers)] = sprite;
		return sprite;
	}

	public static Sprite SpriteForProductionModifier(ProductionModifierType m)
	{
		return m switch
		{
			ProductionModifierType.Disabled => instance.activeStateOff, 
			ProductionModifierType.Worker => instance.worker, 
			ProductionModifierType.Automatic => instance.workUnits, 
			ProductionModifierType.Upgrades => instance.upgrade, 
			ProductionModifierType.OmniUpgrades => instance.omnistone, 
			ProductionModifierType.GlobalSpeed => instance.productionTime, 
			ProductionModifierType.Happiness => instance.happinessGeneral, 
			ProductionModifierType.Steam => instance.steamBoost, 
			ProductionModifierType.FireBoost => instance.elementalFireBoost, 
			ProductionModifierType.WaterBoost => instance.elementalWaterBoost, 
			ProductionModifierType.EarthBoost => instance.elementalEarthBoost, 
			ProductionModifierType.AirBoost => instance.elementalAirBoost, 
			ProductionModifierType.YellowCoin => SpriteForItem(ItemType.UtilityYellowCoinBoost), 
			ProductionModifierType.RedCoin => SpriteForItem(ItemType.UtilityRedCoinBoost), 
			ProductionModifierType.BlueCoin => SpriteForItem(ItemType.UtilityBlueCoinBoost), 
			ProductionModifierType.PurpleCoin => SpriteForItem(ItemType.UtilityPurpleCoinBoost), 
			_ => null, 
		};
	}

	public static Sprite SpriteForState(StateManager stateManager)
	{
		if (stateManager is HarvestState harvestState)
		{
			return SpriteForState(harvestState.resource);
		}
		if (stateManager is RecipeState recipeState)
		{
			return SpriteForRecipeType(recipeState.type);
		}
		if (stateManager is FarmingState farmingState)
		{
			return SpriteForState(farmingState.resource);
		}
		if (stateManager is MiningState miningState)
		{
			return SpriteForState(miningState.resource);
		}
		if (stateManager is SellState sellState)
		{
			return SpriteForItem(sellState.itemType);
		}
		if (stateManager is TradingState tradingState)
		{
			return SpriteForItem(tradingState.itemType);
		}
		if (stateManager is ConstructionState constructionState)
		{
			return SpriteForBuilding(constructionState.parentBuildingState.type);
		}
		return null;
	}

	public static Sprite SpriteForState(CountableState state)
	{
		return SpriteForEntity(state.AsEntity());
	}

	public static Sprite SpriteForFarmingTool(FarmingToolType t)
	{
		return t switch
		{
			FarmingToolType.CropHarvester => instance.scythe, 
			FarmingToolType.RockDestroyer => instance.pickaxe, 
			FarmingToolType.TerrainShovel => instance.shovel, 
			FarmingToolType.TillSoil => instance.hoe, 
			FarmingToolType.WateringCan => instance.wateringCan, 
			_ => null, 
		};
	}

	public static Sprite SpriteForTerrainTexture(FarmingTextureType t)
	{
		return t switch
		{
			FarmingTextureType.Farm => instance.farmingTerrainFarm, 
			FarmingTextureType.Grass => instance.farmingTerrainGrass, 
			FarmingTextureType.Rock => instance.farmingTerrainRock, 
			FarmingTextureType.Water => instance.farmingTerrainWater, 
			FarmingTextureType.Dirt => instance.farmingTerrainDirt, 
			FarmingTextureType.Trench => instance.farmingTerrainTrench, 
			_ => null, 
		};
	}

	public static Sprite SpriteForItem(ItemType itemType)
	{
		if (itemType == ItemType.None)
		{
			return null;
		}
		return CachedSpriteForItem(itemType, 0);
	}

	public static Sprite DefaultSpriteForItem(ItemType itemType)
	{
		if (itemType == ItemType.None)
		{
			return null;
		}
		if (Item.IsUpgrade(itemType))
		{
			return instance.upgrade;
		}
		switch (itemType)
		{
		case ItemType.AirEther:
			return instance.etherAir;
		case ItemType.AirshipComponent:
			return instance.airshipComponent;
		case ItemType.Apple:
			return instance.apple;
		case ItemType.ApplePie:
			return instance.pie;
		case ItemType.AnimalFeed:
			return instance.animalFeed;
		case ItemType.Antidote:
			return instance.antidote;
		case ItemType.AttackPotion:
			return instance.healthPotion;
		case ItemType.Bandage:
			return instance.bandage;
		case ItemType.Berries:
			return instance.berries;
		case ItemType.BerryCake:
			return instance.cakeBerry;
		case ItemType.BerryJam:
			return instance.berryJam;
		case ItemType.BerryJuice:
			return instance.berryJuice;
		case ItemType.Bread:
			return instance.bread;
		case ItemType.BlueSapphire:
			return instance.gemAqua;
		case ItemType.Book:
			return instance.book;
		case ItemType.Boots:
			return instance.boots;
		case ItemType.Butter:
			return instance.butter;
		case ItemType.BlueCoin:
			return instance.blueCoin;
		case ItemType.CactusFruit:
			return instance.cactusFruit;
		case ItemType.CactusJam:
			return instance.cactusJam;
		case ItemType.Carrot:
			return instance.carrot;
		case ItemType.Cake:
			return instance.cake;
		case ItemType.Cheese:
			return instance.cheese;
		case ItemType.CookedChicken:
			return instance.chickenCooked;
		case ItemType.Cloak:
			return instance.cloak;
		case ItemType.CottonCloth:
			return instance.cloth;
		case ItemType.Cotton:
			return instance.cotton;
		case ItemType.CookedBeef:
			return instance.beefCooked;
		case ItemType.CopperOre:
			return instance.copperOre;
		case ItemType.ConveyorBeltWooden:
			return instance.conveyorBeltWood;
		case ItemType.MetalConveyorBelt:
			return instance.conveyorBeltMetal;
		case ItemType.ClothConveyorBelt:
			return instance.conveyorBeltCloth;
		case ItemType.MagicConveyorBelt:
			return instance.conveyorBeltMagic;
		case ItemType.Coal:
			return instance.coal;
		case ItemType.CopperWire:
			return instance.copperWire;
		case ItemType.CopperIngot:
			return instance.copperIngot;
		case ItemType.EnchantedAirCrown:
			return instance.airCrown;
		case ItemType.DepletedMana:
			return instance.depletedMana;
		case ItemType.DragonFruit:
			return instance.dragonFruit;
		case ItemType.DragonPunch:
			return instance.dragonPunch;
		case ItemType.EarthEther:
			return instance.etherEarth;
		case ItemType.Egg:
			return instance.egg;
		case ItemType.StealthPotion:
			return instance.potionBlue;
		case ItemType.SpeedPotion:
			return instance.elixer;
		case ItemType.EnchantedBook:
			return instance.enchantedBook;
		case ItemType.EnchantedBookRed:
			return instance.enchantedBookRed;
		case ItemType.EnchantedBookYellow:
			return instance.enchantedBookYellow;
		case ItemType.EnchantedBookBlue:
			return instance.enchantedBookBlue;
		case ItemType.EnchantedBookPurple:
			return instance.enchantedBookPurple;
		case ItemType.ResearchTomeGeneral:
			return instance.researchTomeGeneral;
		case ItemType.MagicStoneBrick:
			return instance.enchantedStoneBrick;
		case ItemType.ManaEther:
			return instance.ether;
		case ItemType.Fertilizer:
			return instance.fertilizer;
		case ItemType.Fish:
			return instance.fish;
		case ItemType.FishFood:
			return instance.fishFood;
		case ItemType.FishCooked:
			return instance.fishCooked;
		case ItemType.FishStew:
			return instance.fishStew;
		case ItemType.FishingNet:
			return instance.fishingNet;
		case ItemType.MagicFishingNet:
			return instance.magicFishingNet;
		case ItemType.Flour:
			return instance.flour;
		case ItemType.FireEther:
			return instance.etherFire;
		case ItemType.FruitJuice:
			return instance.fruitJuice;
		case ItemType.GemOrange:
			return instance.gemOrange;
		case ItemType.GoldCrown:
			return instance.goldCrown;
		case ItemType.GemGreen:
			return instance.gemGreen;
		case ItemType.GemBlue:
			return instance.gemBlue;
		case ItemType.RedRuby:
			return instance.gemRed;
		case ItemType.PurpleAmethyst:
			return instance.gemPurple;
		case ItemType.GemPink:
			return instance.gemPink;
		case ItemType.Gear:
			return instance.gear;
		case ItemType.Grain:
			return instance.grain;
		case ItemType.YellowCoin:
			return instance.gold;
		case ItemType.PurpleCoin:
			return instance.purpleCoin;
		case ItemType.OmniCoin:
			return instance.omniCoin;
		case ItemType.ExplorationCoin:
			return instance.exploration;
		case ItemType.ExchangeToken:
			return instance.silverCoin;
		case ItemType.TownExperiencePoint:
			return instance.experiencePointText;
		case ItemType.Hat:
			return instance.hat;
		case ItemType.HealthPotion:
			return instance.potionPurple;
		case ItemType.Herb:
			return instance.herb;
		case ItemType.CopperRing:
			return instance.copperRing;
		case ItemType.Jam:
			return instance.appleJam;
		case ItemType.MagicCloak:
			return instance.cloakMagic;
		case ItemType.MagicPotion:
			return instance.potionWhite;
		case ItemType.Magma:
			return instance.magma;
		case ItemType.Mana:
			return instance.mana;
		case ItemType.ManaPipe:
			return instance.manaPipe;
		case ItemType.ManaPower:
			return instance.powerMana;
		case ItemType.Milk:
			return instance.milk;
		case ItemType.Invalid:
			return instance.invalidItem;
		case ItemType.FilterCategoryGeneralTools:
			return instance.pickaxe;
		case ItemType.FilterCategoryGeneralGadgets:
			return instance.conveyorBeltItemMetal;
		case ItemType.FilterCategoryMedicineEthers:
			return instance.etherFire;
		case ItemType.FilterCategorySpecialtyGadgets:
			return instance.conveyorBeltMagic;
		case ItemType.FilterCategorySpecialtyJewelry:
			return instance.crown;
		case ItemType.FilterCategoryConstructionWood:
			return instance.satisfactionCategoryWoodConstruction;
		case ItemType.FilterCategoryConstructionStone:
			return instance.satisfactionCategoryStoneConstruction;
		case ItemType.FilterCategoryConstructionMetal:
			return instance.ironPlate;
		case ItemType.FilterResearchGeneral:
			return instance.satisfactionCategoryKnowledgeGeneral;
		case ItemType.FilterResearchMedicine:
			return instance.satisfactionCategoryKnowledgeNature;
		case ItemType.FilterResearchIndustry:
			return instance.satisfactionCategoryKnowledgeIndustry;
		case ItemType.FilterResearchMagic:
			return instance.satisfactionCategoryKnowledgeMagic;
		case ItemType.FilterResearchFire:
			return instance.satisfactionCategoryKnowledgeFire;
		case ItemType.FilterResearchWater:
			return instance.satisfactionCategoryKnowledgeWater;
		case ItemType.FilterResearchEarth:
			return instance.satisfactionCategoryKnowledgeEarth;
		case ItemType.FilterResearchAir:
			return instance.satisfactionCategoryKnowledgeAir;
		case ItemType.FishOil:
			return instance.fishOil;
		case ItemType.EnchantedFireRing:
			return instance.ringFire;
		case ItemType.SilverChain:
			return instance.silverChain;
		case ItemType.SilverRing:
			return instance.silverRing;
		case ItemType.GoldOre:
			return instance.goldOre;
		case ItemType.GoldIngot:
			return instance.goldIngot;
		case ItemType.GlassPanel:
			return instance.glassPanel;
		case ItemType.GoldRing:
			return instance.goldRing;
		case ItemType.Harvester:
			return instance.harvester;
		case ItemType.IronOre:
			return instance.iron;
		case ItemType.IronIngot:
			return instance.ironPlate;
		case ItemType.IronWheel:
			return instance.ironWheel;
		case ItemType.Leather:
			return instance.leather;
		case ItemType.MagicBoots:
			return instance.magicBoots;
		case ItemType.MagicHat:
			return instance.magicHat;
		case ItemType.MagicBoatComponent:
			return instance.magicBoatComponent;
		case ItemType.MagicPants:
			return instance.magicPants;
		case ItemType.MeatStew:
			return instance.meatStew;
		case ItemType.MedicalWrap:
			return instance.medicalWrap;
		case ItemType.Nails:
			return instance.nails;
		case ItemType.AmethystNecklace:
			return instance.necklace;
		case ItemType.EnchantedEarthNecklace:
			return instance.earthNecklace;
		case ItemType.RedCoin:
			return instance.redCoin;
		case ItemType.RawChicken:
			return instance.chickenRaw;
		case ItemType.Ointment:
			return instance.ointment;
		case ItemType.Outfit:
			return instance.outfit;
		case ItemType.Omnistone:
			return instance.omnistone;
		case ItemType.OmniPipe:
			return instance.omnipipe;
		case ItemType.Pants:
			return instance.pants;
		case ItemType.Plank:
			return instance.plank;
		case ItemType.Poultice:
			return instance.poultice;
		case ItemType.Paper:
			return instance.paper;
		case ItemType.Pear:
			return instance.pear;
		case ItemType.PearJam:
			return instance.pearJam;
		case ItemType.PearJuice:
			return instance.pearJuice;
		case ItemType.Pickaxe:
			return instance.pickaxe;
		case ItemType.ProteinShake:
			return instance.proteinShake;
		case ItemType.PolishedStone:
			return instance.polishedStone;
		case ItemType.PolishedStoneRing:
			return instance.polishedStoneRing;
		case ItemType.Potato:
			return instance.potato;
		case ItemType.PurifiedMana:
			return instance.purifiedMana;
		case ItemType.PurifiedFire:
			return instance.fireCrystal;
		case ItemType.PurifiedWater:
			return instance.waterCrystal;
		case ItemType.PurifiedEarth:
			return instance.earthCrystal;
		case ItemType.PurifiedAir:
			return instance.airCrystal;
		case ItemType.RailTileWood:
			return instance.woodenRail;
		case ItemType.RailTile:
			return instance.rail;
		case ItemType.RailTilePowered:
			return instance.railTilePowered;
		case ItemType.RailTileMagic:
			return instance.railTileMagic;
		case ItemType.RawBeef:
			return instance.beef;
		case ItemType.Remedy:
			return instance.remedy;
		case ItemType.RefinedPlank:
			return instance.refinedPlank;
		case ItemType.RefinedStoneBrick:
			return instance.refinedStone;
		case ItemType.ReinforcedPlank:
			return instance.reinforcedBeam;
		case ItemType.FilterChargedElement:
			return instance.filterChargedCrystal;
		case ItemType.FilterDepletedElement:
			return instance.filterDepletedCrystal;
		case ItemType.FilterPurifiedElement:
			return instance.filterPurifiedElement;
		case ItemType.DepletedFire:
			return instance.depletedFire;
		case ItemType.DepletedWater:
			return instance.depletedWater;
		case ItemType.DepletedEarth:
			return instance.depletedEarth;
		case ItemType.DepletedAir:
			return instance.depletedAir;
		case ItemType.Sandwich:
			return instance.sandwich;
		case ItemType.Shoe:
			return instance.shoe;
		case ItemType.Shovel:
			return instance.shovel;
		case ItemType.SilverOre:
			return instance.silverOre;
		case ItemType.SilverIngot:
			return instance.silverIngot;
		case ItemType.Star:
			return instance.knowledgeOrb;
		case ItemType.Quartz:
			return instance.quartz;
		case ItemType.Steel:
			return instance.steel;
		case ItemType.Stone:
			return instance.stone;
		case ItemType.StoneAxe:
			return instance.stoneAxe;
		case ItemType.StoneSlab:
			return instance.stoneSlab;
		case ItemType.Sugar:
			return instance.sugarcane;
		case ItemType.RefinedSugar:
			return instance.sugar;
		case ItemType.RubyRing:
			return instance.rubyRing;
		case ItemType.SapphireRing:
			return instance.sapphireRing;
		case ItemType.Tomato:
			return instance.tomato;
		case ItemType.TimeToken:
			return instance.timeToken;
		case ItemType.TopazCrown:
			return instance.crown;
		case ItemType.VeggieStew:
			return instance.veggieStew;
		case ItemType.MagicPlank:
			return instance.enchantedPlank;
		case ItemType.EnchantedWaterRing:
			return instance.ringWater;
		case ItemType.MagicShirt:
			return instance.magicRobe;
		case ItemType.MagicRing:
			return instance.magicRing;
		case ItemType.Water:
			return instance.water;
		case ItemType.WarmCoat:
			return instance.warmCoat;
		case ItemType.Wood:
			return instance.wood;
		case ItemType.WoodAxe:
			return instance.woodAxe;
		case ItemType.WoodWheel:
			return instance.woodWheel;
		case ItemType.WaterEther:
			return instance.etherWater;
		case ItemType.Wool:
			return instance.wool;
		case ItemType.WoolCloth:
			return instance.woolCloth;
		case ItemType.YellowTopaz:
			return instance.gemYellow;
		case ItemType.Worker:
			return instance.worker;
		case ItemType.RailCartWooden:
			return instance.woodenRailCart;
		case ItemType.RailCart:
			return instance.railCart;
		case ItemType.Boxcar:
			return instance.boxcar;
		case ItemType.TankCar:
			return instance.tankCar;
		case ItemType.HopperCar:
			return instance.hopperCar;
		case ItemType.SteamTrainEngine:
			return instance.steamTrainEngine;
		case ItemType.FishingBoat:
			return instance.fishingBoat;
		case ItemType.Wagon:
			return instance.wagon;
		case ItemType.Caravan:
			return instance.caravan;
		case ItemType.CargoBoat:
			return instance.cargoBoat;
		case ItemType.Raft:
			return instance.raft;
		case ItemType.Airship:
			return instance.airship;
		case ItemType.WaterPipe:
			return instance.waterPipe;
		case ItemType.SteamPipe:
			return instance.steamPipe;
		case ItemType.MagmaPipe:
			return instance.magmaPipe;
		case ItemType.FilterFarmSeeds:
		case ItemType.FilterTreeSeeds:
		case ItemType.FilterManaSeeds:
			return instance.farm;
		case ItemType.Fire:
			return instance.filterFuel;
		case ItemType.FilterFuel:
			return instance.filterFuel;
		case ItemType.FilterPackable:
			return instance.filterPackable;
		case ItemType.FilterPackage:
			return instance.filterUnpackable;
		case ItemType.FilterAnything:
			return instance.filterAnything;
		case ItemType.UtilityHouseGoods:
			return instance.filterMarketFood;
		case ItemType.UtilityPopulationSize:
			return instance.population;
		case ItemType.UtilityDisappearedItem:
			return instance.voidOutput;
		case ItemType.UtilityProductionTime:
			return instance.productionTime;
		case ItemType.UtilityWorkUnits:
			return instance.workUnits;
		case ItemType.UtilityHappiness:
			return instance.happinessGeneral;
		case ItemType.UtilityPowerSupply:
			return instance.categoryPower;
		case ItemType.UtilityApplyWater:
			return instance.water;
		case ItemType.UtilityApplyFertilizer:
			return instance.fertilizer;
		case ItemType.UtilityApplyPickaxe:
			return instance.mineShaft;
		case ItemType.UtilityManaPipeItem:
			return instance.powerMana;
		case ItemType.SkillExperiencePoint:
			return instance.skill;
		case ItemType.UtilityMinigameExperiencePoint:
			return instance.experiencePointBlue;
		case ItemType.UtilityTechLevel:
			return instance.techLevel;
		case ItemType.UtilityPopulationLevel:
			return instance.housingLevel;
		case ItemType.UtilityPerkPoint:
			return instance.perkPoint;
		case ItemType.UtilityPrestigePoint:
			return instance.experiencePointPurple;
		case ItemType.UtilityQuestCoin:
			return instance.questCoin;
		case ItemType.UtilityVictory:
			return instance.victory;
		case ItemType.ManaPipeItem:
			return instance.powerMana;
		case ItemType.UtilityAffinity:
			return instance.affinity;
		case ItemType.UtilityElementalFirePower:
			return instance.powerElementalFire;
		case ItemType.UtilityElementalWaterPower:
			return instance.powerElementalWater;
		case ItemType.UtilityElementalEarthPower:
			return instance.powerElementalEarth;
		case ItemType.UtilityElementalAirPower:
			return instance.powerElementalAir;
		case ItemType.UtilitySendFireBoost:
			return instance.sendBoostFire;
		case ItemType.UtilitySendWaterBoost:
			return instance.sendBoostWater;
		case ItemType.UtilitySendEarthBoost:
			return instance.sendBoostEarth;
		case ItemType.UtilitySendAirBoost:
			return instance.sendBoostAir;
		case ItemType.UtilityElementalFireBoost:
			return instance.elementalFireBoost;
		case ItemType.UtilityElementalWaterBoost:
			return instance.elementalWaterBoost;
		case ItemType.UtilityElementalEarthBoost:
			return instance.elementalEarthBoost;
		case ItemType.UtilityElementalAirBoost:
			return instance.elementalAirBoost;
		case ItemType.UtilitySteamPower:
			return instance.powerSteam;
		case ItemType.Steam:
			return instance.powerSteam;
		case ItemType.Power:
			return instance.categoryPower;
		case ItemType.UtilitySteamBoost:
			return instance.steamBoost;
		case ItemType.UtilityYellowCoinBoost:
			return instance.coinBoostYellow;
		case ItemType.UtilityRedCoinBoost:
			return instance.coinBoostRed;
		case ItemType.UtilityBlueCoinBoost:
			return instance.coinBoostBlue;
		case ItemType.UtilityPurpleCoinBoost:
			return instance.coinBoostPurple;
		case ItemType.UtilityBoostWorker:
			return instance.workerSpeedBoost;
		case ItemType.UtilityRotationalPower:
			return instance.powerRotational;
		case ItemType.UtilityParkedTrain:
			return instance.steamTrainEngine;
		case ItemType.UtilityLinkedHouseUpgrades:
			return instance.houseUpgrade;
		case ItemType.UtilityMoveTrainCargo:
			return instance.moveTrainCargo;
		case ItemType.UtilityHappinessSpeedBoost:
			return instance.happinessSpeedBoost;
		case ItemType.UtilityProductionSpeedBoost:
			return instance.productionSpeedBoost;
		case ItemType.UtilityCompleteOmniTempleConstruction:
			return instance.omniTemple;
		case ItemType.UtilityNearbyWater:
			return instance.waterBlock;
		case ItemType.UtilityNearbyFishingTiles:
			return instance.resourceFish;
		case ItemType.UtilityConsumptionTime:
			return instance.consumptionDuration;
		case ItemType.UtilityHappinessDuration:
			return instance.happinessDuration;
		case ItemType.UtilityRegenerateResources:
			return instance.resourceRegenBoost;
		case ItemType.UtilityLand:
			return instance.land;
		case ItemType.UtilityFarmingPlot:
			return instance.farmingPlots;
		case ItemType.UtilityDiceGamePoint:
			return instance.diceGamePoint;
		case ItemType.UtilityEnergyFarming:
			return instance.minigameEnergyFarming;
		case ItemType.UtilityEnergyMining:
			return instance.minigameEnergyMining;
		case ItemType.UtilityEnergyWater:
			return instance.minigameEnergyWater;
		case ItemType.UtilityEnergyDice:
			return instance.minigameEnergyDice;
		case ItemType.UtilityEnergyResearch:
			return instance.minigameEnergyResearch;
		case ItemType.UtilityEnergyWood:
			return instance.minigameEnergyWood;
		case ItemType.UtilityResearchGroupBasicProcessing:
			return instance.research;
		case ItemType.UtilityResearchGroupCultivation:
			return instance.categoryFarming;
		case ItemType.UtilityResearchGroupBasicLogistics:
			return instance.logicBasic;
		case ItemType.UtilityAutoAssign:
			return instance.automaticAssignmentOn;
		case ItemType.UtilityAutoClaim:
			return instance.automaticClaimOn;
		case ItemType.UtilityPrioritization:
			return instance.priorityHigh;
		case ItemType.UtilityIdleRewardBoost:
			return instance.rewardBoost;
		case ItemType.ResearchPointsGeneral_Disabled:
			return instance.researchPointsGeneral;
		case ItemType.ResearchPointsIndustry:
			return instance.researchPointsIndustry;
		case ItemType.ResearchPointsNature:
			return instance.researchPointsMedicine;
		case ItemType.ResearchPointsMagic:
			return instance.researchPointsMagic;
		case ItemType.ResearchPointsFire:
			return instance.researchPointsFire;
		case ItemType.ResearchPointsWater:
			return instance.researchPointsWater;
		case ItemType.ResearchPointsEarth:
			return instance.researchPointsEarth;
		case ItemType.ResearchPointsAir:
			return instance.researchPointsAir;
		case ItemType.ResearchTomeIndustry1:
			return instance.researchTomeIndustry1;
		case ItemType.ResearchTomeIndustry2:
			return instance.researchTomeIndustry2;
		case ItemType.ResearchTomeIndustry3:
			return instance.researchTomeIndustry3;
		case ItemType.ResearchTomeNature1:
			return instance.researchTomeNature1;
		case ItemType.ResearchTomeNature2:
			return instance.researchTomeNature2;
		case ItemType.ResearchTomeNature3:
			return instance.researchTomeNature3;
		case ItemType.ResearchTomeMagic1:
			return instance.researchTomeMagic1;
		case ItemType.ResearchTomeMagic2:
			return instance.researchTomeMagic2;
		case ItemType.ResearchTomeMagic3:
			return instance.researchTomeMagic3;
		case ItemType.ResearchTomeFire1:
			return instance.researchTomeFire1;
		case ItemType.ResearchTomeFire2:
			return instance.researchTomeFire2;
		case ItemType.ResearchTomeFire3:
			return instance.researchTomeFire3;
		case ItemType.ResearchTomeWater1:
			return instance.researchTomeWater1;
		case ItemType.ResearchTomeWater2:
			return instance.researchTomeWater2;
		case ItemType.ResearchTomeWater3:
			return instance.researchTomeWater3;
		case ItemType.ResearchTomeEarth1:
			return instance.researchTomeEarth1;
		case ItemType.ResearchTomeEarth2:
			return instance.researchTomeEarth2;
		case ItemType.ResearchTomeEarth3:
			return instance.researchTomeEarth3;
		case ItemType.ResearchTomeAir1:
			return instance.researchTomeAir1;
		case ItemType.ResearchTomeAir2:
			return instance.researchTomeAir2;
		case ItemType.ResearchTomeAir3:
			return instance.researchTomeAir3;
		default:
			return null;
		}
	}

	public static Sprite SpriteForResearch(ResearchType t)
	{
		if (Crafting.researchCache.TryGetValue(t, out var value) && value.localizationEntity.type != EntityType.None)
		{
			return SpriteForEntity(value.localizationEntity);
		}
		return DefaultSpriteForResearch(t);
	}

	public static Sprite DefaultSpriteForResearch(ResearchType t)
	{
		return t switch
		{
			ResearchType.Aqueduct => instance.aqueduct, 
			ResearchType.CoinBoosters => instance.coinBoostYellow, 
			ResearchType.Farming => instance.farm, 
			ResearchType.FoodMill => instance.grainMill, 
			ResearchType.StoneMason => instance.stoneMason, 
			ResearchType.Quarry => instance.quarry, 
			ResearchType.WaterBucket => instance.water, 
			ResearchType.Fishery => instance.fishery, 
			ResearchType.Forestry => instance.forester, 
			ResearchType.ManaTransmitter => instance.powerMana, 
			ResearchType.ManaRecharger => instance.recharger, 
			ResearchType.ManaPowerHarvesterDrills => instance.harvester, 
			ResearchType.ManaPowerTractors => instance.tractor, 
			ResearchType.ManaPowerChainsawTanks => instance.chainsawTank, 
			ResearchType.ManaPowerCropHarvesters => instance.cropHarvester, 
			ResearchType.ManaPipe => instance.manaPipe, 
			ResearchType.OmniPipe => instance.omnipipe, 
			ResearchType.Enchanting => instance.enchanter, 
			ResearchType.GemJewelry => instance.polishedStoneRing, 
			ResearchType.Market_Disabled => instance.market, 
			ResearchType.Forge => instance.forge, 
			ResearchType.MagicForge => instance.purifiedMana, 
			ResearchType.MedicineBasic => instance.herb, 
			ResearchType.MedicineIntermediate => instance.antidote, 
			ResearchType.MedicineAdvanced => instance.elixer, 
			ResearchType.Pasture => instance.pasture, 
			ResearchType.MagmaPipe => instance.magmaPipe, 
			ResearchType.SteamBoiler => instance.steamPowerPlant, 
			ResearchType.SteamPowerGenerator => instance.powerGear, 
			ResearchType.MetalRailway => instance.rail, 
			ResearchType.Minecart => instance.railCart, 
			ResearchType.WoodenRailway => instance.woodenRail, 
			ResearchType.SteamTrainEngine => instance.steamTrainEngine, 
			ResearchType.RailDepot => instance.railDepot, 
			ResearchType.RailwayFreightCars_Disabled => instance.boxcar, 
			ResearchType.Mining => instance.mine, 
			ResearchType.GemMining_Disabled => instance.mineShaft, 
			ResearchType.GoldMining => instance.goldOre, 
			ResearchType.SilverMining => instance.researchSilver, 
			ResearchType.RubyMining => instance.gemRed, 
			ResearchType.SapphireMining => instance.gemBlue, 
			ResearchType.AmethystMining => instance.gemPurple, 
			ResearchType.TopazMining => instance.gemYellow, 
			ResearchType.Jewelry => instance.goldRing, 
			ResearchType.MagicClothing => instance.cloakMagic, 
			ResearchType.MagicJewelry => instance.ringFire, 
			ResearchType.MagicTech => instance.magicTech, 
			ResearchType.MagicMedicine => instance.magicMedicine, 
			ResearchType.Tailor => instance.tailor, 
			ResearchType.Hearth => instance.hearth, 
			ResearchType.Bakery => instance.bakery, 
			ResearchType.GourmetKitchen => instance.kitchen, 
			ResearchType.Boatbuilding => instance.fishingBoat, 
			ResearchType.Machinery => instance.gear, 
			ResearchType.Pantry => instance.pantry, 
			ResearchType.CropSilo => instance.silo, 
			ResearchType.OreSilo => instance.oreSilo, 
			ResearchType.Warehouse => instance.barn, 
			ResearchType.Treasury => instance.treasury, 
			ResearchType.Well => instance.well, 
			ResearchType.Lodge => instance.lodge, 
			ResearchType.WaterPower => instance.waterWheel, 
			ResearchType.Workshop => instance.workshop, 
			ResearchType.Economics => instance.gold, 
			ResearchType.CashRegisters => instance.cashRegister, 
			ResearchType.Advertising => instance.market, 
			ResearchType.FluidPipes_Disabled => instance.waterPipe, 
			ResearchType.FirePurification => instance.fireCrystal, 
			ResearchType.WaterPurification => instance.waterCrystal, 
			ResearchType.EarthPurification => instance.earthCrystal, 
			ResearchType.AirPurification => instance.airCrystal, 
			ResearchType.PurifiedFirePower => instance.powerElementalFire, 
			ResearchType.PurifiedWaterPower => instance.powerElementalWater, 
			ResearchType.PurifiedEarthPower => instance.powerElementalEarth, 
			ResearchType.PurifiedAirPower => instance.powerElementalAir, 
			ResearchType.FireBooster => instance.elementalFireBoost, 
			ResearchType.WaterBooster => instance.elementalWaterBoost, 
			ResearchType.EarthBooster => instance.elementalEarthBoost, 
			ResearchType.AirBooster => instance.elementalAirBoost, 
			ResearchType.FireMastery => instance.elementalFireBoost, 
			ResearchType.WaterMastery => instance.elementalWaterBoost, 
			ResearchType.EarthMastery => instance.elementalEarthBoost, 
			ResearchType.AirMastery => instance.elementalAirBoost, 
			ResearchType.ManaRefinery => instance.crusher, 
			ResearchType.ManaReactor => instance.manaReactor, 
			ResearchType.BuildManaTemple => instance.manaTemple, 
			ResearchType.BuildFireTemple => instance.fireTemple, 
			ResearchType.BuildWaterTemple => instance.waterTemple, 
			ResearchType.BuildEarthTemple => instance.earthTemple, 
			ResearchType.BuildAirTemple => instance.airTemple, 
			ResearchType.BuildOmniTemple => instance.omniTemple, 
			ResearchType.OmniTransmission => instance.omnipipe, 
			ResearchType.MarketCostUpgrades => instance.panelBuildings, 
			ResearchType.OmnistoneUpgrades => instance.omnistoneBoost, 
			ResearchType.InfiniteCraftingSpeed => SpriteForBuildingCategory(BuildingCategory.Production), 
			ResearchType.InfiniteCultivationSpeed => SpriteForBuildingCategory(BuildingCategory.Cultivation), 
			ResearchType.InfiniteProspectingSpeed => SpriteForBuildingCategory(BuildingCategory.Prospecting), 
			ResearchType.InfiniteKnowledgeSpeed => SpriteForBuildingCategory(BuildingCategory.Research), 
			ResearchType.InfiniteNaturalResourceCapacity => instance.panelWorld, 
			ResearchType.InfiniteGoodsConsumption => instance.gold, 
			ResearchType.InfiniteResourceRegeneration => instance.resourceRegen, 
			ResearchType.FireTempleSpeed_Disabled => instance.fireTemple, 
			ResearchType.WaterTempleSpeed_Disabled => instance.waterTemple, 
			ResearchType.EarthTempleSpeed_Disabled => instance.earthTemple, 
			ResearchType.AirTempleSpeed_Disabled => instance.airTemple, 
			ResearchType.FireShrineSpeed_Disabled => instance.fireShrine, 
			ResearchType.WaterShrineSpeed_Disabled => instance.waterShrine, 
			ResearchType.EarthShrineSpeed_Disabled => instance.earthShrine, 
			ResearchType.AirShrineSpeed_Disabled => instance.airShrine, 
			ResearchType.RechargerSpeed => instance.recharger, 
			ResearchType.OmniUpgradePower_Disabled => instance.omnistone, 
			ResearchType.OmniPlanters => instance.omniplanter, 
			ResearchType.CropYield_Disabled => instance.cropYield, 
			ResearchType.HouseMax1 => instance.house, 
			ResearchType.HouseMax2 => instance.house, 
			ResearchType.HouseMax3 => instance.house, 
			ResearchType.HouseMax4 => instance.house, 
			ResearchType.HouseMax5 => instance.house, 
			ResearchType.HouseMax6 => instance.house, 
			ResearchType.HouseMax7 => instance.house, 
			ResearchType.HouseMax8 => instance.house, 
			ResearchType.HouseMax9 => instance.house, 
			ResearchType.Airship => instance.airship, 
			ResearchType.Civics1_Disabled => instance.civics1, 
			ResearchType.Civics2_Disabled => instance.civics2, 
			ResearchType.Civics3 => instance.civics3, 
			ResearchType.Civics4 => instance.civics4, 
			ResearchType.Civics5 => instance.civics5, 
			ResearchType.MagicConveyorBelt => instance.conveyorBeltMagic, 
			ResearchType.MagicRail => instance.railTileMagic, 
			ResearchType.PoweredRail => instance.railTilePowered, 
			ResearchType.MetalConveyorBelt => instance.conveyorBeltMetal, 
			ResearchType.ClothConveyorBelt => instance.conveyorBeltCloth, 
			ResearchType.FishingNet => instance.fishingNet, 
			ResearchType.MagicFishingNet => instance.magicFishingNet, 
			ResearchType.HarvesterDrill => instance.harvester, 
			ResearchType.ChainsawTank => instance.chainsawTank, 
			ResearchType.CropHarvester => instance.cropHarvester, 
			ResearchType.Tractor => instance.tractor, 
			ResearchType.Caravan => instance.caravan, 
			ResearchType.CargoBoat => instance.cargoBoat, 
			ResearchType.BeltWooden => instance.conveyorBeltWood, 
			ResearchType.Chute => instance.chute, 
			ResearchType.MegaRecharger => instance.megaRecharger, 
			ResearchType.ManaBrick => instance.ironPlateEnchanted, 
			ResearchType.MagicLab => instance.magicLab, 
			ResearchType.GeneralLab => instance.generalLab, 
			ResearchType.Glassmaking => instance.glassPanel, 
			ResearchType.TechLab => instance.techLab, 
			ResearchType.Fishing_Disabled => instance.fishingBoat, 
			ResearchType.FloatingIsland => instance.floatingIsland, 
			ResearchType.Steel => instance.steel, 
			ResearchType.SolarPower => instance.solarPanel, 
			ResearchType.SupplyChain_Disabled => instance.categoryTools, 
			ResearchType.CoalMining => instance.resourceCoal, 
			ResearchType.ManaMining => instance.resourceManaCrystal, 
			ResearchType.CopperMining => instance.copperOre, 
			ResearchType.InfiniteManaReactorProductivity => instance.manaReactor, 
			ResearchType.InfiniteOmniTempleProductivity => instance.omniTemple, 
			ResearchType.InfiniteOmnistoneValue => instance.omnistoneBoost, 
			ResearchType.InfiniteMarketSellSpeed => instance.gold, 
			ResearchType.InfiniteSkillGainSpeed => instance.skill, 
			ResearchType.GrainProcessingSpeed => instance.grainProcessingSpeed, 
			ResearchType.StoneProcessingSpeed => instance.stoneProcessingSpeed, 
			ResearchType.WoodProcessingSpeed => instance.woodProcessingSpeed, 
			ResearchType.MetalProcessingSpeed => instance.metalProcessingSpeed, 
			ResearchType.EtherBonusManaPower => instance.powerMana, 
			ResearchType.EtherBonusFirePower => instance.powerElementalFire, 
			ResearchType.EtherBonusWaterPower => instance.powerElementalWater, 
			ResearchType.EtherBonusEarthPower => instance.powerElementalEarth, 
			ResearchType.EtherBonusAirPower => instance.powerElementalAir, 
			_ => null, 
		};
	}

	public static Sprite SpriteForHappinessQuintile(int q)
	{
		return q switch
		{
			0 => instance.happiness3, 
			1 => instance.happiness3, 
			2 => instance.happiness4, 
			3 => instance.happiness4, 
			4 => instance.happiness5, 
			_ => null, 
		};
	}

	public static Sprite SpriteForItemTier(int maxHappiness, bool useSmall)
	{
		if (useSmall)
		{
			return maxHappiness switch
			{
				1 => instance.tierNumeralSmall1, 
				2 => instance.tierNumeralSmall2, 
				3 => instance.tierNumeralSmall3, 
				4 => instance.tierNumeralSmall4, 
				5 => instance.tierNumeralSmall5, 
				_ => instance.happiness3, 
			};
		}
		return maxHappiness switch
		{
			1 => instance.tierNumeral1, 
			2 => instance.tierNumeral2, 
			3 => instance.tierNumeral3, 
			4 => instance.tierNumeral4, 
			5 => instance.tierNumeral5, 
			_ => instance.happiness3, 
		};
	}

	public static Sprite SpriteForMiningLayer(ItemType resourceType)
	{
		return SpriteForNaturalResource(resourceType);
	}

	public static string RichText(string s)
	{
		return "<sprite name=\"" + s + "\">";
	}

	public static Sprite SpriteForItemYield(ItemType t)
	{
		if (Item.MatchesFilterCache(t, ItemType.FilterFarmOutput))
		{
			return Instance.cropYield;
		}
		if (Item.MatchesFilterCache(t, ItemType.FilterForesterOutput))
		{
			return Instance.cropYield;
		}
		return Instance.miningYield;
	}

	public static Sprite SpriteForPriority(StatePriority priority)
	{
		return priority switch
		{
			StatePriority.Highest => instance.priorityHighest, 
			StatePriority.High => instance.priorityHigh, 
			StatePriority.Regular => instance.priorityRegular, 
			StatePriority.Low => instance.priorityLow, 
			StatePriority.Lowest => instance.priorityLowest, 
			_ => instance.priorityDefault, 
		};
	}

	public static Sprite SpriteForTargetMode(ProductionLimitType mode)
	{
		return mode switch
		{
			ProductionLimitType.DefaultNone => instance.productionLimitOff, 
			ProductionLimitType.OverrideNone => instance.productionLimitOff, 
			ProductionLimitType.TargetRate => instance.productionLimitOn, 
			ProductionLimitType.MeetDemand => instance.productionLimitOn, 
			_ => null, 
		};
	}

	public static Sprite SpriteForAutoClaimState(OverrideState state)
	{
		return state switch
		{
			OverrideState.None => instance.automaticClaimNeutral, 
			OverrideState.On => instance.automaticClaimOn, 
			OverrideState.Off => instance.automaticClaimOff, 
			_ => null, 
		};
	}

	public static Sprite SpriteForAutoAssignState(OverrideState state)
	{
		return state switch
		{
			OverrideState.None => instance.automaticAssignmentOff, 
			OverrideState.On => instance.automaticAssignmentOn, 
			OverrideState.Off => instance.automaticAssignmentOff, 
			_ => null, 
		};
	}

	public static Sprite SpriteForPausedState(OverrideState state)
	{
		return state switch
		{
			OverrideState.None => instance.pauseStateDefault, 
			OverrideState.On => instance.unpause, 
			OverrideState.Off => instance.play, 
			_ => null, 
		};
	}

	public static Sprite SpriteForPausedState(bool isPaused)
	{
		if (!isPaused)
		{
			return instance.pauseStateDefault;
		}
		return instance.unpause;
	}

	public static Sprite SpriteForPerk(PerkType t)
	{
		return t switch
		{
			PerkType.MoreStartingLand => instance.land, 
			PerkType.LandCapacity => instance.land, 
			PerkType.SkillGainSpeed => instance.skill, 
			PerkType.ResearchEfficiency => instance.research, 
			PerkType.ClickPower => instance.panelClickables, 
			PerkType.IdleGain => instance.timeToken, 
			PerkType.Specialization => instance.specialtyOn, 
			PerkType.SpecializationCount => instance.specialtyOn, 
			PerkType.SpecializationValue => instance.specialtyOn, 
			PerkType.SpecializationDemand => instance.specialtyOn, 
			PerkType.GoodsConsumption => instance.market, 
			PerkType.TownOmnistoneDemand => instance.omnistoneBoost, 
			PerkType.RemoveBiomeNegatives => instance.panelWorld, 
			PerkType.ExtraQuestCoins => SpriteForItem(ItemType.UtilityQuestCoin), 
			PerkType.GlobalTradingCapacity => SpriteForBuilding(BuildingType.TradingPost), 
			PerkType.GlobalXPBoost => instance.experiencePointText, 
			PerkType.TownXPBoost => instance.experiencePointText, 
			PerkType.MinigameXPGainSpeed => instance.experiencePointBlue, 
			PerkType.NaturalResourceCapacity => instance.grain, 
			PerkType.ResourceRegen => instance.resourceRegen, 
			PerkType.HousingCapacity => instance.worker, 
			PerkType.CultivationSpeed => SpriteForMenuPanel(MenuPanelType.Cultivation), 
			PerkType.ProspectingSpeed => SpriteForMenuPanel(MenuPanelType.Prospecting), 
			PerkType.ConstructionCost => instance.refinedPlank, 
			PerkType.ConstructionEfficiency => instance.panelBuildings, 
			PerkType.UpgradeEfficiency => instance.upgrade, 
			PerkType.CraftingSpeed => instance.panelCrafting, 
			PerkType.StorageBoost => instance.inventory, 
			PerkType.KnowledgeSpeed => SpriteForBuildingCategory(BuildingCategory.Research), 
			PerkType.TownTradingSpeed => SpriteForMenuPanel(MenuPanelType.Trading), 
			PerkType.GlobalTradingSpeed => instance.tradingPost, 
			PerkType.GourmetFoodsDemand => instance.cakeBerry, 
			PerkType.BooksDemand => instance.book, 
			PerkType.ConstructionDemand => instance.reinforcedBeam, 
			PerkType.HardwareDemand => instance.gear, 
			PerkType.JewelryDemand => instance.necklace, 
			PerkType.ClothingDemand => instance.cloak, 
			PerkType.MedicineDemand => instance.antidote, 
			PerkType.MagicDemand => instance.purifiedMana, 
			PerkType.ResearchSpeed => instance.panelResearch, 
			PerkType.GlobalResearchSpeed => instance.panelResearch, 
			PerkType.HarvestingSpeed => instance.panelHarvesting, 
			PerkType.MarketValue => instance.coinBoostYellow, 
			PerkType.ConstructionSpeed => instance.refinedStone, 
			PerkType.GlobalMarketSpeed => instance.sellSpeed, 
			PerkType.GourmetFoodsStoreSpeed => instance.fancyFoods, 
			PerkType.BookStoreSpeed => instance.bookstore, 
			PerkType.ConstructionStoreSpeed => instance.generalGoodsStore, 
			PerkType.HardwareStoreSpeed => instance.hardwareStore, 
			PerkType.JewelryStoreSpeed => instance.specialtyGoodsStore, 
			PerkType.ClothingStoreSpeed => instance.clothingStore, 
			PerkType.MedicineStoreSpeed => instance.hospital, 
			PerkType.MagicStoreSpeed => instance.arcaneEmporium, 
			_ => null, 
		};
	}

	public static Sprite SpriteForTradingPostItem(CountableState t)
	{
		return instance.itemPackageBackground;
	}

	public static Sprite SpriteForDiceFace(int value)
	{
		return value switch
		{
			1 => instance.dice1, 
			2 => instance.dice2, 
			3 => instance.dice3, 
			4 => instance.dice4, 
			5 => instance.dice5, 
			6 => instance.dice6, 
			_ => null, 
		};
	}

	public static Sprite SpriteForDiceLockState(bool state)
	{
		if (!state)
		{
			return instance.diceUnlocked;
		}
		return instance.diceLocked;
	}

	public static Sprite BackgroundForBiome(BiomeType t)
	{
		return t switch
		{
			BiomeType.Desert => instance.backgroundDesert, 
			BiomeType.Forest => instance.backgroundForest, 
			BiomeType.Jungle => instance.backgroundJungle, 
			BiomeType.Magic => instance.backgroundMagic, 
			BiomeType.Mountains => instance.backgroundMountains, 
			BiomeType.Plains => instance.backgroundPlains, 
			BiomeType.River => instance.backgroundRiver, 
			BiomeType.Snow => instance.backgroundSnow, 
			_ => null, 
		};
	}

	public static Sprite ButtonBackgroundForBiome(BiomeType t)
	{
		return t switch
		{
			BiomeType.Desert => instance.buttonBackgroundDesert, 
			BiomeType.Forest => instance.buttonBackgroundForest, 
			BiomeType.Jungle => instance.buttonBackgroundJungle, 
			BiomeType.Magic => instance.buttonBackgroundMagic, 
			BiomeType.Mountains => instance.buttonBackgroundMountains, 
			BiomeType.Plains => instance.buttonBackgroundPlains, 
			BiomeType.River => instance.buttonBackgroundRiver, 
			BiomeType.Snow => instance.buttonBackgroundSnow, 
			_ => null, 
		};
	}

	public static Sprite SpriteForTimeMode(int mode)
	{
		return mode switch
		{
			-1 => instance.speedStopped, 
			0 => instance.speedNormal, 
			1 => instance.speedFast, 
			2 => instance.speedUltra, 
			_ => null, 
		};
	}
}
