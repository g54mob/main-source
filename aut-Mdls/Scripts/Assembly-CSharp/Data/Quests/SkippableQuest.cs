using System;

namespace Data.Quests
{
	[Serializable]
	public struct SkippableQuest
	{
		public bool Skip;

		public QuestSO Quest;
	}
}
