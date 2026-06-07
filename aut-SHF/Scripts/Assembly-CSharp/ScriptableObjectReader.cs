using System;
using System.Collections.Generic;
using Factory.FieldData;
using PostProcess;
using ScriptableObjects.ScriptableObjectScripts.ExtendData;
using ScriptableObjects.ScriptableObjectScripts.Settings;
using ScriptableObjects.ScriptableObjectScripts.Tile;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class ScriptableObjectReader : ScriptableObject
{
	public enum JamIconStatus
	{
		None = 0,
		Jam12 = 1,
		Jam34 = 2
	}

	[Serializable]
	public class MapAssetInfo
	{
		public string path;

		public TextAsset asset;

		public eMapExtension mapExtension;

		public string mapVersion;

		[HideInInspector]
		public MapResource[] mapResources;

		[HideInInspector]
		public string[] mapResourceMachines;

		public MapAssetInfo(string path, TextAsset asset)
		{
		}
	}

	[Flags]
	public enum GetBlendResult
	{
		NotFound = 0,
		Success = 2,
		WrongMachine = 4
	}

	public class WriterInitialUpgrade
	{
		public eStageId stageId;

		public eWriterId id;

		public (eMachine, int)[] inventories;

		public (eAttachment, string[])[] attachments;
	}

	public enum eCursorSet
	{
		Default = 0,
		Ruler = 1,
		Camera = 2
	}

	[Serializable]
	public class CursorSet
	{
		public eCursorSet id;

		public Texture2D texture;

		public Vector2 hotspot;
	}

	public ExtMachineData[] extMachineData;

	public DTileBase2[] dTileBases;

	public DTileBase2[] pipeTiles;

	public DTileBase2[] pipeInkLevelTiles;

	public DTileBase2[] pipeFunnelTiles;

	[FormerlySerializedAs("uvTileBases")]
	public UvAnimationTile[] uvAnimationTiles;

	private Dictionary<string, UvAnimationTile[]> _uvAnimationTilesMap;

	private static DTileBase2 _portTile;

	private static DTileBase2 _routeGuideTile;

	private static DTileBase2 _portGuideTileProduct;

	private static DTileBase2 _portGuideTilePipe;

	private static DTileBase2 _portGuideTileConveyer;

	private static DTileBase2 _bubbleIconCautionTile;

	private static DTileBase2 _bubbleIconSettingMenuTile;

	private static DTileBase2[] _jamIconTiles;

	private static DTileBase2[] _jamInkIconTiles;

	private static DTileBase2[] _mixColorNormalAnimationTiles;

	public TileBase[] tileBases;

	public static readonly string MapAssetPath;

	public MapAssetInfo[] mapAssets;

	public MstLuggageData mstLuggageData;

	private Dictionary<eLuggage, MstLuggageDataEntities> _mstLuggageDataEntitiesMap;

	public MstLuggageTag mstLuggageTagData;

	public MstBlendData mstBlendData;

	private Dictionary<ExtBlendKey, List<MstBlendDataEntities>> _mstBlendDataEntitiesMap;

	public MstLuggageAbilityData mstLuggageAbilityData;

	private Dictionary<eLuggage, MstLuggageAbilityDataEntities[]> _mstLuggageAbilityDataEntitiesMap;

	public MstFactoryEffectData mstFactoryEffectData;

	private Dictionary<eFactoryEffectId, MstFactoryEffectDataEntities> _mstFactoryEffectDataEntitiesMap;

	public MstBattleData mstBattleData;

	public MstBattleInfoData mstBattleInfoData;

	private List<MstBattleInfoDataEntities> _targetStageBattleInfoData;

	public MstWaveGroupData mstWaveGroupData;

	public MstEnemyData mstEnemyData;

	public MstExpData mstExpData;

	public MstMachineData mstMachineData;

	private Dictionary<eMachine, MstMachineDataEntities> mstMachineDataEntitiesMap;

	public MstPrimaryMachineCategory mstPrimaryMachineCategory;

	public MstSecondaryMachineCategory mstSecondaryMachineCategory;

	public MstPaletteCategory mstPaletteCategory;

	public MstGuideCategory mstGuideCategory;

	public MstMouseOverDetailCategory mstMouseOverDetailCategory;

	public MstMachineDescSpecTextType mstMachineDescSpecTextType;

	public MstUnitData mstUnitData;

	public MstUnitSizeData mstUnitSizeData;

	public MstUnitRaceData mstUnitRaceData;

	public MstUnitAttackType mstUnitAttackType;

	public MstUnitActionType mstUnitActionType;

	public MstSpellActionType mstSpellActionType;

	public MstUnitRank mstUnitRank;

	public MstEnemyChoiceData mstEnemyChoiceData;

	public MstEnemyLevel mstEnemyLevel;

	public MstSpawnGroupLabel mstSpawnGroupLabel;

	public MstEnemySpawnPosition mstEnemySpawnPosition;

	public MstWriterData mstWriterData;

	private WriterInitialUpgrade[] writerInitialUpgrades;

	public MstShopData mstShopData;

	public MstUpgrade mstUpgrade;

	public MstUpgradeKind mstUpgradeKind;

	public MstUpgradePack mstUpgradePack;

	public MstSoundGroup mstSoundGroup;

	private Dictionary<eSoundGroupId, MstSoundGroupEntities> _mstSoundGroupMap;

	public MstMachineSound mstMachineSound;

	public MstUnitSound mstUnitSound;

	public MstEnemySound mstEnemySound;

	public MstSpellSound mstSpellSound;

	public MstAttachment mstAttachment;

	public MstMachineQuantity mstMachineQuantity;

	public MstArchiveData mstArchiveData;

	public MstInitialArchiveData mstInitialArchiveData;

	public MstChallengeData mstChallengeData;

	public MstRelicData mstRelicData;

	public MstRelicRarityData mstRelicRarityData;

	public MstAscensionData mstAscensionData;

	public MstRouteEventData mstRouteEventData;

	public MstRouteEvent mstRouteEvent;

	public MstReleaseNote mstReleaseNote;

	public MstReleaseNoteSwitch mstReleaseNoteSwitch;

	public MstReleaseNotePS mstReleaseNotePs;

	public MstReleaseNoteXbox mstReleaseNoteXbox;

	public MstResearchCategory mstResearchCategory;

	private static int _researchMax;

	public MstResearchCollectionCategory mstResearchCollectionCategory;

	public MstResearchTreeData mstResearchTree;

	public MstOutGameShop mstOutGameShop;

	private static int _outShopItemMax;

	public MstRouteEventChoice mstRouteEventChoice;

	public MstErrorText mstErrorText;

	public MstTutorial mstTutorial;

	public MstConfirmTitle mstConfirmTitle;

	public MstTips mstTips;

	public MstLargeTips mstLargeTips;

	public MstAvatorTalk mstAvatorTalk;

	public MstStaffroll mstStaffroll;

	public MstCredit mstCredit;

	public MstEndroll mstEndroll;

	public MstMasterMemo mstMasterMemo;

	public MstMasterMemoMessage mstMasterMemoMessage;

	public MstMessage mstMessage;

	public MstKeyword mstKeyword;

	public MstResultComment mstResultComment;

	public MstMiracleData mstMiracle;

	public MstPoint mstPoint;

	public MstTutorialSection mstTutorialSection;

	public MstGameAction mstGameAction;

	public MstGameActionSpriteFont mstGameActionSpriteFont;

	public MstFeatureData mstFeature;

	public MstScoreRank mstScoreRank;

	public MstScoreRecord mstScoreRecord;

	public MstUnlockData mstUnlock;

	public MstSteamAchiveData mstSteamAchive;

	public MstOrdealData mstOrdealData;

	public MstOrdealWisdomData mstOrdealWisdomData;

	private Dictionary<eLuggage, eMachine> statueLuggageToMachine;

	[SerializeField]
	[FormerlySerializedAs("LuggageSettings")]
	private LuggageSettings luggageSettings;

	[SerializeField]
	[FormerlySerializedAs("CameraSettings")]
	private FactoryCameraSettings cameraSettings;

	[SerializeField]
	[FormerlySerializedAs("FactorySettings")]
	private FactorySettings factorySettings;

	[SerializeField]
	private StructurePaletteSettings structurePaletteSettings;

	[SerializeField]
	private MiscSettings miscSettings;

	[SerializeField]
	[FormerlySerializedAs("WaveSetting")]
	private WaveInfoData waveSettings;

	[SerializeField]
	[FormerlySerializedAs("CustomRuleSetting")]
	private CustomRuleSetting customRuleSettings;

	[SerializeField]
	[FormerlySerializedAs("GateSetting")]
	private GateSettings gateSettings;

	[SerializeField]
	[FormerlySerializedAs("RewardSetting")]
	private RewardSetting rewardSettings;

	[SerializeField]
	[FormerlySerializedAs("TutorialSetting")]
	private TutorialSetting tutorialSettings;

	[SerializeField]
	[FormerlySerializedAs("UISetting")]
	private UISetting uiSettings;

	[SerializeField]
	private PostProcessSetting postProcessSetting;

	[SerializeField]
	[FormerlySerializedAs("PaletteSettings")]
	private PaletteSettings paletteSettings;

	[SerializeField]
	[FormerlySerializedAs("OutGameShopSettings")]
	private OutGameShopSettings outGameShopSettings;

	[SerializeField]
	[FormerlySerializedAs("InGameShopSettings")]
	private InGameShopSettings inGameShopSettings;

	[SerializeField]
	[FormerlySerializedAs("OptionSettings")]
	private OptionSettings optionSettings;

	[SerializeField]
	[FormerlySerializedAs("AudioSettings")]
	private AudioSettings audioSettings;

	[SerializeField]
	[FormerlySerializedAs("CollectionSettings")]
	private CollectionSettings collectionSettings;

	[SerializeField]
	[FormerlySerializedAs("StaffrollSettings")]
	private StaffrollSettings staffrollSettings;

	[SerializeField]
	[FormerlySerializedAs("ScoreSetting")]
	private ScoreSetting scoreSetting;

	[SerializeField]
	[FormerlySerializedAs("InGameScaleSetting")]
	private InGameScaleSetting scaleSetting;

	[SerializeField]
	private PS5Settings ps5Settings;

	public CursorSet[] cursorSets;

	public Image DefaultCursorPrefab;

	public Texture2D BlankCursorTexture;

	public GameObject EventSystem;

	public static Dictionary<eLuggage, MstLuggageDataEntities> GetMstLuggageDataEntitiesMap => null;

	public static int ResearchMax => 0;

	public static int OutShopItemMax => 0;

	public static LuggageSettings GetLuggageSettings => null;

	public static FactoryCameraSettings GetFactoryCameraSettings => null;

	public static FactorySettings GetFactorySettings => null;

	public static StructurePaletteSettings GetStructurePaletteSettings => null;

	public static MiscSettings GetMiscSettings => null;

	public static WaveInfoData GetWaveSettings => null;

	public static float GetTargetPlatformManaIncrease => 0f;

	public static CustomRuleSetting GetCustomRuleSetting => null;

	public static GateSettings GetGateSetting => null;

	public static RewardSetting GetRewardSetting => null;

	public static TutorialSetting GetTutorialSetting => null;

	public static UISetting GetUISetting => null;

	public static PostProcessSetting GetPostProcessSetting => null;

	public static PaletteSettings GetPaletteSettings => null;

	public static OutGameShopSettings GetOutGameShopSettings => null;

	public static InGameShopSettings GetInGameShopSettings => null;

	public static OptionSettings GetOptionSettings => null;

	public static AudioSettings GetAudioSettings => null;

	public static CollectionSettings GetCollectionSettings => null;

	public static StaffrollSettings GetStaffrollSettings => null;

	public static ScoreSetting GetScoreSetting => null;

	public static InGameScaleSetting GetScaleSetting => null;

	public static PS5Settings GetPS5Settings => null;

	public static ExtMachineData GetExtMachineData(eMachine machineID)
	{
		return null;
	}

	public static DTileBase2 GetDTileBase(string name)
	{
		return null;
	}

	private UvAnimationTile[] GetUvAnimationTiles(string n)
	{
		return null;
	}

	public static UvAnimationTile[] GetUvAnimationTile(string name)
	{
		return null;
	}

	public static DTileBase2 GetPortTile()
	{
		return null;
	}

	public static DTileBase2 GetRouteGuideTile()
	{
		return null;
	}

	public static DTileBase2 GetPortGuideProductTile()
	{
		return null;
	}

	public static DTileBase2 GetPortGuidePipeTile()
	{
		return null;
	}

	public static DTileBase2 GetPortGuideConveyerTile()
	{
		return null;
	}

	public static DTileBase2 GetBubbleIconCautionTile()
	{
		return null;
	}

	public static DTileBase2 GetSettingMenuBubbleIconTile()
	{
		return null;
	}

	public static DTileBase2 GetJamIconTile(JamIconStatus status)
	{
		return null;
	}

	public static DTileBase2 GetJamInkIconTile(JamIconStatus status)
	{
		return null;
	}

	public static DTileBase2 GetMixColorNormalAnimationTile(eLuggage color)
	{
		return null;
	}

	public static TileBase GetTileBase(string name)
	{
		return null;
	}

	public static MapAssetInfo CreateMapAssetInfo(ScriptableObjectReader ins, string path, TextAsset asset)
	{
		return null;
	}

	public static MapAsset[] GetMapAssets(string writerPath, eMapExtension mapExtension = eMapExtension.Area5)
	{
		return null;
	}

	public static TextAsset GetMapTextAssetDirect(string mapPath)
	{
		return null;
	}

	public static MapAssetInfo GetMapAsset(string path, eMapExtension mapExtension)
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetLuggageDataJaStrings()
	{
		return null;
	}

	public static MstLuggageDataEntities GetLuggageDataEntities(eLuggage eLuggage)
	{
		return null;
	}

	public static List<eLuggage> GetLuggageList(eLuggageKind eLuggageKind)
	{
		return null;
	}

	public static List<eLuggage> GetLuggageByManualLuggageTag(List<string> luggageTags)
	{
		return null;
	}

	public static (GetBlendResult, MstBlendDataEntities) GetBlendData(eSecondaryMachineCategory secondaryMachineCategory, params eLuggage[] args)
	{
		return default((GetBlendResult, MstBlendDataEntities));
	}

	public static List<eLuggage> GetIntoBlendMaterialUnits(eLuggage luggage)
	{
		return null;
	}

	public static void GetSourceLuggage(ref List<eLuggage> sourcesLuggage, eLuggage target, int level, bool distinct = true)
	{
	}

	public static MstBlendDataEntities GetBlendDataEntities(eLuggage product)
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetLuggageAbilityDataJaStrings()
	{
		return null;
	}

	public static MstLuggageAbilityDataEntities[] GetLuggageAbilityDataEntities(eLuggage eLuggage)
	{
		return null;
	}

	public MstFactoryEffectDataEntities GetFactoryEffectDataEntities(eFactoryEffectId eFactoryEffectId)
	{
		return null;
	}

	public static MstBattleDataEntities GetBattleData(eStageId stageId)
	{
		return null;
	}

	public void SettingStage(eWaveGroup id)
	{
	}

	public static MstBattleInfoDataEntities GetBattleInfoData(int id)
	{
		return null;
	}

	public static MstBattleInfoDataEntities GetBattleInfoDataByWave(int wave)
	{
		return null;
	}

	public static int GetStartWaveCountInDivision(eWaveGroup waveGroup, eStageDivision division)
	{
		return 0;
	}

	public static int AdditionalBattleInfoData(eWaveGroup waveGroup)
	{
		return 0;
	}

	public static void OverwriteBattleInfo(eWaveGroup waveGroup, List<eStageDivision> divisions)
	{
	}

	public static List<MstBattleInfoDataEntities> GetBattleInfoPlayAll()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetEnemyDataNameJaStrings()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetEnemyDataDescJaStrings()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetEnemyDataCollectionDescJaStrings()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetEnemyDataFlavorTextJaStrings()
	{
		return null;
	}

	public static MstEnemyDataEntities GetEnemyData(eEnemy enemy)
	{
		return null;
	}

	public static List<MstEnemyDataEntities> GetEnemiesDataByEnemyType(eEnemyType enemyType)
	{
		return null;
	}

	public static MstExpDataEntities GetExpDataNow(int exp)
	{
		return null;
	}

	public static MstExpDataEntities GetExpData(int level)
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetMachineDataNameJaStrings()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetMachineDataDescJaStrings()
	{
		return null;
	}

	public static MstMachineDataEntities GetMachineData(eMachine machine)
	{
		return null;
	}

	public static MstMachineDataEntities[] GetMachineDataByPrimaryMachineCategory(ePrimaryMachineCategory primaryCategory)
	{
		return null;
	}

	public static MstMachineDataEntities[] GetMachineDataBySecondaryMachineCategory(eSecondaryMachineCategory secondaryCategory)
	{
		return null;
	}

	public static eMachine[] SearchMachinesByRarity(int rarity)
	{
		return null;
	}

	public static eMachine[] SearchMachinesByRarityAndUnlockLevel(int rarity, int level)
	{
		return null;
	}

	public static eMachine[] SearchMachinesByUnlockLevelAndGetCountInfinity(int unlockLevel)
	{
		return null;
	}

	public static eMachine[] SearchMachinesByGetCountFinite()
	{
		return null;
	}

	public static eMachine[] SearchMachinesByUseMachine()
	{
		return null;
	}

	public static MstPrimaryMachineCategoryEntities GetPrimaryMachineCategory(ePrimaryMachineCategory cate)
	{
		return null;
	}

	public static MstSecondaryMachineCategoryEntities GetSecondaryMachineCategoryEntities(eSecondaryMachineCategory cate)
	{
		return null;
	}

	public static MstPaletteCategoryEntities GetPaletteCategory(ePaletteCategory cate)
	{
		return null;
	}

	public static MstGuideCategoryEntities GetMstGuideCategoryEntities(eGuideCategory id)
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetGuideCategoryDataJaStrings()
	{
		return null;
	}

	public static MstMouseOverDetailCategoryEntities GetMouseOverDetailCategoryEntities(eMouseOverDetailCategory cat)
	{
		return null;
	}

	public static MstMachineDescSpecTextTypeEntities GetMachineDescSpecTextTypeEntities(eMachineDescSpecTextType type)
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetUnitDataNameJaStrings()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetUnitDataActionDescJaStrings()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetUnitDataFlavorTextJaStrings()
	{
		return null;
	}

	public static MstUnitDataEntities GetUnitData(eUnit unit)
	{
		return null;
	}

	public static MstUnitDataEntities GetUnitData(eLuggage luggage)
	{
		return null;
	}

	public static MstUnitDataEntities[] GetActivateUnitDataEntities()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetUnitSizeDataJaStrings()
	{
		return null;
	}

	public static string GetSizeName(eUnitSize id)
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetUnitRaceDataJaStrings()
	{
		return null;
	}

	public static string GetRaceName(eUnitRace id)
	{
		return null;
	}

	public static MstUnitAttackTypeEntities GetAttackTypeDataById(eUnitAttackType id)
	{
		return null;
	}

	public static MstUnitActionTypeEntities GetActionTypeDataById(eUnitActionType id)
	{
		return null;
	}

	public static MstSpellActionTypeEntities GetSpellActionTypeDataById(eSpellActionType id)
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetUnitActionTypeDataNameJaStrings()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetSpellActionTypeDataNameJaStrings()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetUnitAttackTypeDataNameJaStrings()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetUnitActionTypeDataDescJaStrings()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetUnitAttackTypeDataDescJaStrings()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetSpellActionTypeDataDescJaStrings()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetUnitRankDataJaStrings()
	{
		return null;
	}

	public static string GetRankName(eUnitRank id)
	{
		return null;
	}

	public static MstEnemyChoiceDataEntities GetMstEnemyChoiceDataEntities(int id)
	{
		return null;
	}

	public static List<MstEnemyChoiceDataEntities> FindEnemyChoiceDataByTierId(eWaveTierId tier)
	{
		return null;
	}

	public static MstEnemyLevelEntities GetMstEnemyLevelEntities(eStageDivision division, int level, eEnemy id)
	{
		return null;
	}

	public static MstSpawnGroupLabelEntities GetMstSpawnGroupLabelEntities(eSpawnGroupLabel id)
	{
		return null;
	}

	public static MstEnemySpawnPositionEntities GetMstEnemySpawnPositionEntities(eSpawnPositionId id)
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetWriterDataNameJaStrings()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetWriterDataAbilityDescJaStrings()
	{
		return null;
	}

	public static MstWriterDataEntities GetMstWriterDataEntities(eWriterId id)
	{
		return null;
	}

	public static WriterInitialUpgrade GetWriterInitialUpgrade(eStageId stageId, eWriterId id = eWriterId.None)
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetShopDataJaStrings()
	{
		return null;
	}

	public static List<MstShopDataEntities> GetMstShopDataAll()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetUpgradeDataJaStrings()
	{
		return null;
	}

	public static MstUpgradeEntities GetMstUpgradeDataById(eUpgradeId id)
	{
		return null;
	}

	public static MstUpgradeKindEntities GetUpgradeKindDataById(eUpgradeKind id)
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetUpgradePackDataJaStrings()
	{
		return null;
	}

	public static MstUpgradePackEntities GetMstUpgradePackById(eUpgradePack id)
	{
		return null;
	}

	public static MstSoundGroupEntities GetMstSoundGroupDataById(eSoundGroupId id)
	{
		return null;
	}

	public static MstSoundGroupEntities GetMstSoundGroupDataByGroupName(string groupName)
	{
		return null;
	}

	public static MstSoundGroupEntities GetMstSoundGroupDataByCategoryAndGroupName(eSoundGroupCategory category, string groupName)
	{
		return null;
	}

	public static MstMachineSoundEntities GetMstMachineSoundDataByMachineIdAndActionType(eMachine machine, eMachineSoundActionType actionType)
	{
		return null;
	}

	public static List<MstMachineSoundEntities> GetMstMachineSoundDataListByMachineIdAndActionType(eMachine machine, eMachineSoundActionType actionType)
	{
		return null;
	}

	public static MstUnitSoundEntities GetMstUnitSoundDataByUnitIdAndActionType(eUnit unit, eUnitSoundActionType actionType)
	{
		return null;
	}

	public static List<MstUnitSoundEntities> GetMstUnitSoundDataListByUnitIdAndActionType(eUnit unit, eUnitSoundActionType actionType)
	{
		return null;
	}

	public static MstEnemySoundEntities GetMstEnemySoundDataByEneymIdAndEnemyTypeAndActionType(eEnemy enemy, eEnemyType enemyType, eEnemySoundActionType actionType)
	{
		return null;
	}

	public static List<MstEnemySoundEntities> GetMstEnemySoundDataListByEnemyIdAndEnemyTypeAndActionType(eEnemy enemy, eEnemyType enemyType, eEnemySoundActionType actionType)
	{
		return null;
	}

	public static MstSpellSoundEntities GetMstSpellSoundDataByMiracleIdAndActionType(eMiracle miracle, eSpellSoundActionType actionType)
	{
		return null;
	}

	public static List<MstSpellSoundEntities> GetMstSpellSoundDataListByMiracleIdAndActionType(eMiracle miracle, eSpellSoundActionType actionType)
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetAttachmentDataJaStrings()
	{
		return null;
	}

	public static MstAttachmentEntities GetMstAttachmentDataById(eAttachment id)
	{
		return null;
	}

	public static MstMachineQuantityEntities GetMstMachineQuantityByMachine(eMachine machine)
	{
		return null;
	}

	public static MstArchiveDataEntities GetMstArchiveDataById(eArchive id)
	{
		return null;
	}

	public static List<MstInitialArchiveDataEntities> GetMstInitialArchiveDataAll()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetChallengeDataNameJaStrings()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetChallengeDataDescJaStrings()
	{
		return null;
	}

	public static MstChallengeDataEntities GetMstChallengeDataById(eChallengeId id)
	{
		return null;
	}

	public static List<MstChallengeDataEntities> GetMstChallengeDataAll()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetRelicDataNameJaStrings()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetRelicDataDescJaStrings()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetRelicDataReleaseConditionMessageJaStrings()
	{
		return null;
	}

	public static List<MstRelicDataEntities> GetMstRelicDataAll()
	{
		return null;
	}

	public static MstRelicDataEntities GetMstRelicDataById(eRelic id)
	{
		return null;
	}

	public static MstRelicRarityDataEntities GetMstRelicRarityData(eRelicRarity id)
	{
		return null;
	}

	public static List<MstAscensionDataEntities> GetMstAscensionsByBelowLevel(int ascensionLevel)
	{
		return null;
	}

	public static MstAscensionDataEntities GetMstAscensionsByLevel(int ascensionLevel)
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetAscensionDataDescJaStrings()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetAscensionDataToDescJaStrings()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetRouteEventDataDescDataJaStrings()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetRouteEventDataNameDataJaStrings()
	{
		return null;
	}

	public static MstRouteEventDataEntities GetMstRouteEventDataEntitiesById(int id)
	{
		return null;
	}

	public static List<MstRouteEventDataEntities> GetMstRouteEventsByIdAndStageDivision(eRouteEvent id, eStageDivision division, bool endress = false)
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetRouteEventNameDataJaStrings()
	{
		return null;
	}

	public static MstRouteEventEntities GetMstRouteEventById(eRouteEvent id)
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetReleaseNoteJaStrings()
	{
		return null;
	}

	public static List<MstReleaseNoteEntities> GetReleaseNote(int limit = -1)
	{
		return null;
	}

	public static List<MstReleaseNoteSwitchEntities> GetReleaseNoteSwitch(int limit = -1)
	{
		return null;
	}

	public static List<MstReleaseNotePSEntities> GetReleaseNotePs(int limit = -1)
	{
		return null;
	}

	public static List<MstReleaseNoteXboxEntities> GetReleaseNoteXbox(int limit = -1)
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetResearchCategoryDataNameJaStrings()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetResearchCategoryDataOverviewJaStrings()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetResearchCategoryDataReleaseConditionMessageJaStrings()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetResearchCollectionCategoryDataDescJaStrings()
	{
		return null;
	}

	public static MstResearchCollectionCategoryEntities GetMstResearchCollectionCategoryEntities(eResearchCollectionCategory id)
	{
		return null;
	}

	public static MstResearchCategoryEntities GetMstResearchCategoryEntities(eResearchCategory id)
	{
		return null;
	}

	public static List<MstResearchCategoryEntities> GetMstResearchCategoriesByWriterId(eWriterId writer)
	{
		return null;
	}

	public static List<MstResearchCategoryEntities> GetMstResearchCategoriesByWriterIdAndResearchCategoryType(eWriterId writer, eResearchCategoryType type)
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetResearchTreeDataJaStrings()
	{
		return null;
	}

	public static List<MstResearchTreeDataEntities> GetMstResearchTreeEntities(eResearchCategory id)
	{
		return null;
	}

	public static MstResearchTreeDataEntities GetMstResearchTreeById(eResearchTreeId id)
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetOutGameShopDataJaStrings()
	{
		return null;
	}

	public static MstOutGameShopEntities GetOutGameShopEntities(eOutGameShopId id)
	{
		return null;
	}

	public static MstOutGameShopEntities GetOutGameShopEntitiesWithUpdateId(eOutGameShopId id)
	{
		return null;
	}

	public static List<eOutGameShopId> GetOutGameShopIdsByUseChallenge()
	{
		return null;
	}

	public static List<MstOutGameShopEntities> GetOutGameShopIdsByIsConsumption()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetRouteEventChoiceDataJaStrings()
	{
		return null;
	}

	public static MstRouteEventChoiceEntities GetMstRouteEventChoice(eRouteEventChoice id)
	{
		return null;
	}

	public static MstErrorTextEntities GetMstErrorTextEntities(eErrorId id)
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetErrorDataJaStrings()
	{
		return null;
	}

	public static MstTutorialEntities GetMstTutorialEntities(eTutorialId id)
	{
		return null;
	}

	public static MstConfirmTitleEntities GetMstConfirmTitleEntities(eConfirmId id, params object[] args)
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetConfirmDataJaStrings()
	{
		return null;
	}

	public static MstTipsEntities GetMstTipsEntities(eTipsId id)
	{
		return null;
	}

	public static MstLargeTipsEntities GetMstLargeTipsEntities(eLargeTips id)
	{
		return null;
	}

	public static MstAvatorTalkEntities GetMstAvatorTalkEntities(eAvatorTalk id)
	{
		return null;
	}

	public static List<MstAvatorTalkEntities> GetMstAvatorTalkEntitiesByAvatorTalkScene(eAvatorTalkScene scene)
	{
		return null;
	}

	public static MstStaffrollEntities GetMstStaffrollEntity(eStaffroll id)
	{
		return null;
	}

	public static List<MstCreditEntities> GetMstCreditAll()
	{
		return null;
	}

	public static List<MstEndrollEntities> GetMstEndrollAll()
	{
		return null;
	}

	public static MstMasterMemoEntities GetMstMasterMemoEntities(eMasterMemo id)
	{
		return null;
	}

	public static MstMasterMemoMessageEntities GetMstMasterMemoMessageEntities(eMasterMemoMessage id)
	{
		return null;
	}

	public static List<MstMasterMemoMessageEntities> GetMstMasterMemoMessageEntitiesByMasterMemo(eMasterMemo memo)
	{
		return null;
	}

	public static MstMessageEntities GetMstMessageEntities(eMessageId id, params object[] args)
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetMessageDataJaStrings()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetKeywordJaStrings()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetTutorialDataJaStrings()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetTipsDataJaStrings()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetLargeTipsDataJaStrings()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetAvatorTalkDataJaStrings()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetMasterMemoMessageDataJaStrings()
	{
		return null;
	}

	public static MstResultCommentEntities GetMstResultCommentEntities(eResultComment id)
	{
		return null;
	}

	public static List<MstResultCommentEntities> GetMstResultCommentBySpecial(bool isSpecial)
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GeResultCommentDataJaStrings()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetMiracleDataNameJaStrings()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetMiracleDataDescJaStrings()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetMiracleDataFlavorTextJaStrings()
	{
		return null;
	}

	public static MstMiracleDataEntities GetMstMiracleDataById(eMiracle id)
	{
		return null;
	}

	public static MstPointEntities GetMstPointDataById(ePointType id)
	{
		return null;
	}

	public static List<MstTutorialSectionEntities> GetAllTutorialSectionDatas()
	{
		return null;
	}

	public static MstTutorialSectionEntities GetMstTutorialSectionDataById(eTutorialSectionId id)
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetTutorialSectionDataJaStrings()
	{
		return null;
	}

	public static List<MstGameActionEntities> GetMstGameActionAll(bool? isController = null)
	{
		return null;
	}

	public static List<MstGameActionEntities> GetMstGameActionByActionMap(string actionMapName)
	{
		return null;
	}

	public static MstGameActionEntities GetMstGameActionByActionMapAndAction(string actionMapName, string actionName, bool isController = false)
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetGameActionDataJaStrings()
	{
		return null;
	}

	public static List<MstGameActionSpriteFontEntities> GetMstGameActionSpriteFontAll()
	{
		return null;
	}

	public static List<MstGameActionSpriteFontEntities> GetMstGameActionSpriteFontByInputType(string inputType)
	{
		return null;
	}

	public static MstGameActionSpriteFontEntities GetMstGameActionSpriteFont(eGameActionSpriteFont id)
	{
		return null;
	}

	public static MstGameActionSpriteFontEntities GetMstGameActionSpriteFontByInputTypeAndInput(string inputType, string input)
	{
		return null;
	}

	public static MstGameActionSpriteFont GetMstGameActionSpriteFont()
	{
		return null;
	}

	public static MstFeatureDataEntities GetMstFeatureDataById(eFeatureId id)
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetFeatureDataJaStrings()
	{
		return null;
	}

	public static List<MstScoreRankEntities> GetMstScoreRankByStageId(eStageId id)
	{
		return null;
	}

	public static MstScoreRankEntities GetMstScoreRankDataTop(eStageId stageId, int score)
	{
		return null;
	}

	public static List<MstScoreRankEntities> GetMstScoreRankDataMoreAll(eStageId stageId, int score)
	{
		return null;
	}

	public static MstScoreRecordEntities GetMstScoreRecord(eScoreRecord id)
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetScoreRecordDataJaStrings()
	{
		return null;
	}

	public static List<MstScoreRecordEntities> GetScoreRecordDataByCalcLastWave(bool calcLast)
	{
		return null;
	}

	public static ICommonEntiies GetCommonData(eArchiveCategory category, string archiveId)
	{
		return null;
	}

	public static MstShopDataEntities GetLocalizedShopDataEntities(eShopId shopId)
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetUnlockDataJaStrings()
	{
		return null;
	}

	public static MstUnlockDataEntities GetMstUnlockData(eUnlockId unlockId)
	{
		return null;
	}

	public static MstUnlockDataEntities GetMstUnlockData(eWriterId writer, eStageDivision division)
	{
		return null;
	}

	public static List<MstUnlockDataEntities> GetMstUnlockDataAll()
	{
		return null;
	}

	public static MstSteamAchiveDataEntities GetMstSteamAchiveData(eSteamAchivementId id)
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetSteamAchievementJaStrings()
	{
		return null;
	}

	public static MstOrdealDataEntities GetOrdealDataByKey(eLastBattleKey key)
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetOrdealDataJaStrings()
	{
		return null;
	}

	public static MstOrdealWisdomDataEntities GetOrdealWisdomById(eOrdealWisdom id)
	{
		return null;
	}

	public static List<MstOrdealWisdomDataEntities> GetMstOrdealWisdomDataAll()
	{
		return null;
	}

	public Dictionary<ILocalizeTextStringKey, string> GetOrdealWisdomJaStrings()
	{
		return null;
	}

	private eMachine getStatueMachine(eLuggage luggage)
	{
		return default(eMachine);
	}

	public static eMachine GetStatueMachine(eLuggage luggage)
	{
		return default(eMachine);
	}

	private bool isBecomeStatue(eLuggage luggage)
	{
		return false;
	}

	public static bool IsBecomeStatue(eLuggage luggage)
	{
		return false;
	}

	public void ChangeCursor(eCursorSet id)
	{
	}

	public void Init()
	{
	}

	public WriterInitialUpgrade[] InitWriteInitialUpgrades()
	{
		return null;
	}
}
