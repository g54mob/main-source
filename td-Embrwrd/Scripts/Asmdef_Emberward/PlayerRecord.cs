using System;
using UnityEngine;

[Serializable]
public class PlayerRecord
{
	[SerializeField]
	private long gamesPlayed;

	[SerializeField]
	private long gamesPerfectWin;

	[SerializeField]
	private long gamesWin;

	[SerializeField]
	private long gamesLost;

	[SerializeField]
	private long highestInfernoShardLevel_Casual;

	[SerializeField]
	private long highestInfernoShardLevel_Normal;

	[SerializeField]
	private long highestInfernoShardLevel_Heroic;

	[SerializeField]
	private long winStreak;

	[SerializeField]
	private long maxWinStreak;

	[SerializeField]
	private long clearedLevels;

	[SerializeField]
	private long clearedNormalLevels;

	[SerializeField]
	private long clearedCorruptedLevels;

	[SerializeField]
	private long clearedVariantLevels;

	[SerializeField]
	private long clearedDarknessLevels;

	[SerializeField]
	private long questCompleted;

	[SerializeField]
	private long rerollCount;

	[SerializeField]
	private long enemiesKilled;

	[SerializeField]
	private long eliteKills;

	[SerializeField]
	private long bossKills;

	[SerializeField]
	private long towerBuilt;

	[SerializeField]
	private long towerBuilt_1x1;

	[SerializeField]
	private long towerBuilt_2x2;

	[SerializeField]
	private long towerBuilt_Other;

	[SerializeField]
	private long blockBuilt;

	[SerializeField]
	private long totalCollectedCoins;

	[SerializeField]
	private long totalSpentCoins;

	[SerializeField]
	private long totalEmberStone;

	[SerializeField]
	private long totalExperience;

	[SerializeField]
	private long totalTreasureChestOpened;

	[SerializeField]
	private long totalDamageTaken;

	[SerializeField]
	private long totalDamageDealt;

	[SerializeField]
	private long normalDamage;

	[SerializeField]
	private long fireDamage;

	[SerializeField]
	private long frostDamage;

	[SerializeField]
	private long electricDamage;

	[SerializeField]
	private long poisonDamage;

	[SerializeField]
	private long arcaneDamage;

	[SerializeField]
	private long coinFromGoldenMonster;

	public long GamesPlayed => 0L;

	public long GamesPerfectWin => 0L;

	public long GamesWin => 0L;

	public long GamesLost => 0L;

	public long HighestInfernoShardLevel_Casual => 0L;

	public long HighestInfernoShardLevel_Normal => 0L;

	public long HighestInfernoShardLevel_Heroic => 0L;

	public long WinStreak => 0L;

	public long MaxWinStreak => 0L;

	public long ClearedLevels => 0L;

	public long ClearedNormalLevels => 0L;

	public long ClearedCorruptedLevels => 0L;

	public long ClearedVariantLevels => 0L;

	public long ClearedDarknessLevels => 0L;

	public long QuestCompleted => 0L;

	public long RerollCount => 0L;

	public long EnemiesKilled => 0L;

	public long EliteKills => 0L;

	public long BossKills => 0L;

	public long TowerBuilt => 0L;

	public long TowerBuilt_1x1 => 0L;

	public long TowerBuilt_2x2 => 0L;

	public long TowerBuilt_Other => 0L;

	public long BlockBuilt => 0L;

	public long TotalCollectedCoins => 0L;

	public long TotalSpentCoins => 0L;

	public long TotalEmberStone => 0L;

	public long TotalExperience => 0L;

	public long TotalTreasureChestOpened => 0L;

	public long TotalDamageTaken => 0L;

	public long TotalDamageDealt => 0L;

	public long NormalDamage => 0L;

	public long FireDamage => 0L;

	public long FrostDamage => 0L;

	public long ElectricDamage => 0L;

	public long PoisonDamage => 0L;

	public long ArcaneDamage => 0L;

	public long CoinFromGoldenMonster => 0L;

	public void UpdateGameRecords(int winStreak)
	{
	}

	private bool IsCustomGame()
	{
		return false;
	}

	public void AddGamesPlayed(int value)
	{
	}

	public void AddGamesWin(int value, bool isPerfectWin)
	{
	}

	public void AddGamesLost(int value)
	{
	}

	public bool AddWinStreak()
	{
		return false;
	}

	public void ResetWinStreak()
	{
	}

	public void SetHighestInfernoShardLevel(long level, eGameDifficultyType difficulty)
	{
	}

	public long GetHighestInfernoShardLevel(eGameDifficultyType difficulty)
	{
		return 0L;
	}

	public void AddClearedLevels(int value)
	{
	}

	public void AddClearedNormalLevels(int value)
	{
	}

	public void AddClearedCorruptedLevels(int value)
	{
	}

	public void AddClearedVariantLevels(int value)
	{
	}

	public void AddClearedDarknessLevels(int value)
	{
	}

	private void RecordCorruptLevelAchievement()
	{
	}

	private void RecordDarknessLevelAchievement()
	{
	}

	public void AddRerollCount(int value)
	{
	}

	public void AddQuestCompleted(int value)
	{
	}

	public void AddEnemiesKilled(int value)
	{
	}

	public void AddEliteKills(int value)
	{
	}

	public void AddBossKills(int value)
	{
	}

	public void AddTowerBuilt(int value)
	{
	}

	public void AddTowerBuilt_1x1(int value)
	{
	}

	public void AddTowerBuilt_2x2(int value)
	{
	}

	public void AddTowerBuilt_Other(int value)
	{
	}

	public void AddBlockBuilt(int value)
	{
	}

	public void AddTotalCollectedCoins(int value)
	{
	}

	public void AddTotalSpentCoins(int value)
	{
	}

	public void AddTotalEmberStone(int value)
	{
	}

	public void AddTotalExperience(int value)
	{
	}

	public void SetTotalExperience(int value)
	{
	}

	public void AddTotalTreasureChestOpened(int value)
	{
	}

	public void AddTotalDamageTaken(int value)
	{
	}

	public void AddTotalDamageDealt(int value)
	{
	}

	public void AddNormalDamage(int value)
	{
	}

	public void AddFireDamage(int value)
	{
	}

	public void AddFrostDamage(int value)
	{
	}

	public void AddElectricDamage(int value)
	{
	}

	public void AddPoisonDamage(int value)
	{
	}

	public void AddArcaneDamage(int value)
	{
	}

	public void AddCoinFromGoldenMonster(int value)
	{
	}
}
