using System;
using System.Threading;
using System.Threading.Tasks;
using Restory.Data.Locations;
using Restory.Data.ReadWriteServices.Interface;
using Restory.Data.ReadWriteServices.Interfaces;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using UnityEngine;

namespace Restory.Data.ReadWriteServices
{
	public class StubReadWriteDataService : MonoBehaviour, IReadWriteDataService, IReadDataService, IWriteDataService, IRemoveDataService, IGameplayReadWriteDataService, IGameplayReadOnlyDataService, IGameplayWriteOnlyDataService
	{
		public DateTime LastSaveDateTime => DateTime.Now;

		public bool IsBusy => false;

		public bool ShouldFailed { get; set; }

		public event Action<FileType> OnWriteBegin;

		public event Action<FileType> OnWriteCompleted;

		public event Action<FileType> OnWriteFailed;

		public event Action<FileType> OnReadBegin;

		public event Action<FileType> OnReadCompleted;

		public event Action<FileType> OnReadFailed;

		public void SaveAsync(Action onComplete)
		{
			this.OnWriteBegin?.Invoke(FileType.Unknown);
			if (ShouldFailed)
			{
				this.OnWriteFailed?.Invoke(FileType.Unknown);
			}
			else
			{
				this.OnWriteCompleted?.Invoke(FileType.Unknown);
			}
			onComplete?.Invoke();
		}

		public void LoadAsync(Action onComplete)
		{
			this.OnReadBegin?.Invoke(FileType.Unknown);
			if (ShouldFailed)
			{
				this.OnReadFailed?.Invoke(FileType.Unknown);
			}
			else
			{
				this.OnReadCompleted?.Invoke(FileType.Unknown);
			}
			onComplete?.Invoke();
		}

		public void DeleteAll(SaveFileNameParameters parameters)
		{
		}

		public void DeleteAll()
		{
		}

		public void DeleteFile(string filePath)
		{
		}

		public bool SaveFileExists(SaveFileNameParameters parameters)
		{
			return false;
		}

		public Task<SaveSystemSaveData> ReadLastGameProgressAsync(SaveFileNameParameters parameters)
		{
			return null;
		}

		public SaveSystemSaveData ReadLastGameProgress(SaveFileNameParameters parameters)
		{
			return null;
		}

		public Task<SaveSystemSaveData> TryGetUncorruptedSave(SaveFileNameParameters parameters)
		{
			return null;
		}

		public Task<int> GetCorruptedSaveFileProfileAsync(GameMode gameMode)
		{
			return null;
		}

		public bool IsFileExists(string path)
		{
			return false;
		}

		public Task WriteGameProgressAsync(SaveFileNameParameters parameters, GameplayProgressSaveData capturedGameplayProgress, CancellationToken cancellationTokenOnDestroy)
		{
			return Task.CompletedTask;
		}

		public Task<T> ReadDataAsync<T>(string path, FileType fileType) where T : class
		{
			return null;
		}

		public T ReadData<T>(string filePath, FileType fileType) where T : class
		{
			return null;
		}

		public Task WriteDataAsync<T>(string path, T data, FileType fileType) where T : class
		{
			return Task.CompletedTask;
		}

		public Task CheckCorruptedSaveFilesAsync(SaveFileNameParameters parameters)
		{
			return Task.CompletedTask;
		}

		public void BackupSaveDataDirectory()
		{
		}

		public Task<T> ReadLastGameProgressAsync<T>(SaveFileNameParameters parameters) where T : class
		{
			throw new NotImplementedException();
		}

		public DateTime GetLastGameProgressCreationDate(SaveFileNameParameters parameters)
		{
			return DateTime.MinValue;
		}
	}
}
