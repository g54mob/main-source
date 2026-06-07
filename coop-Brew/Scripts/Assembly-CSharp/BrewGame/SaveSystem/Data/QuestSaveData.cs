using System;
using System.Collections.Generic;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class QuestSaveData
	{
		public List<QuestProgressSaveData> activeQuests;

		public List<string> completedQuestIds;

		public string activeQuestId;

		public List<QuestItemProgressEntry> itemCollectionProgress;

		public List<QuestDeliveryProgressEntry> deliveryProgress;

		public bool hasTriggeredTutorialQuest;

		public bool hasTriggeredBarQuest;
	}
}
