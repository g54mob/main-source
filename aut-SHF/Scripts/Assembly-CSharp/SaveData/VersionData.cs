using System;
using System.Runtime.Serialization;
using Libs;
using UnityEngine;

namespace SaveData
{
	[Serializable]
	public class VersionData : ISerializationCallbackReceiver
	{
		public const string SaveKey = "Version";

		public const string Version000 = "0.0.0";

		public const string Version001 = "0.0.1";

		public const string Version002 = "0.0.2";

		public const string Version101 = "1.0.1";

		public static readonly Version SaveVersion;

		public string dataVersion;

		private Version _dataVersion;

		public string applicationVersion;

		[SerializeField]
		private JDictionary<string, string> versionDB;

		[IgnoreDataMember]
		public Version DataVersion
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Version GetVersion(string key)
		{
			return null;
		}

		public Version GetApplicationVersion()
		{
			return null;
		}

		public void SetVersion(string key, Version inGameVersion)
		{
		}

		public void SetVersion(string key, string value)
		{
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}

		public static bool IsIncompatibleInGameData()
		{
			return false;
		}

		public static bool IsCompletelyIncompatibleInGameData()
		{
			return false;
		}
	}
}
