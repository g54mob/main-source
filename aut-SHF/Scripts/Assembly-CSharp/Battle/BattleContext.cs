using System;
using System.Collections.Generic;
using System.Diagnostics;
using Factory.FieldData;
using Libs;
using SaveData;
using UI;
using UnityEngine;

namespace Battle
{
	[Serializable]
	public class BattleContext
	{
		private bool? _prohibitedScrollExpansion;

		private bool? _noLevelUp;

		private bool? _finishWaveAllEliminate;

		private bool? _restartNamed;

		private bool? _scoreMode;

		private bool? _enableEndless;

		private bool? _enableLastBattle;

		private const eLastBattleKey All = eLastBattleKey.PowerKey | eLastBattleKey.SpiritKey | eLastBattleKey.WisdomKey;

		private double _battleReciprocalSpeed;

		public int DebugSlowBattleTimeScale;

		private double _cacheSpeedGear;

		private double _nowSpeedGear;

		private bool _isSystemPause;

		private bool _isButtonPause;

		public const string ButtonPauseTag = "ButtonPause";

		private float _longthinkTimeScale;

		private int _longthinkHealCount;

		private List<HpLuggageAbility> _hpAbilityEffect;

		public Dictionary<eLuggage, double> SallyHeroNextTime;

		public List<eLuggage> OutputClickSpellList;

		public ReactiveProperty<bool> AutoMiracle;

		private int _researchPointLimit;

		private int _researchPointRedLimit;

		private int _keenLimit;

		private float _manaIncrease;

		private float _attchmentManaIncrease;

		private MstExpDataEntities _nextLevetExpData;

		public PlayBattleData BattleData => null;

		public BuffSet<ePlayerBuff> PlayerBuff => null;

		public Dictionary<eEnemy, BuffSet<eEnemyBuff>> EnemiesBuff => null;

		public eStageId PlayStage
		{
			get
			{
				return default(eStageId);
			}
			set
			{
			}
		}

		public MstBattleDataEntities StageData { get; private set; }

		public MstBattleInfoDataEntities NowBattleInfoData { get; set; }

		public bool ProhibitedScrollExpansion => false;

		public bool NoLevelUp => false;

		public bool FinishWaveAllEliminate => false;

		public bool RestartNamed => false;

		public bool ScoreMode => false;

		public bool IsNewRecord { get; set; }

		public bool EnableEndless => false;

		public bool EnableLastBattle => false;

		public bool IsEndless => false;

		public int MaxWaveCount { get; set; }

		public bool IsLastBattle => false;

		public eLastBattleKey LastBattleKey
		{
			get
			{
				return default(eLastBattleKey);
			}
			set
			{
			}
		}

		public bool PassLastBattle => false;

		public eOrdealWisdom SelectedWisdomOrdealId
		{
			get
			{
				return default(eOrdealWisdom);
			}
			set
			{
			}
		}

		public eStageDivision NextStageCache { get; set; }

		public int ClearWaveCount { get; set; }

		public bool ClearCheck => false;

		public eClearState ClearState
		{
			get
			{
				return default(eClearState);
			}
			set
			{
			}
		}

		public bool IsClear => false;

		public DateTime PlayBeginDate
		{
			get
			{
				return default(DateTime);
			}
			set
			{
			}
		}

		public DateTime PlayEndDate
		{
			get
			{
				return default(DateTime);
			}
			set
			{
			}
		}

		public bool IsUseableChuchuhouse
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public List<eUnlockId> waitUnlockDirectionIds
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool AscensionUp
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public double CurrentTime => 0.0;

		public double BattleDeltaTime { get; set; }

		public double NextSwitchTime
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double WaveTime { get; set; }

		public double TimeRate => 0.0;

		public double CountDownTime => 0.0;

		public bool OverNextSwitchTime => false;

		public double OverTimeCounter { get; set; }

		public int BattleRandomSeed
		{
			get
			{
				return 0;
			}
			private set
			{
			}
		}

		public double CacheSpeedGear
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double NowSpeedGear
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public float NowTimeScale => 0f;

		public bool IsPause => false;

		public bool IsSystemPause => false;

		public List<eStageDivision> StageDivisionList => null;

		public int PlayDivisionUseIndex => 0;

		public int ClearDivision
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public List<string> SelectedNodeId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public List<ChoiceRouteCtrl.RouteNode> RouteList
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public List<ChoiceRouteCtrl.RouteBranch> BranchList
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public eRouteEvent ProcessingEvent
		{
			get
			{
				return default(eRouteEvent);
			}
			set
			{
			}
		}

		public SRandom RewardRandom => null;

		public ePhase Phase
		{
			get
			{
				return default(ePhase);
			}
			set
			{
			}
		}

		public bool OnStandby
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsChoicePhase => false;

		public int WaveCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool IsLongthink { get; set; }

		public bool IsLongthinkStandby { get; set; }

		public int LongthinkTimeCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int LongthinkMaxCount => 0;

		public float LongthinkTimeScale => 0f;

		public int LongthinkHealCount => 0;

		public double RemainLongThinkTime
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double ChargeLongThinkTime
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double GetLongThinkChargeGoalTime => 0.0;

		public int CurrentHp
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		private int MaxHp
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int GetMaxHp => 0;

		public bool InvincibleGate { get; set; }

		public bool IsImmortal { get; set; }

		public List<BaseUnit> BattleUnits { get; set; }

		public Dictionary<eLuggage, PlayUnlockData> PlayUnitInfo => null;

		public bool ExistSanctuary { get; private set; }

		public List<BaseBullet> BattleBullets { get; set; }

		public List<BaseMiracle> BattleMiracles { get; set; }

		public List<BaseEnemy> BattleEnemies { get; set; }

		public List<BaseEnemy> StandbyEnemy { get; set; }

		public List<EnemyCluster> EnemyCluster { get; set; }

		public Dictionary<eEnemy, GameObject> EnemyObject { get; set; }

		public Dictionary<eEnemy, MstEnemyDataEntities> MstEnemyData { get; set; }

		public Dictionary<eEnemy, MstEnemyLevelEntities> WaveBattleSetting { get; private set; }

		public bool IsLastBossWave => false;

		public float DifficultyIncrease
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public List<int> AddNamedToBossStage
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public List<int> AdditionalEnemyPool
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float GameDifficulty => 0f;

		public float DebugGameDifficulty { get; set; }

		public HashSet<ePointType> LimitlessPoint { get; private set; }

		public Dictionary<ePointType, int> CompleteRemoveMachineBonusPoint { get; private set; }

		public bool IsEnableCompleteRemoveMachine => false;

		public int GreenResearch
		{
			get
			{
				return 0;
			}
			private set
			{
			}
		}

		public int GreenResearchLimit => 0;

		private List<UseToGetPoint> UseGreenToGetPoint
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int RedResearch
		{
			get
			{
				return 0;
			}
			private set
			{
			}
		}

		public int RedResearchLimit => 0;

		public int Keen
		{
			get
			{
				return 0;
			}
			private set
			{
			}
		}

		public int KeenLimit => 0;

		public int MachineCostPool1
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int MachineCostPool2
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float MachineCostPool1Remain
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float ManaPerSecond => 0f;

		public int MachineCostPool1Limit => 0;

		public int MachineCostPool2Limit => 0;

		public int ReturnMana
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public List<PriceRevision> StandbyPriceRevision => null;

		public int FreeReloadCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int SelectedHeroInfoIdx
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool HeroInfoAutoMode
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public HashSet<eUpgradePack> MultipleChoicePack { get; private set; }

		public Dictionary<eUpgradePack, int> ReloadablePack { get; private set; }

		public bool EnableChageFactoryReload
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool EnableFirstResearchReload
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public List<eRouteEvent> FirstPulsEvent
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public List<WaveLog> HistoryList
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public WaveLog NowWaveLog => null;

		public List<string> GetHasRelics => null;

		public List<eRelic> GetUsedRelics => null;

		public List<string> GetHasUnits => null;

		public List<string> GetHasResearches => null;

		public List<WaveLog.SelectedHappeningData> GetHasHappening => null;

		public int GetReceiveDamage => 0;

		public List<eOrdealWisdom> GetSkipOrdealKnowledges => null;

		public int GetScoreAll => 0;

		public List<ShopData> ShopData
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int BattleLevel
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public MstExpDataEntities NextLevelExpData => null;

		public int NextNeedExp => 0;

		public int MaxLevel { get; private set; }

		public bool IsMaxLevel => false;

		public int BattleExp
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool CheckLevelUp => false;

		private bool IsNextLevelRareReward { get; set; }

		public Dictionary<eResearchCategory, PlayResearchTreeDataGroup> PlayResearchTreeDatas => null;

		public List<eLargeTips> waitLargeTipsList { get; set; }

		public List<MiracleInfo> MiracleInfos
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int SelectedMiracleIdx
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool NormalMiracleOk => false;

		public Dictionary<eEnemy, MstEnemyLevelEntities> DebugEnemySetting { get; set; }

		public bool CustomBattleMode { get; set; }

		public bool EndressWait { get; set; }

		public bool EndlessWaveMode { get; set; }

		public int BattleLoopCount { get; set; }

		public bool SpawnEnemyOk { get; set; }

		public bool IsOpenInGameShop { get; set; }

		public bool AchieveCheckOk => false;

		public float GetPlayerBuffPoint(ePlayerBuff buffType, float value)
		{
			return 0f;
		}

		public bool TryGetPassiveData(eUpgradeKind id, out List<BattlePassiveData> result)
		{
			result = null;
			return false;
		}

		public bool TryGetPassiveLastData(eUpgradeKind id, out BattlePassiveData result)
		{
			result = null;
			return false;
		}

		public bool HasPassiveData(eUpgradeKind id)
		{
			return false;
		}

		public void GetOrdealKey(eLastBattleKey key)
		{
		}

		public bool CheckOrdealPowerBattle()
		{
			return false;
		}

		public void CountUpSpiritEnergy()
		{
		}

		public int GetNeedSpritEnergy(FactoryContext.AltarOfSpiritType alterType)
		{
			return 0;
		}

		public void UseableChuchuhouse(bool on = true)
		{
		}

		public void UpdateBattleTime(bool isPause)
		{
		}

		public void SkipWaitTime(double remainTime)
		{
		}

		public void SystemPause(bool? isProhibitFactory = null)
		{
		}

		public void ReleaseSystemPause()
		{
		}

		public void ButtonPause()
		{
		}

		public void ReleaseButtonPause()
		{
		}

		private void ChangeSequenceGear(double newGear)
		{
		}

		public void ChangeSpeedGear(double gear)
		{
		}

		public void ChangeBattleSpeedGear(double speedGear)
		{
		}

		public eStageDivision PlayDivision()
		{
			return default(eStageDivision);
		}

		public bool IntoPlayStageDivision(eStageDivision target)
		{
			return false;
		}

		public bool TryGetLastStage(out eStageDivision nowStage)
		{
			nowStage = default(eStageDivision);
			return false;
		}

		public void SetStageDivision()
		{
		}

		public void OverwriteWaveGroup(List<eStageDivision> divisionList)
		{
		}

		public ChoiceRouteCtrl.RouteNode NowRouteNode()
		{
			return null;
		}

		public void CountUpWave()
		{
		}

		private void RegisterHpAbility(List<string> param)
		{
		}

		public void CheckHpAbility(int remainHp)
		{
		}

		private void ResetHpAbility()
		{
		}

		public void CheckWaveStartPassive()
		{
		}

		public void DamageTown(int damagePoint, Vector3 hitPosition)
		{
		}

		public void HealTown(float healPercent, bool isLastStand = false)
		{
		}

		public void HealTown(int healPoint, bool isLastStand = false)
		{
		}

		public void CalcHp(int add, bool isLastStand = false)
		{
		}

		public void HealRest(float healPercent)
		{
		}

		public void DestroyAllBattleObjects<T>(List<T> battleObjects) where T : IBattleCycle
		{
		}

		[Conditional("UNITY_EDITOR")]
		[Conditional("DEVELOP_COMMAND")]
		public void DebugCheckExistAndAddLuggage(eLuggage luggage)
		{
		}

		public void SetParticipationHero(bool reCalcOutput = true)
		{
		}

		public void OverWriteParticipationHero(List<(eLuggage luggage, float overwriteValue)> luggageIntervals)
		{
		}

		public bool CheckOutuptHero(eLuggage luggage)
		{
			return false;
		}

		public void ExtendRecastTime(eLuggage luggage, double addTime, bool withLock = false)
		{
		}

		public void ResetSkill()
		{
		}

		public MstEnemyDataEntities GetEnemyData(eEnemy enemyType)
		{
			return null;
		}

		public GameObject GetEnemyObj(eEnemy enemyId)
		{
			return null;
		}

		public void RegisterEnemyPrefabAll()
		{
		}

		private void RegisterEnemyPrefab(eEnemy enemyType)
		{
		}

		public void SetWaveBattleEnemyLevelData(eEnemy key, MstEnemyLevelEntities levelData)
		{
		}

		private MstEnemyLevelEntities CheckEnemyBuff(MstEnemyLevelEntities entity)
		{
			return null;
		}

		public void SetBaseEnemyLevel(int wave)
		{
		}

		public List<(eEnemy, MstEnemyLevelEntities)> ConvertBattleFrequency(List<string> enemyLevel, eStageDivision division = eStageDivision.None)
		{
			return null;
		}

		public void AddBattleFrequency(eStageDivision division, int level, MstEnemyChoiceDataEntities entity)
		{
		}

		public void PreBattleEnemySetting()
		{
		}

		public void RegisterEliminatedWave()
		{
		}

		private void NamedEncountFirstNode()
		{
		}

		public int GetNowLevelEnemyData(eEnemy id)
		{
			return 0;
		}

		public List<MstEnemyChoiceDataEntities> GetEnemyPoolByWaveTier(eWaveTierId id)
		{
			return null;
		}

		public void ReAddNowMainEnemy()
		{
		}

		private void AddLimitlessPoint(params ePointType[] points)
		{
		}

		public bool IsLimitlessPoint(ePointType point)
		{
			return false;
		}

		private void AddCompleteRemovePoint(List<(ePointType, int)> bonusPoint)
		{
		}

		public void GetCompleteRemoveMachineBonusPoint()
		{
		}

		private void CheckUseToGetPoint(List<UseToGetPoint> pointList, int usePoint)
		{
		}

		public void AddGreenResearch(int moneyPoint, bool countUpAnimation = false, bool isDialogUpdate = true)
		{
		}

		public void AddRedResearch(int point, bool countUpAnimation = false, bool isDialogUpdate = true)
		{
		}

		public void AddKeen(int keen, bool countUpAnimation = false)
		{
		}

		public void CustomCheckCost(ref int point, ePointType type)
		{
		}

		private float GetAttachmentManaIncrease()
		{
			return 0f;
		}

		public void UpdateManaIncrease()
		{
		}

		public void AddMoneyMachineCostPool(int _poolNum, int _addmachineMoney, bool countUpAnimation = false)
		{
		}

		public void AddMoneyMachineCostPool(int machineMoney)
		{
		}

		private void CalcActuallyUseMana(int machineValue)
		{
		}

		private bool CheckInfinitCostMode(ePointType type)
		{
			return false;
		}

		public string GenerateSkipBonusText(List<(ePointType, int)> skipBonus)
		{
			return null;
		}

		private void AddMultipleChoicePack(List<eUpgradePack> itemList)
		{
		}

		private void AddReloadablePack(List<(eUpgradePack, int)> itemList)
		{
		}

		public WaveLog GetHistoryByWave(int wave)
		{
			return null;
		}

		public bool HasItem(eArchiveCategory category, string id)
		{
			return false;
		}

		public void SaveStartWaveHistory()
		{
		}

		public void UnlockShopItem(eShopId id)
		{
		}

		public void AddExp(int value)
		{
		}

		public void LevelUp()
		{
		}

		public void RegisterLevelupAbility(List<string> param)
		{
		}

		public void CheckLevelupAbility()
		{
		}

		public void Init(eWriterId writerId, eStageId stageId, int acensionLevel, bool freeControlMode)
		{
		}

		private void ApplyConvertResearches(MstBattleDataEntities battleData)
		{
		}

		private void ApplyOutGameShopForUnlockPermanent(MstBattleDataEntities battleData)
		{
		}

		private void ApplyOutGameShop(MstBattleDataEntities battleData)
		{
		}

		private void ApplyAscension(MstBattleDataEntities battleData)
		{
		}

		public void ApplyAscension(int debugAscension)
		{
		}

		public void UpdateUnits()
		{
		}

		public void UpdateBullets()
		{
		}

		public void UpdateMiracles()
		{
		}

		public void UpdateEnemies()
		{
		}

		public void RemoveFromBattleList()
		{
		}

		public void UpdateCluster()
		{
		}

		public void EnableSpawnFilterAll(float minAngle, float maxAngle)
		{
		}

		public void DesableSpawnFilterAll()
		{
		}

		private void SavePassive((eUpgradeKind, List<string>) effectset, eArchiveCategory category, string id, bool withPassive = true)
		{
		}

		private void LoadPassive()
		{
		}

		public void PassiveEffect((eUpgradeKind, List<string>) effectset, eArchiveCategory sourceCategory = eArchiveCategory.None, string sourceId = "")
		{
		}

		private void AllMapExtend()
		{
		}

		private void ExchangeRouteEvent(eRouteEvent from, eRouteEvent to)
		{
		}

		public void MachineSpecificationCost(eMachine machine, int value)
		{
		}

		public void MachineCostDown(eMachine machine, int value)
		{
		}

		public void MachineCostDown(eMachine machine, float value)
		{
		}

		private void CheckCostDown(eMachine machine)
		{
		}

		public void AddAnyPoint(ePointType point, int value, bool countUpAnimation = false)
		{
		}

		public int GetAnyPoint(ePointType point)
		{
			return 0;
		}

		public void IncreasePoint(ePointType point, float ratio)
		{
		}

		public void GetRouteBonusPoint(eRouteEvent eventType)
		{
		}

		private void ApplyFirstBuff()
		{
		}

		private void ApplyConsumptionBuff()
		{
		}

		public void RemovePlayOutGameShopData(eOutGameShopId removeId)
		{
		}

		public List<eLuggage> GetLuggageIdByLuggageTag(string targetTag)
		{
			return null;
		}

		private void ApplyAbilityEffectBuff(eAbilityEffectId effectId, float value, string tag, bool isBase, eArchiveCategory sourceCategory = eArchiveCategory.None, string sourceId = "")
		{
		}

		private void ApplyRelicBuff(eAbilityEffectId effectId, float value, eLuggage luggage, bool isBase, eArchiveCategory sourceCategory = eArchiveCategory.None, string sourceId = "")
		{
		}

		private void ApplyMiracleBuff(eAbilityEffectId effectId, float value, eMiracle miracle, bool isBase)
		{
		}

		public void GetMachine(eMachine machine, int value)
		{
		}

		private List<eMachine> GetMachineIdByResearchCategory(eResearchCategory category)
		{
			return null;
		}

		public eMachine GetRandomMotifOrInk(bool isMotif, eStageId stageId = eStageId.Main)
		{
			return default(eMachine);
		}

		public eMachine GetMotifStarOrHeart(eStageId stageId = eStageId.Main)
		{
			return default(eMachine);
		}

		public eMachine GetRandomStatue(eStageId stageId = eStageId.Main)
		{
			return default(eMachine);
		}

		public List<eMachine> GetRandomStatue(int count)
		{
			return null;
		}

		public void GetRelic(eRelic relic)
		{
		}

		public void GetOrdealKnowledge(eOrdealWisdom id)
		{
		}

		private void ApplyEnemyBuff(eEnemyBuff buff, float value, eEnemy enemy)
		{
		}

		private void ApplyEnemyBuff(eEnemyBuff buff, float value, eEnemyType[] enemyTypes)
		{
		}

		public void PermanentUnlock((eArchiveCategory, string) param)
		{
		}

		public void AchieveCheckCreateHero(eLuggage createLuggage)
		{
		}

		public void AchieveCheckAllUnlockResearch(eResearchCategory categoryId)
		{
		}

		public void AchieveCheckWaveClear(MstBattleInfoDataEntities entity)
		{
		}

		public void AchieveCheckClearGame()
		{
		}

		public void ChallengeAchiveCheckClearGame()
		{
		}

		private void InitialVersionProcess()
		{
		}

		public void DamageEnemies(eEnemyType type, int damage)
		{
		}

		public Dictionary<eUnitRank, List<(eLuggage, int)>> GetRankLuggageCount()
		{
			return null;
		}
	}
}
