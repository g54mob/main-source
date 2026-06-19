using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ModIO.Implementation.Platform;
using ModIO.Util;

namespace ModIO.Implementation
{
	internal static class DataStorage
	{
		internal static TaskQueueRunner taskRunner = new TaskQueueRunner(1, runsAutomatically: true);

		private static Mutex FileWriteMutex = new Mutex();

		public static IPersistentDataService persistent;

		public static IUserDataService user;

		public static ITempDataService temp;

		private const string UserDataFilePath = "user.json";

		public static Mutex GetFileWriteMutex()
		{
			return FileWriteMutex;
		}

		public static async Task<Result> SaveUserDataAsync()
		{
			byte[] data = IOUtil.GenerateUTF8JSONData(UserData.instance);
			return await user.WriteFileAsync(user.RootDirectory + "/user.json", data);
		}

		public static Result SaveUserData()
		{
			byte[] data = IOUtil.GenerateUTF8JSONData(UserData.instance);
			return user.WriteFile(user.RootDirectory + "/user.json", data);
		}

		public static async Task<Result> LoadUserDataAsync()
		{
			ResultAnd<byte[]> resultAnd = await user.ReadFileAsync(user.RootDirectory + "/user.json");
			Result result = resultAnd.result;
			if (result.Succeeded() && IOUtil.TryParseUTF8JSONData<UserData>(resultAnd.value, out var jsonObject, out result))
			{
				UserData.instance = jsonObject;
			}
			return result;
		}

		public static Result LoadUserData()
		{
			ResultAnd<byte[]> resultAnd = user.ReadFile(user.RootDirectory + "/user.json");
			if (resultAnd.result.Succeeded() && IOUtil.TryParseUTF8JSONData<UserData>(resultAnd.value, out var jsonObject, out resultAnd.result))
			{
				UserData.instance = jsonObject;
			}
			else
			{
				UserData.instance = new UserData();
			}
			return ResultBuilder.Success;
		}

		public static string GenerateImageCacheFilePath(string imageURL)
		{
			if (string.IsNullOrEmpty(imageURL))
			{
				Logger.Log(LogLevel.Verbose, ":INTERNAL: Attempted to generate a file path for a NULL/Empty image URL.");
				return null;
			}
			string text = IOUtil.GenerateMD5(imageURL);
			return temp.RootDirectory + "/images/" + text + ".png";
		}

		public static Result DeleteStoredImage(string imageURL)
		{
			if (GenerateImageCacheFilePath(imageURL) == null)
			{
				return ResultBuilder.Create(20507u);
			}
			return temp.DeleteFile(imageURL);
		}

		public static ResultAnd<ModIOFileStream> GetImageFileReadStream(string imageURL)
		{
			Result result;
			ModIOFileStream value = temp.OpenReadStream(GenerateImageCacheFilePath(imageURL), out result);
			return ResultAnd.Create(result, value);
		}

		public static ResultAnd<ModIOFileStream> GetImageFileWriteStream(string imageURL)
		{
			Result result;
			ModIOFileStream value = temp.OpenWriteStream(GenerateImageCacheFilePath(imageURL), out result);
			return ResultAnd.Create(result, value);
		}

		public static async Task<ResultAnd<byte[]>> TryRetrieveImageBytes(string imageURL)
		{
			string filePath = GenerateImageCacheFilePath(imageURL);
			if (filePath == null)
			{
				return ResultAnd.Create<byte[]>(20507u, null);
			}
			ResultAnd<byte[]> resultAnd = await taskRunner.AddTask(TaskPriority.HIGH, 1, async () => await temp.ReadFileAsync(filePath));
			if (!resultAnd.result.Succeeded())
			{
				return ResultAnd.Create<byte[]>(resultAnd.result, null);
			}
			return ResultAnd.Create(0u, resultAnd.value);
		}

		public static string GenerateExtractionDirectoryPath()
		{
			return persistent.RootDirectory + "/installation";
		}

		public static string GenerateInstallationDirectoryPath(long modId, long modfileId)
		{
			return $"{persistent.RootDirectory}/mods/{modId}_{modfileId}";
		}

		public static string GenerateModfileDetailsDirectoryPath(string directory)
		{
			Logger.Log(LogLevel.Verbose, "Not Implemented Yet");
			return directory;
		}

		public static string GenerateModfileArchiveFilePath(long modId, long modfileId)
		{
			return $"{temp.RootDirectory}/{modId}_{modfileId}.zip";
		}

		public static bool TryGetInstallationDirectory(long modId, long modfileId, out string directoryPath)
		{
			directoryPath = GenerateInstallationDirectoryPath(modId, modfileId);
			return persistent.DirectoryExists(directoryPath);
		}

		public static bool TryGetModfileDetailsDirectory(string directoryPath, out string properDirectory)
		{
			properDirectory = GenerateModfileDetailsDirectoryPath(directoryPath);
			return persistent.DirectoryExists(directoryPath);
		}

		public static bool TryGetModfileArchive(long modId, long modfileId, out string filePath)
		{
			filePath = GenerateModfileArchiveFilePath(modId, modfileId);
			return temp.FileExists(filePath);
		}

		public static bool TryDeleteModfileArchive(long modId, long modfileId, out Result result)
		{
			result = ResultBuilder.Success;
			string filePath = GenerateModfileArchiveFilePath(modId, modfileId);
			if (temp.FileExists(filePath))
			{
				result = temp.DeleteFile(filePath);
				return result.Succeeded();
			}
			return true;
		}

		public static bool TryDeleteInstalledMod(long modId, long modfileId, out Result result)
		{
			string directoryPath = GenerateInstallationDirectoryPath(modId, modfileId);
			result = persistent.DeleteDirectory(directoryPath);
			return result.Succeeded();
		}

		public static void DeleteExtractionDirectory()
		{
			persistent.DeleteDirectory(GenerateExtractionDirectoryPath());
		}

		public static Result MakeInstallationFromExtractionDirectory(long modId, long modfileId)
		{
			string text = GenerateExtractionDirectoryPath();
			string text2 = GenerateInstallationDirectoryPath(modId, modfileId);
			Result result;
			try
			{
				result = persistent.DeleteDirectory(text2);
				if (result.Succeeded() && persistent.TryCreateParentDirectory(text2))
				{
					result = persistent.MoveDirectory(text, text2);
					if (!result.Succeeded())
					{
						Logger.Log(LogLevel.Error, "Failed to move the extracted files into the proper directory.\n.src=" + text + "\n.dest=" + text2);
					}
					else
					{
						Logger.Log(LogLevel.Verbose, "Moved the extracted files into the proper directory.\n.src=" + text + "\n.dest=" + text2);
					}
				}
			}
			catch (Exception ex)
			{
				Logger.Log(LogLevel.Warning, "Unhandled error when attempting to rename the extraction directory.\n.src=" + text + "\n.dest=" + text2 + "\n.Exception:" + ex.Message);
				result = ResultBuilder.Create(20423u);
			}
			return result;
		}

		public static ResultAnd<string> GetModfileArchivePathIfValid(long modId, long modfileId, long expectedSize, string expectedHash)
		{
			string text = GenerateModfileArchiveFilePath(modId, modfileId);
			long fileWithSize;
			string fileHash;
			Result fileSizeAndHash = temp.GetFileSizeAndHash(text, out fileWithSize, out fileHash);
			if (!fileSizeAndHash.Succeeded())
			{
				return ResultAnd.Create<string>(fileSizeAndHash, null);
			}
			if (expectedSize != fileWithSize)
			{
				return ResultAnd.Create<string>(20504u, null);
			}
			if (expectedHash != fileHash)
			{
				return ResultAnd.Create<string>(20505u, null);
			}
			return ResultAnd.Create(ResultBuilder.Success, text);
		}

		public static string GenerateSystemRegistryFilePath()
		{
			return persistent.RootDirectory + "/state.json";
		}

		public static async Task<Result> SaveSystemRegistry(ModCollectionRegistry registry)
		{
			string filePath = GenerateSystemRegistryFilePath();
			byte[] data = IOUtil.GenerateUTF8JSONData(registry);
			return await taskRunner.AddTask(TaskPriority.HIGH, 1, async () => await persistent.WriteFileAsync(filePath, data));
		}

		public static async Task<ResultAnd<ModCollectionRegistry>> LoadSystemRegistryAsync()
		{
			string filePath = GenerateSystemRegistryFilePath();
			if (!persistent.FileExists(filePath))
			{
				return ResultAnd.Create(ResultBuilder.Success, new ModCollectionRegistry());
			}
			ResultAnd<byte[]> resultAnd = await persistent.ReadFileAsync(filePath);
			Result result = resultAnd.result;
			ModCollectionRegistry jsonObject = null;
			if (result.Succeeded())
			{
				IOUtil.TryParseUTF8JSONData<ModCollectionRegistry>(resultAnd.value, out jsonObject, out result);
			}
			return ResultAnd.Create(result, jsonObject);
		}

		public static ResultAnd<ModCollectionRegistry> LoadSystemRegistry()
		{
			string filePath = GenerateSystemRegistryFilePath();
			if (!persistent.FileExists(filePath))
			{
				return ResultAnd.Create(ResultBuilder.Success, new ModCollectionRegistry());
			}
			ResultAnd<byte[]> resultAnd = persistent.ReadFile(filePath);
			Result result = resultAnd.result;
			ModCollectionRegistry jsonObject = null;
			if (result.Succeeded())
			{
				IOUtil.TryParseUTF8JSONData<ModCollectionRegistry>(resultAnd.value, out jsonObject, out result);
			}
			return ResultAnd.Create(result, jsonObject);
		}

		public static ModIOFileStream OpenArchiveReadStream(string filePath, out Result result)
		{
			return temp.OpenReadStream(filePath, out result);
		}

		public static ModIOFileStream OpenArchiveReadStream(long modId, long modfileId, out Result result)
		{
			return OpenArchiveReadStream(GenerateModfileArchiveFilePath(modId, modfileId), out result);
		}

		public static ModIOFileStream OpenArchiveEntryOutputStream(string relativePath, out Result result)
		{
			string filePath = GenerateExtractionDirectoryPath() + "/" + relativePath;
			return persistent.OpenWriteStream(filePath, out result);
		}

		public static ModIOFileStream CreateArchiveDownloadStream(string absolutePath, out Result result)
		{
			return temp.OpenWriteStream(absolutePath, out result);
		}

		public static IEnumerable<ResultAnd<ModIOFileStream>> IterateFilesInDirectory(string directoryPath)
		{
			IDataService dataService = persistent;
			List<string> list = null;
			uint resultCode = ((dataService == null) ? 20450u : 0u);
			if (resultCode == 0)
			{
				ResultAnd<List<string>> resultAnd = dataService.ListAllFiles(directoryPath);
				resultCode = resultAnd.result.code;
				list = resultAnd.value;
			}
			if (resultCode == 0)
			{
				foreach (string item in list)
				{
					Result result;
					ModIOFileStream value = dataService.OpenReadStream(item, out result);
					if (result.Succeeded())
					{
						yield return ResultAnd.Create(result, value);
						continue;
					}
					Logger.Log(LogLevel.Error, $"Failed open stream. Result: [{result.code};{result.code_api}]");
					resultCode = result.code;
					break;
				}
			}
			if (resultCode != 0)
			{
				yield return ResultAnd.Create<ModIOFileStream>(20450u, null);
			}
		}
	}
}
