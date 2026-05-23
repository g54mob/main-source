using System;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public class StorySaveData : AbstractSaveData
	{
		public const int CurrentVersion = 0;

		public bool[] CompletedStories;

		public bool CompletedIntro;

		public StorySaveData(bool[] completedStories, bool completedIntro)
			: base(0)
		{
			CompletedStories = completedStories;
			CompletedIntro = completedIntro;
		}
	}
}
