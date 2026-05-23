using System;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public class OtherSettingsSaveData : AbstractSaveData
	{
		public const int CurrentVersion = 1;

		public bool _dataCollectionOptout;

		public bool _showUserName;

		public bool _runInBackground;

		public float _autoSaveInterval;

		public bool _autoSaveFlag;

		public OtherSettingsSaveData(bool dataCollectionOptout, bool showUserName, bool runInBackground, float autoSaveInterval, bool autoSaveFlag)
			: base(1)
		{
			_dataCollectionOptout = dataCollectionOptout;
			_showUserName = showUserName;
			_runInBackground = runInBackground;
			_autoSaveInterval = autoSaveInterval;
			_autoSaveFlag = autoSaveFlag;
		}
	}
}
