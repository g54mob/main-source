#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FullInspector.Internal;
using FullSerializerSave;
using TH20.ExtContent;
using UnityEngine;

namespace TH20
{
	public class SandboxSaveManager : MustCallDestroy
	{
		private const ulong Magic = 50159747054uL;

		private const int Version = 5;

		private const string SaveFileName = "sandbox";

		private const string SaveFileExtension = "set";

		private const string SaveFileFullName = "sandbox.set";

		private const string SaveLocationSubdirectoryName = "Sandbox";

		private static readonly string SaveLocation = Path.Combine(PlatformFileManager.CloudDirectory, "Sandbox");

		private readonly SandboxSettingsConfig _config;

		private readonly fsSerializer _serializer;

		private readonly StringBuilder _largeStringBuilderJSONCache = new StringBuilder();

		private readonly StringBuilder _smallStringBuilderJSONCache = new StringBuilder();

		private static SandboxSettings _currentSettings;

		private readonly List<SandboxSettings> _allSettings = new List<SandboxSettings>();

		public static Action<SandboxSettings> OnSettingsChanged;

		public static Action<SandboxSettings> OnSandboxDeleted;

		public List<SandboxSettings> AllSettings => _allSettings;

		public static SandboxSettings CurrentSettings
		{
			get
			{
				return _currentSettings;
			}
			set
			{
				if (_currentSettings != value)
				{
					_currentSettings = value;
					OnSettingsChanged(value);
					Logging.Info(LogChannels.Sandbox, "Current settings set to {0}", (_currentSettings == null) ? "NULL" : _currentSettings.Name);
				}
			}
		}

		public SandboxSaveManager(SandboxSettingsConfig config, BiDictionary<int, object> assetIDs)
		{
			_config = config;
			_serializer = CreateSerializer(assetIDs);
			EnsureDirectoryExists(SaveLocation);
			RefreshSaveLists();
		}

		public override void Destroy()
		{
			ActionExtension.VerifyCallValid = true;
			OnSettingsChanged.VerifyIsNull();
			OnSandboxDeleted.VerifyIsNull();
			ActionExtension.VerifyCallValid = false;
			base.Destroy();
		}

		private static bool EnsureDirectoryExists(string folder)
		{
			if (!PlatformFileManager.DirectoryExists(folder))
			{
				PlatformFileManager.CreateDirectory(folder);
				return PlatformFileManager.DirectoryExists(folder);
			}
			return true;
		}

		private static fsSerializer CreateSerializer(BiDictionary<int, object> externallyStoredObjects)
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
			string[] directories = PlatformFileManager.GetDirectories(SaveLocation);
			_allSettings.Clear();
			string[] array = directories;
			foreach (string folder in array)
			{
				SandboxSettings sandboxSettings = LoadFromFolder(folder);
				if (sandboxSettings != null)
				{
					_allSettings.Add(sandboxSettings);
				}
			}
		}

		public SandboxSettings LoadFromFolder(string folder)
		{
			string text = Path.Combine(folder.StartsWith(SaveLocation) ? folder : Path.Combine(SaveLocation, folder), "sandbox.set");
			if (PlatformFileManager.FileExists(text))
			{
				Logging.Info(LogChannels.Sandbox, "Found sandbox settings file {0}", text);
				return LoadSandboxSave(text);
			}
			return null;
		}

		public static string SavePathForSettings(SandboxSettings settings)
		{
			return Path.Combine(SaveLocation, settings.SaveFolder);
		}

		private static string SaveFilenameForSettings(SandboxSettings settings)
		{
			return Path.Combine(SavePathForSettings(settings), "sandbox.set");
		}

		public bool SaveSandboxSettings(SandboxSettings settings)
		{
			Logging.Info(LogChannels.Sandbox, "Saving sandbox settings {0}", settings.DisplayName);
			try
			{
				fiSerializationManager.IsInSaveOrLoad = true;
				fiSerializationManager.DisableAutomaticSerialization = true;
				fsData data;
				fsResult fsResult2 = _serializer.TrySerialize(settings, out data);
				if (fsResult2.Failed)
				{
					Logging.Error(LogChannels.Sandbox, "Failed to serialise SaveData: {0}", fsResult2.FormattedMessages);
					return false;
				}
				if (fsResult2.HasWarnings)
				{
					Logging.Error(LogChannels.Sandbox, "SaveData serialize had warnings: {0}", fsResult2.FormattedMessages);
					return false;
				}
				string text = SavePathForSettings(settings);
				if (!EnsureDirectoryExists(text))
				{
					Logging.Error(LogChannels.Sandbox, "Failed to create sandbox settings folder: {0}", text);
					return false;
				}
				string serializedString = fsJsonPrinter.CompressedJson(data, _largeStringBuilderJSONCache, _smallStringBuilderJSONCache);
				Action<BinaryWriter> writeAction = delegate(BinaryWriter binaryWriter)
				{
					binaryWriter.Write(50159747054uL);
					binaryWriter.Write(5);
					binaryWriter.Write(serializedString);
				};
				string text2 = SaveFilenameForSettings(settings);
				PlatformFileManager.Save(text2, writeAction, useBackups: false);
				Logging.Info(LogChannels.Sandbox, "Saved sandbox settings file {0}", text2);
				_allSettings.AddUnique(settings);
				return true;
			}
			catch (Exception ex)
			{
				Logging.Error(LogChannels.Sandbox, "Exception encountered whilst saving {0}", ex);
				return false;
			}
			finally
			{
				fiSerializationManager.DisableAutomaticSerialization = false;
				fiSerializationManager.IsInSaveOrLoad = false;
			}
		}

		private SandboxSettings LoadSandboxSave(string fileName)
		{
			if (!PlatformFileManager.Load(fileName, out var reader))
			{
				return null;
			}
			SandboxSettings instance = null;
			using (reader)
			{
				try
				{
					if (reader.ReadUInt64() != 50159747054L)
					{
						throw new CorruptSaveException("Sandbox setting file is not valid");
					}
					int num = reader.ReadInt32();
					if (num > 5)
					{
						throw new CorruptSaveException("Sandbox setting file is from the future!");
					}
					fsData data;
					try
					{
						fsResult fsResult2 = fsJsonParser.Parse(reader.ReadString(), out data);
						if (fsResult2.Failed)
						{
							throw new CorruptSaveException($"Sandbox setting file is corrupt. Error reported whilst parsing string: {fsResult2.FormattedMessages}");
						}
					}
					catch (Exception arg)
					{
						throw new CorruptSaveException($"Sandbox setting file is corrupt. Failed JSON parsing with exception: {arg}");
					}
					fsResult fsResult3;
					try
					{
						fiSerializationManager.DisableAutomaticSerialization = true;
						fiSerializationManager.IsInSaveOrLoad = true;
						fsResult3 = _serializer.TryDeserialize(data, ref instance);
					}
					finally
					{
						fiSerializationManager.DisableAutomaticSerialization = false;
						fiSerializationManager.IsInSaveOrLoad = false;
					}
					if (fsResult3.Failed)
					{
						throw new SaveDeserialisationException($"Error reported whilst deserializing: {fsResult3.FormattedMessages}");
					}
					if (instance == null)
					{
						throw new SaveDeserialisationException("Deserialized instance is null, but no errors were reported");
					}
					instance.RestoreFromSave(_config, num);
					Logging.Info(LogChannels.Sandbox, "Successfully loaded sandbox settings file ({0})", instance.Name);
				}
				catch (Exception ex)
				{
					Logging.Error(LogChannels.Sandbox, "Broken sandbox setting file found ({0}); Failed to load save data; exception while deserialising: {1}", fileName, ex);
				}
			}
			return instance;
		}

		public void Delete(SandboxSettings settings)
		{
			try
			{
				PlatformFileManager.DeleteDirectory(SavePathForSettings(settings));
				_allSettings.Remove(settings);
				if (CurrentSettings == settings)
				{
					CurrentSettings = null;
				}
				OnSandboxDeleted.InvokeSafe(settings);
			}
			catch (Exception ex)
			{
				Logging.Error(LogChannels.Sandbox, "Failed to delete sandbox settings ({0}): {1}", settings.DisplayName, ex);
			}
		}

		public string CreateUniqueSaveName(string name)
		{
			string text = name;
			bool flag = false;
			int num = 0;
			while (!flag)
			{
				flag = true;
				foreach (SandboxSettings allSetting in _allSettings)
				{
					if (allSetting.Name == text)
					{
						num++;
						flag = false;
						text = $"{name}_{num}";
						break;
					}
				}
			}
			return text;
		}

		public void SortSettingsByLastPlayed(SaveSystem saveSystem)
		{
			Dictionary<SaveFileHeader, SandboxSettings> dictionary = new Dictionary<SaveFileHeader, SandboxSettings>();
			for (int i = 0; i < _allSettings.Count; i++)
			{
				SandboxSettings sandboxSettings = _allSettings[i];
				SaveFileHeader saveForSandbox = saveSystem.GetSaveForSandbox(sandboxSettings);
				if (saveForSandbox != null)
				{
					dictionary.Add(saveForSandbox, sandboxSettings);
				}
			}
			List<SaveFileHeader> list = dictionary.Keys.ToList();
			list.Sort((SaveFileHeader settings1, SaveFileHeader settings2) => settings2.Date.CompareTo(settings1.Date));
			_allSettings.Clear();
			for (int num = 0; num < list.Count; num++)
			{
				SaveFileHeader key = list[num];
				SandboxSettings item = dictionary[key];
				_allSettings.Add(item);
			}
		}

		public bool CanCreateNewSave()
		{
			if (!PlatformFileManager.LimitNumberOfSandboxSaves)
			{
				return true;
			}
			return AllSettings.Count < PlatformFileManager.MaxSandboxSaves;
		}

		public bool PublishWorkshopItem(SandboxSettings settings, Texture2D texture2DThumbnail)
		{
			string sandboxSaveFolderSpec = SavePathForSettings(settings);
			string uniqueId = settings.LevelConfig.UniqueId;
			List<string> sandboxSaveFilenames = new List<string>
			{
				"sandbox.set",
				"career.csav",
				$"{uniqueId}.sav"
			};
			return ExtContentUtils.ExtContentManager.PublishSandboxSave(sandboxSaveFolderSpec, sandboxSaveFilenames, settings.DisplayName, texture2DThumbnail);
		}

		public bool LoadWorkshopItem(SandboxSettings settings, GameItemBase workshopItem)
		{
			settings.Name = CreateUniqueSaveName(settings.DisplayName);
			string text = SavePathForSettings(settings);
			if (!EnsureDirectoryExists(text))
			{
				Logging.Error(LogChannels.Sandbox, "Failed to create sandbox folder {0}", text);
				return false;
			}
			string[] files = Directory.GetFiles(workshopItem.InstalledFolderPathSpec);
			foreach (string text2 in files)
			{
				if (text2.EndsWith(".sav") || text2.EndsWith(".csav"))
				{
					string fileName = Path.GetFileName(text2);
					string text3 = Path.Combine(text, fileName);
					try
					{
						File.Copy(text2, text3);
					}
					catch (Exception ex)
					{
						Logging.Error(LogChannels.Sandbox, "Failed to copy {0} to {1} ({2})", text2, text3, ex);
						return false;
					}
				}
			}
			return SaveSandboxSettings(settings);
		}
	}
}
