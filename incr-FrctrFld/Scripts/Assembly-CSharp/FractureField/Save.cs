using System.Collections.Generic;
using Newtonsoft.Json;

namespace FractureField
{
	public class Save
	{
		public static readonly JsonSerializerSettings LoadJsonSerializerSettings;

		public static readonly JsonSerializerSettings SaveJsonSerializerSettings;

		private static SaveData _latest;

		private static long _lastLocalSave;

		private const int LocalSaveFrequency = 5000;

		private static long _lastCloudSave;

		private const int CloudSaveFrequency = 60000;

		private static long _lastSteamCloudSave;

		private const int SteamCloudSaveFrequency = 30000;

		private static int _steamCloudRetryCount;

		private static long _steamCloudNextRetryTime;

		private static readonly int[] SteamCloudRetryDelays;

		public static Stackabool IsSavingDisabled { get; set; }

		public static bool UseSteamCloud { get; set; }

		public static bool SteamCloudAutoSync { get; set; }

		private static List<JsonConverter> Converters => null;

		private static bool UseUnityEditorLogic => false;

		public static string SaveName => null;

		public static SaveData Local { get; private set; }

		public static SaveData Cloud { get; private set; }

		public static SaveData Latest
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private static bool RetrievingSaveData { get; set; }

		private static void LoadLocal()
		{
		}

		public static void CheckSave()
		{
		}

		public static void DoSave(SaveData saveData = null, bool local = true, bool cloud = false, bool steamCloud = false, bool force = false)
		{
		}

		private static void DoLocalSave(string json, string compressed)
		{
		}

		private static void DoCloudSave(string compressed)
		{
		}

		private static void DoSteamCloudSave(string compressed)
		{
		}

		public static SaveData Decompress(string compressed)
		{
			return null;
		}

		private static SaveData LoadSaveData(string saveDataString)
		{
			return null;
		}

		public static void ImportSave(string saveDataStr, bool replaceIds = false)
		{
		}

		public static string ExportSave()
		{
			return null;
		}

		public static void DoHardReset()
		{
		}

		public static bool IsSteamCloudAvailable()
		{
			return false;
		}

		public static string GetSteamCloudStatus()
		{
			return null;
		}

		public static void ForceSteamCloudSync()
		{
		}

		public static void ToggleSteamCloud(bool enabled)
		{
		}

		public static void ToggleSteamCloudAutoSync(bool enabled)
		{
		}
	}
}
