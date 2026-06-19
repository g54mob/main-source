using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using ModIO.Implementation.API.Objects;

namespace ModIO.Implementation.API
{
	internal static class ResponseCache
	{
		[Serializable]
		private class CachedPageSearch
		{
			public Dictionary<int, long> mods = new Dictionary<int, long>();

			public long resultCount;
		}

		[Serializable]
		private class CachedModProfile
		{
			public ModProfile profile;

			public bool extendLifetime;
		}

		public static bool logCacheMessages = true;

		public static long maxCacheSize = 0L;

		private const int minCacheSize = 10485760;

		private const int absoluteCacheSizeLimit = 1073741924;

		private const int modLifetimeInCache = 60000;

		public static TermsHash termsHash;

		private static Dictionary<string, CachedPageSearch> modPages = new Dictionary<string, CachedPageSearch>();

		private static Dictionary<long, CachedModProfile> mods = new Dictionary<long, CachedModProfile>();

		private static Dictionary<string, CommentPage> commentObjectsCache = new Dictionary<string, CommentPage>();

		private static Dictionary<long, ModDependencies[]> modsDependencies = new Dictionary<long, ModDependencies[]>();

		private static Dictionary<long, Rating> currentUserRatings = new Dictionary<long, Rating>();

		private static bool currentRatingsCached = false;

		private static KeyValuePair<string, TermsOfUse>? termsOfUse;

		private static TagCategory[] gameTags;

		private static UserProfile? currentUser;

		public static int CacheSize => mods.Count;

		public static void AddModsToCache(string url, int offset, ModPage modPage)
		{
			if (modPage.modProfiles == null)
			{
				return;
			}
			if (logCacheMessages)
			{
				Logger.Log(LogLevel.Verbose, $"[CACHE] adding {modPage.modProfiles.Length} mods to cache with url: {url}\n offset({offset})");
			}
			if (!modPages.ContainsKey(url))
			{
				modPages.Add(url, new CachedPageSearch());
			}
			EnsureCacheSize(modPage);
			modPages[url].resultCount = modPage.totalSearchResultsFound;
			List<ModId> list = new List<ModId>();
			for (int i = 0; i < modPage.modProfiles.Length; i++)
			{
				ModProfile profile = modPage.modProfiles[i];
				int key = i + offset;
				if (!modPages[url].mods.ContainsKey(key))
				{
					modPages[url].mods.Add(key, profile.id);
				}
				if (!mods.ContainsKey(profile.id))
				{
					CachedModProfile value = new CachedModProfile
					{
						profile = profile
					};
					mods.Add(profile.id, value);
					list.Add(profile.id);
				}
				else
				{
					mods[profile.id].profile = profile;
					mods[profile.id].extendLifetime = true;
				}
			}
			ClearModsFromCacheAfterDelay(list);
		}

		public static void AddModCommentsToCache(string url, CommentPage commentPage)
		{
			if (commentObjectsCache.ContainsKey(url))
			{
				commentObjectsCache[url] = commentPage;
			}
			else
			{
				commentObjectsCache.Add(url, commentPage);
			}
		}

		public static void RemoveModCommentFromCache(long id)
		{
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, CommentPage> item in commentObjectsCache)
			{
				ModComment[] commentObjects = item.Value.CommentObjects;
				for (int i = 0; i < commentObjects.Length; i++)
				{
					if (commentObjects[i].id == id)
					{
						list.Add(item.Key);
					}
				}
			}
			foreach (string item2 in list)
			{
				commentObjectsCache.Remove(item2);
			}
		}

		public static void AddModToCache(ModProfile mod)
		{
			if (mods.ContainsKey(mod.id))
			{
				mods[mod.id].profile = mod;
				mods[mod.id].extendLifetime = true;
				return;
			}
			CachedModProfile cachedModProfile = new CachedModProfile();
			cachedModProfile.profile = mod;
			cachedModProfile.extendLifetime = false;
			mods.Add(mod.id, cachedModProfile);
			ClearModFromCacheAfterDelay(mod.id);
		}

		public static void AddUserToCache(UserProfile profile)
		{
			currentUser = profile;
		}

		public static void AddTagsToCache(TagCategory[] tags)
		{
			gameTags = tags;
		}

		public static void AddTermsToCache(string url, TermsOfUse terms)
		{
			termsHash = terms.hash;
			termsOfUse = new KeyValuePair<string, TermsOfUse>(url, terms);
		}

		public static void AddModDependenciesToCache(ModId modId, ModDependencies[] modDependencies)
		{
			if (modsDependencies.ContainsKey(modId))
			{
				modsDependencies[modId] = modDependencies;
			}
			else
			{
				modsDependencies.Add(modId, modDependencies);
			}
		}

		public static void AddCurrentUserRating(long modId, Rating rating)
		{
			if (rating.rating == ModRating.None)
			{
				currentUserRatings.Remove(modId);
			}
			else if (currentUserRatings.ContainsKey(modId))
			{
				currentUserRatings[modId] = rating;
			}
			else
			{
				currentUserRatings.Add(modId, rating);
			}
		}

		public static void ReplaceCurrentUserRatings(Rating[] ratings)
		{
			currentRatingsCached = true;
			currentUserRatings.Clear();
			for (int i = 0; i < ratings.Length; i++)
			{
				Rating rating = ratings[i];
				AddCurrentUserRating(rating.modId, rating);
			}
		}

		public static bool GetModsFromCache(string url, int offset, int limit, out ModPage modPage)
		{
			if (logCacheMessages)
			{
				Logger.Log(LogLevel.Verbose, $"[CACHE] checking cache for mods for url: {url}\n offset({offset} limit({limit}))");
			}
			if (modPages.ContainsKey(url))
			{
				List<ModProfile> list = new List<ModProfile>();
				int num = 0;
				while (num < limit)
				{
					int num2 = num + offset;
					if (num2 >= modPages[url].resultCount)
					{
						break;
					}
					if (modPages[url].mods.TryGetValue(num2, out var value))
					{
						if (mods.TryGetValue(value, out var value2))
						{
							list.Add(value2.profile);
							num++;
							continue;
						}
					}
					else if (logCacheMessages)
					{
						Logger.Log(LogLevel.Verbose, $"[CACHE] failed to get one of the mods. {list.Count} mods found thus far. Failed at {num2}. Total mods {modPages[url].mods.Count}");
					}
					modPage = default(ModPage);
					return false;
				}
				if (logCacheMessages)
				{
					Logger.Log(LogLevel.Verbose, $"[CACHE] retrieved {list.Count} mods from cache for url: {url}\n offset({offset} limit({limit}))");
				}
				modPage = default(ModPage);
				modPage.totalSearchResultsFound = modPages[url].resultCount;
				modPage.modProfiles = list.ToArray();
				return true;
			}
			modPage = default(ModPage);
			return false;
		}

		public static bool GetModFromCache(ModId modId, out ModProfile modProfile)
		{
			if (mods.ContainsKey(modId))
			{
				if (logCacheMessages)
				{
					Logger.Log(LogLevel.Verbose, "[CACHE] retrieved mod from cache");
				}
				modProfile = mods[modId].profile;
				return true;
			}
			modProfile = default(ModProfile);
			return false;
		}

		public static bool GetUserProfileFromCache(out UserProfile userProfile)
		{
			if (currentUser.HasValue)
			{
				if (logCacheMessages)
				{
					Logger.Log(LogLevel.Verbose, "[CACHE] retrieved user profile from cache");
				}
				userProfile = currentUser.Value;
				return true;
			}
			userProfile = default(UserProfile);
			return false;
		}

		public static bool GetTagsFromCache(out TagCategory[] tags)
		{
			if (gameTags != null)
			{
				if (logCacheMessages)
				{
					Logger.Log(LogLevel.Verbose, "[CACHE] retrieved game tags from cache");
				}
				tags = gameTags;
				return true;
			}
			tags = null;
			return false;
		}

		public static bool GetModCommentsFromCache(string url, out CommentPage commentObjs)
		{
			if (commentObjectsCache.ContainsKey(url))
			{
				if (logCacheMessages)
				{
					Logger.Log(LogLevel.Verbose, "[CACHE] retrieved mod comments from cache");
				}
				commentObjs = commentObjectsCache[url];
				return true;
			}
			commentObjs = default(CommentPage);
			return false;
		}

		public static async Task<ResultAnd<byte[]>> GetImageFromCache(string url)
		{
			ResultAnd<byte[]> result = new ResultAnd<byte[]>();
			ResultAnd<byte[]> resultAnd = await DataStorage.TryRetrieveImageBytes(url);
			result.result = resultAnd.result;
			if (resultAnd.result.Succeeded())
			{
				if (logCacheMessages)
				{
					Logger.Log(LogLevel.Verbose, "[CACHE] retrieved texture from temp folder cache");
				}
				result.value = resultAnd.value;
			}
			return result;
		}

		public static async Task<ResultAnd<byte[]>> GetImageFromCache(DownloadReference downloadReference)
		{
			return await GetImageFromCache(downloadReference.url);
		}

		public static bool GetTermsFromCache(string url, out TermsOfUse terms)
		{
			if (termsOfUse.HasValue && termsOfUse.Value.Key == url)
			{
				if (logCacheMessages)
				{
					Logger.Log(LogLevel.Verbose, "[CACHE] retrieved terms of use from cache");
				}
				terms = termsOfUse.Value.Value;
				return true;
			}
			terms = default(TermsOfUse);
			return false;
		}

		public static bool GetModDependenciesCache(ModId modId, out ModDependencies[] modDependencies)
		{
			if (modsDependencies.ContainsKey(modId))
			{
				if (logCacheMessages)
				{
					Logger.Log(LogLevel.Verbose, "[CACHE] retrieved mod dependency from cache");
				}
				modDependencies = modsDependencies[modId];
				return true;
			}
			modDependencies = null;
			return false;
		}

		public static bool GetCurrentUserRatingsCache(out Rating[] ratings)
		{
			ratings = currentUserRatings.Values.ToArray();
			if (currentUserRatings == null)
			{
				return false;
			}
			if (logCacheMessages)
			{
				Logger.Log(LogLevel.Verbose, "[CACHE] retrieved mod rating from cache");
			}
			return true;
		}

		public static bool GetCurrentUserRatingFromCache(ModId modId, out ModRating modRating)
		{
			if (HaveRatingsBeenCachedThisSession())
			{
				if (currentUserRatings.TryGetValue(modId, out var value))
				{
					modRating = value.rating;
					return true;
				}
				modRating = ModRating.None;
				return true;
			}
			modRating = ModRating.None;
			return false;
		}

		public static bool HaveRatingsBeenCachedThisSession()
		{
			return currentRatingsCached;
		}

		private static async void ClearModFromCacheAfterDelay(ModId modId)
		{
			do
			{
				if (mods.TryGetValue(modId, out var value))
				{
					value.extendLifetime = false;
				}
				await Task.Delay(60000);
			}
			while (mods.ContainsKey(modId) && mods[modId].extendLifetime);
			if (mods.ContainsKey(modId))
			{
				mods.Remove(modId);
			}
		}

		private static async void ClearModsFromCacheAfterDelay(List<ModId> modIds)
		{
			List<ModId> modIdsToClear = new List<ModId>();
			do
			{
				modIdsToClear.Clear();
				foreach (ModId modId in modIds)
				{
					if (mods.TryGetValue(modId, out var value))
					{
						value.extendLifetime = false;
					}
				}
				await Task.Delay(60000);
				foreach (ModId modId2 in modIds)
				{
					if (!mods.TryGetValue(modId2, out var value2) || !value2.extendLifetime)
					{
						modIdsToClear.Add(modId2);
					}
				}
				foreach (ModId item in modIdsToClear)
				{
					modIds.Remove(item);
					if (mods.ContainsKey(item))
					{
						mods.Remove(item);
					}
				}
			}
			while (modIds.Count > 0);
		}

		public static void ClearUserFromCache()
		{
			currentUser = null;
		}

		public static void ClearCache()
		{
			modPages?.Clear();
			mods?.Clear();
			termsHash = default(TermsHash);
			termsOfUse = null;
			gameTags = null;
			commentObjectsCache.Clear();
			modsDependencies?.Clear();
			currentUserRatings?.Clear();
			currentRatingsCached = false;
			ClearUserFromCache();
		}

		private static void EnsureCacheSize(object obj)
		{
			long num = ((maxCacheSize < 10485760) ? 10485760 : maxCacheSize);
			num = ((num > 1073741924) ? 1073741924 : maxCacheSize);
			long cacheSizeEstimate = GetCacheSizeEstimate();
			long byteSizeForObject = GetByteSizeForObject(obj);
			if (cacheSizeEstimate + byteSizeForObject > num)
			{
				ForceClearCache(cacheSizeEstimate + byteSizeForObject - num);
			}
		}

		private static void ForceClearCache(long numberOfBytesToClear)
		{
			if (mods == null)
			{
				return;
			}
			using Dictionary<long, CachedModProfile>.Enumerator enumerator = mods.GetEnumerator();
			List<long> list = new List<long>();
			long num = 0L;
			while (num < numberOfBytesToClear && enumerator.MoveNext())
			{
				num += GetByteSizeForObject(enumerator.Current.Value);
				list.Add(enumerator.Current.Key);
			}
			foreach (long item in list)
			{
				mods.Remove(item);
			}
		}

		private static long GetCacheSizeEstimate()
		{
			long modsByteSize = GetModsByteSize();
			modsByteSize += GetByteSizeForObject(currentUser);
			modsByteSize += GetByteSizeForObject(gameTags);
			modsByteSize += GetByteSizeForObject(termsOfUse);
			if (logCacheMessages)
			{
				Logger.Log(LogLevel.Verbose, $"CACHE SIZE: {modsByteSize} bytes");
			}
			return modsByteSize;
		}

		private static long GetModsByteSize()
		{
			long num = 0L;
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			if (mods != null)
			{
				using CacheSizeStream cacheSizeStream = new CacheSizeStream();
				binaryFormatter.Serialize(cacheSizeStream, mods);
				num = cacheSizeStream.Length;
			}
			if (modPages != null)
			{
				using CacheSizeStream cacheSizeStream2 = new CacheSizeStream();
				binaryFormatter.Serialize(cacheSizeStream2, modPages);
				num += cacheSizeStream2.Length;
			}
			return num;
		}

		private static long GetByteSizeForObject(object obj)
		{
			if (obj == null)
			{
				return 0L;
			}
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			using CacheSizeStream cacheSizeStream = new CacheSizeStream();
			binaryFormatter.Serialize(cacheSizeStream, obj);
			return cacheSizeStream.Length;
		}
	}
}
