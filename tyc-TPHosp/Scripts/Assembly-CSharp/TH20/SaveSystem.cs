#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using FullInspector.Internal;
using FullSerializerSave;
using LZ4ps;
using MessagePack;
using UnityConsole;
using UnityEngine;

namespace TH20
{
	public class SaveSystem : MustCallDestroy
	{
		private struct RoomTemplatesSaveFileParts
		{
			public int Signature;

			public int Version;

			public int HeaderSizeCompressed;

			public int HeaderSizeUncompressed;

			public int BodySizeCompressed;

			public int BodySizeUncompressed;

			public byte[] HeaderSerializedBytesCompressed;

			public byte[] BodySerializedBytesCompressed;
		}

		private struct LevelSaveFileParts
		{
			public int Signature;

			public int Version;

			public int HeaderSizeCompressed;

			public int HeaderSizeUncompressed;

			public int BodySizeCompressed;

			public int BodySizeUncompressed;

			public byte[] HeaderSerializedBytesCompressed;

			public byte[] BodySerializedBytesCompressed;
		}

		private struct MetagameSaveFileParts
		{
			public int Signature;

			public int Version;

			public int HeaderSizeCompressed;

			public int HeaderSizeUncompressed;

			public int BodySizeCompressed;

			public int BodySizeUncompressed;

			public byte[] HeaderSerializedBytesCompressed;

			public byte[] BodySerializedBytesCompressed;
		}

		public const string FileExtension = "sav";

		public const string FileExtensionMetagame = "csav";

		public const string FileExtensionRoomTemplates = "tsav";

		public const string FileExtensionWithDot = ".sav";

		public const string FileExtensionMetagameWithDot = ".csav";

		public const string FileExtensionRoomTemplatesWithDot = ".tsav";

		private const string MetagameSaveName = "career";

		private const string RoomTemplatesSubdirectoryName = "RoomTemplates";

		private const string SaveLocationSubdirectoryName = "Saves";

		private const string DebugSaveOutputPathSubdirectoryName = "SaveDebug";

		private const string SaveSlotSubdirectoryPrefix = "Slot";

		public const int NumSaveSlots = 3;

		public static readonly string SaveLocation = Path.Combine(PlatformFileManager.CloudDirectory, "Saves");

		public static readonly string SaveLocationEditor = Path.Combine(Directories.CloudDirectoryEditor, "Saves");

		public static readonly string SaveLocationStandalone = Path.Combine(Directories.CloudDirectoryStandalone, "Saves");

		public static readonly string RoomTemplatesSaveLocation = Path.Combine(PlatformFileManager.CloudDirectory, "RoomTemplates");

		public static readonly string RoomTemplatesSaveLocationEditor = Path.Combine(PlatformFileManager.CloudDirectory, "RoomTemplates");

		public static readonly string RoomTemplatesSaveLocationStandalone = Path.Combine(PlatformFileManager.CloudDirectory, "RoomTemplates");

		public static readonly string DebugSaveOutputPath = Path.Combine(Directories.GameOutputDirectory, "SaveDebug");

		public static readonly string DebugSaveOutputPathEditor = Path.Combine(Directories.GameOutputDirectoryEditor, "SaveDebug");

		public static readonly string DebugSaveOutputPathStandalone = Path.Combine(Directories.GameOutputDirectoryStandalone, "SaveDebug");

		private const int SaveSizeLimit = 268435456;

		private const int SaveFileSignature = 1818783860;

		private const int SaveFileSignatureMetagame = 1835561076;

		private const int SaveFileSignatureRoomTemplates = 1919447156;

		private static readonly int SaveFileVersion = 3;

		private static readonly int SaveFileVersionMetagame = 2;

		private static readonly int SaveFileVersionRoomTemplates = 1;

		private readonly BiDictionary<int, object> _assetIDs;

		private readonly fsSerializer _serializerLevel;

		private readonly fsSerializer _serializerMetagame;

		private readonly fsSerializer _serializerRoomTemplates;

		private readonly StringBuilder _largeStringBuilderJSONCache = new StringBuilder();

		private readonly StringBuilder _smallStringBuilderJSONCache = new StringBuilder();

		private readonly MetagameSaveHeader[] _metagameSaveHeaders = new MetagameSaveHeader[3];

		private readonly List<SaveFileHeader>[] _mSaveFileList = new List<SaveFileHeader>[3];

		private readonly SaveFileHeader[] _mMostRecentSave = new SaveFileHeader[3];

		private int _mostRecentMetagameSaveSlotIndex = -1;

		private int _currentSaveSlot;

		private bool _shouldCorruptNextLevelSave;

		public Action OnRefreshCompleted;

		public static Action<int> OnDiscoverCorruptMetagameSave;

		public static Action OnDiscoverCorruptRoomTemplatesSave;

		private string SaveLocationForCurrentSlot => SaveLocationForSlot(_currentSaveSlot);

		private string MetagameSavePathForCurrentSlot => MetagameSavePathForSlot(_currentSaveSlot);

		private string DebugSaveOutputPathForCurrentSlot => DebugSaveOutputPathForSlot(_currentSaveSlot);

		public int CurrentSaveSlot
		{
			get
			{
				return _currentSaveSlot;
			}
			set
			{
				if (value != _currentSaveSlot)
				{
					_currentSaveSlot = value;
					RefreshSaveList(_currentSaveSlot);
				}
			}
		}

		public List<SaveFileHeader> SaveFiles => _mSaveFileList[_currentSaveSlot];

		public SaveFileHeader MostRecentSave => _mMostRecentSave[_currentSaveSlot];

		public int MostRecentMetagameSaveSlotIndex => _mostRecentMetagameSaveSlotIndex;

		private static string SaveLocationForSlot(int slot)
		{
			if (SandboxSaveManager.CurrentSettings != null)
			{
				return SandboxSaveManager.SavePathForSettings(SandboxSaveManager.CurrentSettings);
			}
			return Path.Combine(SaveLocation, "Slot" + (slot + 1));
		}

		private static string SaveLocationInEditorForSlot(int slot)
		{
			return Path.Combine(SaveLocationEditor, "Slot" + (slot + 1));
		}

		private static string SaveLocationInStandaloneForSlot(int slot)
		{
			return Path.Combine(SaveLocationStandalone, "Slot" + (slot + 1));
		}

		private static string MetagameSavePathForSlot(int slot)
		{
			return Path.Combine(SaveLocationForSlot(slot), "career.csav");
		}

		private static string MetagameSavePathInEditorForSlot(int slot)
		{
			return Path.Combine(SaveLocationInEditorForSlot(slot), "career.csav");
		}

		private static string MetagameSavePathInStandaloneForSlot(int slot)
		{
			return Path.Combine(SaveLocationInStandaloneForSlot(slot), "career.csav");
		}

		private static string DebugSaveOutputPathForSlot(int slot)
		{
			return Path.Combine(DebugSaveOutputPath, "Slot" + (slot + 1));
		}

		private static string DebugSaveOutputPathInEditorForSlot(int slot)
		{
			return Path.Combine(DebugSaveOutputPathEditor, "Slot" + (slot + 1));
		}

		private static string DebugSaveOutputPathInStandaloneForSlot(int slot)
		{
			return Path.Combine(DebugSaveOutputPathStandalone, "Slot" + (slot + 1));
		}

		public SaveSystem(BiDictionary<int, object> assetIDs)
		{
			_assetIDs = assetIDs;
			EnsureDirectoriesExist();
			_serializerLevel = CreateAndConfigureLevelSerializer(_assetIDs);
			_serializerMetagame = CreateAndConfigureMetagameSerializer(_assetIDs);
			_serializerRoomTemplates = CreateAndConfigureRoomTemplatesSerializer(_assetIDs);
			for (int i = 0; i < 3; i++)
			{
				_mSaveFileList[i] = new List<SaveFileHeader>();
			}
			if (PlatformFileManager.IsAvailable)
			{
				RefreshSaveLists();
			}
			SandboxSaveManager.OnSettingsChanged = (Action<SandboxSettings>)Delegate.Combine(SandboxSaveManager.OnSettingsChanged, new Action<SandboxSettings>(OnSandboxChanged));
			ConsoleCommandsDatabase.RegisterCommand("SetSaveSlot", "Sets the current save slot index, 0-based, 3 slots", "SetSaveSlot 1", DebugSetSaveSlot);
			ConsoleCommandsDatabase.RegisterSimpleCommand("RefreshSaves", "Refreshes info on save files from disk", RefreshSaveLists);
			ConsoleCommandsDatabase.RegisterSimpleCommand("CorruptNextLevelSave", "Corrupts the next level save. Disables itself after use.", CorruptNextLevelSave);
		}

		public override void Destroy()
		{
			SandboxSaveManager.OnSettingsChanged = (Action<SandboxSettings>)Delegate.Remove(SandboxSaveManager.OnSettingsChanged, new Action<SandboxSettings>(OnSandboxChanged));
			base.Destroy();
		}

		private static void EnsureDirectoriesExist()
		{
			for (int i = 0; i < 3; i++)
			{
				string path = SaveLocationForSlot(i);
				if (!PlatformFileManager.DirectoryExists(path))
				{
					PlatformFileManager.CreateDirectory(path);
				}
			}
		}

		private static fsSerializer CreateAndConfigureLevelSerializer(BiDictionary<int, object> externallyStoredObjects)
		{
			fsSerializer fsSerializer2 = new fsSerializer();
			fsSerializer2.Config.DefaultMemberSerialization = fsMemberSerialization.OptOut;
			fsSerializer2.Config.SerializeAttributes = new Type[1] { typeof(fsPropertyAttribute) };
			fsSerializer2.Config.IgnoreSerializeAttributes = new Type[3]
			{
				typeof(DontSaveAttribute),
				typeof(NonSerializedAttribute),
				typeof(fsIgnoreAttribute)
			};
			fsSerializer2.Config.IgnoreSerializeTypeAttributes = new Type[3]
			{
				typeof(DontSaveAttribute),
				typeof(fsIgnoreAttribute),
				typeof(NonSerializedAttribute)
			};
			fsSerializer2.Config.SerializeEnumsAsInteger = true;
			fsSerializer2.Config.VersionAllClasses = true;
			fsSerializer2.SetIDObjectMapping(externallyStoredObjects.FirstToSecond, externallyStoredObjects.SecondToFirst);
			return fsSerializer2;
		}

		private static fsSerializer CreateAndConfigureMetagameSerializer(BiDictionary<int, object> externallyStoredObjects)
		{
			fsSerializer fsSerializer2 = new fsSerializer();
			fsSerializer2.Config.DefaultMemberSerialization = fsMemberSerialization.OptOut;
			fsSerializer2.Config.SerializeAttributes = new Type[1] { typeof(fsPropertyAttribute) };
			fsSerializer2.Config.IgnoreSerializeAttributes = new Type[3]
			{
				typeof(DontSaveAttribute),
				typeof(NonSerializedAttribute),
				typeof(fsIgnoreAttribute)
			};
			fsSerializer2.Config.IgnoreSerializeTypeAttributes = new Type[3]
			{
				typeof(DontSaveAttribute),
				typeof(fsIgnoreAttribute),
				typeof(NonSerializedAttribute)
			};
			fsSerializer2.Config.SerializeEnumsAsInteger = true;
			fsSerializer2.Config.VersionAllClasses = true;
			fsSerializer2.Config.DeserializeMissingNegativeObjectIDsAsNull = true;
			fsSerializer2.SetIDObjectMapping(externallyStoredObjects.FirstToSecond, externallyStoredObjects.SecondToFirst);
			return fsSerializer2;
		}

		private static fsSerializer CreateAndConfigureRoomTemplatesSerializer(BiDictionary<int, object> externallyStoredObjects)
		{
			fsSerializer fsSerializer2 = new fsSerializer();
			fsSerializer2.Config.DefaultMemberSerialization = fsMemberSerialization.OptOut;
			fsSerializer2.Config.SerializeAttributes = new Type[1] { typeof(fsPropertyAttribute) };
			fsSerializer2.Config.IgnoreSerializeAttributes = new Type[3]
			{
				typeof(DontSaveAttribute),
				typeof(NonSerializedAttribute),
				typeof(fsIgnoreAttribute)
			};
			fsSerializer2.Config.IgnoreSerializeTypeAttributes = new Type[3]
			{
				typeof(DontSaveAttribute),
				typeof(fsIgnoreAttribute),
				typeof(NonSerializedAttribute)
			};
			fsSerializer2.Config.SerializeEnumsAsInteger = true;
			fsSerializer2.Config.VersionAllClasses = true;
			fsSerializer2.Config.DeserializeMissingNegativeObjectIDsAsNull = true;
			fsSerializer2.SetIDObjectMapping(externallyStoredObjects.FirstToSecond, externallyStoredObjects.SecondToFirst);
			return fsSerializer2;
		}

		public void RefreshSaveLists()
		{
			RefreshMetagameSaveListsInner();
			RefreshLevelSaveListsInner();
			OnRefreshCompleted?.Invoke();
		}

		private void RefreshSaveList(int saveSlotIndex)
		{
			RefreshMetagameSaveListInner(saveSlotIndex);
			RefreshLevelSaveListInner(saveSlotIndex);
			OnRefreshCompleted?.Invoke();
		}

		public void RefreshMetagameSaveLists()
		{
			RefreshMetagameSaveListsInner();
			OnRefreshCompleted?.Invoke();
		}

		public void CheckForCorruptMetagameSaves()
		{
			for (int i = 0; i < 3; i++)
			{
				if (PlatformFileManager.FileExists(MetagameSavePathForSlot(i)))
				{
					try
					{
						LoadMetagameSaveData(i);
					}
					catch (Exception)
					{
						OnDiscoverCorruptMetagameSave.InvokeSafe(i);
					}
				}
			}
		}

		private void CorruptNextLevelSave()
		{
			_shouldCorruptNextLevelSave = true;
		}

		private void RefreshMetagameSaveListsInner()
		{
			Logging.Info(LogChannels.Save, "Refreshing metagame save file lists");
			for (int i = 0; i < 3; i++)
			{
				LoadAndStoreMetagameSaveHeaderForSlot(i);
			}
			RefreshMostRecentMetagameSaveSlotIndex();
		}

		private void RefreshMetagameSaveList(int slotIndex)
		{
			RefreshMetagameSaveListInner(slotIndex);
			OnRefreshCompleted?.Invoke();
		}

		private void RefreshMetagameSaveListInner(int slotIndex)
		{
			Logging.Info(LogChannels.Save, "Refreshing metagame save file list for slot {0}", slotIndex);
			LoadAndStoreMetagameSaveHeaderForSlot(slotIndex);
			RefreshMostRecentMetagameSaveSlotIndex();
		}

		private void LoadAndStoreMetagameSaveHeaderForSlot(int slotIndex)
		{
			try
			{
				_metagameSaveHeaders[slotIndex] = LoadMetagameSaveHeaderIfExists(slotIndex);
			}
			catch (Exception ex)
			{
				_metagameSaveHeaders[slotIndex] = null;
				Logging.Error(LogChannels.Save, "Broken (old?) metagame save file found; Failed to load save data; exception while deserialising: " + ex);
			}
		}

		private void RefreshMostRecentMetagameSaveSlotIndex()
		{
			_mostRecentMetagameSaveSlotIndex = -1;
			MetagameSaveHeader metagameSaveHeader = null;
			for (int i = 0; i < 3; i++)
			{
				if (_metagameSaveHeaders[i] != null && (metagameSaveHeader == null || _metagameSaveHeaders[i].Date > metagameSaveHeader.Date))
				{
					metagameSaveHeader = _metagameSaveHeaders[i];
					_mostRecentMetagameSaveSlotIndex = i;
				}
			}
		}

		private void RefreshLevelSaveLists()
		{
			RefreshLevelSaveListsInner();
			OnRefreshCompleted?.Invoke();
		}

		private void RefreshLevelSaveListsInner()
		{
			Logging.Info(LogChannels.Save, "Refreshing level save file lists");
			for (int i = 0; i < 3; i++)
			{
				LoadAndStoreLevelSaveHeadersForSlot(i);
			}
			for (int j = 0; j < 3; j++)
			{
				RefreshMostRecentLevelSaveForSlot(j);
			}
		}

		private void RefreshLevelSaveList(int saveSlotIndex)
		{
			RefreshLevelSaveListInner(saveSlotIndex);
			OnRefreshCompleted?.Invoke();
		}

		private void RefreshLevelSaveListInner(int saveSlotIndex)
		{
			Logging.Info(LogChannels.Save, "Refreshing level save file list for slot {0}", saveSlotIndex);
			LoadAndStoreLevelSaveHeadersForSlot(saveSlotIndex);
			RefreshMostRecentLevelSaveForSlot(saveSlotIndex);
		}

		private void LoadAndStoreLevelSaveHeadersForSlot(int saveSlotIndex)
		{
			_mSaveFileList[saveSlotIndex].Clear();
			string[] allFiles = PlatformFileManager.GetAllFiles(SaveLocationForSlot(saveSlotIndex));
			foreach (string text in allFiles)
			{
				if (text.EndsWith(".sav"))
				{
					SaveFileHeader item = LoadLevelSaveFileHeader(text);
					_mSaveFileList[saveSlotIndex].Add(item);
				}
			}
		}

		private void RefreshMostRecentLevelSaveForSlot(int saveSlotIndex)
		{
			_mMostRecentSave[saveSlotIndex] = null;
			foreach (SaveFileHeader item in _mSaveFileList[saveSlotIndex])
			{
				if (!item.IsBroken && (_mMostRecentSave[saveSlotIndex] == null || item.Date > _mMostRecentSave[saveSlotIndex].Date))
				{
					_mMostRecentSave[saveSlotIndex] = item;
				}
			}
			_mSaveFileList[saveSlotIndex].Sort((SaveFileHeader x, SaveFileHeader y) => -x.Date.CompareTo(y.Date));
		}

		public void AutoSave(MetagameSaveData metagameSaveData, SaveData saveData)
		{
			SaveImplementation(metagameSaveData, saveData, null);
		}

		public void ManualSave(MetagameSaveData metagameSaveData, SaveData saveData)
		{
			SaveImplementation(metagameSaveData, saveData, null);
		}

		public void ManualSaveAs(MetagameSaveData metagameSaveData, SaveData saveData, string saveName)
		{
			SaveImplementation(metagameSaveData, saveData, saveName);
		}

		public void SaveRoomTemplate(RoomTemplateSaveData roomTemplateSaveData)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			bool flag = SaveRoomTemplatesImplementationInner(roomTemplateSaveData);
			stopwatch.Stop();
			long num = stopwatch.ElapsedTicks / 10;
			if (!flag)
			{
				Logging.Error(LogChannels.Save, "Saving room templates failed");
			}
			float num2 = (float)num / 1000000f;
			Logging.Info(LogChannels.Save, "SaveRoomTemplate completed in {0} seconds", num2);
		}

		public void SaveMetagame(MetagameSaveData metagameSaveData)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Logging.AlwaysLog(LogChannels.Save, "SaveMetagame() Saving metagame with guid {0}", metagameSaveData.Metagame.GetRefId());
			bool num = SaveMetagameImplementationInner(metagameSaveData, _currentSaveSlot);
			stopwatch.Stop();
			long num2 = stopwatch.ElapsedTicks / 10;
			if (!num)
			{
				Logging.Error(LogChannels.Save, "Saving game failed");
			}
			float num3 = (float)num2 / 1000000f;
			Logging.Info(LogChannels.Save, "SaveMetagame completed in {0} seconds", num3);
			RefreshMetagameSaveList(_currentSaveSlot);
		}

		private void SaveImplementation(MetagameSaveData metagameSaveData, SaveData saveData, string manualSaveName)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Logging.AlwaysLog(LogChannels.Save, "SaveImplementation() Saving metagame with guid {0}", metagameSaveData.Metagame.GetRefId());
			bool num = SaveMetagameImplementationInner(metagameSaveData, _currentSaveSlot);
			stopwatch.Stop();
			long num2 = stopwatch.ElapsedTicks / 10;
			stopwatch.Reset();
			stopwatch.Start();
			bool flag = saveData == null || saveData.Level == null || SaveLevelImplementationInner(saveData, manualSaveName, _currentSaveSlot);
			stopwatch.Stop();
			long num3 = stopwatch.ElapsedTicks / 10;
			if (!num || !flag)
			{
				Logging.Error(LogChannels.Save, "Saving game failed");
			}
			else
			{
				float num4 = (float)(num2 + num3) / 1000000f;
				if (saveData?.Level == null)
				{
					Logging.Info(LogChannels.Save, "Save completed in {0} seconds. Not in a level so just saved metagame.", num4);
				}
				else
				{
					Logging.Info(LogChannels.Save, "Save completed in {0} seconds. Saved level {1}", num4, saveData.Level.Config.UniqueId);
				}
			}
			RefreshSaveList(_currentSaveSlot);
		}

		private bool SaveLevelImplementationInner(SaveData saveData, string manualSaveName, int slotIndex)
		{
			if (saveData.Level.FinanceManager.IsBankrupt)
			{
				Logging.Warning(LogChannels.Save, "Trying to save bankrupt level {0}", saveData.Level.Config.GetDisplayName());
				return true;
			}
			bool isUserChosen = manualSaveName != null;
			string text = ((manualSaveName != null) ? manualSaveName : saveData.Level.UniqueID);
			string sanitisedSaveName = SanitiseFileNameCharacters(text);
			try
			{
				SaveFileHeader obj = new SaveFileHeader(saveData, text);
				byte[] headerSerializedBytes = MessagePackSerializer.Serialize(obj);
				if (headerSerializedBytes.Length == 0 || headerSerializedBytes[0] == 0)
				{
					throw new CorruptSaveException("MessagePack failed to serialise save file header correctly for " + text);
				}
				fiSerializationManager.DisableAutomaticSerialization = true;
				fiSerializationManager.IsInSaveOrLoad = true;
				fsData data;
				fsResult fsResult2 = _serializerLevel.TrySerialize(saveData, out data);
				if (fsResult2.Failed)
				{
					throw new CorruptSaveException("Failed to serialise SaveData: " + text);
				}
				if (fsResult2.HasWarnings)
				{
					Logging.Error(LogChannels.Save, "SaveData serialize had warnings: {0}", fsResult2.FormattedMessages);
				}
				string s = fsJsonPrinter.CompressedJson(data, _largeStringBuilderJSONCache, _smallStringBuilderJSONCache);
				byte[] uncompressedBody = Encoding.UTF8.GetBytes(s);
				byte[] compressedBody = LZ4Codec.Encode32(uncompressedBody, 0, uncompressedBody.Length);
				Action<BinaryWriter> writeAction = delegate(BinaryWriter binaryWriter)
				{
					if (_shouldCorruptNextLevelSave)
					{
						Logging.Info("Corrupting level for: " + sanitisedSaveName);
						_shouldCorruptNextLevelSave = false;
						binaryWriter.Write(Debug_GenerateJunkArray(131072u));
					}
					else
					{
						binaryWriter.Write(1818783860);
						binaryWriter.Write(SaveFileVersion);
						binaryWriter.Write(headerSerializedBytes.Length);
						binaryWriter.Write(0);
						binaryWriter.Write(compressedBody.Length);
						binaryWriter.Write(uncompressedBody.Length);
						binaryWriter.Write(headerSerializedBytes);
						binaryWriter.Write(compressedBody);
					}
				};
				Func<MemoryStream, bool> fileValidating = delegate(MemoryStream baseStream)
				{
					using BinaryReader binaryReader = new BinaryReader(baseStream);
					binaryReader.BaseStream.Seek(0L, SeekOrigin.Begin);
					if (binaryReader.ReadInt32() != 1818783860)
					{
						throw new CorruptSaveException("Level save file is not a valid save file for this game");
					}
					int num = binaryReader.ReadInt32();
					if (num < 2)
					{
						throw new OutOfDaveSaveException("Level save file is an old format, and no upgrade path exists - must be from an old unsupported development version");
					}
					if (num > SaveFileVersion)
					{
						throw new CorruptSaveException("Level save file version is newer than the game version! It's either corrupt, or the game executable is out of date");
					}
					try
					{
						int count = binaryReader.ReadInt32();
						binaryReader.ReadInt32();
						int count2 = binaryReader.ReadInt32();
						binaryReader.ReadInt32();
						binaryReader.ReadBytes(count);
						binaryReader.ReadBytes(count2);
						return true;
					}
					catch (Exception inner)
					{
						throw new CorruptSaveException("Level save file threw exception while reading file; file is corrupt", inner);
					}
				};
				PlatformFileManager.Save(GetFullPathFromSaveName(sanitisedSaveName, slotIndex, isUserChosen, 0), writeAction, useBackups: true, fileValidating);
				return true;
			}
			catch (Exception ex)
			{
				Logging.Error(LogChannels.Save, "Exception encountered whilst saving" + ex);
				return false;
			}
			finally
			{
				fiSerializationManager.DisableAutomaticSerialization = false;
				fiSerializationManager.IsInSaveOrLoad = false;
			}
		}

		private byte[] Debug_GenerateJunkArray(uint sizeInBytes)
		{
			System.Random random = new System.Random();
			byte[] array = new byte[sizeInBytes];
			random.NextBytes(array);
			return array;
		}

		private static MetagameSaveHeader CreateMetagameSaveHeader(Metagame metagame)
		{
			return new MetagameSaveHeader
			{
				Date = DateTime.UtcNow,
				Version = GameVersionNumber.Version,
				OrganisationName = metagame.OrganisationName,
				TotalStars = metagame.TotalStars(),
				TotalSilver = metagame.TotalSilver(),
				TotalFoundationValue = metagame.TotalFoundationValue(),
				ThumbnailPNG = ((Camera.main == null) ? null : CameraUtils.TakeScreenShotAsBytes(Camera.main))
			};
		}

		private bool SaveMetagameImplementationInner(MetagameSaveData saveData, int slotIndex)
		{
			try
			{
				if (saveData.Metagame == null)
				{
					throw new Exception("Metagame was null during metagame save");
				}
				MetagameSaveHeader obj = CreateMetagameSaveHeader(saveData.Metagame);
				byte[] headerSerializedBytes = MessagePackSerializer.Serialize(obj);
				if (headerSerializedBytes.Length == 0 || headerSerializedBytes[0] == 0)
				{
					Logging.Error("MessagePack failed to serialise save file header correctly.");
				}
				fiSerializationManager.DisableAutomaticSerialization = true;
				fiSerializationManager.IsInSaveOrLoad = true;
				fsData data;
				fsResult fsResult2 = _serializerMetagame.TrySerialize(saveData, out data);
				if (fsResult2.Failed)
				{
					Logging.Error(LogChannels.Save, "Failed to serialise SaveData: {0}", fsResult2.FormattedMessages);
				}
				else if (fsResult2.HasWarnings)
				{
					Logging.Error(LogChannels.Save, "SaveData serialize had warnings: {0}", fsResult2.FormattedMessages);
				}
				string s = fsJsonPrinter.CompressedJson(data, _largeStringBuilderJSONCache, _smallStringBuilderJSONCache);
				byte[] uncompressedBody = Encoding.UTF8.GetBytes(s);
				byte[] compressedBody = LZ4Codec.Encode32(uncompressedBody, 0, uncompressedBody.Length);
				Action<BinaryWriter> writeAction = delegate(BinaryWriter binaryWriter)
				{
					binaryWriter.Write(1835561076);
					binaryWriter.Write(SaveFileVersionMetagame);
					binaryWriter.Write(headerSerializedBytes.Length);
					binaryWriter.Write(0);
					binaryWriter.Write(compressedBody.Length);
					binaryWriter.Write(uncompressedBody.Length);
					binaryWriter.Write(headerSerializedBytes);
					binaryWriter.Write(compressedBody);
				};
				PlatformFileManager.Save(MetagameSavePathForSlot(slotIndex), writeAction, useBackups: true);
				return true;
			}
			catch (Exception ex)
			{
				Logging.Error(LogChannels.Save, "Exception encountered whilst saving" + ex);
				return false;
			}
			finally
			{
				fiSerializationManager.DisableAutomaticSerialization = false;
				fiSerializationManager.IsInSaveOrLoad = false;
			}
		}

		private static RoomTemplatesSaveHeader CreateRoomTemplatesSaveHeader()
		{
			return new RoomTemplatesSaveHeader
			{
				Date = DateTime.UtcNow,
				Version = GameVersionNumber.Version
			};
		}

		private bool SaveRoomTemplatesImplementationInner(RoomTemplateSaveData saveData)
		{
			try
			{
				if (saveData.RoomTemplate == null)
				{
					throw new Exception("RoomTemplate was null during RoomTemplate save");
				}
				RoomTemplatesSaveHeader obj = CreateRoomTemplatesSaveHeader();
				byte[] headerSerializedBytes = MessagePackSerializer.Serialize(obj);
				if (headerSerializedBytes.Length == 0 || headerSerializedBytes[0] == 0)
				{
					Logging.Error("MessagePack failed to serialise save file header correctly (Room Templates).");
				}
				fiSerializationManager.DisableAutomaticSerialization = true;
				fiSerializationManager.IsInSaveOrLoad = true;
				fsData data;
				fsResult fsResult2 = _serializerRoomTemplates.TrySerialize(saveData, out data);
				if (fsResult2.Failed)
				{
					Logging.Error(LogChannels.Save, "Failed to serialise SaveData: {0}", fsResult2.FormattedMessages);
				}
				else if (fsResult2.HasWarnings)
				{
					Logging.Error(LogChannels.Save, "SaveData serialize had warnings: {0}", fsResult2.FormattedMessages);
				}
				string s = fsJsonPrinter.CompressedJson(data, _largeStringBuilderJSONCache, _smallStringBuilderJSONCache);
				byte[] uncompressedBody = Encoding.UTF8.GetBytes(s);
				byte[] compressedBody = LZ4Codec.Encode32(uncompressedBody, 0, uncompressedBody.Length);
				Action<BinaryWriter> writeAction = delegate(BinaryWriter binaryWriter)
				{
					binaryWriter.Write(1919447156);
					binaryWriter.Write(SaveFileVersionRoomTemplates);
					binaryWriter.Write(headerSerializedBytes.Length);
					binaryWriter.Write(0);
					binaryWriter.Write(compressedBody.Length);
					binaryWriter.Write(uncompressedBody.Length);
					binaryWriter.Write(headerSerializedBytes);
					binaryWriter.Write(compressedBody);
				};
				PlatformFileManager.Save(Path.Combine(RoomTemplatesSaveLocation, saveData.RoomTemplate.GeneratedFileName + ".tsav"), writeAction, useBackups: false);
				return true;
			}
			catch (Exception ex)
			{
				Logging.Error(LogChannels.Save, "Exception encountered whilst saving" + ex);
				return false;
			}
			finally
			{
				fiSerializationManager.DisableAutomaticSerialization = false;
				fiSerializationManager.IsInSaveOrLoad = false;
			}
		}

		public void DeleteRoomTemplateSave(string generatedFileName)
		{
			string path = Path.Combine(RoomTemplatesSaveLocation, generatedFileName + ".tsav");
			try
			{
				PlatformFileManager.DeleteSave(path, deleteBackups: false);
			}
			catch (Exception ex)
			{
				Logging.Error(LogChannels.Save, "Exception encountered whilst deleting room template" + ex);
			}
		}

		private bool HasBackupCareerSave(int slotIndex)
		{
			FixupBackupCareerSaveIndices(slotIndex);
			return PlatformFileManager.FileExists(SaveUtils.GetBackupSavePath(MetagameSavePathForSlot(slotIndex), 1));
		}

		public bool TryGetBackupCareerSave(int slotIndex, out MetagameSaveDataAndHeader saveData)
		{
			int num = 1;
			FixupBackupCareerSaveIndices(slotIndex);
			string backupSavePath = SaveUtils.GetBackupSavePath(MetagameSavePathForSlot(slotIndex), num);
			bool flag = PlatformFileManager.FileExists(backupSavePath);
			while (flag)
			{
				try
				{
					saveData = LoadMetagameImplementation(backupSavePath, slotIndex);
					return saveData != null;
				}
				catch (Exception)
				{
					try
					{
						Logging.Warning("Skipping corrupt backup save " + backupSavePath);
						num++;
						backupSavePath = SaveUtils.GetBackupSavePath(MetagameSavePathForSlot(slotIndex), num);
						flag = PlatformFileManager.FileExists(backupSavePath);
					}
					catch (Exception)
					{
						Logging.Error("Failed deleting corrupt backup save " + backupSavePath + ", aborting backup flow");
						saveData = null;
						return false;
					}
				}
			}
			RefreshMetagameSaveList(slotIndex);
			saveData = null;
			return false;
		}

		public bool TryGetBackupLevelSave(string levelID, out LevelSaveDataAndHeader saveData)
		{
			int num = 1;
			FixupBackupLevelSaveIndices(CurrentSaveSlot, levelID);
			string saveName = SanitiseFileNameCharacters(levelID);
			string fullPathFromSaveName = GetFullPathFromSaveName(saveName, CurrentSaveSlot, isUserChosen: false, num);
			bool flag = PlatformFileManager.FileExists(fullPathFromSaveName);
			while (flag)
			{
				try
				{
					saveData = LoadLevelImplementation(fullPathFromSaveName);
					return saveData != null;
				}
				catch (Exception)
				{
					try
					{
						Logging.Warning("Skipping corrupt backup save " + fullPathFromSaveName);
						num++;
						fullPathFromSaveName = GetFullPathFromSaveName(saveName, CurrentSaveSlot, isUserChosen: false, num);
						flag = PlatformFileManager.FileExists(fullPathFromSaveName);
					}
					catch (Exception)
					{
						Logging.Error("Failed deleting corrupt backup save " + fullPathFromSaveName + ", aborting backup flow");
						saveData = null;
						return false;
					}
				}
			}
			RefreshLevelSaveList(CurrentSaveSlot);
			saveData = null;
			return false;
		}

		public void ApplyBackupCareerSave(int slotIndex)
		{
			MoveAllBackupCareerSavesUp(slotIndex);
			RefreshMetagameSaveList(slotIndex);
		}

		public void ApplyBackupLevelSave(string levelID)
		{
			MoveAllBackupLevelSavesUp(levelID);
			RefreshLevelSaveList(CurrentSaveSlot);
		}

		private void FixupBackupSaveIndices(string savePath)
		{
			PlatformFileManager.FixupBackupSaveIndices(savePath);
		}

		private void FixupBackupCareerSaveIndices(int slotIndex)
		{
			FixupBackupSaveIndices(MetagameSavePathForSlot(slotIndex));
		}

		private void FixupBackupLevelSaveIndices(int slotIndex, string levelID)
		{
			string saveName = SanitiseFileNameCharacters(levelID);
			FixupBackupSaveIndices(GetFullPathFromSaveName(saveName, slotIndex, isUserChosen: false, 0));
		}

		private void MoveAllBackupCareerSavesUp(int slotIndex)
		{
			PlatformFileManager.MoveAllBackupSavesUp(MetagameSavePathForSlot(slotIndex));
		}

		private void MoveAllBackupLevelSavesUp(string levelID)
		{
			PlatformFileManager.MoveAllBackupSavesUp(GetFullPathFromSaveName(SanitiseFileNameCharacters(levelID), CurrentSaveSlot, isUserChosen: false, 0));
		}

		public LevelSaveDataAndHeader LoadMostRecentFile()
		{
			if (_mMostRecentSave[_currentSaveSlot] != null)
			{
				return LoadLevel(_mMostRecentSave[_currentSaveSlot].FilePath);
			}
			return null;
		}

		public LevelSaveDataAndHeader LoadLevel(string path)
		{
			if (!PlatformFileManager.FileExists(path))
			{
				throw new SaveFileDoesNotExistException("Save file doesn't exist: " + path);
			}
			DateTime utcNow = DateTime.UtcNow;
			LevelSaveDataAndHeader result = LoadLevelImplementation(path);
			float num = (float)(DateTime.UtcNow - utcNow).TotalSeconds;
			Logging.Info(LogChannels.Save, "Load completed in {0} seconds", num);
			return result;
		}

		private SaveFileHeader LoadLevelSaveFileHeader(string fileName)
		{
			SaveFileHeader saveFileHeader = new SaveFileHeader(fileName);
			try
			{
				if (!PlatformFileManager.Load(fileName, out var reader))
				{
					return null;
				}
				using (reader)
				{
					if (reader.ReadInt32() != 1818783860)
					{
						throw new CorruptSaveException("Save file is not a valid save file for this game");
					}
					int num = reader.ReadInt32();
					if (num < 2)
					{
						throw new OutOfDaveSaveException("Save file is an old format, and no upgrade path exists - must be from an old unsupported development version");
					}
					if (num > SaveFileVersion)
					{
						throw new CorruptSaveException("Save file version is newer than the game version! It's either corrupt, or the game executable is out of date");
					}
					int num2 = reader.ReadInt32();
					int sizeUncompressed = reader.ReadInt32();
					reader.ReadInt32();
					reader.ReadInt32();
					byte[] array = reader.ReadBytes(num2);
					if (num > 2)
					{
						saveFileHeader = MessagePackSerializer.Deserialize<SaveFileHeader>(array);
						saveFileHeader.Date = TimeZoneInfo.ConvertTimeFromUtc(saveFileHeader.Date, TimeUtils.LocalSafe());
					}
					else
					{
						saveFileHeader = new SaveFileHeader(DeserializeClassFromSaveFileBuffer<SaveFileHeaderV1>(_serializerLevel, array, num2, sizeUncompressed, "level header"));
					}
					saveFileHeader.SetFilePath(fileName, Path.GetFileName(fileName));
				}
			}
			catch (Exception ex)
			{
				saveFileHeader = new SaveFileHeader(fileName);
				Logging.Error(LogChannels.Save, "Broken (old?) save file found ({0}); Failed to load save data; exception while deserialising: {1}", fileName, ex);
			}
			return saveFileHeader;
		}

		private LevelSaveDataAndHeader LoadLevelImplementation(string path)
		{
			LevelSaveFileParts levelSaveFileParts = ReadLevelSaveFileParts(path);
			SaveFileHeader saveFileHeader;
			try
			{
				if (levelSaveFileParts.Version > 2)
				{
					saveFileHeader = MessagePackSerializer.Deserialize<SaveFileHeader>(levelSaveFileParts.HeaderSerializedBytesCompressed);
					saveFileHeader.Date = TimeZoneInfo.ConvertTimeFromUtc(saveFileHeader.Date, TimeUtils.LocalSafe());
				}
				else
				{
					saveFileHeader = new SaveFileHeader(DeserializeClassFromSaveFileBuffer<SaveFileHeaderV1>(_serializerLevel, levelSaveFileParts.HeaderSerializedBytesCompressed, levelSaveFileParts.HeaderSizeCompressed, levelSaveFileParts.HeaderSizeUncompressed, "level header"));
				}
			}
			catch (SaveDeserialisationException inner)
			{
				throw new CorruptSaveException("Level save header failed to deserialize; must be corrupt", inner);
			}
			Logging.Info(LogChannels.Save, "Loaded level save header. Date: {0}, version: {1}", saveFileHeader.Date, saveFileHeader.Version);
			try
			{
				SaveData levelSaveData = DeserializeClassFromSaveFileBuffer<SaveData>(_serializerLevel, levelSaveFileParts.BodySerializedBytesCompressed, levelSaveFileParts.BodySizeCompressed, levelSaveFileParts.BodySizeUncompressed, "level body");
				return new LevelSaveDataAndHeader
				{
					LevelSaveFileHeader = saveFileHeader,
					LevelSaveData = levelSaveData
				};
			}
			catch (SaveDeserialisationException inner2)
			{
				throw new CorruptSaveException("Level save body failed to deserialize; must be corrupt", inner2);
			}
		}

		private static RoomTemplatesSaveFileParts ReadRoomTemplatesSaveFileParts(string path)
		{
			if (!PlatformFileManager.Load(path, out var reader))
			{
				Logging.Error("Couldn't load RoomTemplatesSaveFileParts");
				OnDiscoverCorruptRoomTemplatesSave.InvokeSafe();
				return default(RoomTemplatesSaveFileParts);
			}
			using (reader)
			{
				int num = reader.ReadInt32();
				if (num != 1919447156)
				{
					OnDiscoverCorruptRoomTemplatesSave.InvokeSafe();
					throw new CorruptSaveException("Room templates save file is not a valid save file for this game");
				}
				int num2 = reader.ReadInt32();
				if (num2 < 1)
				{
					OnDiscoverCorruptRoomTemplatesSave.InvokeSafe();
					throw new OutOfDaveSaveException("Room templates save file is an old format, and no upgrade path exists - must be from an old unsupported development version");
				}
				if (num2 > SaveFileVersionRoomTemplates)
				{
					OnDiscoverCorruptRoomTemplatesSave.InvokeSafe();
					throw new CorruptSaveException("Room templates save file version is newer than the game version! It's either corrupt, or the game executable is out of date");
				}
				try
				{
					int num3 = reader.ReadInt32();
					int headerSizeUncompressed = reader.ReadInt32();
					int num4 = reader.ReadInt32();
					int bodySizeUncompressed = reader.ReadInt32();
					byte[] headerSerializedBytesCompressed = reader.ReadBytes(num3);
					byte[] bodySerializedBytesCompressed = reader.ReadBytes(num4);
					return new RoomTemplatesSaveFileParts
					{
						Signature = num,
						Version = num2,
						HeaderSizeCompressed = num3,
						HeaderSizeUncompressed = headerSizeUncompressed,
						BodySizeCompressed = num4,
						BodySizeUncompressed = bodySizeUncompressed,
						HeaderSerializedBytesCompressed = headerSerializedBytesCompressed,
						BodySerializedBytesCompressed = bodySerializedBytesCompressed
					};
				}
				catch (Exception inner)
				{
					OnDiscoverCorruptRoomTemplatesSave.InvokeSafe();
					throw new CorruptSaveException("Room templates save file threw exception while reading file; file is corrupt", inner);
				}
			}
		}

		private RoomTemplatesSaveDataAndHeader LoadRoomTemplatesImplementation(string path)
		{
			RoomTemplatesSaveFileParts roomTemplatesSaveFileParts = ReadRoomTemplatesSaveFileParts(path);
			RoomTemplatesSaveHeader roomTemplatesSaveHeader;
			try
			{
				roomTemplatesSaveHeader = MessagePackSerializer.Deserialize<RoomTemplatesSaveHeader>(roomTemplatesSaveFileParts.HeaderSerializedBytesCompressed);
				roomTemplatesSaveHeader.Date = TimeZoneInfo.ConvertTimeFromUtc(roomTemplatesSaveHeader.Date, TimeUtils.LocalSafe());
			}
			catch (SaveDeserialisationException inner)
			{
				OnDiscoverCorruptRoomTemplatesSave.InvokeSafe();
				throw new CorruptSaveException("Room templates save header failed to deserialize; must be corrupt", inner);
			}
			Logging.Info(LogChannels.Save, "Loaded Room templates save header. Date: {0}, version: {1}", roomTemplatesSaveHeader.Date, roomTemplatesSaveHeader.Version);
			try
			{
				RoomTemplateSaveData roomTemplateSaveData = DeserializeClassFromSaveFileBuffer<RoomTemplateSaveData>(_serializerMetagame, roomTemplatesSaveFileParts.BodySerializedBytesCompressed, roomTemplatesSaveFileParts.BodySizeCompressed, roomTemplatesSaveFileParts.BodySizeUncompressed, "room templates body");
				return new RoomTemplatesSaveDataAndHeader
				{
					RoomTemplatesSaveHeader = roomTemplatesSaveHeader,
					RoomTemplateSaveData = roomTemplateSaveData
				};
			}
			catch (SaveDeserialisationException inner2)
			{
				OnDiscoverCorruptRoomTemplatesSave.InvokeSafe();
				throw new CorruptSaveException("Room templates save body failed to deserialize; must be corrupt", inner2);
			}
		}

		public void LoadRoomTemplatesSaveData(RoomTemplatesManager templatesManager)
		{
			string roomTemplatesSaveLocation = RoomTemplatesSaveLocation;
			string[] allFiles;
			try
			{
				allFiles = PlatformFileManager.GetAllFiles(roomTemplatesSaveLocation);
			}
			catch (DirectoryNotFoundException)
			{
				PlatformFileManager.CreateDirectory(roomTemplatesSaveLocation);
				allFiles = PlatformFileManager.GetAllFiles(roomTemplatesSaveLocation);
			}
			DateTime utcNow = DateTime.UtcNow;
			int num = 0;
			string[] array = allFiles;
			foreach (string text in array)
			{
				if (text.EndsWith(".tsav"))
				{
					RoomTemplatesSaveDataAndHeader roomTemplatesSaveDataAndHeader = LoadRoomTemplatesImplementation(text);
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
					if (templatesManager.LoadInRoomTemplate(roomTemplatesSaveDataAndHeader.RoomTemplateSaveData.RoomTemplate, fileNameWithoutExtension))
					{
						num++;
					}
				}
			}
			float num2 = (float)(DateTime.UtcNow - utcNow).TotalSeconds;
			Logging.Info(LogChannels.Save, "Room templates load completed in {0} seconds, loaded {1} templates", num2, num);
		}

		private static LevelSaveFileParts ReadLevelSaveFileParts(string path)
		{
			if (!PlatformFileManager.Load(path, out var reader))
			{
				Logging.Error("Couldn't load levelSaveParts");
				return default(LevelSaveFileParts);
			}
			using (reader)
			{
				int num = reader.ReadInt32();
				if (num != 1818783860)
				{
					throw new CorruptSaveException("Level save file is not a valid save file for this game");
				}
				int num2 = reader.ReadInt32();
				if (num2 < 2)
				{
					throw new OutOfDaveSaveException("Level save file is an old format, and no upgrade path exists - must be from an old unsupported development version");
				}
				if (num2 > SaveFileVersion)
				{
					throw new CorruptSaveException("Level save file version is newer than the game version! It's either corrupt, or the game executable is out of date");
				}
				try
				{
					int num3 = reader.ReadInt32();
					int headerSizeUncompressed = reader.ReadInt32();
					int num4 = reader.ReadInt32();
					int bodySizeUncompressed = reader.ReadInt32();
					byte[] headerSerializedBytesCompressed = reader.ReadBytes(num3);
					byte[] bodySerializedBytesCompressed = reader.ReadBytes(num4);
					return new LevelSaveFileParts
					{
						Signature = num,
						Version = num2,
						HeaderSizeCompressed = num3,
						HeaderSizeUncompressed = headerSizeUncompressed,
						BodySizeCompressed = num4,
						BodySizeUncompressed = bodySizeUncompressed,
						HeaderSerializedBytesCompressed = headerSerializedBytesCompressed,
						BodySerializedBytesCompressed = bodySerializedBytesCompressed
					};
				}
				catch (Exception inner)
				{
					throw new CorruptSaveException("Level save file threw exception while reading file; file is corrupt", inner);
				}
			}
		}

		public MetagameSaveHeader LoadMetagameSaveHeaderIfExists(int slotIndex)
		{
			string text = MetagameSavePathForSlot(slotIndex);
			if (!PlatformFileManager.FileExists(text))
			{
				return null;
			}
			MetagameSaveFileParts metagameSaveFileParts = ReadMetagameSaveFileParts(text, slotIndex);
			MetagameSaveHeader metagameSaveHeader;
			try
			{
				if (metagameSaveFileParts.Version == 1)
				{
					metagameSaveHeader = new MetagameSaveHeader(DeserializeClassFromSaveFileBuffer<MetagameSaveHeader_FS>(_serializerMetagame, metagameSaveFileParts.HeaderSerializedBytesCompressed, metagameSaveFileParts.HeaderSizeCompressed, metagameSaveFileParts.HeaderSizeUncompressed, "metagame header"));
				}
				else
				{
					metagameSaveHeader = MessagePackSerializer.Deserialize<MetagameSaveHeader>(metagameSaveFileParts.HeaderSerializedBytesCompressed);
					metagameSaveHeader.Date = TimeZoneInfo.ConvertTimeFromUtc(metagameSaveHeader.Date, TimeUtils.LocalSafe());
				}
			}
			catch (Exception inner)
			{
				OnDiscoverCorruptMetagameSave.InvokeSafe(slotIndex);
				throw new CorruptSaveException("Metagame save header failed to deserialize; must be corrupt", inner);
			}
			return metagameSaveHeader;
		}

		public MetagameSaveDataAndHeader LoadMetagameSaveData(int slotIndex)
		{
			CurrentSaveSlot = slotIndex;
			string text = MetagameSavePathForSlot(slotIndex);
			if (!PlatformFileManager.FileExists(text))
			{
				throw new SaveFileDoesNotExistException("Metagame save file doesn't exist: " + text);
			}
			DateTime utcNow = DateTime.UtcNow;
			MetagameSaveDataAndHeader result = LoadMetagameImplementation(text, slotIndex);
			float num = (float)(DateTime.UtcNow - utcNow).TotalSeconds;
			Logging.Info(LogChannels.Save, "Metagame load completed in {0} seconds", num);
			return result;
		}

		private MetagameSaveDataAndHeader LoadMetagameImplementation(string path, int slotIdx)
		{
			MetagameSaveFileParts metagameSaveFileParts = ReadMetagameSaveFileParts(path, slotIdx);
			MetagameSaveHeader metagameSaveHeader;
			try
			{
				if (metagameSaveFileParts.Version == 1)
				{
					metagameSaveHeader = new MetagameSaveHeader(DeserializeClassFromSaveFileBuffer<MetagameSaveHeader_FS>(_serializerMetagame, metagameSaveFileParts.HeaderSerializedBytesCompressed, metagameSaveFileParts.HeaderSizeCompressed, metagameSaveFileParts.HeaderSizeUncompressed, "metagame header"));
				}
				else
				{
					metagameSaveHeader = MessagePackSerializer.Deserialize<MetagameSaveHeader>(metagameSaveFileParts.HeaderSerializedBytesCompressed);
					metagameSaveHeader.Date = TimeZoneInfo.ConvertTimeFromUtc(metagameSaveHeader.Date, TimeUtils.LocalSafe());
				}
			}
			catch (SaveDeserialisationException inner)
			{
				OnDiscoverCorruptMetagameSave.InvokeSafe(slotIdx);
				throw new CorruptSaveException("Metagame save header failed to deserialize; must be corrupt", inner);
			}
			Logging.Info(LogChannels.Save, "Loaded metagame save header. Date: {0}, version: {1}", metagameSaveHeader.Date, metagameSaveHeader.Version);
			try
			{
				MetagameSaveData metagameSaveData = DeserializeClassFromSaveFileBuffer<MetagameSaveData>(_serializerMetagame, metagameSaveFileParts.BodySerializedBytesCompressed, metagameSaveFileParts.BodySizeCompressed, metagameSaveFileParts.BodySizeUncompressed, "metagame body");
				return new MetagameSaveDataAndHeader
				{
					MetagameSaveHeader = metagameSaveHeader,
					MetagameSaveData = metagameSaveData
				};
			}
			catch (SaveDeserialisationException inner2)
			{
				OnDiscoverCorruptMetagameSave.InvokeSafe(slotIdx);
				throw new CorruptSaveException("Metagame save body failed to deserialize; must be corrupt", inner2);
			}
		}

		private static MetagameSaveFileParts ReadMetagameSaveFileParts(string path, int slotIndex)
		{
			if (!PlatformFileManager.Load(path, out var reader))
			{
				Logging.Error("Couldn't load MetagameSaveFileParts");
				OnDiscoverCorruptMetagameSave.InvokeSafe(slotIndex);
				return default(MetagameSaveFileParts);
			}
			using (reader)
			{
				int num = reader.ReadInt32();
				if (num != 1835561076)
				{
					OnDiscoverCorruptMetagameSave.InvokeSafe(slotIndex);
					throw new CorruptSaveException("Metagame save file is not a valid save file for this game");
				}
				int num2 = reader.ReadInt32();
				if (num2 < 1)
				{
					OnDiscoverCorruptMetagameSave.InvokeSafe(slotIndex);
					throw new OutOfDaveSaveException("Metagame save file is an old format, and no upgrade path exists - must be from an old unsupported development version");
				}
				if (num2 > SaveFileVersionMetagame)
				{
					OnDiscoverCorruptMetagameSave.InvokeSafe(slotIndex);
					throw new CorruptSaveException("Metagame save file version is newer than the game version! It's either corrupt, or the game executable is out of date");
				}
				try
				{
					int num3 = reader.ReadInt32();
					int headerSizeUncompressed = reader.ReadInt32();
					int num4 = reader.ReadInt32();
					int bodySizeUncompressed = reader.ReadInt32();
					byte[] headerSerializedBytesCompressed = reader.ReadBytes(num3);
					byte[] bodySerializedBytesCompressed = reader.ReadBytes(num4);
					return new MetagameSaveFileParts
					{
						Signature = num,
						Version = num2,
						HeaderSizeCompressed = num3,
						HeaderSizeUncompressed = headerSizeUncompressed,
						BodySizeCompressed = num4,
						BodySizeUncompressed = bodySizeUncompressed,
						HeaderSerializedBytesCompressed = headerSerializedBytesCompressed,
						BodySerializedBytesCompressed = bodySerializedBytesCompressed
					};
				}
				catch (Exception inner)
				{
					OnDiscoverCorruptMetagameSave.InvokeSafe(slotIndex);
					throw new CorruptSaveException("Metagame save file threw exception while reading file; file is corrupt", inner);
				}
			}
		}

		private TClassType DeserializeClassFromSaveFileBuffer<TClassType>(fsSerializer serializer, byte[] serializedBytesCompressed, int sizeCompressed, int sizeUncompressed, string contentDescription) where TClassType : class
		{
			fsData data = LoadDataFromSaveFileBuffer(serializedBytesCompressed, sizeCompressed, sizeUncompressed, contentDescription);
			TClassType instance = null;
			fsResult fsResult2;
			try
			{
				fiSerializationManager.DisableAutomaticSerialization = true;
				fiSerializationManager.IsInSaveOrLoad = true;
				fsResult2 = serializer.TryDeserialize(data, ref instance);
			}
			finally
			{
				fiSerializationManager.DisableAutomaticSerialization = false;
				fiSerializationManager.IsInSaveOrLoad = false;
			}
			if (fsResult2.RawMessages.Any())
			{
				StringBuilder builder = StringBuilderPool.GlobalStringBuilderPool.GetBuilder(fsResult2.RawMessages.Count * 500);
				foreach (string rawMessage in fsResult2.RawMessages)
				{
					builder.AppendLine(rawMessage);
				}
				Logging.Warning(LogChannels.Save, "Deserialize had warnings ({1}):\n{0}", builder, contentDescription);
				StringBuilderPool.GlobalStringBuilderPool.ReturnBuilder(builder);
			}
			if (fsResult2.Failed)
			{
				throw new SaveDeserialisationException($"Error reported whilst deserializing {contentDescription}: {fsResult2.FormattedMessages}");
			}
			if (instance == null)
			{
				throw new SaveDeserialisationException("Deserialized instance is null, but no errors were reported");
			}
			return instance;
		}

		private static fsData LoadDataFromSaveFileBuffer(byte[] serializedBytesCompressed, int sizeCompressed, int sizeUncompressed, string contentDescription)
		{
			if (sizeUncompressed > 268435456)
			{
				throw new CorruptSaveException($"Save file {contentDescription} size is apparently way too big - file has either been tampered with or become corrupt");
			}
			byte[] bytes;
			try
			{
				bytes = LZ4Codec.Decode32(serializedBytesCompressed, 0, sizeCompressed, sizeUncompressed);
			}
			catch (Exception inner)
			{
				throw new CorruptSaveException("Save file is corrupt. Failed LZ4 decompression with exception.", inner);
			}
			string input;
			try
			{
				input = Encoding.UTF8.GetString(bytes);
			}
			catch (Exception inner2)
			{
				throw new CorruptSaveException("Save file is corrupt. Failed UTF decoding with exception.", inner2);
			}
			try
			{
				fsData data;
				fsResult fsResult2 = fsJsonParser.Parse(input, out data);
				if (fsResult2.Failed)
				{
					throw new CorruptSaveException($"Save file is corrupt. Error reported whilst parsing serialized {contentDescription} string: {fsResult2.FormattedMessages}");
				}
				return data;
			}
			catch (Exception inner3)
			{
				throw new CorruptSaveException("Save file is corrupt. Failed JSON parsing with exception.", inner3);
			}
		}

		public void Delete(SaveFileHeader inSaveFileHeader)
		{
			if (PlatformFileManager.FileExists(inSaveFileHeader.FilePath))
			{
				PlatformFileManager.DeleteSave(inSaveFileHeader.FilePath, deleteBackups: true);
				RefreshLevelSaveLists();
			}
		}

		public void DeleteAllLevelSaves(int slotIndex)
		{
			DeleteAllLevelSaveFilesInner(slotIndex);
			RefreshLevelSaveList(slotIndex);
		}

		private void DeleteAllLevelSaveFilesInner(int slotIndex)
		{
			string[] allFiles = PlatformFileManager.GetAllFiles(SaveLocationForSlot(slotIndex));
			foreach (string text in allFiles)
			{
				if (text.EndsWith(".sav"))
				{
					PlatformFileManager.DeleteSave(text, deleteBackups: true);
				}
			}
		}

		public static void Debug_DeleteAllLevelSaveFiles()
		{
			for (int i = 0; i < 3; i++)
			{
				Debug_DeleteAllLevelSaveFilesInner(SaveLocationForSlot(i));
			}
		}

		public static void Debug_DeleteAllLevelSaveFilesEditor()
		{
			for (int i = 0; i < 3; i++)
			{
				Debug_DeleteAllLevelSaveFilesInner(SaveLocationInEditorForSlot(i));
			}
		}

		public static void Debug_DeleteAllLevelSaveFilesStandalone()
		{
			for (int i = 0; i < 3; i++)
			{
				Debug_DeleteAllLevelSaveFilesInner(SaveLocationInStandaloneForSlot(i));
			}
		}

		public static void Debug_DeleteAllLevelSaveFilesInner(string saveLocation)
		{
			string[] files = Directory.GetFiles(saveLocation);
			if (files.Length == 0)
			{
				return;
			}
			for (int i = 0; i < files.Length; i++)
			{
				if (files[i].EndsWith(".sav") && PlatformFileManager.FileExists(files[i]))
				{
					PlatformFileManager.DeleteSave(files[i], deleteBackups: true);
				}
			}
		}

		public static void Debug_NukeSaveFolderEditor()
		{
			Directory.Delete(SaveLocationEditor, recursive: true);
		}

		public static void Debug_NukeSaveFolderStandalone()
		{
			Directory.Delete(SaveLocationStandalone, recursive: true);
		}

		public static void Debug_DeleteMetagameSaveFiles()
		{
			for (int i = 0; i < 3; i++)
			{
				PlatformFileManager.TryDeleteFileIfExists(MetagameSavePathForSlot(i));
			}
		}

		public static void Debug_DeleteMetagameSaveFilesEditor()
		{
			for (int i = 0; i < 3; i++)
			{
				PlatformFileManager.TryDeleteFileIfExists(MetagameSavePathInEditorForSlot(i));
			}
		}

		public static void Debug_DeleteMetagameSaveFilesStandalone()
		{
			for (int i = 0; i < 3; i++)
			{
				PlatformFileManager.TryDeleteFileIfExists(MetagameSavePathInStandaloneForSlot(i));
			}
		}

		public static void Debug_CreateJSONVersionsOfSaveFiles()
		{
			ThreadingUtils.Initialise();
			for (int i = 0; i < 3; i++)
			{
				FileUtils.EnsureDirectoryExists(DebugSaveOutputPathForSlot(i));
				Debug_CreateJSONVersionOfMetagameSaveForSlot(i);
				Debug_CreateJSONVersionOfLevelSavesForSlot(i);
			}
			Debug_CreateJSONVersionOfRoomTemplatesSave();
		}

		public static void Debug_CreateJSONVersionOfMetagameSaveForSlot(int slotIndex)
		{
			string[] files = Directory.GetFiles(SaveLocationForSlot(slotIndex));
			for (int i = 0; i < files.Length; i++)
			{
				if (!files[i].Contains(".csav"))
				{
					continue;
				}
				string path = files[i];
				try
				{
					Logging.Info("Pretty printing header JSON to file");
					MetagameSaveFileParts metagameSaveFileParts = ReadMetagameSaveFileParts(path, slotIndex);
					if (metagameSaveFileParts.Version == 1)
					{
						fsJsonPrinter.PrettyJsonStraightToFile(LoadDataFromSaveFileBuffer(metagameSaveFileParts.HeaderSerializedBytesCompressed, metagameSaveFileParts.HeaderSizeCompressed, metagameSaveFileParts.HeaderSizeUncompressed, "metagame header"), Path.Combine(DebugSaveOutputPathForSlot(slotIndex), Path.GetFileName(path) + ".header.json"));
					}
					else
					{
						string contents = MessagePackSerializer.ToJson(metagameSaveFileParts.HeaderSerializedBytesCompressed);
						File.WriteAllText(Path.Combine(DebugSaveOutputPathForSlot(slotIndex), Path.GetFileName(path) + ".header.json"), contents);
					}
					fsData data = LoadDataFromSaveFileBuffer(metagameSaveFileParts.BodySerializedBytesCompressed, metagameSaveFileParts.BodySizeCompressed, metagameSaveFileParts.BodySizeUncompressed, "metagame body");
					Logging.Info("Pretty printing body JSON to file");
					fsJsonPrinter.PrettyJsonStraightToFile(data, Path.Combine(DebugSaveOutputPathForSlot(slotIndex), Path.GetFileName(path) + ".body.json"));
				}
				catch (Exception ex)
				{
					Logging.Error(LogChannels.Save, "Exception encountered whilst generating JSON version of metagame save file: " + ex);
				}
			}
		}

		public static void Debug_CreateJSONVersionOfRoomTemplatesSave()
		{
			string[] files = Directory.GetFiles(SaveLocationEditor);
			for (int i = 0; i < files.Length; i++)
			{
				if (files[i].Contains(".tsav"))
				{
					string path = files[i];
					try
					{
						Logging.Info("Pretty printing header JSON to file");
						RoomTemplatesSaveFileParts roomTemplatesSaveFileParts = ReadRoomTemplatesSaveFileParts(path);
						string contents = MessagePackSerializer.ToJson(roomTemplatesSaveFileParts.HeaderSerializedBytesCompressed);
						File.WriteAllText(Path.Combine(DebugSaveOutputPath, Path.GetFileName(path) + ".header.json"), contents);
						fsData data = LoadDataFromSaveFileBuffer(roomTemplatesSaveFileParts.BodySerializedBytesCompressed, roomTemplatesSaveFileParts.BodySizeCompressed, roomTemplatesSaveFileParts.BodySizeUncompressed, "room templates body");
						Logging.Info("Pretty printing body JSON to file");
						fsJsonPrinter.PrettyJsonStraightToFile(data, Path.Combine(DebugSaveOutputPath, Path.GetFileName(path) + ".body.json"));
					}
					catch (Exception ex)
					{
						Logging.Error(LogChannels.Save, "Exception encountered whilst generating JSON version of room templates save file: " + ex);
					}
				}
			}
		}

		public static void Debug_CreateJSONVersionOfLevelSavesForSlot(int slotIndex)
		{
			string[] files = Directory.GetFiles(SaveLocationForSlot(slotIndex));
			for (int i = 0; i < files.Length; i++)
			{
				if (files[i].EndsWith(".sav"))
				{
					Debug_CreateJSONVersionOfLevelSave(files[i], slotIndex);
				}
			}
		}

		public static void Debug_CreateJSONVersionOfLevelSave(string path, int slotIndex)
		{
			try
			{
				Logging.Info("Converting {0}", path);
				Logging.Info("Reading parts");
				LevelSaveFileParts levelSaveFileParts = ReadLevelSaveFileParts(path);
				Logging.Info("Loading header");
				if (levelSaveFileParts.Version == 2)
				{
					fsData data = LoadDataFromSaveFileBuffer(levelSaveFileParts.HeaderSerializedBytesCompressed, levelSaveFileParts.HeaderSizeCompressed, levelSaveFileParts.HeaderSizeUncompressed, "level header");
					Logging.Info("Pretty printing header JSON to file");
					fsJsonPrinter.PrettyJsonStraightToFile(data, Path.Combine(DebugSaveOutputPathForSlot(slotIndex), Path.GetFileName(path) + ".header.json"));
				}
				else
				{
					string contents = MessagePackSerializer.ToJson(levelSaveFileParts.HeaderSerializedBytesCompressed);
					File.WriteAllText(Path.Combine(DebugSaveOutputPathForSlot(slotIndex), Path.GetFileName(path) + ".header.json"), contents);
				}
				Logging.Info("Loading body");
				fsData data2 = LoadDataFromSaveFileBuffer(levelSaveFileParts.BodySerializedBytesCompressed, levelSaveFileParts.BodySizeCompressed, levelSaveFileParts.BodySizeUncompressed, "level body");
				Logging.Info("Pretty printing body JSON to file");
				fsJsonPrinter.PrettyJsonStraightToFile(data2, Path.Combine(DebugSaveOutputPathForSlot(slotIndex), Path.GetFileName(path) + ".body.json"));
			}
			catch (Exception ex)
			{
				Logging.Error(LogChannels.Save, "Exception encountered whilst generating JSON version of level save file: " + ex);
			}
		}

		public static void Debug_CreateSaveFilesFromJSON()
		{
			ThreadingUtils.Initialise();
			for (int i = 0; i < 3; i++)
			{
				PlatformFileManager.EnsureDirectoryExists(SaveLocationForSlot(i));
				Debug_CreateMetagameSaveFileFromJSONForSlot(i);
				Debug_CreateLevelSaveFilesFromJSONForSlot(i);
			}
		}

		private static void Debug_CreateMetagameSaveFileFromJSONForSlot(int slotIndex)
		{
			string text = Path.Combine(DebugSaveOutputPathForSlot(slotIndex), "career.header.json");
			string text2 = Path.Combine(DebugSaveOutputPathForSlot(slotIndex), "career.body.json");
			if (!File.Exists(text))
			{
				Logging.Info("Path {0} does not exist", text);
				return;
			}
			if (!File.Exists(text2))
			{
				Logging.Info("Path {0} does not exist", text2);
				return;
			}
			byte[] headerSerializedBytes = MessagePackSerializer.FromJson(File.ReadAllText(text));
			if (headerSerializedBytes == null || headerSerializedBytes.Length == 0)
			{
				Logging.Info("Header JSON failed to parse as MessagePack binary");
				return;
			}
			fsData data;
			fsResult fsResult2 = fsJsonParser.Parse(File.ReadAllText(text2), out data);
			if (fsResult2.Failed)
			{
				Logging.Info("Body JSON failed to parse: {0}", fsResult2.FormattedMessages);
				return;
			}
			string s = fsJsonPrinter.CompressedJson(data);
			byte[] uncompressedBody = Encoding.UTF8.GetBytes(s);
			byte[] compressedBody = LZ4Codec.Encode32(uncompressedBody, 0, uncompressedBody.Length);
			Action<BinaryWriter> writeAction = delegate(BinaryWriter binaryWriter)
			{
				binaryWriter.Write(1835561076);
				binaryWriter.Write(SaveFileVersionMetagame);
				binaryWriter.Write(headerSerializedBytes.Length);
				binaryWriter.Write(0);
				binaryWriter.Write(compressedBody.Length);
				binaryWriter.Write(uncompressedBody.Length);
				binaryWriter.Write(headerSerializedBytes);
				binaryWriter.Write(compressedBody);
			};
			PlatformFileManager.Save(MetagameSavePathForSlot(slotIndex), writeAction, useBackups: true);
		}

		private static void Debug_CreateLevelSaveFilesFromJSONForSlot(int slotIndex)
		{
			string[] files = Directory.GetFiles(DebugSaveOutputPathForSlot(slotIndex), "*.body.json");
			foreach (string text in files)
			{
				string text2 = text.Replace(".body.", ".header.");
				if (!text.Contains("career") && PlatformFileManager.FileExists(text2))
				{
					Debug_CreateLevelSaveFileFromJSONForSlot(text, text2, slotIndex);
				}
			}
		}

		private static void Debug_CreateLevelSaveFileFromJSONForSlot(string bodyPath, string headerPath, int slotIndex)
		{
			string text = bodyPath.Substring(0, bodyPath.Length - ".body.json".Length);
			string saveName = text.Substring(text.Replace('\\', '/').LastIndexOf('/') + 1);
			Logging.Info("Attempting to convert {0} and {1} to save file", bodyPath, headerPath);
			if (!File.Exists(headerPath))
			{
				Logging.Info("Path {0} does not exist", headerPath);
				return;
			}
			if (!File.Exists(bodyPath))
			{
				Logging.Info("Path {0} does not exist", bodyPath);
				return;
			}
			byte[] headerSerializedBytes = MessagePackSerializer.FromJson(File.ReadAllText(headerPath));
			if (headerSerializedBytes == null || headerSerializedBytes.Length == 0)
			{
				Logging.Info("Header JSON failed to parse as MessagePack binary");
				return;
			}
			fsData data;
			fsResult fsResult2 = fsJsonParser.Parse(File.ReadAllText(bodyPath), out data);
			if (fsResult2.Failed)
			{
				Logging.Info("Body JSON failed to parse: {0}", fsResult2.FormattedMessages);
				return;
			}
			string s = fsJsonPrinter.CompressedJson(data);
			byte[] uncompressedBody = Encoding.UTF8.GetBytes(s);
			byte[] compressedBody = LZ4Codec.Encode32(uncompressedBody, 0, uncompressedBody.Length);
			Action<BinaryWriter> writeAction = delegate(BinaryWriter binaryWriter)
			{
				binaryWriter.Write(1835561076);
				binaryWriter.Write(SaveFileVersionMetagame);
				binaryWriter.Write(headerSerializedBytes.Length);
				binaryWriter.Write(0);
				binaryWriter.Write(compressedBody.Length);
				binaryWriter.Write(uncompressedBody.Length);
				binaryWriter.Write(headerSerializedBytes);
				binaryWriter.Write(compressedBody);
			};
			PlatformFileManager.Save(GetFullPathFromSaveName(saveName, slotIndex, isUserChosen: false, 0), writeAction, useBackups: true);
		}

		private ConsoleCommandResult DebugSetSaveSlot(string[] args)
		{
			return ConsoleCommandHelpers.ExtractInt(delegate(int x)
			{
				CurrentSaveSlot = x;
			}, args);
		}

		private static string GetFullPathFromSaveName(string saveName, int slotIndex, bool isUserChosen, int backupNumber)
		{
			string text = saveName;
			string text2 = SaveLocationForSlot(slotIndex);
			if (isUserChosen)
			{
				text = SanitiseFileNameCharacters(saveName);
				text = "Save_" + text;
				int num = text2.Length + 1 + text.Length + ".sav".Length + 1;
				if (backupNumber > 0)
				{
					num += 1 + (backupNumber + 1).ToString().Length + ".bak".Length;
				}
				int num2 = 260 - num;
				if (num2 < 0)
				{
					if (-num2 > text.Length)
					{
						throw new PathTooLongException("Path to save game is too long, even for blank save file name! Save directory must be a very long path");
					}
					text = text.Substring(0, text.Length + num2);
				}
			}
			return SaveUtils.GetBackupSavePath(Path.Combine(text2, text + ".sav"), backupNumber);
		}

		public static string SanitiseFileNameCharacters(string s)
		{
			string text = s;
			char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
			foreach (char oldChar in invalidFileNameChars)
			{
				text = text.Replace(oldChar, '_');
			}
			invalidFileNameChars = Path.GetInvalidPathChars();
			foreach (char oldChar2 in invalidFileNameChars)
			{
				text = text.Replace(oldChar2, '_');
			}
			return text;
		}

		private SaveFileHeader GetSaveFileHeaderWithFileInfo(FileInfo fileInfo)
		{
			for (int i = 0; i < _mSaveFileList[_currentSaveSlot].Count; i++)
			{
				if (_mSaveFileList[_currentSaveSlot][i].FilePath == fileInfo.FullName)
				{
					return _mSaveFileList[_currentSaveSlot][i];
				}
			}
			return null;
		}

		public SaveFileHeader GetSaveForLevel(string levelID, bool returnBrokenSaves = false)
		{
			for (int i = 0; i < _mSaveFileList[_currentSaveSlot].Count; i++)
			{
				SaveFileHeader saveFileHeader = _mSaveFileList[_currentSaveSlot][i];
				if (saveFileHeader.LevelID == levelID && (!saveFileHeader.IsBroken || returnBrokenSaves))
				{
					return saveFileHeader;
				}
			}
			return null;
		}

		public MetagameSaveHeader GetMetagameSaveHeaderForSlot(int slotIndex)
		{
			return _metagameSaveHeaders[slotIndex];
		}

		public void DeleteLevelSave(string levelID, int slotIndex)
		{
			PlatformFileManager.DeleteSave(GetFullPathFromSaveName(SanitiseFileNameCharacters(levelID), slotIndex, isUserChosen: false, 0), deleteBackups: true);
			List<SaveFileHeader> list = _mSaveFileList[slotIndex];
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].FilePath.Contains(levelID))
				{
					list.RemoveAt(i);
				}
			}
		}

		public void DeleteMetagameAndLevelSavesInSlot(int slotIndex)
		{
			PlatformFileManager.DeleteSave(MetagameSavePathForSlot(slotIndex), deleteBackups: true);
			string[] allFiles = PlatformFileManager.GetAllFiles(SaveLocationForSlot(slotIndex));
			for (int i = 0; i < allFiles.Length; i++)
			{
				PlatformFileManager.DeleteSave(allFiles[i], deleteBackups: false);
			}
			RefreshSaveList(slotIndex);
		}

		public void Refresh()
		{
			RefreshSaveLists();
		}

		private void OnSandboxChanged(SandboxSettings settings)
		{
			if (settings == null)
			{
				RefreshSaveLists();
				return;
			}
			LoadAndStoreLevelSaveHeadersForSlot(0);
			RefreshMostRecentLevelSaveForSlot(0);
		}

		public SaveFileHeader GetSaveForSandbox(SandboxSettings settings)
		{
			if (settings.Name.IsNullOrEmpty())
			{
				return null;
			}
			return LoadSaveHeaderFromFolder(SandboxSaveManager.SavePathForSettings(settings));
		}

		public SaveFileHeader LoadSaveHeaderFromFolder(string sandboxFolder)
		{
			if (PlatformFileManager.DirectoryExists(sandboxFolder))
			{
				try
				{
					string[] allFiles = PlatformFileManager.GetAllFiles(sandboxFolder);
					foreach (string text in allFiles)
					{
						if (text.EndsWith(".sav"))
						{
							SaveFileHeader saveFileHeader = LoadLevelSaveFileHeader(text);
							if (saveFileHeader != null)
							{
								return saveFileHeader;
							}
						}
					}
				}
				catch (Exception ex)
				{
					Logging.Error(LogChannels.Save, "Exception encountered while getting sandbox {0} save files: {1}", sandboxFolder, ex);
				}
			}
			return null;
		}
	}
}
