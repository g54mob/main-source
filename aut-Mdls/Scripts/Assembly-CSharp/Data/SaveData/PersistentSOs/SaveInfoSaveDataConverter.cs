using System;
using UnityEngine.Serialization;

namespace Data.SaveData.PersistentSOs
{
	public class SaveInfoSaveDataConverter : SaveDataConverter<SaveInfoSaveData>
	{
		private class Version0 : IPreviousSaveVersion, ISaveVersion
		{
			public int SaveDirectoryVersion;

			public double TotalPlayTimeMins;

			public bool ZenMode;

			public Guid MapGuid;

			public DateTime LastSaveTimeStamp;

			public bool IsDemoSave;

			[FormerlySerializedAs("OriginalSaveName")]
			public string AutoSaveSourceSaveName;

			public string DisplaySaveName;

			public ISaveVersion ToNextVersion()
			{
				string mapName = (ZenMode ? "DefaultLevelCreative" : "DefaultLevel");
				return new SaveInfoSaveData(TotalPlayTimeMins, ZenMode, mapName, MapGuid, IsDemoSave, AutoSaveSourceSaveName)
				{
					SaveDirectoryVersion = SaveDirectoryVersion,
					LastSaveTimeStamp = LastSaveTimeStamp
				};
			}
		}

		public SaveInfoSaveDataConverter()
			: base(1)
		{
		}

		public override Type GetPreviousVersion(int version)
		{
			if (version == 0)
			{
				return typeof(Version0);
			}
			return null;
		}
	}
}
