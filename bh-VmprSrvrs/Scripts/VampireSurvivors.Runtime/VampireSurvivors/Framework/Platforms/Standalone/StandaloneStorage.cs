using System;
using System.Collections.Generic;
using VampireSurvivors.Framework.Platforms.Saves;

namespace VampireSurvivors.Framework.Platforms.Standalone
{
	public class StandaloneStorage : IPlatformSaveUtils, ILastErrorProvider, IPlatformSaveBackup
	{
		public class Blob
		{
			private bool _mDirtyFlag;

			private byte[] _mData;

			public bool IsDirty => false;

			public bool IsEmpty => false;

			public byte[] Data => null;

			public void SetData(byte[] data)
			{
			}

			public void ClearDirty()
			{
			}

			public Blob(byte[] data, bool dirtyFlag = true)
			{
			}
		}

		private const string SAV_EXTENSION = ".sav";

		private const string BAK_EXTENSION = ".bak.sav";

		private Dictionary<string, Blob> _mData;

		private string _targetPath;

		private ErroInfo _mLastError;

		private bool _mInitialized;

		private const int HR_ERROR_HANDLE_DISK_FULL = -2147024857;

		private const int HR_ERROR_DISK_FULL = -2147024784;

		private const int HR_ERROR_SHARING_VIOLATION = -2147024864;

		public ErroInfo LastError => default(ErroInfo);

		public bool IsReady => false;

		public bool ContinuePlayingWithoutSaving { get; set; }

		public void EraseAllAsync(StorageOperationComplete onComplete)
		{
		}

		private string GetBackupBlobName(string orgBlobName)
		{
			return null;
		}

		public void CommitAsync(StorageOperationComplete onComplete, CommitOptions options, bool createBackup = false)
		{
		}

		private string GetBlobPath(string blobName)
		{
			return null;
		}

		public void TryRestoreBlobAsync(string blobName, StorageOperationCompleteWithData onComplete, bool skipCache = false)
		{
		}

		public bool BackupExists(string blobName)
		{
			return false;
		}

		public void GetBlobsAsync(string blobName, StorageOperationCompleteWithData onComplete, bool skipCache = false)
		{
		}

		private void GetBlobsAsyncDirect(string blobNameWithExtension, StorageOperationCompleteWithData onComplete, bool skipCache = false)
		{
		}

		public void RequestNoFreeSpaceToSaveSystemDialog(Action onComplete, bool canContinueWithoutSaving = true)
		{
		}

		public StorageResult SetBlob(string containerName, byte[] data)
		{
			return default(StorageResult);
		}

		protected virtual string GetTargetSavePath(string containerName)
		{
			return null;
		}

		public static string GetTargetPath(string containerName)
		{
			return null;
		}

		public void InitAsync(string containerName, string containerDisplayName, StorageOperationComplete onComplete)
		{
		}

		private StorageResult ToStorageResult(Exception ex)
		{
			return default(StorageResult);
		}

		public void Close()
		{
		}
	}
}
