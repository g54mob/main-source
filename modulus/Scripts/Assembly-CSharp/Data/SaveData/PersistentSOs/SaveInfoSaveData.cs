using System;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public class SaveInfoSaveData : AbstractSaveData
	{
		public const int CurrentVersion = 1;

		public const int CurrentGlobalVersion = 2;

		public int SaveDirectoryVersion;

		public double TotalPlayTimeMins;

		public bool ZenMode;

		public string MapName;

		public Guid MapGuid;

		public DateTime LastSaveTimeStamp;

		public bool IsDemoSave;

		public string AutoSaveSourceSaveName;

		public string DisplaySaveName;

		public SaveInfoSaveData()
			: base(0)
		{
		}

		public SaveInfoSaveData(double totalPlayTimeMins, bool zenMode, string mapName, Guid mapGuid, bool isDemoSave, string autoSaveSourceSaveName)
			: base(1)
		{
			SaveDirectoryVersion = 2;
			TotalPlayTimeMins = totalPlayTimeMins;
			ZenMode = zenMode;
			MapName = mapName;
			MapGuid = mapGuid;
			LastSaveTimeStamp = DateTime.Now;
			IsDemoSave = isDemoSave;
			AutoSaveSourceSaveName = autoSaveSourceSaveName;
		}
	}
}
