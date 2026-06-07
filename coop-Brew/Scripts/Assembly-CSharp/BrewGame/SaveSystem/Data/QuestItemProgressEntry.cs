using System;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class QuestItemProgressEntry
	{
		public string questId;

		public string itemId;

		public int collectedCount;
	}
}
