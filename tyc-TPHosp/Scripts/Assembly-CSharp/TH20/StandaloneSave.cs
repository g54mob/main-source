#define LOG_LEVEL_VERBOSE
using System;
using System.IO;

namespace TH20
{
	public class StandaloneSave : PlatformSaveBase
	{
		public override string CloudDirectory => Directories.SteamCloudDirectory;

		public override bool IsAvailable => true;

		public override bool UsesVariableBackupSaveAmount => true;

		public override byte[] Load(string path)
		{
			try
			{
				return File.ReadAllBytes(path);
			}
			catch (Exception ex)
			{
				Logging.Error(ex.Message);
				return null;
			}
		}

		public override bool Save(string filePath, byte[] writeData, bool useBackups)
		{
			if (useBackups)
			{
				return SaveToFileWithBackups(filePath, writeData);
			}
			return SaveToFileUsingTemp(filePath, writeData);
		}

		private bool SaveToFileUsingTemp(string filePath, byte[] writeData)
		{
			string tempSavePath = SaveUtils.GetTempSavePath(filePath);
			if (!SaveToFile(tempSavePath, writeData))
			{
				return false;
			}
			if (!FileUtils.TryDeleteFileIfExists(filePath))
			{
				Logging.Warning(LogChannels.Save, "Couldn't delete previous file. Failed deleting {0}.", filePath);
			}
			return MoveSave(tempSavePath, filePath);
		}

		private bool SaveToFile(string filePath, byte[] writeData)
		{
			string directoryName = Path.GetDirectoryName(filePath);
			if (!DirectoryExists(directoryName))
			{
				CreateDirectory(directoryName);
			}
			using (BinaryWriter binaryWriter = new BinaryWriter(File.Create(new FileInfo(filePath).FullName)))
			{
				binaryWriter.Write(writeData);
			}
			return true;
		}

		private bool SaveToFileWithBackups(string filePath, byte[] writeData)
		{
			string tempSavePath = SaveUtils.GetTempSavePath(filePath);
			SaveToFile(tempSavePath, writeData);
			int num = _app.UserPreferences.Game.NumberOfRollingSavesToKeep + 1;
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				string backupSavePath = SaveUtils.GetBackupSavePath(filePath, num2 + 1);
				string backupSavePath2 = SaveUtils.GetBackupSavePath(filePath, num2);
				if (!FileUtils.TryMoveFileIfExists(backupSavePath2, backupSavePath))
				{
					Logging.Warning(LogChannels.Save, "Couldn't move rolling save files whilst rotating saves. The rest of the save may not work. Failed moving {0} to {1}.", backupSavePath2, backupSavePath);
				}
			}
			string backupSavePath3 = SaveUtils.GetBackupSavePath(filePath, num);
			if (!FileUtils.TryDeleteFileIfExists(backupSavePath3))
			{
				Logging.Warning(LogChannels.Save, "Couldn't delete oldest rolling save file whilst rotating saves. The rest of the save may not work. Failed deleting {0}.", backupSavePath3);
			}
			return MoveSave(tempSavePath, filePath);
		}

		public override bool FileExists(string fileName)
		{
			return File.Exists(fileName);
		}

		public override bool DirectoryExists(string path)
		{
			return Directory.Exists(path);
		}

		public override bool DeleteSave(string path, bool deleteBackups)
		{
			if (deleteBackups)
			{
				string fileName = Path.GetFileName(path);
				string[] files = Directory.GetFiles(Path.GetDirectoryName(path), $"{fileName}*");
				for (int i = 0; i < files.Length; i++)
				{
					File.Delete(files[i]);
				}
			}
			else
			{
				File.Delete(path);
			}
			return true;
		}

		public override bool MoveSave(string sourcePath, string destinationPath)
		{
			File.Move(sourcePath, destinationPath);
			return true;
		}

		public override void CreateDirectory(string path)
		{
			Directory.CreateDirectory(path);
		}

		public override bool DeleteDirectory(string path)
		{
			Directory.Delete(path, recursive: true);
			return true;
		}

		public override string[] GetAllFiles(string path)
		{
			return Directory.GetFiles(path);
		}

		public override string[] GetDirectories(string path)
		{
			return Directory.GetDirectories(path);
		}

		public override bool MoveAllBackupSavesUp(string path)
		{
			int num = _app.UserPreferences.Game.NumberOfRollingSavesToKeep + 1;
			if (num <= 1)
			{
				return true;
			}
			for (int i = 0; i < num - 1; i++)
			{
				string backupSavePath = SaveUtils.GetBackupSavePath(path, i + 1);
				string backupSavePath2 = SaveUtils.GetBackupSavePath(path, i);
				if (!FileUtils.TryMoveFileIfExists(backupSavePath, backupSavePath2))
				{
					Logging.Warning(LogChannels.Save, "Couldn't move rolling save files whilst rotating saves. The rest of the save may not work. Failed moving {0} to {1}.", backupSavePath2, backupSavePath);
				}
			}
			string backupSavePath3 = SaveUtils.GetBackupSavePath(path, num - 1);
			if (!FileUtils.TryDeleteFileIfExists(backupSavePath3))
			{
				Logging.Warning(LogChannels.Save, "Couldn't delete oldest rolling save file whilst rotating saves. The rest of the save may not work. Failed deleting {0}.", backupSavePath3);
			}
			return true;
		}

		public override bool FixupBackupSaveIndices(string path)
		{
			if (!FileExists(path))
			{
				FileUtils.TryMoveFileIfExists(SaveUtils.GetTempSavePath(path), path);
			}
			int num = _app.UserPreferences.Game.NumberOfRollingSavesToKeep + 1;
			for (int i = 1; i < num; i++)
			{
				string backupSavePath = SaveUtils.GetBackupSavePath(path, i);
				if (FileExists(backupSavePath))
				{
					continue;
				}
				bool flag = false;
				for (int j = i + 1; j < num; j++)
				{
					string backupSavePath2 = SaveUtils.GetBackupSavePath(path, j);
					if (FileExists(backupSavePath2))
					{
						FileUtils.TryMoveFileIfExists(backupSavePath2, backupSavePath);
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					break;
				}
			}
			return true;
		}

		public override void RefreshForUserChanged(Action<bool> onComplete)
		{
			onComplete?.Invoke(obj: true);
		}
	}
}
