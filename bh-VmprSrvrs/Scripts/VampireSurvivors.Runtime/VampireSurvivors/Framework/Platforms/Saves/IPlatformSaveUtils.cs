using System;

namespace VampireSurvivors.Framework.Platforms.Saves
{
	public interface IPlatformSaveUtils : ILastErrorProvider
	{
		bool IsReady { get; }

		bool ContinuePlayingWithoutSaving { get; set; }

		void InitAsync(string containerName, string containerDisplayName, StorageOperationComplete onComplete);

		StorageResult SetBlob(string blobName, byte[] data);

		void CommitAsync(StorageOperationComplete onComplete, CommitOptions options = CommitOptions.Default, bool createBackup = false);

		void GetBlobsAsync(string blobName, StorageOperationCompleteWithData onComplete, bool skipCache = false);

		void RequestNoFreeSpaceToSaveSystemDialog(Action onComplete, bool canContinueWithoutSaving = true);

		void EraseAllAsync(StorageOperationComplete onComplete);

		void Close();
	}
}
