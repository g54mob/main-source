#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FullInspector;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;
using UnityConsole;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TH20
{
	[fiInspectorOnly]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class MetagameMap : MonoBehaviour, IGameEventsBase
	{
		[SerializeField]
		private Transform _rootObject;

		[SerializeField]
		private GraphicRaycaster _graphicRaycaster;

		[SerializeField]
		private RectTransform _canvasTransform;

		[SerializeField]
		private SharedInstance_TH20TH20_TopDownCameraLogic_Config _cameraLogicConfig;

		[SerializeField]
		private float _fadeTransitionTime = 1.5f;

		[SerializeField]
		private SharedInstance_TH20TH20_HUD_Config _metagameHUDConfig;

		[SerializeField]
		private MetagameMapUI _mapUI;

		[SerializeField]
		private AudioMixer _audioMixer;

		[SerializeField]
		private Transform _fixedCameraOverride;

		private App _app;

		private MetagameMapScene _mapScene;

		private string _metagameSceneName;

		private GameTime _gameTime;

		private InputManager _inputManager;

		private Level _level;

		private SaveSystem _saveSystem;

		private Camera _gameCamera;

		private TopDownCameraLogic _gameCameraLogic;

		private RectTransform _menusTransform;

		private RectTransform _inWorldTransform;

		private StateMachine _stateMachine;

		private MetagameMapAmbience _metagameMapAmbience;

		private HUD _hud;

		private TopDownCameraLogic _cameraLogic;

		private MetagameCutsceneManager _cutsceneManager;

		private HUDEvents _hudEvents;

		private bool _isTransitioning;

		private bool _prevPausedByUser;

		private List<Light> _disabledLights;

		private MipmapVisualiser _mipmapVisualiser;

		public Action OnOpen;

		public Action OnClose;

		public bool IsReadyToStart { get; private set; }

		public App App => _app;

		public HUD HUD => _hud;

		public Metagame Metagame => _app.GameMode?.Metagame;

		public SaveSystem SaveSystem => _saveSystem;

		public MetagameMapUI MapUI => _mapUI;

		public MetagameCutsceneManager CutsceneManager => _cutsceneManager;

		public InputManager InputManager => _inputManager;

		public TopDownCameraLogic CameraLogic => _cameraLogic;

		public StateMachine StateMachine => _stateMachine;

		public MetagameCutsceneAudioPlayer CutsceneAudioPlayer => _mapScene.CutsceneAudioPlayer;

		public Transform DefaultCollaborativeModeCameraTransform => _mapScene.DefaultCollaborativeModeCameraTransform;

		public HUDEvents HUDEvents => _hudEvents;

		public bool IsTransitioning => _isTransitioning;

		public bool IsVisible => _rootObject.gameObject.activeSelf;

		public Level Level => _level;

		public Transform RootTransform => _rootObject;

		public MetagameMap()
		{
			GameEventsRegistry.RegisterGlobalEvent(this);
		}

		public void Initialise(App app, MetagameMapScene metagameMapScene, string metagameSceneName, InputManager inputManager, RectTransform menusTransform, RectTransform inWorldTransform, SaveSystem saveSystem, Preferences userPreferences, LocalPreferences localPreferences)
		{
			_app = app;
			_mapScene = metagameMapScene;
			_metagameSceneName = metagameSceneName;
			_inputManager = inputManager;
			_menusTransform = menusTransform;
			_inWorldTransform = inWorldTransform;
			_saveSystem = saveSystem;
			_hudEvents = new HUDEvents();
			_hudEvents.Initialise(isGlobalHUD: true);
			_hud = new HUD(_canvasTransform, _canvasTransform, _metagameHUDConfig.Instance, _hudEvents, _inputManager, null, destroyChildren: false);
			_cameraLogic = new TopDownCameraLogic(_inputManager, _cameraLogicConfig.Instance, userPreferences, localPreferences, _rootObject, null);
			_cameraLogic.CameraComponent.gameObject.AddComponent<AudioListener>();
			_cutsceneManager = new MetagameCutsceneManager();
			_cutsceneManager.RegisterCutsceneLocation(metagameMapScene.CollaborativeIntroCutsceneLocation);
			_mapScene.CutsceneEventBehaviour.Initialise(this);
			Metagame.CutsceneEvents.Initialise(this);
			_inputManager.AddGraphicRayCaster(_graphicRaycaster);
			_mapUI.Setup(_app, Metagame, this, _inputManager, _hud, _cameraLogic);
			_metagameMapAmbience = new MetagameMapAmbience(_cameraLogic, Metagame.MetagameConfig.MetagameMapAmbienceConfig);
			_stateMachine = new StateMachine(new MetagameStateData());
			_stateMachine.PushState(App.GameMode.CreateStateMachine(this));
			GameObjectUtils.SetActive(_mapScene.Projector.gameObject, isActive: true);
			ConsoleCommandsDatabase.RegisterCommand("LogLightingInfo", "Prints information about all lights in the scene to the log.", "LogLightingInfo", Debug_LogLightingInfo);
			ConsoleCommandsDatabase.RegisterCommand("AddSceneAdditive", "Adds a scene additiviely to the current one", "AddSceneAdditive ExtraScene", Debug_AddSceneAdditive);
			ConsoleCommandsDatabase.RegisterCommand("ToggleDebugMetagameCamera", "Allows greater pitch angles on the metagame camera", "ToggleDebugMetagameCamera", Debug_ToggleDebugMetagameCamera);
			ConsoleCommandsDatabase.RegisterCommand("TestHospitalRaiseAnim", "Tests the hospital raise animation", "TestHospitalRaiseAnim LevelId State", Debug_TestHospitalRaiseAnim);
			ConsoleCommandsDatabase.RegisterCommand("TestHospitalRaiseInstantly", "Tests the hospital raise instantly", "TestHospitalRaiseInstantly LevelId State", Debug_TestHospitalRaiseInstantly);
			ConsoleCommandsDatabase.RegisterCommand("ToggleMipmapVisualiser", "Toggles the mipmap visualiser", "ToggleMipmapVisualiser", Debug_ToggleMipmapVisualiser);
		}

		public void InitialiseFromLevel(Level level, GameTime gameTime, TopDownCameraLogic topDownCameraLogic)
		{
			_level = level;
			_gameTime = gameTime;
			_gameCameraLogic = topDownCameraLogic;
			_gameCamera = ((_gameCameraLogic == null) ? null : _gameCameraLogic.CameraComponent);
		}

		public void Uninitialise()
		{
			_mapUI.Uninitialise();
		}

		public void Destroy()
		{
			ConsoleCommandsDatabase.UnRegisterCommand("LogLightingInfo");
			ConsoleCommandsDatabase.UnRegisterCommand("AddSceneAdditive");
			ConsoleCommandsDatabase.UnRegisterCommand("ToggleDebugMetagameCamera");
			ConsoleCommandsDatabase.UnRegisterCommand("TestHospitalRaiseAnim");
			ConsoleCommandsDatabase.UnRegisterCommand("TestHospitalRaiseInstantly");
			ConsoleCommandsDatabase.UnRegisterCommand("ToggleMipmapVisualiser");
			if (_rootObject.gameObject.activeSelf)
			{
				TooltipManager.Instance.PopGUIRoot(_canvasTransform);
			}
			_stateMachine.Destroy();
			_cutsceneManager.Destroy();
			_metagameMapAmbience.Destroy();
			_metagameMapAmbience = null;
			if (_cameraLogic != null)
			{
				_cameraLogic.Destroy();
				_cameraLogic = null;
			}
			_hudEvents.Destroy();
			_inputManager.RemoveGraphicRayCaster(_graphicRaycaster);
		}

		public void VerifyEvents()
		{
		}

		public void Open()
		{
			_isTransitioning = true;
			if (_level == null)
			{
				OpenInternal();
				return;
			}
			_prevPausedByUser = _gameTime.IsPausedByUser;
			_gameTime.IsPausedByUser = true;
			_level.TakeThumbnail();
			_gameCamera.gameObject.GetOrAddComponent<CameraCloudZoomComponent>().ZoomOut(_fadeTransitionTime, 50f);
			_app.FadeOut(_fadeTransitionTime, Color.white, delegate
			{
				_gameTime.IsSuperPaused = true;
				_gameTime.IsPausedByUser = _prevPausedByUser;
				OpenInternal();
				_cameraLogic.CameraComponent.gameObject.GetOrAddComponent<CameraCloudZoomComponent>().ZoomIn(_fadeTransitionTime, -50f);
				_app.FadeIn(_fadeTransitionTime, Color.white);
			});
		}

		public void Close(LevelConfig nextLevelConfig = null, bool ignoreSave = false, bool saveOldLevel = true, bool forceLevelLoad = false)
		{
			_isTransitioning = true;
			if (_gameTime != null)
			{
				_gameTime.IsSuperPaused = false;
			}
			_cameraLogic.CameraComponent.gameObject.GetOrAddComponent<CameraCloudZoomComponent>().ZoomOut(_fadeTransitionTime, -50f);
			_app.FadeOut(_fadeTransitionTime, Color.white, delegate
			{
				bool flag = false;
				if (_level != null && _level.FinanceManager.IsBankrupt && (nextLevelConfig == null || nextLevelConfig == _level.Config))
				{
					flag = true;
					_app.LoadLevel(_level.Config, null, ignoreSave);
				}
				else if (nextLevelConfig != null && (_level == null || _level.Config != nextLevelConfig || ignoreSave || forceLevelLoad))
				{
					_level = null;
					flag = true;
					_app.LoadLevel(nextLevelConfig, null, ignoreSave, saveOldLevel);
				}
				CloseInternal();
				if (!flag && _level != null)
				{
					_level.StartCameraFadeIn(_fadeTransitionTime);
				}
			});
		}

		public void CloseAfterLoad()
		{
			CloseInternal();
			if (_level != null)
			{
				_level.StartCameraFadeIn(_fadeTransitionTime);
			}
		}

		private void OpenInternal()
		{
			OnOpen.InvokeSafe();
			_rootObject.gameObject.SetActive(value: true);
			_mapScene.RootObject.SetActive(value: true);
			_menusTransform.gameObject.SetActive(value: false);
			_inWorldTransform.gameObject.SetActive(value: false);
			if (_gameTime != null && _gameCamera != null)
			{
				_gameTime.IsSuperPaused = true;
				_gameCamera.gameObject.SetActive(value: false);
			}
			DisableGameLights();
			if (_fixedCameraOverride != null)
			{
				CameraGentleSwayComponent orAddComponent = _cameraLogic.CameraComponent.gameObject.GetOrAddComponent<CameraGentleSwayComponent>();
				orAddComponent.CameraSwayAmplitude = new Vector2(3f, 3f);
				orAddComponent.CameraSwayFrequency = new Vector2(0.41f, 0.73f);
				_cameraLogic.SetFixedTransform(_fixedCameraOverride);
			}
			TooltipManager.Instance.PushGUIRoot(_canvasTransform);
			SceneManager.SetActiveScene(SceneManager.GetSceneByName(_metagameSceneName));
			_mapUI.Open();
			if (_level != null)
			{
				if (_stateMachine.TopState is BaseStateInHospital baseStateInHospital)
				{
					baseStateInHospital.OnReturnToMetagameMap();
				}
				else
				{
					Logging.Warning(LogChannels.Metagame, "We've come back to the MetagameMap from a hospital, but we're not in a BaseStateInHospital!");
				}
				PauseMenu pauseMenu = _level.HUD.FindMenu<PauseMenu>();
				if (pauseMenu != null)
				{
					pauseMenu.CloseMenu();
				}
			}
			_audioMixer.SetFloat("MetamapAmbiencePitch", 1f);
			Metagame.OnlineMetadataManager.GetLatestData();
			IsReadyToStart = true;
			_isTransitioning = false;
			CheckForAchievements();
		}

		private void CloseInternal()
		{
			if (_gameTime != null && _gameCamera != null)
			{
				_gameTime.IsSuperPaused = false;
				_gameCamera.gameObject.SetActive(value: true);
			}
			_rootObject.gameObject.SetActive(value: false);
			_mapScene.RootObject.SetActive(value: false);
			_menusTransform.gameObject.SetActive(value: true);
			_inWorldTransform.gameObject.SetActive(value: true);
			CameraGentleSwayComponent component = _cameraLogic.CameraComponent.gameObject.GetComponent<CameraGentleSwayComponent>();
			if (component != null)
			{
				UnityEngine.Object.Destroy(component);
			}
			_cameraLogic.SetFixedTransform(null);
			_mapUI.Close();
			EnableGameLights();
			if (_app.PreferencesScreen.gameObject.activeSelf)
			{
				_app.PreferencesScreen.CloseAndSavePreferences();
			}
			TooltipManager.Instance.PopGUIRoot(_canvasTransform);
			if (_level != null)
			{
				SceneManager.SetActiveScene(SceneManager.GetSceneByName(_level.Config.SceneName));
			}
			_audioMixer.SetFloat("MetamapAmbiencePitch", 0f);
			OnClose.InvokeSafe();
			_isTransitioning = false;
		}

		private void EnableGameLights()
		{
			if (_disabledLights == null)
			{
				return;
			}
			foreach (Light disabledLight in _disabledLights)
			{
				if (disabledLight != null)
				{
					disabledLight.enabled = true;
				}
			}
			_disabledLights = null;
		}

		private void DisableGameLights()
		{
			Light[] array = (Light[])UnityEngine.Object.FindObjectsOfType(typeof(Light));
			if (array.Length == 0)
			{
				return;
			}
			_disabledLights = new List<Light>();
			Light[] array2 = array;
			foreach (Light light in array2)
			{
				if (light.enabled && light != _mapScene.SceneLight && !light.gameObject.GetComponent<MetagameSceneLight>() && (_mapScene.SceneLights == null || !_mapScene.SceneLights.Contains(light)))
				{
					_disabledLights.Add(light);
					light.enabled = false;
				}
			}
		}

		private ConsoleCommandResult Debug_ToggleMipmapVisualiser(string[] args)
		{
			if (_mipmapVisualiser != null)
			{
				GameObjectUtils.SetActive(_mapScene.Projector.gameObject, isActive: true);
				UnityEngine.Object.Destroy(_mipmapVisualiser.gameObject);
				_mipmapVisualiser = null;
			}
			else
			{
				GameObjectUtils.SetActive(_mapScene.Projector.gameObject, isActive: false);
				GameObject gameObject = UnityEngine.Object.Instantiate(Metagame.MetagameConfig.MipMapVisualiserPrefab);
				_mipmapVisualiser = gameObject.GetComponent<MipmapVisualiser>();
				if (_mipmapVisualiser == null)
				{
					return ConsoleCommandResult.Failed("Could not create Mipmap Visualiser from prefab.  No MipmapVisualiser component found!");
				}
			}
			return ConsoleCommandResult.Succeeded(string.Format("MipmapVisualiser is {0}", (_mipmapVisualiser != null) ? "ON" : "OFF"));
		}

		private ConsoleCommandResult Debug_LogLightingInfo(string[] args)
		{
			StringBuilder stringBuilder = new StringBuilder();
			Light[] array = (Light[])UnityEngine.Object.FindObjectsOfType(typeof(Light));
			foreach (Light light in array)
			{
				string value = $"Light: {light.gameObject.name}, Intensity = {light.intensity}, Color = {light.color}, RenderMode = {light.renderMode}, InScene = {light.gameObject.scene.name}";
				stringBuilder.AppendLine(value);
			}
			return ConsoleCommandResult.Succeeded(stringBuilder.ToString());
		}

		private ConsoleCommandResult Debug_AddSceneAdditive(string[] args)
		{
			if (args.Length != 1)
			{
				return ConsoleCommandResult.Failed("Usage: AddSceneAdditive [SceneName]");
			}
			SceneManager.LoadScene(args[0], LoadSceneMode.Additive);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_ToggleDebugMetagameCamera(string[] args)
		{
			CameraLogic.IsDebugCameraEnabled = !CameraLogic.IsDebugCameraEnabled;
			return ConsoleCommandResult.Succeeded(string.Format("Debug Camera = {0}", CameraLogic.IsDebugCameraEnabled ? "On" : "Off"));
		}

		private ConsoleCommandResult Debug_TestHospitalRaiseAnim(string[] args)
		{
			if (args.Length < 1)
			{
				return ConsoleCommandResult.Failed("No arguments found!  Usage => TestHospitalRaiseAnim 901 1");
			}
			bool isUnlocked = true;
			if (args.Length == 2)
			{
				isUnlocked = int.Parse(args[1]) != 0;
			}
			MapPinHospital pinForLevelUniqueId = MapUI.GetPinForLevelUniqueId(args[0]);
			if (pinForLevelUniqueId == null)
			{
				return ConsoleCommandResult.Failed("Can't find HospitalPin");
			}
			if (pinForLevelUniqueId.HospitalVisual == null)
			{
				return ConsoleCommandResult.Failed("Can't find HospitalPin's HospitalVisual");
			}
			pinForLevelUniqueId.HospitalVisual.SetIsUnlocked(isUnlocked, instant: false);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_TestHospitalRaiseInstantly(string[] args)
		{
			if (args.Length < 1)
			{
				return ConsoleCommandResult.Failed("No arguments found!  Usage => TestHospitalRaiseAnim 901 1");
			}
			bool isUnlocked = true;
			if (args.Length == 2)
			{
				isUnlocked = int.Parse(args[1]) != 0;
			}
			MapPinHospital pinForLevelUniqueId = MapUI.GetPinForLevelUniqueId(args[0]);
			if (pinForLevelUniqueId == null)
			{
				return ConsoleCommandResult.Failed("Can't find HospitalPin");
			}
			if (pinForLevelUniqueId.HospitalVisual == null)
			{
				return ConsoleCommandResult.Failed("Can't find HospitalPin's HospitalVisual");
			}
			pinForLevelUniqueId.HospitalVisual.SetIsUnlocked(isUnlocked);
			return ConsoleCommandResult.Succeeded();
		}

		private void Update()
		{
			if (_stateMachine != null)
			{
				_stateMachine.Update();
			}
			if (_metagameMapAmbience != null)
			{
				_metagameMapAmbience.Update();
			}
		}

		private void CheckForAchievements()
		{
			MetagameHospitalRecord hospitalRecord = Metagame.GetHospitalRecord(Metagame.MetagameConfig.LifeUniverseLevelComplete.Instance, canBeNull: true);
			if (hospitalRecord != null && hospitalRecord.HasStarBeenAwarded(0))
			{
				PlatformStatsAndAchievements.TriggerAchievement(AchievementId.CompleteRegion7);
			}
			MetagameHospitalRecord hospitalRecord2 = Metagame.GetHospitalRecord(Metagame.MetagameConfig.CloseEncountersDLCLevelConfig.Instance, canBeNull: true);
			if (hospitalRecord2 != null && hospitalRecord2.HasStarBeenAwarded(0))
			{
				PlatformStatsAndAchievements.TriggerAchievement(AchievementId.CompleteRegion8);
			}
			MetagameHospitalRecord hospitalRecord3 = Metagame.GetHospitalRecord(Metagame.MetagameConfig.OffTheGridDLCLevelConfig.Instance, canBeNull: true);
			if (hospitalRecord3 != null && hospitalRecord3.HasStarBeenAwarded(0))
			{
				PlatformStatsAndAchievements.TriggerAchievement(AchievementId.CompleteRegion9);
			}
			MetagameHospitalRecord hospitalRecord4 = Metagame.GetHospitalRecord(Metagame.MetagameConfig.CultureShockDLCLevelConfig.Instance, canBeNull: true);
			if (hospitalRecord4 != null && hospitalRecord4.HasStarBeenAwarded(0))
			{
				PlatformStatsAndAchievements.TriggerAchievement(AchievementId.CompleteRegion10);
			}
			MetagameHospitalRecord hospitalRecord5 = Metagame.GetHospitalRecord(Metagame.MetagameConfig.TimeTravelDLCLevelConfig.Instance, canBeNull: true);
			if (hospitalRecord5 != null && hospitalRecord5.HasStarBeenAwarded(0))
			{
				PlatformStatsAndAchievements.TriggerAchievement(AchievementId.CompleteRegion11);
			}
			MetagameHospitalRecord hospitalRecord6 = Metagame.GetHospitalRecord(Metagame.MetagameConfig.SpeedyRecoveryDLCLevelConfig.Instance, canBeNull: true);
			if (hospitalRecord6 != null && hospitalRecord6.HasStarBeenAwarded(0))
			{
				PlatformStatsAndAchievements.TriggerAchievement(AchievementId.CompleteRegion12);
			}
			SharedInstance<LevelConfig>[] region1RemixConfigs;
			if (Metagame.MetagameConfig.Region1RemixConfigs.Length != 0)
			{
				bool flag = true;
				region1RemixConfigs = Metagame.MetagameConfig.Region1RemixConfigs;
				for (int i = 0; i < region1RemixConfigs.Length; i++)
				{
					LevelConfig instance = region1RemixConfigs[i].Instance;
					if (instance != null)
					{
						MetagameHospitalRecord hospitalRecord7 = Metagame.GetHospitalRecord(instance);
						if (hospitalRecord7 != null && !hospitalRecord7.HasRemixBadgeBeenAwarded())
						{
							flag = false;
							break;
						}
					}
				}
				if (flag)
				{
					PlatformStatsAndAchievements.TriggerAchievement(AchievementId.RemixRegion1);
				}
			}
			if (Metagame.MetagameConfig.Region2RemixConfigs.Length == 0)
			{
				return;
			}
			bool flag2 = true;
			region1RemixConfigs = Metagame.MetagameConfig.Region2RemixConfigs;
			for (int i = 0; i < region1RemixConfigs.Length; i++)
			{
				LevelConfig instance2 = region1RemixConfigs[i].Instance;
				if (instance2 != null)
				{
					MetagameHospitalRecord hospitalRecord8 = Metagame.GetHospitalRecord(instance2);
					if (hospitalRecord8 != null && !hospitalRecord8.HasRemixBadgeBeenAwarded())
					{
						flag2 = false;
						break;
					}
				}
			}
			if (flag2)
			{
				PlatformStatsAndAchievements.TriggerAchievement(AchievementId.RemixRegion2);
			}
		}
	}
}
