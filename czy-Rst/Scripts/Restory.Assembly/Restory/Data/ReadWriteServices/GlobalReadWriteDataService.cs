using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Restory.Data.Locations;
using Restory.Data.ReadWriteServices.Interface;
using Restory.Data.ReadWriteServices.Interfaces;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.FullSerializerWrappers;
using Restory.Data.SaveLoad.Providers;
using Restory.Gameplay.SaveLoad.Exceptions;
using UnityEngine;
using Zenject;

namespace Restory.Data.ReadWriteServices
{
	public class GlobalReadWriteDataService : MonoBehaviour, IGameplayReadOnlyDataService, IReadDataService, IReadWriteDataService, IWriteDataService, IRemoveDataService
	{
		[Header("General settings")]
		[SerializeField]
		private SaveSystemSettings settings;

		private const int MAX_PROFILES_COUNT = 3;

		private SaveFileNameGenerator fileNameGenerator;

		private SaveFileNameSorter saveFileNameSorter;

		private CommonFullSerializer.Factory commonFsFactory;

		private SaveFileCompatibilityChecker saveFileCompatibilityChecker;

		private float lastSaveTimeSinceStartup;

		public bool IsBusy { get; private set; }

		public event Action<FileType> OnWriteBegin;

		public event Action<FileType> OnWriteCompleted;

		public event Action<FileType> OnWriteFailed;

		public event Action<FileType> OnReadBegin;

		public event Action<FileType> OnReadCompleted;

		public event Action<FileType> OnReadFailed;

		[Inject]
		private void Construct(SaveFileNameGenerator saveFileNameGenerator, SaveFileNameSorter saveFileNameSorter, CommonFullSerializer.Factory commonFsFactory, SaveFileCompatibilityChecker saveFileCompatibilityChecker)
		{
			fileNameGenerator = saveFileNameGenerator;
			this.saveFileNameSorter = saveFileNameSorter;
			this.commonFsFactory = commonFsFactory;
			this.saveFileCompatibilityChecker = saveFileCompatibilityChecker;
		}

		public async Task<T> ReadLastGameProgressAsync<T>(SaveFileNameParameters parameters) where T : class
		{
			IsBusy = true;
			try
			{
				if (!SaveFileExists(parameters))
				{
					return Activator.CreateInstance<T>();
				}
				string latestSaveRecord = GetLatestSaveRecord(parameters);
				if (string.IsNullOrEmpty(latestSaveRecord))
				{
					return Activator.CreateInstance<T>();
				}
				return await ReadFileUnsafeAsync<T>(latestSaveRecord);
			}
			catch (Exception data)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, data));
				this.OnReadFailed?.Invoke(FileType.GameSave);
				return Activator.CreateInstance<T>();
			}
			finally
			{
				IsBusy = false;
			}
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

		public DateTime GetLastGameProgressCreationDate(SaveFileNameParameters parameters)
		{
			DateTime result = DateTime.MinValue;
			if (!SaveFileExists(parameters))
			{
				return result;
			}
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(GetLatestSaveRecord(parameters));
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

		private async Task<bool> IsSaveFileCorrupted(string filePath)
		{
			if (!IsFileExists(filePath))
			{
				return false;
			}
			try
			{
				if (await ReadFileUnsafeAsync<SaveSystemSaveData>(filePath) == null)
				{
					return true;
				}
			}
			catch
			{
				return true;
			}
			return false;
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
					if (await ReadFileUnsafeAsync<SaveSystemSaveData>(record) == null)
					{
						SetFileAsCorrupted(record);
					}
				}
				catch
				{
					SetFileAsCorrupted(record);
				}
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

		private async Task<T> ReadFileUnsafeAsync<T>(string fullPath) where T : class
		{
			Debug.Log("[GlobalReadWriteDataService] Load from: " + fullPath);
			if (DataProviders.GetAsyncJsonProvider().FileExists(fullPath))
			{
				return await GetDataUnsafeAsync<T>(fullPath).ConfigureAwait(continueOnCapturedContext: false);
			}
			throw new FileNotFoundException();
		}

		public async Task<T> ReadDataAsync<T>(string filePath, FileType fileType) where T : class
		{
			IsBusy = true;
			try
			{
				Debug.Log("[GlobalReadWriteDataService] Load from: " + filePath);
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
				Debug.Log("[GlobalReadWriteDataService] Load from: " + filePath);
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
				Debug.Log("[GlobalReadWriteDataService] Save to: " + filePath);
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

		private async Task<T> GetDataUnsafeAsync<T>(string path) where T : class
		{
			return await FromJsonUnsafeTask<T>(await DataProviders.GetAsyncJsonProvider().LoadAsync(path));
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

		private Task<T> FromJsonUnsafeTask<T>(string jsonValue) where T : class
		{
			return Task.Run(() => FromJsonUnsafe<T>(jsonValue));
		}

		private T FromJsonUnsafe<T>(string jsonValue) where T : class
		{
			return commonFsFactory.Create().FromJsonUnsafe<T>(jsonValue);
		}

		private T FromJson<T>(string jsonValue, FileType fileType) where T : class
		{
			return commonFsFactory.Create().FromJson<T>(jsonValue, fileType, OnFailed);
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
			return commonFsFactory.Create().ToJson(data, delegate
			{
				OnFailed(fileType);
			});
		}

		public bool SaveFileExists(SaveFileNameParameters parameters)
		{
			return !string.IsNullOrEmpty(GetLatestSaveRecord(parameters));
		}

		public bool IsFileExists(string path)
		{
			return DataProviders.GetAsyncJsonProvider().FileExists(path);
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

		public void BackupSaveDataDirectory()
		{
			IJsonSaveDataProvider jsonProvider = DataProviders.GetJsonProvider();
			string text = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
			jsonProvider.CopyDirectory(directoryB: Path.Combine(settings.BackupDirectory, settings.WorkDirectory + "-" + text), directoryA: settings.WorkDirectory);
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
	}
}
