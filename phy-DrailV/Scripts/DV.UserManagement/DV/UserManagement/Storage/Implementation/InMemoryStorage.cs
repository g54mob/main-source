using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DV.UserManagement.Storage.Implementation
{
	public class InMemoryStorage : IStorageProvider
	{
		private class DirectoryNode
		{
			public string Name = "";

			public DirectoryNode Parent;

			public Dictionary<string, DirectoryNode> Subdirs = new Dictionary<string, DirectoryNode>();

			public Dictionary<string, MemoryStream> Files = new Dictionary<string, MemoryStream>();

			public Dictionary<string, DateTime> TimeStamps = new Dictionary<string, DateTime>();

			public DirectoryNode(string name, DirectoryNode parent)
			{
				Name = name;
				Parent = parent;
			}

			public DirectoryNode GetDir(string path, bool createIfNeeded = false)
			{
				return GetDir(Pathify(path), createIfNeeded);
			}

			public DirectoryNode GetDir(string[] path, bool createIfNeeded = false)
			{
				DirectoryNode directoryNode = this;
				for (int i = 0; i < path.Length; i++)
				{
					DirectoryNode value = null;
					if (directoryNode.Subdirs.TryGetValue(path[i], out value))
					{
						directoryNode = value;
						continue;
					}
					if (createIfNeeded)
					{
						DirectoryNode directoryNode2 = new DirectoryNode(path[i], directoryNode);
						directoryNode.Subdirs.Add(path[i], directoryNode2);
						directoryNode = directoryNode2;
						continue;
					}
					return null;
				}
				return directoryNode;
			}

			public bool DeleteDir(string path)
			{
				return DeleteDir(Pathify(path));
			}

			public bool DeleteDir(string[] path)
			{
				DirectoryNode dir = GetDir(path);
				if (dir != null && dir.Parent != null)
				{
					return dir.Parent.Subdirs.Remove(dir.Name);
				}
				return false;
			}

			public byte[] GetFile(string path)
			{
				return GetFile(Pathify(path));
			}

			public DateTime GetLastWriteTime(string filePath)
			{
				string[] array = Pathify(filePath);
				DirectoryNode directoryNode = this;
				for (int i = 0; i < array.Length - 1; i++)
				{
					DirectoryNode value = null;
					if (directoryNode.Subdirs.TryGetValue(array[i], out value))
					{
						directoryNode = value;
						continue;
					}
					return DateTime.MinValue;
				}
				directoryNode.TimeStamps.TryGetValue(array[array.Length - 1], out var value2);
				return value2;
			}

			public MemoryStream GetFileStream(string path)
			{
				return GetFileStream(Pathify(path));
			}

			public byte[] GetFile(string[] path)
			{
				return GetFileStream(path)?.ToArray();
			}

			public MemoryStream GetFileStream(string[] path)
			{
				DirectoryNode directoryNode = this;
				for (int i = 0; i < path.Length - 1; i++)
				{
					DirectoryNode value = null;
					if (directoryNode.Subdirs.TryGetValue(path[i], out value))
					{
						directoryNode = value;
						continue;
					}
					return null;
				}
				MemoryStream value2 = null;
				directoryNode.Files.TryGetValue(path[path.Length - 1], out value2);
				return value2;
			}

			public bool CreateDir(string path)
			{
				return CreateDir(Pathify(path)) != null;
			}

			public DirectoryNode CreateDir(string[] path, int trimEnd = 0)
			{
				DirectoryNode directoryNode = this;
				for (int i = 0; i < path.Length - trimEnd; i++)
				{
					DirectoryNode value = null;
					if (directoryNode.Subdirs.TryGetValue(path[i], out value))
					{
						directoryNode = value;
						continue;
					}
					DirectoryNode directoryNode2 = new DirectoryNode(path[i], directoryNode);
					directoryNode.Subdirs.Add(path[i], directoryNode2);
					directoryNode = directoryNode2;
				}
				return directoryNode;
			}

			public void PutFile(string path, byte[] data)
			{
				if (data == null)
				{
					data = new byte[0];
				}
				PutFile(Pathify(path), data);
			}

			public void PutFile(string[] path, byte[] data)
			{
				DirectoryNode directoryNode = CreateDir(path, 1);
				string key = path[path.Length - 1];
				directoryNode.Files[key] = new MemoryStream(data);
				directoryNode.TimeStamps[key] = DateTime.Now;
			}

			public void PutFile(string path, MemoryStream data)
			{
				PutFile(new string[1] { path }, data);
			}

			public void PutFile(string[] path, MemoryStream data)
			{
				DirectoryNode directoryNode = CreateDir(path, 1);
				string key = path[path.Length - 1];
				directoryNode.Files[key] = data;
				directoryNode.TimeStamps[key] = DateTime.Now;
			}

			public bool DeleteFile(string path)
			{
				return DeleteFile(Pathify(path));
			}

			public bool DeleteFile(string[] path)
			{
				DirectoryNode directoryNode = this;
				for (int i = 0; i < path.Length - 1; i++)
				{
					DirectoryNode value = null;
					if (directoryNode.Subdirs.TryGetValue(path[i], out value))
					{
						directoryNode = value;
						continue;
					}
					return false;
				}
				string key = path[path.Length - 1];
				if (directoryNode.Files.Remove(key))
				{
					directoryNode.TimeStamps.Remove(key);
					return true;
				}
				return false;
			}
		}

		private DirectoryNode root = new DirectoryNode("", null);

		private static string[] Pathify(string path)
		{
			path = path.Replace('\\', '/');
			return path.Split(new char[1] { '/' }, StringSplitOptions.RemoveEmptyEntries);
		}

		public bool CreateDirectory(string path)
		{
			return root.CreateDir(path);
		}

		public bool DeleteDirectory(string path)
		{
			return root.DeleteDir(path);
		}

		public bool DeleteFile(string path)
		{
			return root.DeleteFile(path);
		}

		public bool DirectoryExists(string path)
		{
			return root.GetDir(path) != null;
		}

		public bool FileExists(string path)
		{
			return root.GetFile(path) != null;
		}

		public List<string> ListDirectories(string path, string searchPattern = "")
		{
			List<string> list = new List<string>();
			DirectoryNode dir = root.GetDir(path);
			if (dir != null)
			{
				string value = "";
				string value2 = "";
				int num = searchPattern.IndexOf('*');
				if (num >= 0)
				{
					value = searchPattern.Substring(0, num);
					value2 = searchPattern.Substring(num + 1, searchPattern.Length - num - 1);
				}
				foreach (KeyValuePair<string, DirectoryNode> subdir in dir.Subdirs)
				{
					if ((string.IsNullOrEmpty(value) || subdir.Key.StartsWith(value)) && (string.IsNullOrEmpty(value2) || subdir.Key.EndsWith(value2)))
					{
						list.Add(subdir.Key);
					}
				}
			}
			return list;
		}

		public List<string> ListFiles(string path, string searchPattern = "")
		{
			List<string> list = new List<string>();
			DirectoryNode dir = root.GetDir(path);
			if (dir != null)
			{
				string value = "";
				string value2 = "";
				int num = searchPattern.IndexOf('*');
				if (num >= 0)
				{
					value = searchPattern.Substring(0, num);
					value2 = searchPattern.Substring(num + 1, searchPattern.Length - num - 1);
				}
				foreach (KeyValuePair<string, MemoryStream> file in dir.Files)
				{
					if ((string.IsNullOrEmpty(value) || file.Key.StartsWith(value)) && (string.IsNullOrEmpty(value2) || file.Key.EndsWith(value2)))
					{
						list.Add(file.Key);
					}
				}
			}
			return list;
		}

		public byte[] ReadFileToBytes(string path, byte[] key = null)
		{
			return root.GetFile(path);
		}

		public string ReadFileToString(string path, byte[] key = null)
		{
			byte[] file = root.GetFile(path);
			if (file != null)
			{
				return Encoding.UTF8.GetString(file);
			}
			return null;
		}

		public DateTime GetLastWriteTime(string path)
		{
			return root.GetLastWriteTime(path);
		}

		public string GetDirectoryName(string path)
		{
			string[] array = Pathify(path);
			if (array.Length > 1)
			{
				return string.Join("/", new ArraySegment<string>(array, 0, array.Length - 1));
			}
			return "";
		}

		public string SanitizeName(string name)
		{
			return name;
		}

		public string GetFilesystemPath(string internalPath)
		{
			return "";
		}

		public void WriteFile(string path, string data, byte[] key = null)
		{
			root.PutFile(path, (data == null) ? Array.Empty<byte>() : Encoding.UTF8.GetBytes(data));
		}

		public void WriteFile(string path, byte[] data, byte[] key = null)
		{
			root.PutFile(path, data);
		}

		public void CopyFile(string sourcePath, string destinationPath)
		{
			byte[] data = ReadFileToBytes(sourcePath);
			root.PutFile(destinationPath, data);
		}

		public byte[] EncryptData(byte[] data, byte[] key)
		{
			return data;
		}

		public byte[] DecryptData(byte[] data, byte[] key)
		{
			return data;
		}

		public IStreamProvider OpenFileForReading(string path)
		{
			return new MemoryStreamProvider(root.GetFileStream(path), 0L);
		}

		public Stream OpenFileForWriting(string path)
		{
			MemoryStream memoryStream = new MemoryStream();
			root.PutFile(path, memoryStream);
			return memoryStream;
		}
	}
}
