using System;
using System.Collections.Generic;
using PugMod;

namespace Pug.Platform
{
	[DisallowPatching]
	public abstract class NoDirectoryFilesystemInterface : FilesystemInterface
	{
		private Dictionary<string, List<string>> directoryLookup = new Dictionary<string, List<string>>();

		public bool IsInitialized => true;

		public abstract void Deinit();

		public abstract bool FileExists(string path);

		public abstract byte[] Read(string path);

		public abstract void BeginWrite();

		public abstract void EndWrite();

		public abstract IEnumerable<string> GetAllFiles();

		public abstract DateTime GetFileTime(string path);

		public abstract ulong GetRemainingBytes();

		public virtual void Init(string partition, PlatformInterface platformInterface)
		{
			if (!string.IsNullOrEmpty(partition))
			{
				throw new NotImplementedException();
			}
			directoryLookup.Clear();
			foreach (string allFile in GetAllFiles())
			{
				AddFileToDirectories(allFile);
			}
		}

		private void AddFileToDirectories(string file)
		{
			for (int i = 0; i < file.Length; i++)
			{
				if (file[i] == '/')
				{
					string key = file.Substring(0, i);
					if (directoryLookup.ContainsKey(key))
					{
						directoryLookup[key].Add(file);
						continue;
					}
					directoryLookup.Add(key, new List<string> { file });
				}
			}
		}

		public virtual void Write(string name, string path, byte[] data)
		{
			int num = 0;
			foreach (KeyValuePair<string, List<string>> item in directoryLookup)
			{
				for (int num2 = item.Value.Count - 1; num2 >= 0; num2--)
				{
					if (string.Equals(item.Value[num2], path))
					{
						num++;
					}
				}
			}
			int num3 = 0;
			for (int i = 0; i < path.Length; i++)
			{
				if (path[i] == '/')
				{
					num3++;
				}
			}
			if (num != num3)
			{
				AddFileToDirectories(path);
			}
		}

		public virtual void Delete(string path)
		{
			foreach (KeyValuePair<string, List<string>> item in directoryLookup)
			{
				for (int num = item.Value.Count - 1; num >= 0; num--)
				{
					if (string.Equals(item.Value[num], path))
					{
						item.Value.RemoveAt(num);
					}
				}
			}
		}

		public bool DirectoryExists(string path)
		{
			return directoryLookup.ContainsKey(path);
		}

		public void CreateDirectory(string path)
		{
			directoryLookup.Add(path, new List<string>());
		}

		public void DeleteDirectory(string path)
		{
			List<string> list = directoryLookup[path];
			directoryLookup.Remove(path);
			foreach (string item in list)
			{
				Delete(item);
			}
		}

		public void CopyDirectory(string from, string to)
		{
			CreateDirectory(to);
			foreach (string item in directoryLookup[from])
			{
				string path = item.Replace(from, to);
				Write("", path, Read(item));
			}
		}

		public IEnumerable<string> GetFiles(string path)
		{
			return directoryLookup[path].ToArray();
		}
	}
}
