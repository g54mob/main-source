using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Platforms
{
	public class SaveStorage<T> where T : IComparable<T>
	{
		private const string FileExtension = ".plateupsave";

		private const int BackupCount = 5;

		private readonly string Directory;

		private readonly List<SaveInfo<T>> SaveInfos;

		private readonly IAsyncFileSystem FileSystem;

		private object WatcherLock = new object();

		private bool HasWatchedChanges;

		private bool IsFakeWatch;

		private const int CompressionFactor = 10;

		public SaveStorage(IAsyncFileSystem fs, string directory)
		{
			Directory = directory;
			FileSystem = fs;
			SaveInfos = new List<SaveInfo<T>>();
			FileSystem.OnFileSystemChange += HandleFileSystemChange;
			FileSystem.OnClearFileSystemChanges += ClearFileSystemChanges;
		}

		private void ClearFileSystemChanges()
		{
			IsFakeWatch = true;
			if (!HasWatchedChanges)
			{
				EnsureDelayedUpdate();
			}
		}

		private void HandleFileSystemChange(string path)
		{
			if (!Directory.StartsWith(path))
			{
				return;
			}
			lock (WatcherLock)
			{
				if (!HasWatchedChanges)
				{
					IsFakeWatch = false;
					EnsureDelayedUpdate();
				}
			}
		}

		private void EnsureDelayedUpdate()
		{
			HasWatchedChanges = true;
			WatchForFileChanges();
		}

		private async Task WatchForFileChanges()
		{
			await Task.Delay(TimeSpan.FromSeconds(3.0));
			if (HasWatchedChanges && !IsFakeWatch)
			{
				await LoadFromDisk();
				HasWatchedChanges = false;
			}
			HasWatchedChanges = false;
			IsFakeWatch = false;
		}

		private void Set(string key, SaveInfo<T> value)
		{
			if (SaveInfos.Count != 0 && value.CompareTo(SaveInfos[0]) < 0)
			{
				Debug.LogWarning("refusing to create old save with key (" + key + ")");
				return;
			}
			SaveInfos.Insert(0, value);
			string path = Path.Combine(Directory, key);
			List<string> remove = new List<string>();
			if (SaveInfos.Count > 5)
			{
				for (int i = 5; i < SaveInfos.Count; i++)
				{
					remove.Add(SaveInfos[i].Name);
				}
				SaveInfos.RemoveRange(5, SaveInfos.Count - 5);
			}
			Forget(Task.Run(async delegate
			{
				try
				{
					await FileSystem.CreateDirectory(Path.GetDirectoryName(path));
					await FileSystem.WriteAllBytes(path, Compress(value.Data));
				}
				catch (Exception arg)
				{
					Debug.LogError($"failed to write file to {path}: {arg}");
					return;
				}
				foreach (string item in remove)
				{
					await Delete(item);
				}
			}));
		}

		public void Clear()
		{
			string[] remove = new string[SaveInfos.Count];
			for (int i = 0; i < remove.Length; i++)
			{
				remove[i] = SaveInfos[i].Name;
			}
			SaveInfos.Clear();
			Forget(Task.Run(async delegate
			{
				string[] array = remove;
				foreach (string name in array)
				{
					await Delete(name);
				}
			}));
		}

		private async Task Delete(string name)
		{
			string path = Path.Combine(Directory, name);
			try
			{
				await FileSystem.DeleteFile(path);
			}
			catch (Exception arg)
			{
				Debug.LogError($"failed to delete file at {path}: {arg}");
			}
		}

		private static SaveInfo<T> CreateSaveInfo(byte[] data)
		{
			DateTime utcNow = DateTime.UtcNow;
			return new SaveInfo<T>
			{
				LastWriteTime = utcNow,
				Name = UnixSeconds(utcNow) + ".plateupsave",
				Data = data
			};
		}

		private static int UnixSeconds(DateTime t)
		{
			DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			return (int)(t - dateTime).TotalSeconds;
		}

		public void LoadedSuccessfully(int index)
		{
			for (int i = index + 1; i < SaveInfos.Count; i++)
			{
				SaveInfos[i].Data = null;
			}
		}

		public void Set(byte[] data)
		{
			SaveInfo<T> saveInfo = CreateSaveInfo(data);
			Set(saveInfo.Name, saveInfo);
		}

		public void Set(byte[] data, T extra)
		{
			SaveInfo<T> saveInfo = CreateSaveInfo(data);
			saveInfo.Extra = extra;
			Set(saveInfo.Name, saveInfo);
		}

		public async Task Initialise(Func<byte[], bool, T> load = null)
		{
			await LoadFromDisk(load);
		}

		public async Task LoadFromDisk(Func<byte[], bool, T> load = null)
		{
			SaveInfos.Clear();
			FileReference[] files;
			try
			{
				await FileSystem.CreateDirectory(Directory);
				files = (await FileSystem.GetFiles(Directory, ".plateupsave", filter_empty: true)).ToArray();
			}
			catch (Exception arg)
			{
				Debug.LogError($"failed to get files in directory ({Directory}): {arg}");
				return;
			}
			List<Task<(byte[], bool)>> list = new List<Task<(byte[], bool)>>(files.Length);
			FileReference[] array = files;
			for (int i = 0; i < array.Length; i++)
			{
				FileReference file = array[i];
				list.Add(Task.Run(async delegate
				{
					try
					{
						bool was_compressed;
						return (Decompress(await FileSystem.ReadAllBytes(file.Path), out was_compressed), true);
					}
					catch (FileNotFoundException)
					{
					}
					catch (Exception arg2)
					{
						Debug.LogError($"failed to read file at {file.Path}: {arg2}");
					}
					return ((byte[], bool))(null, false);
				}));
			}
			(byte[], bool)[] array2 = await Task.WhenAll(list);
			for (int num = 0; num < array2.Length; num++)
			{
				SaveInfo<T> saveInfo = new SaveInfo<T>();
				saveInfo.Name = files[num].FileName;
				saveInfo.LastWriteTime = files[num].LastWriteTime.ToUniversalTime();
				bool item = array2[num].Item2;
				if (item)
				{
					saveInfo.Data = array2[num].Item1;
				}
				if (load != null)
				{
					saveInfo.Extra = load(saveInfo.Data, item);
				}
				SaveInfos.Add(saveInfo);
			}
			SaveInfos.Sort();
			SaveInfos.Reverse();
		}

		public List<SaveInfo<T>> Get()
		{
			return SaveInfos;
		}

		private void Forget(Task task)
		{
			if (!task.IsCompleted || task.IsFaulted)
			{
				ForgetAwaited(task);
			}
		}

		private async Task ForgetAwaited(Task task)
		{
			try
			{
				await task.ConfigureAwait(continueOnCapturedContext: false);
			}
			catch
			{
			}
		}

		public static byte[] Compress(byte[] bytes)
		{
			using MemoryStream memoryStream = new MemoryStream(bytes);
			using MemoryStream memoryStream2 = new MemoryStream(bytes.Length / 10);
			using (GZipStream destination = new GZipStream(memoryStream2, CompressionLevel.Fastest))
			{
				memoryStream.CopyTo(destination);
			}
			return memoryStream2.ToArray();
		}

		public static byte[] Decompress(byte[] bytes, out bool was_compressed)
		{
			was_compressed = false;
			if (bytes == null)
			{
				return Array.Empty<byte>();
			}
			using MemoryStream stream = new MemoryStream(bytes);
			using MemoryStream memoryStream = new MemoryStream(bytes.Length * 10);
			try
			{
				using (GZipStream gZipStream = new GZipStream(stream, CompressionMode.Decompress))
				{
					gZipStream.CopyTo(memoryStream);
				}
				was_compressed = true;
			}
			catch
			{
				return bytes;
			}
			return memoryStream.ToArray();
		}
	}
}
