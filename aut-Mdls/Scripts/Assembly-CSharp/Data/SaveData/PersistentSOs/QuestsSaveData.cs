using System;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public class QuestsSaveData : AbstractSaveData
	{
		public const int CurrentVersion = 2;

		public int CurrentIndex;

		public bool ShowTutorial;

		public QuestsSaveData(int index, bool showTutorial)
			: base(2)
		{
			CurrentIndex = index;
			ShowTutorial = showTutorial;
		}
	}
}
