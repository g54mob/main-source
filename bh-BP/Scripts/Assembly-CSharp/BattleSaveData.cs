using System;
using System.Collections.Generic;

[Serializable]
public class BattleSaveData
{
	public static BattleSaveData I;

	public CharBattleInst CurChar;

	public LevelType CurLevel;

	public int CurDifficulty;

	public int CurNGPlusLvl;

	public List<HeroInst> Heroes;

	public int NumHeroesGotten;

	public List<PassiveInst> Passives;

	public List<PlayerStatusEffect> PlayerStatusEffects;

	public List<HeroCombo> IgnoredFusions;

	public int Seed;

	public int CurTurn;

	public int NumBossTurnsElapsed;

	public int NumFuserTurnsElapsed;

	public bool DidDropFuserBlueprint;

	public int NumTimesExpanded;

	public int NextObstacleTurn;

	public int NumBanishes;

	public List<UpgradeInfo> BanishedItems;

	public float LastBossTime;

	public float LastTurnTime;

	public float ElapsedTime;

	public float SkippedTime;

	public float ElapsedRealTime;

	public float PlayerX;

	public float CurHealth;

	public float CurXP;

	public int UpgradeLvl;

	public int NumLevelUpsAvail;

	public int NumFissionsDone;

	public int NumFissionUpgradesReceived;

	public int LastFissionCount;

	public int NumCombosFused;

	public int NumEvosFused;

	public Cost NumResources;

	public Cost PrevResources;

	public int NumTreasures;

	public int NumRevives;

	public bool IsEndless;

	public int EndlessStartTurn;

	public List<GridPieceInst> Pieces;

	public List<PickupInst> Pickups;

	public int NumRows;

	public int NumCols;

	public int NumKills;

	public int NumEndlessKills;

	public int NumLvlUpRerolls;

	public int NumRerollsInARow;

	public int NumFreeRerolls;

	public int NumClearBonuses;

	public float DifficultyModifier;

	public List<HeroInst> OldHeroes;

	public int BabyNumLaunched;

	public int BabyDamageDealt;

	public int BabyKills;

	public int FinalBossTurn;

	public bool CompletedLevel;

	public int NumNewCharCompletions;

	public int NumGearsGotten;

	public bool IsLatestUnlockedLvlWithGearSpace;

	public bool IsFirstTimeCompletingDifficultyWithChar;

	public int NumBossBlueprintsDropped;

	public bool Cheated;

	public GameState CurState;

	public List<BuildingType> QueuedFoundBlueprints;

	public List<BuildingType> FoundBlueprints;

	public BattleSaveData(CharBattleInst ct)
	{
	}

	public int GetCurTurnSeed()
	{
		return 0;
	}

	public int GetCurLvlSeed()
	{
		return 0;
	}

	public int GetNumResources(ResourceType rt)
	{
		return 0;
	}

	public string GetElapsedTimeStr()
	{
		return null;
	}

	public int GetNumAOEHeroes()
	{
		return 0;
	}

	public int GetNumActiveEnemies()
	{
		return 0;
	}

	public float GetActiveEnemyArea()
	{
		return 0f;
	}

	public float GetLowestEnemyY()
	{
		return 0f;
	}

	public bool HasBossPiece()
	{
		return false;
	}

	public bool IsGameplayOver()
	{
		return false;
	}
}
