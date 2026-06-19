using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace ModIO.Implementation.Platform
{
	internal class SystemIODataService : IUserDataService, IDataService, IPersistentDataService, ITempDataService
	{
		[Serializable]
		internal struct GlobalSettingsFile
		{
			public string RootLocalStoragePath;
		}

		public static readonly string PersistentDataRootDirectory = Environment.GetEnvironmentVariable("public") + "/mod.io";

		public static readonly string UserRootDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/mod.io";

		public static readonly string TempRootDirectory = Application.temporaryCachePath;

		public static readonly string GlobalSettingsFilePath = UserRootDirectory + "/globalsettings.json";

		private string rootDir;

		public string RootDirectory => rootDir;

		Result IUserDataService.Initialize(string userProfileIdentifier, long gameId, BuildSettings settings)
		{
			rootDir = UserRootDirectory + "/" + gameId.ToString("00000") + "/" + userProfileIdentifier;
			Result result = SystemIOWrapper.CreateDirectory(rootDir);
			if (result.Succeeded())
			{
				Logger.Log(LogLevel.Verbose, "Initialized SystemIODataService for User Data: " + rootDir);
			}
			else
			{
				Logger.Log(LogLevel.Error, "Failed to initialize SystemIODataService for User Data. \n.rootDirectory=" + rootDir + " \n.result:[" + result.code.ToString("00000") + "]");
				result = ResultBuilder.Create(20020u);
			}
			return result;
		}

		Result IPersistentDataService.Initialize(long gameId, BuildSettings settings)
		{
			rootDir = PersistentDataRootDirectory + "/" + gameId;
			string text = rootDir;
			ResultAnd<byte[]> resultAnd = SystemIOWrapper.ReadFile(GlobalSettingsFilePath);
			Result result = resultAnd.result;
			string text2 = UserData.instance?.rootLocalStoragePath;
			GlobalSettingsFile jsonObject;
			if (!string.IsNullOrEmpty(text2))
			{
				Logger.Log(LogLevel.Verbose, "RootLocalStoragePath loaded from existing user.json\ndirectory=" + text2);
				text = text2;
			}
			else if (result.Succeeded() && IOUtil.TryParseUTF8JSONData<GlobalSettingsFile>(resultAnd.value, out jsonObject, out result))
			{
				Logger.Log(LogLevel.Verbose, "RootLocalStoragePath loaded from existing globalsettings.json\ndirectory=" + jsonObject.RootLocalStoragePath);
				text = jsonObject.RootLocalStoragePath + "/" + gameId;
			}
			else
			{
				if (result.code != 20401 && result.code != 20420)
				{
					string logMessage = "Unable to initialize the persistent data service. globalsettings.json could not be parsed to load in the root data directory. FilePath: " + GlobalSettingsFilePath + " - Result: [" + result.code + "]";
					Logger.Log(LogLevel.Error, logMessage);
					return result;
				}
				jsonObject = new GlobalSettingsFile
				{
					RootLocalStoragePath = PersistentDataRootDirectory
				};
				byte[] data = IOUtil.GenerateUTF8JSONData(jsonObject);
				SystemIOWrapper.WriteFile(GlobalSettingsFilePath, data);
				Logger.Log(LogLevel.Verbose, "RootLocalStoragePath written to new globalsettings.json");
			}
			rootDir = text;
			Logger.Log(LogLevel.Verbose, "Initialized SystemIODataService for Persistent Data: " + rootDir);
			return ResultBuilder.Success;
		}

		Result ITempDataService.Initialize(long gameId, BuildSettings settings)
		{
			rootDir = TempRootDirectory + "/" + gameId;
			Logger.Log(LogLevel.Verbose, "Initialized SystemIODataService for Temp Data: " + rootDir);
			return ResultBuilder.Success;
		}

		public ModIOFileStream OpenReadStream(string filePath, out Result result)
		{
			return SystemIOWrapper.OpenReadStream(filePath, out result);
		}

		public ModIOFileStream OpenWriteStream(string filePath, out Result result)
		{
			return SystemIOWrapper.OpenWriteStream(filePath, out result);
		}

		public async Task<ResultAnd<byte[]>> ReadFileAsync(string filePath)
		{
			return await SystemIOWrapper.ReadFileAsync(filePath);
		}

		public ResultAnd<byte[]> ReadFile(string filePath)
		{
			return SystemIOWrapper.ReadFile(filePath);
		}

		public async Task<Result> WriteFileAsync(string filePath, byte[] data)
		{
			return await SystemIOWrapper.WriteFileAsync(filePath, data);
		}

		public Result WriteFile(string filePath, byte[] data)
		{
			return SystemIOWrapper.WriteFile(filePath, data);
		}

		public Result DeleteFile(string filePath)
		{
			return SystemIOWrapper.DeleteFileGetResult(filePath);
		}

		public Result DeleteDirectory(string directoryPath)
		{
			return SystemIOWrapper.DeleteDirectory(directoryPath);
		}

		public Result MoveDirectory(string directoryPath, string newDirectoryPath)
		{
			return SystemIOWrapper.MoveDirectory(directoryPath, newDirectoryPath);
		}

		public bool TryCreateParentDirectory(string path)
		{
			Result result;
			return SystemIOWrapper.TryCreateParentDirectory(path, out result);
		}

		public async Task<bool> IsThereEnoughDiskSpaceFor(long bytes)
		{
			try
			{
				DriveInfo driveInfo = new DriveInfo(Path.GetPathRoot(new FileInfo(PersistentDataRootDirectory).FullName));
				return bytes < driveInfo.AvailableFreeSpace;
			}
			catch (Exception value)
			{
				Console.WriteLine(value);
				throw;
			}
		}

		public bool FileExists(string filePath)
		{
			Result result;
			return SystemIOWrapper.FileExists(filePath, out result);
		}

		public Result GetFileSizeAndHash(string filePath, out long fileSize, out string fileHash)
		{
			return SystemIOWrapper.GetFileSizeAndHash(filePath, out fileSize, out fileHash);
		}

		public bool DirectoryExists(string directoryPath)
		{
			return SystemIOWrapper.DirectoryExists(directoryPath);
		}

		public ResultAnd<List<string>> ListAllFiles(string directoryPath)
		{
			return SystemIOWrapper.ListAllFiles(directoryPath);
		}
	}
}
