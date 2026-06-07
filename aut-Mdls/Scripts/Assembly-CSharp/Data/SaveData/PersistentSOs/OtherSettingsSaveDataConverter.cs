using System;

namespace Data.SaveData.PersistentSOs
{
	public class OtherSettingsSaveDataConverter : SaveDataConverter<OtherSettingsSaveData>
	{
		private class Version0 : IPreviousSaveVersion, ISaveVersion
		{
			public bool _dataCollectionOptout;

			public bool _showUserName;

			public bool _runInBackground;

			public ISaveVersion ToNextVersion()
			{
				return new OtherSettingsSaveData(_dataCollectionOptout, _showUserName, _runInBackground, 60f, autoSaveFlag: true);
			}
		}

		public OtherSettingsSaveDataConverter()
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
