using System;
using System.Collections.Generic;
using System.IO;
using DV.UserManagement.Util;
using UnityEngine;

namespace DV.UserManagement.Storage.Implementation
{
	public class FileSystemStorage : IStorageProvider
	{
		private string basePath = ".";

		private static readonly char[] invalidChars = Path.GetInvalidPathChars();

		public FileSystemStorage()
		{
			basePath = Application.persistentDataPath;
		}

		public FileSystemStorage(string basePathOverride)
		{
			basePath = basePathOverride;
		}

		public bool DeleteFile(string path)
		{
			path = SanitizeName(path);
			path = Path.Combine(basePath, path);
			if (File.Exists(path))
			{
				File.Delete(path);
				return true;
			}
			return false;
		}

		public bool DeleteDirectory(string path)
		{
			path = SanitizeName(path);
			path = Path.Combine(basePath, path);
			if (Directory.Exists(path))
			{
				Directory.Delete(path, recursive: true);
				return true;
			}
			return false;
		}

		public bool CreateDirectory(string path)
		{
			path = SanitizeName(path);
			path = Path.Combine(basePath, path);
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			return true;
		}

		public bool FileExists(string path)
		{
			path = SanitizeName(path);
			path = Path.Combine(basePath, path);
			return File.Exists(path);
		}

		public bool DirectoryExists(string path)
		{
			path = SanitizeName(path);
			path = Path.Combine(basePath, path);
			return Directory.Exists(path);
		}

		public List<string> ListFiles(string path, string searchPattern)
		{
			path = SanitizeName(path);
			path = Path.Combine(basePath, path);
			if (Directory.Exists(path))
			{
				List<string> list = ((!string.IsNullOrEmpty(searchPattern)) ? new List<string>(Directory.GetFiles(path, searchPattern, SearchOption.TopDirectoryOnly)) : new List<string>(Directory.GetFiles(path)));
				for (int i = 0; i < list.Count; i++)
				{
					list[i] = list[i].Substring(path.Length);
					if (list[i][0] == Path.DirectorySeparatorChar)
					{
						list[i] = list[i].Substring(1);
					}
				}
				return list;
			}
			return new List<string>();
		}

		public List<string> ListDirectories(string path, string searchPattern)
		{
			path = SanitizeName(path);
			path = Path.Combine(basePath, path);
			if (Directory.Exists(path))
			{
				List<string> list = ((!string.IsNullOrEmpty(searchPattern)) ? new List<string>(Directory.GetDirectories(path, searchPattern, SearchOption.TopDirectoryOnly)) : new List<string>(Directory.GetDirectories(path)));
				for (int i = 0; i < list.Count; i++)
				{
					list[i] = list[i].Substring(path.Length);
					if (list[i][0] == Path.DirectorySeparatorChar)
					{
						list[i] = list[i].Substring(1);
					}
				}
				return list;
			}
			return new List<string>();
		}

		public byte[] ReadFileToBytes(string path, byte[] key)
		{
			path = SanitizeName(path);
			path = Path.Combine(basePath, path);
			byte[] array = File.ReadAllBytes(path);
			if (key != null && key.Length != 0)
			{
				array = DataProtection.DecryptBytes(array, key);
			}
			return array;
		}

		public string ReadFileToString(string path, byte[] key)
		{
			byte[] bytes = ReadFileToBytes(path, key);
			return UserManager.ENCODING.GetString(bytes);
		}

		public DateTime GetLastWriteTime(string path)
		{
			return File.GetLastWriteTime(GetFilesystemPath(path));
		}

		public string GetDirectoryName(string path)
		{
			int num = path.LastIndexOf(Path.DirectorySeparatorChar);
			if (num < 0)
			{
				return path;
			}
			return path.Substring(0, num);
		}

		public void WriteFile(string path, string data, byte[] key)
		{
			if (data == null)
			{
				data = "";
			}
			if (key != null && key.Length != 0)
			{
				WriteFile(path, UserManager.ENCODING.GetBytes(data), key);
				return;
			}
			path = SanitizeName(path);
			path = Path.Combine(basePath, path);
			string directoryName = Path.GetDirectoryName(path);
			if (!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			File.WriteAllText(path, data, UserManager.ENCODING);
		}

		public void WriteFile(string path, byte[] data, byte[] key)
		{
			if (data == null)
			{
				data = Array.Empty<byte>();
			}
			path = SanitizeName(path);
			path = Path.Combine(basePath, path);
			string directoryName = Path.GetDirectoryName(path);
			if (!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			if (key != null && key.Length != 0)
			{
				data = DataProtection.EncryptBytes(data, key);
			}
			File.WriteAllBytes(path, data);
		}

		public void CopyFile(string sourcePath, string destinationPath)
		{
			sourcePath = GetFilesystemPath(sourcePath);
			destinationPath = GetFilesystemPath(destinationPath);
			File.Copy(sourcePath, destinationPath, overwrite: true);
		}

		public string SanitizeName(string name)
		{
			if (invalidChars != null)
			{
				for (int i = 0; i < invalidChars.Length; i++)
				{
					name = name.Replace(invalidChars[i], '_');
				}
			}
			return name;
		}

		public string GetFilesystemPath(string internalPath)
		{
			string path = SanitizeName(internalPath);
			path = Path.Combine(basePath, path);
			if (Path.DirectorySeparatorChar != '/')
			{
				path = path.Replace('/', Path.DirectorySeparatorChar);
			}
			return path;
		}

		public byte[] EncryptData(byte[] data, byte[] key)
		{
			return DataProtection.EncryptBytes(data, key);
		}

		public byte[] DecryptData(byte[] data, byte[] key)
		{
			return DataProtection.DecryptBytes(data, key);
		}

		public IStreamProvider OpenFileForReading(string path)
		{
			path = SanitizeName(path);
			path = Path.Combine(basePath, path);
			return new FileStreamProvider(path, 0L);
		}

		public Stream OpenFileForWriting(string path)
		{
			path = SanitizeName(path);
			path = Path.Combine(basePath, path);
			string directoryName = Path.GetDirectoryName(path);
			if (!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			return new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
		}
	}
}
