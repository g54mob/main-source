using System;
using System.IO;
using SharpConfig;

namespace TH20
{
	public static class FileUtils
	{
		public static bool TryDeleteFileIfExists(string path)
		{
			if (!File.Exists(path))
			{
				return true;
			}
			try
			{
				File.Delete(path);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static bool TryMoveFileIfExists(string fromPath, string toPath)
		{
			if (!File.Exists(fromPath))
			{
				return true;
			}
			TryDeleteFileIfExists(toPath);
			try
			{
				File.Move(fromPath, toPath);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static void EnsureDirectoryExists(string directoryPath)
		{
			if (!Directory.Exists(directoryPath))
			{
				Directory.CreateDirectory(directoryPath);
			}
		}

		public static bool IsFileReadonly(string path)
		{
			return (File.GetAttributes(path) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly;
		}

		public static void MakeFileWriteable(string path)
		{
			FileAttributes attributes = File.GetAttributes(path);
			if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
			{
				File.SetAttributes(path, attributes & ~FileAttributes.ReadOnly);
			}
		}

		public static void MakeFileReadonly(string path)
		{
			FileAttributes attributes = File.GetAttributes(path);
			if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
			{
				File.SetAttributes(path, attributes | FileAttributes.Hidden);
			}
		}

		public static void MergeConfig(this Configuration destConfig, Configuration config)
		{
			if (config == null)
			{
				return;
			}
			foreach (Section item in config)
			{
				if (destConfig.Contains(item.Name))
				{
					foreach (Setting item2 in item)
					{
						if (destConfig[item.Name].Contains(item2.Name))
						{
							destConfig[item.Name].Remove(item2.Name);
						}
						destConfig[item.Name].Add(item2);
					}
				}
				else
				{
					destConfig.Add(item);
				}
			}
		}
	}
}
