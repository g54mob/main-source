using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using App.Data;
using GoogleDocs;
using HTTP;
using Newtonsoft.Json;
using ResourcesManager;
using Unity.Components.Logs;
using Unity.Components.Scene;
using Unity.Components.SoundsManager;
using Unity.Tools;
using UnityEngine;
using Utils;

public class Program : MonoBehaviour
{
	public static bool validInABTest = false;

	private static int incorrectValue = int.MinValue;

	public static GameObject Canvas = null;

	public static Program Instance;

	public bool Offline;

	public string customScreenshotPath = "";

	private StaticData _staticData;

	public ParentalControl parentalControl;

	private StaticDataConfig _config;

	[NonSerialized]
	public AmplitudeAnalytics amp;

	private static string _saveGamePath;

	private static string _replayPath;

	private static string _version;

	private static int _versioni = 0;

	private static string _versioniStr;

	private static int tryGetUnityRemoteValue = 0;

	private static int maxTryGetUnitRemoteValue = 4;

	private static float tryDelay = 15f;

	private static float lastTry = -1f;

	public static Camera mainCam;

	[NonSerialized]
	public JoyWtlInput joyInput;

	[NonSerialized]
	public JoyWtlPC joyInputPC;

	public List<string> CommonSteamResolutions = new List<string>(new string[17]
	{
		"1024x768", "1280x800", "1280x1024", "1280x720", "1360x768", "1366x768", "1440x900", "1600x900", "1680x1050", "1920x1200",
		"1920x1080", "2560x1080", "2560x1600", "2560x1440", "2560x1080", "3440x1440", "3840x2160"
	});

	public RewiredCursor cursor;

	public MainMenu mainMenu;

	public static int Startups_tutorial_comics_68_percentile
	{
		get
		{
			return Model.startups_tutorial_comics_68_percentile;
		}
		set
		{
		}
	}

	public static string GetSaveGamePath()
	{
		return _saveGamePath;
	}

	public static string GetReplayPath()
	{
		return _replayPath;
	}

	public static string GetVersionString()
	{
		return _version;
	}

	public static int GetVersionInt()
	{
		return _versioni;
	}

	public static string GetShortVersion()
	{
		return _versioniStr;
	}

	private void Update()
	{
		InputSystem.Poll();
		Steam.Poll();
		if (!validInABTest && Logic.GetModel() != null && Logic.GetModel().globalSaves != null && tryGetUnityRemoteValue < maxTryGetUnitRemoteValue && Time.unscaledTime - tryDelay > lastTry)
		{
			lastTry = Time.unscaledTime;
			tryGetUnityRemoteValue++;
			Startups_tutorial_comics_68_percentile = incorrectValue;
		}
		if (Input.GetKeyDown(KeyCode.F12))
		{
			string dataPath = Application.dataPath;
			int num = dataPath.LastIndexOf('/');
			ScreenShotsTool.Shot(dataPath.Substring(0, num + 1) + "/Screenshots/", "png");
		}
		if (Logic.GetModel() != null)
		{
			Logic.GetModel().KeyBoardTicks--;
		}
	}

	private void SetUpReplayAndSaves()
	{
		string dataPath = Application.dataPath;
		int num = dataPath.LastIndexOf('/');
		if (num >= 0)
		{
			_saveGamePath = dataPath.Substring(0, num + 1) + "Saves/";
		}
		else
		{
			_saveGamePath = dataPath + "/Saves/";
		}
		Debug.LogError("save game path: " + _saveGamePath);
		if (!Directory.Exists(_saveGamePath))
		{
			Directory.CreateDirectory(_saveGamePath);
		}
	}

	private void Start()
	{
		Application.targetFrameRate = 60;
		Log.Debug("program start #{0}", GetInstanceID());
		Instance = this;
		mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
		Canvas = GameObject.Find("Canvas");
		_version = (ResourcesManager.Resources.Load("version") as TextAsset).ToString();
		string[] array = _version.Split('.');
		int num = Convert.ToInt32(array[0]);
		int num2 = Convert.ToInt32(array[1]);
		int num3 = Convert.ToInt32(array[2]);
		_versioni = num * 100000 + num2 * 1000 + num3;
		_versioniStr = num + "." + num2 + "." + num3;
		SetUpReplayAndSaves();
		InputSystem.Init();
		Steam.Init();
		if (Commandline.IsSet("--wipecloudsaves"))
		{
			Steam.DeleteAllCloudSaves(Logic.GetSaveNameTemplate());
		}
		Logic.ForceNoCloud = Commandline.IsSet("--nocloud");
		LoadConfig(out _config);
		Screen.sleepTimeout = -1;
		Sound.MusicVolume = 0.2f;
		Sound.VoiceVolume = 0f;
		Sound.UIVolume = 1f;
		Debug.Log("loading static data...");
		TextAsset textAsset = ResourcesManager.Resources.Load(_config.StaticDataPath) as TextAsset;
		string json = string.Empty;
		if (textAsset != null)
		{
			json = textAsset.text;
		}
		ProceedStaticDataAndLaunch(json, success: false);
	}

	public void OnApplicationQuit()
	{
		try
		{
			Steam.ForceShutdown();
		}
		catch
		{
		}
		Debug.Log("Program::OnApplicationQuit called");
	}

	private void ProceedStaticDataAndLaunch(string json, bool success)
	{
		CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
		CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
		if (LoadStaticData(json, out var data))
		{
			Debug.Log("loading static data...ok " + Time.timeSinceLevelLoad);
			Logic.staticDataLoaded = true;
			Logic.staticDataLoadedEvent.Invoke();
			Debug.Log("StaticDataLoadedEvent has been invoked");
		}
		else
		{
			Debug.Log("loading static data...fail");
		}
		data.Update();
		_staticData = data;
		ReLaunch();
	}

	public void ReLaunch()
	{
		StartCoroutine(Launch());
	}

	private IEnumerator Launch()
	{
		Cursor.visible = false;
		Log.Debug("relaunch");
		Log.Debug("init mvc...");
		Scene.DefaultComponentsBase = SceneData.SystemGObject;
		Model m = new Model();
		ViewModel vm = new ViewModel();
		Controller controller = Scene.FindOrCreate<Controller>();
		mainMenu = Scene.Find<MainMenu>();
		SoundSystem sound = Scene.Find<SoundSystem>();
		ActiveComponent.ResetGeneralComponents();
		ActiveComponent.InitGeneralComponents(m, controller, vm, _staticData, sound, this);
		joyInput = base.gameObject.AddComponent<JoyWtlPC>();
		joyInput.Init();
		joyInputPC = joyInput as JoyWtlPC;
		cursor = GameObject.Find("RewiredCursor").GetComponent<RewiredCursor>();
		cursor.Init();
		Logic.GetModel().InputDeviceChanged.Invoke("PC");
		_staticData.Init();
		QuestLine.Clear();
		CarObjectTree.Init();
		GameObject gameObject = GameObject.Find("ReloadingObject");
		Logic.GetModel().firstLoad = gameObject == null;
		bool num = Logic.LoadOrCreateGlobalSaves();
		Debug.LogError("Global saves inited");
		amp = base.gameObject.AddComponent<AmplitudeAnalytics>();
		amp.Init(GetShortVersion(), Logic.GetModel().globalSaves.user_id_ab.ToString());
		if (Logic.GetModel().globalSaves.Resolution == null)
		{
			Logic.GetModel().globalSaves.Resolution = new Pair<int, int>(1920, 1080);
		}
		if (!Logic.IsSteamDeckRunning())
		{
			Pair<int, int> resolution = Logic.GetModel().globalSaves.Resolution;
			string item = $"{resolution.First}x{resolution.Second}";
			if (!CommonSteamResolutions.Contains(item))
			{
				CommonSteamResolutions.Add(item);
			}
			Screen.SetResolution(Logic.GetModel().globalSaves.Resolution.First, Logic.GetModel().globalSaves.Resolution.Second, Logic.GetModel().globalSaves.FullScreen);
		}
		Startups_tutorial_comics_68_percentile = incorrectValue;
		if (num)
		{
			if (Logic.GetModel().globalSaves.lang == 0)
			{
				if (Application.systemLanguage == SystemLanguage.Russian)
				{
					Logic.GetModel().globalSaves.lang = 1;
				}
				if (Application.systemLanguage == SystemLanguage.German)
				{
					Logic.GetModel().globalSaves.lang = 7;
				}
				if (Application.systemLanguage == SystemLanguage.Korean)
				{
					Logic.GetModel().globalSaves.lang = 4;
				}
				if (Application.systemLanguage == SystemLanguage.Greek)
				{
					Logic.GetModel().globalSaves.lang = 5;
				}
				if (Application.systemLanguage == SystemLanguage.Portuguese)
				{
					Logic.GetModel().globalSaves.lang = 6;
				}
				if (Application.systemLanguage == SystemLanguage.Chinese || Application.systemLanguage == SystemLanguage.ChineseSimplified || Application.systemLanguage == SystemLanguage.ChineseTraditional)
				{
					Logic.GetModel().globalSaves.lang = 2;
				}
				if (Application.systemLanguage == SystemLanguage.Polish)
				{
					Logic.GetModel().globalSaves.lang = 8;
				}
				if (Application.systemLanguage == SystemLanguage.French)
				{
					Logic.GetModel().globalSaves.lang = 9;
				}
				if (Application.systemLanguage == SystemLanguage.Italian)
				{
					Logic.GetModel().globalSaves.lang = 14;
				}
				if (Application.systemLanguage == SystemLanguage.Spanish)
				{
					Logic.GetModel().globalSaves.lang = 16;
				}
				if (Application.systemLanguage == SystemLanguage.Turkish)
				{
					Logic.GetModel().globalSaves.lang = 18;
				}
			}
			Logic.SendAnalytics("LAUNCH_FIRST_TIME", new Dictionary<string, object>
			{
				{
					"version",
					GetShortVersion()
				},
				{
					"cohort_day",
					Logic.GetModel().globalSaves.cohort_day
				},
				{
					"user_id_ab",
					Logic.GetModel().globalSaves.user_id_ab
				}
			});
		}
		if (controller != null && controller.gameObject.activeInHierarchy)
		{
			controller.Init();
		}
		Log.Debug("init mvc...ok");
		mainMenu.Init();
		yield break;
	}

	public static bool LoadStaticData(string json, out StaticData data)
	{
		if (string.IsNullOrEmpty(json))
		{
			Log.Warning("loading static data...fail, using default data");
			data = new StaticData();
			return false;
		}
		data = JsonConvert.DeserializeObject<StaticData>(json, Logic.GetGlobalSettings());
		return true;
	}

	public static bool LoadConfig(out StaticDataConfig config)
	{
		string text = string.Empty;
		if (ResourcesManager.Resources.LoadNotBakedText("configs/config.json", out text))
		{
			config = JsonConvert.DeserializeObject<StaticDataConfig>(text, Logic.GetGlobalSettings());
			return true;
		}
		config = new StaticDataConfig();
		return false;
	}

	public static StaticData LoadStaticData()
	{
		LoadConfig(out var config);
		ResourcesManager.Resources.LoadNotBakedText(ResourcesManager.Resources.GetNotBakedPath(config.StaticDataPath, "json"), out var text);
		LoadStaticData(text, out var data);
		Debug.Log(data);
		return data;
	}

	public static void DownloadStaticData()
	{
		LoadConfig(out var cfg);
		HTTPLoader _HTTPLoader = HTTPLoader.Create(new GameObject("downloader"));
		new GSLoader(_HTTPLoader).LoadAllSheets(cfg.StaticDataSheetID, delegate(string json, bool success)
		{
			if (success)
			{
				string notBakedPath = ResourcesManager.Resources.GetNotBakedPath(cfg.StaticDataPath, "json");
				Log.Debug("caching static data to '{0}'...", notBakedPath);
				File.WriteAllText(notBakedPath, json);
			}
			else
			{
				Log.Debug("error");
			}
			UnityEngine.Object.DestroyImmediate(_HTTPLoader.gameObject);
		});
	}
}
