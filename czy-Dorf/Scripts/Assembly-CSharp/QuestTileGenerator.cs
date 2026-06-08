using Dorfromantik;
using UnityEngine;

public class QuestTileGenerator : ScriptableObject
{
	[SerializeField]
	private QuestManager questManager;

	[SerializeField]
	private TileFactory tileFactory;

	public QuestTile GenerateQuestTile(int seed, TileGenFilter usedFilter = TileGenFilter.None)
	{
		if (seed == -1)
		{
			seed = Randomizer.GetRandomSeed();
		}
		SessionQuestReward reward;
		QuestTile randomQuestTile = questManager.Configuration.GetRandomQuestTile(out reward, usedFilter, seed);
		return CreateQuestTile(randomQuestTile, seed);
	}

	public QuestTile CreateQuestTile(QuestTile questTilePrefab, int overwriteSeed = -1, QuestTileData_002 loadedData = null)
	{
		QuestTile questTile = Object.Instantiate(questTilePrefab);
		questTile.InitializeSeed(overwriteSeed);
		tileFactory.InitializePrebuiltTile(questTile);
		return questTile;
	}

	public Tile SetupLoadedQuestTile(TileData_003 tileData)
	{
		if (tileData.questTileData.questTileId == QuestTileId.Undefined)
		{
			Debug.LogError($"tries to load questTile without id {tileData.questTileData.questTileId}, {tileData.questTileData.questLevel}");
		}
		if (!questManager.Configuration.QuestTileById.ContainsKey(tileData.questTileData.questTileId))
		{
			Debug.LogError($"QuestTile key missing {tileData.questTileData.questTileId} in {questManager.Configuration}");
			return null;
		}
		QuestTile questTilePrefab = questManager.Configuration.QuestTileById[tileData.questTileData.questTileId];
		QuestTile questTile = CreateQuestTile(questTilePrefab, tileData.seed, tileData.questTileData);
		questTile.SetupLoadedData(tileData.questTileData);
		return questTile;
	}
}
