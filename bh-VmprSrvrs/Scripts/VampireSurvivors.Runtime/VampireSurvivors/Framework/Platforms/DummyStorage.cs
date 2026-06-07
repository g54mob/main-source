using System;
using VampireSurvivors.Framework.Platforms.Saves;

namespace VampireSurvivors.Framework.Platforms
{
	public class DummyStorage : IPlatformSaveUtils, ILastErrorProvider, IPlatformSaveBackup
	{
		public ErroInfo LastError { get; }

		public bool IsReady => false;

		public bool ContinuePlayingWithoutSaving { get; set; }

		public void InitAsync(string containerName, string containerDisplayName, StorageOperationComplete onComplete)
		{
		}

		public StorageResult SetBlob(string blobName, byte[] data)
		{
			return default(StorageResult);
		}

		public void CommitAsync(StorageOperationComplete onComplete, CommitOptions options = CommitOptions.Default, bool createBackup = false)
		{
		}

		public void GetBlobsAsync(string blobName, StorageOperationCompleteWithData onComplete, bool skipCache = false)
		{
		}

		public void RequestNoFreeSpaceToSaveSystemDialog(Action onComplete, bool canContinueWithoutSaving = true)
		{
		}

		public void EraseAllAsync(StorageOperationComplete onComplete)
		{
		}

		public void Close()
		{
		}

		public void TryRestoreBlobAsync(string blobName, StorageOperationCompleteWithData onComplete, bool skipCache = false)
		{
		}

		public bool BackupExists(string blobName)
		{
			return false;
		}
	}
}
