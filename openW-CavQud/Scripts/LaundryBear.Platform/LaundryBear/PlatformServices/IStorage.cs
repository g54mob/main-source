using System;
using System.IO;

namespace LaundryBear.PlatformServices
{
	public interface IStorage : IDisposable, IEquatable<IStorage>
	{
		bool IsMounted { get; }

		IUser AssociatedUser { get; }

		string RootPath { get; }

		void GetUsedStorageQuota(OnQuotaRemainingCheck callback);

		long GetTotalStorageQuota();

		StorageResult ExpandStorageQuota(long newSaveSize);

		void DirectoryExists(string path, OnDirectoryExistCheck callback);

		void FileExists(string path, OnFileExistCheck callback);

		bool IsPathRootedToMount(string path);

		string GetPathMount(string path);

		void CreateDirectory(string path, OnDirectoryCreate callback);

		void DeleteDirectory(string path, OnDirectoryDelete callback);

		void EnumerateFiles(string path, OnFilesEnumerated callback);

		void EnumerateDirectories(string path, OnDirectoriesEnumerated callback);

		void SaveBlob(string path, string contents, OnSaveBlobComplete callback);

		void SaveBlob(string path, byte[] contents, OnSaveBlobComplete callback);

		void LoadBlob(string path, OnLoadBlobStringComplete callback);

		void LoadBlob(string path, OnLoadBlobBytesComplete callback);

		void OpenStream(string path, FileMode mode, FileAccess access, Action<StorageResult, Stream> onCreate);

		void DeleteBlob(string path, OnDeleteComplete callback);

		void FileMetadata(string path, OnGetFileMetadataComplete callback);
	}
}
