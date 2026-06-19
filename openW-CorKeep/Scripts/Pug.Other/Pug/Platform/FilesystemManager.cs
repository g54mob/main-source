using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Pug.UnityExtensions;
using PugMod;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

namespace Pug.Platform
{
	[DisallowPatching]
	public class FilesystemManager : ManagerBase
	{
		public enum FileID
		{
			None = 0,
			Preferences = 1,
			Save = 2,
			WorldSave = 3,
			ServerPreferences = 4,
			MapParts = 5,
			ServerMapParts = 6,
			WorldInfo = 7,
			PlayerBanList = 8,
			AdminList = 9,
			WorldGenerationParameters = 10,
			PlayerPrefs = 11,
			__MAX_VALUE__ = 12
		}

		private enum FileType
		{
			None = 0,
			Singleton = 1,
			Character = 2,
			World = 3
		}

		public struct File : IEquatable<File>
		{
			public readonly int fileTypeId;

			public readonly int instance0;

			public readonly int instance1;

			public readonly bool encrypted;

			public readonly FileID FileID => (FileID)fileTypeId;

			public File(FileID fileTypeId, int instance, bool encrypted = false)
			{
				this.fileTypeId = (int)fileTypeId;
				instance0 = instance;
				instance1 = 0;
				this.encrypted = encrypted;
			}

			public File(FileID fileTypeId, int instance0, int instance1)
			{
				this.fileTypeId = (int)fileTypeId;
				this.instance0 = instance0;
				this.instance1 = instance1;
				encrypted = false;
			}

			public string GetFilePath()
			{
				return Manager.filesystemManager.GetFilePath(this);
			}

			public DateTime GetFileTime()
			{
				return Manager.filesystemManager.GetFileTime(this);
			}

			public byte[] Read(bool raw = false)
			{
				return Manager.filesystemManager.Read(this, raw);
			}

			public void Write(byte[] data, bool addToPool = false, bool force = false, bool raw = false)
			{
				Write(data, (data != null) ? data.Length : 0, addToPool, force, raw);
			}

			public void Write(byte[] data, int size, bool addToPool = false, bool force = false, bool raw = false)
			{
				Manager.filesystemManager.Write(this, data, size, addToPool, force, raw);
			}

			public void Delete(bool force = false)
			{
				Manager.filesystemManager.Delete(this, force);
			}

			public bool Exists()
			{
				return Manager.filesystemManager.FileExists(this);
			}

			public bool Equals(File other)
			{
				if (fileTypeId == other.fileTypeId && instance0 == other.instance0 && instance1 == other.instance1)
				{
					return encrypted == other.encrypted;
				}
				return false;
			}

			public override bool Equals(object obj)
			{
				if (obj is File other)
				{
					return Equals(other);
				}
				return false;
			}

			public override int GetHashCode()
			{
				return (int)math.hash(new int4(fileTypeId, instance0, instance1, (!encrypted) ? 1 : 0));
			}

			public override string ToString()
			{
				return $"{FileID} {instance0} {instance1}";
			}
		}

		private struct WriteRequest
		{
			public bool remove;

			public File file;

			public byte[] data;

			public int dataSize;

			public bool addToPool;

			public bool flush;

			public bool raw;

			public string subFolder;

			public DateTime dateTime;
		}

		private class StreamCounter : Stream
		{
			public int readCount;

			public int writeCount;

			public override bool CanRead => true;

			public override bool CanSeek => false;

			public override bool CanWrite => true;

			public override long Length => 0L;

			public override long Position
			{
				get
				{
					return 0L;
				}
				set
				{
					throw new NotSupportedException();
				}
			}

			public override void Flush()
			{
			}

			public override int Read(byte[] buffer, int offset, int count)
			{
				readCount += count;
				return count;
			}

			public override long Seek(long offset, SeekOrigin origin)
			{
				throw new NotSupportedException();
			}

			public override void SetLength(long value)
			{
				throw new NotSupportedException();
			}

			public override void Write(byte[] buffer, int offset, int count)
			{
				writeCount += count;
			}
		}

		private class FileEnumerator : IEnumerator<File>, IEnumerator, IDisposable, IEnumerable<File>, IEnumerable
		{
			private IEnumerator<string> files;

			private bool detectOldEncrypted;

			public File Current => Parse(files.Current, detectOldEncrypted);

			object IEnumerator.Current => Current;

			public FileEnumerator(IEnumerable<string> files, bool detectOldEncrypted = false)
			{
				this.files = files.GetEnumerator();
				this.detectOldEncrypted = detectOldEncrypted;
			}

			public bool MoveNext()
			{
				while (files.MoveNext())
				{
					if (Current.fileTypeId != 0)
					{
						return true;
					}
				}
				return false;
			}

			public void Reset()
			{
				files.Reset();
			}

			public void Dispose()
			{
			}

			public IEnumerator<File> GetEnumerator()
			{
				return this;
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		private static readonly bool[] typeIsSingleton = new bool[12]
		{
			false, true, false, false, true, false, false, false, true, true,
			false, true
		};

		private static readonly bool[] typeHasSecondInstance = new bool[12]
		{
			false, false, false, false, false, true, false, false, false, false,
			false, false
		};

		private static readonly string[] typeNames = new string[12]
		{
			null, "prefs", "saves", "worlds", "ServerConfig", "maps", "servermaps", "worldinfos", "PlayerBans", "Admins",
			"worldgenparams", "playerPrefs"
		};

		private static readonly string[] suffixes = new string[12]
		{
			null, ".json", ".json", ".world", ".json", ".mapparts", ".mapparts", ".worldinfo", ".json", ".json",
			".json", ".prefs"
		};

		private static readonly bool[] useCompression = new bool[12]
		{
			false, false, false, true, false, true, true, false, false, false,
			false, false
		};

		private static readonly bool[] useEncryption = new bool[12];

		private static readonly bool[] usedToHaveEncryption = new bool[12]
		{
			false, false, true, false, false, false, false, true, false, false,
			false, false
		};

		private static readonly int[] baseFileSize = new int[12]
		{
			0, 16384, 16384, 8388608, 16384, 131072, 131072, 16384, 16384, 16384,
			16384, 65536
		};

		private static readonly int[] maxWriteBufferPoolSize = new int[12]
		{
			0, 10, 10, 1, 10, 10, 10, 10, 10, 10,
			10, 2
		};

		private static readonly bool[] cloudSynced = new bool[12]
		{
			false, false, true, true, false, true, true, true, true, true,
			true, false
		};

		private static readonly FileType[] fileType = new FileType[12]
		{
			FileType.None,
			FileType.Singleton,
			FileType.Character,
			FileType.World,
			FileType.Singleton,
			FileType.World,
			FileType.World,
			FileType.World,
			FileType.Singleton,
			FileType.Singleton,
			FileType.World,
			FileType.Singleton
		};

		private static readonly int[] maxNumberInstance0 = new int[12]
		{
			0, 1, 61, 31, 1, 61, 31, 31, 1, 1,
			31, 1
		};

		private static readonly byte[] emptyFile = new byte[0];

		private static readonly string compressedFileEnding = ".gzip";

		private static readonly string encryptedFileEnding = ".enc";

		public FilesystemInterface platformImpl;

		private Thread writeThread;

		private BlockingCollection<WriteRequest> writeQueue = new BlockingCollection<WriteRequest>();

		private BlockingCollection<WriteRequest> poolQueue = new BlockingCollection<WriteRequest>();

		private BlockingCollection<WriteRequest> flushQueue = new BlockingCollection<WriteRequest>();

		private BlockingCollection<WriteRequest> returnQueue = new BlockingCollection<WriteRequest>();

		private Dictionary<File, bool> fileExistsCache = new Dictionary<File, bool>();

		private List<File> dirtyFiles = new List<File>();

		private StringBuilder builder = new StringBuilder(100);

		private List<byte[]>[] bufferPools;

		private Dictionary<File, Func<byte[]>> fileDataProviders = new Dictionary<File, Func<byte[]>>();

		private const int aesKeySize = 32;

		private readonly byte[] aesKey = new byte[32]
		{
			179, 83, 149, 245, 47, 93, 150, 176, 123, 189,
			119, 160, 238, 228, 203, 152, 222, 229, 247, 41,
			193, 64, 11, 240, 105, 30, 43, 219, 187, 26,
			199, 111
		};

		private bool _initialized;

		private static readonly ProfilerMarker InitMarker = new ProfilerMarker("FilesystemManager.Init");

		public DateTime LastWrite { get; private set; }

		private bool savingEnabled => Manager.prefs.saveEnabled;

		private Aes GetAes()
		{
			Aes aes = Aes.Create();
			aes.Mode = CipherMode.CBC;
			aes.Padding = PaddingMode.PKCS7;
			aes.KeySize = 256;
			return aes;
		}

		private void WriteHandler()
		{
			StringBuilder stringBuilder = new StringBuilder(100);
			bool flag = false;
			StreamCounter streamCounter = new StreamCounter();
			byte[] array = new byte[aesKey.Length];
			while (!writeQueue.IsCompleted)
			{
				try
				{
					WriteRequest item;
					try
					{
						if (!flag || !writeQueue.TryTake(out item))
						{
							if (flag)
							{
								try
								{
									platformImpl.EndWrite();
								}
								catch (Exception exception)
								{
									Debug.LogException(exception);
								}
								flag = false;
							}
							item = writeQueue.Take();
						}
					}
					catch (InvalidOperationException)
					{
						goto end_IL_0025;
					}
					if (item.flush)
					{
						flushQueue.Add(item);
						continue;
					}
					if (!flag)
					{
						try
						{
							platformImpl.BeginWrite();
						}
						catch (Exception exception2)
						{
							Debug.LogException(exception2);
						}
						flag = true;
					}
					bool flag2 = useCompression[item.file.fileTypeId];
					bool flag3 = useEncryption[item.file.fileTypeId];
					EnsureFileDirExists(item.file, item.subFolder);
					string filePath = GetFilePath(stringBuilder, item.file, item.subFolder);
					string fileName = GetFileName(stringBuilder, item.file);
					byte[] array2 = item.data;
					int num = item.dataSize;
					if (!item.raw && !item.remove && flag2)
					{
						streamCounter.writeCount = 0;
						using (GZipStream gZipStream = new GZipStream(streamCounter, System.IO.Compression.CompressionLevel.Optimal))
						{
							gZipStream.Write(item.data, 0, item.dataSize);
						}
						num = streamCounter.writeCount;
						array2 = new byte[num];
						using MemoryStream stream = new MemoryStream(array2, 0, num);
						using GZipStream gZipStream2 = new GZipStream(stream, System.IO.Compression.CompressionLevel.Optimal);
						gZipStream2.Write(item.data, 0, item.dataSize);
					}
					if (!item.raw && !item.remove && flag3)
					{
						using Aes aes = GetAes();
						Array.Copy(aesKey, array, aesKey.Length);
						for (int i = 0; i < array.Length; i++)
						{
							array[i] ^= (byte)(1 << (item.file.instance0 + item.file.fileTypeId + i) % 8);
						}
						byte[] iV = aes.IV;
						int num2 = aes.BlockSize / 8;
						byte[] buffer = array2;
						int count = num;
						num = iV.Length + ((num + num2) & ~(num2 - 1));
						array2 = new byte[num];
						using (MemoryStream stream2 = new MemoryStream(array2, 0, num - iV.Length))
						{
							using CryptoStream cryptoStream = new CryptoStream(stream2, aes.CreateEncryptor(array, iV), CryptoStreamMode.Write);
							cryptoStream.Write(buffer, 0, count);
						}
						Array.Copy(iV, 0, array2, num - iV.Length, iV.Length);
					}
					try
					{
						if (item.remove)
						{
							platformImpl.Delete(filePath);
						}
						else if (array2.Length != num)
						{
							byte[] array3 = new byte[num];
							Array.Copy(array2, array3, num);
							platformImpl.Write(fileName, filePath, array3);
						}
						else
						{
							platformImpl.Write(fileName, filePath, array2);
						}
					}
					catch (Exception ex2)
					{
						Debug.LogError("Exception trying to write " + filePath + ": " + ex2.Message);
					}
					if (item.addToPool)
					{
						poolQueue.Add(item);
					}
					returnQueue.Add(item);
					continue;
					end_IL_0025:;
				}
				catch (Exception exception3)
				{
					Debug.LogError("Unexpected exception in write handler");
					Debug.LogException(exception3);
					continue;
				}
				break;
			}
			if (flag)
			{
				try
				{
					platformImpl.EndWrite();
				}
				catch (Exception exception4)
				{
					Debug.LogException(exception4);
				}
			}
		}

		private void EnsureFileDirExists(File file, string subFolder)
		{
			int fileTypeId = file.fileTypeId;
			string text = "";
			if (!string.IsNullOrEmpty(subFolder))
			{
				if (!platformImpl.DirectoryExists(subFolder))
				{
					platformImpl.CreateDirectory(subFolder);
				}
				text = text + subFolder + "/";
			}
			if (typeIsSingleton[fileTypeId])
			{
				return;
			}
			text += typeNames[fileTypeId];
			if (!platformImpl.DirectoryExists(text))
			{
				platformImpl.CreateDirectory(text);
			}
			if (typeHasSecondInstance[fileTypeId])
			{
				text = text + "/" + file.instance0;
				if (!platformImpl.DirectoryExists(text))
				{
					platformImpl.CreateDirectory(text);
				}
			}
		}

		public bool IsCloudSynced(File file)
		{
			return cloudSynced[file.fileTypeId];
		}

		public string GetFilePath(File file)
		{
			return GetFilePath(builder, file);
		}

		private static string GetFilePath(StringBuilder builder, File file, string subFolder = null)
		{
			int fileTypeId = file.fileTypeId;
			builder.Clear();
			if (!string.IsNullOrEmpty(subFolder))
			{
				builder.Append(subFolder);
				builder.Append('/');
			}
			if (!typeIsSingleton[fileTypeId])
			{
				builder.Append(typeNames[fileTypeId]);
				builder.Append('/');
				builder.Append(file.instance0);
				if (typeHasSecondInstance[fileTypeId])
				{
					builder.Append('/');
					builder.Append(file.instance1);
				}
			}
			else
			{
				builder.Append(typeNames[fileTypeId]);
			}
			builder.Append(suffixes[fileTypeId]);
			if (useCompression[fileTypeId])
			{
				builder.Append(compressedFileEnding);
			}
			if (useEncryption[fileTypeId] || file.encrypted)
			{
				builder.Append(encryptedFileEnding);
			}
			return builder.ToString();
		}

		private static string GetFileName(StringBuilder builder, File file)
		{
			return null;
		}

		public DateTime GetFileTime(File file)
		{
			string filePath = GetFilePath(file);
			return platformImpl.GetFileTime(filePath);
		}

		public int GetMaxFileInstance0(FileID fileTypeId)
		{
			return maxNumberInstance0[(int)fileTypeId];
		}

		public File GetFile(FileID file)
		{
			return GetFile(file, -1);
		}

		public File GetFile(FileID file, int instance)
		{
			return new File(file, instance);
		}

		public File GetFile(FileID file, int instance0, int instance1)
		{
			return new File(file, instance0, instance1);
		}

		public void RegisterFileDataProvider(File file, Func<byte[]> provider)
		{
			fileDataProviders[file] = provider;
			fileExistsCache[file] = true;
		}

		public bool FileExists(File file)
		{
			if (fileExistsCache.ContainsKey(file))
			{
				return fileExistsCache[file];
			}
			string filePath = GetFilePath(file);
			return platformImpl.FileExists(filePath);
		}

		private byte[] Decompress(byte[] data)
		{
			uint size;
			bool flag = FileCompressionUtility.TryGetGzipCompressedSize(data, out size);
			bool flag2 = !flag && FileCompressionUtility.TryGetBrotliCompressedSize(data, out size);
			if (!flag && !flag2)
			{
				Debug.LogError("Provided buffer is not GZIP or Brotli compressed");
				return emptyFile;
			}
			int num = (int)size;
			byte[] array = new byte[num];
			using MemoryStream stream = new MemoryStream(data, 0, data.Length);
			using Stream stream2 = (flag ? ((Stream)new GZipStream(stream, CompressionMode.Decompress)) : ((Stream)new BrotliStream(stream, CompressionMode.Decompress)));
			stream2.Read(array, 0, num);
			return array;
		}

		private byte[] Decrypt(File file, byte[] data)
		{
			try
			{
				using Aes aes = GetAes();
				if (data.Length < aes.IV.Length)
				{
					Debug.LogError(file.GetFilePath() + " is too small to decrypt");
					return emptyFile;
				}
				byte[] array = new byte[aesKey.Length];
				Array.Copy(aesKey, array, aesKey.Length);
				for (int i = 0; i < array.Length; i++)
				{
					array[i] ^= (byte)(1 << (file.instance0 + file.fileTypeId + i) % 8);
				}
				byte[] iV = aes.IV;
				Array.Copy(data, data.Length - iV.Length, iV, 0, iV.Length);
				using MemoryStream memoryStream = new MemoryStream();
				using (MemoryStream stream = new MemoryStream(data, 0, data.Length - iV.Length))
				{
					using CryptoStream cryptoStream = new CryptoStream(stream, aes.CreateDecryptor(array, iV), CryptoStreamMode.Read);
					cryptoStream.CopyTo(memoryStream);
				}
				return memoryStream.ToArray();
			}
			catch
			{
				Debug.Log("Trying old encryptiong scheme...");
				try
				{
					using Aes aes2 = GetAes();
					byte[] array2 = new byte[aesKey.Length];
					Array.Copy(aesKey, array2, aesKey.Length);
					for (int j = 0; j < array2.Length; j++)
					{
						array2[j] ^= (byte)(1 << file.instance0 + file.fileTypeId);
					}
					byte[] iV2 = aes2.IV;
					Array.Copy(data, data.Length - iV2.Length, iV2, 0, iV2.Length);
					using MemoryStream memoryStream2 = new MemoryStream();
					using (MemoryStream stream2 = new MemoryStream(data, 0, data.Length - iV2.Length))
					{
						using CryptoStream cryptoStream2 = new CryptoStream(stream2, aes2.CreateDecryptor(array2, iV2), CryptoStreamMode.Read);
						cryptoStream2.CopyTo(memoryStream2);
					}
					return memoryStream2.ToArray();
				}
				catch (Exception exception)
				{
					Debug.LogError("Failed to decrypt " + file.GetFilePath());
					Debug.LogException(exception);
					return emptyFile;
				}
			}
		}

		public void Flush()
		{
			System.Threading.ThreadPriority priority = writeThread.Priority;
			writeThread.Priority = System.Threading.ThreadPriority.Normal;
			writeQueue.Add(new WriteRequest
			{
				flush = true
			});
			flushQueue.Take();
			writeThread.Priority = priority;
		}

		public byte[] Read(File file, bool raw = false)
		{
			Flush();
			Func<byte[]> value;
			byte[] array = (fileDataProviders.TryGetValue(file, out value) ? value() : platformImpl.Read(GetFilePath(file)));
			if (array != null)
			{
				if (!raw && (useEncryption[file.fileTypeId] || file.encrypted))
				{
					array = Decrypt(file, array);
				}
				if (!raw && useCompression[file.fileTypeId])
				{
					array = Decompress(array);
				}
			}
			else
			{
				Debug.LogWarning("FilesystemManager.Read: file read failed. See previous logs for more information.");
			}
			return array;
		}

		public void Write(File file, byte[] data, bool addToPool = false, bool force = false, bool raw = false, string subFolder = null)
		{
			Write(file, data, data.Length, addToPool, force, raw, subFolder);
		}

		public void Write(File file, byte[] data, int size, bool addToPool = false, bool force = false, bool raw = false, string subFolder = null)
		{
			if (!savingEnabled && !force)
			{
				Debug.Log("Skipping write since saving not enabled");
				if (data != null && addToPool)
				{
					ReturnToFileWritePool((FileID)file.fileTypeId, data);
				}
				return;
			}
			if (fileDataProviders.ContainsKey(file))
			{
				Debug.Log("Skipping write since a file data provider was used");
				if (data != null && addToPool)
				{
					ReturnToFileWritePool((FileID)file.fileTypeId, data);
				}
				return;
			}
			if (data == null)
			{
				data = emptyFile;
			}
			if (subFolder == null)
			{
				if (fileExistsCache.ContainsKey(file))
				{
					fileExistsCache[file] = true;
				}
				else
				{
					fileExistsCache.Add(file, value: true);
				}
			}
			if (writeQueue.IsAddingCompleted)
			{
				Debug.LogError("filesystem manager already stopped, too late to write file");
				return;
			}
			dirtyFiles.Add(file);
			writeQueue.Add(new WriteRequest
			{
				file = file,
				data = data,
				dataSize = size,
				addToPool = addToPool,
				raw = raw,
				subFolder = subFolder,
				dateTime = DateTime.Now
			});
		}

		public void DeleteAll(FileID fileType, int instance)
		{
			foreach (File allFile in GetAllFiles(fileType, instance))
			{
				Delete(allFile);
			}
		}

		public void Delete(File file, bool force = false)
		{
			if (!savingEnabled && !force)
			{
				Debug.Log("Skipping delete since saving not enabled");
				return;
			}
			if (fileDataProviders.ContainsKey(file))
			{
				fileDataProviders.Remove(file);
			}
			fileExistsCache[file] = false;
			if (writeQueue.IsAddingCompleted)
			{
				Debug.LogWarning("filesystem manager already stopped, too late to delete file");
				return;
			}
			dirtyFiles.Add(file);
			writeQueue.Add(new WriteRequest
			{
				file = file,
				remove = true,
				dateTime = DateTime.Now
			});
		}

		private void BackupFolder(string folder)
		{
			string text = "backups";
			if (platformImpl.DirectoryExists(folder))
			{
				if (!platformImpl.DirectoryExists(text))
				{
					platformImpl.CreateDirectory(text);
				}
				string text2 = text + "/" + folder;
				string text3 = text + "/" + folder + "_old";
				if (platformImpl.DirectoryExists(text3))
				{
					platformImpl.DeleteDirectory(text3);
				}
				if (platformImpl.DirectoryExists(text2))
				{
					platformImpl.CopyDirectory(text2, text3);
					platformImpl.DeleteDirectory(text2);
				}
				platformImpl.CopyDirectory(folder, text2);
			}
		}

		public void Backup()
		{
			Debug.Log("Backing up saves...");
			BackupFolder(typeNames[2]);
			BackupFolder(typeNames[3]);
			BackupFolder(typeNames[5]);
			BackupFolder(typeNames[6]);
			BackupFolder(typeNames[7]);
		}

		public bool BackingStorageIsFull()
		{
			return platformImpl.GetRemainingBytes() < 10485760;
		}

		public static File Parse(string path, bool detectOldEncrypted = false)
		{
			File result = default(File);
			try
			{
				for (int i = 1; i < typeNames.Length; i++)
				{
					if (!path.StartsWith(typeNames[i], StringComparison.InvariantCultureIgnoreCase))
					{
						continue;
					}
					if (typeIsSingleton[i])
					{
						result = new File((FileID)i, 0);
						continue;
					}
					if (typeHasSecondInstance[i])
					{
						string[] array = path.Split('/');
						if (array.Length != 3)
						{
							throw new Exception("incorrect # of /: " + path);
						}
						int instance = int.Parse(array[1]);
						string[] array2 = array[2].Split('.');
						if (array2.Length != 2 && array2.Length != 3)
						{
							throw new Exception("too many/too few dots: " + array[1]);
						}
						int instance2 = int.Parse(array2[0]);
						result = new File((FileID)i, instance, instance2);
						continue;
					}
					string[] array3 = path.Split('/');
					if (array3.Length != 2)
					{
						throw new Exception("incorrect # of /: " + path);
					}
					string[] array4 = array3[1].Split('.');
					int num = 2;
					if (useCompression[i])
					{
						num++;
					}
					if (useEncryption[i])
					{
						num++;
					}
					bool encrypted = false;
					if (array4.Length == num + 1 && usedToHaveEncryption[i] && path.EndsWith(encryptedFileEnding))
					{
						if (!detectOldEncrypted)
						{
							continue;
						}
						encrypted = true;
					}
					else if (array4.Length != num)
					{
						throw new Exception("too many/too few dots: " + array3[1]);
					}
					int instance3 = int.Parse(array4[0]);
					result = new File((FileID)i, instance3, encrypted);
				}
			}
			catch
			{
				if (path.EndsWith(encryptedFileEnding))
				{
					Debug.LogWarning("detected encrypted file at " + path);
				}
				else
				{
					Debug.LogWarning("unknown file at " + path);
				}
			}
			return result;
		}

		public IEnumerable<File> GetAllFiles(FileID fileType, int instance0 = -1, int instance1 = -1, bool detectOldEncrypted = false)
		{
			IEnumerable<string> enumerable = null;
			string path = typeNames[(int)fileType];
			if (platformImpl.DirectoryExists(path))
			{
				enumerable = platformImpl.GetFiles(path);
			}
			if (enumerable == null)
			{
				return Array.Empty<File>();
			}
			return new FileEnumerator(enumerable, detectOldEncrypted).Where((File f) => (instance0 == -1 || f.instance0 == instance0) && (instance1 == -1 || f.instance1 == instance1));
		}

		public IEnumerable<File> GetDirtyFiles()
		{
			return dirtyFiles;
		}

		public IEnumerable<File> GetAllFiles(bool detectOldEncrypted = false)
		{
			IEnumerable<string> allFiles = platformImpl.GetAllFiles();
			if (allFiles == null)
			{
				return Array.Empty<File>();
			}
			return new FileEnumerator(allFiles, detectOldEncrypted);
		}

		public byte[] GetFileWriteBuffer(FileID fileTypeId, int minSize)
		{
			WriteRequest item;
			while (poolQueue.TryTake(out item))
			{
				ReturnToFileWritePool((FileID)item.file.fileTypeId, item.data);
			}
			return GetOrAllocateFileWriteBuffer(fileTypeId, minSize);
		}

		private void ReturnToFileWritePool(FileID fileTypeId, byte[] buffer)
		{
			if (buffer != null)
			{
				bufferPools[(int)fileTypeId].Add(buffer);
				TrimFileWriteBufferPoolSize(fileTypeId, maxWriteBufferPoolSize[(int)fileTypeId]);
			}
		}

		private void TrimFileWriteBufferPoolSize(FileID fileTypeID, int targetSize)
		{
			targetSize = math.max(targetSize, 0);
			List<byte[]> list = bufferPools[(int)fileTypeID];
			while (list.Count > targetSize)
			{
				int index = 0;
				for (int i = 1; i < list.Count; i++)
				{
					if (list[i].Length < list[index].Length)
					{
						index = i;
					}
				}
				list.RemoveAtSwapBack(index);
			}
		}

		private byte[] GetOrAllocateFileWriteBuffer(FileID fileTypeID, int minSize)
		{
			List<byte[]> list = bufferPools[(int)fileTypeID];
			int num = -1;
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].Length >= minSize && (num == -1 || list[i].Length < list[num].Length))
				{
					num = i;
				}
			}
			if (num != -1)
			{
				byte[] result = list[num];
				list.RemoveAtSwapBack(num);
				return result;
			}
			int num2 = baseFileSize[(int)fileTypeID];
			if (num2 < minSize)
			{
				num2 = (int)math.ceil(1.26 * (double)minSize);
			}
			TrimFileWriteBufferPoolSize(fileTypeID, maxWriteBufferPoolSize[(int)fileTypeID] - 1);
			int num3 = num2;
			for (int j = 0; j < bufferPools[(int)fileTypeID].Count; j++)
			{
				num3 += bufferPools[(int)fileTypeID][j].Length;
			}
			if (num3 > 1048576)
			{
				Debug.Log($"Allocating a new file write buffer of size {ByteToMb(num2):F3}MB for {fileTypeID}. Total buffer size for this file including pool is {ByteToMb(num3):F3}MB");
			}
			return new byte[num2];
		}

		public static float ByteToMb(int bytes)
		{
			return (float)bytes / 1024f / 1024f;
		}

		public static float ByteToMb(long bytes)
		{
			return (float)bytes / 1024f / 1024f;
		}

		public override bool Init()
		{
			using (InitMarker.Auto())
			{
				bufferPools = new List<byte[]>[baseFileSize.Length];
				for (int i = 1; i < baseFileSize.Length; i++)
				{
					bufferPools[i] = new List<byte[]>();
				}
				writeThread = new Thread(WriteHandler);
				writeThread.Priority = System.Threading.ThreadPriority.BelowNormal;
				writeThread.Start();
				Manager.platform.CloudSyncDown();
				Flush();
				for (int j = 0; j < useCompression.Length; j++)
				{
					if (!useCompression[j])
					{
						continue;
					}
					foreach (File allFile in GetAllFiles((FileID)j))
					{
						if (!allFile.Exists())
						{
							string text = GetFilePath(allFile).Replace(compressedFileEnding, "");
							if (platformImpl.FileExists(text))
							{
								byte[] data = platformImpl.Read(text);
								Debug.Log("Compressing old file " + text);
								Write(allFile, data, addToPool: false, force: true);
								Flush();
								platformImpl.Delete(text);
							}
						}
					}
				}
				for (int k = 0; k < usedToHaveEncryption.Length; k++)
				{
					if (!usedToHaveEncryption[k])
					{
						continue;
					}
					if (useEncryption[k])
					{
						Debug.LogError($"{(FileID)k} still set to use encryption");
						continue;
					}
					foreach (File allFile2 in GetAllFiles((FileID)k, -1, -1, detectOldEncrypted: true))
					{
						if (!allFile2.encrypted)
						{
							continue;
						}
						File file = new File(allFile2.FileID, allFile2.instance0);
						if (!file.Exists() || k == 7)
						{
							string filePath = GetFilePath(allFile2);
							Debug.Log("Decrypting " + filePath);
							byte[] array = allFile2.Read();
							if (array.Length != 0)
							{
								file.Write(array, addToPool: false, force: true);
								Flush();
							}
							else
							{
								Debug.Log("Decrypt failed");
							}
							allFile2.Delete(force: true);
						}
					}
				}
				_initialized = true;
				return true;
			}
		}

		public override void Deinit()
		{
			if (_initialized)
			{
				writeThread.Priority = System.Threading.ThreadPriority.Normal;
				Flush();
				Manager.platform.CloudSyncUp();
				writeQueue.CompleteAdding();
				Thread.Sleep(1);
				while (writeThread.IsAlive)
				{
					Thread.Sleep(100);
				}
			}
		}

		public void OnSceneUnload()
		{
			if (Manager.sceneHandler.isInGame)
			{
				Flush();
				Manager.platform.CloudSyncUp();
				dirtyFiles.Clear();
			}
		}

		private void Update()
		{
			WriteRequest item;
			while (returnQueue.TryTake(out item))
			{
				if (item.file.fileTypeId == 3)
				{
					LastWrite = item.dateTime;
				}
			}
			int count = writeQueue.Count;
			if (count > 0)
			{
				bool flag = count > 10;
				System.Threading.ThreadPriority priority = writeThread.Priority;
				if (priority == System.Threading.ThreadPriority.BelowNormal && flag)
				{
					writeThread.Priority = System.Threading.ThreadPriority.Normal;
				}
				else if (priority != System.Threading.ThreadPriority.BelowNormal && !flag)
				{
					writeThread.Priority = System.Threading.ThreadPriority.BelowNormal;
				}
			}
		}

		public unsafe static byte[] SerializeToBinary<T>(T file, FileID bufferID, out int byteCount)
		{
			string text = JsonUtility.ToJson(file);
			fixed (char* chars = text)
			{
				byteCount = Encoding.UTF8.GetByteCount(chars, text.Length);
				byte[] fileWriteBuffer = Manager.filesystemManager.GetFileWriteBuffer(bufferID, byteCount);
				fixed (byte* bytes = fileWriteBuffer)
				{
					Encoding.UTF8.GetBytes(chars, text.Length, bytes, fileWriteBuffer.Length);
				}
				return fileWriteBuffer;
			}
		}

		public static byte[] SerializeToBinary<T>(T file)
		{
			return Encoding.UTF8.GetBytes(JsonUtility.ToJson(file));
		}

		public static void LoadBinaryFile<T>(File file, ref T returnFile)
		{
			JsonUtility.FromJsonOverwrite(Encoding.UTF8.GetString(file.Read()), returnFile);
		}
	}
}
