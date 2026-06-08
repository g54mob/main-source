using System;

namespace Dorfromantik
{
	[Serializable]
	public class QuestWatcherState
	{
		public int[] questTileGridPos;

		public int questQueueIndex;

		public int targetValue;

		public QuestId questId;

		public bool watching;

		public QuestWatcherState(QuestWatcher questWatcher)
		{
			watching = questWatcher.Watching;
			questTileGridPos = new int[2]
			{
				questWatcher.QuestTile.GridPos.x,
				questWatcher.QuestTile.GridPos.y
			};
			questQueueIndex = questWatcher.CurrentQuestIndex;
			targetValue = questWatcher.GetConditionWatcher(0).TargetValue;
			questId = questWatcher.CurrentQuest.id;
		}
	}
}
