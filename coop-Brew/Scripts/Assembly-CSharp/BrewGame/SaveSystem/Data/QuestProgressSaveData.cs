using System;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class QuestProgressSaveData
	{
		public string questId;

		public int currentStepIndex;

		public bool isCompleted;
	}
}
