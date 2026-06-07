using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillTreeIcon2 : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler
{
	public class IconInfo
	{
		public IconTypeEnum IconType;

		public BaseSavableAttribute Attribute;

		public string Name;

		public string Description;

		public IconInfo()
		{
		}

		public IconInfo(IconTypeEnum type, BaseSavableAttribute attr, string name, string description)
		{
			IconType = type;
			Attribute = attr;
			Name = name;
			Description = description;
		}
	}

	public enum IconStateEnum
	{
		None = 0,
		Hidden = 1,
		CannotAfford = 2,
		CanAfford = 3,
		Completed = 4
	}

	public enum IconTypeEnum
	{
		A1_Central = 100,
		A2_Fan = 101,
		A3_MoreStorage = 102,
		A4_Capture = 103,
		B1_Bu_Catapult = 200,
		B2_ThrowMore = 201,
		B3_Cannon = 202,
		B4_CannonCloud = 203,
		B5_Ab_ThrowAll = 204,
		B6_MiniGun = 205,
		B7_Half = 206,
		C1_Bu_House = 300,
		C2_OutputOnCycle = 301,
		C3_MaxPeon = 302,
		C4_Ab_Clone = 303,
		C5_HappyLonger = 304,
		C6_Ab_AllHappy = 305,
		C7_NormalLonger = 306,
		C8_InitialMaxPeon = 307,
		C9_Half = 308,
		C10_HalfPeonCost = 309,
		D1_Bu_Rock = 400,
		D2_Scafolding = 401,
		D3_MoreMiner1 = 402,
		D4_ThrowRight = 403,
		D5_MoreMiner2 = 404,
		D6_MoreOutput = 405,
		D7_MakeMedium = 406,
		D8_ThrowFurther = 407,
		E1_Bu_Research = 500,
		E2_DoubleYellowShard = 501,
		E3_MoreCloud = 502,
		E4_PipeCanThrow = 503,
		E5_ClosePipe = 504,
		E6_MoreRP = 505,
		E7_MoneyToYellow = 506,
		E8_Half = 507,
		E9_Ab_ResetAbilities = 508,
		F1_Bu_Training = 600,
		F2_FasterPeon = 601,
		F3_NoDeath = 602,
		F4_MoreTP = 603,
		F5_Half = 604,
		F6_ContentIsHappy = 605,
		G1_Bu_Industry = 700,
		G2_Ab_Bulldozer = 701,
		G3_BulldozerCloud = 702,
		G4_LastCycleMoreOutput = 703,
		G5_AllMoreOutput = 704,
		G6_Half = 705,
		G7_AllCanGenerateMedium = 706,
		H1_Bu_Compressor = 800,
		H2_BetterSmallCompress = 801,
		H3_Ab_CompressAllInStorage = 802,
		H4_CompressMedium = 803,
		H5_GarbageMoreMoney = 804,
		H6_Half = 805,
		H7_MediumOnLowStability = 806,
		H8_CompressLarge = 807,
		H9_ConvertYtoB = 808,
		H10_ConvertBtoY = 809,
		H11_Doublecompress = 810,
		H12_Compress8 = 811,
		H13_CompressFromCompressor = 812,
		I1_Bu_Power = 900,
		I2_PrestigeRemoveStability = 901,
		I3_MoreManualDestroy = 902,
		I4_MoreStabilityDestroy = 903,
		I5_CompressClosebyGarbage = 904,
		I6_Ab_CompressAllOnMap = 905,
		I7_MorePrestige = 906,
		I8_Half = 907,
		I9_BuildingLessCost = 908,
		I10_Ab_DoubleAllOnMap = 909,
		I11_HaveMoreRange = 910,
		I12_Ab_LowerAllStability = 911,
		J1_Bu_Helicopter = 1000,
		J2_DumpRight = 1001,
		J3_OutputLessButMedium = 1002,
		J4_MoreHelicopter = 1003,
		J5_Half = 1004,
		J6_Ab_Airplane = 1005,
		J7_Transition = 1006,
		J8_IncreaseSizeOfGarbage = 1007,
		J9_Transition = 1008,
		J10_OutputMore = 1009,
		J11_Transition = 1010,
		J12_AirplaneMore = 1011,
		K1_Bu_Baloon = 1100,
		K2_MoreBaloon = 1101,
		K3_BaloonMakeCloud = 1102,
		K4_MoveLeft = 1103,
		K5_Half = 1104,
		K6_StrongerFan = 1105,
		K7_BothSide = 1106,
		K8_CanCompress = 1107,
		K9_StrongerFan2 = 1108,
		L1_Bu_Drone = 1200,
		L2_ClickPowerIncrease = 1201,
		L3_CloudOutputMore = 1202,
		L4_MoreDrone = 1203,
		L5_Half = 1204,
		L6_BothSide = 1205,
		L7_CloudOutputBigger = 1206,
		L8_StrongerParticle = 1207,
		L9_CloudMakeRP = 1208,
		L10_MoreParticle = 1209,
		M1_Bu_Smoke = 1300,
		N1_Bu_Temple = 1400,
		N2_ExtraPortal1 = 1401,
		N3_ExtraPortal2 = 1402,
		N4_Lazer = 1403,
		N5_Half = 1404,
		N6_MoreRP = 1405,
		N7_BiggerOutput = 1406,
		N8_YtoR = 1407,
		O1_Transition1 = 1500,
		O2_Transition2 = 1501,
		O3_Transition3 = 1502,
		O4_CompressorDevice = 1503,
		O5_DroneDevice = 1504,
		O6_HelicopterDevice = 1505,
		O7_HotairDevice = 1506,
		O8_HouseDevice = 1507,
		O9_IndustryDevice = 1508,
		O10_PowerDevice = 1509,
		O11_ResearchDevice = 1510,
		O12_TrainingDevice = 1511
	}

	private static Dictionary<IconTypeEnum, IconInfo> _iconInfo;

	public IconTypeEnum IconType;

	public SkillTreeIcon2 ParentIcon;

	public Tween _overTween;

	private GameObject _backImage;

	private GameObject _borderImage;

	private Sequence _newNodeSequence;

	public IconStateEnum _cachedBackAnum;

	static SkillTreeIcon2()
	{
		_iconInfo = new Dictionary<IconTypeEnum, IconInfo>();
		_iconInfo.Add(IconTypeEnum.A1_Central, new IconInfo(IconTypeEnum.A1_Central, GameController.GlobalInfo.LevelUpAttribute, "The Beginning", "Unlock upgrade tree."));
		_iconInfo.Add(IconTypeEnum.A2_Fan, new IconInfo(IconTypeEnum.A2_Fan, GameController.GlobalInfo.CanVacuumAttribute, "Vacuum", "Unlock Building Upgrade\n\nCan pull trash from the left or right side of the catapult and compressor. Also automatically stores trash in front of the building. Extra peon needed."));
		_iconInfo.Add(IconTypeEnum.A3_MoreStorage, new IconInfo(IconTypeEnum.A3_MoreStorage, Research.GlobalInfo.CanMoreStorageAttribute, "Storage", "Unlock Building Upgrade\n\nCan increase maximum storage for catapult and compressor. (" + Catapult.GlobalInfo.GetMoreStorageValue() + " per upgrade)"));
		_iconInfo.Add(IconTypeEnum.A4_Capture, new IconInfo(IconTypeEnum.A4_Capture, Compressor.GlobalInfo.CanCaptureFlyingAttribute, "Capture", "Unlock Building Upgrade\n\nCan allow compressor to capture flying trash."));
		_iconInfo.Add(IconTypeEnum.B1_Bu_Catapult, new IconInfo(IconTypeEnum.B1_Bu_Catapult, Catapult.GlobalInfo.LevelUpAttribute, LanguageText.GetText("Catapult"), "Unlock Building\n\nPeon will store trash in the catapult, which will be thrown into the hole.\n\n+1 maximum catapult on map."));
		_iconInfo.Add(IconTypeEnum.B2_ThrowMore, new IconInfo(IconTypeEnum.B2_ThrowMore, Catapult.GlobalInfo.CanThrowMoreAttribute, "Throw+", "Unlock Building Upgrade\n\nCan allow catapult to throw more trash. (1 per upgrade)"));
		_iconInfo.Add(IconTypeEnum.B3_Cannon, new IconInfo(IconTypeEnum.B3_Cannon, Catapult.GlobalInfo.CanCannonAttribute, "Cannon", "Permanent\n\nIncrease max level of catapult."));
		_iconInfo.Add(IconTypeEnum.B4_CannonCloud, new IconInfo(IconTypeEnum.B4_CannonCloud, Catapult.GlobalInfo.CanCannonCloudAttribute, "Cannon Cloud", "Permanent\n\nCannon will generate cloud on each use."));
		_iconInfo.Add(IconTypeEnum.B5_Ab_ThrowAll, new IconInfo(IconTypeEnum.B5_Ab_ThrowAll, GameController.GlobalInfo.CanAbilityThrowAllAttribute, "Catapult Flush", "Unlock Ability\n\nEvery " + SecondsToMinutes(Ability.GetMaxDelay(Ability.AbilityTypeEnum.ProcessAll)) + " minutes, process all trash in catapult storage and double its value."));
		_iconInfo.Add(IconTypeEnum.B6_MiniGun, new IconInfo(IconTypeEnum.B6_MiniGun, Catapult.GlobalInfo.CanMinigunAttribute, "Minigun", "Permanent\n\nIncrease max level of catapult."));
		_iconInfo.Add(IconTypeEnum.B7_Half, new IconInfo(IconTypeEnum.B7_Half, Catapult.GlobalInfo.CanLowerCostAttribute, "Lower Cost", "Permanent\n\nReduce the cost by 50% to level up the catapult."));
		_iconInfo.Add(IconTypeEnum.C1_Bu_House, new IconInfo(IconTypeEnum.C1_Bu_House, House.GlobalInfo.LevelUpAttribute, LanguageText.GetText("House"), "Unlock Building\n\nHouses allow peons to rest, get happy and produce trash. Houses increase max peon.\n\n+1 maximum house on map."));
		_iconInfo.Add(IconTypeEnum.C2_OutputOnCycle, new IconInfo(IconTypeEnum.C2_OutputOnCycle, House.GlobalInfo.CanProduceOnButtonAttribute, "Waste", "Unlock Building Upgrade\n\nCan allow houses to produce trash in between cycles when the light turns on."));
		_iconInfo.Add(IconTypeEnum.C3_MaxPeon, new IconInfo(IconTypeEnum.C3_MaxPeon, House.GlobalInfo.CanHaveMorePeopleAttribute, "House Space", "Permanent\n\n+1 max peon per house floor."));
		_iconInfo.Add(IconTypeEnum.C4_Ab_Clone, new IconInfo(IconTypeEnum.C4_Ab_Clone, GameController.GlobalInfo.CanAbilityCloneAttribute, "Clone", "Unlock Ability\n\nEvery " + SecondsToMinutes(Ability.GetMaxDelay(Ability.AbilityTypeEnum.ClonePeon)) + " minutes, clone all peons to work for 30 seconds."));
		_iconInfo.Add(IconTypeEnum.C5_HappyLonger, new IconInfo(IconTypeEnum.C5_HappyLonger, House.GlobalInfo.CanHappyLongerAttribute, "Happiness", "Permanent\n\n+30s to peon happiness. Happy peons move 20% faster."));
		_iconInfo.Add(IconTypeEnum.C6_Ab_AllHappy, new IconInfo(IconTypeEnum.C6_Ab_AllHappy, GameController.GlobalInfo.CanAbilityAllHappyAttribute, "Bliss", "Unlock Ability\n\nEvery " + SecondsToMinutes(Ability.GetMaxDelay(Ability.AbilityTypeEnum.FullHapiness)) + " minutes, all peons are set to full happiness."));
		_iconInfo.Add(IconTypeEnum.C7_NormalLonger, new IconInfo(IconTypeEnum.C7_NormalLonger, House.GlobalInfo.CanNormalLongerAttribute, "Content", "Permanent\n\n+30s to peon content. Content peons move at normal speed."));
		_iconInfo.Add(IconTypeEnum.C8_InitialMaxPeon, new IconInfo(IconTypeEnum.C8_InitialMaxPeon, House.GlobalInfo.CanInitialMaxPeonAttribute, "Max Peon", "Permanent\n\n+1 to initial max peon."));
		_iconInfo.Add(IconTypeEnum.C9_Half, new IconInfo(IconTypeEnum.C9_Half, House.GlobalInfo.CanLowerCostAttribute, "Lower Cost", "Permanent\n\nReduce the cost by 50% to level up the house."));
		_iconInfo.Add(IconTypeEnum.C10_HalfPeonCost, new IconInfo(IconTypeEnum.C10_HalfPeonCost, House.GlobalInfo.CanHalfPeonCostAttribute, "Peon Half", "Permanent\n\nReduce the cost of peons by 50%."));
		_iconInfo.Add(IconTypeEnum.D1_Bu_Rock, new IconInfo(IconTypeEnum.D1_Bu_Rock, Rock.GlobalInfo.LevelUpAttribute, "Rock", "+1 yellow shard when rock is destroyed."));
		_iconInfo.Add(IconTypeEnum.D2_Scafolding, new IconInfo(IconTypeEnum.D2_Scafolding, Rock.GlobalInfo.CanScafoldingAttribute, "Scaffolding", "Unlock Building Upgrade\n\nCan build a scaffolding in front of the rock and increase the number of working peons by 1."));
		_iconInfo.Add(IconTypeEnum.D3_MoreMiner1, new IconInfo(IconTypeEnum.D3_MoreMiner1, Rock.GlobalInfo.CanHaveExtraWorker1Attribute, "Mining", "Permanent\n\n+1 max peon working on the rock."));
		_iconInfo.Add(IconTypeEnum.D4_ThrowRight, new IconInfo(IconTypeEnum.D4_ThrowRight, Rock.GlobalInfo.CanThrowRightAttribute, "Throw Right", "Permanent\n\nWith a scaffolding, trash is thrown to the right."));
		_iconInfo.Add(IconTypeEnum.D5_MoreMiner2, new IconInfo(IconTypeEnum.D5_MoreMiner2, Rock.GlobalInfo.CanHaveExtraWorker2Attribute, "Mining", "Permanent\n\n+1 max peon working on the rock with a scaffolding."));
		_iconInfo.Add(IconTypeEnum.D6_MoreOutput, new IconInfo(IconTypeEnum.D6_MoreOutput, Rock.GlobalInfo.CanHaveMoreOutputAttribute, "Rock+", "Permanent\n\n+1 trash output when rock is hit."));
		_iconInfo.Add(IconTypeEnum.D7_MakeMedium, new IconInfo(IconTypeEnum.D7_MakeMedium, Rock.GlobalInfo.CanMakeMediumAttribute, "Mine Medium", "Permanent\n\nWith 4 workers, rock outputs medium trash when possible."));
		_iconInfo.Add(IconTypeEnum.D8_ThrowFurther, new IconInfo(IconTypeEnum.D8_ThrowFurther, Rock.GlobalInfo.CanThrowFurtherAttribute, "Rock Throw+", "Unlock Building\n\nTrash from the rock can be thrown farther to the right."));
		_iconInfo.Add(IconTypeEnum.E1_Bu_Research, new IconInfo(IconTypeEnum.E1_Bu_Research, Research.GlobalInfo.LevelUpAttribute, LanguageText.GetText("Research Lab"), "Unlock Building\n\nResearch Lab allows peons to produce RP (research point).\n\n+1 maximum research lab on map."));
		_iconInfo.Add(IconTypeEnum.E2_DoubleYellowShard, new IconInfo(IconTypeEnum.E2_DoubleYellowShard, Research.GlobalInfo.CanExtraYellowShardAttribute, "More Yellow", "Permanent\n\n+1 yellow shard when any building loses durability."));
		_iconInfo.Add(IconTypeEnum.E3_MoreCloud, new IconInfo(IconTypeEnum.E3_MoreCloud, Research.GlobalInfo.CanMoreCloudAttribute, "Cloud+", "Permanent\n\n+0.5% cloud output rate for all buildings."));
		_iconInfo.Add(IconTypeEnum.E4_PipeCanThrow, new IconInfo(IconTypeEnum.E4_PipeCanThrow, Research.GlobalInfo.CanThrowOutputAttribute, "Throw", "Unlock Building Upgrade\n\nCan allow some pipes for all buildings to throw output trash directly into the hole."));
		_iconInfo.Add(IconTypeEnum.E5_ClosePipe, new IconInfo(IconTypeEnum.E5_ClosePipe, Research.GlobalInfo.CanCloseOutputAttribute, "Close", "Permanent\n\nOutput pipe for all buildings can be opened and closed (by clicking on the pipe)."));
		_iconInfo.Add(IconTypeEnum.E6_MoreRP, new IconInfo(IconTypeEnum.E6_MoreRP, Research.GlobalInfo.CanMoreRPAttribute, "RP+", "Permanent\n\n+1 RP generated per worker."));
		_iconInfo.Add(IconTypeEnum.E7_MoneyToYellow, new IconInfo(IconTypeEnum.E7_MoneyToYellow, Research.GlobalInfo.CanMoneyToYellowAttribute, "$ -> Y", "Permanent\n\nBuy a yellow shard."));
		_iconInfo.Add(IconTypeEnum.E8_Half, new IconInfo(IconTypeEnum.E8_Half, Research.GlobalInfo.CanLowerCostAttribute, "Lower Cost", "Permanent\n\nReduce the cost by 50% to level up the research lab."));
		_iconInfo.Add(IconTypeEnum.E9_Ab_ResetAbilities, new IconInfo(IconTypeEnum.E9_Ab_ResetAbilities, Research.GlobalInfo.CanResetAbilitiesAttribute, "Reset", "Unlock Ability\n\nEvery " + SecondsToMinutes(Ability.GetMaxDelay(Ability.AbilityTypeEnum.Reset)) + " minutes, timer on all abilities is reset."));
		_iconInfo.Add(IconTypeEnum.F1_Bu_Training, new IconInfo(IconTypeEnum.F1_Bu_Training, Training.GlobalInfo.LevelUpAttribute, LanguageText.GetText("Training"), "Unlock Building\n\nTraining center helps increase peons' abilities.\n\n+1 maximum training on map."));
		_iconInfo.Add(IconTypeEnum.F2_FasterPeon, new IconInfo(IconTypeEnum.F2_FasterPeon, Training.GlobalInfo.CanFasterPeonAttribute, "Run", "Permanent\n\n+20% to peon walking speed."));
		_iconInfo.Add(IconTypeEnum.F3_NoDeath, new IconInfo(IconTypeEnum.F3_NoDeath, Training.GlobalInfo.CanNoDeathAttribute, "No Death", "Permanent\n\nPeons will always respawn."));
		_iconInfo.Add(IconTypeEnum.F4_MoreTP, new IconInfo(IconTypeEnum.F4_MoreTP, Training.GlobalInfo.CanMoreTPAttribute, "TP+", "Permanent\n\n+1 TP (training point) generated per peon."));
		_iconInfo.Add(IconTypeEnum.F5_Half, new IconInfo(IconTypeEnum.F5_Half, Training.GlobalInfo.CanLowerCostAttribute, "Lower Cost", "Permanent\n\nReduce the cost by 50% to level up the training building."));
		_iconInfo.Add(IconTypeEnum.F6_ContentIsHappy, new IconInfo(IconTypeEnum.F6_ContentIsHappy, Training.GlobalInfo.CanContentIsHappyAttribute, "Lower Cost", "Permanent\n\nContent peons will move at the same speed as happy peons."));
		_iconInfo.Add(IconTypeEnum.G1_Bu_Industry, new IconInfo(IconTypeEnum.G1_Bu_Industry, Industry.GlobalInfo.LevelUpAttribute, LanguageText.GetText("Factory"), "Unlock Building\n\nFactory produces trash by making peons work.\n\n+1 maximum factory on map."));
		_iconInfo.Add(IconTypeEnum.G2_Ab_Bulldozer, new IconInfo(IconTypeEnum.G2_Ab_Bulldozer, GameController.GlobalInfo.CanAbilityBulldozerAttribute, "Bulldozer", "Unlock Ability\n\nEvery " + SecondsToMinutes(Ability.GetMaxDelay(Ability.AbilityTypeEnum.Bulldozer)) + " minutes, call a bulldozer to push trash."));
		_iconInfo.Add(IconTypeEnum.G3_BulldozerCloud, new IconInfo(IconTypeEnum.G3_BulldozerCloud, Industry.GlobalInfo.CanBulldozerCloudAttribute, "Pollution", "Permanent\n\nBulldozer will produce more cloud."));
		_iconInfo.Add(IconTypeEnum.G4_LastCycleMoreOutput, new IconInfo(IconTypeEnum.G4_LastCycleMoreOutput, Industry.GlobalInfo.CanLastCycleMoreOutputAttribute, "10th+", "Permanent\n\n+5 trash on the 10th cycle."));
		_iconInfo.Add(IconTypeEnum.G5_AllMoreOutput, new IconInfo(IconTypeEnum.G5_AllMoreOutput, Industry.GlobalInfo.CanAllMoreOutputAttribute, "Output+", "Permanent\n\n+1 trash on each cycle of the factory."));
		_iconInfo.Add(IconTypeEnum.G6_Half, new IconInfo(IconTypeEnum.G6_Half, Industry.GlobalInfo.CanLowerCostAttribute, "Lower Cost", "Permanent\n\nReduce the cost by 50% to level up the factory."));
		_iconInfo.Add(IconTypeEnum.G7_AllCanGenerateMedium, new IconInfo(IconTypeEnum.G7_AllCanGenerateMedium, Industry.GlobalInfo.CanAllCanGenerateMediumAttribute, "All Medium", "Permanent\n\nEvery time 4 small pieces of trash are generated from any building, they will be combined into 1 medium."));
		_iconInfo.Add(IconTypeEnum.H1_Bu_Compressor, new IconInfo(IconTypeEnum.H1_Bu_Compressor, Compressor.GlobalInfo.LevelUpAttribute, LanguageText.GetText("Compressor"), "Unlock Building\n\nCompresses trash into one larger, higher-value trash.\n\n+1 maximum compressor on map."));
		_iconInfo.Add(IconTypeEnum.H2_BetterSmallCompress, new IconInfo(IconTypeEnum.H2_BetterSmallCompress, Compressor.GlobalInfo.CanBetterSmallCompressAttribute, "Compress Small", "Permanent\n\n+5% value to medium trash generated by the compressor."));
		_iconInfo.Add(IconTypeEnum.H3_Ab_CompressAllInStorage, new IconInfo(IconTypeEnum.H3_Ab_CompressAllInStorage, GameController.GlobalInfo.CanAbilityCompressAllInStorageAttribute, "Compressor Burst", "Unlock Ability\n\nEvery " + SecondsToMinutes(Ability.GetMaxDelay(Ability.AbilityTypeEnum.PowerCompress)) + " minutes, compress all trash in the compressor and double its value."));
		_iconInfo.Add(IconTypeEnum.H4_CompressMedium, new IconInfo(IconTypeEnum.H4_CompressMedium, Compressor.GlobalInfo.CanCompressMediumAttribute, "Compress Medium", "Permanent\n\nCompress medium trash.\n\n+5% value to large trash generated by the compressor."));
		_iconInfo.Add(IconTypeEnum.H5_GarbageMoreMoney, new IconInfo(IconTypeEnum.H5_GarbageMoreMoney, Compressor.GlobalInfo.CanGarbageMoreMoneyAttribute, "Trash $+", "Permanent\n\nAll trash put in the hole will give an extra 1$."));
		_iconInfo.Add(IconTypeEnum.H6_Half, new IconInfo(IconTypeEnum.H6_Half, Compressor.GlobalInfo.CanLowerCostAttribute, "Lower Cost", "Permanent\n\nReduce the cost by 50% to level up the compressor."));
		_iconInfo.Add(IconTypeEnum.H7_MediumOnLowStability, new IconInfo(IconTypeEnum.H7_MediumOnLowStability, Compressor.GlobalInfo.CanMediumOnLowStabilityAttribute, "Durability M.", "Permanent\n\nWhen any building is destroyed due to durability, it produces medium trash."));
		_iconInfo.Add(IconTypeEnum.H8_CompressLarge, new IconInfo(IconTypeEnum.H8_CompressLarge, Compressor.GlobalInfo.CanCompressLargeAttribute, "Compress Large", "Permanent\n\nCompress large trash.\n\n+5% value to extra large trash generated by the compressor."));
		_iconInfo.Add(IconTypeEnum.H9_ConvertYtoB, new IconInfo(IconTypeEnum.H9_ConvertYtoB, Compressor.GlobalInfo.CanConvertYtoBAttribute, "Y to B", "Permanent\n\nConvert yellow shards into 1 blue shard."));
		_iconInfo.Add(IconTypeEnum.H10_ConvertBtoY, new IconInfo(IconTypeEnum.H10_ConvertBtoY, Compressor.GlobalInfo.CanConvertBtoYAttribute, "B to Y", "Permanent\n\nConvert blue shard into 3 yellow shards."));
		_iconInfo.Add(IconTypeEnum.H11_Doublecompress, new IconInfo(IconTypeEnum.H11_Doublecompress, Compressor.GlobalInfo.CanDoublecompressAttribute, "X2 Press", "Permanent\n\nDouble the output of compression."));
		_iconInfo.Add(IconTypeEnum.H12_Compress8, new IconInfo(IconTypeEnum.H12_Compress8, Compressor.GlobalInfo.CanCompress8Attribute, "Compress 8", "Permanent\n\nCompress 8 trash (instead of 4) into 2 larger ones."));
		_iconInfo.Add(IconTypeEnum.H13_CompressFromCompressor, new IconInfo(IconTypeEnum.H13_CompressFromCompressor, Compressor.GlobalInfo.CanCompressFromCompressorAttribute, "Recycle", "Permanent\n\nAllow compressor to process garbage that was already compressed."));
		_iconInfo.Add(IconTypeEnum.I1_Bu_Power, new IconInfo(IconTypeEnum.I1_Bu_Power, Power.GlobalInfo.LevelUpAttribute, LanguageText.GetText("Power"), "Unlock Building\n\nPower stations increase attributes of nearby buildings.\n\n+1 maximum power on map."));
		_iconInfo.Add(IconTypeEnum.I2_PrestigeRemoveStability, new IconInfo(IconTypeEnum.I2_PrestigeRemoveStability, Power.GlobalInfo.CanPrestigeRemoveStabilityAttribute, "Hardness", "Permanent\n\nDuring earthquakes, buildings lose 30% durability instead of being destroyed.\n\n+10% for each extra level."));
		_iconInfo.Add(IconTypeEnum.I3_MoreManualDestroy, new IconInfo(IconTypeEnum.I3_MoreManualDestroy, Power.GlobalInfo.CanMoreManualDestroyAttribute, "Manual+", "Permanent\n\n+10% value of trash when any building is manually destroyed."));
		_iconInfo.Add(IconTypeEnum.I4_MoreStabilityDestroy, new IconInfo(IconTypeEnum.I4_MoreStabilityDestroy, Power.GlobalInfo.CanMoreStabilityDestroyAttribute, "Durability+", "Permanent\n\n+10% value of trash when any building loses all durability."));
		_iconInfo.Add(IconTypeEnum.I5_CompressClosebyGarbage, new IconInfo(IconTypeEnum.I5_CompressClosebyGarbage, Power.GlobalInfo.CanLightningGarbageAttribute, "Power Lightning", "Permanent\n\nAt the end of a power cycle, workers shoot lightning that doubles the value of a random nearby trash."));
		_iconInfo.Add(IconTypeEnum.I6_Ab_CompressAllOnMap, new IconInfo(IconTypeEnum.I6_Ab_CompressAllOnMap, GameController.GlobalInfo.CanAbilityCompressAllOnMapAttribute, "Compress All", "Unlock Ability\n\nEvery " + SecondsToMinutes(Ability.GetMaxDelay(Ability.AbilityTypeEnum.CompressAll)) + " minutes, compress all trash on the map."));
		_iconInfo.Add(IconTypeEnum.I7_MorePrestige, new IconInfo(IconTypeEnum.I7_MorePrestige, Power.GlobalInfo.CanMorePrestigeAttribute, "Earthquake+", "Permanent\n\n+10% of money converted to trash during earthquake."));
		_iconInfo.Add(IconTypeEnum.I8_Half, new IconInfo(IconTypeEnum.I8_Half, Power.GlobalInfo.CanLowerCostAttribute, "Lower Cost", "Permanent\n\nReduce the cost by 50% to level up the power building."));
		_iconInfo.Add(IconTypeEnum.I9_BuildingLessCost, new IconInfo(IconTypeEnum.I9_BuildingLessCost, Power.GlobalInfo.CanBuildingLessCostAttribute, "-Building Level", "Permanent\n\nFor each durability level of any building, reduce its level up cost by 5%."));
		_iconInfo.Add(IconTypeEnum.I10_Ab_DoubleAllOnMap, new IconInfo(IconTypeEnum.I10_Ab_DoubleAllOnMap, GameController.GlobalInfo.CanAbilityDoubleAllOnMapAttribute, "Zap All", "Unlock Ability\n\nEvery " + SecondsToMinutes(Ability.GetMaxDelay(Ability.AbilityTypeEnum.DoubleAll)) + " minutes, double the value of all trash on the map."));
		_iconInfo.Add(IconTypeEnum.I11_HaveMoreRange, new IconInfo(IconTypeEnum.I11_HaveMoreRange, Power.GlobalInfo.CanHaveMoreRangeAttribute, "More Range", "Unlock Building\n\nIncrease the range of the power building."));
		_iconInfo.Add(IconTypeEnum.I12_Ab_LowerAllStability, new IconInfo(IconTypeEnum.I12_Ab_LowerAllStability, GameController.GlobalInfo.CanAbilityLowerAllStabilityAttribute, "Durability Down", "Unlock Ability\n\nEvery " + SecondsToMinutes(Ability.GetMaxDelay(Ability.AbilityTypeEnum.LowerDurability)) + " minutes, reduce the durability of all buildings by 10%."));
		_iconInfo.Add(IconTypeEnum.J1_Bu_Helicopter, new IconInfo(IconTypeEnum.J1_Bu_Helicopter, Helicopter.GlobalInfo.LevelUpAttribute, LanguageText.GetText("Helipad"), "Unlock Building\n\nHelicopter will arrive periodically to drop trash.\n\n+1 maximum helipad on map."));
		_iconInfo.Add(IconTypeEnum.J2_DumpRight, new IconInfo(IconTypeEnum.J2_DumpRight, Helicopter.GlobalInfo.CanDumpRightAttribute, "Dump Right", "Unlock Building Upgrade\n\nCan allow helicopter to dump further to the right."));
		_iconInfo.Add(IconTypeEnum.J3_OutputLessButMedium, new IconInfo(IconTypeEnum.J3_OutputLessButMedium, Helicopter.GlobalInfo.CanOutputLessButMediumAttribute, "Heavy Dump", "Permanent\n\nHelicopter dumps less trash, but generates higher-value medium trash."));
		_iconInfo.Add(IconTypeEnum.J4_MoreHelicopter, new IconInfo(IconTypeEnum.J4_MoreHelicopter, Helicopter.GlobalInfo.CanMoreHelicopterAttribute, "Helicopter+", "Permanent\n\nIncrease max level of helipad and add an extra helicopter."));
		_iconInfo.Add(IconTypeEnum.J5_Half, new IconInfo(IconTypeEnum.J5_Half, Helicopter.GlobalInfo.CanLowerCostAttribute, "Lower Cost", "Permanent\n\nReduce the cost by 50% to level up the helipad."));
		_iconInfo.Add(IconTypeEnum.J6_Ab_Airplane, new IconInfo(IconTypeEnum.J6_Ab_Airplane, GameController.GlobalInfo.CanAbilityAirplaneAttribute, "Airplane", "Unlock Ability\n\nEvery " + SecondsToMinutes(Ability.GetMaxDelay(Ability.AbilityTypeEnum.Airplane)) + " minutes, an airplane will drop medium trash with a value of " + 35 + "."));
		_iconInfo.Add(IconTypeEnum.J7_Transition, new IconInfo(IconTypeEnum.J7_Transition, Helicopter.GlobalInfo.CanTransitionAttribute, "Transition", "Permanent\n\nTransition node. Does nothing."));
		_iconInfo.Add(IconTypeEnum.J8_IncreaseSizeOfGarbage, new IconInfo(IconTypeEnum.J8_IncreaseSizeOfGarbage, Helicopter.GlobalInfo.CanIncreaseSizeOfGarbageAttribute, "Trash Size", "Permanent\n\nEach trash thrown in the hole increases the fill rate by 100%."));
		_iconInfo.Add(IconTypeEnum.J9_Transition, new IconInfo(IconTypeEnum.J9_Transition, Helicopter.GlobalInfo.CanTransition2Attribute, "Transition", "Permanent\n\nTransition node. Does nothing."));
		_iconInfo.Add(IconTypeEnum.J10_OutputMore, new IconInfo(IconTypeEnum.J10_OutputMore, Helicopter.GlobalInfo.CanOutputMoreAttribute, "Trash+", "Unlock Building Upgrade\n\nCan increase the amount of trash generated by the helicopter."));
		_iconInfo.Add(IconTypeEnum.J11_Transition, new IconInfo(IconTypeEnum.J11_Transition, Helicopter.GlobalInfo.CanTransition3Attribute, "Transition", "Permanent\n\nTransition node. Does nothing."));
		_iconInfo.Add(IconTypeEnum.J12_AirplaneMore, new IconInfo(IconTypeEnum.J12_AirplaneMore, GameController.GlobalInfo.CanAbilityAirplaneMoreAttribute, "Airplane+", "Permanent\n\nAirplane will drop large garbage with a value of " + 245 + "."));
		_iconInfo.Add(IconTypeEnum.K1_Bu_Baloon, new IconInfo(IconTypeEnum.K1_Bu_Baloon, HotAirStation.GlobalInfo.LevelUpAttribute, LanguageText.GetText("Hangar"), "Unlock Building\n\nHot Air balloon will fly and grab trash to throw back in the hole.\n\n+1 maximum hangar on map."));
		_iconInfo.Add(IconTypeEnum.K2_MoreBaloon, new IconInfo(IconTypeEnum.K2_MoreBaloon, HotAirStation.GlobalInfo.CanMoreBaloonAttribute, "Balloon+", "Permanent\n\nIncrease max level of hangar and add an extra balloon."));
		_iconInfo.Add(IconTypeEnum.K4_MoveLeft, new IconInfo(IconTypeEnum.K4_MoveLeft, HotAirStation.GlobalInfo.CanMoveLeftAttribute, "Move Left", "Unlock Building Upgrade\n\nCan allow balloon to move more to the left."));
		_iconInfo.Add(IconTypeEnum.K5_Half, new IconInfo(IconTypeEnum.K5_Half, HotAirStation.GlobalInfo.CanLowerCostAttribute, "Lower Cost", "Permanent\n\nReduce the cost by 50% to level up the hangar."));
		_iconInfo.Add(IconTypeEnum.K6_StrongerFan, new IconInfo(IconTypeEnum.K6_StrongerFan, HotAirStation.GlobalInfo.CanStrongerFanAttribute, "Stronger", "Permanent\n\nBalloon will be able to pull medium-size trash."));
		_iconInfo.Add(IconTypeEnum.K7_BothSide, new IconInfo(IconTypeEnum.K7_BothSide, HotAirStation.GlobalInfo.CanBothSideAttribute, "Coming Back", "Permanent\n\nBalloons can collect trash when moving to the left."));
		_iconInfo.Add(IconTypeEnum.K8_CanCompress, new IconInfo(IconTypeEnum.K8_CanCompress, HotAirStation.GlobalInfo.CanCompressAttribute, "Compress", "Permanent\n\nBalloons will compress 4 trash in storage into a larger one.\n\nLevel 1: Compress Small\nLevel 2: Compress Medium\nLevel 3: Compress Large"));
		_iconInfo.Add(IconTypeEnum.K9_StrongerFan2, new IconInfo(IconTypeEnum.K9_StrongerFan2, HotAirStation.GlobalInfo.CanStrongerFan2Attribute, "Stronger V2", "Permanent\n\nBalloon will be able to pull all size trash."));
		_iconInfo.Add(IconTypeEnum.L1_Bu_Drone, new IconInfo(IconTypeEnum.L1_Bu_Drone, Drone.GlobalInfo.LevelUpAttribute, LanguageText.GetText("Cloud Seeder"), "Unlock Building\n\nDrones will seed clouds to drop trash.\n\n+1 maximum cloud seeders on map."));
		_iconInfo.Add(IconTypeEnum.L2_ClickPowerIncrease, new IconInfo(IconTypeEnum.L2_ClickPowerIncrease, Drone.GlobalInfo.CanClickPowerIncreaseAttribute, "Cloud Power", "Permanent\n\n+2 to manual click power on clouds."));
		_iconInfo.Add(IconTypeEnum.L3_CloudOutputMore, new IconInfo(IconTypeEnum.L3_CloudOutputMore, Drone.GlobalInfo.CanCloudOutputMoreAttribute, "Cloud Drop", "Permanent\n\n+1 trash to cloud output (when hit and destroyed)."));
		_iconInfo.Add(IconTypeEnum.L4_MoreDrone, new IconInfo(IconTypeEnum.L4_MoreDrone, Drone.GlobalInfo.CanMoreDroneAttribute, "Drone+", "Permanent\n\nIncrease max level of cloud seeders and add an extra drone."));
		_iconInfo.Add(IconTypeEnum.L5_Half, new IconInfo(IconTypeEnum.L5_Half, Drone.GlobalInfo.CanLowerCostAttribute, "Lower Cost", "Permanent\n\nReduce the cost by 50% to level up the cloud seeder."));
		_iconInfo.Add(IconTypeEnum.L6_BothSide, new IconInfo(IconTypeEnum.L6_BothSide, Drone.GlobalInfo.CanBothSideAttribute, "Both Sides", "Permanent\n\nDrones will work on both sides."));
		_iconInfo.Add(IconTypeEnum.L7_CloudOutputBigger, new IconInfo(IconTypeEnum.L7_CloudOutputBigger, Drone.GlobalInfo.CanCloudOutputBiggerAttribute, "Cloud Output+", "Permanent\n\nClouds can generate bigger trash."));
		_iconInfo.Add(IconTypeEnum.L8_StrongerParticle, new IconInfo(IconTypeEnum.L8_StrongerParticle, Drone.GlobalInfo.CanStrongerParticleAttribute, "Particle Str", "Permanent\n\n+1 to particle strength."));
		_iconInfo.Add(IconTypeEnum.L9_CloudMakeRP, new IconInfo(IconTypeEnum.L9_CloudMakeRP, Drone.GlobalInfo.CanCloudMakeRPAttribute, "Cloud Research", "Permanent\n\n+1 RP when a cloud is destroyed (more for larger clouds)."));
		_iconInfo.Add(IconTypeEnum.L10_MoreParticle, new IconInfo(IconTypeEnum.L10_MoreParticle, Drone.GlobalInfo.CanMoreParticleAttribute, "Particle+", "Permanent\n\nParticles now hit one more cloud."));
		_iconInfo.Add(IconTypeEnum.M1_Bu_Smoke, new IconInfo(IconTypeEnum.M1_Bu_Smoke, Smoke.GlobalInfo.LevelUpAttribute, "Smoke", "Unlock Building\n\nNOT IMPLEMENTED."));
		_iconInfo.Add(IconTypeEnum.N1_Bu_Temple, new IconInfo(IconTypeEnum.N1_Bu_Temple, Temple.GlobalInfo.LevelUpAttribute, LanguageText.GetText("Temple"), "Unlock Building\n\nCall help from another dimension."));
		_iconInfo.Add(IconTypeEnum.N2_ExtraPortal1, new IconInfo(IconTypeEnum.N2_ExtraPortal1, Temple.GlobalInfo.CanExtraPortal1Attribute, "Extra Portal", "Permanent\n\nOpen a portal to another world. Need 2 peons in the temple."));
		_iconInfo.Add(IconTypeEnum.N3_ExtraPortal2, new IconInfo(IconTypeEnum.N3_ExtraPortal2, Temple.GlobalInfo.CanExtraPortal2Attribute, "Extra Portal", "Permanent\n\nOpen a portal to another world. Need 3 peons in the temple."));
		_iconInfo.Add(IconTypeEnum.N4_Lazer, new IconInfo(IconTypeEnum.N4_Lazer, Temple.GlobalInfo.CanHaveLazerAttribute, "Lazer", "Permanent\n\nCreate a ray strong enough to stop any enemies (no peon needed).\nOpen a portal to another world. Need 4 peons in the temple."));
		_iconInfo.Add(IconTypeEnum.N5_Half, new IconInfo(IconTypeEnum.N5_Half, Temple.GlobalInfo.CanLowerCostAttribute, "Lower Cost", "Permanent\n\nReduce the cost by 50% to level up the temple."));
		_iconInfo.Add(IconTypeEnum.N6_MoreRP, new IconInfo(IconTypeEnum.N6_MoreRP, Temple.GlobalInfo.CanMoreRPAttribute, "Portal RP", "Permanent\n\nPortal will produce RP."));
		_iconInfo.Add(IconTypeEnum.N7_BiggerOutput, new IconInfo(IconTypeEnum.N7_BiggerOutput, Temple.GlobalInfo.CanBiggerOutputAttribute, "Portal Power", "Permanent\n\nIncrease the size of generated trash from portal."));
		_iconInfo.Add(IconTypeEnum.N8_YtoR, new IconInfo(IconTypeEnum.N8_YtoR, Temple.GlobalInfo.CanYtoRAttribute, "Y -> R", "Permanent\n\nBuy a red shard."));
		_iconInfo.Add(IconTypeEnum.O1_Transition1, new IconInfo(IconTypeEnum.O1_Transition1, GameController.GlobalInfo.CanDeviceTransition1Attribute, "Transition", "Permanent\n\nTransition node for device. Does nothing."));
		_iconInfo.Add(IconTypeEnum.O2_Transition2, new IconInfo(IconTypeEnum.O2_Transition2, GameController.GlobalInfo.CanDeviceTransition2Attribute, "Transition", "Permanent\n\nTransition node for device. Does nothing.\n\nHouse, Research, Training and Factory."));
		_iconInfo.Add(IconTypeEnum.O3_Transition3, new IconInfo(IconTypeEnum.O3_Transition3, GameController.GlobalInfo.CanDeviceTransition3Attribute, "Transition", "Permanent\n\nTransition node for device. Does nothing.\n\nCloud Seeder, Compressor, Power, Helipad and Hangar."));
		_iconInfo.Add(IconTypeEnum.O4_CompressorDevice, new IconInfo(IconTypeEnum.O4_CompressorDevice, Compressor.GlobalInfo.CanAutoDeviceAttribute, "Compressor Device", "Unlock Building Upgrade\n\nCan run the Compressor device automatically after it was manually activated once."));
		_iconInfo.Add(IconTypeEnum.O5_DroneDevice, new IconInfo(IconTypeEnum.O5_DroneDevice, Drone.GlobalInfo.CanAutoDeviceAttribute, "Cloud S. Device", "Unlock Building Upgrade\n\nCan run the Cloud Seeder device automatically after it was manually activated once."));
		_iconInfo.Add(IconTypeEnum.O6_HelicopterDevice, new IconInfo(IconTypeEnum.O6_HelicopterDevice, Helicopter.GlobalInfo.CanAutoDeviceAttribute, "Helipad Device", "Unlock Building Upgrade\n\nCan run the Helipad device automatically after it was manually activated once."));
		_iconInfo.Add(IconTypeEnum.O7_HotairDevice, new IconInfo(IconTypeEnum.O7_HotairDevice, HotAirStation.GlobalInfo.CanAutoDeviceAttribute, "Hangar Device", "Unlock Building Upgrade\n\nCan run the Hangar device automatically after it was manually activated once."));
		_iconInfo.Add(IconTypeEnum.O8_HouseDevice, new IconInfo(IconTypeEnum.O8_HouseDevice, House.GlobalInfo.CanAutoDeviceAttribute, "House Device", "Unlock Building Upgrade\n\nCan run the House device automatically after it was manually activated once."));
		_iconInfo.Add(IconTypeEnum.O9_IndustryDevice, new IconInfo(IconTypeEnum.O9_IndustryDevice, Industry.GlobalInfo.CanAutoDeviceAttribute, "Factory Device", "Unlock Building Upgrade\n\nCan run the Factory device automatically after it was manually activated once."));
		_iconInfo.Add(IconTypeEnum.O10_PowerDevice, new IconInfo(IconTypeEnum.O10_PowerDevice, Power.GlobalInfo.CanAutoDeviceAttribute, "Power Device", "Unlock Building Upgrade\n\nCan run the Power device automatically after it was manually activated once."));
		_iconInfo.Add(IconTypeEnum.O11_ResearchDevice, new IconInfo(IconTypeEnum.O11_ResearchDevice, Research.GlobalInfo.CanAutoDeviceAttribute, "Research Device", "Unlock Building Upgrade\n\nCan run the Research Lab device automatically after it was manually activated once."));
		_iconInfo.Add(IconTypeEnum.O12_TrainingDevice, new IconInfo(IconTypeEnum.O12_TrainingDevice, Training.GlobalInfo.CanAutoDeviceAttribute, "Training Device", "Unlock Building Upgrade\n\nCan run the Training device automatically after it was manually activated once."));
	}

	private void Start()
	{
		_backImage = base.transform.Find("BackImage").gameObject;
		_backImage.GetComponent<Image>().enabled = false;
		_borderImage = base.transform.Find("BorderImage").gameObject;
		_borderImage.GetComponent<Image>().enabled = false;
		SetIconColor();
		StartBackgroundAnim();
		SetIconState();
	}

	private void Update()
	{
		SetIconColor();
		SetIconState();
	}

	private void SetIconState()
	{
		IconStateEnum iconStateEnum = IconStateEnum.None;
		switch ((IconStateEnum)((ParentIcon == null) ? ((int)GetAttributeStatus()) : ((!GameController.GlobalInfo.LevelUpAttribute.IsEnabled) ? 1 : ((_iconInfo[ParentIcon.IconType].Attribute.Level != 0) ? ((int)GetAttributeStatus()) : ((!SkillTreePanel.DisplayAllNodes) ? 1 : 2)))))
		{
		case IconStateEnum.None:
			GetComponent<Image>().enabled = false;
			_borderImage.GetComponent<Image>().enabled = false;
			_backImage.GetComponent<Image>().enabled = false;
			break;
		case IconStateEnum.Hidden:
			GetComponent<Image>().enabled = false;
			_borderImage.GetComponent<Image>().enabled = false;
			_backImage.GetComponent<Image>().enabled = false;
			break;
		case IconStateEnum.CannotAfford:
			GetComponent<Image>().enabled = true;
			_borderImage.GetComponent<Image>().enabled = false;
			_backImage.GetComponent<Image>().enabled = false;
			break;
		case IconStateEnum.CanAfford:
			GetComponent<Image>().enabled = true;
			_borderImage.GetComponent<Image>().enabled = false;
			_backImage.GetComponent<Image>().enabled = true;
			break;
		case IconStateEnum.Completed:
			GetComponent<Image>().enabled = true;
			_borderImage.GetComponent<Image>().enabled = true;
			_backImage.GetComponent<Image>().enabled = false;
			break;
		}
	}

	private void StartBackgroundAnim()
	{
		if (_newNodeSequence == null)
		{
			_backImage.SetActive(value: true);
			_newNodeSequence = DOTween.Sequence();
			_newNodeSequence.Append(_backImage.transform.DOScale(1.3f, 1f));
			_newNodeSequence.Join(_backImage.GetComponent<Image>().DOFade(0.5f, 1f));
			_newNodeSequence.SetLoops(-1, LoopType.Yoyo);
		}
	}

	private void RestartAnim()
	{
		if (_newNodeSequence != null)
		{
			_newNodeSequence.Restart();
		}
	}

	private bool TryEnable()
	{
		bool result = _iconInfo[IconType].Attribute.TryLevelUp();
		SetIconColor();
		return result;
	}

	public bool IsActivated()
	{
		return _iconInfo[IconType].Attribute.Level > 0;
	}

	private void SetIconColor()
	{
		BaseSavableAttribute attribute = _iconInfo[IconType].Attribute;
		Color color = Color.white;
		if (attribute is BaseMoneyAttribute)
		{
			color = GameController.MoneyColor;
		}
		else if (attribute is BaseMoneyLevelAttribute)
		{
			color = GameController.MoneyColor;
		}
		else if (attribute is BaseResearchAttribute)
		{
			color = GameController.RPColor;
		}
		else if (attribute is BaseResearchLevelAttribute)
		{
			color = GameController.RPColor;
		}
		else if (attribute is BaseShardBLevelAttribute)
		{
			color = GameController.BlueShardColor;
		}
		else if (attribute is BaseShardRLevelAttribute)
		{
			color = GameController.RedShardColor;
		}
		else if (attribute is BaseShardYLevelAttribute)
		{
			color = GameController.YellowShardColor;
		}
		else if (attribute is BaseBookAttribute)
		{
			color = GameController.BookColor;
		}
		Color color2 = color;
		if (IconType != IconTypeEnum.A1_Central && !IsActivated())
		{
			color = new Color(color.r * 0.35f, color.g * 0.35f, color.b * 0.35f);
			color2 = new Color(color2.r * 0.5f, color2.g * 0.5f, color2.b * 0.5f);
		}
		GetComponent<Image>().color = color;
		_borderImage.GetComponent<Image>().color = new Color(color.r, color.g, color.b, 0.5f);
		_backImage.GetComponent<Image>().color = new Color(color2.r, color2.g, color2.b, 0.25f);
	}

	private void ShowTooltip()
	{
		IconInfo info = _iconInfo[IconType];
		BaseSavableAttribute attr = info.Attribute;
		string extraDesc = "";
		if (CharDisplay.HasRelax && (IconType == IconTypeEnum.H7_MediumOnLowStability || IconType == IconTypeEnum.I4_MoreStabilityDestroy))
		{
			extraDesc = "\n\nThis has no effect in relax mode.";
		}
		if (attr is BaseMoneyAttribute)
		{
			SkillTreeTooltip.Instance.ShowDynamicTooltip(base.gameObject, base.gameObject, (SkillTreeTooltip.TooltipInfo a) => a.Update(info.Name, ((BaseMoneyAttribute)attr).Level + "/1", info.Description + extraDesc, attr.IsEnabled ? "Max" : (((BaseMoneyAttribute)attr).GetCost().ToNumber() + "$")));
		}
		else if (attr is BaseMoneyLevelAttribute)
		{
			SkillTreeTooltip.Instance.ShowDynamicTooltip(base.gameObject, base.gameObject, (SkillTreeTooltip.TooltipInfo a) => a.Update(info.Name, ((BaseMoneyLevelAttribute)attr).Level + "/" + ((BaseMoneyLevelAttribute)attr).GetMaxLevel(), info.Description + extraDesc, ((BaseMoneyLevelAttribute)attr).IsMax ? "Max" : (((BaseMoneyLevelAttribute)attr).GetCost().ToNumber() + "$")));
		}
		else if (attr is BaseResearchAttribute)
		{
			SkillTreeTooltip.Instance.ShowDynamicTooltip(base.gameObject, base.gameObject, (SkillTreeTooltip.TooltipInfo a) => a.Update(info.Name, ((BaseResearchAttribute)attr).Level + "/1", info.Description + extraDesc, attr.IsEnabled ? "Max" : (((BaseResearchAttribute)attr).GetCost().ToNumber() + " RP")));
		}
		else if (attr is BaseResearchLevelAttribute)
		{
			SkillTreeTooltip.Instance.ShowDynamicTooltip(base.gameObject, base.gameObject, (SkillTreeTooltip.TooltipInfo a) => a.Update(info.Name, ((BaseResearchLevelAttribute)attr).Level + "/" + ((BaseResearchLevelAttribute)attr).GetMaxLevel(), info.Description + extraDesc, ((BaseResearchLevelAttribute)attr).IsMax ? "Max" : (((BaseResearchLevelAttribute)attr).GetCost().ToNumber() + " RP")));
		}
		else if (attr is BaseShardBLevelAttribute)
		{
			SkillTreeTooltip.Instance.ShowDynamicTooltip(base.gameObject, base.gameObject, (SkillTreeTooltip.TooltipInfo a) => a.Update(info.Name, ((BaseShardBLevelAttribute)attr).Level + "/" + ((BaseShardBLevelAttribute)attr).GetMaxLevel(), info.Description + extraDesc, ((BaseShardBLevelAttribute)attr).IsMax ? "Max" : (((BaseShardBLevelAttribute)attr).GetCost() + " Blue Shard(s)")));
		}
		else if (attr is BaseShardRLevelAttribute)
		{
			SkillTreeTooltip.Instance.ShowDynamicTooltip(base.gameObject, base.gameObject, (SkillTreeTooltip.TooltipInfo a) => a.Update(info.Name, ((BaseShardRLevelAttribute)attr).Level + "/" + ((BaseShardRLevelAttribute)attr).GetMaxLevel(), info.Description + extraDesc, ((BaseShardRLevelAttribute)attr).IsMax ? "Max" : (((BaseShardRLevelAttribute)attr).GetCost() + " Red Shard(s)")));
		}
		else if (attr is BaseShardYLevelAttribute)
		{
			SkillTreeTooltip.Instance.ShowDynamicTooltip(base.gameObject, base.gameObject, (SkillTreeTooltip.TooltipInfo a) => a.Update(info.Name, ((BaseShardYLevelAttribute)attr).Level + "/" + ((BaseShardYLevelAttribute)attr).GetMaxLevel(), info.Description + extraDesc, ((BaseShardYLevelAttribute)attr).IsMax ? "Max" : (((BaseShardYLevelAttribute)attr).GetCost() + " Yellow Shard(s)")));
		}
		else if (attr is BaseBookAttribute)
		{
			SkillTreeTooltip.Instance.ShowDynamicTooltip(base.gameObject, base.gameObject, (SkillTreeTooltip.TooltipInfo a) => a.Update(info.Name, ((BaseBookAttribute)attr).Level + "/1", info.Description + extraDesc, attr.IsEnabled ? "Max" : (((BaseBookAttribute)attr).GetCost() + " Book")));
		}
		else
		{
			_ = attr is BaseTrainingAttribute;
		}
	}

	private IconStateEnum GetAttributeStatus()
	{
		BaseSavableAttribute attribute = _iconInfo[IconType].Attribute;
		if (attribute is BaseMoneyAttribute)
		{
			if (((BaseMoneyAttribute)attribute).IsEnabled)
			{
				return IconStateEnum.Completed;
			}
			if (((BaseMoneyAttribute)attribute).CanEnable())
			{
				return IconStateEnum.CanAfford;
			}
			return IconStateEnum.CannotAfford;
		}
		if (attribute is BaseMoneyLevelAttribute)
		{
			if (((BaseMoneyLevelAttribute)attribute).IsMax)
			{
				return IconStateEnum.Completed;
			}
			if (((BaseMoneyLevelAttribute)attribute).CanLevel())
			{
				return IconStateEnum.CanAfford;
			}
			return IconStateEnum.CannotAfford;
		}
		if (attribute is BaseResearchAttribute)
		{
			if (((BaseResearchAttribute)attribute).IsEnabled)
			{
				return IconStateEnum.Completed;
			}
			if (((BaseResearchAttribute)attribute).CanEnable())
			{
				return IconStateEnum.CanAfford;
			}
			return IconStateEnum.CannotAfford;
		}
		if (attribute is BaseResearchLevelAttribute)
		{
			if (((BaseResearchLevelAttribute)attribute).IsMax)
			{
				return IconStateEnum.Completed;
			}
			if (((BaseResearchLevelAttribute)attribute).CanLevel())
			{
				return IconStateEnum.CanAfford;
			}
			return IconStateEnum.CannotAfford;
		}
		if (attribute is BaseShardBLevelAttribute)
		{
			if (((BaseShardBLevelAttribute)attribute).IsMax)
			{
				return IconStateEnum.Completed;
			}
			if (((BaseShardBLevelAttribute)attribute).CanLevel())
			{
				return IconStateEnum.CanAfford;
			}
			return IconStateEnum.CannotAfford;
		}
		if (attribute is BaseShardRLevelAttribute)
		{
			if (((BaseShardRLevelAttribute)attribute).IsMax)
			{
				return IconStateEnum.Completed;
			}
			if (((BaseShardRLevelAttribute)attribute).CanLevel())
			{
				return IconStateEnum.CanAfford;
			}
			return IconStateEnum.CannotAfford;
		}
		if (attribute is BaseShardYLevelAttribute)
		{
			if (((BaseShardYLevelAttribute)attribute).IsMax)
			{
				return IconStateEnum.Completed;
			}
			if (((BaseShardYLevelAttribute)attribute).CanLevel())
			{
				return IconStateEnum.CanAfford;
			}
			return IconStateEnum.CannotAfford;
		}
		if (attribute is BaseBookAttribute)
		{
			if (((BaseBookAttribute)attribute).IsEnabled)
			{
				return IconStateEnum.Completed;
			}
			if (((BaseBookAttribute)attribute).CanEnable())
			{
				return IconStateEnum.CanAfford;
			}
			return IconStateEnum.CannotAfford;
		}
		_ = attribute is BaseTrainingAttribute;
		return IconStateEnum.None;
	}

	private static float SecondsToMinutes(float seconds)
	{
		return seconds / 60f;
	}

	private void HideTooltip()
	{
		SkillTreeTooltip.Instance.HideTooltip();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		GlobalSfx2Controller.Instance.PlayOneWithPitch(SoundManager.SoundTypeEnum.ui_node_hover);
		_overTween = base.transform.DOScale(1.2f, 0.5f).SetEase(Ease.OutElastic);
		ShowTooltip();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (_overTween != null && _overTween.active)
		{
			_overTween.Kill();
		}
		_overTween = null;
		base.transform.localScale = new Vector3(1f, 1f, 1f);
		HideTooltip();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button != PointerEventData.InputButton.Left)
		{
			return;
		}
		if (ParentIcon == null || ParentIcon.IsActivated())
		{
			if (TryEnable())
			{
				if (base.transform.Find("SaveParticle") != null)
				{
					base.transform.Find("SaveParticle").GetComponent<ParticleSystem>().Play();
				}
				if (IconType == IconTypeEnum.E7_MoneyToYellow)
				{
					GameController.Instance.GainYellowPoint(1);
				}
				if (IconType == IconTypeEnum.H9_ConvertYtoB)
				{
					GameController.Instance.GainBluePoint(1);
				}
				if (IconType == IconTypeEnum.H10_ConvertBtoY)
				{
					GameController.Instance.GainYellowPoint(3);
				}
				if (IconType == IconTypeEnum.N8_YtoR)
				{
					GameController.Instance.GainRedPoint(1);
				}
				SkillTreeIcon2[] array = Object.FindObjectsByType<SkillTreeIcon2>(FindObjectsInactive.Include, FindObjectsSortMode.None);
				for (int i = 0; i < array.Length; i++)
				{
					array[i].RestartAnim();
				}
				ShowTooltip();
				if (_iconInfo[IconType].Attribute is BaseShardRLevelAttribute)
				{
					GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ui_node_click_success);
					GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ga_signing);
				}
				else
				{
					GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ui_node_click_success);
				}
			}
			else
			{
				GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ui_node_click_fail);
			}
		}
		else
		{
			GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ui_node_click_fail);
		}
	}
}
