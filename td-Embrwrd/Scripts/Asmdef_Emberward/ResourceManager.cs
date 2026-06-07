using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : Singleton<ResourceManager>
{
	[SerializeField]
	[Header("怪物資料")]
	private List<MonsterSettingData> list_MonsterSettingData;

	private Dictionary<eMonsterType, MonsterSettingData> dic_MonsterSettingData;

	[SerializeField]
	[Header("道具資料")]
	private List<AItemSettingData> list_ItemSettingData;

	private Dictionary<eItemType, AItemSettingData> dic_ItemSettingData;

	private List<eItemType> list_TowerItemTypes;

	private List<TowerSettingData> list_TowerSettingData;

	private List<eItemType> list_PanelItemTypes;

	private List<PanelSettingData> list_PanelSettingData;

	private List<eItemType> list_BuffItemTypes;

	private List<ABaseBuffSettingData> list_BuffSettingData;

	private List<eItemType> list_RelicItemTypes;

	private List<RelicSettingData> list_RelicSettingData;

	private List<eItemType> list_RuneItemTypes;

	private List<RuneSettingData> list_RuneSettingData;

	private List<eItemType> list_GearItemTypes;

	private List<GearSettingData> list_GearSettingData;

	private List<eItemType> list_PerkItemTypes;

	private List<PerkSettingData> list_PerkSettingData;

	private List<CharacterSettingData> list_characterSettingData;

	private bool isInitialized;

	private List<eDamageType> list_TowerDamageTypeLimit;

	protected override void Awake()
	{
	}

	private void Initialize()
	{
	}

	public MonsterSettingData GetMonsterDataByType(eMonsterType type)
	{
		return null;
	}

	public List<MonsterSettingData> GetAllMonsterData()
	{
		return null;
	}

	public List<MonsterSettingData> GetMonsterDataByWorld(eWorldType type)
	{
		return null;
	}

	public ABaseTower CreateTower(TowerSettingData data)
	{
		return null;
	}

	public List<eItemType> GetRandomItemType(int count, List<eItemType> availableItems, bool preventDuplicate)
	{
		return null;
	}

	public void SetTowerDamageTypeLimit(List<eDamageType> list_Limit)
	{
	}

	public void ResetTowerDamageTypeLimit()
	{
	}

	public List<TowerSettingData> GetAllTowerSettingData()
	{
		return null;
	}

	public List<eItemType> GetAllTowerItemType()
	{
		return null;
	}

	public TowerSettingData GetTowerDataByType(eItemType type)
	{
		return null;
	}

	public int GetUnobtaintedTowerCount()
	{
		return 0;
	}

	public List<TowerSettingData> GetRandomTowerSettingData(int count, bool preventPlayerObtained, bool isForPurchase, bool higherWeightFor2x2, bool includeUtilityTower = true, bool includeBuildLimitTower = false, bool onlyCollectedTower = false, List<eItemType> list_Exclude = null, List<eDamageType> list_LimitDamageType = null)
	{
		return null;
	}

	public List<TowerSettingData> GetRandomTowerSettingDatasWithSize(int count, eTowerSizeType size, bool preventPlayerObtained, bool includeUtilityTower, bool includeBuildLimitTower = true, List<eItemType> list_Exclude = null)
	{
		return null;
	}

	public TowerSettingData GetRandomTowerSettingDataWithSize(eTowerSizeType size, bool preventPlayerObtained, bool includeUtilityTower, bool includeBuildLimitTower = true, List<eItemType> list_Exclude = null)
	{
		return null;
	}

	public List<eItemType> GetRandomTowerType(int count, bool preventDuplicate)
	{
		return null;
	}

	public List<TowerSettingData> GetRandomTowerWithTargetType(bool isMultiTarget, eTowerSizeType sizeLimit, int count, bool includeUtilityTower, bool includeBuildLimitTower = false, List<eItemType> list_Exclude = null)
	{
		return null;
	}

	public List<TowerSettingData> GetRandomTowerWithSize(eTowerSizeType allowSize, int count, bool includeUtilityTower, bool preventPlayerObtained, bool includeBuildLimitTower = true, List<eItemType> list_Exclude = null)
	{
		return null;
	}

	public List<TowerSettingData> GetRandomTowerWithSize(List<eTowerSizeType> allowSize, int count, bool includeUtilityTower, bool preventPlayerObtained, bool includeBuildLimitTower = true, List<eItemType> list_Exclude = null)
	{
		return null;
	}

	public List<TowerSettingData> GetTowersWithGridCount(List<int> allowGridCount, int count, bool includeUtilityTower, bool preventPlayerObtained, bool includeBuildLimitTower = true, bool onlyCollectedTower = false, List<eItemType> list_Exclude = null)
	{
		return null;
	}

	public List<TowerSettingData> GetRandomTowerWithTier(eTowerTier tier, int count, List<eItemType> list_Exclude = null)
	{
		return null;
	}

	public List<PanelSettingData> GetAllPanelSettingData()
	{
		return null;
	}

	public PanelSettingData GetPanelDataByType(eItemType type)
	{
		return null;
	}

	public PanelSettingData GetRandomPanelSettingData()
	{
		return null;
	}

	public PanelSettingData GetRandomPanelSettingDataWithSizeLimit(int minBlockCount, int maxBlockCount)
	{
		return null;
	}

	public PanelSettingData GetRandomPanelSettingDataWithSize(int blockCount, bool includeTwisted = false)
	{
		return null;
	}

	public List<eItemType> GetRandomPanelType(int count, bool preventDuplicate)
	{
		return null;
	}

	public PanelSettingData GetPanelSettingDataForTwistedVersion(int blockCount)
	{
		return null;
	}

	public List<PanelSettingData> GetPanelSettingDataForWorkshopModify(eItemType originItemType, int blockCount)
	{
		return null;
	}

	public List<ABaseBuffSettingData> GetRandomBuffSettingDataForStore(int count, List<eItemType> list_Exclude = null)
	{
		return null;
	}

	public List<eItemType> GetRandomBuffType(int count, bool preventDuplicate)
	{
		return null;
	}

	public int GetAvailableRelicCount(List<eItemType> list_Exclude = null, bool isInAcademic = false, bool doLimitEffectType = false, List<eRelicEffectType> limitedEffectTypes = null)
	{
		return 0;
	}

	public List<RelicSettingData> GetRandomRelicSettingDataForStore(int count, List<eItemType> list_Exclude = null, bool isInAcademic = false, bool doLimitEffectType = false, List<eRelicEffectType> limitedEffectTypes = null, List<eDamageType> limitedDamagedTypes = null)
	{
		return null;
	}

	public List<eItemType> GetRandomRelicType(int count, bool preventDuplicate)
	{
		return null;
	}

	public List<eItemType> GetAllRelicItemType()
	{
		return null;
	}

	public List<RelicSettingData> GetAllRelicSettingData()
	{
		return null;
	}

	public List<RuneSettingData> GetRandomRuneSettingDataForStore(int count, List<eItemType> list_Exclude = null)
	{
		return null;
	}

	public List<RuneSettingData> GetRandomRuneSettingDataForReward(int count, List<eItemType> list_Exclude = null)
	{
		return null;
	}

	public RuneSettingData GetRuneSettingDataByType(eItemType type)
	{
		return null;
	}

	public List<eItemType> GetRandomRuneType(int count, bool preventDuplicate)
	{
		return null;
	}

	public List<eItemType> GetAllRuneItemType()
	{
		return null;
	}

	public List<RuneSettingData> GetAllRuneSettingData()
	{
		return null;
	}

	public List<GearSettingData> GetRandomGears(int count)
	{
		return null;
	}

	public List<PerkSettingData> GetRandomPerksForEndlessMode(int count, ePerkType perkType, ePerkScenario perkScenario, List<eItemType> list_Exclude = null)
	{
		return null;
	}

	public List<PerkSettingData> GetRandomPerksForRogueliteMap(int count, int step, ePerkType perkType, ePerkScenario perkScenario, List<ePerkCategory> excludeCategory = null, List<eItemType> list_Exclude = null)
	{
		return null;
	}

	public PerkSettingData GetPerkSettingDataByType(eItemType type)
	{
		return null;
	}

	public List<PerkSettingData> GetPositiveAnomalyForEndlessMode(int count, int seed)
	{
		return null;
	}

	public List<PerkSettingData> GetNegativeAnomalyForEndlessMode(int count, int seed)
	{
		return null;
	}

	public bool IsHaveItemData(eItemType type)
	{
		return false;
	}

	public AItemSettingData GetItemDataByType(eItemType type)
	{
		return null;
	}

	public CharacterSettingData GetCharacterDataByType(eCharacterType type)
	{
		return null;
	}

	public List<AcademyCardSetData> GetAcademyCardSetData()
	{
		return null;
	}

	private AcademyCardSetData ToAcademyCardSetData(List<TowerSettingData> list_Towers, List<TetrisCardData> list_Tetris)
	{
		return null;
	}

	public List<AcademyCardSetData> RerollAcademyCardSetData(List<AcademyCardSetData> originalData, int rerollIndex)
	{
		return null;
	}
}
