using System;
using System.Collections.Generic;
using Dorfromantik;
using Dorfromantik.CreativeMode;

[Serializable]
public class SaveGameData_002 : SaveGameData
{
	public GameModeId gameMode = GameModeId.Undefined;

	public int level;

	public int score;

	public int perfectPlacements;

	public int questsFulfilled;

	public int questsFailed;

	public int consecutivePerfectFits;

	public float playtime;

	public int biomeSeed;

	public int preplacedTileSeed;

	public List<TileData_002> tiles;

	public List<TileData_002> tileStack;

	public List<PreplacedTileData> preplacedTiles;

	public List<string> pendingLockedChallenges;

	public List<ActiveSessionQuestData_001> activeSessionQuests;

	public int tileStackCount;

	public byte[] screenshot;

	public int[] lastPlayed;

	public string fileName;

	public string initialVersion;

	public string lastPlayedVersion;

	public List<GroupTypeProbability> groupTypeConfiguration;

	public List<BiomeId> excludedBiomes;

	public SaveGameData_002()
	{
		version = 2;
		tiles = new List<TileData_002>();
		tileStack = new List<TileData_002>();
		preplacedTiles = new List<PreplacedTileData>();
		activeSessionQuests = new List<ActiveSessionQuestData_001>();
		pendingLockedChallenges = new List<string>();
	}

	public SaveGameData_002(SaveGameData_001 oldSaveGameData)
	{
		version = 2;
		level = oldSaveGameData.level;
		score = oldSaveGameData.score;
		biomeSeed = oldSaveGameData.biomeSeed;
		tiles = new List<TileData_002>();
		foreach (TileData_001 tile in oldSaveGameData.tiles)
		{
			tiles.Add(new TileData_002(tile));
		}
		tileStack = new List<TileData_002>();
		foreach (TileData_001 item in oldSaveGameData.tileStack)
		{
			tileStack.Add(new TileData_002(item));
		}
		tileStackCount = oldSaveGameData.tileStackCount;
		activeSessionQuests = new List<ActiveSessionQuestData_001>();
	}

	public override void SaveTiles(List<Tile> tilesToSave)
	{
		tiles = new List<TileData_002>();
		foreach (Tile item in tilesToSave)
		{
			if (!item.IsInitialTile)
			{
				tiles.Add(new TileData_002(item));
			}
		}
	}

	public override void SaveTileStack(List<Tile> stackedTilesToSave)
	{
		tileStack = new List<TileData_002>();
		foreach (Tile item in stackedTilesToSave)
		{
			tileStack.Add(new TileData_002(item));
		}
	}
}
