using System;
using System.Collections.Generic;
using System.IO;
using MessagePack;
using UnityEngine;
using Zio;
using Zio.FileSystems;

namespace Huey.Core.Utilities
{
	[Serializable]
	[MessagePackObject(false)]
	public class FileSystemInMemory : ISerializationCallbackReceiver
	{
		[Serializable]
		[MessagePackObject(false)]
		public class VFSEntity
		{
			[Key(0)]
			public string _fullPath;

			[Key(1)]
			public byte[] _data;

			[Key(3)]
			public long LastWriteTime;

			[Key(4)]
			public long LastAccessTime;

			[Key(5)]
			public long CreationTime;

			[IgnoreMember]
			public long Length => _data.Length;
		}

		[NonSerialized]
		private MemoryFileSystem _memoryFileSystem = new MemoryFileSystem();

		[SerializeField]
		[Key(0)]
		public List<VFSEntity> _files = new List<VFSEntity>();

		[SerializeField]
		[Key(1)]
		public List<string> _directories = new List<string>();

		private static object _fsLockObj = new object();

		[IgnoreMember]
		public bool SystemUpdated { get; set; }

		[IgnoreMember]
		public bool IsOperationRunning { get; private set; }

		private UPath MakePath(string path)
		{
			if (string.IsNullOrEmpty(path))
			{
				return null;
			}
			if (path[0] != '/')
			{
				return new UPath("/" + path);
			}
			return new UPath(path);
		}

		public void CopyFile(string sourcePath, string destPath, bool overwrite)
		{
			IsOperationRunning = true;
			try
			{
				lock (_fsLockObj)
				{
					_memoryFileSystem.CopyFile(MakePath(sourcePath), MakePath(destPath), overwrite);
					SystemUpdated = true;
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			IsOperationRunning = false;
		}

		public void CreateDirectory(string path)
		{
			IsOperationRunning = true;
			try
			{
				lock (_fsLockObj)
				{
					_memoryFileSystem.CreateDirectory(MakePath(path));
					SystemUpdated = true;
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			IsOperationRunning = false;
		}

		public void DeleteDirectory(string path)
		{
			IsOperationRunning = true;
			try
			{
				lock (_fsLockObj)
				{
					_memoryFileSystem.DeleteDirectory(MakePath(path), isRecursive: true);
					SystemUpdated = true;
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			IsOperationRunning = false;
		}

		public void DeleteFile(string path)
		{
			IsOperationRunning = true;
			try
			{
				lock (_fsLockObj)
				{
					_memoryFileSystem.DeleteFile(MakePath(path));
					SystemUpdated = true;
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			IsOperationRunning = false;
		}

		public bool DoesDirectoryExist(string path)
		{
			try
			{
				lock (_fsLockObj)
				{
					return _memoryFileSystem.DirectoryExists(MakePath(path));
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			return false;
		}

		public bool DoesFileExist(string path)
		{
			try
			{
				lock (_fsLockObj)
				{
					return _memoryFileSystem.FileExists(MakePath(path));
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			return false;
		}

		public Stream ReadFile(string path)
		{
			IsOperationRunning = true;
			try
			{
				lock (_fsLockObj)
				{
					MemoryStream memoryStream = new MemoryStream();
					using (Stream stream = _memoryFileSystem.OpenFile(MakePath(path), FileMode.Open, FileAccess.Read))
					{
						stream.Position = 0L;
						stream.CopyTo(memoryStream);
						stream.Close();
					}
					IsOperationRunning = false;
					return memoryStream;
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			IsOperationRunning = false;
			return null;
		}

		public long WriteFile(string path, Stream data)
		{
			IsOperationRunning = true;
			try
			{
				lock (_fsLockObj)
				{
					long length;
					using (Stream stream = _memoryFileSystem.OpenFile(MakePath(path), FileMode.Create, FileAccess.ReadWrite))
					{
						data.Position = 0L;
						data.CopyTo(stream);
						length = stream.Length;
						stream.Close();
					}
					SystemUpdated = true;
					IsOperationRunning = false;
					return length;
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			IsOperationRunning = false;
			return -1L;
		}

		public long GetFileLength(string path)
		{
			return _files.Find((VFSEntity f) => f._fullPath == path)?.Length ?? 0;
		}

		public byte[] SaveAsByteArray(bool force_compress)
		{
			try
			{
				MessagePackSerializerOptions messagePackSerializerOptions = MessagePackSerializer.DefaultOptions;
				if (force_compress)
				{
					messagePackSerializerOptions = messagePackSerializerOptions.WithCompression(MessagePackCompression.Lz4Block);
				}
				PrepareForSerialization();
				return MessagePackSerializer.Serialize(this, messagePackSerializerOptions);
			}
			catch (MessagePackSerializationException)
			{
				throw;
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				return null;
			}
		}

		public static FileSystemInMemory LoadFromByteArray(byte[] data, bool force_compress)
		{
			try
			{
				MessagePackSerializerOptions messagePackSerializerOptions = MessagePackSerializer.DefaultOptions;
				if (force_compress)
				{
					messagePackSerializerOptions = messagePackSerializerOptions.WithCompression(MessagePackCompression.Lz4Block);
				}
				FileSystemInMemory fileSystemInMemory = MessagePackSerializer.Deserialize<FileSystemInMemory>(data, messagePackSerializerOptions);
				fileSystemInMemory.PopulateFromSetData();
				return fileSystemInMemory;
			}
			catch (MessagePackSerializationException)
			{
				throw;
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				return null;
			}
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			PrepareForSerialization();
		}

		public void PrepareForSerialization()
		{
			IsOperationRunning = true;
			try
			{
				lock (_fsLockObj)
				{
					_directories.Clear();
					_files.Clear();
					MemoryFileSystem memoryFileSystem = _memoryFileSystem.Clone();
					foreach (FileSystemEntry item2 in memoryFileSystem.EnumerateFileSystemEntries(new UPath("/"), "*", SearchOption.AllDirectories))
					{
						if ((item2.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
						{
							_directories.Add(item2.Path.ToString());
							continue;
						}
						using Stream stream = memoryFileSystem.OpenFile(item2.Path, FileMode.Open, FileAccess.Read, FileShare.Read);
						byte[] array = new byte[stream.Length];
						stream.Read(array, 0, (int)stream.Length);
						VFSEntity item = new VFSEntity
						{
							_fullPath = item2.Path.ToString(),
							_data = array,
							CreationTime = _memoryFileSystem.GetCreationTime(item2.Path).Ticks,
							LastAccessTime = _memoryFileSystem.GetLastAccessTime(item2.Path).Ticks,
							LastWriteTime = _memoryFileSystem.GetLastWriteTime(item2.Path).Ticks
						};
						_files.Add(item);
						stream.Close();
					}
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			IsOperationRunning = false;
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			PopulateFromSetData();
		}

		public List<string> EnumerateFiles(string pathToDirectory)
		{
			IsOperationRunning = true;
			try
			{
				lock (_fsLockObj)
				{
					IEnumerable<UPath> enumerable = _memoryFileSystem.EnumerateFiles(MakePath(pathToDirectory));
					List<string> list = new List<string>();
					foreach (UPath item in enumerable)
					{
						list.Add(item.ToString());
					}
					IsOperationRunning = false;
					return list;
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			IsOperationRunning = false;
			return null;
		}

		public DateTime GetCreationTime(string _path)
		{
			return _memoryFileSystem.GetCreationTime(_path);
		}

		public DateTime GetLastWriteTime(string _path)
		{
			return _memoryFileSystem.GetLastWriteTime(_path);
		}

		public void PopulateFromSetData()
		{
			IsOperationRunning = true;
			try
			{
				lock (_fsLockObj)
				{
					_memoryFileSystem = new MemoryFileSystem();
					foreach (string directory in _directories)
					{
						string text = directory;
						if (!text.StartsWith("/"))
						{
							text = "/" + directory;
						}
						_memoryFileSystem.CreateDirectory(new UPath(text));
					}
					foreach (VFSEntity file in _files)
					{
						UPath path = new UPath(file._fullPath);
						using (Stream stream = _memoryFileSystem.CreateFile(path))
						{
							stream.Write(file._data, 0, file._data.Length);
							stream.Close();
						}
						if (file.CreationTime != 0L && file.LastWriteTime != 0L && file.LastAccessTime != 0L)
						{
							_memoryFileSystem.SetCreationTime(path, new DateTime(file.CreationTime));
							_memoryFileSystem.SetLastAccessTime(path, new DateTime(file.LastAccessTime));
							_memoryFileSystem.SetLastWriteTime(path, new DateTime(file.LastWriteTime));
						}
					}
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			IsOperationRunning = false;
		}
	}
}
