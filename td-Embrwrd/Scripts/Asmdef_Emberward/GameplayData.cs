using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameplayData
{
	[Header("是否已初始化")]
	public bool isInitialized;

	[Header("是否是自訂遊戲")]
	public bool isCustomGame;

	[Header("玩家選擇的遊戲難度")]
	public eGameDifficultyType difficulty;

	[Header("玩家選擇的遊戲模式")]
	public eGameMode gameMode;

	[Header("這場遊戲的排行榜類型")]
	public eLeaderboardType LeaderboardType;

	[Header("這場遊戲的seed")]
	public int randomSeed;

	[Header("玩家選擇的角色")]
	public eCharacterType characterType;

	[Header("玩家選擇的火源類型")]
	public eEmberType emberType;

	public List<TowerIngameData> list_LoadoutTowerData;

	public List<TowerIngameData> list_CollectedTowerData;

	public List<CardData> list_ItemStorage;

	[Header("寶石")]
	[SerializeField]
	private int gem;

	[Header("重骰次數")]
	[SerializeField]
	private int rerollChance;

	[Header("復活次數")]
	[SerializeField]
	private int reviveItem;

	[Header("砲塔數量限制")]
	[SerializeField]
	private int towerCardLimit;

	[SerializeField]
	[Header("手牌數量限制")]
	private int itemCardLimit;

	[Header("每回合開始抽卡數")]
	[SerializeField]
	private int drawCardPerRound;

	[SerializeField]
	[Header("困難模式資料")]
	private HardModeSetting hardModeData;

	[SerializeField]
	[Header("是否已經開始")]
	private bool isGameStarted;

	[Header("是否已經GameOver")]
	[SerializeField]
	private bool isGameEnded;

	[SerializeField]
	[Header("目前在哪一大關")]
	private eWorldType curWorld;

	[Header("目前地圖節點")]
	[SerializeField]
	private int curMapStep;

	[SerializeField]
	[Header("目前地圖節點")]
	private int curMapNodeIndex;

	[Header("產生地圖的設定值")]
	public MapGenerateSetting mapGenerateSetting;

	[Header("目前地圖資料")]
	public MapData mapData;

	[Header("已經通過的關卡 (包含非戰鬥格)")]
	public List<eStageType> list_ClearedStageType;

	[Header("已經玩過的環境場景")]
	public List<string> list_PlayedEnvScene;

	[Header("目前HP")]
	[SerializeField]
	private int curHP;

	[SerializeField]
	[Header("最大HP")]
	private int maxHP;

	[Header("額外護盾")]
	[SerializeField]
	private int extraShield;

	[Header("持有神器")]
	[SerializeField]
	private List<eItemType> list_CollectedRelic;

	[Header("進行中的任務")]
	[SerializeField]
	private QuestData quest;

	[Header("進行中的祭壇契約")]
	[SerializeField]
	private List<AltarPactData> list_AltarPactData;

	[Header("上一關剩下的金幣")]
	[SerializeField]
	private int goldRemainLastLevel;

	[SerializeField]
	[Header("是否關閉計時器")]
	private bool turnOffTimer;

	[SerializeField]
	[Header("是否擁有皇家通行證天賦")]
	private bool isHaveRoyalPassTalent;

	[SerializeField]
	[Header("是否使用任何天賦 (成就追蹤用)")]
	private bool isHaveAnyTalent;

	[Header("選擇物品時的reroll次數")]
	[SerializeField]
	private int rerollCount;

	[Header("受到怪物傷害")]
	[SerializeField]
	private int damageTaken;

	[SerializeField]
	[Header("遊戲時間 (Scaled)")]
	private float totalTime_Scaled;

	[SerializeField]
	[Header("遊戲時間 (Unscaled)")]
	private float totalTime_Unscaled;

	[SerializeField]
	[Header("惡魔火焰等級")]
	private int demonFlameLevel;

	[SerializeField]
	private ScrapMasterData scrapMasterData;

	[SerializeField]
	private GameplayStats gameplayStats;

	public int MAX_DRAW_CARD_PER_ROUND;

	public int MAX_TOWER_CARD_LIMIT;

	[SerializeField]
	private string gameVersion;

	private bool isEventRegistered;

	public int Gem => 0;

	public int RerollChance => 0;

	public int ReviveItem => 0;

	public int TowerCardLimit => 0;

	public int ItemCardLimit => 0;

	public int DrawCardPerRound => 0;

	public HardModeSetting HardModeData => null;

	public bool IsGameStarted => false;

	public bool IsGameEnded => false;

	public eWorldType CurWorld => default(eWorldType);

	public int CurMapStep => 0;

	public int CurMapNodeIndex => 0;

	public int CurHP => 0;

	public int MaxHP => 0;

	public int ExtraShield => 0;

	public QuestData Quest => null;

	public List<AltarPactData> List_AltarPactData => null;

	public int GoldRemainLastLevel => 0;

	public bool TurnOffTimer => false;

	public bool IsHaveRoyalPassTalent => false;

	public bool IsHaveAnyTalent => false;

	public int DamageTaken => 0;

	public float TotalTime_Scaled => 0f;

	public float TotalTime_Unscaled => 0f;

	public int DemonFlameLevel => 0;

	public ScrapMasterData ScrapMasterData => null;

	public GameplayStats GameplayStats => null;

	public string GameVersion => null;

	public GameplayData(int seed, eWorldType worldType, eGameMode gameMode, eGameDifficultyType difficulty)
	{
	}

	public void InitializeHP()
	{
	}

	public void LoadDataProcess()
	{
	}

	public void RegisterEvents()
	{
	}

	public void ClearEvents()
	{
	}

	public void SetGameDifficulty(eGameDifficultyType difficulty)
	{
	}

	public bool IsGameDifficulty(eGameDifficultyType difficulty)
	{
		return false;
	}

	public void SetHardModeSetting(HardModeSetting data)
	{
	}

	public bool IsGameDifficultySameOrHigher(eGameDifficultyType difficulty)
	{
		return false;
	}

	public float GetBaseDifficultyMultiplier()
	{
		return 0f;
	}

	private void OnRequestOverrideMapMaxHP(int value)
	{
	}

	private void OnRequestOverrideMapHP(int value)
	{
	}

	private void OnRequestAddExtraShield(int value)
	{
	}

	private void OnRequestAddDrawCardCount(int value)
	{
	}

	private void OnRequestResetStorage()
	{
	}

	private void OnRequestAddCardToStorage(eItemType type)
	{
	}

	private void OnRequestAddTetrisCardToStorage(TetrisCardData data)
	{
	}

	private void AddCardToStorage(eItemType type)
	{
	}

	private void OnRequestRemoveCardFromStorage(CardData data)
	{
	}

	private void OnRequestOverrideStorage(List<CardData> list)
	{
	}

	public void SetWorld(eWorldType world)
	{
	}

	public void SetCurrentMapNodeIndex(int index)
	{
	}

	public void SetCurrentMapStep(int step)
	{
	}

	public int GetShopRerollCount()
	{
		return 0;
	}

	private void OnRequestAddGem(int value)
	{
	}

	private void OnRequestSetGem(int value)
	{
	}

	public int GetStartupRerollCount()
	{
		return 0;
	}

	private void OnRequestAddRerollCount(int value)
	{
	}

	private void OnRequestSetRerollCount(int value)
	{
	}

	private void OnRequestAddReviveCount(int value)
	{
	}

	private void OnRequestSetReviveCount(int value)
	{
	}

	private void OnRequestAddTowerCardLimit(int value)
	{
	}

	private void OnRequestAddItemCardLimit(int value)
	{
	}

	private void OnRequestClearAllTowerCard()
	{
	}

	private void OnRequestOverrideTowerLoadout(List<TowerIngameData> list_newLoadout)
	{
	}

	private void OnRequestAddTowerCard(TowerIngameData data)
	{
	}

	private void OnRequestRemoveTowerCard(eItemType type)
	{
	}

	private void OnRequestReplaceTowerCard(eItemType fromType, TowerIngameData newData)
	{
	}

	private void OnRequestLevelUpTowerCard(eItemType type, int targetLevel)
	{
	}

	public bool IsHaveTowerInCollected(eItemType itemType)
	{
		return false;
	}

	public bool IsTowerHaveLimitedBuildCount(eItemType itemType)
	{
		return false;
	}

	public int GetTowerBuildCountLimit(eItemType itemType)
	{
		return 0;
	}

	public bool IsHaveTowerInLoadout(eItemType itemType)
	{
		return false;
	}

	public bool IsHaveItemInStorage(eItemType itemType)
	{
		return false;
	}

	public int GetLoadoutTowerCount()
	{
		return 0;
	}

	public int GetLoadoutTowerCountBySize(eTowerSizeType sizeType)
	{
		return 0;
	}

	public List<TowerIngameData> GetLoadoutTowerList()
	{
		return null;
	}

	public List<TowerIngameData> GetCollectedTowerList()
	{
		return null;
	}

	public int GetRelicCount()
	{
		return 0;
	}

	public List<eItemType> GetCollectedRelicList()
	{
		return null;
	}

	public bool IsHaveRelic(eItemType itemType)
	{
		return false;
	}

	private void OnRequestAddRelic(eItemType type)
	{
	}

	private void OnRequestRemoveRelic(eItemType type)
	{
	}

	private void OnRequestRemoveAllRelic()
	{
	}

	private void OnRequestAddQuest(QuestData data)
	{
	}

	private void OnRequestRemoveQuest()
	{
	}

	private void OnRequestStartAltarPact(AltarPactData data)
	{
	}

	public bool IsAltarPactInProgress(eItemType perkEffect)
	{
		return false;
	}

	public bool IsAnyAltarPactInProgress()
	{
		return false;
	}

	public void ClearAllAltarPacts()
	{
	}

	private void OnRequestChangeCharacter(eCharacterType type)
	{
	}

	private void OnRequestChangeEmberType(eEmberType type)
	{
	}

	private void OnRequestSetDemonFlameLevel(int level)
	{
	}

	public void ClearGoldRemainLastLevel()
	{
	}

	public void AddGoldRemainLastLevel(int gold)
	{
	}

	public void SetGoldRemainLastLevel(int gold)
	{
	}

	public StageRewardData GetCurrentStageRewardData()
	{
		return null;
	}

	public float GetDifficultyExpMultiplier()
	{
		return 0f;
	}

	public bool IsGameInProgress()
	{
		return false;
	}

	public void SetGameStarted()
	{
	}

	public void SetGameEnded(bool doRecord)
	{
	}

	public bool IsHPFull()
	{
		return false;
	}

	public bool IsHaveTowerWithSizeInLoadout(eTowerSizeType towerSizeType)
	{
		return false;
	}

	public bool IsHaveTowerWithElementInLoadout(eDamageType damageType)
	{
		return false;
	}

	public bool IsHaveTowerWithSize(eTowerSizeType towerSizeType)
	{
		return false;
	}

	public void RecordPlayedScene(string name)
	{
	}

	public bool IsPlayedScene(string name)
	{
		return false;
	}

	public bool IsCharacterType(eCharacterType type)
	{
		return false;
	}

	public bool IsEmberType(eEmberType type)
	{
		return false;
	}

	public bool IsCustomGame()
	{
		return false;
	}

	private void OnMonsterDealDamageToPlayer(AMonsterBase monster, int damage, int hpDamage, int armorDamage)
	{
	}

	private void OnRequestAddScrapMasterExp(int value)
	{
	}

	public void AddTotalTime_Scaled(float time)
	{
	}

	public void AddTotalTime_Unscaled(float time)
	{
	}

	public List<eStageType> GetClearedMapNodeList()
	{
		return null;
	}

	public void RecordMapNodeCleared(eStageType stageType)
	{
	}

	public eStageType GetPreviousRecordedMapNode()
	{
		return default(eStageType);
	}

	public string GetVictoryStatsString()
	{
		return null;
	}

	public string GetGameTimeString_Scaled()
	{
		return null;
	}

	public string GetGameTimeString_Unscaled()
	{
		return null;
	}

	public string GetGameTimeString(float totalSeconds)
	{
		return null;
	}
}
