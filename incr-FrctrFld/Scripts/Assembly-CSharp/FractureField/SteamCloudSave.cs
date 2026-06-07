using System;

namespace FractureField
{
	public static class SteamCloudSave
	{
		private const string CLOUD_SAVE_FILENAME = "fracturefield_save.dat";

		private const int MAX_RETRIES = 3;

		public static bool IsAvailable => false;

		public static bool GetQuota(out ulong totalBytes, out ulong availableBytes)
		{
			totalBytes = default(ulong);
			availableBytes = default(ulong);
			return false;
		}

		public static bool WriteSaveToCloud(string compressedData)
		{
			return false;
		}

		public static bool ReadSaveFromCloud(out string compressedData)
		{
			compressedData = null;
			return false;
		}

		public static DateTime? GetCloudSaveTimestamp()
		{
			return null;
		}

		public static bool DeleteCloudSave()
		{
			return false;
		}

		public static int GetCloudSaveSize()
		{
			return 0;
		}
	}
}
