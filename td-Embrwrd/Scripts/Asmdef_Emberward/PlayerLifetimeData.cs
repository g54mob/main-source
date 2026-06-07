using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerLifetimeData
{
	[SerializeField]
	private int exp;

	[SerializeField]
	private int academyRerollCount;

	[SerializeField]
	private int lifetimeExpEarned;

	[SerializeField]
	private TalentData talentData;

	public List<eTalentType> list_LearnedTalent;

	[SerializeField]
	private List<eTutorialType> list_FinishedTutorial;

	[SerializeField]
	private List<eItemType> list_BuiltTowerRecord;

	[SerializeField]
	private List<eItemType> list_SeenTowerRecord;

	[SerializeField]
	private List<eItemType> list_UnlockedRelics;

	[SerializeField]
	private List<eItemType> list_SeenRelics;

	[SerializeField]
	[Header("已跳過解鎖通知的角色")]
	private List<eCharacterType> list_NotifiedUnlockedCharacters;

	[SerializeField]
	[Header("已跳過解鎖通知的火焰")]
	private List<eEmberType> list_NotifiedUnlockedEmbers;

	[Header("已跳過解鎖通知的額外獎勵")]
	[SerializeField]
	private List<eExtraRewardType> list_NotifiedExtraRewards;

	[SerializeField]
	private eWorldType lastChaosRealmBossWorldType;

	public bool isEventRegistered;

	public bool isSeenGameIntro;

	public bool isDefeatedCasualModeBoss;

	public bool isDefeatedNormalModeBoss;

	public bool isDefeatedHeroicModeBoss;

	[SerializeField]
	private bool isTutorialStageFinished;

	[SerializeField]
	private PlayerRecord playerRecord;

	[SerializeField]
	private StageRecord stageRecord;

	[SerializeField]
	private MiscRecord miscRecord;

	public int Exp => 0;

	public int AcademyRerollCount => 0;

	public TalentData TalentData => null;

	public eWorldType LastChaosRealmBossWorldType => default(eWorldType);

	public bool IsTutorialStageFinished => false;

	public PlayerRecord PlayerRecord => null;

	public StageRecord StageRecord => null;

	public MiscRecord MiscRecord => null;

	public void RegisterEvents()
	{
	}

	public void ClearEvents()
	{
	}

	private void CheckData()
	{
	}

	public bool IsCharacterNeedUnlockNotify(eCharacterType type)
	{
		return false;
	}

	public void RecordCharacterUnlockNotify(eCharacterType type)
	{
	}

	public bool IsEmberNeedUnlockNotify(eEmberType type)
	{
		return false;
	}

	public void RecordEmberUnlockNotify(eEmberType type)
	{
	}

	public bool IsExtraRewardNeedUnlockNotify(eExtraRewardType type)
	{
		return false;
	}

	public void RecordExtraRewardUnlockNotify(eExtraRewardType type)
	{
	}

	public void ResetTutorialState()
	{
	}

	public void RemoveTutorialState(eTutorialType type)
	{
	}

	private void OnRequestAddExp(int value)
	{
	}

	private void OnRequestSetExp(int value)
	{
	}

	private void OnRequestAddAcademyRerollCount(int value)
	{
	}

	private void OnRequestLearnTalent(eTalentType type, bool doSave)
	{
	}

	public bool IsTalentLearned(eTalentType type)
	{
		return false;
	}

	public int GetLearnedTalentCount_AnyLevel()
	{
		return 0;
	}

	public int GetLearnedTalentCount_FullOnly()
	{
		return 0;
	}

	public bool IsAllTalentsLearned()
	{
		return false;
	}

	private void OnRequestResetTalent()
	{
	}

	private void OnRequestSetTutorialStageCompleted()
	{
	}

	private void OnFinishedTutorial(eTutorialType type)
	{
	}

	public bool IsFinishedTutorial(eTutorialType type)
	{
		return false;
	}

	public bool IsWorldUnlocked(eGameDifficultyType difficulty, eWorldType worldType)
	{
		return false;
	}

	public bool IsWorldUnlockedInAnyDifficulty(eWorldType worldType)
	{
		return false;
	}

	public bool IsWorldCleared(eGameDifficultyType difficulty, eWorldType worldType)
	{
		return false;
	}

	public bool IsWorldClearedInAnyDifficulty(eWorldType worldType)
	{
		return false;
	}

	public bool IsRogueliteModeCustomGameUnlocked(eGameDifficultyType difficulty)
	{
		return false;
	}

	public bool IsAcademyRerollUnlocked()
	{
		return false;
	}

	public bool IsInfiniteAcademyRerollUnlocked()
	{
		return false;
	}

	public bool IsInfernoShardSystemUnlocked(eGameDifficultyType difficulty)
	{
		return false;
	}

	public bool IsInfernoShardSystemUnlockedInAnyDifficulty()
	{
		return false;
	}

	public bool IsInfernoShardLevelUnlockedInAnyDifficulty(int level)
	{
		return false;
	}

	public bool IsInfernoShardLevelUnlocked(eGameDifficultyType difficulty, int level)
	{
		return false;
	}

	public bool IsWorldImplemented(eWorldType worldType)
	{
		return false;
	}

	public bool IsCharacterImplemented(eCharacterType type)
	{
		return false;
	}

	public bool IsSpecialEventCharacter(eCharacterType type)
	{
		return false;
	}

	public bool IsCharacterUnlocked(eCharacterType type)
	{
		return false;
	}

	public int GetCharacterUnlockRequirementValue(eCharacterType character)
	{
		return 0;
	}

	public bool IsEmberImplemented(eEmberType type)
	{
		return false;
	}

	public bool IsEmberUnlocked(eEmberType type)
	{
		return false;
	}

	public bool IsAnomalyLevelUnlocked()
	{
		return false;
	}

	public bool IsDarknessLevelUnlocked()
	{
		return false;
	}

	public bool DoSpawnDarknessLevel()
	{
		return false;
	}

	public bool IsEndlessDailyChallengeUnlocked()
	{
		return false;
	}

	public bool IsEndlessWeeklyChallengeUnlocked()
	{
		return false;
	}

	public bool IsEnigmaSanctumUnlocked()
	{
		return false;
	}

	private void OnRequestRecordTowerBuilt(eItemType itemType)
	{
	}

	private void OnRequestRecordSeenTowerCard(eItemType itemType)
	{
	}

	private void RecordSeenTowerCard(eItemType itemType)
	{
	}

	public bool IsTowerBuiltInRecord(eItemType itemType)
	{
		return false;
	}

	public int GetTowerBuildRecordCount()
	{
		return 0;
	}

	public bool IsTowerSeenInRecord(eItemType itemType)
	{
		return false;
	}

	private void OnRequestAddRelic(eItemType type)
	{
	}

	public int GetUnlockedRelicCount()
	{
		return 0;
	}

	private void OnRequestRecordSeenRelic(eItemType type)
	{
	}

	private void RecordSeenRelic(eItemType type)
	{
	}

	public bool IsRelicUnlocked(eItemType type)
	{
		return false;
	}

	public bool IsRelicSeen(eItemType type)
	{
		return false;
	}

	public void CheckAllCharacterUnlockAchievement()
	{
	}

	public void CheckCharacterUnlockAchievement(eCharacterType character)
	{
	}
}
