using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Restory.Data.Locations;
using Restory.Data.ReadWriteServices.Interface;
using Restory.Data.ReadWriteServices.Interfaces;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.FullSerializerWrappers;
using Restory.Data.SaveLoad.Providers;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.Gameplay.TextureMasks;
using UnityEngine;
using Zenject;

namespace Restory.Data.ReadWriteServices
{
	public class GameplayReadWriteCombinedDataService : MonoBehaviour, IGameplayReadWriteDataService, IGameplayReadOnlyDataService, IReadDataService, IGameplayWriteOnlyDataService, IWriteDataService, IRemoveDataService, IDisposable
	{
		[Header("General settings")]
		[SerializeField]
		private SaveSystemSettings settings;

		private const int MAX_PROFILES_COUNT = 3;

		private SaveFileNameGenerator fileNameGenerator;

		private SaveFileNameSorter saveFileNameSorter;

		private GameEntityFullSerializer.Factory fsFactory;

		private CorruptedDataService corruptedDataService;

		private IDiskSpaceService diskSpaceService;

		private TextureCacheService textureCacheService;

		private SaveFileCompatibilityChecker saveFileCompatibilityChecker;

		private GameplaySaveDataBinarySerializer binarySerializer;

		private float lastSaveTimeSinceStartup;

		private long totalPlayTime;

		private int saveIterations;

		public bool IsBusy { get; private set; }

		public DateTime LastSaveDateTime { get; private set; }

		public event Action<FileType> OnWriteBegin;

		public event Action<FileType> OnWriteCompleted;

		public event Action<FileType> OnWriteFailed;

		public event Action<FileType> OnReadBegin;

		public event Action<FileType> OnReadCompleted;

		public event Action<FileType> OnReadFailed;

		[Inject]
		private void Construct(SaveFileNameGenerator fileNameGenerator, SaveFileNameSorter saveFileNameSorter, GameEntityFullSerializer.Factory fsFactory, CorruptedDataService corruptedDataService, IDiskSpaceService diskSpaceService, TextureCacheService textureCacheService, SaveFileCompatibilityChecker saveFileCompatibilityChecker)
		{
			this.fileNameGenerator = fileNameGenerator;
			this.saveFileNameSorter = saveFileNameSorter;
			this.fsFactory = fsFactory;
			this.corruptedDataService = corruptedDataService;
			this.diskSpaceService = diskSpaceService;
			this.textureCacheService = textureCacheService;
			this.saveFileCompatibilityChecker = saveFileCompatibilityChecker;
			binarySerializer = new GameplaySaveDataBinarySerializer(fsFactory);
		}

		public async Task WriteGameProgressAsync(SaveFileNameParameters parameters, GameplayProgressSaveData capturedGameplayProgress, CancellationToken cancellationToken)
		{
			IsBusy = true;
			try
			{
				this.OnWriteBegin?.Invoke(FileType.GameSave);
				if (!diskSpaceService.IsEnoughDiskSpace())
				{
					throw new Exception("Not enough free space");
				}
				ThrowTestException();
				cancellationToken.ThrowIfCancellationRequested();
				SaveSystemSaveData capturedState = new SaveSystemSaveData
				{
					CreationDate = DateTime.Now.Ticks,
					GameVersion = Application.version,
					Iteration = saveIterations + 1,
					GameplayState = capturedGameplayProgress,
					GameMode = parameters.GameplayMode,
					TotalPlayTime = totalPlayTime + GetPassedTimeSinceLastSave(),
					HasData = true
				};
				await textureCacheService.WaitForAllTexturesConversionCompletion();
				byte[] textureData = textureCacheService.SerializeTextureData();
				GameplaySaveDataContainer saveDataContainer = new GameplaySaveDataContainer(capturedState, textureData);
				await WriteToFileAsync(parameters, saveDataContainer, cancellationToken);
				ReduceSaveRecordsCount(parameters);
				LastSaveDateTime = DateTime.Now;
				totalPlayTime = capturedState.TotalPlayTime;
				saveIterations = capturedState.Iteration;
				this.OnWriteCompleted?.Invoke(FileType.GameSave);
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				this.OnWriteFailed?.Invoke(FileType.GameSave);
				corruptedDataService.OnWriteFailed(FileType.GameSave);
				throw;
			}
			finally
			{
				IsBusy = false;
			}
		}

		public async Task<T> ReadLastGameProgressAsync<T>(SaveFileNameParameters parameters) where T : class
		{
			IsBusy = true;
			try
			{
				if (!SaveFileExists(parameters))
				{
					totalPlayTime = 0L;
					saveIterations = 0;
					return Activator.CreateInstance<T>();
				}
				string latestSaveRecord = GetLatestSaveRecord(parameters);
				if (string.IsNullOrEmpty(latestSaveRecord))
				{
					totalPlayTime = 0L;
					saveIterations = 0;
					return Activator.CreateInstance<T>();
				}
				byte[] binaryData = await DataProviders.GetAsyncBinaryProvider().LoadBinaryAsync(latestSaveRecord);
				GameplaySaveDataContainer gameplaySaveDataContainer = binarySerializer.Deserialize(binaryData, FileType.GameSave, this.OnReadFailed);
				textureCacheService.DeserializeTextureData(gameplaySaveDataContainer.TextureData);
				totalPlayTime = gameplaySaveDataContainer.GameData.TotalPlayTime;
				saveIterations = gameplaySaveDataContainer.GameData.Iteration;
				return gameplaySaveDataContainer.GameData as T;
			}
			catch (Exception data)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, data));
				this.OnReadFailed?.Invoke(FileType.GameSave);
				corruptedDataService.OnReadFailed(FileType.GameSave);
				return Activator.CreateInstance<T>();
			}
			finally
			{
				IsBusy = false;
			}
		}

		public DateTime GetLastGameProgressCreationDate(SaveFileNameParameters parameters)
		{
			DateTime result = DateTime.MinValue;
			if (!SaveFileExists(parameters))
			{
				return result;
			}
			string latestSaveRecord = GetLatestSaveRecord(parameters);
			if (string.IsNullOrEmpty(latestSaveRecord))
			{
				return result;
			}
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(latestSaveRecord);
			int num = fileNameWithoutExtension.IndexOf(settings.DateTimeSeparator, StringComparison.InvariantCulture);
			if (num < 1)
			{
				return result;
			}
			if (long.TryParse(fileNameWithoutExtension.Substring(num + 1), out var result2))
			{
				long value = result2;
				DateTime minValue = DateTime.MinValue;
				long ticks = minValue.Ticks;
				minValue = DateTime.MaxValue;
				result2 = Math.Clamp(value, ticks, minValue.Ticks);
				result = new DateTime(result2);
			}
			return result;
		}

		public async Task<int> GetCorruptedSaveFileProfileAsync(GameMode gameMode)
		{
			for (int i = 0; i < 3; i++)
			{
				int index = i + 1;
				SaveFileNameParameters parameters = new SaveFileNameParameters(gameMode, index);
				if (!SaveFileExists(parameters))
				{
					continue;
				}
				List<string> saveFiles = GetSaveFiles(parameters);
				foreach (string item in saveFiles)
				{
					if (await IsSaveFileCorrupted(item))
					{
						return index;
					}
				}
			}
			return -1;
		}

		public async Task CheckCorruptedSaveFilesAsync(SaveFileNameParameters parameters)
		{
			if (!SaveFileExists(parameters))
			{
				return;
			}
			List<string> records = GetSaveFiles(parameters);
			for (int i = records.Count - 1; i >= 0; i--)
			{
				string record = records[i];
				try
				{
					byte[] binaryData = await DataProviders.GetAsyncBinaryProvider().LoadBinaryAsync(record);
					if (binarySerializer.DeserializeUnsafe(binaryData).GameData == null)
					{
						SetFileAsCorrupted(record);
					}
				}
				catch (Exception exception)
				{
					SetFileAsCorrupted(record);
					Debug.LogException(exception);
				}
			}
		}

		public async Task<T> ReadDataAsync<T>(string filePath, FileType fileType) where T : class
		{
			IsBusy = true;
			try
			{
				Debug.Log("[GameplayReadWriteCombinedDataService] Load from: " + filePath);
				this.OnReadBegin?.Invoke(fileType);
				if (DataProviders.GetAsyncJsonProvider().FileExists(filePath))
				{
					T result = await GetDataAsync<T>(filePath, fileType);
					this.OnReadCompleted?.Invoke(fileType);
					return result;
				}
				return null;
			}
			catch (Exception data)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, data));
				this.OnReadFailed?.Invoke(fileType);
				return null;
			}
			finally
			{
				IsBusy = false;
			}
		}

		public T ReadData<T>(string filePath, FileType fileType) where T : class
		{
			IsBusy = true;
			try
			{
				Debug.Log("[GameplayReadWriteCombinedDataService] Load from: " + filePath);
				this.OnReadBegin?.Invoke(fileType);
				if (DataProviders.GetJsonProvider().FileExists(filePath))
				{
					T data = GetData<T>(filePath, fileType);
					this.OnReadCompleted?.Invoke(fileType);
					return data;
				}
				return null;
			}
			catch (Exception data2)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, data2));
				this.OnReadFailed?.Invoke(fileType);
				return null;
			}
			finally
			{
				IsBusy = false;
			}
		}

		public async Task WriteDataAsync<T>(string filePath, T data, FileType fileType) where T : class
		{
			IsBusy = true;
			try
			{
				this.OnWriteBegin?.Invoke(fileType);
				await WriteToFileAsync(data, filePath, fileType);
				Debug.Log("[GameplayReadWriteCombinedDataService] Save to: " + filePath);
				this.OnWriteCompleted?.Invoke(fileType);
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				this.OnWriteFailed?.Invoke(fileType);
			}
			finally
			{
				IsBusy = false;
			}
		}

		public bool SaveFileExists(SaveFileNameParameters parameters)
		{
			return !string.IsNullOrEmpty(GetLatestSaveRecord(parameters));
		}

		public bool IsFileExists(string path)
		{
			return DataProviders.GetAsyncJsonProvider().FileExists(path);
		}

		private long GetPassedTimeSinceLastSave()
		{
			float num = Time.realtimeSinceStartup - lastSaveTimeSinceStartup;
			lastSaveTimeSinceStartup = Time.realtimeSinceStartup;
			return TimeSpan.FromSeconds(num).Ticks;
		}

		private string GetLatestSaveRecord(SaveFileNameParameters parameters)
		{
			List<string> saveFiles = GetSaveFiles(parameters);
			saveFiles.Sort(saveFileNameSorter);
			for (int num = saveFiles.Count - 1; num >= 0; num--)
			{
				string text = saveFiles[num];
				if (saveFileCompatibilityChecker.CheckSaveFileCompatibility(text))
				{
					return text;
				}
			}
			return null;
		}

		private async Task<bool> IsSaveFileCorrupted(string filePath)
		{
			if (!IsFileExists(filePath))
			{
				return false;
			}
			try
			{
				byte[] binaryData = await DataProviders.GetAsyncBinaryProvider().LoadBinaryAsync(filePath);
				return binarySerializer.DeserializeUnsafe(binaryData).GameData == null;
			}
			catch
			{
				return true;
			}
		}

		private void SetFileAsCorrupted(string fullFilePath)
		{
			try
			{
				string fileName = Path.GetFileName(fullFilePath);
				string parentDirectory = GetParentDirectory(fullFilePath);
				string text = CreateCorruptedFilePath(fileName, parentDirectory);
				if (File.Exists(text))
				{
					fileName = $"{DateTime.Now.Ticks}{settings.DateTimeSeparator}{fileName}";
					text = CreateCorruptedFilePath(fileName, parentDirectory);
				}
				File.Move(fullFilePath, text);
			}
			catch (Exception arg)
			{
				Debug.LogError($"<color=red>Error during moving corrupted file\n{arg}</color>");
			}
		}

		private string CreateCorruptedFilePath(string fileName, string parentDirectory)
		{
			string path = settings.CorruptedPrefix + "." + fileName;
			return Path.Combine(parentDirectory, path);
		}

		private async Task WriteToFileAsync(SaveFileNameParameters parameters, GameplaySaveDataContainer saveDataContainer, CancellationToken cancellationToken)
		{
			string text = fileNameGenerator.TemporarySaveFileName(parameters);
			string temporaryRecordPath = Path.Combine(settings.WorkDirectory, text + ".tmp");
			Debug.Log("[GameplayReadWriteCombinedDataService] write to: \"" + temporaryRecordPath + "\" is started");
			byte[] binaryData = binarySerializer.Serialize(saveDataContainer, delegate
			{
				OnFailed(FileType.GameSave);
			});
			await DataProviders.GetAsyncBinaryProvider().SaveBinaryAsync(binaryData, temporaryRecordPath);
			Debug.Log("[GameplayReadWriteCombinedDataService] write to: \"" + temporaryRecordPath + "\" is done");
			if (!cancellationToken.IsCancellationRequested)
			{
				string text2 = fileNameGenerator.AutoSaveNameTemplate(parameters);
				string fullPath = Path.Combine(settings.WorkDirectory, string.Format("{0}{1}{2}{3}", text2, settings.IterationSeparator, saveDataContainer.GameData.Iteration, ".restory"));
				RenameFile(temporaryRecordPath, fullPath);
			}
		}

		private void RenameFile(string temporaryRecordPath, string fullPath)
		{
			DataProviders.GetAsyncJsonProvider().RenameFile(temporaryRecordPath, fullPath);
		}

		private T GetData<T>(string path, FileType fileType) where T : class
		{
			string text = DataProviders.GetJsonProvider().Load(path);
			if (string.IsNullOrEmpty(text))
			{
				Debug.LogException(new Exception("Failed to load file " + path));
				this.OnReadFailed?.Invoke(fileType);
				return null;
			}
			return FromJson<T>(text, fileType);
		}

		private async Task<T> GetDataAsync<T>(string path, FileType fileType) where T : class
		{
			string text = await DataProviders.GetAsyncJsonProvider().LoadAsync(path);
			if (string.IsNullOrEmpty(text))
			{
				Debug.LogException(new Exception("Failed to load file " + path));
				this.OnReadFailed?.Invoke(fileType);
				return null;
			}
			return FromJson<T>(text, fileType);
		}

		private T FromJson<T>(string jsonValue, FileType fileType) where T : class
		{
			return fsFactory.Create().FromJson<T>(jsonValue, fileType, OnFailed);
		}

		private async Task WriteToFileAsync(object data, string filePath, FileType fileType)
		{
			string jsonValue = await SerializeToJsonTask(data, fileType);
			await DataProviders.GetAsyncJsonProvider().SaveAsync(jsonValue, filePath);
		}

		private Task<string> SerializeToJsonTask(object data, FileType fileType)
		{
			return Task.Run(() => SerializeToJson(data, fileType));
		}

		private string SerializeToJson(object data, FileType fileType)
		{
			return fsFactory.Create().ToJson(data, delegate
			{
				OnFailed(fileType);
			});
		}

		private List<string> GetSaveFiles(SaveFileNameParameters parameters)
		{
			string value = fileNameGenerator.AutoSaveNameTemplate(parameters);
			string[] directoryContent = DataProviders.GetJsonProvider().GetDirectoryContent(settings.WorkDirectory);
			List<string> list = new List<string>(settings.MaxSaveRecordsSize);
			string[] array = directoryContent;
			foreach (string text in array)
			{
				if (text.Contains(value))
				{
					list.Add(text);
				}
			}
			return list;
		}

		private void ReduceSaveRecordsCount(SaveFileNameParameters parameters)
		{
			IJsonSaveDataProvider jsonProvider = DataProviders.GetJsonProvider();
			List<string> saveFiles = GetSaveFiles(parameters);
			saveFiles.Sort(saveFileNameSorter);
			while (saveFiles.Count > settings.MaxSaveRecordsSize)
			{
				string text = saveFiles.First();
				jsonProvider.RemoveFile(text);
				saveFiles.Remove(text);
			}
		}

		public void DeleteAll()
		{
			DataProviders.GetJsonProvider().RemoveDirectory(settings.WorkDirectory);
		}

		public void DeleteAll(SaveFileNameParameters parameters)
		{
			IJsonSaveDataProvider jsonProvider = DataProviders.GetJsonProvider();
			foreach (string saveFile in GetSaveFiles(parameters))
			{
				jsonProvider.RemoveFile(saveFile);
			}
		}

		private void OnFailed(FileType fileType)
		{
			this.OnReadFailed?.Invoke(fileType);
		}

		private string GetParentDirectory(string filePath)
		{
			string text = Path.GetDirectoryName(filePath);
			if (string.IsNullOrEmpty(text))
			{
				text = Path.Combine(Application.persistentDataPath, settings.WorkDirectory);
			}
			return Path.GetDirectoryName(text);
		}

		public void DeleteFile(string filePath)
		{
			DataProviders.GetJsonProvider().RemoveFile(filePath);
		}

		private static void ThrowTestException()
		{
		}

		public void Dispose()
		{
			this.OnWriteBegin = null;
			this.OnWriteCompleted = null;
			this.OnWriteFailed = null;
			this.OnReadBegin = null;
			this.OnReadCompleted = null;
			this.OnReadFailed = null;
		}
	}
}
