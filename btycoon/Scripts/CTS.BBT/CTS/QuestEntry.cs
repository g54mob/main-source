using System;

namespace CTS
{
	[Serializable]
	public abstract class QuestEntry
	{
		private string _questName;

		private string _entryID;

		public QuestEntry(string questName, string entryID)
		{
			_questName = questName;
			_entryID = entryID;
		}

		public abstract void StartObserving();

		public abstract void StopObserving();
	}
}
