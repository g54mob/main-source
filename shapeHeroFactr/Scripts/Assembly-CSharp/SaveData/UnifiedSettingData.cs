using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

namespace SaveData
{
	[Serializable]
	public class UnifiedSettingData : ISerializationCallbackReceiver
	{
		public const string SaveKey = "Settings";

		public const string Version001 = "0.0.1";

		public static readonly Version SaveVersion;

		public string settingsVersion;

		private Version _settingDataVersion;

		public SettingData settingData;

		public List<eMachine> favoritePaletteData;

		public string inputDataJson;

		[IgnoreDataMember]
		public Version SettingDataVersion
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool NeedConvertSettingDataFromOutGameData { get; set; }

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}

		public static string LoadJson()
		{
			return null;
		}

		public static UnifiedSettingData Load()
		{
			return null;
		}

		public static bool Save(UnifiedSettingData data, bool withSaveLocal = false)
		{
			return false;
		}

		public void Restore()
		{
		}
	}
}
