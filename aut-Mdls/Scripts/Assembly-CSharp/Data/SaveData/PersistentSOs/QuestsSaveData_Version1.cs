using System;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public class QuestsSaveData_Version1 : IPreviousSaveVersion, ISaveVersion
	{
		public int CurrentIndex;

		public bool ShowTutorial;

		public ISaveVersion ToNextVersion()
		{
			int num = CurrentIndex;
			if (CurrentIndex > 7)
			{
				num += 2;
			}
			if (CurrentIndex > 10)
			{
				num++;
			}
			if (CurrentIndex >= 14 && CurrentIndex <= 18)
			{
				num = 17;
			}
			if (CurrentIndex > 19)
			{
				num++;
			}
			if (CurrentIndex > 24)
			{
				num++;
			}
			if (CurrentIndex > 25)
			{
				num = 30;
			}
			return new QuestsSaveData(num, ShowTutorial);
		}
	}
}
