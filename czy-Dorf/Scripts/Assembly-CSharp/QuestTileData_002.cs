using System;
using Dorfromantik;

[Serializable]
public class QuestTileData_002 : QuestTileData
{
	public QuestTileId questTileId;

	public bool questActive;

	public int questQueueIndex;

	public int targetValue = -1;

	public int questLevel;

	public QuestId questId;

	public ChallengeId unlockedChallengeId;

	public QuestTileData_002()
	{
		version = 2;
	}

	public QuestTileData_002(QuestTile questTile)
	{
		version = 2;
		questTileId = questTile.id;
		if ((bool)questTile.QuestWatcher && questTile.QuestWatcher.Watching)
		{
			questActive = true;
			targetValue = questTile.QuestWatcher.GetConditionWatcher(0).TargetValue;
			questQueueIndex = questTile.QuestWatcher.CurrentQuestIndex;
			questId = questTile.QuestWatcher.CurrentQuest.id;
			unlockedChallengeId = (questTile.QuestWatcher.UnlockingSessionQuest ? questTile.QuestWatcher.UnlockingSessionQuest.id : ChallengeId.Undefined);
		}
		questLevel = questTile.level;
	}

	public QuestTileData_002(QuestTileData_001 oldQuestData)
	{
		version = 2;
		questTileId = QuestTileData_001.questTileIdByName[oldQuestData.questTileId];
		questActive = oldQuestData.questActive;
		questQueueIndex = oldQuestData.questQueueIndex;
		targetValue = oldQuestData.targetValue;
		questLevel = oldQuestData.questLevel;
		if (!string.IsNullOrWhiteSpace(oldQuestData.questId))
		{
			questId = QuestTileData_001.questIdByStringId[oldQuestData.questId];
		}
		if (!string.IsNullOrWhiteSpace(oldQuestData.unlockedSessionQuestId))
		{
			unlockedChallengeId = SessionQuestData.ChallengeIdByName[oldQuestData.unlockedSessionQuestId];
		}
	}

	public QuestTileData_002(QuestWatcher questWatcher, QuestWatcherState previousQuestWatcherState)
	{
		version = 2;
		questTileId = questWatcher.QuestTile.id;
		questActive = previousQuestWatcherState.watching;
		targetValue = previousQuestWatcherState.targetValue;
		questQueueIndex = previousQuestWatcherState.questQueueIndex;
		questId = previousQuestWatcherState.questId;
		unlockedChallengeId = (questWatcher.UnlockingSessionQuest ? questWatcher.UnlockingSessionQuest.id : ChallengeId.Undefined);
		questLevel = questWatcher.QuestTile.level;
	}
}
