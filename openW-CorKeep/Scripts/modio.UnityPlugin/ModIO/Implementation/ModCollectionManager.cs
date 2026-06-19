using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ModIO.Implementation.API;
using ModIO.Implementation.API.Objects;
using ModIO.Implementation.API.Requests;

namespace ModIO.Implementation
{
	internal static class ModCollectionManager
	{
		public static ModCollectionRegistry Registry;

		private static bool hasSyncedBefore;

		private static long lastUserEventId;

		private static long lastModEventId;

		public static async Task<Result> LoadRegistryAsync()
		{
			hasSyncedBefore = false;
			ResultAnd<ModCollectionRegistry> resultAnd = await DataStorage.LoadSystemRegistryAsync();
			if (resultAnd.result.Succeeded())
			{
				Registry = resultAnd.value ?? new ModCollectionRegistry();
				return ResultBuilder.Success;
			}
			Logger.Log(LogLevel.Error, $"Failed to load Registry [{resultAnd.result.code}] - Creating a new one");
			Registry = new ModCollectionRegistry();
			return resultAnd.result;
		}

		public static Result LoadRegistry()
		{
			hasSyncedBefore = false;
			ResultAnd<ModCollectionRegistry> resultAnd = DataStorage.LoadSystemRegistry();
			if (resultAnd.result.Succeeded())
			{
				Registry = resultAnd.value ?? new ModCollectionRegistry();
				return ResultBuilder.Success;
			}
			Logger.Log(LogLevel.Error, $"Failed to load Registry [{resultAnd.result.code}] - Creating a new one");
			Registry = new ModCollectionRegistry();
			return resultAnd.result;
		}

		public static async void SaveRegistry()
		{
			if (!IsRegistryLoaded())
			{
				Logger.Log(LogLevel.Error, "ModCollectionManager was unable to save the Registry to disk because the registry hasn't been loaded yet");
			}
			else if (!(await DataStorage.SaveSystemRegistry(Registry)).Succeeded())
			{
				Logger.Log(LogLevel.Error, "ModCollectionManager was unable to save the Registry to disk because DataStorage.SaveSystemRegistry failed");
			}
		}

		public static void ClearRegistry()
		{
			lastUserEventId = 0L;
			lastModEventId = 0L;
			hasSyncedBefore = false;
			Registry?.mods?.Clear();
			Registry?.existingUsers?.Clear();
			Registry = null;
		}

		public static void ClearUserData()
		{
			if (IsRegistryLoaded() && DoesUserExist(0L))
			{
				Registry.existingUsers.Remove(UserData.instance.userObject.id);
				SaveRegistry();
			}
		}

		public static void AddUserToRegistry(UserObject user)
		{
			if (IsRegistryLoaded())
			{
				UserModCollectionData userModCollectionData = new UserModCollectionData();
				userModCollectionData.userId = user.id;
				if (!Registry.existingUsers.ContainsKey(user.id))
				{
					Registry.existingUsers.Add(user.id, userModCollectionData);
				}
				SaveRegistry();
			}
		}

		public static async Task<Result> FetchUpdates()
		{
			if (!IsRegistryLoaded())
			{
				return ResultBuilder.Create(20502u);
			}
			Result result = ResultBuilder.Success;
			ResultAnd<UserObject> resultAnd = await WebRequestManager.Request<UserObject>(GetAuthenticatedUser.Request());
			if (resultAnd.result.Succeeded())
			{
				UserData.instance.SetUserObject(resultAnd.value);
				long user = GetUserKey();
				ResultAnd<GetGameTags.ResponseSchema> resultAnd2 = await WebRequestManager.Request<GetGameTags.ResponseSchema>(GetGameTags.Request());
				if (resultAnd2.result.Succeeded())
				{
					ResponseCache.AddTagsToCache(ResponseTranslator.ConvertGameTagOptionsObjectToTagCategories(resultAnd2.value.data));
					foreach (ModId item in Registry.existingUsers[user].unsubscribeQueue)
					{
						if (!(await WebRequestManager.Request(UnsubscribeFromMod.Request(item))).Succeeded())
						{
							return result;
						}
					}
					ResultAnd<RatingObject[]> resultAnd3 = await TryRequestAllResults<RatingObject>(GetCurrentUserRatings.Request().Url, GetCurrentUserRatings.Request);
					Rating[] ratings = ResponseTranslator.ConvertModRatingsObjectToRatings(resultAnd3.value);
					if (resultAnd3.result.Succeeded())
					{
						ResponseCache.ReplaceCurrentUserRatings(ratings);
						result = await SyncUsersSubscriptions(user);
						hasSyncedBefore = true;
						ModManagement.WakeUp();
						Logger.Log(LogLevel.Message, $"Finished syncing user[{user}:{UserData.instance.userObject.id}]");
						return result;
					}
					return resultAnd3.result;
				}
				return resultAnd2.result;
			}
			return resultAnd.result;
		}

		private static async Task<Result> SyncUsersSubscriptions(long user)
		{
			Result result = ResultBuilder.Success;
			WebRequestConfig config = GetUserSubscriptions.Request();
			ResultAnd<ModObject[]> resultAnd = await TryRequestAllResults<ModObject>(config.Url, () => config);
			if (resultAnd.result.Succeeded())
			{
				Registry.existingUsers[user].subscribedMods.Clear();
				ModObject[] value = resultAnd.value;
				for (int num = 0; num < value.Length; num++)
				{
					ModObject modObject = value[num];
					Registry.existingUsers[user].subscribedMods.Add(new ModId(modObject.id));
					UpdateModCollectionEntryFromModObject(modObject);
				}
				return result;
			}
			return resultAnd.result;
		}

		public static async Task<ResultAnd<T[]>> TryRequestAllResults<T>(string url, Func<WebRequestConfig> webrequestFactory)
		{
			ResultAnd<T[]> response = new ResultAnd<T[]>();
			List<T> collatedData = new List<T>();
			int numberOfRequestsMade = 0;
			while (true)
			{
				int num = 100 * numberOfRequestsMade;
				WebRequestConfig webRequestConfig = webrequestFactory();
				webRequestConfig.Url = string.Format("{0}&{1}{2}&{3}{4}", url, "_limit=", 100, "_offset=", num);
				ResultAnd<PaginatedResponse<T>> resultAnd = await WebRequestManager.Request<PaginatedResponse<T>>(webRequestConfig);
				response.result = resultAnd.result;
				if (!resultAnd.result.Succeeded())
				{
					break;
				}
				long num2 = (resultAnd.result.Succeeded() ? resultAnd.value.result_total : 0);
				collatedData.AddRange(resultAnd.value.data);
				if (100 * (numberOfRequestsMade + 1) >= num2)
				{
					break;
				}
				numberOfRequestsMade++;
				if (numberOfRequestsMade >= 10)
				{
					Logger.Log(LogLevel.Warning, "Recursive Paging method (TryRequestAllResults) has reached it's cap of 1,000 results. Ending now to avoid rate limiting.");
					break;
				}
			}
			response.value = collatedData.ToArray();
			return response;
		}

		public static void AddModCollectionEntry(ModId modId)
		{
			if (!Registry.mods.ContainsKey(modId))
			{
				ModCollectionEntry modCollectionEntry = new ModCollectionEntry();
				modCollectionEntry.modObject.id = modId;
				Registry.mods.Add(modId, modCollectionEntry);
			}
		}

		public static void UpdateModCollectionEntry(ModId modId, ModObject modObject)
		{
			AddModCollectionEntry(modId);
			Registry.mods[modId].modObject = modObject;
			if (DataStorage.TryGetInstallationDirectory(modId, modObject.modfile.id, out var _))
			{
				Registry.mods[modId].currentModfile = modObject.modfile;
			}
			SaveRegistry();
		}

		public static void AddModToUserSubscriptions(ModId modId, bool saveRegistry = true)
		{
			long userKey = GetUserKey();
			if (IsRegistryLoaded() && DoesUserExist(userKey))
			{
				userKey = GetUserKey();
				if (!Registry.existingUsers[userKey].subscribedMods.Contains(modId))
				{
					Registry.existingUsers[userKey].subscribedMods.Add(modId);
				}
				AddModCollectionEntry(modId);
				if (saveRegistry)
				{
					SaveRegistry();
				}
			}
		}

		public static void RemoveModFromUserSubscriptions(ModId modId, bool offline, bool saveRegistry = true)
		{
			long userKey = GetUserKey();
			if (!IsRegistryLoaded() || !DoesUserExist(userKey))
			{
				Logger.Log(LogLevel.Warning, "registry not loaded");
				return;
			}
			userKey = GetUserKey();
			if (Registry.existingUsers[userKey].subscribedMods.Contains(modId))
			{
				Registry.existingUsers[userKey].subscribedMods.Remove(modId);
				if (offline && !Registry.existingUsers[userKey].unsubscribeQueue.Contains(modId))
				{
					Registry.existingUsers[userKey].unsubscribeQueue.Add(modId);
				}
			}
			if (saveRegistry)
			{
				SaveRegistry();
			}
		}

		public static void UpdateModCollectionEntryFromModObject(ModObject modObject, bool saveRegistry = true)
		{
			ModId modId = (ModId)modObject.id;
			if (!Registry.mods.ContainsKey(modId))
			{
				Registry.mods.Add(modId, new ModCollectionEntry());
			}
			Registry.mods[modId].modObject = modObject;
			if (DataStorage.TryGetInstallationDirectory(modId, modObject.modfile.id, out var _))
			{
				Registry.mods[modId].currentModfile = modObject.modfile;
			}
			if (saveRegistry)
			{
				SaveRegistry();
			}
		}

		public static bool EnableModForCurrentUser(ModId modId)
		{
			if (!IsRegistryLoaded())
			{
				Logger.Log(LogLevel.Error, "Cannot enable mod for user. No registry has been loaded.");
				return false;
			}
			long userKey = GetUserKey();
			if (Registry.existingUsers[userKey].disabledMods.Contains(modId))
			{
				Registry.existingUsers[userKey].disabledMods.Remove(modId);
				SaveRegistry();
			}
			Logger.Log(LogLevel.Verbose, "Enabled Mod " + (long)modId);
			return true;
		}

		public static bool DisableModForCurrentUser(ModId modId)
		{
			if (!IsRegistryLoaded())
			{
				Logger.Log(LogLevel.Error, "Cannot enable mod for user. No registry has been loaded.");
				return false;
			}
			long userKey = GetUserKey();
			if (!Registry.existingUsers[userKey].disabledMods.Contains(modId))
			{
				Registry.existingUsers[userKey].disabledMods.Add(modId);
				SaveRegistry();
			}
			Logger.Log(LogLevel.Verbose, "Disabled Mod " + (long)modId);
			return true;
		}

		public static InstalledMod[] GetInstalledMods(out Result result, bool excludeSubscribedModsForCurrentUser)
		{
			if (!IsRegistryLoaded())
			{
				result = ResultBuilder.Create(20502u);
				return null;
			}
			List<InstalledMod> list = new List<InstalledMod>();
			long userKey = GetUserKey();
			using (Dictionary<ModId, ModCollectionEntry>.Enumerator enumerator = Registry.mods.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if ((!Registry.existingUsers.ContainsKey(userKey) || ((!excludeSubscribedModsForCurrentUser || !Registry.existingUsers[userKey].subscribedMods.Contains(enumerator.Current.Key)) && (excludeSubscribedModsForCurrentUser || Registry.existingUsers[userKey].subscribedMods.Contains(enumerator.Current.Key)))) && DataStorage.TryGetInstallationDirectory(enumerator.Current.Key.id, enumerator.Current.Value.currentModfile.id, out var directoryPath))
					{
						InstalledMod item = ConvertModCollectionEntryToInstalledMod(enumerator.Current.Value, directoryPath);
						item.enabled = Registry.existingUsers.ContainsKey(userKey) && !Registry.existingUsers[userKey].disabledMods.Contains(item.modProfile.id);
						list.Add(item);
					}
				}
			}
			result = ResultBuilder.Success;
			return list.ToArray();
		}

		public static SubscribedMod[] GetSubscribedModsForUser(out Result result)
		{
			long userKey = GetUserKey();
			if (!IsRegistryLoaded() || !DoesUserExist(0L))
			{
				result = ResultBuilder.Create(20502u);
				return null;
			}
			userKey = GetUserKey();
			List<ModCollectionEntry> list = new List<ModCollectionEntry>();
			using (HashSet<ModId>.Enumerator enumerator = Registry.existingUsers[userKey].subscribedMods.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (Registry.mods.TryGetValue(enumerator.Current, out var value))
					{
						list.Add(value);
					}
				}
			}
			List<SubscribedMod> list2 = new List<SubscribedMod>();
			foreach (ModCollectionEntry item2 in list)
			{
				SubscribedMod item = ConvertModCollectionEntryToSubscribedMod(item2);
				item.enabled = !Registry.existingUsers[userKey].disabledMods.Contains(item.modProfile.id);
				list2.Add(item);
			}
			result = ResultBuilder.Success;
			return list2.ToArray();
		}

		public static SubscribedMod ConvertModCollectionEntryToSubscribedMod(ModCollectionEntry entry)
		{
			SubscribedMod result = new SubscribedMod
			{
				modProfile = ResponseTranslator.ConvertModObjectToModProfile(entry.modObject),
				status = ModManagement.GetModCollectionEntrysSubscribedModStatus(entry)
			};
			DataStorage.TryGetInstallationDirectory(entry.modObject.id, entry.modObject.modfile.id, out result.directory);
			return result;
		}

		public static InstalledMod ConvertModCollectionEntryToInstalledMod(ModCollectionEntry entry, string directory)
		{
			InstalledMod result = new InstalledMod
			{
				modProfile = ResponseTranslator.ConvertModObjectToModProfile(entry.modObject),
				updatePending = (entry.currentModfile.id != entry.modObject.modfile.id),
				directory = directory,
				subscribedUsers = new List<long>(),
				metadata = entry.modObject.modfile.metadata_blob,
				version = entry.currentModfile.version,
				changeLog = entry.currentModfile.changelog,
				dateAdded = ResponseTranslator.GetUTCDateTime(entry.currentModfile.date_added)
			};
			foreach (long key in Registry.existingUsers.Keys)
			{
				if (Registry.existingUsers[key].subscribedMods.Contains((ModId)entry.modObject.id))
				{
					result.subscribedUsers.Add(key);
				}
			}
			return result;
		}

		public static Result MarkModForUninstallIfNotSubscribedToCurrentSession(ModId modId)
		{
			if (!IsRegistryLoaded())
			{
				return ResultBuilder.Create(20502u);
			}
			if (Registry.mods.TryGetValue(modId, out var value))
			{
				value.uninstallIfNotSubscribedToCurrentSession = true;
				return ResultBuilder.Success;
			}
			return ResultBuilder.Create(1u);
		}

		private static bool IsRegistryLoaded()
		{
			if (Registry == null)
			{
				Logger.Log(LogLevel.Error, "The Registry hasn't been loaded yet. Make sure you initialize the plugin before using this method;");
				return false;
			}
			return true;
		}

		public static bool DoesUserExist(long user = 0L)
		{
			if (user == 0L)
			{
				UserData instance = UserData.instance;
				if (instance != null)
				{
					_ = instance.userObject;
					if (0 == 0)
					{
						user = UserData.instance.userObject.id;
						if (user == 0L)
						{
							Logger.Log(LogLevel.Error, "The current user has not been authenticated properly (The UserObject id is not set).");
							return false;
						}
						goto IL_0046;
					}
				}
				Logger.Log(LogLevel.Error, "The current user data is null or hasn't been authenticated properly");
				return false;
			}
			goto IL_0046;
			IL_0046:
			if (!Registry.existingUsers.ContainsKey(user))
			{
				Logger.Log(LogLevel.Error, $"The User does not exist in the current loaded Registry [{user}].");
				return false;
			}
			return true;
		}

		public static long GetUserKey()
		{
			if (UserData.instance != null)
			{
				return UserData.instance.userObject.id;
			}
			return 0L;
		}
	}
}
