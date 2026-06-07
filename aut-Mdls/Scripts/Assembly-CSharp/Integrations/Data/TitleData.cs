#define ENABLE_DEBUG_ERRORS
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Utils;

namespace Integrations.Data
{
	public class TitleData
	{
		public const string CacheKey = "titledata";

		public ScreenshotContestInfo ScreenshotContestInfo { get; set; }

		[JsonProperty]
		private Dictionary<string, string> Cache { get; set; }

		public TitleData()
		{
			Cache = new Dictionary<string, string>();
			ScreenshotContestInfo = new ScreenshotContestInfo();
		}

		public TitleData(Dictionary<string, string> cache)
		{
			Cache = cache;
			ScreenshotContestInfo = GetTitleDataOrDefault<ScreenshotContestInfo>("ScreenshotContestInfo");
		}

		public bool TryUpdate(Dictionary<string, string> cache)
		{
			if (Cache.ContentEquals(cache))
			{
				ScreenshotContestInfo = GetTitleDataOrDefault<ScreenshotContestInfo>("ScreenshotContestInfo");
				return !ScreenshotContestInfo.IsValid();
			}
			Cache = cache;
			ScreenshotContestInfo = GetTitleDataOrDefault<ScreenshotContestInfo>("ScreenshotContestInfo");
			return true;
		}

		public List<DownloadableAsset> GetInvalidatedCachedAssetsList()
		{
			if (ScreenshotContestInfo == null)
			{
				return new List<DownloadableAsset>();
			}
			return ScreenshotContestInfo.GetInvalidatedCachedAssetsList();
		}

		private T GetTitleDataOrDefault<T>(string key, T @default = null) where T : class
		{
			string titleDataDataRecord = GetTitleDataDataRecord(key);
			if (string.IsNullOrEmpty(titleDataDataRecord))
			{
				return @default;
			}
			T val = null;
			try
			{
				val = JsonConvert.DeserializeObject<T>(titleDataDataRecord);
			}
			catch (Exception ex)
			{
				this.LogError("Exception -->" + ex, "GetTitleDataOrDefault", 60);
				return @default;
			}
			if (val == null)
			{
				return @default;
			}
			return val;
		}

		private string GetTitleDataDataRecord(string key)
		{
			if (Cache == null || !Cache.TryGetValue(key, out var value))
			{
				return null;
			}
			return value;
		}
	}
}
