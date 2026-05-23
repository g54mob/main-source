#define ENABLE_DEBUG_LOGS
using System;
using System.IO;
using Utils;

namespace Integrations
{
	public class StorageHandler
	{
		public static bool TryGetCachedData<T>(string playerId, string key, out T data) where T : class, new()
		{
			data = new T();
			string text = CreateCachedAssetPath(key.ToLowerInvariant() + ".json", playerId);
			if (!File.Exists(text))
			{
				return false;
			}
			return SaveSystem.TryLoadData<T>(text, out data);
		}

		public static bool StoreCachedData<T>(string playerId, string key, T data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			string fullSavePath = CreateCachedAssetPath(key + ".json", playerId);
			return SaveSystem.TrySaveData(data, fullSavePath);
		}

		public static bool StoreCachedAsset(string filePath, byte[] data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			return FileUtils.TryWriteData(filePath, data);
		}

		public static bool RetrieveCachedAsset(string filePath, out byte[] data)
		{
			if (filePath == null)
			{
				throw new ArgumentNullException("filePath");
			}
			data = null;
			if (!FileUtils.TryReadData(filePath, out var data2))
			{
				return false;
			}
			data = data2;
			return true;
		}

		public static string CreateCachedAssetPath(string assetFileName, string cacheSubPath = null)
		{
			return Path.Combine(GetOrCreateDataDirectory("cache" + (string.IsNullOrWhiteSpace(cacheSubPath) ? ("/" + cacheSubPath) : string.Empty)), assetFileName);
		}

		private static string GetOrCreateDataDirectory(string directoryName)
		{
			string text = Path.Combine(SaveSystem.GameSavePath, directoryName ?? "");
			if (!Directory.Exists(text))
			{
				typeof(StorageHandler).Log("Creating data directory for player at " + text, "GetOrCreateDataDirectory", 62);
				Directory.CreateDirectory(text);
			}
			return text;
		}
	}
}
