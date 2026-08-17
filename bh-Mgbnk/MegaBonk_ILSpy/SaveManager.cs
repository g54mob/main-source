using System;
using System.IO;
using System.Runtime.Serialization;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using Newtonsoft.Json;
using Rewired;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
	private static bool USE_ENCRYPTION;

	private static bool TEST_SAVES;

	private static int settingsVersion;

	private static ulong steamIdSave;

	private const string configName = "config.json";

	private const string statsName = "stats.json";

	private const string progressionName = "progression.json";

	public const string controllersName = "controller_config.json";

	public ConfigSaveFile config;

	public StatsSaveFile stats;

	public ProgressionSaveFile progression;

	private static SaveManager _003CInstance_003Ek__BackingField;

	public static Action A_SavesLoaded;

	public static Action A_ProgressionSaved;

	private static string cloudDirectory;

	private static string localDirectory;

	private static string defaultSavesPath;

	private static string testingSavesPath;

	private static string TEST_SAVES_VERSION;

	private const string lastSteamIdKey = "saves_last_steamid";

	public static bool loaded;

	private bool usingNoSave;

	public static SaveManager Instance
	{
		get
		{
			return _003CInstance_003Ek__BackingField;
		}
		private set
		{
			_003CInstance_003Ek__BackingField = value;
		}
	}

	public void Init()
	{
		if (_003CInstance_003Ek__BackingField != null && _003CInstance_003Ek__BackingField != this)
		{
			GameObject obj = base.gameObject;
			UnityEngine.Object.Destroy(obj);
		}
		else
		{
			_003CInstance_003Ek__BackingField = this;
		}
	}

	private void Awake()
	{
		Init();
	}

	private void OnDestroy()
	{
		if (_003CInstance_003Ek__BackingField == this && progression != null)
		{
			progression.OnDestroy();
		}
	}

	private void OnApplicationQuit()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172E90]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		SaveConfig();
		SaveStats();
		SaveProgression();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
	}

	public void SaveConfig()
	{
		if (config != null && loaded && !usingNoSave)
		{
			string serializedJson = JsonConvert.SerializeObject(config, Formatting.Indented);
			string configPath = GetConfigPath();
			SaveTemp(serializedJson, configPath, encrypt: false);
		}
	}

	public void SaveStats()
	{
		if (stats != null && loaded)
		{
			string serializedJson = JsonConvert.SerializeObject(stats, Formatting.Indented);
			string statsPath = GetStatsPath();
			SaveTemp(serializedJson, statsPath, encrypt: true);
		}
	}

	public void SaveProgression()
	{
		if (progression != null && loaded && !usingNoSave)
		{
			string serializedJson = JsonConvert.SerializeObject(progression, Formatting.Indented);
			string progressionPath = GetProgressionPath();
			SaveTemp(serializedJson, progressionPath, encrypt: true);
			Action a_ProgressionSaved = A_ProgressionSaved;
			if (A_ProgressionSaved != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v59.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private void SaveTemp(string serializedJson, string filePath, bool encrypt)
	{
		//IL_00c1: Expected I, but got O
		//IL_00ff: Expected O, but got I
		//IL_00ff: Expected O, but got I
		//IL_0124: Expected I, but got O
		bool flag = !encrypt;
		string text = serializedJson;
		if (!flag)
		{
			string text2 = SimpleEncryptor.Encrypt(serializedJson);
			bool flag2 = string.IsNullOrEmpty(text2);
			text = text2;
			if (flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				Exception ex = new Exception("Encryption returned empty or null data");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				throw ex;
			}
		}
		string text3 = filePath + ".tmp";
		string destinationBackupFileName = filePath + ".bak";
		FileShare share = default(FileShare);
		FileStream fileStream = new FileStream(text3, FileMode.Create, FileAccess.Write, share);
		Stream stream = default(Stream);
		StreamWriter streamWriter = new StreamWriter(stream);
		Exception ex2 = default(Exception);
		if (ex2 != null)
		{
			nint num = (nint)ex2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v171 @ rax_v19 (Il2CppClass<System.Exception>)+248] (should have been resolved before IL gen)");
			if (ex2 != null)
			{
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rax_v19 (Il2CppClass<System.Exception>)+250]");
				ex2.GetObjectData((SerializationInfo)num2, (StreamingContext)0);
				if (stream != null)
				{
					nint num3 = (nint)stream;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v301 @ rax_v23 (Il2CppClass<System.Exception>)+3A8] (should have been resolved before IL gen)");
					if (ex2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
					}
					if (stream != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
					}
					if (!File.Exists(filePath))
					{
						File.Move(text3, filePath);
					}
					else
					{
						File.Replace(text3, filePath, destinationBackupFileName);
					}
					return;
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	private static string GetDataPath()
	{
		string path;
		string path2;
		if (TEST_SAVES)
		{
			string persistentDataPath = Application.persistentDataPath;
			string text = testingSavesPath + " " + TEST_SAVES_VERSION;
			path = text;
			path2 = persistentDataPath;
		}
		else
		{
			string persistentDataPath2 = Application.persistentDataPath;
			path = defaultSavesPath;
			path2 = persistentDataPath2;
		}
		return Path.Combine(path2, path);
	}

	private static string GetDataPathDefault()
	{
		string persistentDataPath = Application.persistentDataPath;
		return Path.Combine(persistentDataPath, defaultSavesPath);
	}

	private static string GetCloudFolder()
	{
		string dataPath = GetDataPath();
		return Path.Combine(dataPath, cloudDirectory);
	}

	private static string GetLocalFolder()
	{
		string dataPath = GetDataPath();
		return Path.Combine(dataPath, localDirectory);
	}

	private string GetConfigPath()
	{
		string localFolder = GetLocalFolder();
		return Path.Combine(localFolder, "config.json");
	}

	private unsafe string GetStatsPath()
	{
		//IL_001c: Expected I, but got O
		//IL_0032: Expected I8, but got I
		string cloudFolder = GetCloudFolder();
		nint num = (nint)typeof(SaveManager);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rcx_v4 (Il2CppClass<SaveManager>)+B8]");
		ulong num2 = (ulong)(nint)((nuint)0u + (nuint)8u);
		string path = ((ulong*)num2)->ToString();
		return Path.Combine(cloudFolder, path, "stats.json");
	}

	private unsafe string GetProgressionPath()
	{
		//IL_001c: Expected I, but got O
		//IL_0032: Expected I8, but got I
		string cloudFolder = GetCloudFolder();
		nint num = (nint)typeof(SaveManager);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rcx_v4 (Il2CppClass<SaveManager>)+B8]");
		ulong num2 = (ulong)(nint)((nuint)0u + (nuint)8u);
		string path = ((ulong*)num2)->ToString();
		return Path.Combine(cloudFolder, path, "progression.json");
	}

	public unsafe static string GetControllersPath()
	{
		//IL_001c: Expected I, but got O
		//IL_0032: Expected I8, but got I
		string cloudFolder = GetCloudFolder();
		nint num = (nint)typeof(SaveManager);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rcx_v4 (Il2CppClass<SaveManager>)+B8]");
		ulong num2 = (ulong)(nint)((nuint)0u + (nuint)8u);
		string path = ((ulong*)num2)->ToString();
		return Path.Combine(cloudFolder, path, "controller_config.json");
	}

	public unsafe static string GetControllersDir()
	{
		//IL_001c: Expected I, but got O
		//IL_0032: Expected I8, but got I
		string cloudFolder = GetCloudFolder();
		nint num = (nint)typeof(SaveManager);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rcx_v4 (Il2CppClass<SaveManager>)+B8]");
		ulong num2 = (ulong)(nint)((nuint)0u + (nuint)8u);
		string path = ((ulong*)num2)->ToString();
		return Path.Combine(cloudFolder, path);
	}

	public void Load(bool loadBackup)
	{
		ref string failPath = default(ref string);
		if (!Load(SteamManager.steamId, loadBackup, out var failReason, out failPath))
		{
			AlwaysManager instance = AlwaysManager.Instance;
			AlwaysUi alwaysUi = instance.alwaysUi;
			ConfigWarning._003CShowWarningCoroutine_003Ed__12 obj = new ConfigWarning._003CShowWarningCoroutine_003Ed__12(0);
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = alwaysUi.configWarning;
			obj.e = failReason;
			string filepath = default(string);
			obj.filepath = filepath;
			Coroutine coroutine = alwaysUi.configWarning.StartCoroutine(obj);
		}
	}

	public void LoadNoSave()
	{
		ConfigSaveFile configSaveFile = new ConfigSaveFile();
		config = configSaveFile;
		ProgressionSaveFile progressionSaveFile = new ProgressionSaveFile();
		progression = progressionSaveFile;
		StatsSaveFile statsSaveFile = new StatsSaveFile();
		stats = statsSaveFile;
		config.Init();
		progression.Init();
		stats.Init();
		loaded = true;
		Action a_SavesLoaded = A_SavesLoaded;
		if (A_SavesLoaded != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v160.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		usingNoSave = true;
	}

	public unsafe bool Load(ulong steamId, bool loadBackup, out string failReason, out string failPath)
	{
		//IL_012f: Expected I, but got O
		//IL_0145: Expected I8, but got I
		//IL_01bc: Expected O, but got I4
		//IL_0226: Expected O, but got I4
		//IL_031a: Expected O, but got I4
		//IL_0371: Expected O, but got I4
		//IL_03c8: Expected O, but got I4
		//IL_02de: Expected O, but got I4
		//IL_0601: Expected I4, but got O
		Init();
		ref string reference = ref *(string*)"";
		string cloudFolder = GetCloudFolder();
		object obj = cloudFolder;
		ulong num2;
		if (steamId != steamIdSave || !loaded)
		{
			if (steamId == 0)
			{
				if (PlayerPrefs.HasKey("saves_last_steamid"))
				{
					string s = PlayerPrefs.GetString("saves_last_steamid");
					ulong num = ulong.Parse(s);
					num2 = num;
				}
				else
				{
					num2 = steamId;
				}
				if (num2 == 0)
				{
					goto IL_0650;
				}
			}
			ulong num3 = default(ulong);
			string value = num3.ToString();
			PlayerPrefs.SetString("saves_last_steamid", value);
			num2 = num3;
			goto IL_0650;
		}
		Debug.LogError("Tried to load more than once?");
		return false;
		IL_0779:
		string path;
		if (!File.Exists(path))
		{
			ProgressionSaveFile progressionSaveFile = new ProgressionSaveFile();
			progression = progressionSaveFile;
			SaveProgression();
		}
		else
		{
			if (!USE_ENCRYPTION)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822672F0");
				object obj2 = default(object);
				if (obj2 != null)
				{
					string value2 = File.ReadAllText(path);
					ProgressionSaveFile progressionSaveFile2 = JsonConvert.DeserializeObject<ProgressionSaveFile>(value2);
					progression = progressionSaveFile2;
					goto IL_079f;
				}
			}
			string encryptedText = File.ReadAllText(path);
			string value3 = SimpleEncryptor.Decrypt(encryptedText);
			ProgressionSaveFile progressionSaveFile3 = JsonConvert.DeserializeObject<ProgressionSaveFile>(value3);
			progression = progressionSaveFile3;
		}
		goto IL_079f;
		IL_079f:
		if (config != null)
		{
			config.Init();
			progression.Init();
			stats.Init();
			loaded = true;
			usingNoSave = false;
			Action a_SavesLoaded = A_SavesLoaded;
			if (A_SavesLoaded != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1205.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			return true;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0650:
		steamIdSave = num2;
		string dataPath = GetDataPath();
		string text = Path.Combine(dataPath, cloudDirectory);
		string localFolder = GetLocalFolder();
		nint num4 = (nint)typeof(SaveManager);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rcx_v19 (Il2CppClass<SaveManager>)+B8]");
		ulong num5 = (ulong)(nint)((nuint)0u + (nuint)8u);
		string path2 = ((ulong*)num5)->ToString();
		string text2 = Path.Combine(text, path2);
		string configPath = GetConfigPath();
		string statsPath = GetStatsPath();
		string progressionPath = GetProgressionPath();
		bool flag = !loadBackup;
		path = progressionPath;
		string path3 = statsPath;
		string path4 = configPath;
		object obj3 = 0;
		if (!flag)
		{
			string text3 = configPath + ".bak";
			string text4 = statsPath + ".bak";
			string text5 = progressionPath + ".bak";
			path = text5;
			path3 = text4;
			path4 = text3;
			obj3 = 0;
		}
		string dataPath2 = GetDataPath();
		if (TEST_SAVES && !Directory.Exists(dataPath2))
		{
			string dataPathDefault = GetDataPathDefault();
			if (Directory.Exists(dataPathDefault))
			{
				string dataPathDefault2 = GetDataPathDefault();
				CopyDirectory(dataPathDefault2, dataPath2);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
				obj3 = 0;
			}
		}
		if (!Directory.Exists(text))
		{
			DirectoryInfo directoryInfo = Directory.CreateDirectory(text);
			string s2 = "Created saves path cloud: " + text;
			MyLogger.LogInBuild(s2);
			obj3 = 0;
		}
		if (!Directory.Exists(localFolder))
		{
			DirectoryInfo directoryInfo2 = Directory.CreateDirectory(localFolder);
			string s3 = "Created saves path local: " + localFolder;
			MyLogger.LogInBuild(s3);
			obj3 = 0;
		}
		if (!Directory.Exists(text2))
		{
			DirectoryInfo directoryInfo3 = Directory.CreateDirectory(text2);
			string s4 = "Created user dir: " + text2;
			MyLogger.LogInBuild(s4);
			obj3 = 0;
		}
		if (File.Exists(path4))
		{
			string value4 = File.ReadAllText(path4);
			ConfigSaveFile configSaveFile = JsonConvert.DeserializeObject<ConfigSaveFile>(value4);
			config = configSaveFile;
		}
		else
		{
			ConfigSaveFile configSaveFile2 = new ConfigSaveFile();
			config = configSaveFile2;
			SaveConfig();
		}
		if (!File.Exists(path3))
		{
			StatsSaveFile statsSaveFile = new StatsSaveFile();
			stats = statsSaveFile;
			SaveStats();
		}
		else
		{
			if (!USE_ENCRYPTION)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822672F0");
				object obj4 = default(object);
				if (obj4 != null)
				{
					string value5 = File.ReadAllText(path3);
					StatsSaveFile statsSaveFile2 = JsonConvert.DeserializeObject<StatsSaveFile>(value5);
					stats = statsSaveFile2;
					goto IL_0779;
				}
			}
			string encryptedText2 = File.ReadAllText(path3);
			string value6 = SimpleEncryptor.Decrypt(encryptedText2);
			StatsSaveFile statsSaveFile3 = JsonConvert.DeserializeObject<StatsSaveFile>(value6);
			stats = statsSaveFile3;
		}
		goto IL_0779;
	}

	public void NewSaveConfig()
	{
		ConfigSaveFile configSaveFile = new ConfigSaveFile();
		config = configSaveFile;
		config.Init();
	}

	public void ResetAll()
	{
		ConfigSaveFile configSaveFile = new ConfigSaveFile();
		config = configSaveFile;
		config.Init();
		ProgressionSaveFile progressionSaveFile = new ProgressionSaveFile();
		progression = progressionSaveFile;
		progression.Init();
		StatsSaveFile statsSaveFile = new StatsSaveFile();
		stats = statsSaveFile;
		stats.Init();
	}

	private static void CopyDirectory(string sourceDir, string destinationDir, bool recursive = true)
	{
		//IL_005b: Expected O, but got I4
		//IL_0064: Expected O, but got I4
		//IL_00d0: Expected O, but got I4
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		//IL_010b: Expected I, but got O
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Expected O, but got Unknown
		//IL_01df: Expected I, but got O
		DirectoryInfo directoryInfo = new DirectoryInfo(sourceDir);
		bool exists = directoryInfo.Exists;
		bool flag = !exists;
		string text = sourceDir;
		if (!flag)
		{
			DirectoryInfo directoryInfo2 = Directory.CreateDirectory(destinationDir);
			FileInfo[] files = directoryInfo.GetFiles();
			object obj = 0;
			object obj2 = 0;
			text = sourceDir;
			while (true)
			{
				if ((nint)obj2 < files.Length)
				{
					if ((nint)obj >= files.Length)
					{
						break;
					}
					text = (string)(object)files[obj];
					TypeCode typeCode = ((string)(object)files[obj]).GetTypeCode();
					string destFileName = Path.Combine(destinationDir, (string)typeCode);
					FileInfo fileInfo = files[obj].CopyTo(destFileName, overwrite: true);
					obj++;
					nint num = unchecked((nint)null);
					obj2 = obj;
					continue;
				}
				if (!recursive)
				{
					return;
				}
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				string text2 = null;
				text = null;
				while (true)
				{
					if ((nint)text2 < directories.Length)
					{
						if ((nint)text >= directories.Length)
						{
							break;
						}
						string path = directories[(object)text].Name;
						string destinationDir2 = Path.Combine(destinationDir, path);
						string fullName = directories[(object)text].FullName;
						CopyDirectory(fullName, destinationDir2);
						text++;
						nint num = unchecked((nint)null);
						text2 = text;
						continue;
					}
					return;
				}
				break;
			}
			throw new IndexOutOfRangeException();
		}
		string text3 = "Source directory not found: " + text;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		object obj3 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18148A5D0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		throw obj3;
	}

	public void SaveControllers()
	{
		Player player = MyInputManager.GetPlayer();
		if (player != null)
		{
			PlayerSaveData saveData = player.GetSaveData(userAssignableMapsOnly: true);
			object obj = default(object);
			object value = (PlayerSaveData)obj;
			string contents = JsonConvert.SerializeObject(value, Formatting.Indented);
			string controllersPath = GetControllersPath();
			File.WriteAllText(controllersPath, contents);
			string s = "Saved Rewired controller config to: " + controllersPath;
			MyLogger.LogInBuild(s);
		}
		else
		{
			Debug.LogError("Can't save because player is null");
		}
	}

	public void LoadControllers()
	{
		//IL_009b: Expected O, but got I4
		//IL_00f3: Expected O, but got I
		//IL_0108: Expected O, but got I
		//IL_0122: Expected O, but got I
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		string controllersPath = GetControllersPath();
		if (File.Exists(controllersPath))
		{
			string value = File.ReadAllText(controllersPath);
			PlayerSaveData playerSaveData = JsonConvert.DeserializeObject<PlayerSaveData>(value);
			Player player = MyInputManager.GetPlayer();
			if (player != null)
			{
				object obj = default(object);
				bool flag = obj == null;
				object obj2 = 0;
				if (flag)
				{
					throw new NullReferenceException();
				}
				while (true)
				{
					object obj3 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ stack_-60+18]");
					if ((nint)obj3 < 0)
					{
						Player.ControllerHelper controllers = player.controllers;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ stack_-60+20+v162 @ rbx_v8*8]");
						ControllerType controllerType = ((ControllerMapSaveData)0).controllerType;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ stack_-60+20+v162 @ rbx_v8*8]");
						Controller controller = ((ControllerMapSaveData)0).controller;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ stack_-60+20+v162 @ rbx_v8*8]");
						KeyboardMap keyboardMap = ((KeyboardMapSaveData)0).keyboardMap;
						controllers.maps.AddMap(controllerType, controller.id, keyboardMap);
						Debug.LogError("Loaded keyboard map");
						obj2++;
						continue;
					}
					break;
				}
			}
			else
			{
				Debug.LogError("Failed to read Controller Config because player is null");
			}
		}
		else
		{
			string message = "Rewired controller config not found: " + controllersPath;
			Debug.LogWarning(message);
		}
	}

	static SaveManager()
	{
		//IL_0047: Expected I8, but got I4
		USE_ENCRYPTION = true;
		TEST_SAVES = false;
		settingsVersion = 1;
		steamIdSave = 69uL;
		cloudDirectory = "CloudDir";
		localDirectory = "LocalDir";
		defaultSavesPath = "Saves";
		testingSavesPath = "Saves_For_Testing";
		TEST_SAVES_VERSION = "(1.0.5)";
	}
}
