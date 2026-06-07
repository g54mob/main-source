using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using DV.Common;
using DV.UserManagement.Integration;
using DV.UserManagement.Storage;
using DV.UserManagement.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.UserManagement.Data
{
	public class SaveGameSnapshot : ISaveGame, IDisposable
	{
		public const int CHUNK_MAINDATA = 1;

		public const int CHUNK_METADATA = 2;

		public const int CHUNK_THUMBNAIL = 3;

		public const int CHUNK_CLIENT_START = 10;

		internal const int SaveGameSnapshotVersion = 1;

		internal const int SaveGameUID_Digits = 5;

		public const string SAVE_PACK_MAGIC = "SAVE";

		public const byte SAVE_PACK_VERSION = 1;

		internal static readonly AJSONDataUpgrader[] InternalSnapshotMetaUpgraders = new AJSONDataUpgrader[0];

		internal static readonly ASaveSnapshotUpgrader[] InternalGameDataUpgraders = new ASaveSnapshotUpgrader[0];

		internal static readonly Regex SaveSnapshotPattern = new Regex("^([0-9]{" + 5 + "})_.*$");

		internal static readonly string UIDFormat = new string('0', 5);

		private bool thumbnailError;

		private List<(int Type, byte[] Data)> customChunks;

		private byte[] thumbnailData;

		[JsonIgnore]
		public int UID { get; internal set; }

		[JsonProperty]
		public DateTimeOffset Timestamp { get; private set; }

		[JsonProperty]
		public SaveType Type { get; private set; }

		[JsonProperty]
		public string Name { get; set; }

		[JsonProperty]
		public string World { get; private set; }

		[JsonProperty]
		public string GameMode { get; private set; }

		[JsonIgnore]
		public JObject Data { get; private set; }

		[JsonIgnore]
		public Texture2D Thumbnail { get; private set; }

		[JsonIgnore]
		public IGameSession ParentSession { get; internal set; }

		[JsonIgnore]
		public UserManager ParentManager { get; internal set; }

		[JsonIgnore]
		public string BasePath { get; internal set; }

		[JsonIgnore]
		public bool IsDataLoaded => Data != null;

		[JsonIgnore]
		public bool IsThumbnailLoaded => Thumbnail != null;

		[JsonIgnore]
		internal IStorageProvider Storage { get; set; }

		[JsonIgnore]
		public Paky LoadedPak { get; internal set; }

		[JsonIgnore]
		public List<(int Type, byte[] Data)> CustomChunkData
		{
			get
			{
				if (customChunks == null)
				{
					if (LoadedPak == null)
					{
						throw new InvalidOperationException("LoadedPak is null, can't read custom chunks from it");
					}
					LoadCustomChunks();
				}
				return customChunks;
			}
		}

		[Obsolete("Don't use this in code, this is for JSON processing only")]
		[JsonConstructor]
		internal SaveGameSnapshot()
		{
		}

		public void LoadData()
		{
			if (!IsDataLoaded)
			{
				if (Storage == null)
				{
					throw new InvalidOperationException("Storage is null, so data can't be loaded, check the code");
				}
				if (LoadedPak == null)
				{
					throw new InvalidOperationException("LoadedPak is null, base file wasn't loaded properly");
				}
				byte[] array = null;
				if (ParentSession.Owner is User user)
				{
					array = user.EncryptionKey;
				}
				byte[] array2 = LoadedPak.ReadFirst(1);
				if (array != null)
				{
					array2 = Storage.DecryptData(array2, array);
				}
				Data = JsonConvert.DeserializeObject<JObject>(UserManager.ENCODING.GetString(array2), UserManager.JSON_SERIALIZER_SETTINGS);
				Data = Data.Upgrade(ParentManager, BasePath, CustomChunkData, Storage, ParentSession as GameSession, ParentManager.saveDataUpgraders);
			}
		}

		private void LoadCustomChunks()
		{
			customChunks = new List<(int, byte[])>();
			foreach (Paky.Chunk chunk in LoadedPak.Chunks)
			{
				if (chunk.Type >= 10)
				{
					customChunks.Add((chunk.Type, LoadedPak.ReadChunk(chunk)));
				}
			}
		}

		public void LoadThumbnail()
		{
			if (IsThumbnailLoaded || thumbnailError)
			{
				return;
			}
			if (LoadedPak == null)
			{
				throw new InvalidOperationException("LoadedPak is null, base file wasn't loaded properly");
			}
			try
			{
				if (thumbnailData == null)
				{
					thumbnailData = LoadedPak.ReadFirst(3);
					if (thumbnailData == null)
					{
						thumbnailError = true;
						Debug.LogWarning(Name + " snapshot doesn't have a thumbnail");
						return;
					}
				}
				Texture2D texture2D = new Texture2D(1, 1, TextureFormat.RGB24, mipChain: false);
				texture2D.LoadImage(thumbnailData, markNonReadable: true);
				texture2D.wrapMode = TextureWrapMode.Clamp;
				texture2D.name = Name;
				Thumbnail = texture2D;
			}
			catch (Exception ex)
			{
				Debug.LogError("Thumbnail for " + Name + " couldn't be loaded: " + ex.Message + "\n" + ex.StackTrace);
				Thumbnail = null;
				thumbnailError = true;
			}
		}

		public void UnloadThumbnail()
		{
			if (Thumbnail != null)
			{
				UnityEngine.Object.Destroy(Thumbnail);
				Thumbnail = null;
			}
		}

		internal SaveGameSnapshot(UserManager manager, GameSession session, IStorageProvider storage, SaveType type, int uid, DateTimeOffset timestamp, string name, JObject data, Texture2D thumbnail, List<(int Type, byte[] Data)> customChunks = null)
		{
			ParentManager = manager;
			ParentSession = session;
			GameMode = session.GameMode;
			Storage = storage;
			UID = uid;
			BasePath = Path.Combine(session.BasePath, "Saves", uid.ToString(UIDFormat) + "_" + UserManager.GetIdentifierString(name.Clamp(32)) + ".save");
			Timestamp = timestamp;
			Type = type;
			Name = name;
			World = session.World;
			Data = data;
			this.customChunks = (List<(int Type, byte[] Data)>)((customChunks != null) ? ((IList)customChunks) : ((IList)new List<(int, byte[])>()));
			if (data == null)
			{
				Debug.LogError("SaveGameSnapshot created with data == null!");
			}
			if (thumbnail != null)
			{
				if (!thumbnail.isReadable)
				{
					Debug.LogWarning("Thumbnail texture for save " + name + " is not readable, won't be able to save it, fixme");
				}
				Thumbnail = new Texture2D(thumbnail.width, thumbnail.height, thumbnail.format, thumbnail.mipmapCount, linear: false);
				Graphics.CopyTexture(thumbnail, Thumbnail);
			}
		}

		internal void WriteData()
		{
			if (Data == null)
			{
				throw new InvalidOperationException("Save data isn't present");
			}
			byte[] array = null;
			if (ParentSession.Owner is User user)
			{
				array = user.EncryptionKey;
			}
			List<Paky.InputData> list = new List<Paky.InputData>();
			JObject jObject = JObject.FromObject(this);
			jObject.SetVersion(ParentManager.SnapshotMetaVersion);
			list.Add(new Paky.InputData(2, jObject.ToString()));
			Data.SetVersion(ParentManager.SaveDataVersion);
			if (array != null)
			{
				byte[] bytes = UserManager.ENCODING.GetBytes(Data.ToString(Formatting.None));
				bytes = Storage.EncryptData(bytes, array);
				list.Add(new Paky.InputData(1, bytes));
			}
			else
			{
				list.Add(new Paky.InputData(1, Data.ToString()));
			}
			if (thumbnailData != null)
			{
				list.Add(new Paky.InputData(3, thumbnailData));
			}
			else if (Thumbnail != null && Thumbnail.isReadable)
			{
				list.Add(new Paky.InputData(3, Thumbnail.EncodeToJPG()));
			}
			if (customChunks != null)
			{
				foreach (var customChunk in customChunks)
				{
					list.Add(new Paky.InputData(customChunk.Type, customChunk.Data));
				}
			}
			if (LoadedPak != null)
			{
				LoadedPak.Close();
			}
			Stream stream = Storage.OpenFileForWriting(BasePath);
			Paky.Pack(list, "SAVE", 1, stream);
			stream.Close();
			IStreamProvider streamProvider = Storage.OpenFileForReading(BasePath);
			LoadedPak = new Paky(streamProvider, "SAVE", 1);
		}

		public void Dispose()
		{
			Data = null;
			thumbnailData = null;
			if (LoadedPak != null)
			{
				LoadedPak.Close();
				LoadedPak = null;
			}
			if (Thumbnail != null)
			{
				UnityEngine.Object.Destroy(Thumbnail);
				Thumbnail = null;
			}
		}

		internal void DeleteData()
		{
			Dispose();
			Storage.DeleteFile(BasePath);
		}

		public List<string> GetFiles(List<string> fileList)
		{
			if (fileList == null)
			{
				fileList = new List<string>();
			}
			if (Storage.FileExists(BasePath))
			{
				fileList.Add(Storage.SanitizeName(BasePath));
			}
			return fileList;
		}

		public void FlushToDisk()
		{
			if (LoadedPak != null)
			{
				if (Data == null)
				{
					LoadData();
				}
				if (!IsThumbnailLoaded)
				{
					LoadThumbnail();
				}
				if (customChunks == null)
				{
					LoadCustomChunks();
				}
				LoadedPak.Close();
				LoadedPak = null;
			}
			else if (Data == null)
			{
				throw new InvalidOperationException("Data isn't loaded, and the pak file isn't loaded either, can't save");
			}
			WriteData();
			if (LoadedPak == null)
			{
				Debug.LogError("LoadedPak is null at the end of FlushToDisk!");
			}
		}

		public override string ToString()
		{
			return $"[{UID.ToString(UIDFormat)} - {Type}] {Name}";
		}
	}
}
