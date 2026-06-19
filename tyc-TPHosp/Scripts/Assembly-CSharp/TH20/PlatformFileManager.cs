using System;
using System.IO;
using System.Text;

namespace TH20
{
	public static class PlatformFileManager
	{
		private static readonly PlatformSaveBase _platformSave = new StandaloneSave();

		public static string CloudDirectory => _platformSave.CloudDirectory;

		public static bool AllowAsync
		{
			get
			{
				return _platformSave.AllowAsync;
			}
			set
			{
				_platformSave.AllowAsync = value;
			}
		}

		public static bool IsAvailable => _platformSave.IsAvailable;

		public static bool UsesVariableBackupSaveAmount => _platformSave.UsesVariableBackupSaveAmount;

		public static bool LimitNumberOfSandboxSaves => _platformSave.MaxSandboxSaves >= 0;

		public static int MaxSandboxSaves => _platformSave.MaxSandboxSaves;

		public static void Initialise()
		{
			_platformSave.Initialise();
		}

		public static void Destroy()
		{
			_platformSave.Destroy();
		}

		public static bool Save(string path, Action<BinaryWriter> writeAction, bool useBackups, Func<MemoryStream, bool> fileValidating = null)
		{
			byte[] buffer;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter obj = new BinaryWriter(memoryStream, Encoding.Default, leaveOpen: true))
				{
					writeAction(obj);
				}
				buffer = memoryStream.GetBuffer();
				if (fileValidating != null && !fileValidating(memoryStream))
				{
					return false;
				}
			}
			return Save(path, buffer, useBackups);
		}

		public static bool Save(string path, byte[] writeData, bool useBackups, Func<MemoryStream, bool> fileValidating = null)
		{
			return _platformSave.Save(path, writeData, useBackups);
		}

		public static bool Load(string path, out BinaryReader reader)
		{
			byte[] array = _platformSave.Load(path);
			if (array == null)
			{
				reader = null;
				return false;
			}
			reader = new BinaryReader(new MemoryStream(array));
			return true;
		}

		public static byte[] Load(string path)
		{
			return _platformSave.Load(path);
		}

		public static bool DirectoryExists(string path)
		{
			return _platformSave.DirectoryExists(path);
		}

		public static bool FileExists(string fileName)
		{
			return _platformSave.FileExists(fileName);
		}

		public static void DeleteSave(string path, bool deleteBackups)
		{
			_platformSave.DeleteSave(path, deleteBackups);
		}

		public static void MoveSave(string sourcePath, string destinationPath)
		{
			_platformSave.MoveSave(sourcePath, destinationPath);
		}

		public static void CreateDirectory(string path)
		{
			_platformSave.CreateDirectory(path);
		}

		public static bool DeleteDirectory(string path)
		{
			return _platformSave.DeleteDirectory(path);
		}

		public static string[] GetAllFiles(string path)
		{
			return _platformSave.GetAllFiles(path);
		}

		public static string[] GetDirectories(string path)
		{
			return _platformSave.GetDirectories(path);
		}

		public static bool MoveAllBackupSavesUp(string path)
		{
			return _platformSave.MoveAllBackupSavesUp(path);
		}

		public static bool FixupBackupSaveIndices(string path)
		{
			return _platformSave.FixupBackupSaveIndices(path);
		}

		public static void AssignApp(App app)
		{
			_platformSave.AssignApp(app);
		}

		public static void RefreshForUserChanged(Action<bool> onComplete)
		{
			_platformSave.RefreshForUserChanged(onComplete);
		}

		public static bool TryDeleteFileIfExists(string path)
		{
			if (!FileExists(path))
			{
				return true;
			}
			try
			{
				DeleteSave(path, deleteBackups: false);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static bool TryMoveFileIfExists(string fromPath, string toPath)
		{
			if (!FileExists(fromPath))
			{
				return true;
			}
			TryDeleteFileIfExists(toPath);
			try
			{
				MoveSave(fromPath, toPath);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static void EnsureDirectoryExists(string directoryPath)
		{
			if (!DirectoryExists(directoryPath))
			{
				CreateDirectory(directoryPath);
			}
		}
	}
}
