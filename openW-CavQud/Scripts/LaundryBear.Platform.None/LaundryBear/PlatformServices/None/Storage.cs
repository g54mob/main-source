using System;
using System.IO;
using System.Security;
using System.Threading;
using Unity.Properties;
using UnityEngine;

namespace LaundryBear.PlatformServices.None
{
	internal class Storage : IStorage, IDisposable, IEquatable<IStorage>, ICanDelayShutdown
	{
		private int mainThreadID;

		private string m_rootPath;

		public bool IsMounted => true;

		public IUser AssociatedUser { get; private set; }

		public string RootPath => m_rootPath;

		public bool IsUserHandlingShutdownDelay { get; set; }

		public void BeginDelayShutdown()
		{
		}

		public void EndShutdownDelay()
		{
		}

		private bool IsOnMain()
		{
			return Thread.CurrentThread.ManagedThreadId == mainThreadID;
		}

		public bool IsPathRootedToMount(string path)
		{
			return Path.IsPathRooted(path);
		}

		public string GetPathMount(string path)
		{
			return Path.GetPathRoot(path);
		}

		internal Storage(string name)
		{
			mainThreadID = Thread.CurrentThread.ManagedThreadId;
			if (string.IsNullOrEmpty(name))
			{
				m_rootPath = Application.persistentDataPath;
			}
			else
			{
				m_rootPath = Combine(Application.persistentDataPath, name);
			}
			if (!Directory.Exists(RootPath))
			{
				Directory.CreateDirectory(RootPath);
			}
		}

		public string Combine(params string[] paths)
		{
			foreach (string text in paths)
			{
				if (text.StartsWith(Application.streamingAssetsPath))
				{
					Debug.LogWarning("Attempted to perform IO operation with a ROM path " + text + ". This is not allowed and could crash on platform, but might succeed on Standalone");
				}
			}
			return Path.Combine(paths);
		}

		private string EnsurePathRooted(string path)
		{
			if (!Path.IsPathRooted(path))
			{
				return Path.Combine(RootPath, path);
			}
			return path;
		}

		public void OpenStream(string path, FileMode mode, FileAccess access, Action<StorageResult, Stream> callback)
		{
			try
			{
				FileStream arg = File.Open(EnsurePathRooted(path), mode, access);
				callback(StorageResult.Success, arg);
			}
			catch (Exception exception)
			{
				StorageResult arg2 = ExceptionToStorageResult(exception);
				callback(arg2, null);
			}
		}

		public void DeleteBlob(string path, OnDeleteComplete callback)
		{
			string path2 = EnsurePathRooted(path);
			try
			{
				File.Delete(path2);
				callback(StorageResult.Success);
			}
			catch (ArgumentException)
			{
				callback(StorageResult.InvalidPath);
			}
			catch (DirectoryNotFoundException)
			{
				callback(StorageResult.DirectoryNotFound);
			}
			catch (PathTooLongException)
			{
				callback(StorageResult.PathTooLong);
			}
			catch (IOException)
			{
				callback(StorageResult.InUse);
			}
			catch (NotSupportedException)
			{
				callback(StorageResult.UnknownFailure);
			}
			catch (UnauthorizedAccessException)
			{
				callback(StorageResult.InvalidPermissions);
			}
		}

		public void DeleteBlobs(string[] paths, OnDeleteComplete callback)
		{
			foreach (string path in paths)
			{
				try
				{
					File.Delete(EnsurePathRooted(path));
				}
				catch
				{
					callback(StorageResult.UnknownFailure);
					return;
				}
			}
			callback(StorageResult.Success);
		}

		public void FileMetadata(string path, OnGetFileMetadataComplete callback)
		{
			try
			{
				FileInfo fileInfo = new FileInfo(EnsurePathRooted(path));
				callback(StorageResult.Success, new FileMetadata
				{
					SizeInBytes = fileInfo.Length
				});
			}
			catch (Exception exception)
			{
				callback(ExceptionToStorageResult(exception), default(FileMetadata));
			}
		}

		public void DirectoryExists(string path, OnDirectoryExistCheck callback)
		{
			if (Directory.Exists(EnsurePathRooted(path)))
			{
				callback(StorageResult.Success);
			}
			else
			{
				callback(StorageResult.DirectoryNotFound);
			}
		}

		public void FileExists(string path, OnFileExistCheck callback)
		{
			if (File.Exists(EnsurePathRooted(path)))
			{
				callback(StorageResult.Success);
			}
			else
			{
				callback(StorageResult.FileNotFound);
			}
		}

		public void EnumerateDirectories(string path, OnDirectoriesEnumerated callback)
		{
			string path2 = EnsurePathRooted(path);
			if (Directory.Exists(path2))
			{
				callback(StorageResult.Success, Directory.GetDirectories(path2));
			}
			else
			{
				callback(StorageResult.DirectoryNotFound, null);
			}
		}

		public void EnumerateFiles(string path, OnFilesEnumerated callback)
		{
			string path2 = EnsurePathRooted(path);
			if (Directory.Exists(path2))
			{
				callback(StorageResult.Success, Directory.GetFiles(path2));
			}
			else
			{
				callback(StorageResult.DirectoryNotFound, null);
			}
		}

		public void LoadBlob(string path, int offset, int length, OnLoadBlobBytesComplete callback)
		{
			throw new NotImplementedException();
		}

		public void LoadBlob(string path, OnLoadBlobStringComplete callback)
		{
			try
			{
				string contents = File.ReadAllText(EnsurePathRooted(path));
				callback(StorageResult.Success, contents);
			}
			catch (Exception exception)
			{
				callback(ExceptionToStorageResult(exception), null);
			}
		}

		public void LoadBlob(string path, OnLoadBlobBytesComplete callback)
		{
			byte[] array = null;
			try
			{
				array = File.ReadAllBytes(EnsurePathRooted(path));
				callback(StorageResult.Success, array);
			}
			catch (Exception exception)
			{
				callback(ExceptionToStorageResult(exception), null);
			}
		}

		public void LoadBlobs(string[] filenames, OnLoadBlobsStringComplete callback)
		{
			(string, string)[] array = new(string, string)[filenames.Length];
			for (int i = 0; i < filenames.Length; i++)
			{
				try
				{
					string path = EnsurePathRooted(filenames[i]);
					array[i] = (filenames[i], File.ReadAllText(path));
				}
				catch (Exception exception)
				{
					callback(ExceptionToStorageResult(exception), null);
					return;
				}
			}
			callback(StorageResult.Success, array);
		}

		public void LoadBlobs(string[] paths, OnLoadBlobsBytesComplete callback)
		{
			(string, byte[])[] array = new(string, byte[])[paths.Length];
			for (int i = 0; i < paths.Length; i++)
			{
				try
				{
					string path = EnsurePathRooted(paths[i]);
					array[i] = (paths[i], File.ReadAllBytes(path));
				}
				catch (Exception exception)
				{
					callback(ExceptionToStorageResult(exception), null);
					return;
				}
			}
			callback(StorageResult.Success, array);
		}

		public void SaveBlob(string path, string contents, OnSaveBlobComplete callback)
		{
			using (new DelayShutdownScope_Platform(this))
			{
				try
				{
					string path2 = EnsurePathRooted(path);
					Directory.CreateDirectory(Path.GetDirectoryName(path2));
					File.WriteAllText(path2, contents);
					callback(StorageResult.Success);
				}
				catch (Exception exception)
				{
					callback(ExceptionToStorageResult(exception));
				}
			}
		}

		public void SaveBlob(string path, byte[] contents, OnSaveBlobComplete callback)
		{
			using (new DelayShutdownScope_Platform(this))
			{
				try
				{
					string path2 = EnsurePathRooted(path);
					Directory.CreateDirectory(Path.GetDirectoryName(path2));
					File.WriteAllBytes(path2, contents);
					callback(StorageResult.Success);
				}
				catch (Exception exception)
				{
					callback(ExceptionToStorageResult(exception));
				}
			}
		}

		public void SaveBlob(string path, int offset, int length, byte[] contents, OnSaveBlobComplete callback)
		{
			throw new NotImplementedException();
		}

		public void SaveBlobs((string, string)[] blobs, OnSaveBlobComplete callback)
		{
			using (new DelayShutdownScope_Platform(this))
			{
				for (int i = 0; i < blobs.Length; i++)
				{
					(string, string) tuple = blobs[i];
					try
					{
						string path = EnsurePathRooted(tuple.Item1);
						Directory.CreateDirectory(Path.GetDirectoryName(path));
						File.WriteAllText(path, tuple.Item2);
						callback(StorageResult.Success);
					}
					catch (Exception exception)
					{
						callback(ExceptionToStorageResult(exception));
					}
				}
			}
		}

		public void SaveBlobs((string, byte[])[] blobs, OnSaveBlobComplete callback)
		{
			using (new DelayShutdownScope_Platform(this))
			{
				for (int i = 0; i < blobs.Length; i++)
				{
					(string, byte[]) tuple = blobs[i];
					try
					{
						string path = EnsurePathRooted(tuple.Item1);
						Directory.CreateDirectory(Path.GetDirectoryName(path));
						File.WriteAllBytes(path, tuple.Item2);
						callback(StorageResult.Success);
					}
					catch (Exception exception)
					{
						callback(ExceptionToStorageResult(exception));
					}
				}
			}
		}

		public void Dispose()
		{
		}

		public void GetUsedStorageQuota(OnQuotaRemainingCheck callback)
		{
			callback(StorageResult.Success, GetDirectorySize(RootPath));
		}

		public long GetTotalStorageQuota()
		{
			DriveInfo[] drives = DriveInfo.GetDrives();
			foreach (DriveInfo driveInfo in drives)
			{
				if (driveInfo.Name.StartsWith(Path.GetPathRoot(Path.GetFullPath(Application.persistentDataPath))))
				{
					return driveInfo.AvailableFreeSpace;
				}
			}
			return 0L;
		}

		public StorageResult ExpandStorageQuota(long newSaveSize)
		{
			return StorageResult.Success;
		}

		public bool Equals(IStorage other)
		{
			return true;
		}

		private static long GetDirectorySize(string path)
		{
			return GetDirectorySize(new DirectoryInfo(path));
		}

		private static long GetDirectorySize(DirectoryInfo directoryInfo)
		{
			long num = 0L;
			FileInfo[] files = directoryInfo.GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				num += fileInfo.Length;
			}
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			foreach (DirectoryInfo directoryInfo2 in directories)
			{
				num += GetDirectorySize(directoryInfo2);
			}
			return num;
		}

		private StorageResult ExceptionToStorageResult(Exception exception)
		{
			if (!(exception is InvalidPathException) && !(exception is ArgumentException))
			{
				if (!(exception is DirectoryNotFoundException))
				{
					if (!(exception is FileNotFoundException))
					{
						if (!(exception is PathTooLongException))
						{
							if (!(exception is IOException))
							{
								if (!(exception is NotSupportedException))
								{
									if (exception is UnauthorizedAccessException || exception is SecurityException)
									{
										return StorageResult.InvalidPermissions;
									}
									return StorageResult.UnknownFailure;
								}
								return StorageResult.UnknownFailure;
							}
							return StorageResult.InUse;
						}
						return StorageResult.PathTooLong;
					}
					return StorageResult.FileNotFound;
				}
				return StorageResult.DirectoryNotFound;
			}
			return StorageResult.InvalidPath;
		}

		public void CreateDirectory(string path, OnDirectoryCreate callback)
		{
			using (new DelayShutdownScope_Platform(this))
			{
				try
				{
					Directory.CreateDirectory(EnsurePathRooted(path));
					callback(StorageResult.Success);
				}
				catch (Exception ex)
				{
					if (ex is IOException)
					{
						callback(StorageResult.InvalidPath);
					}
					else
					{
						callback(ExceptionToStorageResult(ex));
					}
				}
			}
		}

		public void DeleteDirectory(string path, OnDirectoryDelete callback)
		{
			using (new DelayShutdownScope_Platform(this))
			{
				try
				{
					Directory.Delete(EnsurePathRooted(path), recursive: true);
					callback(StorageResult.Success);
				}
				catch (Exception ex)
				{
					if (ex is IOException)
					{
						callback(StorageResult.InvalidPath);
					}
					else
					{
						callback(ExceptionToStorageResult(ex));
					}
				}
			}
		}

		public void DeleteDirectories(string[] paths, OnDirectoryDelete callback)
		{
			using (new DelayShutdownScope_Platform(this))
			{
				foreach (string path in paths)
				{
					try
					{
						Directory.Delete(EnsurePathRooted(path), recursive: true);
						callback(StorageResult.Success);
					}
					catch (Exception ex)
					{
						if (ex is IOException)
						{
							callback(StorageResult.InvalidPath);
						}
						else
						{
							callback(ExceptionToStorageResult(ex));
						}
						break;
					}
				}
			}
		}
	}
}
