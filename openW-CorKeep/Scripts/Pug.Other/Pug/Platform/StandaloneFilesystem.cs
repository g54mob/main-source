using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using PugMod;
using UnityEngine;

namespace Pug.Platform
{
	[DisallowPatching]
	public class StandaloneFilesystem : FilesystemInterface, IConfigFilesystem
	{
		private const string tempFileSuffix = ".pugtmp";

		private const string backupFileSuffix = ".pugbackup";

		private readonly string _persistentPath;

		public bool IsInitialized => true;

		private string Abs2Rel(string path)
		{
			return path.Remove(0, _persistentPath.Length + 1);
		}

		public StandaloneFilesystem(string partition, PlatformInterface platformInterface)
		{
			_persistentPath = Application.persistentDataPath;
			if (!string.IsNullOrEmpty(partition))
			{
				_persistentPath = _persistentPath + "/" + partition;
			}
			_persistentPath = _persistentPath + "/" + platformInterface.Name + "/" + platformInterface.GetAccountId();
			DirectoryInfo directoryInfo = new DirectoryInfo(_persistentPath);
			_persistentPath = directoryInfo.FullName;
			_persistentPath = _persistentPath.Replace('\\', '/');
			CreateDirectory(directoryInfo);
		}

		public StandaloneFilesystem(string partition, string subFolder, PlatformInterface platformInterface)
		{
			_persistentPath = Application.persistentDataPath;
			if (!string.IsNullOrEmpty(partition))
			{
				_persistentPath = _persistentPath + "/" + partition;
			}
			_persistentPath = _persistentPath + "/" + platformInterface.Name + "/" + platformInterface.GetAccountId();
			if (!string.IsNullOrEmpty(subFolder))
			{
				_persistentPath = Path.Combine(_persistentPath, subFolder);
			}
			DirectoryInfo directoryInfo = new DirectoryInfo(_persistentPath);
			_persistentPath = directoryInfo.FullName;
			_persistentPath = _persistentPath.Replace('\\', '/');
			CreateDirectory(directoryInfo);
		}

		public string Rel2Abs(string path)
		{
			string text = Path.GetFullPath(path, _persistentPath).Replace('\\', '/');
			if (!text.StartsWith(_persistentPath))
			{
				throw new InvalidOperationException("Trying to access " + text + " outside " + _persistentPath);
			}
			return text;
		}

		private void CreateDirectory(DirectoryInfo dirInfo)
		{
			if (dirInfo != null && !dirInfo.Exists)
			{
				CreateDirectory(dirInfo.Parent);
				if (!dirInfo.Exists)
				{
					Directory.CreateDirectory(dirInfo.FullName);
				}
			}
		}

		public void BeginWrite()
		{
		}

		public void EndWrite()
		{
		}

		public void Write(string path, byte[] data)
		{
			Write("", path, data);
		}

		public void Write(string name, string path, byte[] data)
		{
			try
			{
				string text = Rel2Abs(path);
				string text2 = Rel2Abs(path + ".pugtmp");
				string text3 = Rel2Abs(path + ".pugbackup");
				int i;
				for (i = 0; i < 10; i++)
				{
					try
					{
						if (File.Exists(text3))
						{
							File.Delete(text3);
						}
					}
					catch (IOException ex)
					{
						if (ex.HResult != -2147024864)
						{
							throw;
						}
						Debug.LogWarning("Failed to write because save file is open in other program, retrying in 1 sec...");
						Thread.Sleep(1000);
						continue;
					}
					break;
				}
				if (i == 10)
				{
					Debug.LogError("Deleting old backup " + path + " failed after timeout");
				}
				using (FileStream fileStream = File.Create(text2))
				{
					fileStream.Write(data, 0, data.Length);
					fileStream.Flush(flushToDisk: true);
				}
				for (i = 0; i < 10; i++)
				{
					try
					{
						if (File.Exists(text))
						{
							File.Replace(text2, Rel2Abs(path), text3, ignoreMetadataErrors: true);
						}
						else
						{
							File.Move(text2, text);
						}
					}
					catch (IOException ex2)
					{
						if (ex2.HResult != -2147024864)
						{
							throw;
						}
						Debug.LogWarning("Failed to write because save file is open in other program, retrying in 1 sec...");
						Thread.Sleep(1000);
						continue;
					}
					break;
				}
				if (i == 10)
				{
					Debug.LogError("Writing " + path + " failed after timeout");
				}
			}
			catch (IOException ex3)
			{
				Debug.LogError("Write failed: " + ex3.Message + " (" + ex3.HResult + ")");
			}
		}

		public bool DirectoryExists(string path)
		{
			return Directory.Exists(Rel2Abs(path));
		}

		public void CreateDirectory(string path)
		{
			Directory.CreateDirectory(Rel2Abs(path));
		}

		public void DeleteDirectory(string path)
		{
			Directory.Delete(Rel2Abs(path), recursive: true);
		}

		public void CopyDirectory(string from, string to)
		{
			string sourceDirName = Rel2Abs(from);
			string destDirName = Rel2Abs(to);
			CopyDirectoryRecursive(sourceDirName, destDirName, copySubDirs: true);
		}

		public static void CopyDirectoryRecursive(string sourceDirName, string destDirName, bool copySubDirs)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(sourceDirName);
			if (!directoryInfo.Exists)
			{
				throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + sourceDirName);
			}
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			Directory.CreateDirectory(destDirName);
			FileInfo[] files = directoryInfo.GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				string destFileName = Path.Combine(destDirName, fileInfo.Name);
				fileInfo.CopyTo(destFileName, overwrite: false);
			}
			if (copySubDirs)
			{
				DirectoryInfo[] array = directories;
				foreach (DirectoryInfo directoryInfo2 in array)
				{
					string destDirName2 = Path.Combine(destDirName, directoryInfo2.Name);
					CopyDirectoryRecursive(directoryInfo2.FullName, destDirName2, copySubDirs);
				}
			}
		}

		public bool FileExists(string path)
		{
			return File.Exists(Rel2Abs(path));
		}

		public byte[] Read(string path)
		{
			return File.ReadAllBytes(Rel2Abs(path));
		}

		public void Delete(string path)
		{
			try
			{
				string sourceFileName = Rel2Abs(path);
				string text = Rel2Abs(path + ".pugbackup");
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				File.Move(sourceFileName, text);
			}
			catch (IOException ex)
			{
				Debug.LogError("Delete failed: " + ex.Message + " (" + ex.HResult + ")");
			}
		}

		public IEnumerable<string> GetAllFiles()
		{
			return GetFiles("");
		}

		public IEnumerable<string> GetFiles(string path)
		{
			List<string> list = (from x in Directory.EnumerateFiles(Rel2Abs(path), "*", SearchOption.AllDirectories)
				where !x.EndsWith(".pugbackup") && !x.EndsWith(".pugtmp")
				select x).ToList();
			for (int num = 0; num < list.Count; num++)
			{
				list[num] = Abs2Rel(list[num]).Replace("\\", "/");
			}
			return list;
		}

		public DateTime GetFileTime(string path)
		{
			return File.GetLastWriteTimeUtc(Rel2Abs(path));
		}

		public ulong GetRemainingBytes()
		{
			Debug.Log("Couldn't find backing drive, assumes there is space");
			return ulong.MaxValue;
		}
	}
}
