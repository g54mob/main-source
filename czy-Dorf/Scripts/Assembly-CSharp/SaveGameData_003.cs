using System;
using System.Collections.Generic;
using Dorfromantik;
using Dorfromantik.CreativeMode;
using UnityEngine;

[Serializable]
public class SaveGameData_003 : SaveGameData
{
	public GameModeId gameMode = GameModeId.Undefined;

	public int level;

	public int score;

	public int perfectPlacements;

	public int questsFulfilled;

	public int questsFailed;

	public int consecutivePerfectFits;

	public int consecutivePlacementsWithoutRotate;

	public float playtime;

	public int biomeSeed;

	public int preplacedTileSeed;

	public int placedTileCount;

	public int generatedTileCount = -1;

	public int generatedQuestCount = -1;

	public int surroundedTilesCount;

	public List<TileData_003> tiles;

	public List<TileData_003> tileStack;

	public List<PreplacedTileData_002> preplacedTiles;

	public List<ChallengeId> pendingLockedChallenges;

	public List<ActiveSessionQuestData_002> activeChallenges;

	public int tileStackCount;

	public byte[] screenshot;

	public int[] lastPlayed;

	public string fileName;

	public string initialVersion;

	public string lastPlayedVersion;

	public List<GroupTypeProbability> groupTypeConfiguration;

	public List<BiomeId> excludedBiomes;

	public CustomModeData customModeData;

	public List<int> lastRewardedStep = new List<int>();

	public List<int> lastRewardedScore = new List<int>();

	private Action OnUpdated;

	public bool HasStarted => tiles.Count > 0;

	public bool HasSaveFile => !string.IsNullOrWhiteSpace(fileName);

	public bool HasScreenshot
	{
		get
		{
			if (screenshot != null)
			{
				return screenshot.Length != 0;
			}
			return false;
		}
	}

	public SaveGameData_003()
	{
		version = 3;
		tiles = new List<TileData_003>();
		tileStack = new List<TileData_003>();
		preplacedTiles = new List<PreplacedTileData_002>();
		activeChallenges = new List<ActiveSessionQuestData_002>();
		pendingLockedChallenges = new List<ChallengeId>();
	}

	public SaveGameData_003(SaveGameData_002 oldSaveGameData)
	{
		version = 3;
		gameMode = oldSaveGameData.gameMode;
		level = oldSaveGameData.level;
		score = oldSaveGameData.score;
		biomeSeed = oldSaveGameData.biomeSeed;
		perfectPlacements = oldSaveGameData.perfectPlacements;
		questsFulfilled = oldSaveGameData.questsFulfilled;
		questsFailed = oldSaveGameData.questsFailed;
		consecutivePerfectFits = oldSaveGameData.consecutivePerfectFits;
		playtime = oldSaveGameData.playtime;
		preplacedTileSeed = oldSaveGameData.preplacedTileSeed;
		if (oldSaveGameData.pendingLockedChallenges != null)
		{
			pendingLockedChallenges = new List<ChallengeId>();
			foreach (string pendingLockedChallenge in oldSaveGameData.pendingLockedChallenges)
			{
				pendingLockedChallenges.Add(SessionQuestData.ChallengeIdByName[pendingLockedChallenge]);
			}
		}
		if (oldSaveGameData.activeSessionQuests != null)
		{
			activeChallenges = new List<ActiveSessionQuestData_002>();
			foreach (ActiveSessionQuestData_001 activeSessionQuest in oldSaveGameData.activeSessionQuests)
			{
				activeChallenges.Add(new ActiveSessionQuestData_002(activeSessionQuest));
			}
		}
		screenshot = oldSaveGameData.screenshot;
		lastPlayed = oldSaveGameData.lastPlayed;
		fileName = oldSaveGameData.fileName;
		initialVersion = oldSaveGameData.initialVersion;
		lastPlayedVersion = oldSaveGameData.lastPlayedVersion;
		groupTypeConfiguration = oldSaveGameData.groupTypeConfiguration;
		excludedBiomes = oldSaveGameData.excludedBiomes;
		tiles = new List<TileData_003>();
		foreach (TileData_002 tile in oldSaveGameData.tiles)
		{
			tiles.Add(new TileData_003(tile));
		}
		tileStack = new List<TileData_003>();
		foreach (TileData_002 item in oldSaveGameData.tileStack)
		{
			tileStack.Add(new TileData_003(item));
		}
		tileStackCount = oldSaveGameData.tileStackCount;
		preplacedTiles = new List<PreplacedTileData_002>();
		if (oldSaveGameData.preplacedTiles == null)
		{
			return;
		}
		foreach (PreplacedTileData preplacedTile in oldSaveGameData.preplacedTiles)
		{
			preplacedTiles.Add(new PreplacedTileData_002(preplacedTile));
		}
	}

	public override void SaveTiles(List<Tile> tilesToSave)
	{
		tiles = new List<TileData_003>();
		foreach (Tile item in tilesToSave)
		{
			if (!item.IsInitialTile)
			{
				tiles.Add(new TileData_003(item));
			}
		}
	}

	public override void SaveTileStack(List<Tile> stackedTilesToSave)
	{
		tileStack = new List<TileData_003>();
		foreach (Tile item in stackedTilesToSave)
		{
			tileStack.Add(new TileData_003(item));
		}
	}

	public void SavePreplacedTiles(PreplacedTileSectionManager preplacedTileSectionManager)
	{
		preplacedTiles = new List<PreplacedTileData_002>();
		foreach (KeyValuePair<Vector2Int, QuestTileId> predefinedPreplacedTile in preplacedTileSectionManager.predefinedPreplacedTiles)
		{
			preplacedTiles.Add(new PreplacedTileData_002(predefinedPreplacedTile.Key, predefinedPreplacedTile.Value));
		}
	}

	public void SaveWatchedChallenges(List<WatchedSessionQuest> watchedSessionQuests)
	{
		activeChallenges = new List<ActiveSessionQuestData_002>();
		foreach (WatchedSessionQuest watchedSessionQuest in watchedSessionQuests)
		{
			if (!watchedSessionQuest.SessionQuest.Passive)
			{
				activeChallenges.Add(new ActiveSessionQuestData_002(watchedSessionQuest.SessionQuest, watchedSessionQuest.EffectWasWatched));
			}
		}
	}

	public void SavePendingLockedChallenges(List<SessionQuest> lockedChallenges)
	{
		pendingLockedChallenges = new List<ChallengeId>();
		foreach (SessionQuest lockedChallenge in lockedChallenges)
		{
			pendingLockedChallenges.Add(lockedChallenge.id);
		}
	}

	public void SetLastPlayedTime(DateTime lastPlayedTime)
	{
		lastPlayed = new int[6] { lastPlayedTime.Year, lastPlayedTime.Month, lastPlayedTime.Day, lastPlayedTime.Hour, lastPlayedTime.Minute, lastPlayedTime.Second };
	}
}
