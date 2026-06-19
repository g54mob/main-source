using System.Collections.Generic;
using System.Threading.Tasks;
using ModIO.Implementation.API;
using ModIO.Implementation.API.Objects;
using ModIO.Implementation.API.Requests;

namespace ModIO.Implementation
{
	internal static class ModManagement
	{
		private static Task operation;

		private static bool isModManagementEnabled;

		private static bool isModManagementAwake;

		private static HashSet<ModId> taintedMods = new HashSet<ModId>();

		private static HashSet<ModId> notEnoughStorageMods = new HashSet<ModId>();

		private static List<ModId> uninstalledModsWithNoUserSubscriptions = new List<ModId>();

		private static HashSet<CreationToken> creationTokens = new HashSet<CreationToken>();

		public static ModManagementJob currentJob;

		private static Dictionary<long, ModManagementOperationType> previousJobs = new Dictionary<long, ModManagementOperationType>();

		public static ModManagementEventDelegate modManagementEventDelegate;

		private static HashSet<long> abortingDownloadsModObjectIds = new HashSet<long>();

		public static CreationToken GenerateNewCreationToken()
		{
			CreationToken creationToken = new CreationToken();
			creationTokens.Add(creationToken);
			return creationToken;
		}

		public static void InvalidateCreationToken(CreationToken token)
		{
			if (creationTokens.Contains(token))
			{
				creationTokens.Remove(token);
			}
		}

		public static bool IsCreationTokenValid(CreationToken token)
		{
			if (token == null)
			{
				return false;
			}
			return creationTokens.Contains(token);
		}

		public static void EnableModManagement()
		{
			isModManagementEnabled = true;
			Logger.Log(LogLevel.Verbose, "ENABLED Mod Management");
			WakeUp();
		}

		public static void DisableModManagement()
		{
			isModManagementEnabled = false;
			Logger.Log(LogLevel.Verbose, "DISABLED Mod Management");
		}

		public static async void WakeUp()
		{
			if (!isModManagementAwake && isModManagementEnabled)
			{
				isModManagementAwake = true;
				Logger.Log(LogLevel.Verbose, "Mod Management Awake");
				operation = PerformJobs();
				await operation;
				isModManagementAwake = false;
				Logger.Log(LogLevel.Verbose, "Mod Management Asleep");
			}
		}

		public static void AbortCurrentInstallJob()
		{
			Logger.Log(LogLevel.Message, $"Aborting installation of Mod[{currentJob.mod.modObject.id}_" + $"{currentJob.mod.modObject.modfile.id}]");
			currentJob.zipOperation.Cancel();
		}

		public static void AbortCurrentDownloadJob()
		{
			Logger.Log(LogLevel.Message, $"Aborting download of Mod[{currentJob.mod.modObject.id}_" + $"{currentJob.mod.modObject.modfile.id}]");
			currentJob.downloadWebRequest?.cancel?.Invoke();
			abortingDownloadsModObjectIds.Add(currentJob.mod.modObject.id);
		}

		private static bool DownloadIsAborting(long id)
		{
			return abortingDownloadsModObjectIds.Contains(id);
		}

		private static async Task PerformJobs()
		{
			currentJob = GetNextModManagementJob();
			while (currentJob != null && isModManagementEnabled)
			{
				if (!(await PerformJob(currentJob)).Succeeded())
				{
					if (DownloadIsAborting(currentJob.mod.modObject.id))
					{
						abortingDownloadsModObjectIds.Remove(currentJob.mod.modObject.id);
					}
					else
					{
						Logger.Log(LogLevel.Error, "ModManagement Failed to complete an operation." + $" the Mod[{currentJob.mod.modObject.id}_{currentJob.mod.modObject.modfile.id}]" + " will be ignored by ModManagement for the duration of the session. If it failed due to insufficient storage space it will re-attempt after a mod deletion has occurred.");
						taintedMods.Add((ModId)currentJob.mod.modObject.id);
					}
				}
				ModCollectionManager.SaveRegistry();
				currentJob = (isModManagementEnabled ? GetNextModManagementJob() : null);
			}
			currentJob = null;
		}

		public static async Task<Result> PerformJob(ModManagementJob job)
		{
			Result result = ResultBuilder.Unknown;
			if (job == null)
			{
				return ResultBuilder.Create(20503u);
			}
			long modId = job.mod.modObject.id;
			long id = job.mod.modObject.modfile.id;
			long id2 = job.mod.currentModfile.id;
			if (previousJobs.ContainsKey(modId) && previousJobs[modId] == job.type)
			{
				Logger.Log(LogLevel.Error, $"Mod Management [{modId}_{job.type.ToString()}" + $"_{currentJob.mod.modObject.modfile.id}]" + " has received an identical job that should already be complete. To avoid getting into an " + $"infinite loop the ModId[{modId}] has been " + "blacklisted and will be ignored until ModManagement is re-enabled.");
				return ResultBuilder.Create(20503u);
			}
			job.progressHandle = new ProgressHandle();
			job.progressHandle.modId = (ModId)modId;
			switch (job.type)
			{
			case ModManagementOperationType.Install:
				job.progressHandle.OperationType = ModManagementOperationType.Install;
				InvokeModManagementDelegate((ModId)modId, ModManagementEventType.InstallStarted, ResultBuilder.Unknown);
				result = await PerformOperation_Install(job);
				job.progressHandle.Completed = true;
				if (result.Succeeded())
				{
					InvokeModManagementDelegate((ModId)modId, ModManagementEventType.Installed, result);
					break;
				}
				job.progressHandle.Failed = true;
				InvokeModManagementDelegate((ModId)modId, ModManagementEventType.InstallFailed, result);
				break;
			case ModManagementOperationType.Download:
				job.progressHandle.OperationType = ModManagementOperationType.Download;
				InvokeModManagementDelegate((ModId)modId, ModManagementEventType.DownloadStarted, ResultBuilder.Unknown);
				result = await PerformOperation_Download(job);
				job.progressHandle.Completed = true;
				if (result.Succeeded())
				{
					InvokeModManagementDelegate((ModId)modId, ModManagementEventType.Downloaded, result);
					break;
				}
				job.progressHandle.Failed = true;
				InvokeModManagementDelegate((ModId)modId, ModManagementEventType.DownloadFailed, result);
				break;
			case ModManagementOperationType.Update:
				job.progressHandle.OperationType = ModManagementOperationType.Update;
				if (id == id2)
				{
					Logger.Log(LogLevel.Error, "Mod Management Was given a job to update a mod but the existing fileId matches the update fileId, therefore should already" + $" be up to date [{modId}_{id2} == " + $"{modId}_{id}].");
					result = ResultBuilder.Create(20503u);
					break;
				}
				InvokeModManagementDelegate((ModId)modId, ModManagementEventType.UpdateStarted, ResultBuilder.Unknown);
				result = await PerformOperation_Download(job);
				if (!result.Succeeded())
				{
					job.progressHandle.Completed = true;
					job.progressHandle.Failed = true;
					InvokeModManagementDelegate((ModId)modId, ModManagementEventType.UpdateFailed, result);
					break;
				}
				result = await PerformOperation_Install(job);
				job.progressHandle.Completed = true;
				if (result.Succeeded())
				{
					InvokeModManagementDelegate((ModId)modId, ModManagementEventType.Updated, ResultBuilder.Success);
					break;
				}
				job.progressHandle.Failed = true;
				InvokeModManagementDelegate((ModId)modId, ModManagementEventType.UpdateFailed, result);
				break;
			case ModManagementOperationType.Uninstall:
				job.progressHandle.OperationType = ModManagementOperationType.Uninstall;
				result = await PerformOperation_Delete(modId, job.mod.currentModfile.id);
				job.progressHandle.Progress = 1f;
				job.progressHandle.Completed = true;
				if (result.Succeeded())
				{
					InvokeModManagementDelegate((ModId)modId, ModManagementEventType.Uninstalled, ResultBuilder.Success);
					if (notEnoughStorageMods.Count > 0)
					{
						DataStorage.TryDeleteModfileArchive(modId, job.mod.currentModfile.id, out var _);
					}
					foreach (ModId notEnoughStorageMod in notEnoughStorageMods)
					{
						if (taintedMods.Contains(notEnoughStorageMod))
						{
							taintedMods.Remove(notEnoughStorageMod);
						}
					}
					notEnoughStorageMods.Clear();
				}
				else
				{
					job.progressHandle.Failed = true;
					InvokeModManagementDelegate((ModId)modId, ModManagementEventType.UninstallFailed, result);
				}
				break;
			}
			if (previousJobs.ContainsKey(modId))
			{
				previousJobs[modId] = job.type;
			}
			else
			{
				previousJobs.Add(modId, job.type);
			}
			return result;
		}

		private static async Task<Result> PerformOperation_Download(ModManagementJob job)
		{
			long modId = job.mod.modObject.id;
			long fileId = job.mod.modObject.modfile.id;
			if (!(await DataStorage.temp.IsThereEnoughDiskSpaceFor(job.mod.modObject.modfile.filesize)))
			{
				Logger.Log(LogLevel.Error, $"INSUFFICIENT STORAGE FOR DOWNLOAD [{modId}_{fileId}]");
				notEnoughStorageMods.Add((ModId)modId);
				return ResultBuilder.Create(20442u);
			}
			Logger.Log(LogLevel.Message, $"DOWNLOADING MODFILE[{modId}_{fileId}]");
			ResultAnd<ModObject> resultAnd = await WebRequestManager.Request<ModObject>(GetMod.Request(modId));
			Result result = resultAnd.result;
			if (!resultAnd.result.Succeeded())
			{
				Logger.Log(LogLevel.Warning, $"Failed to get mod[{modId}] for modfile download. " + "Attempting to use existing download url in cache instead.");
			}
			else
			{
				job.mod.modObject = resultAnd.value;
				fileId = job.mod.modObject.modfile.id;
				ModCollectionManager.UpdateModCollectionEntry((ModId)resultAnd.value.id, resultAnd.value);
			}
			if (!ShouldModManagementBeRunning())
			{
				return DownloadCleanup(result, modId, fileId);
			}
			string binary_url = job.mod.modObject.modfile.download.binary_url;
			string md5 = job.mod.modObject.modfile.filehash.md5;
			string downloadFilepath = DataStorage.GenerateModfileArchiveFilePath(modId, fileId);
			Result result2 = ResultBuilder.Unknown;
			Result result3;
			using (ModIOFileStream downloadStream = DataStorage.CreateArchiveDownloadStream(downloadFilepath, out result3))
			{
				if (!result3.Succeeded())
				{
					return DownloadCleanup(result, modId, fileId);
				}
				result2 = await (job.downloadWebRequest = WebRequestManager.Download(binary_url, downloadStream, job.progressHandle)).task;
			}
			if (result2.Succeeded())
			{
				if (!ShouldModManagementBeRunning())
				{
					result = ResultBuilder.Create(20506u);
				}
				else
				{
					result = ResultBuilder.Success;
					Logger.Log(LogLevel.Verbose, $"DOWNLOADED MODFILE[{modId}_{fileId}]");
				}
				if (ValidateDownload_md5(md5, downloadFilepath))
				{
					if (!ShouldModManagementBeRunning())
					{
						result = ResultBuilder.Create(20506u);
					}
					else
					{
						Logger.Log(LogLevel.Verbose, $"VERIFIED DOWNLOAD[{modId}_{fileId}]");
					}
					return result;
				}
				Logger.Log(LogLevel.Error, $"Failed to verify downloaded modfile[{modId}_{fileId}]");
				result = ResultBuilder.Create(20503u);
				return DownloadCleanup(result, modId, fileId);
			}
			Logger.Log(LogLevel.Error, $"Failed to download modfile[{modId}_{fileId}]");
			result = ((result2.code == 20506) ? result2 : ResultBuilder.Create(20503u));
			return DownloadCleanup(result, modId, fileId);
		}

		private static Result DownloadCleanup(Result result, long modId, long fileId)
		{
			if (!result.Succeeded())
			{
				DataStorage.TryDeleteModfileArchive(modId, fileId, out var _);
			}
			return result;
		}

		private static async Task<Result> PerformOperation_Install(ModManagementJob job)
		{
			long modId = job.mod.modObject.id;
			long fileId = job.mod.modObject.modfile.id;
			if (!(await DataStorage.persistent.IsThereEnoughDiskSpaceFor(job.mod.modObject.modfile.filesize * 2)))
			{
				Logger.Log(LogLevel.Error, $"INSUFFICIENT STORAGE FOR INSTALLATION [{modId}_{fileId}]");
				notEnoughStorageMods.Add((ModId)modId);
				return ResultBuilder.Create(20442u);
			}
			Logger.Log(LogLevel.Verbose, $"INSTALLING MODFILE[{modId}_{fileId}]");
			Result result = await ((ExtractOperation)(job.zipOperation = new ExtractOperation(modId, fileId, job.progressHandle))).Extract();
			if (!ShouldModManagementBeRunning())
			{
				result = ResultBuilder.Create(20506u);
			}
			if (result.Succeeded())
			{
				if (fileId != job.mod.currentModfile.id)
				{
					long id = job.mod.currentModfile.id;
					if (DataStorage.TryGetInstallationDirectory(modId, id, out var _))
					{
						DataStorage.TryDeleteInstalledMod(modId, id, out result);
						if (!result.Succeeded())
						{
							Logger.Log(LogLevel.Warning, $"Failed to cleanup old modfile[{modId}_{id}]");
						}
					}
				}
				job.mod.currentModfile = job.mod.modObject.modfile;
				ModCollectionManager.UpdateModCollectionEntryFromModObject(job.mod.modObject);
				Logger.Log(LogLevel.Verbose, $"INSTALLED MOD [{modId}_{fileId}]");
			}
			else
			{
				Logger.Log(LogLevel.Error, $"Failed to install mod[{modId}_{fileId}]");
				result = ResultBuilder.Create(20503u);
			}
			return result;
		}

		private static async Task<Result> PerformOperation_Delete(long modId, long fileId)
		{
			Logger.Log(LogLevel.Verbose, $"DELETING MODFILE[{modId}_{fileId}]");
			DataStorage.TryDeleteInstalledMod(modId, fileId, out var result);
			if (!result.Succeeded())
			{
				Logger.Log(LogLevel.Error, $"Failed to delete modfile[{modId}_{fileId}]");
			}
			else
			{
				Logger.Log(LogLevel.Verbose, $"DELETED MODFILE[{modId}_{fileId}");
			}
			return await Task.FromResult(result);
		}

		public static async Task ShutdownOperations()
		{
			DisableModManagement();
			if (currentJob != null)
			{
				if (currentJob.zipOperation != null)
				{
					currentJob.zipOperation.Cancel();
					if (currentJob.zipOperation.GetOperation() != null)
					{
						await currentJob.zipOperation.GetOperation();
					}
				}
				currentJob?.downloadWebRequest?.cancel?.Invoke();
			}
			if (operation != null)
			{
				await operation;
			}
			creationTokens.Clear();
			previousJobs.Clear();
			taintedMods.Clear();
		}

		public static ProgressHandle GetCurrentOperationProgress()
		{
			if (currentJob == null || currentJob.progressHandle == null)
			{
				return null;
			}
			currentJob.progressHandle.modId = (ModId)currentJob.mod.modObject.id;
			return currentJob.progressHandle;
		}

		public static void InvokeModManagementDelegate(ModId modId, ModManagementEventType eventType, Result eventResult)
		{
			modManagementEventDelegate?.Invoke(eventType, modId, eventResult);
		}

		public static SubscribedModStatus GetModCollectionEntrysSubscribedModStatus(ModCollectionEntry mod)
		{
			ModId modId = (ModId)mod.modObject.id;
			long id = mod.modObject.modfile.id;
			long id2 = mod.currentModfile.id;
			if (taintedMods.Contains(modId))
			{
				return SubscribedModStatus.ProblemOccurred;
			}
			string directoryPath;
			if (ShouldThisModBeUninstalled(modId))
			{
				if (DataStorage.TryGetInstallationDirectory(modId, id2, out directoryPath))
				{
					return SubscribedModStatus.WaitingToUninstall;
				}
			}
			else
			{
				if (!DataStorage.TryGetInstallationDirectory(modId, id2, out directoryPath))
				{
					if (DataStorage.TryGetModfileArchive(modId, id, out directoryPath))
					{
						return SubscribedModStatus.WaitingToInstall;
					}
					return SubscribedModStatus.WaitingToDownload;
				}
				if (id2 != id)
				{
					return SubscribedModStatus.WaitingToUpdate;
				}
			}
			return SubscribedModStatus.Installed;
		}

		private static ModManagementJob GetNextModManagementJob()
		{
			if (!ShouldModManagementBeRunning())
			{
				return null;
			}
			ModManagementJob modManagementJob = null;
			if (uninstalledModsWithNoUserSubscriptions == null)
			{
				uninstalledModsWithNoUserSubscriptions = new List<ModId>();
			}
			else
			{
				uninstalledModsWithNoUserSubscriptions.Clear();
			}
			foreach (KeyValuePair<ModId, ModCollectionEntry> mod in ModCollectionManager.Registry.mods)
			{
				ModCollectionEntry value = mod.Value;
				if (!ShouldModManagementBeRunning())
				{
					return null;
				}
				if (value.modObject.game_id == Settings.server.gameId)
				{
					ModManagementOperationType nextJobTypeForModCollectionEntry = GetNextJobTypeForModCollectionEntry(value);
					switch (nextJobTypeForModCollectionEntry)
					{
					case ModManagementOperationType.Install:
						modManagementJob = new ModManagementJob
						{
							mod = value,
							type = nextJobTypeForModCollectionEntry
						};
						goto end_IL_00a3;
					default:
						modManagementJob = FilterJob(modManagementJob, value, nextJobTypeForModCollectionEntry);
						break;
					case ModManagementOperationType.None_AlreadyInstalled:
					case ModManagementOperationType.None_ErrorOcurred:
						break;
					}
				}
				continue;
				end_IL_00a3:
				break;
			}
			foreach (ModId uninstalledModsWithNoUserSubscription in uninstalledModsWithNoUserSubscriptions)
			{
				ModCollectionManager.Registry.mods.Remove(uninstalledModsWithNoUserSubscription);
			}
			return modManagementJob;
		}

		private static ModManagementJob FilterJob(ModManagementJob job, ModCollectionEntry mod, ModManagementOperationType jobType)
		{
			if (job == null)
			{
				job = new ModManagementJob
				{
					mod = mod,
					type = jobType
				};
			}
			if (jobType < job.type)
			{
				job = new ModManagementJob
				{
					mod = mod,
					type = jobType
				};
			}
			return job;
		}

		private static ModManagementOperationType GetNextJobTypeForModCollectionEntry(ModCollectionEntry mod)
		{
			ModId modId = (ModId)mod.modObject.id;
			long id = mod.modObject.modfile.id;
			long id2 = mod.currentModfile.id;
			if (taintedMods.Contains(modId))
			{
				return ModManagementOperationType.None_ErrorOcurred;
			}
			string directoryPath;
			if (ShouldThisModBeUninstalled(modId))
			{
				if (DataStorage.TryGetInstallationDirectory(modId, id2, out directoryPath))
				{
					return ModManagementOperationType.Uninstall;
				}
				uninstalledModsWithNoUserSubscriptions.Add(modId);
			}
			else
			{
				if (!DataStorage.TryGetInstallationDirectory(modId, id2, out directoryPath))
				{
					if (DataStorage.TryGetModfileArchive(modId, id, out var filePath))
					{
						if (!ValidateDownload_md5(mod.modObject.modfile.filehash.md5, filePath))
						{
							return ModManagementOperationType.Download;
						}
						return ModManagementOperationType.Install;
					}
					return ModManagementOperationType.Download;
				}
				if (id2 != id)
				{
					return ModManagementOperationType.Update;
				}
			}
			return ModManagementOperationType.None_AlreadyInstalled;
		}

		private static bool ShouldThisModBeUninstalled(ModId modId)
		{
			List<long> list = new List<long>();
			using (Dictionary<long, UserModCollectionData>.Enumerator enumerator = ModCollectionManager.Registry.existingUsers.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Value.subscribedMods.Contains(modId))
					{
						list.Add(enumerator.Current.Key);
					}
				}
			}
			if (list.Count == 0)
			{
				return true;
			}
			if (ModCollectionManager.Registry.mods.TryGetValue(modId, out var value))
			{
				if (list.Contains(ModCollectionManager.GetUserKey()))
				{
					return false;
				}
				if (value.uninstallIfNotSubscribedToCurrentSession)
				{
					return true;
				}
				return false;
			}
			Logger.Log(LogLevel.Warning, "A ModManagement check was made on a ModCollectionEntry that doesn't appear to exist anymore in the registry. This shouldn't happen.");
			return false;
		}

		public static bool ValidateDownload_md5(string correctMD5, string zippedFilepath)
		{
			string value = IOUtil.GenerateArchiveMD5(zippedFilepath);
			bool num = correctMD5.Equals(value);
			if (!num)
			{
				Logger.Log(LogLevel.Warning, "Failed to validate modfile archive with md5. This may be due to a download being corrupted or stopped before completion, such as from ModIOUnity.Shutdown()");
			}
			return num;
		}

		private static bool ShouldModManagementBeRunning()
		{
			if (!isModManagementEnabled || !ModIOUnityImplementation.IsAuthenticatedSessionValid(out var result))
			{
				return false;
			}
			if (!ModIOUnityImplementation.IsInitialized(out result))
			{
				DisableModManagement();
				return false;
			}
			return true;
		}

		public static void RemoveModFromTaintedJobs(ModId modid)
		{
			taintedMods.Remove(modid);
		}
	}
}
