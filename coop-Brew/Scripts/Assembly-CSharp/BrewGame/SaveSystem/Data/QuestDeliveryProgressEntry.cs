using System;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class QuestDeliveryProgressEntry
	{
		public string questId;

		public int stepIndex;

		public int deliveredCount;
	}
}
