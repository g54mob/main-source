using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Common.SaveSystem;
using UnityEngine;

namespace Fullscreen.NanoSave.Runtime
{
	[Serializable]
	[Title("NanoSave")]
	[Category("NanoSave")]
	[Image(typeof(IconNanoSave), ColorTheme.Type.White)]
	[Description("Stores game information in compressed JSON save slots with separate metadata, backup, integrity check, and screenshot support")]
	public class NanoSave : TDataStorage
	{
		public enum ScreenshotResolution
		{
			Full = 0,
			Half = 1,
			Quarter = 2,
			Eighth = 3
		}

		public delegate void CorruptedSaveDetectedHandler();

		private class CoroutineHelper : MonoBehaviour
		{
		}

		[Serializable]
		private class Block
		{
			[SerializeField]
			private List<Entry> m_Entries = new List<Entry>();

			public Entry[] Entries => m_Entries.ToArray();

			public Block(IDictionary<string, Entry> data)
			{
				m_Entries = new List<Entry>(data.Values);
			}

			public void AddEntry(Entry entry)
			{
				m_Entries.Add(entry);
			}
		}

		[Serializable]
		private class Entry
		{
			[SerializeField]
			private string m_Key;

			[SerializeField]
			private string m_Value;

			public string Key => m_Key;

			public string Value => m_Value;

			public Entry(string key, string value)
			{
				m_Key = key;
				m_Value = value;
			}
		}

		[Serializable]
		private class CopyProtectionData
		{
			[SerializeField]
			private string m_DeviceId;

			[SerializeField]
			private Block m_Data;

			public string DeviceId
			{
				get
				{
					return m_DeviceId;
				}
				set
				{
					m_DeviceId = value;
				}
			}

			public Block Data
			{
				get
				{
					return m_Data;
				}
				set
				{
					m_Data = value;
				}
			}
		}

		[Serializable]
		private class Metadata
		{
			[SerializeField]
			private string m_Timestamp = string.Empty;

			[SerializeField]
			private string m_Title = string.Empty;

			[SerializeField]
			private string m_Location = string.Empty;

			[SerializeField]
			private string m_Progression = string.Empty;

			[SerializeField]
			private string m_TotalPlaytime = string.Empty;

			[SerializeField]
			private string m_CharLevel = string.Empty;

			[SerializeField]
			private string m_AppVersion = string.Empty;

			public string Timestamp
			{
				get
				{
					return m_Timestamp;
				}
				set
				{
					m_Timestamp = value;
				}
			}

			public string Title
			{
				get
				{
					return m_Title;
				}
				set
				{
					m_Title = value;
				}
			}

			public string Location
			{
				get
				{
					return m_Location;
				}
				set
				{
					m_Location = value;
				}
			}

			public string Progression
			{
				get
				{
					return m_Progression;
				}
				set
				{
					m_Progression = value;
				}
			}

			public string TotalPlaytime
			{
				get
				{
					return m_TotalPlaytime;
				}
				set
				{
					m_TotalPlaytime = value;
				}
			}

			public string CharLevel
			{
				get
				{
					return m_CharLevel;
				}
				set
				{
					m_CharLevel = value;
				}
			}

			public string AppVersion
			{
				get
				{
					return m_AppVersion;
				}
				set
				{
					m_AppVersion = value;
				}
			}
		}

		private const string SAVES_FOLDER = "/Saves/";

		private const string SAVE_FILE = "SAVE.GZ";

		private const string META_FILE = "game_data.meta";

		private const string BACKUP_FOLDER = "/Backup/";

		private const string SCREENSHOT_FILE = "Screenshot.png";

		private static Dictionary<string, Entry> CacheData = new Dictionary<string, Entry>();

		private static HashSet<string> DirtyKeys = new HashSet<string>();

		private static bool _isInitialized = false;

		[SerializeField]
		private PropertyGetString title = new PropertyGetString("Prologue");

		[SerializeField]
		private PropertyGetString saveSlotLocation = new PropertyGetString("Unknown Location");

		[SerializeField]
		private PropertyGetString saveSlotProgression = new PropertyGetString("0%");

		[SerializeField]
		private PropertyGetString saveSlotTotalPlaytime = new PropertyGetString("0h 0m");

		[SerializeField]
		private PropertyGetString characterLevel = new PropertyGetString("Level 1");

		[SerializeField]
		private string folderPrefix = "NANOSAVE";

		[SerializeField]
		private bool backupSaveFile = true;

		[SerializeField]
		private bool takeScreenshot = true;

		[SerializeField]
		private bool copyProtection;

		[SerializeField]
		private ScreenshotResolution screenshotResolution = ScreenshotResolution.Quarter;

		[SerializeField]
		protected LayerMask m_LayerMask = -5;

		private CoroutineHelper coroutineHelper;

		private string FOLDER_PREFIX => folderPrefix + "_";

		public static event CorruptedSaveDetectedHandler OnCorruptedSaveDetected;

		public override Task DeleteAll()
		{
			CacheData.Clear();
			DirtyKeys.Clear();
			DeleteAllFiles(Application.persistentDataPath);
			return Task.CompletedTask;
		}

		public override Task DeleteKey(string key)
		{
			string persistentDataPath = Application.persistentDataPath;
			if (string.IsNullOrEmpty(persistentDataPath))
			{
				throw new Exception("Application.persistentDataPath is empty!");
			}
			if (CacheData.Remove(key))
			{
				DirtyKeys.Add(key);
				string text = ExtractMiddleNumber(key);
				string middleNumberPadded = text.PadLeft(4, '0');
				string text2 = Path.Combine(persistentDataPath, "Saves");
				if (!Directory.Exists(text2))
				{
					Debug.LogWarning("Saves folder not found: " + text2);
					return Task.CompletedTask;
				}
				string text3 = Directory.GetDirectories(text2).FirstOrDefault((string path) => Path.GetFileName(path).EndsWith(middleNumberPadded));
				if (!string.IsNullOrEmpty(text3) && Directory.Exists(text3))
				{
					try
					{
						Directory.Delete(text3, recursive: true);
					}
					catch (Exception ex)
					{
						Debug.LogError("Failed to delete slot folder at " + text3 + ": " + ex.Message);
					}
				}
			}
			return Task.CompletedTask;
		}

		public override Task<bool> HasKey(string key)
		{
			EnsureOlimp();
			return Task.FromResult(CacheData.ContainsKey(key));
		}

		public override Task<object> Get(string key, Type type)
		{
			EnsureOlimp();
			Entry value;
			return Task.FromResult((CacheData.TryGetValue(key, out value) && !string.IsNullOrEmpty(value.Value)) ? JsonUtility.FromJson(value.Value, type) : null);
		}

		public override Task Set(string key, object value)
		{
			try
			{
				string value2 = JsonUtility.ToJson(value, prettyPrint: false);
				if (string.IsNullOrEmpty(value2))
				{
					return Task.CompletedTask;
				}
				CacheData[key] = new Entry(key, value2);
				DirtyKeys.Add(key);
				return Task.CompletedTask;
			}
			catch (Exception ex)
			{
				Debug.LogError($"Failed to serialize value for '{key}': {ex}");
				return Task.FromException(new InvalidOperationException("Serialization failed", ex));
			}
		}

		public override Task Commit()
		{
			string persistentDataPath = Application.persistentDataPath;
			string text = persistentDataPath + "/Saves/";
			string text2 = persistentDataPath + "/Backup/";
			try
			{
				Directory.CreateDirectory(text);
				Directory.CreateDirectory(text2);
				Dictionary<string, Block> dictionary = SplitDataByMiddleNumber();
				string timestamp = FormatCurrentTime();
				string text3 = title.Get(Args.EMPTY);
				string location = saveSlotLocation.Get(Args.EMPTY);
				string progression = saveSlotProgression.Get(Args.EMPTY);
				string totalPlaytime = saveSlotTotalPlaytime.Get(Args.EMPTY);
				string charLevel = characterLevel.Get(Args.EMPTY);
				string version = Application.version;
				string deviceUniqueIdentifier = SystemInfo.deviceUniqueIdentifier;
				foreach (KeyValuePair<string, Block> item in dictionary)
				{
					string key = item.Key;
					string text4 = Path.Combine(text, FOLDER_PREFIX + key);
					string text5 = Path.Combine(text4, "SAVE.GZ");
					string text6 = Path.Combine(text4, "game_data.meta");
					string text7 = Path.Combine(text2, FOLDER_PREFIX + key + "_SAVE.GZ");
					string text8 = Path.Combine(text2, FOLDER_PREFIX + key + "_game_data.meta");
					string screenshotFilePath = Path.Combine(text4, "Screenshot.png");
					if (item.Value.Entries.Length == 0)
					{
						if (Directory.Exists(text4))
						{
							Directory.Delete(text4, recursive: true);
						}
						if (File.Exists(text7))
						{
							File.Delete(text7);
						}
						if (File.Exists(text8))
						{
							File.Delete(text8);
						}
					}
					else
					{
						if (!item.Value.Entries.Any((Entry e) => DirtyKeys.Contains(e.Key)))
						{
							continue;
						}
						Directory.CreateDirectory(text4);
						if (backupSaveFile && File.Exists(text5))
						{
							if (File.Exists(text7))
							{
								File.Delete(text7);
							}
							File.Copy(text5, text7);
						}
						if (backupSaveFile && File.Exists(text6))
						{
							if (File.Exists(text8))
							{
								File.Delete(text8);
							}
							File.Copy(text6, text8);
						}
						string text9 = ((!copyProtection) ? JsonUtility.ToJson(item.Value, prettyPrint: false) : JsonUtility.ToJson(new CopyProtectionData
						{
							DeviceId = deviceUniqueIdentifier,
							Data = item.Value
						}, prettyPrint: false));
						SaveBlockToFile(text5, text9);
						string contents = JsonUtility.ToJson(new Metadata
						{
							Timestamp = timestamp,
							Title = text3,
							Location = location,
							Progression = progression,
							TotalPlaytime = totalPlaytime,
							CharLevel = charLevel,
							AppVersion = version
						});
						File.WriteAllText(text6, contents);
						if (!VerifySaveFile(text5, text9))
						{
							Debug.LogError("Corrupted save detected: " + text5);
							NanoSave.OnCorruptedSaveDetected?.Invoke();
							string path = $"CorruptedSaveSlot{key}{DateTime.Now:yyyyMMdd_HHmmss}.gz";
							string text10 = Path.Combine(text4, path);
							if (File.Exists(text5))
							{
								File.Move(text5, text10);
								Debug.Log("Corrupted file saved as: " + text10);
							}
							if (backupSaveFile && File.Exists(text7))
							{
								File.Copy(text7, text5);
								Debug.Log("Restored from backup: " + text5);
								if (File.Exists(text8))
								{
									File.Delete(text6);
									File.Copy(text8, text6);
									Debug.Log("Restored metadata from backup: " + text6);
								}
							}
						}
						if (!takeScreenshot || !(key != "0000") || !(coroutineHelper != null))
						{
							continue;
						}
						coroutineHelper.StartCoroutine(CaptureScreenshotCoroutine(screenshotFilePath, screenshotResolution, delegate(Texture2D screenshot)
						{
							if (screenshot != null)
							{
								File.WriteAllBytes(screenshotFilePath, screenshot.EncodeToPNG());
								UnityEngine.Object.Destroy(screenshot);
							}
						}));
					}
				}
				DirtyKeys.Clear();
			}
			catch (Exception arg)
			{
				Debug.LogError($"Commit failed: {arg}");
				throw;
			}
			return Task.CompletedTask;
		}

		private IEnumerator CaptureScreenshotCoroutine(string screenshotFilePath, ScreenshotResolution resolution, Action<Texture2D> callback)
		{
			yield return new WaitForEndOfFrame();
			int num = Screen.width;
			int num2 = Screen.height;
			switch (resolution)
			{
			case ScreenshotResolution.Half:
				num /= 2;
				num2 /= 2;
				break;
			case ScreenshotResolution.Quarter:
				num /= 4;
				num2 /= 4;
				break;
			case ScreenshotResolution.Eighth:
				num /= 8;
				num2 /= 8;
				break;
			}
			RenderTexture temporary = RenderTexture.GetTemporary(num, num2, 24);
			Texture2D texture2D = null;
			try
			{
				Camera main = Camera.main;
				if (main != null)
				{
					int cullingMask = main.cullingMask;
					main.cullingMask = m_LayerMask;
					main.targetTexture = temporary;
					main.Render();
					main.targetTexture = null;
					main.cullingMask = cullingMask;
				}
				RenderTexture.active = temporary;
				texture2D = new Texture2D(num, num2, TextureFormat.RGB24, mipChain: false);
				texture2D.ReadPixels(new Rect(0f, 0f, num, num2), 0, 0);
				texture2D.Apply();
				RenderTexture.active = null;
				RenderTexture.ReleaseTemporary(temporary);
				callback(texture2D);
			}
			catch (Exception arg)
			{
				Debug.LogError($"Screenshot capture failed: {arg}");
				if (texture2D != null)
				{
					UnityEngine.Object.Destroy(texture2D);
				}
				RenderTexture.ReleaseTemporary(temporary);
			}
		}

		private void SaveBlockToFile(string path, string json)
		{
			string value = base.Cryptography.Encrypt(json);
			using FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write);
			using GZipStream stream2 = new GZipStream(stream, CompressionMode.Compress);
			using StreamWriter streamWriter = new StreamWriter(stream2);
			streamWriter.Write(value);
		}

		private bool VerifySaveFile(string path, string originalJson)
		{
			try
			{
				if (!File.Exists(path))
				{
					return false;
				}
				string input;
				using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
				{
					using GZipStream stream2 = new GZipStream(stream, CompressionMode.Decompress);
					using StreamReader streamReader = new StreamReader(stream2);
					input = streamReader.ReadToEnd();
				}
				return base.Cryptography.Decrypt(input) == originalJson;
			}
			catch (Exception ex)
			{
				Debug.LogError("Verification failed for " + path + ": " + ex.Message);
				return false;
			}
		}

		private void LoadFromFile(string filePath)
		{
			try
			{
				if (!File.Exists(filePath))
				{
					return;
				}
				string text;
				using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
				{
					using GZipStream stream2 = new GZipStream(stream, CompressionMode.Decompress);
					using StreamReader streamReader = new StreamReader(stream2);
					text = streamReader.ReadToEnd();
				}
				if (string.IsNullOrEmpty(text))
				{
					return;
				}
				text = base.Cryptography.Decrypt(text);
				Block block;
				if (copyProtection)
				{
					CopyProtectionData copyProtectionData = JsonUtility.FromJson<CopyProtectionData>(text);
					if (copyProtectionData == null || copyProtectionData.Data == null)
					{
						throw new InvalidDataException("Invalid protected save data");
					}
					string deviceUniqueIdentifier = SystemInfo.deviceUniqueIdentifier;
					if (copyProtectionData.DeviceId != deviceUniqueIdentifier)
					{
						Debug.LogError("Copy protection: Save file at " + filePath + " is bound to a different device (ID: " + copyProtectionData.DeviceId + "). Current device ID: " + deviceUniqueIdentifier + ". Loading aborted.");
						return;
					}
					block = copyProtectionData.Data;
				}
				else
				{
					block = JsonUtility.FromJson<Block>(text);
				}
				if (block?.Entries == null)
				{
					throw new InvalidDataException("Invalid block data");
				}
				Entry[] entries = block.Entries;
				foreach (Entry entry in entries)
				{
					CacheData[entry.Key] = entry;
				}
			}
			catch (Exception ex)
			{
				Debug.LogError("Failed to load '" + filePath + "': " + ex.Message);
			}
		}

		private void DeleteAllFiles(string path)
		{
			string path2 = path + "/Saves/";
			string path3 = path + "/Backup/";
			string[] directories;
			if (Directory.Exists(path2))
			{
				directories = Directory.GetDirectories(path2);
				for (int i = 0; i < directories.Length; i++)
				{
					Directory.Delete(directories[i], recursive: true);
				}
			}
			if (!Directory.Exists(path3))
			{
				return;
			}
			directories = Directory.GetFiles(path3);
			foreach (string text in directories)
			{
				try
				{
					File.Delete(text);
				}
				catch (Exception arg)
				{
					Debug.LogWarning($"Failed to delete {text}: {arg}");
				}
			}
		}

		private void EnsureOlimp()
		{
			if (!_isInitialized)
			{
				if (coroutineHelper == null)
				{
					GameObject gameObject = new GameObject("NanoSaveCoroutineHelper");
					coroutineHelper = gameObject.AddComponent<CoroutineHelper>();
					gameObject.hideFlags = HideFlags.HideInHierarchy;
					UnityEngine.Object.DontDestroyOnLoad(gameObject);
				}
				InitializeCacheData();
				_isInitialized = true;
			}
		}

		private void InitializeCacheData()
		{
			string path = Application.persistentDataPath + "/Saves/";
			if (Directory.Exists(path))
			{
				string[] directories = Directory.GetDirectories(path);
				for (int i = 0; i < directories.Length; i++)
				{
					string filePath = Path.Combine(directories[i], "SAVE.GZ");
					LoadFromFile(filePath);
				}
			}
		}

		private Dictionary<string, Block> SplitDataByMiddleNumber()
		{
			Dictionary<string, Block> dictionary = new Dictionary<string, Block>();
			foreach (KeyValuePair<string, Entry> cacheDatum in CacheData)
			{
				string key = ExtractMiddleNumber(cacheDatum.Key);
				if (!dictionary.TryGetValue(key, out var value))
				{
					value = (dictionary[key] = new Block(new Dictionary<string, Entry>()));
				}
				value.AddEntry(cacheDatum.Value);
			}
			return dictionary;
		}

		private string ExtractMiddleNumber(string key)
		{
			string[] array = key.Split('-');
			if (array.Length < 2)
			{
				return "Unknown";
			}
			return array[1];
		}

		public (string title, string timestamp, string location, string progression, string totalPlaytime, string charLevel, string appVersion) GetMetaDataForSlot(string slotNumber)
		{
			string persistentDataPath = Application.persistentDataPath;
			if (string.IsNullOrEmpty(persistentDataPath))
			{
				throw new Exception("Application.persistentDataPath is empty!");
			}
			string text = Path.Combine(persistentDataPath, "Saves");
			if (!Directory.Exists(text))
			{
				Debug.LogWarning("Saves folder not found: " + text);
				return (title: string.Empty, timestamp: string.Empty, location: string.Empty, progression: string.Empty, totalPlaytime: string.Empty, charLevel: string.Empty, appVersion: string.Empty);
			}
			string text2 = Directory.GetDirectories(text).FirstOrDefault((string path) => Path.GetFileName(path).EndsWith(slotNumber));
			if (string.IsNullOrEmpty(text2))
			{
				return (title: string.Empty, timestamp: string.Empty, location: string.Empty, progression: string.Empty, totalPlaytime: string.Empty, charLevel: string.Empty, appVersion: string.Empty);
			}
			string text3 = Path.Combine(text2, "game_data.meta");
			if (!File.Exists(text3))
			{
				Debug.LogWarning("Metadata file not found at: " + text3);
				return (title: string.Empty, timestamp: string.Empty, location: string.Empty, progression: string.Empty, totalPlaytime: string.Empty, charLevel: string.Empty, appVersion: string.Empty);
			}
			try
			{
				Metadata metadata = JsonUtility.FromJson<Metadata>(File.ReadAllText(text3));
				if (metadata == null)
				{
					return (title: string.Empty, timestamp: string.Empty, location: string.Empty, progression: string.Empty, totalPlaytime: string.Empty, charLevel: string.Empty, appVersion: string.Empty);
				}
				return (title: metadata.Title, timestamp: metadata.Timestamp, location: metadata.Location, progression: metadata.Progression, totalPlaytime: metadata.TotalPlaytime, charLevel: metadata.CharLevel, appVersion: metadata.AppVersion);
			}
			catch (Exception ex)
			{
				Debug.LogError("Failed to read metadata from " + text3 + ": " + ex.Message);
				return (title: string.Empty, timestamp: string.Empty, location: string.Empty, progression: string.Empty, totalPlaytime: string.Empty, charLevel: string.Empty, appVersion: string.Empty);
			}
		}

		private string FormatCurrentTime()
		{
			CultureInfo currentCulture = CultureInfo.CurrentCulture;
			return DateTime.Now.ToString(currentCulture.DateTimeFormat.ShortDatePattern + " " + currentCulture.DateTimeFormat.ShortTimePattern);
		}
	}
}
