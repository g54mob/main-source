using System;
using System.IO;
using System.Reflection;
using Assets.Scripts.Achievements;
using Assets.Scripts.Analytics.Logging;
using Assets.Scripts.Audio;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.CraftFiles;
using Assets.Scripts.Craft.CraftResourceData;
using Assets.Scripts.Craft.Decals;
using Assets.Scripts.Craft.Paint;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Design;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Demo;
using Assets.Scripts.Flight.Maps;
using Assets.Scripts.GuiNew;
using Assets.Scripts.Input;
using Assets.Scripts.Input.XR;
using Assets.Scripts.Levels;
using Assets.Scripts.Mods;
using Assets.Scripts.Multiplayer;
using Assets.Scripts.Multiplayer.ActivityFramework;
using Assets.Scripts.Scenes;
using Assets.Scripts.Scenes.Startup;
using Assets.Scripts.Settings;
using Assets.Scripts.Storage;
using Assets.Scripts.UI;
using Assets.Scripts.XR;
using Jundroo.Common.Cache;
using Jundroo.Common.Extensions;
using Jundroo.Common.Platform;
using Jundroo.Common.Utils;
using Jundroo.SocialPlatforms;
using Jundroo.SocialPlatforms.Steam;
using Jundroo.SocialPlatforms.Steam.Events;
using Rewired;
using Rewired.Platforms;
using UnityEngine;

namespace Assets.Scripts
{
	[Obfuscation(Exclude = true)]
	public sealed class Game
	{
		public const string RequiredResourcesFolder = "InstalledResources/Required";

		public static readonly Guid SessionID = Guid.NewGuid();

		public static readonly Version Version = new Version(0, 7, 0, 0);

		private static volatile Game _instance;

		private static object _lockObject = new object();

		private bool _newVersionSinceLastRun;

		private GameObject _rootGameObject;

		private Action _upgradeInputSystem = delegate
		{
		};

		public static string ClientControllerUrl => SimplePlanesWebsiteUrl + "/Client";

		public static GameInputs Inputs { get; private set; }

		public static Game Instance
		{
			get
			{
				if (_instance == null)
				{
					lock (_lockObject)
					{
						if (_instance == null)
						{
							new Game();
						}
					}
				}
				return _instance;
			}
		}

		public static string SimplePlanesWebsiteUrl => "https://www.simpleplanes.com";

		public AircraftThemes AircraftThemes { get; private set; }

		public DesignerPartList CachedDesignerParts { get; private set; }

		public string[] ClonedEditorArgs { get; private set; }

		public string ClonedEditorName { get; private set; }

		public CraftDatabase CraftDatabase { get; }

		public CraftDecalManager CraftDecalManager { get; private set; }

		public CraftResourceDataScript CraftResourceData { get; }

		public CraftUpdateManagerScript CraftUpdateManager { get; private set; }

		public LevelInfo CurrentLevel { get; set; }

		public MapBase CurrentMap { get; set; }

		public DemoData[] DemoData { get; }

		public SimplePlanesDevConsoleScript DevConsole { get; }

		public IDevice Device { get; set; }

		public string DownloadedAircraftId { get; set; }

		public InputManager InputManager { get; private set; }

		public XRInputManager InputManagerXR { get; private set; }

		public bool IsClonedEditor { get; private set; }

		public string LastAircraftId { get; set; }

		public LevelDatabase LevelDatabase { get; private set; }

		public IModManager ModManager => ModManagerScript?.ModManager;

		public ModManagerScript ModManagerScript { get; private set; }

		public MusicPlayerScript MusicPlayer { get; private set; }

		public NetworkedActivityManager NetworkedActivityManager { get; private set; }

		public NetworkGameManager NetworkGameManager { get; private set; }

		public bool NewVersionNotificationShown { get; internal set; }

		public PaintTextureManager PaintTextureManager { get; private set; }

		public PartTypeList PartTypes { get; private set; }

		public GameObject PersistentScriptsContainer { get; private set; }

		public string PrefabDirectory => "Data/Parts";

		public IResourceLoader ResourceLoader { get; set; }

		public SceneManager SceneManager { get; }

		public string SelectedCraftId { get; set; } = "__editor__.xml";

		public SettingsManager Settings { get; private set; }

		public UIInfo UIInfo { get; private set; }

		public UserInterface UserInterface { get; private set; }

		public WebCacheScript WebCache { get; private set; }

		public XRDeviceManager XRDeviceManager { get; }

		private Game()
		{
			try
			{
				CheckForClonedEditor();
				PersistentScriptsContainer = new GameObject("PersistentScripts");
				UnityEngine.Object.DontDestroyOnLoad(PersistentScriptsContainer);
				_rootGameObject = PersistentScriptsContainer;
				_rootGameObject.AddComponent<CustomLogger>().EnableSpamDetection = !Application.isEditor;
				if (!Application.isPlaying && (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor))
				{
					Debug.LogError("Game.cs constructor running outside of play mode!");
				}
				_instance = this;
				UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
				InstallResources();
				Device = Jundroo.Common.Platform.Device.CurrentDevice;
				SystemUtils.SaveWindowHandle();
				ResourceLoader = new ResourceLoader();
				if (Device.IsDemoBuild)
				{
					DemoData = new DemoData[2]
					{
						ResourceLoader.Load<DemoData>("Demo/DemoDataDriftwood"),
						ResourceLoader.Load<DemoData>("Demo/DemoDataBannock")
					};
				}
				DevConsole = ResourceLoader.InstantiatePrefab<SimplePlanesDevConsoleScript>("Common/SimplePlanesDevConsole");
				if (SocialExt.Active == null)
				{
					SocialExt.Initialize(AchievementManager.Instance.Achievements);
				}
				CloudStorageManager.Initialize();
				XRDeviceManager = XRDeviceManager.Create();
				UIInfo = UIInfo.Create();
				AchievementManager.Instance.LoadAchievements();
				DownloadedAircraftId = null;
				Settings = SettingsManager.Create();
				bool flag = Settings.App.AppVersionLastRun < Version;
				if (flag)
				{
					ProcessNewVersionSinceLastRun(Version, Settings.App.AppVersionLastRun);
				}
				CraftDatabase = new CraftDatabase();
				CraftDatabase.BeginAsyncInitialization(flag, flag);
				InitializeInputManager();
				_upgradeInputSystem();
				AircraftThemes = new AircraftThemes(GetPathForDocument("AircraftThemes.xml"));
				PaintTextureManager.CopyPaintTexturesExampleXml();
				CraftDecalManager.CopyCraftDecalsExampleXml();
				PaintTextureManager = PaintTextureManager.Create(_rootGameObject);
				CraftDecalManager = CraftDecalManager.Create(_rootGameObject);
				CraftResourceData = CraftResourceDataScript.Create(_rootGameObject, ResourceLoader);
				PartTypes = new PartTypeList();
				PartTypes.LoadXml(ResourceLoader.LoadText("Data/Parts/PartTypes"));
				CachedDesignerParts = new DesignerPartList();
				CachedDesignerParts.LoadDesignerPartsFile();
				LevelDatabase = new LevelDatabase(GetPathForDocument("Levels.xml"), !Instance.Device.IsMobileBuild, Device.IsOculusQuest1);
				if (SocialExt.IsSteam)
				{
					SteamPlatform obj = (SteamPlatform)SocialExt.Active;
					obj.GameWebCallback += OnGameWebCallback;
					obj.NewLaunchParameters += OnNewLaunchParameters;
				}
				ModManagerScript = ModManagerScript.Create(_rootGameObject);
				GameObject gameObject = new GameObject("WebCache");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				WebCache = gameObject.AddComponent<WebCacheScript>();
				WebCache.Initialize(GameData.GetPath("Cache", "Web"), 50000000L);
				if (_newVersionSinceLastRun)
				{
					try
					{
						Debug.Log("Wiping text entries from web cache.");
						WebCache.ClearAllTextEntries();
						WebCache.SaveCacheMetaData();
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
				CurrentLevel = LevelDatabase.GetLevel("LevelSandbox");
				CurrentMap = new DefaultMap();
				SceneManager = SceneManager.Create(null);
				CraftUpdateManager = CraftUpdateManagerScript.Create(_rootGameObject);
				UserInterface = new UserInterface(PersistentScriptsContainer);
				NetworkGameManager = NetworkGameManager.Create(_rootGameObject);
				NetworkedActivityManager = NetworkedActivityManager.Create(_rootGameObject);
				InitializeMusic(Settings.Gameplay.Audio.MusicVolume);
				Application.quitting += OnApplicationQuitting;
				Application.focusChanged += OnApplicationFocusChanged;
			}
			catch (Exception exception2)
			{
				Debug.LogException(exception2);
			}
		}

		public static string GetDownloadAircraftDetailsUrl(string aircraftId)
		{
			return SimplePlanesWebsiteUrl + "/Client/GetPostDetails/" + aircraftId;
		}

		public static string GetDownloadAircraftUrl(string aircraftId, int revision = 0)
		{
			string text = $"{SimplePlanesWebsiteUrl}/Client/DownloadAircraft?a={aircraftId}&clientVersion={1}";
			if (revision > 0)
			{
				text += $"&revision={revision}";
			}
			return text;
		}

		public static bool TryGetInstance(out Game instance)
		{
			return (instance = _instance) != null;
		}

		public void Awake()
		{
			NewVersionNotificationShown = false;
		}

		public string GetPathForDocument(string relativePath)
		{
			return GameData.GetPath(relativePath);
		}

		public void InstallResources()
		{
			string path = "InstalledResources/Required";
			string[] array = Resources.Load<TextAsset>(Path.Combine(path, "Manifest")).text.Split(new string[2] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string text in array)
			{
				try
				{
					string text2 = Path.Combine(Application.persistentDataPath, text);
					if (text2.EndsWith("/"))
					{
						DirectoryInfo directoryInfo = new DirectoryInfo(text2);
						if (!directoryInfo.Exists)
						{
							Directory.CreateDirectory(directoryInfo.FullName);
						}
					}
					else
					{
						InstallTextFileResource(Path.Combine(path, text), text2);
					}
				}
				catch (Exception ex)
				{
					Debug.LogErrorFormat("Failed to copy required game state file: {0}. Error: {1}", text, ex.ToString());
				}
			}
		}

		public void OnStartup()
		{
		}

		internal bool InstallXmlAssetsInFolderToDocuments(string resourceFolder, string persistentDataStoreDirectory, bool overwrite)
		{
			string text = (Path.IsPathFullyQualified(persistentDataStoreDirectory) ? persistentDataStoreDirectory : GameData.GetPath(persistentDataStoreDirectory));
			bool flag = File.Exists(text);
			if (!flag)
			{
				Directory.CreateDirectory(text);
			}
			TextAsset[] array = Resources.LoadAll<TextAsset>(resourceFolder);
			foreach (TextAsset textAsset in array)
			{
				string path = FileIOUtility.CombinePaths(text, textAsset.name + ".xml");
				bool num = File.Exists(path);
				if (num && overwrite)
				{
					File.Delete(path);
				}
				if (!num || overwrite)
				{
					File.WriteAllText(path, textAsset.text);
				}
				Resources.UnloadAsset(textAsset);
			}
			return flag;
		}

		private static void InstallTextFileResource(string resourcePath, string targetPath)
		{
			string path = Path.ChangeExtension(resourcePath, null);
			if (targetPath.EndsWith(".bytes"))
			{
				targetPath = targetPath.Substring(0, targetPath.Length - ".bytes".Length);
			}
			TextAsset textAsset = Resources.Load<TextAsset>(path);
			File.WriteAllBytes(targetPath, textAsset.bytes);
		}

		private void CheckForClonedEditor()
		{
			IsClonedEditor = Application.dataPath.Contains("_clone_");
			ClonedEditorName = null;
			ClonedEditorArgs = Array.Empty<string>();
		}

		private FileInfo CopyModFileToModDirectory(string modFilePath)
		{
			try
			{
				FileInfo fileInfo = new FileInfo(SystemUtils.GetLongPathName(modFilePath));
				if (fileInfo.Exists)
				{
					FileInfo fileInfo2 = new FileInfo(GameData.Mods.GetPath(fileInfo.Name));
					if (!fileInfo2.Directory.Exists)
					{
						fileInfo2.Directory.Create();
					}
					fileInfo.CopyTo(fileInfo2.FullName, overwrite: true);
					return fileInfo2;
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			return null;
		}

		private void InitializeInputManager()
		{
			InputManager = ResourceLoader.InstantiatePrefab<InputManager>("Input/InputManager");
			if (InputManager == null)
			{
				((Object)null).LogException("Unable to instantiate the input manager!!");
			}
			InputManager.userData.ConfigVars.windowsStandalonePrimaryInputSource = (Settings.Gameplay.General.UseDirectInput.Value ? WindowsStandalonePrimaryInputSource.DirectInput : WindowsStandalonePrimaryInputSource.RawInput);
			InputManager.userData.ConfigVars.android_supportUnknownGamepads = Settings.Gameplay.General.SupportUnknownGamepadsOnAndroid.Value;
			InputManager.gameObject.SetActive(value: true);
			Inputs = GameInputs.Instance;
			InputManagerXR = ResourceLoader.InstantiatePrefab<XRInputManager>("XR/Input/XRInputManager");
			if (InputManager == null)
			{
				((Object)null).LogException("Unable to instantiate the XR input manager!!");
			}
			else
			{
				UnityEngine.Object.DontDestroyOnLoad(InputManagerXR);
			}
			InputWrapper.ApplySceneControls();
		}

		private void InitializeMusic(float volume)
		{
			GameObject gameObject = Instance.ResourceLoader.InstantiatePrefab("Music/MusicPlayer");
			MusicPlayer = gameObject.GetComponent<MusicPlayerScript>();
			MusicPlayer.Volume = volume;
		}

		private void OnApplicationFocusChanged(bool hasFocus)
		{
			if (hasFocus)
			{
				CraftDatabase.RescanCraftFilesForChangesAsync().Forget();
			}
		}

		private void OnApplicationQuitting()
		{
			Application.quitting -= OnApplicationQuitting;
			Application.focusChanged -= OnApplicationFocusChanged;
		}

		private void OnGameWebCallback(object sender, GameWebCallbackEventArgs e)
		{
			Debug.Log("Game web callback received: " + e.Url);
			if (string.IsNullOrEmpty(e.Url))
			{
				return;
			}
			Uri uri = new Uri(e.Url);
			string text = uri.Segments[uri.Segments.Length - 1];
			if (Utilities.IsValidCraftUrlId(text))
			{
				string currentScene = SceneManager.CurrentScene;
				if (currentScene == "Designer")
				{
					Designer.Instance.DesignerScript.LoadAircraftFromClipboardOrUrl(text);
					return;
				}
				if (currentScene == "Terrain")
				{
					FlightSceneScript.Instance.LoadAircraftFromClipboardOrUrl(text);
					return;
				}
				DownloadedAircraftId = text;
				SceneManager.LoadDesigner();
			}
		}

		private void OnNewLaunchParameters(object sender, NewLaunchParametersEventArgs e)
		{
			string parameter = e.GetParameter("plane");
			string parameter2 = e.GetParameter("mod");
			Debug.LogFormat("Received new launch parameters: plane={0},  mod={1}", parameter, parameter2);
			SystemUtils.SwitchToThisWindow();
			if (!string.IsNullOrEmpty(parameter) && File.Exists(parameter))
			{
				string text = File.ReadAllText(parameter);
				if (Utilities.IsValidCraftUrlId(text))
				{
					if (CurrentLevel != null && CurrentLevel.SkipDesigner)
					{
						CurrentLevel = LevelDatabase.GetLevel("LevelSandbox");
						CurrentMap = new DefaultMap();
					}
					DownloadedAircraftId = text;
					SceneManager.LoadDesigner();
				}
			}
			else if (!string.IsNullOrEmpty(parameter2) && File.Exists(parameter2))
			{
				ModManagerScript.LoadExternalModFile(parameter2);
			}
		}

		private void ProcessCommandLineMods()
		{
			string[] array = System.Environment.GetCommandLineArgs() ?? new string[0];
			foreach (string text in array)
			{
				StringComparison comparisonType = StringComparison.InvariantCultureIgnoreCase;
				if (text.EndsWith(".sp2-mod", comparisonType) || text.EndsWith(".sp2-mod-android", comparisonType))
				{
					CopyModFileToModDirectory(text);
				}
			}
			if (SocialExt.IsSteam)
			{
				string text2 = SocialExt.Steam?.GetLaunchQueryParam("mod");
				if (!string.IsNullOrEmpty(text2) && File.Exists(text2))
				{
					CopyModFileToModDirectory(text2);
				}
			}
		}

		private void ProcessNewVersionSinceLastRun(Version newVersion, Version oldVersion)
		{
			Debug.Log("A new version (" + newVersion.ToString(4) + ") has been installed since last run (" + oldVersion.ToString(4) + ").");
			try
			{
				if (oldVersion < new Version(0, 5, 6, 0))
				{
					Instance.Settings.App.NumberOfApplicationRuns = 0;
					Instance.Settings.App.Save();
					Debug.Log("Resetting NumberOfApplicationRuns");
				}
				_newVersionSinceLastRun = true;
				_upgradeInputSystem = delegate
				{
					InputWrapper.OnVersionUpgrade(newVersion, oldVersion);
				};
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}
	}
}
