using System;
using VampireSurvivors.Framework.Platforms.Saves;

namespace VampireSurvivors.Framework.Platforms.SteamworksIntegration
{
	public class SteamworksCloudStorage : IPlatformSaveUtils, ILastErrorProvider
	{
		private bool m_IsReady;

		private ErroInfo m_LastError;

		private byte[] m_LastBlobData;

		private string m_LastBlobFilename;

		public bool IsReady => false;

		public bool ContinuePlayingWithoutSaving { get; set; }

		public ErroInfo LastError => default(ErroInfo);

		private void FailWithLastError(StorageResult result, string msg, StorageOperationComplete callback)
		{
		}

		public void Close()
		{
		}

		public void EraseAllAsync(StorageOperationComplete onComplete)
		{
		}

		public void GetBlobsAsync(string blobName, StorageOperationCompleteWithData onComplete, bool skipCache = false)
		{
		}

		public void RequestNoFreeSpaceToSaveSystemDialog(Action onComplete, bool canContinueWithoutSaving = true)
		{
		}

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
	}
}
